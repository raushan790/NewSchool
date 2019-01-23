using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class StateSetting : System.Web.UI.Page
{
    Dbutility objDbutility = new Dbutility();
    protected static string strType;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UID"] = 1;
        if (!IsPostBack)
        {
            txtState.Attributes.Add("AutoComplete", "off");
        }
        objDbutility.FillDDLs(ddlCountry, "SELECT 0 AS CountryID,'' AS CountryName UNION SELECT CountryID AS CountryID,CountryName AS CountryName  FROM CountrySetting ORDER BY CountryID  ", "CountryId", "CountryName");
        if (ddlCountry.Items.Count > 0)
        {
            ddlCountry.Items[0].Text = objDbutility.pDisplayMessage("1", "6", "Country");
        }
        Session["Type"] = "1";
        if ((Session["Type"] == null) || (Session["Type"].ToString() == "1"))
        {
            strType = "ltr";
        }
        else
        {
            strType = "rtl";
        }
        BindData();
    }
    protected void BindData()
    {
        PlaceHolder1.Controls.Clear();
        //Populating a DataTable from database.
        DataTable dt = this.GetData();
        //Building an HTML string.
        StringBuilder html = new StringBuilder();
        //Table start.
        html.Append("<table id=\"tableId\" class=\"table table - striped jambo_table bulk_action\">");
        //Building the Header row. style="display: none;"
        html.Append("  <thead>  <tr class=\"headings\">");
        int ColCount = 0;
        foreach (DataColumn column in dt.Columns)
        {
            if (ColCount == 0)
            {
                html.Append("<th class=\"column - title\" style=\"display: none; \">");
                html.Append(column.ColumnName);
                html.Append("</th>");
            }
            else
            {
                html.Append("<th class=\"column - title\">");
                html.Append(column.ColumnName);
                html.Append("</th>");
            }
            ColCount = ColCount + 1;
        }
        html.Append("  </thead>  </tr>");
        ColCount = 0;
        //Building the Data rows.
        foreach (DataRow row in dt.Rows)
        {
            ColCount = 0;
            html.Append("<tr class=\"even pointer\">");
            foreach (DataColumn column in dt.Columns)
            {
                if (ColCount == 0)
                {
                    html.Append("<td class=\" \" style=\"display: none; \" >");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                else
                {
                    html.Append("<td class=\" \">");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                ColCount = ColCount + 1;
            }
            html.Append("  </tr>");
        }

        //Table end.
        html.Append("</table>");
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
    }
    private DataTable GetData()
    {
        DataTable dt = objDbutility.BindDataTable("SELECT SM.StateID,SM.StateName [State],CM.CountryID,CM.CountryName [Country]" +
                    " FROM StateSetting SM  INNER JOIN CountrySetting CM ON CM.CountryID = SM.CountryID "+
                    " WHERE SM.StateID <> 0   ORDER BY CM.CountryName, SM.StateName");
        return dt;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult;
            string[] astrFlag = hdnFlag.Value.Split('^');
            if (astrFlag[0] == "N" || (astrFlag[0] == "E" && astrFlag[3].Trim().ToUpper() != txtState.Value.Trim().ToUpper()))
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(StateID) FROM StateSetting WHERE StateName=" + objDbutility.fReplaceChar(txtState) + " AND CountryID=" + hdnddlVal.Value) > 0)
                {
                    strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "5", lblState.Text.Trim().Split('<')[0]);
                    ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>alert('" + strResult + "')</script>");
                    return;
                }
            }
            if (astrFlag[0] == "N")
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(*) FROM StateSetting") == 0)
                {
                    strResult = objDbutility.ExecuteQuery("INSERT INTO StateSetting(StateID,StateName,CountryID) values(0,'',0)");
                }
                strResult = objDbutility.ExecuteQuery("INSERT INTO StateSetting(StateID,StateName,CountryID,EntryUserID,EntryDate) SELECT ISNULL(MAX(StateID),0)+1," + objDbutility.fReplaceChar(txtState) + "," + hdnddlVal.Value + ", " +
                       "" + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM StateSetting");
                strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuState','State: " + (txtState.Value.Trim().Replace("'", "''") != "" ? txtState.Value.Trim().Replace("'", "''") : txtState.Value.Trim().Replace("'", "''")) + " ,Is Added In " + ddlCountry.SelectedItem + "')");


            }
            else
            {
                strResult = objDbutility.ExecuteQuery("UPDATE StateSetting SET StateName='" + txtState.Value.Trim().Replace("'", "''") + "',CountryID=" + hdnddlVal.Value + "," +
                    " UpdateUserID=" + Convert.ToInt32(Session["UID"]) + ",UpdateDate=GetDate() WHERE stateId=" + astrFlag[1] + "");
                strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuState','State: " + astrFlag[3] + " To " + (txtState.Value.Trim().Replace("'", "''") != "" ? txtState.Value.Trim().Replace("'", "''") : txtState.Value.Trim().Replace("'", "''")) + " ,Is Modified of Country " + ddlCountry.SelectedItem + "')");
            }
            BindData();
            txtState.Value = "";
            hdnFlag.Value = "";
            if (strResult == "")
            {
                if (astrFlag[0] == "N")
                {
                    strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "1", "");
                }
                else
                {
                    strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "2", "");
                }
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('" + strResult + "');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('" + strResult + "')</script>");
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "disError", "<script language='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult;
            string[] astrFlag = hdnFlag.Value.ToString().Split('^');
            if (objDbutility.ReturnNumericValue("EXEC GetDataused 'StateID','StateSetting','" + astrFlag[0] + "'") > 0)
            {
                strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "4", "");
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>alert('" + strResult + "')</script>");
                hdnFlag.Value = "";
                txtState.Value = "";
                return;
            }
            strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuCountry','Category Name: " + (txtState.Value.Trim().Replace("'", "''") != "" ? txtState.Value.Trim().Replace("'", "''") : txtState.Value.Trim().Replace("'", "''")) + " ,Is Deleted')");
            strResult = objDbutility.ExecuteQuery("DELETE FROM StateSetting WHERE StateID= " + astrFlag[0] + "");
            BindData();
            txtState.Value = "";
            hdnFlag.Value = "";
            if (strResult == "")
            {
                strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "3", "");
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('" + strResult + "')</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('" + strResult + "')</script>");
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
        }
    }
}
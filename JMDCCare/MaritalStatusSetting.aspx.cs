using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class MaritalStatusSetting : System.Web.UI.Page
{
    Dbutility objDbutility = new Dbutility();
    protected static string strType;
    protected static string strHideID = "$('td:nth-child(1),th:nth-child(1)').hide();";

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UID"] = 1;
        if (!IsPostBack)
        {
            txtMaritalStatus.Attributes.Add("AutoComplete", "off");
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
        DataTable dt = objDbutility.BindDataTable("SELECT MaritalStatusID, MaritalStatusName [Marital Status] FROM MaritalStatusSetting  WHERE MaritalStatusID<>0 ORDER BY MaritalStatusName");
        return dt;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult;
            string[] astrFlag = hdnFlag.Value.ToString().Split('^');
            if (astrFlag[0] == "N" || astrFlag[0] == "E" && astrFlag[2].Trim().ToUpper() != txtMaritalStatus.Value.Trim().ToUpper())
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(MaritalStatusName) FROM MaritalStatusSetting WHERE UPPER(MaritalStatusName) =" + objDbutility.fReplaceChar(txtMaritalStatus) + "") != 0)
                {
                    strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "5", lblMaritalStatus.Text.Trim().Split('<')[0]);
                    ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>" + strHideID + "  alert('" + strResult + "');</script>");
                    hdnFlag.Value = hdnFlag.Value + "N";
                    return;
                }
            }
            if (astrFlag[0] == "N")
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(*) FROM MaritalStatusSetting") == 0)
                {
                    strResult = objDbutility.ExecuteQuery("INSERT INTO MaritalStatusSetting(MaritalStatusID,MaritalStatusName) VALUES(0,'')");
                }
                strResult = objDbutility.ExecuteQuery("INSERT INTO MaritalStatusSetting(MaritalStatusID,MaritalStatusName,EntryUserID,EntryDate) SELECT (ISNULL(MAX(MaritalStatusID),0))+1," + objDbutility.fReplaceChar(txtMaritalStatus) + ", " +
                                      "" + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM MaritalStatusSetting");
                strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuMaritalStatus','Marital Status: " + (txtMaritalStatus.Value.Trim().Replace("'", "''") != "" ? txtMaritalStatus.Value.Trim().Replace("'", "''") : txtMaritalStatus.Value.Trim().Replace("'", "''")) + " ,Is Added')");

            }
            else
            {
                strResult = objDbutility.ExecuteQuery("UPDATE MaritalStatusSetting SET MaritalStatusName=" + objDbutility.fReplaceChar(txtMaritalStatus) + ",UpdateUserID=" + Convert.ToInt32(Session["UID"]) + ", " +
                                      "UpdateDate=GetDate() WHERE MaritalStatusID=" + astrFlag[1] + "");
                strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuMaritalStatus','Marital Status: " + astrFlag[2] + " To " + (txtMaritalStatus.Value.Trim().Replace("'", "''") != "" ? txtMaritalStatus.Value.Trim().Replace("'", "''") : txtMaritalStatus.Value.Trim().Replace("'", "''")) + " ,Is Modified')");

            }
            BindData();
            txtMaritalStatus.Value = "";
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
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult;
            string[] astrFlag = hdnFlag.Value.ToString().Split('^');
            if (objDbutility.ReturnNumericValue("EXEC GetDataused 'MaritalStatusID','MaritalStatusSetting','" + astrFlag[0] + "'") > 0)
            {
                strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "4", "");
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>alert('" + strResult + "')</script>");
                hdnFlag.Value = "";
                txtMaritalStatus.Value = "";
                return;
            }
            strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuCountry','Marital Status: " + (txtMaritalStatus.Value.Trim().Replace("'", "''") != "" ? txtMaritalStatus.Value.Trim().Replace("'", "''") : txtMaritalStatus.Value.Trim().Replace("'", "''")) + " ,Is Deleted')");
            strResult = objDbutility.ExecuteQuery("DELETE FROM MaritalStatusSetting WHERE MaritalStatusID= " + astrFlag[0] + "");
            BindData();
            txtMaritalStatus.Value = "";
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
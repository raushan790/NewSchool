using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;

public partial class NationalitySetting : System.Web.UI.Page
{
       Dbutility objDbutility = new Dbutility();
    protected static string strType;
    protected static string strHideID = "$('td:nth-child(1),th:nth-child(1)').hide();";

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UID"] = 1;
        if (!IsPostBack)
        {
            txtNationalityName.Attributes.Add("AutoComplete", "off");
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
        DataTable dt = objDbutility.BindDataTable("SELECT NationalityID, NationalityName [Nationality] FROM NationalitySetting  WHERE NationalityID<>0 ORDER BY NationalityName");
        return dt;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult;            
            string[] astrFlag = hdnFlag.Value.ToString().Split('^');
            if (astrFlag[0] == "N" || astrFlag[0] == "E" && astrFlag[2].Trim().ToUpper() != txtNationalityName.Value .Trim().ToUpper())
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(NationalityName) FROM NationalitySetting WHERE UPPER(NationalityName) =" + objDbutility.fReplaceChar(txtNationalityName) + "") != 0)
                {
                    strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "5", lblNationalityName.Text.Trim().Split('<')[0]);
                    ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>" + strHideID + "  alert('" + strResult + "');</script>");
                    return;
                }
            }
            if (astrFlag[0] == "N")
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(*) FROM NationalitySetting") == 0)
                {
                    strResult = objDbutility.ExecuteQuery("INSERT INTO NationalitySetting(NationalityID,NationalityName) VALUES(0,'')");
                }
                strResult = objDbutility.ExecuteQuery("INSERT INTO NationalitySetting(NationalityID,NationalityName,EntryUserID,EntryDate) SELECT (ISNULL(MAX(NationalityID),0))+1," + objDbutility.fReplaceChar(txtNationalityName) + ", " +
                                      "" + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM NationalitySetting");
               strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuNationality','Nationality: " + (txtNationalityName.Value.Trim().Replace("'", "''") != "" ? txtNationalityName.Value.Trim().Replace("'", "''") : txtNationalityName.Value.Trim().Replace("'", "''")) + " ,Is Added')");
            }
            else
            {
                strResult = objDbutility.ExecuteQuery("UPDATE NationalitySetting SET NationalityName=" + objDbutility.fReplaceChar(txtNationalityName) + ",UpdateUserID=" + Convert.ToInt32(Session["UID"]) + ", " +
                                      "UpdateDate=GetDate() WHERE NationalityID="+ astrFlag[1]+"");
                strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuNationality','Nationality: " + astrFlag[2] + " To " + (txtNationalityName.Value.Trim().Replace("'", "''") != "" ? txtNationalityName.Value.Trim().Replace("'", "''") : txtNationalityName.Value.Trim().Replace("'", "''")) + " ,Is Modified')");
            }
            BindData();
            txtNationalityName.Value = "";
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
            if (objDbutility.ReturnNumericValue("EXEC GetDataused 'NationalityID','NationalitySetting','"+ astrFlag[0] +"'") > 0)
            {
                strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "4", "");
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>alert('" + strResult + "')</script>");
                return;
            }
            strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuCountry','Country: " + (txtNationalityName.Value.Trim().Replace("'", "''") != "" ? txtNationalityName.Value.Trim().Replace("'", "''") : txtNationalityName.Value.Trim().Replace("'", "''")) + " ,Is Deleted')");
            strResult = objDbutility.ExecuteQuery("DELETE FROM NationalitySetting WHERE NationalityID= "+astrFlag[0]+"");
            BindData();
            txtNationalityName.Value = "";
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
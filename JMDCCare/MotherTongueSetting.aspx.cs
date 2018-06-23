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

public partial class MotherTongueSetting : System.Web.UI.Page
{
    Dbutility objDbutility = new Dbutility();
    protected static string strType;
    protected static string strHideID = "$('td:nth-child(1),th:nth-child(1)').hide();";

    protected void Page_Load(object sender, EventArgs e)
    {
        // ClientScript.RegisterStartupScript(this.GetType(), "disScript", "<script language='javascript'>" + strHideID + "</script>");
        Session["UID"] = 1;
        if (!IsPostBack)
        {
            txtMotherTongue.Attributes.Add("AutoComplete", "off");
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
        DataTable dt = objDbutility.BindDataTable("SELECT MotherTongueID, MotherTongueName [Country Name] FROM MotherTongueSetting  WHERE MotherTongueID<>0 ORDER BY MotherTongueName");
        return dt;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult;
            string[] astrFlag = hdnFlag.Value.ToString().Split('^');
            if (astrFlag[0] == "N" || astrFlag[0] == "E" && astrFlag[2].Trim().ToUpper() != txtMotherTongue.Value.Trim().ToUpper())
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(MotherTongueName) FROM MotherTongueSetting WHERE UPPER(MotherTongueName) =" + objDbutility.fReplaceChar(txtMotherTongue) + "") != 0)
                {
                    strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "5", lblMotherTongue.InnerHtml.Trim().Split('<')[0]);
                    ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>" + strHideID + "  alert('" + strResult + "');</script>");
                    return;
                }
            }
            if (astrFlag[0] == "N")
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(*) FROM MotherTongueSetting") == 0)
                {
                    strResult = objDbutility.ExecuteQuery("INSERT INTO MotherTongueSetting(MotherTongueID,MotherTongueName) VALUES(0,'')");
                }
                strResult = objDbutility.ExecuteQuery("INSERT INTO MotherTongueSetting(MotherTongueID,MotherTongueName,EntryUserID,EntryDate) SELECT (ISNULL(MAX(MotherTongueID),0))+1," + objDbutility.fReplaceChar(txtMotherTongue) + ", " +
                                      "" + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM MotherTongueSetting");
                strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuMotherTongue','Mother Tongue: " + (txtMotherTongue.Value.Trim().Replace("'", "''") != "" ? txtMotherTongue.Value.Trim().Replace("'", "''") : txtMotherTongue.Value.Trim().Replace("'", "''")) + " ,Is Added')");
            }
            else
            {
                strResult = objDbutility.ExecuteQuery("UPDATE MotherTongueSetting SET MotherTongueName=" + objDbutility.fReplaceChar(txtMotherTongue) + ",UpdateUserID=" + Convert.ToInt32(Session["UID"]) + ", " +
                                      "UpdateDate=GetDate() WHERE MotherTongueID=" + astrFlag[1] + "");
                strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuMotherTongue','Mother Tongue: " + astrFlag[2] + " To " + (txtMotherTongue.Value.Trim().Replace("'", "''") != "" ? txtMotherTongue.Value.Trim().Replace("'", "''") : txtMotherTongue.Value.Trim().Replace("'", "''")) + " ,Is Modified')");
            }
            BindData();
            txtMotherTongue.Value = "";
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
            if (objDbutility.ReturnNumericValue("EXEC GetDataused 'MotherTongueID','MotherTongueSetting','" + astrFlag[0] + "'") > 0)
            {
                strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "4", "");
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>alert('" + strResult + "')</script>");
                return;
            }
            strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuCountry','Country: " + (txtMotherTongue.Value.Trim().Replace("'", "''") != "" ? txtMotherTongue.Value.Trim().Replace("'", "''") : txtMotherTongue.Value.Trim().Replace("'", "''")) + " ,Is Deleted')");
            strResult = objDbutility.ExecuteQuery("DELETE FROM MotherTongueSetting WHERE MotherTongueID= " + astrFlag[0] + "");
            BindData();
            txtMotherTongue.Value = "";
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
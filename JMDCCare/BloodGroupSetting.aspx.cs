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

public partial class BloodGroupSetting : System.Web.UI.Page
{
    Dbutility objDbutility = new Dbutility();
    protected static string strType;

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetNoStore();
        Response.AddHeader("Cache-control", "no-store,must-revalidate,private,no-cache,no-store,pre-check=0,post-check=0,max-stale=0");
        Response.AddHeader("Pragma", "no-cache");
        Response.AddHeader("Expires", "0");
        if (!IsPostBack) // If page loads for first time 
        {
            Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString()); // Assign the Session["update"] with unique value
        }
        if (!IsPostBack)
        {
            txtBloodGroup.Attributes.Add("AutoComplete", "off");
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
    protected override void OnPreRender(EventArgs e)
    {
        ViewState["update"] = Session["update"];
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
        //Building the Header row.
        html.Append("  <thead>  <tr class=\"headings\">");
        foreach (DataColumn column in dt.Columns)
        {
            html.Append("<th class=\"column - title\">");
            html.Append(column.ColumnName);
            html.Append("</th>");
        }
        html.Append("  </thead>  </tr>");

        //Building the Data rows.
        foreach (DataRow row in dt.Rows)
        {
            html.Append("<tr class=\"even pointer\">");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<td class=\" \">");
                html.Append(row[column.ColumnName]);
                html.Append("</td>");
            }
            html.Append("  </tr>");
        }

        //Table end.
        html.Append("</table>");
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
    }
    private DataTable GetData()
    {
        DataTable dt = objDbutility.BindDataTable("SELECT BloodGroupName [Blood Group] FROM BloodGroupSetting  WHERE BloodGroupID<>0 ORDER BY BloodGroupName");
        return dt;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Session["update"].ToString() == ViewState["update"].ToString()) // If page not Refreshed 
        {
            try
            {
                string strResult;
                string[] strArray = hdnFlag.Value.Split('^');

                if (strArray[0] == "N")
                {
                    if (objDbutility.ReturnNumericValue("SELECT COUNT(*) FROM BloodGroupSetting WHERE UPPER(BloodGroupName)=" + objDbutility.fReplaceChar(txtBloodGroup) + "") > 0)
                    {
                        strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "5", lblBloodGroup.InnerText.Trim().Replace("' '", ""));
                        ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>alert('" + strResult + "')</script>");
                        txtBloodGroup.Focus();
                        return;
                    }

                }
                if (strArray[0] == "E" && strArray[1].Trim().ToUpper() != txtBloodGroup.Value.Trim().ToUpper())
                {
                    if (objDbutility.ReturnNumericValue("SELECT COUNT(*) FROM BloodGroupSetting WHERE UPPER(BloodGroupName)=" + objDbutility.fReplaceChar(txtBloodGroup) + "") > 0)
                    {
                        strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "5", lblBloodGroup.InnerText.Trim().Replace("' '", ""));
                        ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>alert('" + strResult + "')</script>");
                        txtBloodGroup.Focus();
                        return;
                    }
                }
                if (strArray[0] == "N")
                {
                    if (objDbutility.ReturnNumericValue("SELECT COUNT(*) FROM BloodGroupSetting") == 0)
                    {
                        strResult = objDbutility.ExecuteQuery("INSERT INTO BloodGroupSetting(BloodGroupID,BloodGroupName,PriorityNo) VALUES (0,'',0)");
                    }
                    strResult = objDbutility.ExecuteQuery("INSERT INTO BloodGroupSetting(BloodGroupID,BloodGroupName,EntryUserID,EntryDate) SELECT ISNULL(Max(BloodGroupID),0)+1," +
                        " " + objDbutility.fReplaceChar(txtBloodGroup) + ",'" + Convert.ToInt32(Session["UID"]) + "',GetDate() FROM BloodGroupSetting");
                    strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES('" + Session["UID"] + "','" + Session.SessionID + "',GETDATE(),'mnuClass','Class: " + (txtBloodGroup.Value.Trim().Replace("'", "''") != "" ? txtBloodGroup.Value.Trim().Replace("'", "''") : txtBloodGroup.Value.Trim().Replace("'", "''")) + "  ,Is Added')");
                }
                else
                {
                    strResult = objDbutility.ExecuteQuery("UPDATE BloodGroupSetting SET BloodGroupName=" + objDbutility.fReplaceChar(txtBloodGroup) + ",UpdateUserID='" + Convert.ToInt32(Session["UID"]) + "',UpdateDate=GetDate() WHERE BloodGroupName='" + strArray[1] + "'");
                    strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES('" + Session["UID"] + "','" + Session.SessionID + "',GETDATE(),'mnuClass','Class: " + strArray[1].Trim().ToUpper() + " To " + (txtBloodGroup.Value.Trim().Replace("'", "''") != "" ? txtBloodGroup.Value.Trim().Replace("'", "''") : txtBloodGroup.Value.Trim().Replace("'", "''")) + " ,Is Modified')");
                }
                BindData();
                clear();
                if (strResult == "")
                {
                    if (strArray[0] == "N")
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
    }
    protected void clear()
    {
        txtBloodGroup.Value = "";
        hdnFlag.Value = "";
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult = "";
            if (objDbutility.ReturnNumericValue("EXEC GetDataused 'BloodGroupName','BloodGroupSetting','" + hdnFlag.Value.Split('^')[0] + "'") > 0)
            {
                strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "4", "");
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>alert('" + strResult + "')</script>");
            }
            else
            {
                if (hdnFlag.Value != "")
                {
                    strResult = objDbutility.ExecuteQuery("DELETE FROM BloodGroupSetting WHERE UPPER(BloodGroupName)='" + hdnFlag.Value.Split('^')[0].ToUpper() + "'");
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
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('Please select title to delete.')</script>");
                }

                BindData();
                hdnFlag.Value = "";
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('" + ex.Message + "')</script>");
        }

    }
}
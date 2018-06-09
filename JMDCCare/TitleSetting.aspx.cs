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

public partial class TitleSetting : System.Web.UI.Page
{
    Dbutility objDbutility = new Dbutility();
    protected static string strType;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Type"] = "1";
        if ((Session["Type"] == null) || (Session["Type"].ToString() == "1"))
        {
            strType = "ltr";
        }
        else
        {
            strType = "rtl";
        }
        BindTitle();
    }
    protected void BindTitle()
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
        DataTable dt=objDbutility.BindDataTable("SELECT TitleName FROM TitleSetting  WHERE TitleID<>0 ORDER BY TitleName");
        return dt;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            TextBox t = new TextBox();
            t.Text = txtTitleName.Value;    
                    
            string strResult = "";
            //if (objDbutility.ReturnNumericValue("SELECT COUNT(TitleID) FROM TitleSetting") == 0)
            //{
            //    strResult = objDbutility.ExecuteQuery("INSERT INTO TitleSetting(TitleID,TitleName) VALUES(0,'')");
            //}
            //if (objDbutility.ReturnNumericValue("SELECT COUNT(TitleName) from TitleSetting WHERE UPPER(TitleName)='" + txtTitleName.Value.Trim().Replace("'", "''").ToUpper() + "'") > 0)
            //{
            //    strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "5", "Title");
            //    ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>alert('" + strResult + "')</script>");
            //    txtTitleName.Focus();
            //    return;
            //}
            //else if(hdnFlag.Value!="")
            //{
            //    strResult = objDbutility.ExecuteQuery("Update TitleSetting Set TitleName= '" + txtTitleName.Value.Trim().Replace("'","''") + "' Where TitleName='"+ hdnFlag.Value +"'");
            //    txtTitleName.Value = "";
            //}
            //else
            //{
            //    strResult = objDbutility.ExecuteQuery("INSERT INTO TitleSetting(TitleID,TitleName,EntryUserID,EntryDate) SELECT ISNULL(Max(TitleId),0)+1,'" + txtTitleName.Value.Trim().Replace("'", "''") + "'," + Convert.ToInt32(Session["UID"]) + ",GetDate() from TitleSetting");
            //    txtTitleName.Value = "";
            //}
            string[] strArray = hdnFlag.Value.Split('^');
            if (strArray[0] == "N" || (strArray[1] == "E" && strArray[0].Trim().ToUpper() != txtTitleName.Value.Trim().ToUpper()))
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(TitleName) from TitleSetting WHERE UPPER(TitleName)='" + txtTitleName.Value.Trim().Replace("'", "''").ToUpper() + "'") > 0)
                {
                    strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "5", "Title");
                    ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>alert('" + strResult + "')</script>");
                    txtTitleName.Focus();
                    return;
                }
            }
            if (strArray[0] == "N")
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(TitleID) FROM TitleSetting") == 0)
                {
                    strResult = objDbutility.ExecuteQuery("INSERT INTO TitleSetting(TitleID,TitleName) VALUES(0,'')");
                }
                else
                {
                    strResult = objDbutility.ExecuteQuery("INSERT INTO TitleSetting(TitleID,TitleName,EntryUserID,EntryDate) SELECT ISNULL(Max(TitleId),0)+1,'" + txtTitleName.Value.Trim().Replace("'", "''") + "'," + Convert.ToInt32(Session["UID"]) + ",GetDate() from TitleSetting");
                    txtTitleName.Value = "";
                }
            }
            else
            {
                strResult = objDbutility.ExecuteQuery("Update TitleSetting Set TitleName= '" + txtTitleName.Value.Trim().Replace("'", "''") + "' Where TitleName='" + strArray[0] + "'");
                txtTitleName.Value = "";
            }
            BindTitle();
            //if (strResult == "")
            //{
            //    if (hdnFlag.Value == "")
            //    {
            //        strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "1", "");

            //    }
            //    else
            //    {
            //        strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "2", "");
            //    }
            //    ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('" + strResult + "');</script>");
            //}
            //else
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "DisplayScript", "<script>alert('" + strResult + "')</script>");
            //}
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
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('" + strResult + "');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "DisplayScript", "<script>alert('" + strResult + "')</script>");
            }
            hdnFlag.Value = "";
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "DisplayScript", "<script>alert('" + ex.Message + "')</script>");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult = "";
            if (objDbutility.ReturnNumericValue("EXEC GetDataused 'TitleID','TitleSetting','" + hdnFlag.Value.Split('^')[0] + "'") > 0)
            {
                strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "4", "");
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>alert('" + strResult + "')</script>");
            }
            else
            {
                if (hdnFlag.Value != "")
                {
                    strResult = objDbutility.ExecuteQuery("DELETE FROM TitleSetting WHERE UPPER(TitleName)='" + hdnFlag.Value.Split('^')[0].ToUpper() + "'");
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

                BindTitle();
                hdnFlag.Value = "";
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('" + ex.Message + "')</script>");
        }

    }
}
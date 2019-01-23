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

public partial class BoardingCategorySetting : System.Web.UI.Page
{
    Dbutility objDbutility = new Dbutility();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtBoardingCategory.Attributes.Add("AutoComplete", "off");
        }
        Session["Type"] = "1";
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
        DataTable dt = objDbutility.BindDataTable("SELECT BoardingCategoryName [Boarding Category] FROM BoardingCategorySetting  WHERE BoardingCategoryID<>0 ORDER BY BoardingCategoryName");
        return dt;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult;
            string[] strArray = hdnFlag.Value.Split('^');

            if (strArray[0] == "N")
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(*) FROM BoardingCategorySetting WHERE UPPER(BoardingCategoryName)=" + objDbutility.fReplaceChar(txtBoardingCategory) + "") > 0)
                {
                    strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "5", lblBoardingCategoryName.InnerText.Trim().Replace("' '", ""));
                    //ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>alert('" + strResult + "')</script>");
                    txtBoardingCategory.Focus();
                    lblMessage.Text = strResult;
                    ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
                    return;
                }

            }
            if (strArray[0] == "E" && strArray[1].Trim().ToUpper() != txtBoardingCategory.Value.Trim().ToUpper())
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(*) FROM BoardingCategorySetting WHERE UPPER(BoardingCategoryName)=" + objDbutility.fReplaceChar(txtBoardingCategory) + "") > 0)
                {
                    strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "5", lblBoardingCategoryName.InnerText.Trim().Replace("' '", ""));
                    //ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>alert('" + strResult + "')</script>");
                    txtBoardingCategory.Focus();
                    lblMessage.Text = strResult;
                    ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
                    return;
                }
            }
            if (strArray[0] == "N")
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(*) FROM BoardingCategorySetting") == 0)
                {
                    strResult = objDbutility.ExecuteQuery("INSERT INTO BoardingCategorySetting(BoardingCategoryID,BoardingCategoryName) VALUES (0,'')");
                }
                strResult = objDbutility.ExecuteQuery("INSERT INTO BoardingCategorySetting(BoardingCategoryID,BoardingCategoryName,EntryUserID,EntryDate) SELECT ISNULL(Max(BoardingCategoryID),0)+1," +
                    " " + objDbutility.fReplaceChar(txtBoardingCategory) + ",'" + Convert.ToInt32(Session["UID"]) + "',GetDate() FROM BoardingCategorySetting");
                strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES('" + Session["UID"] + "','" + Session.SessionID + "',GETDATE(),'mnuClass','Class: " + (txtBoardingCategory.Value.Trim().Replace("'", "''") != "" ? txtBoardingCategory.Value.Trim().Replace("'", "''") : txtBoardingCategory.Value.Trim().Replace("'", "''")) + "  ,Is Added')");
            }
            else
            {
                strResult = objDbutility.ExecuteQuery("UPDATE BoardingCategorySetting SET BoardingCategoryName=" + objDbutility.fReplaceChar(txtBoardingCategory) + ",UpdateUserID='" + Convert.ToInt32(Session["UID"]) + "',UpdateDate=GetDate() WHERE BoardingCategoryName='" + strArray[1] + "'");
                strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES('" + Session["UID"] + "','" + Session.SessionID + "',GETDATE(),'mnuClass','Class: " + strArray[1].Trim().ToUpper() + " To " + (txtBoardingCategory.Value.Trim().Replace("'", "''") != "" ? txtBoardingCategory.Value.Trim().Replace("'", "''") : txtBoardingCategory.Value.Trim().Replace("'", "''")) + " ,Is Modified')");
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
                lblMessage.Text = strResult;
                ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
            }
            else
            {
                lblMessage.Text = strResult;
                ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
        }
    }
    protected void clear()
    {
        txtBoardingCategory.Value = "";
        hdnFlag.Value = "";
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult = "";
            if (objDbutility.ReturnNumericValue("EXEC GetDataused 'BoardingCategoryName','BoardingCategorySetting','" + hdnFlag.Value.Split('^')[0] + "'") > 0)
            {
                strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "4", "");
                lblMessage.Text = strResult;
                ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
            }
            else
            {
                if (hdnFlag.Value != "")
                {
                    strResult = objDbutility.ExecuteQuery("DELETE FROM BoardingCategorySetting WHERE UPPER(BoardingCategoryName)='" + hdnFlag.Value.Split('^')[0].ToUpper() + "'");
                    if (strResult == "")
                    {
                        strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "3", "");
                        lblMessage.Text = strResult;
                        ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
                    }
                    else
                    {
                        lblMessage.Text = strResult;
                        ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
                    }
                }
                else
                {
                    lblMessage.Text = strResult;
                    ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
                }

                BindData();
                hdnFlag.Value = "";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
        }

    }
}
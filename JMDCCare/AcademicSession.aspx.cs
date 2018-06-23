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

public partial class AcademicSession : System.Web.UI.Page
{
    Dbutility objDbutility = new Dbutility();
    protected static string strType;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            inputAS1.Attributes.Add("AutoComplete", "off");
            inputAS2.Attributes.Add("AutoComplete", "off");
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
        DataTable dt = objDbutility.BindDataTable("SELECT AcaStart [Start Year], AcaStart+1 as [Academic Session],  Convert (varchar, StartDate, 103) as [Start Date],Convert (varchar, EndDate,103) as [End Date] FROM AcademicSessionSetting  WHERE AcaStart<>0 ORDER BY AcaStart");
        return dt;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult = "";
            string[] strArray = hdnFlag.Value.Split('^');
            if (strArray[0] == "N" || (strArray[3] == "E" && strArray[0].Trim().ToUpper() != inputAS1.Value.Trim().ToUpper() && hdnDate.Value.Split('~')[0]== strArray[1] && hdnDate.Value.Split('~')[1] == strArray[2]))
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(AcaStart) from AcademicSessionSetting WHERE UPPER(AcaStart)='" + inputAS1.Value.Trim().Replace("'", "''").ToUpper() + "'") > 0)
                {
                    strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "5", "Title");
                    ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>alert('" + strResult + "')</script>");
                    inputAS1.Focus();
                    return;
                }
            }
            if (strArray[0] == "N")
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(AcaStart) FROM AcademicSessionSetting") == 0)
                {
                    strResult = objDbutility.ExecuteQuery("INSERT INTO AcademicSessionSetting(AcaStart,StartDate,EndDate) VALUES(0,GetDate(),GetDate())");
                }
                else
                {
                    strResult = objDbutility.ExecuteQuery("INSERT INTO AcademicSessionSetting(AcaStart,StartDate,EndDate,EntryUserID,EntryDate) SELECT '" + inputAS1.Value.Trim().Replace("'", "''") + "',"+
                        "Convert(datetime, '" + hdnDate.Value.Split('~')[0] + "', 103 ),Convert(datetime,'" + hdnDate.Value.Split('~')[1]+"',103),0,GetDate() ");
                    inputAS1.Value = "";
                    inputAS2.Value = "";
                }
            }
            else
            {
                strResult = objDbutility.ExecuteQuery("Update AcademicSessionSetting Set StartDate= Convert(datetime,'" + hdnDate.Value.Split('~')[0] + "',103), EndDate=Convert(datetime,'" + hdnDate.Value.Split('~')[1] +"',103) Where AcaStart='" + strArray[0] + "'");
                inputAS1.Value = "";
                inputAS2.Value = "";
            }
            BindData();
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
            if (objDbutility.ReturnNumericValue("EXEC GetDataused 'AcaStart','AcademicSessionSetting','" + hdnFlag.Value.Split('^')[0] + "'") > 0)
            {
                strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "4", "");
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language='javascript'>alert('" + strResult + "')</script>");
            }
            else
            {
                if (hdnFlag.Value != "")
                {
                    strResult = objDbutility.ExecuteQuery("DELETE FROM AcademicSessionSetting WHERE UPPER(AcaStart)='" + hdnFlag.Value.Split('^')[0].ToUpper() + "'");
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
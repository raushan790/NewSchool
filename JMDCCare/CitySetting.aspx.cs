using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;

public partial class CitySetting : System.Web.UI.Page
{
    Dbutility objDbutility = new Dbutility();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UID"] = 1;
        Session["Type"] = "1";

        if (!IsPostBack)
        {
            txtCity.Attributes.Add("AutoComplete", "off");
        }
        objDbutility.FillDDLs(ddlState, "SELECT StateID ,StateName AS StateName  FROM StateSetting ORDER BY StateName  ", "StateID", "StateName");
        if (ddlCountry.Items.Count > 0)
        {
            ddlCountry.Items[0].Text = objDbutility.pDisplayMessage("1", "6", "Country");
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
            if (ColCount == 0|| ColCount == 3)
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
                if (ColCount == 0 || ColCount == 3)
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
        DataTable dt = objDbutility.BindDataTable("SELECT DM.CityID,ROW_NUMBER() over (order by DM.CityName, CM.CountryName, SM.StateName) as [Sl. No.],CityName [City Name],SM.StateID,SM.StateName [State Name] ,CM.CountryName [Country Name]" +
                        " FROM StateSetting SM INNER JOIN CountrySetting CM ON CM.CountryID = SM.CountryID "+
                        " INNER JOIN CitySetting DM ON DM.StateID = SM.StateID WHERE DM.CityID <> 0 ORDER BY DM.CityName, CM.CountryName, SM.StateName");
        return dt;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult;
            string[] astrFlag = hdnFlag.Value.Split('^');
            if (astrFlag[0] == "N" || (astrFlag[0] == "E" && astrFlag[3].Trim().ToUpper() != txtCity.Value.Trim().ToUpper()))
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(StateID) FROM CitySetting WHERE CityName=" + objDbutility.fReplaceChar(txtCity) + " AND StateID=" + hdnddlVal.Value) > 0)
                {
                    strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "5", lblCity.Text.Trim().Split('<')[0]);
                    lblMessage.Text = strResult;
                    ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);

                    return;
                }
            }
            if (astrFlag[0] == "N")
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(*) FROM CitySetting") == 0)
                {
                    strResult = objDbutility.ExecuteQuery("INSERT INTO CitySetting(CityID,CityName) values(0,'')");
                }
                strResult = objDbutility.ExecuteQuery("INSERT INTO CitySetting(CityID,CityName,StateID,EntryUserID,EntryDate) SELECT ISNULL(MAX(CityID),0)+1," + objDbutility.fReplaceChar(txtCity) + "," + hdnddlVal.Value + ", " +
                       " " + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM CitySetting");
                strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuCity','City: " + (txtCity.Value.Trim().Replace("'", "''") != "" ? txtCity.Value.Trim().Replace("'", "''") : txtCity.Value.Trim().Replace("'", "''")) + " ,Is Added In " + ddlCountry.SelectedItem + "')");
            }
            else
            {
                strResult = objDbutility.ExecuteQuery("UPDATE CitySetting SET CityName='" + txtCity.Value.Trim().Replace("'", "''") + "',StateID=" + hdnddlVal.Value + "," +
                    " UpdateUserID=" + Convert.ToInt32(Session["UID"]) + ",UpdateDate=GetDate() WHERE CityID=" + astrFlag[1] + "");
                strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuCity','City: " + astrFlag[3] + " To " + (txtCity.Value.Trim().Replace("'", "''") != "" ? txtCity.Value.Trim().Replace("'", "''") : txtCity.Value.Trim().Replace("'", "''")) + " ,Is Modified of Country " + ddlCountry.SelectedItem + "')");
            }
            BindData();
            txtCity.Value = "";
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

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult;
            string[] astrFlag = hdnFlag.Value.ToString().Split('^');
            if (objDbutility.ReturnNumericValue("EXEC GetDataused 'City','CitySetting','" + astrFlag[0] + "'") > 0)
            {
                strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "4", "");
                hdnFlag.Value = "";
                txtCity.Value = "";
                lblMessage.Text = strResult;
                ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
                return;
            }
            strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuCity','City Name: " + (txtCity.Value.Trim().Replace("'", "''") != "" ? txtCity.Value.Trim().Replace("'", "''") : txtCity.Value.Trim().Replace("'", "''")) + " ,Is Deleted')");
            strResult = objDbutility.ExecuteQuery("DELETE FROM CitySetting WHERE CityID= " + astrFlag[0] + "");
            BindData();
            txtCity.Value = "";
            hdnFlag.Value = "";
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
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
        }
    }

    [System.Web.Services.WebMethod]
    public static List<ListItem> GetCountry(string stateid)
    {
        Dbutility objDbutility = new Dbutility();
        string query = "SELECT CS.CountryID, CountryName FROM CountrySetting  CS INNER JOIN StateSetting SS ON CS.CountryID = SS.CountryID "+
"        Where SS.StateID = "+ stateid + "";
        string constr = objDbutility.ReturnConnectionString();
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                List<ListItem> customers = new List<ListItem>();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(new ListItem
                        {
                            Value = sdr["CountryID"].ToString(),
                            Text = sdr["CountryName"].ToString()
                        });
                    }
                }
                con.Close();
                return customers;
            }
        }
    }
}
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
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

public partial class upload : System.Web.UI.Page
{
    protected static string strServer = System.Configuration.ConfigurationManager.AppSettings.Get("ServerName");
    protected static string strDatabase = System.Configuration.ConfigurationManager.AppSettings.Get("DatabaseName");
    protected static string strDatabaseUID = System.Configuration.ConfigurationManager.AppSettings.Get("UID");
    protected static string strDatabasePWD = System.Configuration.ConfigurationManager.AppSettings.Get("PWD");

    protected static string strConnectionString = "Data Source=" + strServer + ";User ID=" + strDatabaseUID + ";PWD=" + strDatabasePWD + ";Initial Catalog=" + strDatabase + ";Max Pool Size=500;Pooling=True;Connect Timeout=0;";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string ConnectionString = strConnectionString;//ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT top 1 * FROM Files", conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt != null)
                    {
                        //imgStudent.Src = dt.Rows[0].ItemArray[1].ToString();
                        Session["Path"] = dt.Rows[0].ItemArray[1].ToString();

                    }
                    //gvImages.DataSource = dt;
                    //gvImages.DataBind();
                }
            }
        }
    }
    protected void  Upload(object sender, EventArgs e)
    {
        //Extract Image File Name.
        string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

        //Set the Image File Path.
        string filePath = "~/Uploads/" + fileName;

        //Save the Image File in Folder.
        FileUpload1.PostedFile.SaveAs(Server.MapPath(filePath));

        string ConnectionString = strConnectionString;// ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            string sql = "Delete from Files";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            string sql = "INSERT INTO Files VALUES(@Name, @Path)";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Name", fileName);
                cmd.Parameters.AddWithValue("@Path", filePath);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        return;
        // Response.Redirect(Request.Url.AbsoluteUri);
    }

}
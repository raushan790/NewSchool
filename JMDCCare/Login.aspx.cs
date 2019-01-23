using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    public bool ValidatePassword()
    {
        bool chkValue = false;
        DataTable dt = new DataTable();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CM_Connection"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Email FROM userDetails where MobileNo='" + txtMobileNo.Value + "' and Password='" + txtPassword.Value + "' ";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
                chkValue = false;
            else
                chkValue = true;
        }
        return chkValue;
    }
    public bool ValidateMobileNo()
    {
        string email = txtMobileNo.Value;
        bool chkValue = false;
        DataTable dt = new DataTable();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CM_Connection"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //  cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SELECT MobileNo FROM userDetails where MobileNo='" + txtMobileNo.Value + "' ";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
                chkValue = false;
            else
                chkValue = true;
        }
        return chkValue;
    }
    protected void btnSignup_Click(object sender, EventArgs e)
    {
        if (ValidateMobileNo())
        {
            ShowMessage("User is not registered", MessageType.Error);
            return;
        }
        if (ValidatePassword())
        {
            ShowMessage("Invalid User Id and Password", MessageType.Error);
            return;
        }
        Session["Text"] = "Raushan";
        Response.Redirect("HomePage.aspx");
    }
}
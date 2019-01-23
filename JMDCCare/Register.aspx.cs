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


public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void ClearTextBoxes()
    {
        txtFullName.Value = "";
        txtMobileNo.Value = "";
        //txtUsername.Value = "";
        Email.Value = "";
        txtPassword.Value = "*************";
        txtCPassword.Value = "*************";

    }
    protected void btnSignup_Click(object sender, EventArgs e)
    {
        if (ValidateMobileNo())
        {
            ShowMessage("Mobile No. already registered", MessageType.Error);
            return;
        }
        if (ValidateEmail_Server())
        {
            ShowMessage("Email already registered", MessageType.Error);
            return;
        }
        if (ValidatePassword())
        {
            ShowMessage("Entered password and confirm password are not same, Enter same password!", MessageType.Error);
            return;
        }

        if (Page.IsValid)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CM_Connection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();

                Guid guid;
                guid = Guid.NewGuid();

                string sql = "INSERT INTO userDetails (FullName,MobileNo,Email,UserName,Password)";
                sql += "VALUES (@FullName,@MobileNo,@Email,@UserName,@Password)";

                cmd.Parameters.AddWithValue("@FullName", txtFullName.Value.Trim());
                cmd.Parameters.AddWithValue("@MobileNo", txtMobileNo.Value.Trim());
                cmd.Parameters.AddWithValue("@Email", Email.Value.Trim());
                cmd.Parameters.AddWithValue("@UserName", "Test");
                cmd.Parameters.AddWithValue("@Password", txtPassword.Value);

                cmd.Connection = con;
                cmd.CommandText = sql;
                con.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                    ClearTextBoxes();
                    //ShowMessage("Record submitted successfully", MessageType.Success);
                    Response.Redirect("ThankYou.aspx");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

    }
    public bool ValidatePassword()
    {
        bool chkValue = false;
        if (txtCPassword.Value != txtPassword.Value)
        {
            chkValue = true;
        }
        else
        {
            chkValue = false;
        }
        return chkValue;
    }

    public bool ValidateEmail_Server()
    {
        string email = Email.Value;
        bool chkValue = false;
        DataTable dt = new DataTable();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CM_Connection"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //  cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SELECT Email FROM userDetails where Email='" + email + "' ";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
                chkValue = true;
            else
                chkValue = false;
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
                chkValue = true;
            else
                chkValue = false;
        }
        return chkValue;
    }
}
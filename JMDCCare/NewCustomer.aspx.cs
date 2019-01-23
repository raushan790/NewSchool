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

public partial class NewCustomer : System.Web.UI.Page
{
    Dbutility objDbutility = new Dbutility();
    protected static string strCon1 = "";
    protected static string strCon2 = "";
    protected static string strCon3 = "";
    protected static string strCon4 = "";
    protected static string strCon5 = "";
    protected static string strCon6 = "";
    protected static string strCon7 = "";
    protected static string strCon8 = "";
    protected static string strCon9 = "";
    protected static string strCon10 = "";
    protected static string strCon11 = "";
    protected static string strCon12 = "";
    protected static string strCon13 = "";
    protected static string strCon14 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDOB.Value = DateTime.Now.ToString("dd/MM/yyyy");
            if (txtDOB.Value != DateTime.Now.ToString("dd/MM/yyyy") || txtDOB.Value == "")
            {
                txtDOB.Value = DateTime.Now.ToString("dd/MM/yyyy");
            }

        }
        if (genderM.Checked == false && genderF.Checked == false)
        {
            genderM.Checked = true;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        foreach (Control txtControl in Master.Controls)
        {
            if (txtControl.GetType().FullName == "System.Web.UI.WebControls.TextBox")
            {
                ((TextBox)txtControl).Text = "";
            }
        }

        foreach (Control ddlControl in Master.Controls)
        {
            if (ddlControl.GetType().FullName == "System.Web.UI.WebControls.DropDownList")
                if (((System.Web.UI.WebControls.ListControl)(((DropDownList)ddlControl))).Items.Count > 0)
                {
                    {
                        ((DropDownList)ddlControl).SelectedIndex = 0;
                    }
                }
        }
        Accno.Focus();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            btnCancel_Click(sender, e);
            genderM.Checked = true;
            string accNo = "0";
            accNo = objDbutility.ReturnSingleValue("SELECT ISNULL(MAX(CAST([CustomerID] AS Bigint)),0)+1 FROM [CustomerMaster] WHERE ISNUMERIC([CustomerID])= 1 ");
            Accno.Value = "MI-000" + accNo;
            //hndAccno.Value = "MI-000" + accNo;
            if (Accno.Value.Trim() != "")
            {
                if (objDbutility.ReturnNumericValue("Select count(*) AS [scount] From CustomerMaster Where [ACCNO]='" + Accno.Value.Trim().Replace("'", "''") + "'") > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('Account No. already exists');</script>");
                    return;
                }
            }
            firstname.Focus();
            hdnFlag.Value = "N~";
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert(" + ex.Message.Replace("'", "") + ");</script>");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult = "";
            //string lblMessage = "";
            int intCustID = objDbutility.ReturnNumericValue("SELECT ISNULL(MAX(CustomerID),0)+1 FROM CustomerMaster ");
            string accNo = "0";
            accNo = objDbutility.ReturnSingleValue("SELECT ISNULL(MAX(CAST([CustomerID] AS Bigint)),0)+1 FROM [CustomerMaster] WHERE ISNUMERIC([CustomerID])= 1 ");
            Accno.Value = "MI-000" + accNo;
            strCon1 = "INSERT INTO CustomerMaster (CustomerID,FirstName,MiddleName,LastName,Sex,DateOfBirth,EmailID,ACCNO,PanNo,FatherName,Balance,EntryUserID,EntryDate" +
                " ) VALUES(" + intCustID + "," + objDbutility.fReplaceChar(firstname.Value.Trim()) + "," + objDbutility.fReplaceChar(middlename.Value.Trim()) + "," +
                " " + objDbutility.fReplaceChar(lastname.Value.Trim()) + ",'" + (genderM.Checked == true ? 'M' : 'F') + "'," + objDbutility.ReturnDateorNull(txtDOB.Value.Trim()) + "," +
                " " + objDbutility.fReplaceChar(email.Value.Trim()) + "," + objDbutility.fReplaceChar(Accno.Value.Trim()) + "," + objDbutility.fReplaceChar(panNo.Value.Trim()) + ","  +
                " " + objDbutility.fReplaceChar(FatherName.Value.Trim()) + ",'0.00',1,GETDATE())" ;
            Session["UID"] = "1";
            strCon2 = strCon2 + "~INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES('" + Session["UID"] + "','" + Session.SessionID + "',GETDATE(),'mnuStudent','Student, Name: " + firstname.Value.Trim().Replace("'", "''") + " " + middlename.Value.Trim().Replace("'", "''") + " " +
                " "+ lastname.Value.Trim().Replace("'", "''") + " With Accno No : " + Accno.Value.Trim().Replace("'", "''") + " & Cust ID: " + accNo + "  Is Added In Student Information')";
            lblMessage.Text = strResult;
            if (strResult == "")
            {
                if (hdnFlag.Value == "N~" || hdnFlag.Value == "A")
                {
                    strResult = objDbutility.pDisplayMessage("", "1", "");
                }
                else
                {
                    strResult = objDbutility.pDisplayMessage("", "2", "");
                }
                lblMessage.Text = strResult;

                ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
            }
            else
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "dipt", "<script language=javascript>alert('" + strResult + "')</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
            }


            strResult = objDbutility.ExecuteQuery("EXEC DMLQuery '" + strCon1.Replace("'", "''") + "','" + strCon2.Replace("'", "''") + "','" + strCon3.Replace("'", "''") +
          "','" + strCon4.Replace("'", "''") + "','" + strCon5.Replace("'", "''") + "','" + strCon6.Replace("'", "''") + "','" + strCon7.Replace("'", "''") + "','" + strCon8.Replace("'", "''") + "','" + strCon9.Replace("'", "''") + "','" + strCon10.Replace("'", "''") + "','" + strCon11.Replace("'", "''") + "','" + strCon12.Replace("'", "''") + "','" + strCon13.Replace("'", "''") + "','" + strCon14.Replace("'", "''") + "'");


        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert(" + ex.Message.Replace("'", "") + ");</script>");
        }
    }
}
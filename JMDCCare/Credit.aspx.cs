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

public partial class Credit : System.Web.UI.Page
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
        txtDOB.Value = DateTime.Now.ToString("dd/MM/yyyy");

        if (!this.IsPostBack)
        {
            Accno.Attributes.Add("onkeypress", "javascript:return fBind_Student(event);");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strResult = "";
        try
        {            
            int intCustID = objDbutility.ReturnNumericValue("SELECT CustomerID FROM CustomerMaster Where ACCNO='"+ Accno.Value.Trim()+"'");
            int intBalanceID = objDbutility.ReturnNumericValue("SELECT ISNULL(MAX(BalanceID),0)+1 FROM CustBalance ");

            strCon1 = "  INSERT INTO CustBalance (BalanceID,CustomerID,Balance,EntryUserID,EntryDate) " +
                " VALUES(" + intBalanceID + "," + intCustID + ",'" + balance.Value.Trim() + "',1,GETDATE()) ";

            strCon1 = strCon1 + "~Update CustomerMaster  Set Balance = (Select Sum(isnull(CB.Balance,0)) from CustBalance CB Where CustomerID = " + intCustID + " GROUP BY CB.CustomerID )" +
                " ,[UpdateDate]=GetDate() Where CustomerID=" + intCustID + "";
            Session["UID"] = "1";
            strCon2 = strCon2 + "~INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES('" + Session["UID"] + "','" + Session.SessionID + "',GETDATE(),'mnuStudent','Student, Name: " + firstname.Value.Trim().Replace("'", "''") + " " + middlename.Value.Trim().Replace("'", "''") + " " +
                " " + lastname.Value.Trim().Replace("'", "''") + " With Accno No : " + Accno.Value.Trim().Replace("'", "''") + " & Balance Update - added "+ balance.Value +" to main balance')";
            lblMessage.Text = strResult;
            if (strResult == "")
            {
                strResult = objDbutility.pDisplayMessage("", "2", "");
                lblMessage.Text = strResult;

                ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
            }


            strResult = objDbutility.ExecuteQuery("EXEC DMLQuery '" + strCon1.Replace("'", "''") + "','" + strCon2.Replace("'", "''") + "','" + strCon3.Replace("'", "''") +
          "','" + strCon4.Replace("'", "''") + "','" + strCon5.Replace("'", "''") + "','" + strCon6.Replace("'", "''") + "','" + strCon7.Replace("'", "''") + "','" + strCon8.Replace("'", "''") + "','" + strCon9.Replace("'", "''") + "','" + strCon10.Replace("'", "''") + "','" + strCon11.Replace("'", "''") + "','" + strCon12.Replace("'", "''") + "','" + strCon13.Replace("'", "''") + "','" + strCon14.Replace("'", "''") + "'");


        }
        catch (Exception ex)
        {
            lblMessage.Text =  "Data not saved please report this to support team";
            ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
        }
    }
    protected void btnDisplay_Click(object sender, EventArgs e)
    {
        if (objDbutility.ReturnNumericValue("Select Count(*) From CustomerMaster Where ACCNO='" + Accno.Value.Trim().Replace("'", "''") + "' ") > 0)
        {
            int CustomerID = objDbutility.ReturnNumericValue("Select CustomerID From  CustomerMaster Where ACCNO='" + Accno.Value.Trim().Replace("'", "''") + "' ");
            if (CustomerID == 0)
            {
                return;
            }
            DataTable dtCust = new DataTable();
            dtCust = objDbutility.BindDataTable("Select * From CustomerMaster Where CustomerID='" + CustomerID + "'");
            foreach (DataRow row in dtCust.Rows)
            {
                string gender= row["Sex"].ToString(); 
                if(gender=="F")
                {
                    genderF.Checked = true;
                    genderM.Checked = false;
                }
                else
                {
                    genderF.Checked = false;
                    genderM.Checked = true;
                }
                firstname.Value = row["FirstName"].ToString();
                middlename.Value = row["MiddleName"].ToString();
                lastname.Value = row["LastName"].ToString();
                txtDOB.Value = row["DateOfBirth"].ToString();
                email.Value = row["EmailID"].ToString();
                FatherName.Value = row["FatherName"].ToString();
                panNo.Value = row["PanNo"].ToString();
                balance.Value = row["Balance"].ToString();
                Accno.Value= row["ACCNO"].ToString();
            }
        }

    }

}
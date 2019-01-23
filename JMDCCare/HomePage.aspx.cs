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
using System.Text;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web.Services;
public partial class HomePage : System.Web.UI.Page
{
    Dbutility objDbutility = new Dbutility();
    [WebMethod]
    public static List<string> GetAutoCompleteData(string username)
    {
        Dbutility objDbutility1 = new Dbutility();

        string conStr = objDbutility1.ReturnConnectionString();
        List<string> result = new List<string>();
        using (SqlConnection con = new SqlConnection(conStr))
        {
            using (SqlCommand cmd = new SqlCommand("select StudentId,firstName from StudentDetails where firstName LIKE '%'+@SearchText+'%'", con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@SearchText", username);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result.Add(string.Format("{0}/{1}", dr["StudentId"], dr["firstName"]));
                }
                return result;
            }
        }
    }
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
        string yy = Session["Text"].ToString();

        Session["SchoolID"] = "1";
        Session["AcaStart"] = "2017";
        Session["UID"] = 1;

        if (!this.IsPostBack)
        {
            txtStuSelect.Attributes.Add("onkeypress", "javascript:return SetContextKey();");
            txtStuSelect.Attributes.Add("onkeypress", "javascript:return fBind_Student(event);");
            Session["SchoolID"] = "1";
            Session["AcaStart"] = "2017";
            Session["UID"] = 1;
            BindControls();
            txtDateOFJoin.Value = DateTime.Now.ToString("dd/MM/yyyy");
            txtDOA.Value = DateTime.Now.ToString("dd/MM/yyyy");
            if (txtStuDOB.Value != DateTime.Now.ToString("dd/MM/yyyy") || txtStuDOB.Value == "")
            {
                txtStuDOB.Value = DateTime.Now.ToString("dd/MM/yyyy");
            }
            rbtnMale.Checked = true;
            rbtnAdmissionNew.Checked = true;
        }
        if (hdnimageIDtemp.Value != "")
        {
            FetchImage(sender, e);
        }
        else
        {
            imgStudent.ImageUrl = "~/Uploads/Noimage.jpg";
        }
    }
    protected void FetchImage(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = objDbutility.BindDataTable("SELECT pic FROM ImageDetailsTemp WHERE Imgid =" + hdnimageIDtemp.Value + "");
        byte[] bytes = (byte[])dt.Rows[0]["pic"];
        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        imgStudent.ImageUrl = "data:image/png;base64," + base64String;
    }
    #region control events
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
        //txtStuSelect.Text = "";
        //hdntxtStuSelect.Value = "";
        //hdnSDID.Value = "";
        //hidFeeGrpID.Value = "";
        //hidFeeAppID.Value = "";
        //hdntxtParentID.Value = "";
        //lblLastMDate.Text = "";
        //btnNew.Enabled = true;
        //objDbutility.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName AS MotherTongueName FROM MotherTongueSetting WHERE MotherTongueID<>0 ORDER BY MotherTongueName ", "MotherTongueID", "MotherTongueName", "");
        //objDbutility.FillCheckedBoxList(chkImpairment, "SELECT ImpairmentID,Impairment AS ImpairmentName FROM MTImpairmentMaster WHERE ImpairmentID<>0 ORDER BY Impairment ", "ImpairmentID", "ImpairmentName", "");

        //rbtnAdmissionNew.Checked = true;
        //rbtnMale.Checked = true;
        txtAdmNo.Focus();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        btnCancel_Click(sender, e);
        rbtnFeMale.Checked = true;
        if (hdnimageIDtemp.Value != "")
        {
            FetchImage(sender, e);
        }
        else
        {
            imgStudent.ImageUrl = "~/Uploads/Noimage.jpg";
        }
        txtAdmNo.Text = objDbutility.ReturnSingleValue("SELECT ISNULL(MAX(CAST(AdmissionNo AS Bigint)),0)+1 FROM StudentYearWiseDetails WHERE ISNUMERIC(AdmissionNo)=1  AND  " +
                          " SchoolID=" + Session["SchoolID"] + " ");
        if (txtAdmNo.Text.Trim() != "")
        {
            if (objDbutility.ReturnNumericValue("Select count(*) AS [scount] From StudentYearWiseDetails Where AdmissionNo='" + txtAdmNo.Text.Trim().Replace("'", "''") + "' AND SchoolID=" + Session["SchoolID"].ToString() + " AND AcaStart=" + Session["AcaStart"].ToString()) > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('AdmissionNo already exists for another student');</script>");
                return;
            }
        }

        txtFeeNo.Text = objDbutility.ReturnSingleValue("SELECT  ISNULL(MAX(CAST(FeeNo AS Bigint)),0)+1  FROM StudentYearWiseDetails WHERE ISNUMERIC(FeeNo)=1  AND  " +
                                         "  SchoolID=" + Session["SchoolID"] + " ");
        if (txtFeeNo.Text.Trim() != "")
        {
            if (objDbutility.ReturnNumericValue("Select count(*) AS [scount] From StudentYearWiseDetails Where FeeNo='" + txtFeeNo.Text.Trim().Replace("'", "''") + "' AND SchoolID=" + Session["SchoolID"].ToString() + " AND AcaStart=" + Session["AcaStart"].ToString()) > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script>alert('Fee No. already exists for another student');</script>");
                return;
            }
        }
       // txtParentID.Text = objDbutility.ReturnSingleValue("SELECT ISNULL(MAX(ParentID),0)+1 From StudentDetails");
        hdntxtParentID.Value = txtParentID.Text;
        btnNew.Enabled = false;
        txtAdmNo.Focus();
        hdnFlag.Value = "N^";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int intParentID = 0;
            List<string> lstArray = new List<string>();
            int intstudentID = 0;
            int intPreviousID = 0;
            string strResult = "";
            string StrChkLanguageKnown = "";
            string StrTypeofImpairment = "";
            strCon1 = "";
            strCon2 = "";
            strCon3 = "";
            strCon4 = "";
            strCon5 = "";
            strCon6 = "";
            strCon7 = "";
            strCon8 = "";
            strCon9 = "";
            strCon10 = "";
            strCon11 = "";
            strCon12 = "";
            strCon13 = "";
            strCon14 = "";
            for (int inti = 0; inti < chkLanguageKnown.Items.Count; inti++)
            {
                if (chkLanguageKnown.Items[inti].Selected == true)
                {
                    StrChkLanguageKnown = StrChkLanguageKnown + chkLanguageKnown.Items[inti].Value + ",";
                }
            }
            if (StrChkLanguageKnown.Length > 0)
            {
                StrChkLanguageKnown = StrChkLanguageKnown.Substring(0, StrChkLanguageKnown.Length - 1);
            }

            if (hdnFlag.Value == "N^")
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(*) FROM StudentDetails  SM INNER JOIN  StudentYearWiseDetails YD ON SM.StudentID=YD.StudentID WHERE SM.SchoolId=" + Session["SchoolID"] + "" +
                             " AND   ISNULL(AdmissionNo,'') ='" + txtAdmNo.Text.Trim().Replace("'", "''") + "' ") > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "dipt", "<script language=javascript>alert('Admission No. Already Exists')</script>");
                    txtAdmNo.Focus();
                    return;
                }
                if (txtRollNo.Text.Trim() != "")
                {
                    if (objDbutility.ReturnNumericValue("SELECT COUNT(*) FROM StudentDetails  SM INNER JOIN  StudentYearWiseDetails YD ON SM.StudentID=YD.StudentID WHERE SM.SchoolId=" + Session["SchoolID"] + " AND  YD.AcaStart=" + Session["AcaStart"] + "  " +
                             "AND YD.StudentStatus='S' and ClassId=" + ddlClass.SelectedValue + " AND SectionId=" + ddlSection.SelectedValue + " And   ClassRollNo=" + txtRollNo.Text.Trim().Replace("'", "''") + " AND  ClassRollNo>0") > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "dipt", "<script language=javascript>alert('Roll No. Already Exists')</script>");
                        txtRollNo.Focus();
                        return;
                    }
                }

                if (txtFeeNo.Text.Trim().Replace("'", "''") != "")
                {
                    if (objDbutility.ReturnNumericValue("SELECT COUNT(*) FROM StudentDetails  SM INNER JOIN  StudentYearWiseDetails YD ON SM.StudentID=YD.StudentID WHERE SM.SchoolId=" + Session["SchoolID"] + " " +
                             " AND   YD.FeeNo='" + txtFeeNo.Text.Trim().Replace("'", "''") + "'") > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "dipt", "<script language=javascript>alert('Fee No. Already Exists')</script>");
                        txtFeeNo.Focus();
                        return;
                    }
                }
                if (hdntxtParentID.Value == txtParentID.Text)
                {
                    if (objDbutility.ReturnNumericValue("Select Count(ParentID) from StudentDetails WHERE ParentID=" + Convert.ToInt32(hdntxtParentID.Value) + "") > 0)
                    {
                        txtParentID.Text = objDbutility.ReturnSingleValue("SELECT ISNULL(MAX(ParentID),0)+1 From StudentDetails");
                    }
                    else
                    {
                        txtParentID.Text = hdntxtParentID.Value;
                    }
                }

                intstudentID = objDbutility.ReturnNumericValue("SELECT ISNULL(MAX(StudentID),0)+1 FROM StudentDetails ");

                strCon1 = "INSERT INTO StudentDetails (StudentID,FirstName,MiddleName,LastName,Sex,DateOfBirth,DateOfAdmission,ClassAdmited,CategoryID,ReligionID, " +
                    " EmailID,BloodGroupID,NationalityID,MotherTongueID,ParentID,SchoolID,EntryUserID,EntryDate,FeeConcessionTypeID,SchoolBus,StudentLivingWithParents, " +
                    " DateOfJoin,CBSERollNo) VALUES(" + intstudentID + "," + objDbutility.fReplaceChar(txtFirstName.Text) + "," + objDbutility.fReplaceChar(txtMiddleName.Text) + "," +
                    " " + objDbutility.fReplaceChar(txtLastName.Text) + ",'" + (rbtnMale.Checked == true ? 'M' : 'F') + "'," + objDbutility.ReturnDateorNull(txtStuDOB.Value.Trim()) + "," +
                    " " + objDbutility.ReturnDateorNull(txtDOA.Value.Trim()) + "," + ddlAdmittedClass.SelectedValue + "," + ddlSocCategory.SelectedValue + ", " + ddlReligion.SelectedValue + ",  " +
                    " " + objDbutility.fReplaceChar(txtStuEmail.Text) + "," + ddlBloodGroup.SelectedValue + "," + ddlNationality.SelectedValue + "," + ddlMotherTongue.SelectedValue + "," + (txtParentID.Text.Trim() == "" ? "0" : txtParentID.Text.Trim().Replace("'", "''")) + ", " +
                    " '" + Session["SchoolID"].ToString() + "','" + Session["UID"] + "',GETDATE(),'" + ddlConcessionType.SelectedValue + "', " +
                    " '" + ddlSchoolBus.SelectedValue + "','" + ddlStuLiving.SelectedValue + "'," + objDbutility.ReturnDateorNull(txtDateOFJoin.Value.Trim()) + "," +
                    " " + objDbutility.fReplaceChar(txtCBSERollNo.Text) + ")";


                strCon1 = strCon1 + "~INSERT INTO StudentYearWiseDetails (YearWiseID,StudentID,AcaStart,AdmissionNo,FeeNo,ClassID,SectionID,FeeGroupID,NewAdmission,FeeApplicableFrom,ClassRollNo, " +
                     " HouseID,BoardID,BoardRegistrationNo,BoardingCategoryID,StudentStatus,Promotion,SchoolID,EntryUserID,EntryDate,SchoolTransfered,WardenID,HostelID,RoomNo,BedNo,HomeAdvisorID,TRBusStopID)   " +
                     "  SELECT ISNULL(MAX(YearWiseID),0)+1," + intstudentID + ",'" + Session["AcaStart"] + "'," +
                     " " + objDbutility.fReplaceChar(txtAdmNo.Text) + "," + objDbutility.fReplaceChar(txtFeeNo.Text) + ",'" + ddlClass.SelectedValue + "'," +
                     " '" + ddlSection.SelectedValue + "','" + ddlFeeGroup.SelectedValue + "','" + (rbtnAdmissionNew.Checked == true ? 'N' : 'O') + "','" + ddlFeeApplnFrom.SelectedValue + "','" + (txtRollNo.Text.Trim() == "" ? "0" : txtRollNo.Text.Trim()) + "','" + ddlHouse.SelectedValue.Trim().Replace("'", "''") + "'," +
                     " '" + ddlBoard.SelectedValue + "'," + objDbutility.fReplaceChar(txtBoardRegNo.Text) + ",'" + ddlBoardingCategory.SelectedValue + "'," +
                "  'S','N','" + Session["SchoolID"] + "','" + Session["UID"] + "',GETDATE(),'0',0,0,'','',0,0 FROM StudentYearWiseDetails";

                strCon2 = strCon2 + "~INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuStudent','Student, Name: " + txtFirstName.Text.Trim().Replace("'", "''") + " " + txtMiddleName.Text.Trim().Replace("'", "''") + " " + txtLastName.Text.Trim().Replace("'", "''") + " With Admission No : " + txtAdmNo.Text.Trim().Replace("'", "''") + " & Fee No: " + txtFeeNo.Text.Trim().Replace("'", "''") + " In Class-Sec " + ddlClass.SelectedItem.Text.Trim().Replace("'", "''") + "-" + ddlSection.SelectedItem.Text.Trim().Replace("'", "''") + " Is Added In Student Information')";

            }

            strCon1 = strCon1 + "~INSERT INTO StudentMailingAddress (StudentID,FlatNo,CityID,PinCode,TelephoneNo,EntryUserID,EntryDate)" +
                " VALUES(" + intstudentID + ",'" + txtPresAddress.Value.Trim().Replace("'", "''") + "', " +
                "' " + ddlRCity.SelectedValue + "','" + txtRpincode.Text.Trim() + "','" + txtPresPhone.Text.Trim() + "','" + Session["UID"] + "',GETDATE())";
            strCon1 = strCon1 + "~INSERT INTO StudentResidenceAddress (StudentID,FlatNo,CityID,PinCode,TelephoneNo,EntryUserID,EntryDate)" +
                " VALUES(" + intstudentID + ",'" + txtPerAddress.Value.Trim().Replace("'", "''") + "', " +
                " '" + ddlRCity.SelectedValue + "', '" + txtPerPincode.Text.Trim() + "','" + txtPerPhone.Text.Trim() + "','" + Session["UID"] + "',GETDATE())";

            strCon1 = strCon1 + "~INSERT INTO SIStudentFatherDetails(StudentID,TitleID,FatherName,ArabicFatherName,PQualificationID,POccupationID,PDesignationID,AnnualIncome,OrganizationName,OrganizationAddress,CityID, " +
          "PinCode,MobileNo,Telephone,EmailID,FIqamaNo,EntryUserID,EntryDate,FIqamaNoExpiryDate,PNationlityID)  " +
          " VALUES (" + intstudentID + "," + ddlFTitle.SelectedValue + ",'" + txtFName.Text.Trim().Replace("'", "''") + "','',0,0,0,0,'','',0, " +
          " '','','','',''," + Session["UID"] + ",GETDATE(),NULL,0)";
            strCon1 = strCon1 + "~INSERT INTO SIStudentMotherDetails(StudentID,TitleID,MotherName,ArabicMotherName,PQualificationID,POccupationID,PDesignationID,AnnualIncome,OrganizationName,OrganizationAddress,CityID," +
                                     " PinCode,MobileNo,Telephone,EmailID,MIqamaNo,EntryUserID,EntryDate,MIqamaNoExpiryDate,PNationlityID) " +
                                     " VALUES(" + intstudentID + "," + ddlMTitle.SelectedValue + ",'" + txtMName.Text.Trim().Replace("'", "''") + "','',0,0,0,0,'','',0,'','','','','' " +
                                     " ," + Session["UID"] + ",GETDATE(),NULL,0)";
            if (hdnimageIDtemp.Value != "")
            {
                strCon1 = strCon1 + "~update StudentDetails set pic=(Select Pic from ImageDetailsTemp where Imgid=" + hdnimageIDtemp.Value + ")";
            }


            for (int inti = 0; inti < chkLanguageKnown.Items.Count; inti++)
            {
                if (chkLanguageKnown.Items[inti].Selected == true)
                {
                    strCon1 = strCon1 + "~INSERT INTO StudentLanguages (SLDID,StudentID,MotherTongueID,EntryUserID,EntryDate)" +
                          " SELECT ISNULL(MAX(SLDID),0)+1," + intstudentID + ",'" + chkLanguageKnown.Items[inti].Value + "','" + Session["UID"] + "',GETDATE() FROM StudentLanguages";
                }

            }
            lblMessage.Text = strResult;
            if (strResult == "")
            {
                if (hdnFlag.Value == "N^" || hdnFlag.Value == "A")
                {
                    strResult = objDbutility.pDisplayMessage("", "1", "");
                }
                else
                {
                    strResult = objDbutility.pDisplayMessage("", "2", "");
                }
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
    private string pGetSiblingDetails(int intParentID)
    {
        string strResult = "";
        SqlDataReader sqlRdr = objDbutility.BindReader(" SELECT TOP 1 SM.StudentID,SM.ReligionID,SM.CasteID,SM.NationalityID,SM.MotherTongueID,  " +
           " SM.NoofChild,YD.ChildCode,MA.FlatNo,ISNULL(MA.CityID,0) AS MCity,MA.PinCode,MA.TelephoneNo,RA.FlatNo, " +
           " ISNULL(RA.CityID,0) AS RCity,RA.PinCode,RA.TelephoneNo , ISNULL(MCM.CityName,'') As MCityName,ISNULL(MSM.StateName ,'') AS MStateName, " +
           " ISNULL(MCT.CountryName,'') As MCountryName,ISNULL(RCM.CityName,'') As RCityName,ISNULL(RSM.StateName,'') AS RStateName,  " +
           " ISNULL(RCT.CountryName ,'') As RCountryName,ISNULL(SM.ParentID,0),YD.AdmissionNo,FD.TitleID,FD.FatherName, MD.TitleID,MD.MotherName,YD.FeeGroupID,YD.FeeApplicableFrom,YD.StudentStatus   FROM StudentDetails SM INNER JOIN StudentYearWiseDetails YD ON  SM.StudentID=YD.StudentId   " +
           " LEFT JOIN StudentMailingAddress MA  ON MA.studentID=SM.StudentID   " +
           " LEFT JOIN StudentResidenceAddress  RA ON   RA.studentID=SM.StudentID   " +
           " LEFT JOIN citySetting MCM ON MCM.CityID=MA.CityID AND  MCM.CityID<>0  " +
           " LEFT JOIN StateSetting MSM ON MSM.StateID=MCM.StateID  " +
           " LEFT JOIN CountrySetting  MCT ON MCT.CountryID=MSM.CountryID  " +
           " LEFT JOIN citySetting  RCM ON RCM.CityID=RA.CityID AND   RCM.CityID<>0  " +
           " LEFT JOIN StateSetting  RSM ON RSM.StateID=RCM.StateID  " +
           " LEFT JOIN CountrySetting  RCT ON RCT.CountryID=RSM.CountryID    " +
           " LEFT JOIN SIStudentFatherDetails FD ON FD.studentID=SM.StudentID " +
           " LEFT JOIN SIStudentMotherDetails  MD ON  MD.studentID=SM.StudentID  " +
           "  WHERE SM.ParentID=" + intParentID + "  AND YD.SchoolId=" + Session["SchoolID"].ToString() + "  ORDER BY SM.StudentID ASC");

        if (sqlRdr.Read())
        {
            for (int intForloop = 0; intForloop < sqlRdr.FieldCount; intForloop++)
            {
                strResult = strResult + sqlRdr.GetValue(intForloop).ToString() + "^";
            }
            strResult = strResult.Remove(strResult.Length - 1, 1);
        }

        sqlRdr.Close();
        sqlRdr.Dispose();
        return strResult;
    }
    private string pGetStudentDetails(int intStudentID)
    {
        string strResult = "";
        SqlDataReader sqlRdr = objDbutility.BindReader("SELECT  SM.StudentID,SM.FirstName,SM.MiddleName,SM.LastName,'' AS ArabicName,SM.Sex,   " +
            " CONVERT(VARCHAR,SM.DateOfBirth,103) AS DateOfBirth,CONVERT(VARCHAR,SM.DateOfAdmission,103)AS  DateOfAdmission,ISNULL(SM.ClassAdmited,0) AS ClassAdmited,ISNULL(SM.CategoryID,0) As CategoryID,ISNULL(SM.ReligionID,0) AS ReligionID,ISNULL(SM.CasteID,0) AS CasteID,SM.EmergencyPhoneNo, " +
            " SM.EmailID,ISNULL(SM.BloodGroupID,0) AS BloodGroupID,ISNULL(SM.NationalityID,0) AS NationalityID,ISNULL(SM.MotherTongueID,0) As MotherTongueID,ISNULL(SM.ParentID,0),SM.SIqamaNo,SM.NoofChild,SM.Positionofchild, " +
            " YD.AdmissionNo,ISNULL(YD.FeeNo,0),ISNULL(YD.ClassID,0),ISNULL(YD.SectionID,0),YD.NewAdmission,YD.ClassRollNo,ISNULL(YD.HouseID,0),ISNULL(YD.BoardID,0),YD.BoardRegistrationNo, " +
            " ISNULL(YD.BoardingCategoryID,0),YD.ChildCode,YD.Remark,MA.FlatNo,ISNULL(MA.CityID,0),MA.PinCode,MA.TelephoneNo,RA.FlatNo,ISNULL(RA.CityID,0),RA.PinCode,RA.TelephoneNo ,  " +
            " ISNULL(MCM.CityName ,'') As MCityName,ISNULL(MSM.StateName ,'') AS MStateName,  " +
            " ISNULL(MCT.CountryName ,'') As MCountryName,ISNULL(RCM.CityName ,'') As RCityName, " +
            " ISNULL(RSM.StateName ,'') AS RStateName,   " +
            " ISNULL(RCT.CountryName ,'') As RCountryName,ISNULL(FD.TitleID,0),FD.FatherName,ISNULL(MD.TitleID,0),ISNULL(MD.MotherName,0),ISNULL(YD.FeeGroupID,0),YD.FeeApplicableFrom,YD.StudentStatus, " +
            " ISNULL(Convert(varchar,SIqamaExpiryDate,103),'') As SIqamaExpiryDate,ISNULL(SM.FeeConcessionTypeID,0) AS FeeConcessionTypeID,ISNULL(Meals,0),SchoolBus,ISNULL(SecondLanguage,0),ISNULL(ThirdLanguage,0),  " +
            " SM.StudentLivingWithParents,SM.ProvAdmission,CONVERT(VARCHAR,SM.DateOfJoin,103) As DateOFJoin,ISNULL(SM.EduLiveEmailID,'') AS EduLiveEmailID ,ISNULL(YD.SchoolTransfered,0) as SchoolTransfered,ISNULL(SM.CBSERollNo,'') AS CBSERollNo, ISNULL(YD.Stream,0),ISNULL(YD.TRBusStopID,0) AS BusStopID,ISNULL(SM.Caste,'') AS Caste,ISNULL(SM.FreeShip,'N'),GGNNo " +
            " FROM StudentDetails SM INNER JOIN StudentYearwisedetails YD ON SM.StudentID=YD.StudentId   " +
            " LEFT JOIN StudentMailingAddress MA   ON MA.studentID=SM.StudentID  " +
            " LEFT JOIN StudentResidenceAddress  RA ON RA.studentID=SM.StudentID   " +
            " LEFT JOIN citySetting MCM ON MCM.CityID=MA.CityID AND  MCM.CityID<>0   " +
            " LEFT JOIN StateSetting MSM ON MSM.StateID=MCM.StateID   " +
            " LEFT JOIN CountrySetting MCT ON MCT.CountryID=MSM.CountryID   " +
            " LEFT JOIN citySetting RCM ON RCM.CityID=RA.CityID AND  RCM.CityID<>0   " +
            " LEFT JOIN StateSetting RSM ON RSM.StateID=RCM.StateID   " +
            " LEFT JOIN CountrySetting RCT ON RCT.CountryID=RSM.CountryID   " +
            " LEFT JOIN SIStudentFatherDetails FD ON FD.studentID=SM.StudentID " +
            " LEFT JOIN SIStudentMotherDetails  MD ON  MD.studentID=SM.StudentID  " +
            " LEFT JOIN TRBusStopMaster BSM ON BSM.TRBusStopID=YD.TRBusStopID" +
            " WHERE SM.StudentID=" + intStudentID + " AND YD.AcaStart=" + Session["AcaStart"].ToString() + " AND YD.SchoolId=" + Session["SchoolID"].ToString() + " ");
        if (sqlRdr.Read())
        {
            for (int intForloop = 0; intForloop < sqlRdr.FieldCount; intForloop++)
            {
                strResult = strResult + sqlRdr.GetValue(intForloop).ToString() + "^";
            }
            strResult = strResult.Remove(strResult.Length - 1, 1);
        }

        sqlRdr.Close();
        sqlRdr.Dispose();
        return strResult;

    }

    protected void btnDisplay_Click(object sender, EventArgs e)
    {
        string strResult = "";
        int intStudentID = 0;
        string strClassStrength = "";
        string strSchoolStrength = "";
        int minAcaStart = Convert.ToInt32(Session["Acastart"]) - 1;
        if (btnNew.Enabled == false)
        {
            if (objDbutility.ReturnNumericValue("Select Count(*) From StudentDetails SM INNER JOIN StudentYearWiseDetails YD ON YD.StudentID=SM.StudentID where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "' ") > 0)
            {
                int intParentID = Convert.ToInt32(txtParentID.Text.Trim().Replace("'", "''"));
                strResult = pGetSiblingDetails(intParentID);
                if ((strResult == "") || (strResult == "null"))
                {
                    return;
                }
                string[] varStudent = strResult.Split('^');
                hdntxtStuSelect.Value = varStudent[0];
                ddlReligion.SelectedValue = varStudent[1];
                ddlNationality.SelectedValue = varStudent[3];
                ddlMotherTongue.SelectedValue = varStudent[4];
                //txtNoOfChild.Text = varStudent[5];
                //txtChildCode.Text = varStudent[6];
                txtPresAddress.Value = varStudent[7];
                //hdntxtResiCity.Value = varStudent[8];
                txtPerPincode.Text = varStudent[9];
                txtPresPhone.Text = varStudent[10];
                txtPerAddress.Value = varStudent[11];
                //hdntxtPerCity.Value = varStudent[12];
                txtPerPincode.Text = varStudent[13];
                txtPerPhone.Text = varStudent[14];
                //txtResiCity = varStudent[15];
                //txtPresState.Text = varStudent[16];
                //txtPresCountry.Text = varStudent[17];
                //txtPerCity.Text = varStudent[18];
                //txtPerState.Text = varStudent[19];
                //txtPerCountry.Text = varStudent[20];
                txtParentID.Text = varStudent[21];
                ddlFTitle.SelectedValue = varStudent[23];
                txtFName.Text = varStudent[24];
                ddlMTitle.SelectedValue = varStudent[25];
                txtMName.Text = varStudent[26];
                if (varStudent[29] == "T")
                {
                    //hidStatusdisplay.Value = "T";
                    //imgATD.ImageUrl = "~/Images/Present.png";
                }
                else if (varStudent[29] == "D")
                {
                    //hidStatusdisplay.Value = "D";
                    //imgATD.ImageUrl = "~/Images/Absent.png";
                }
                else if (objDbutility.ReturnNumericValue("SELECT count(*) from StudentYearWiseDetails SYD " +
                      "  INNER JOIN (SELECT  SYD.StudentID FROM StudentYearWiseDetails SYD   " +
                      " WHERE  SYD.SchoolID=" + Session["SchoolID"] + " AND SYD.AcaStart=" + minAcaStart + " AND SYD.Promotion='F') P ON SYD.StudentID=P.StudentID " +
                      " WHERE SYD.AcaStart=" + Session["AcaStart"] + " AND StudentStatus='S'  AND SYD.SchoolID=" + Session["SchoolID"] + " AND  SYD.StudentID=" + varStudent[0] + " ") > 0)
                {
                    //hidStatusdisplay.Value = "R";
                    //imgATD.ImageUrl = "~/Images/HalfDay.png";
                }
            }
            hdnFlag.Value = "N^";
        }
        else
        {
            if ((objDbutility.ReturnNumericValue("Select Count(*) From StudentDetails where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "'")) > 0)
            {
                int intPStudentID = objDbutility.ReturnNumericValue("SELECT Top 1 SM.StudentID FROM StudentDetails  SM INNER JOIN  StudentYearWiseDetails YD ON SM.StudentID=YD.StudentID  " +
                    " WHERE ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "'  AND YD.AcaStart=" + Session["AcaStart"].ToString() + " AND YD.SchoolId=" + Session["SchoolID"].ToString() + " Order by SM.StudentId ASC");

                //strResult = pGetStudentDetails(intPStudentID);
                if ((strResult == "") || (strResult == "null"))
                {
                    return;
                }
                string[] VarArray = strResult.Split('^');
                hdntxtStuSelect.Value = VarArray[0];
                txtFirstName.Text = VarArray[1];
                txtMiddleName.Text = VarArray[2];
                txtLastName.Text = VarArray[3];
                if (VarArray[5].ToString() == "M")
                {
                    rbtnMale.Checked = true;
                }
                else
                {
                    rbtnFeMale.Checked = true;
                }
                txtStuDOB.Value = txtStuDOB.Value + "~" + VarArray[6];
                txtDOA.Value = VarArray[7];
                ddlAdmittedClass.SelectedValue = VarArray[8];
                ddlSocCategory.SelectedValue = VarArray[9];

                ddlReligion.SelectedValue = VarArray[10];
                // txtStuEmergencyNo.Text = VarArray[12];
                txtStuEmail.Text = VarArray[13];
                ddlBloodGroup.SelectedValue = VarArray[14];
                ddlNationality.SelectedValue = VarArray[15];
                ddlMotherTongue.SelectedValue = VarArray[16];
                txtParentID.Text = VarArray[17];
                //txtSiqmano.Text = VarArray[18];
                //txtNoOfChild.Text = VarArray[19];
                //txtPositionChild.Text = VarArray[20];
                txtAdmNo.Text = VarArray[21];
                txtFeeNo.Text = VarArray[22];
                ddlClass.SelectedValue = VarArray[23];
                ddlSection.SelectedValue = VarArray[24];

                // lblCaption1.Text = "Strength";
                strClassStrength = objDbutility.ReturnSingleValue("Select Count(*) from StudentDetails SIM inner join StudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
                 " where StudentStatus='S' and SYD.ClassID='" + VarArray[23] + "' and SYD.SectionID='" + VarArray[24] + "' and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");

                strSchoolStrength = objDbutility.ReturnSingleValue("Select Count(*) from StudentDetails SIM inner join StudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
                 " where StudentStatus='S'  and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");

                //lblTotalStrength.Text = "School : " + "" + strSchoolStrength;

                //lblClassStrength.Text = "Class  : " + "" + strClassStrength;

                if (VarArray[25].ToString() == "N")
                {
                    rbtnAdmissionNew.Checked = true;
                }
                else
                {
                    rbtnAdmissionOld.Checked = true;
                }
                txtRollNo.Text = VarArray[26];
                ddlHouse.SelectedValue = VarArray[27];
                ddlBoard.SelectedValue = VarArray[28];
                txtBoardRegNo.Text = VarArray[29];
                ddlBoardingCategory.SelectedValue = VarArray[30];
                //txtChildCode.Text = VarArray[31];
                //txtRemarks.Text = VarArray[32];
                txtPresAddress.Value = VarArray[33];
                //hdntxtResiCity.Value = VarArray[34];
                txtPresAddress.Value = VarArray[35];
                txtPresPhone.Text = VarArray[36];
                txtPerAddress.Value = VarArray[37];
                //hdntxtPerCity.Value = VarArray[38];
                txtPerPincode.Text = VarArray[39];
                txtPerPhone.Text = VarArray[40];
                //txtResiCity.Text = VarArray[41];
                //txtPresState.Text = VarArray[42];
                //txtPresCountry.Text = VarArray[43];
                //txtPerCity.Text = VarArray[44];
                //txtPerState.Text = VarArray[45];
                //txtPerCountry.Text = VarArray[46];
                ddlFTitle.SelectedValue = VarArray[47];
                txtFName.Text = VarArray[48];
                ddlMTitle.SelectedValue = VarArray[49];
                txtMName.Text = VarArray[50];
                ddlFeeGroup.SelectedValue = VarArray[51];
                ddlFeeApplnFrom.SelectedValue = VarArray[52];

                if (VarArray[53].ToString() == "T")
                {
                    //hidStatusdisplay.Value = "T";
                    //imgATD.ImageUrl = "~/Images/Present.png";
                }
                else if (VarArray[53].ToString() == "D")
                {
                    //hidStatusdisplay.Value = "D";
                    //imgATD.ImageUrl = "~/Images/Absent.png";
                }
                else if (objDbutility.ReturnNumericValue("SELECT count(*) from StudentYearWiseDetails SYD " +
                "  INNER JOIN (SELECT  SYD.StudentID FROM StudentYearWiseDetails SYD   " +
                " WHERE  SYD.SchoolID=" + Session["SchoolID"] + " AND SYD.AcaStart=" + minAcaStart + " AND SYD.Promotion='F') P ON SYD.StudentID=P.StudentID " +
                " WHERE SYD.AcaStart=" + Session["AcaStart"] + " AND StudentStatus='S'  AND SYD.SchoolID=" + Session["SchoolID"] + " AND  SYD.StudentID=" + VarArray[0] + " ") > 0)
                {
                    //hidStatusdisplay.Value = "R";
                    //imgATD.ImageUrl = "~/Images/HalfDay.png";
                }
                ddlConcessionType.SelectedValue = VarArray[55];
                if (VarArray[56] != "0")
                {
                    //ddlMeal.SelectedValue = VarArray[56];
                }

                if (VarArray[57] == "")
                {
                    ddlSchoolBus.SelectedValue = "";
                }
                else
                {
                    ddlSchoolBus.SelectedValue = VarArray[57];
                }
                //ddlSecondLanguage.SelectedValue = VarArray[58];
                //ddlThirdLanguage.SelectedValue = VarArray[59];
                //ddlStuLiving.SelectedValue = VarArray[60];

                if (VarArray[61].ToString() == "Y")
                {
                    //rbtProvYes.Checked = true;
                }
                else
                {
                    //rbtProvNo.Checked = true;
                }
                txtDateOFJoin.Value = VarArray[62];
                //txtLiveEduID.Text = VarArray[63];

                txtCBSERollNo.Text = VarArray[65];
                if (VarArray[69].ToString() == "Y")
                {
                    //rbtnFreeShipYes.Checked = true;
                }
                else
                {
                    //rbtnFreeShipNo.Checked = true;
                }
                //txtGGNNo.Text = VarArray[70];


                //ClientScript.RegisterStartupScript(this.GetType(), "displayFillFields", "<script language=javascript> pAddGridAttributes('frmStudentmaster')</script>");
                string vardata = objDbutility.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(MotherTongueID AS Varchar)  FROM studentLanguages Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
                                          "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

                objDbutility.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName AS MotherTongueName,1 as id FROM MotherTongueSetting  WHERE MotherTongueID<>0 AND MotherTongueID IN (select * from [fnSplit] ('" + vardata + "',',')) union Select MotherTongueID,MotherTongueName As MotherTongueName,2 as id From MotherTongueSetting WHERE MotherTongueID<>0  AND MotherTongueID NOT IN (select * from [fnSplit] ('" + vardata + "',',')) ORDER BY id ", "MotherTongueID", "MotherTongueName");
                if (vardata != "0")
                {
                    string[] varStr = vardata.Split(',');
                    for (int i = 0; i < varStr.Length; i++)
                    {
                        if (chkLanguageKnown.Items.Count > 0)
                        {
                            for (int inti = 0; inti < chkLanguageKnown.Items.Count; inti++)
                            {
                                if (chkLanguageKnown.Items[inti].Value == varStr[i])
                                {
                                    chkLanguageKnown.Items[inti].Selected = true;
                                }

                            }
                        }
                    }
                }
            }
            intStudentID = objDbutility.ReturnNumericValue("SELECT  SM.StudentID FROM StudentDetails SM INNER JOIN StudentYearWiseDetails SYD ON SM.StudentID = SYD.StudentID WHERE SM.ParentID='" + txtParentID.Text.Trim() + "' AND SYD.AcaStart=" + Session["AcaStart"] + " AND SYD.SchoolID=" + Session["SchoolID"] + "");
            hdnFlag.Value = "A";
        }
        if (btnNew.Enabled == true && (txtAdmNo.Text.Trim() != ""))
        {
            if ((txtAdmNo.Text.Trim() != "") && (hdnAdmNo.Value == ""))
            {

                intStudentID = objDbutility.ReturnNumericValue("SELECT StudentID FROM StudentYearWiseDetails WHERE AdmissionNo='" + txtAdmNo.Text.Trim() + "' AND AcaStart=" + Session["AcaStart"] + " AND SchoolID=" + Session["SchoolID"] + "");
                int pParentID = objDbutility.ReturnNumericValue("SELECT ParentID FROM StudentDetails WHERE StudentID=" + intStudentID + "");
                // string FeeNo = objDbutility.ReturnSingleValue("Select FeeNo from StudentYearWiseDetails where AdmissionNo='"+txtAdmNo.Text.Trim()+"' AND AcaStart="+Session["AcaStart"]+" AND SchoolID="+Session["SchoolID"]+" ");

                if (objDbutility.ReturnNumericValue("SELECT Count(*) from StudentYearWiseDetails where AdmissionNo='" + txtAdmNo.Text.Trim().Replace("'", "''") + "' AND AcaStart=" + Session["AcaStart"] + "  AND SchoolID=" + Session["SchoolID"] + "") <= 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert('Admission No Does Not Exits..');callreturn();</script>");
                    txtAdmNo.Focus();
                    return;
                }
                if (txtParentID.Text.Trim().Replace("'", "''") != "")
                {
                    if (objDbutility.ReturnNumericValue("SELECT Count(*) from StudentDetails SM INNER JOIN StudentYearWiseDetails YD ON YD.StudentID=SM.StudentID where ParentID='" + txtParentID.Text.Trim().Replace("'", "''") + "' ") <= 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>alert('ParentID Does Not Exits..');callreturn();</script>");
                        txtParentID.Focus();
                        return;
                    }
                    pParentID = Convert.ToInt32(txtParentID.Text.Trim());
                }

                //if (objDbutility.ReturnNumericValue("Select Count(*) From StudentYearWiseDetails where FeeNo='" + FeeNo + "' AND AcaStart=" + Session["AcaStart"] + " AND SchoolID=" + Session["SchoolID"] + "") > 1)
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "disipt", "<script language=javascript>callreturn();</script>");
                //    txtAdmNo.Focus();

                //    return;
                //}


                //strResult = pGetStudentDetails(intStudentID);
                if ((strResult == "") || (strResult == "null"))
                {
                    return;
                }
                string[] strArray1 = strResult.Split('^');
                hdntxtStuSelect.Value = strArray1[0];
                txtFirstName.Text = strArray1[1];
                txtMiddleName.Text = strArray1[2];
                txtLastName.Text = strArray1[3];
                if (strArray1[5].ToString() == "M")
                {
                    rbtnMale.Checked = true;
                }
                else
                {
                    rbtnFeMale.Checked = true;
                }
                txtStuDOB.Value = txtStuDOB.Value + "~" + strArray1[6];

                txtDOA.Value = strArray1[7];
                ddlAdmittedClass.SelectedValue = strArray1[8];
                ddlSocCategory.SelectedValue = strArray1[9];

                ddlReligion.SelectedValue = strArray1[10];
                txtStuEmail.Text = strArray1[13];
                ddlBloodGroup.SelectedValue = strArray1[14];
                ddlNationality.SelectedValue = strArray1[15];
                ddlMotherTongue.SelectedValue = strArray1[16];
                if (pParentID != Convert.ToInt32(strArray1[17]))
                {
                    txtParentID.Text = pParentID.ToString();
                }
                else
                {
                    txtParentID.Text = strArray1[17];
                }
                //txtNoOfChild.Text = strArray1[19];
                //txtPositionChild.Text = strArray1[20];
                txtAdmNo.Text = strArray1[21];
                txtFeeNo.Text = strArray1[22];
                ddlClass.SelectedValue = strArray1[23];
                ddlSection.SelectedValue = strArray1[24];
                //lblCaption1.Text = "Strength";
                strClassStrength = objDbutility.ReturnSingleValue("Select Count(*) from StudentDetails SIM inner join StudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
                  " where StudentStatus='S' and SYD.ClassID='" + strArray1[23] + "' and SYD.SectionID='" + strArray1[24] + "' and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");

                //lblClassStrength.Text = "Class : " + "" + strClassStrength;


                strSchoolStrength = objDbutility.ReturnSingleValue("Select Count(*) from StudentDetails SIM inner join StudentYearWiseDetails SYD ON SYD.StudentID=SIM.StudentID " +
                  " where StudentStatus='S'  and SYD.SchoolID='" + Session["SchoolID"] + "' and SYD.AcaStart='" + Session["AcaStart"] + "'");

                //lblTotalStrength.Text = "School : " + "" + strSchoolStrength;

                if (strArray1[25].ToString() == "N")
                {
                    rbtnAdmissionNew.Checked = true;
                }
                else
                {
                    rbtnAdmissionOld.Checked = true;
                }
                txtRollNo.Text = strArray1[26];
                ddlHouse.SelectedValue = strArray1[27];
                ddlBoard.SelectedValue = strArray1[28];
                txtBoardRegNo.Text = strArray1[29];
                ddlBoardingCategory.SelectedValue = strArray1[30];
                //txtChildCode.Text = strArray1[31];
                txtPresAddress.Value = strArray1[33];
                //hdntxtResiCity.Value = strArray1[34];
                txtPerPincode.Text = strArray1[35];
                txtPresPhone.Text = strArray1[36];
                txtPerAddress.Value = strArray1[37];
                //hdntxtPerCity.Value = strArray1[38];
                txtPerPincode.Text = strArray1[39];
                txtPerPhone.Text = strArray1[40];
                //txtResiCity.Text = strArray1[41];
                //txtPresState.Text = strArray1[42];
                //txtPresCountry.Text = strArray1[43];
                //txtPerCity.Text = strArray1[44];
                //txtPerState.Text = strArray1[45];
                //txtPerCountry.Text = strArray1[46];
                ddlFTitle.SelectedValue = strArray1[47];
                txtFName.Text = strArray1[48];
                ddlMTitle.SelectedValue = strArray1[49];
                txtMName.Text = strArray1[50];
                ddlFeeGroup.SelectedValue = strArray1[51];


                ddlFeeApplnFrom.SelectedValue = strArray1[52];

                //if (strArray1[53].ToString() == "T")
                //{
                //    hidStatusdisplay.Value = "T";
                //    imgATD.ImageUrl = "~/Images/Present.png";
                //}
                //else if (strArray1[53].ToString() == "D")
                //{
                //    hidStatusdisplay.Value = "D";
                //    imgATD.ImageUrl = "~/Images/Absent.png";
                //}
                //else if (objDbutility.ReturnNumericValue("SELECT count(*) from StudentYearWiseDetails SYD " +
                //   "  INNER JOIN (SELECT  SYD.StudentID FROM StudentYearWiseDetails SYD   " +
                //   " WHERE  SYD.SchoolID=" + Session["SchoolID"] + " AND SYD.AcaStart=" + minAcaStart + " AND SYD.Promotion='F') P ON SYD.StudentID=P.StudentID " +
                //   " WHERE SYD.AcaStart=" + Session["AcaStart"] + " AND StudentStatus='S'  AND SYD.SchoolID=" + Session["SchoolID"] + " AND  SYD.StudentID=" + strArray1[0] + " ") > 0)
                //{
                //    hidStatusdisplay.Value = "R";
                //    imgATD.ImageUrl = "~/Images/HalfDay.png";
                //}

                ddlConcessionType.SelectedValue = strArray1[55];
                //if (strArray1[56] != "0")
                //{
                //    ddlMeal.SelectedValue = strArray1[56];
                //}

                if (strArray1[57] == "")
                {
                    ddlSchoolBus.SelectedValue = "";
                }
                else
                {
                    ddlSchoolBus.SelectedValue = strArray1[57];
                }
                ddlStuLiving.SelectedValue = strArray1[60];


                //if (strArray1[61].ToString() == "Y")
                //{
                //    rbtProvYes.Checked = true;
                //}
                //else
                //{
                //    rbtProvNo.Checked = true;
                //}
                txtDateOFJoin.Value = strArray1[62];
                //txtLiveEduID.Text = strArray1[63];


                txtCBSERollNo.Text = strArray1[65];
                //ddlStream.SelectedValue = (strArray1[66] == "" ? "0" : strArray1[66]);
                //txtCaste.Text = strArray1[68];

                if (strArray1[69].ToString() == "Y")
                {
                    // rbtnFreeShipYes.Checked = true;
                }
                else
                {
                    // rbtnFreeShipNo.Checked = true;
                }
                //txtGGNNo.Text = strArray1[70];
                string vardata2 = objDbutility.ReturnSingleValue("declare @varSelected as varchar(2000); set @varSelected=''; SELECT @varSelected=@varSelected+','+ CAst(MotherTongueID AS Varchar)  FROM studentLanguages Where StudentID=" + intStudentID + "   Select CASE WHEN LEN(@varSelected)>1  " +
                                          "  THEN SubString(@varSelected,1,LEN(@varSelected))   ELSE '0' END as  GridDetails");

                objDbutility.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName AS MotherTongueName,1 as id FROM MotherTongueSetting  WHERE MotherTongueID<>0 AND MotherTongueID IN (select * from [fnSplit] ('" + vardata2 + "',',')) union Select MotherTongueID,MotherTongueName As MotherTongueName,2 as id From MotherTongueSetting WHERE MotherTongueID<>0  AND MotherTongueID NOT IN (select * from [fnSplit] ('" + vardata2 + "',',')) ORDER BY id ", "MotherTongueID", "MotherTongueName");

                if (vardata2 != "0")
                {
                    string[] varStr = vardata2.Split(',');

                    for (int i = 0; i < varStr.Length; i++)
                    {
                        if (chkLanguageKnown.Items.Count > 0)
                        {
                            for (int inti = 0; inti < chkLanguageKnown.Items.Count; inti++)
                            {
                                if (chkLanguageKnown.Items[inti].Value == varStr[i])
                                {
                                    chkLanguageKnown.Items[inti].Selected = true;
                                }

                            }
                        }
                    }
                }
                bindImage(intStudentID);
                //fBusRouteDetails(intStudentID);
                //if (hdnFindSearch.Value == "F")
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=\"javascript\" type=\"text/javascript\">" + strfindShowID + "</script>");
                //}
            }
            if (hdnFlag.Value != "PID")
            {
                hdnFlag.Value = "A";
            }
        }
    }
    #endregion
    protected void BindControls()
    {
        objDbutility.FillDDLs(ddlFTitle, "Select TitleId, TitleName from TitleSetting order By TitleName", "TitleId", "TitleName");
        objDbutility.FillDDLs(ddlMTitle, "Select TitleId, TitleName from TitleSetting order By TitleName", "TitleId", "TitleName");
        objDbutility.FillDDLs(ddlClass, "Select ClassId, ClassName from ClassSetting Order By ClassName", "ClassId", "ClassName");
        objDbutility.FillDDLs(ddlSection, "Select SectionID, SectionName from SectionSetting order by SectionName", "SectionID", "SectionName");
        objDbutility.FillDDLs(ddlAdmittedClass, "Select ClassId, ClassName from ClassSetting Order By ClassName", "ClassId", "ClassName");
        objDbutility.FillCheckedBoxList(chkLanguageKnown, "SELECT MotherTongueID,MotherTongueName AS MotherTongueName FROM MotherTongueSetting  WHERE MotherTongueID<>0 ORDER BY  MotherTongueName", "MotherTongueID", "MotherTongueName");
        objDbutility.FillDDLs(ddlReligion, "Select ReligionID, ReligionName from ReligionSetting Order By ReligionName", "ReligionID", "ReligionName");
        objDbutility.FillDDLs(ddlHouse, "Select HouseID, HouseName from HouseSetting Order By HouseName", "HouseID", "HouseName");
        objDbutility.FillDDLs(ddlNationality, "Select NationalityID,NationalityName from NationalitySetting Order By  NationalityName", "NationalityID", "NationalityName");
        objDbutility.FillDDLs(ddlMotherTongue, "Select MotherTongueID,MotherTongueName from MotherTongueSetting Order By  MotherTongueName", "MotherTongueID", "MotherTongueName");
        objDbutility.FillDDLs(ddlBoard, "Select BoardID,BoardName from BoardSetting Order By  BoardName", "BoardID", "BoardName");
        objDbutility.FillDDLs(ddlBoardingCategory, "Select BoardingCategoryID,BoardingCategoryName from BoardingCategorySetting Order By BoardingCategoryName", "BoardingCategoryID", "BoardingCategoryName");
        objDbutility.FillDDLs(ddlBloodGroup, "Select BloodGroupID,BloodGroupName from BloodGroupSetting Order By BloodGroupName", "BloodGroupID", "BloodGroupName");
        objDbutility.FillDDLs(ddlSocCategory, "Select CategoryID,CategoryName from CategorySetting  Order By CategoryName", "CategoryID", "CategoryName");
        objDbutility.FillDDLs(ddlFeeGroup, "Select * from (SELECT 0 FeeGroupID,''  AS FeeGroupName UNION SELECT FeeGroupID ,FeeGroupName1  AS FeeGroupName FROM FEEGroupMaster WHERE AcaStart=2017 ) a ORDER BY  FeeGroupName", "FeeGroupID", "FeeGroupName");
        //objDbutility.FillDDLs(ddlRCity, "SELECT CityID ,CityName  AS CityName FROM citySetting ORDER BY  CityName", "CityID", "CityName");
        //objDbutility.FillDDLs(ddlPCity, "SELECT CityID ,CityName  AS CityName FROM citySetting ORDER BY  CityName", "CityID", "CityName");
        //objDbutility.FillDDLs(ddlRState, "SELECT StateID ,StateName  AS StateName FROM StateSetting  ORDER BY  StateName", "StateID", "StateName");
        //objDbutility.FillDDLs(ddlPState, "SELECT StateID ,StateName  AS StateName FROM StateSetting  ORDER BY  StateName", "StateID", "StateName");
        //objDbutility.FillDDLs(ddlRCountry, "SELECT CountryID ,CountryName  AS CountryName FROM CountrySetting  ORDER BY  CountryName", "CountryID", "CountryName");
        //objDbutility.FillDDLs(ddlPCountry, "SELECT CountryID ,CountryName  AS CountryName FROM CountrySetting  ORDER BY  CountryName", "CountryID", "CountryName");
        //objDbutility.FillDDLs(ddlFeeApplnFrom, "Select  0 FeeApplnFrom,'' AS FeeApplnFromName UNION Select FeeInstallmentID FeeApplnFrom,FeeInstallmentName1 AS FeeApplnFromName FROM FEEInstallmentMaster " +
        //    " WHERE  SchoolId = 1", "FeeApplnFrom", "FeeApplnFromName");


    }
    private byte[] ConvertImageToByteArray(System.Drawing.Image imageToConvert, System.Drawing.Imaging.ImageFormat formatOfImage)
    {
        byte[] Ret;
        try
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageToConvert.Save(ms, formatOfImage);
                Ret = ms.ToArray();
            }
        }
        catch (Exception) { throw; }
        return Ret;
    }
    protected void Upload(object sender, EventArgs e)
    {
        string ipAddress = ""; //ipDetails
        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        hdnimageIDtemp.Value = "";
        System.Drawing.Image imag = System.Drawing.Image.FromStream(flImage.PostedFile.InputStream);
        System.Data.SqlClient.SqlConnection conn = null;
        try
        {
            try
            {
                Dbutility objDbutility = new Dbutility();
                string ConnectionString = objDbutility.ReturnConnectionString(); // ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                conn = new System.Data.SqlClient.SqlConnection(ConnectionString);
                conn.Open();
                ipAddress = Convert.ToString(ipHostInfo.AddressList.FirstOrDefault(address => address.AddressFamily == AddressFamily.InterNetwork));
                DateTime Uploadtime = DateTime.Now;
                if (objDbutility.ReturnNumericValue("SELECT COUNT(*) FROM ImageDetailsTemp") == 0)
                {
                    objDbutility.ExecuteQuery("INSERT INTO ImageDetailsTemp(Imgid, pic,ipDetails,EntryDate) VALUES (0,'0','0', GeteDate())");
                }
                objDbutility.ExecuteQuery("delete from ImageDetailsTemp where ipDetails='" + ipAddress + "' and EntryDate <=DATEADD(hh,-2,getdate())");
                System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand("Insert into [ImageDetailsTemp] " +
                " (Imgid, pic,ipDetails,EntryDate) Select ISNULL(Max(Imgid),0)+1, @Pic,'" + ipAddress + "','" + Uploadtime + "' from ImageDetailsTemp", conn);
                insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
                int queryResult = insertCommand.ExecuteNonQuery();
                if (queryResult == 1)
                    lblRes.Text = "File uploaded successfully";
                hdnimageIDtemp.Value = objDbutility.ReturnSingleValue("Select Imgid from ImageDetailsTemp where ipDetails='" + ipAddress + "' and EntryDate='" + Uploadtime + "'");
            }
            catch (Exception ex)
            {
                lblRes.Text = "Error: " + ex.Message;
            }
        }
        finally
        {
            if (conn != null)
                conn.Close();
        }
        //Extract Image File Name.
        //string fileName = Path.GetFileName(flImage.PostedFile.FileName);
        //string strConnectionString = objDbutility.ReturnConnectionString();
        ////Set the Image File Path.
        //string filePath = "~/Uploads/" + fileName;
        //if (fileName == "")
        //{

        //}
        //else
        //{
        //    //Save the Image File in Folder.
        //    flImage.PostedFile.SaveAs(Server.MapPath(filePath));

        //    string ConnectionString = strConnectionString;// ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //    using (SqlConnection conn = new SqlConnection(ConnectionString))
        //    {
        //        string sql = "Delete from Files";
        //        using (SqlCommand cmd = new SqlCommand(sql, conn))
        //        {
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            conn.Close();
        //        }
        //    }
        //using (SqlConnection conn = new SqlConnection(ConnectionString))
        //{
        //    string sql = "INSERT INTO Files VALUES(@Name, @Path)";
        //    using (SqlCommand cmd = new SqlCommand(sql, conn))
        //    {
        //        cmd.Parameters.AddWithValue("@Name", fileName);
        //        cmd.Parameters.AddWithValue("@Path", filePath);
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //        conn.Close();
        //    }
        //}
        //using (SqlConnection conn = new SqlConnection(ConnectionString))
        //{
        //    using (SqlDataAdapter sda = new SqlDataAdapter("SELECT top 1 * FROM Files", conn))
        //    {
        //        DataTable dt = new DataTable();
        //        sda.Fill(dt);
        //        if (dt.Rows.Count != 0)
        //        {
        //            //imgStudent.ImageUrl = dt.Rows[0].ItemArray[1].ToString();
        //            imgStudent.ImageUrl = "ImgHandler.ashx?imgid=1"; //dt.Rows[0].ItemArray[1].ToString();

        //        }
        //        else
        //        {
        //            imgStudent.ImageUrl = "~/Uploads/Noimage.jpg";

        //        }
        //    }
        //}
        //}
        return;
    }
    public void bindImage(int studentID)
    {
        DataTable dt = new DataTable();
        dt = objDbutility.BindDataTable("Select pic from StudentDetails where studentID =" + studentID + "");
        if (dt.Rows.Count != 0)
        {
            //imgStudent.ImageUrl = dt.Rows[0].ItemArray[1].ToString();
            imgStudent.ImageUrl = "ImgHandler.ashx?imgid=" + studentID + ""; //dt.Rows[0].ItemArray[1].ToString();

        }
        else
        {
            imgStudent.ImageUrl = "~/Uploads/Noimage.jpg";

        }
    }
}
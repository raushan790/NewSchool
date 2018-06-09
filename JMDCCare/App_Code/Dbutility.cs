using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Mail;
using System.Net.NetworkInformation;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Dbutility
/// </summary>
public class Dbutility
{
    public Dbutility()
    {
        //
        // TODO: Add constructor logic here
        //
    }

        protected static string strDisplayType = "ltr";
        protected static string strServer = System.Configuration.ConfigurationManager.AppSettings.Get("ServerName");
        protected static string strDatabase = System.Configuration.ConfigurationManager.AppSettings.Get("DatabaseName");
        protected static string strDatabaseUID = System.Configuration.ConfigurationManager.AppSettings.Get("UID");
        protected static string strDatabasePWD = System.Configuration.ConfigurationManager.AppSettings.Get("PWD");
        protected static string strConnectionString = "Data Source=" + strServer + ";User ID=" + strDatabaseUID + ";PWD=" + strDatabasePWD + ";Initial Catalog=" + strDatabase + ";Max Pool Size=500;Pooling=True;Connect Timeout=0;";

    public string ReturnConnectionString()
    {
        return strConnectionString;
    }
    public string ReturnDataBaseUID()
    {
        return strDatabaseUID;
    }
    public string ReturnDataBasePWD()
    {
        return strDatabasePWD;
    }

    public void FillDDLs(DropDownList ddlName, string strSQl, string strValue, string strText, string strDisplay)
    {
        SqlConnection conFillDDL = new SqlConnection();
        SqlCommand cmdFillDDL = new SqlCommand();
        conFillDDL.ConnectionString = strConnectionString;//ConfigurationManager.AppSettings.Get("Connectionstring");

        conFillDDL.Open();
        cmdFillDDL.Connection = conFillDDL;
        cmdFillDDL.CommandText = strSQl;
        SqlDataReader rdrFillDDL = cmdFillDDL.ExecuteReader();
        ddlName.DataSource = rdrFillDDL;
        ddlName.DataValueField = strValue;
        ddlName.DataTextField = strText;
        ddlName.DataBind();
        rdrFillDDL.Close();
        cmdFillDDL.Dispose();
        conFillDDL.Close();
        conFillDDL.Dispose();
        GC.Collect();
    }
        public void FillList(ListBox lstName, string strSQL, string strValue, string strText, string strDisplay)
        {
            SqlConnection conFillList = new SqlConnection();
            SqlCommand cmdFillList = new SqlCommand();
            conFillList.ConnectionString = strConnectionString;//ConfigurationManager.AppSettings.Get("Connectionstring");
            conFillList.Open();
            cmdFillList.Connection = conFillList;
            cmdFillList.CommandText = strSQL;
            SqlDataReader rdrFillList = cmdFillList.ExecuteReader();
            lstName.DataSource = rdrFillList;
            lstName.DataValueField = strValue;
            lstName.DataTextField = strText;
            lstName.DataBind();
            rdrFillList.Close();
            rdrFillList.Dispose();
            cmdFillList.Dispose();
            conFillList.Close();
            conFillList.Dispose();
            GC.Collect();
        }
        public void FillCheckedBoxList(CheckBoxList chkList, string strSQL, string strValue, string strText, string strDisplay)
        {
            SqlConnection conFillChk = new SqlConnection(strConnectionString);//new SqlConnection(ConfigurationManager.AppSettings.Get("Connectionstring"));
            conFillChk.Open();
            SqlCommand cmdFillChk = new SqlCommand(strSQL, conFillChk);
            cmdFillChk.CommandTimeout = 0;
            SqlDataReader rdrFillChk = cmdFillChk.ExecuteReader();
            chkList.DataSource = rdrFillChk;
            chkList.DataValueField = strValue;
            chkList.DataTextField = strText;
            chkList.DataBind();
            chkList.Dispose();
            rdrFillChk.Close();
            rdrFillChk.Dispose();
            conFillChk.Close();
            conFillChk.Dispose();
            GC.Collect();
        }
        public void FillRadioButtonList(RadioButtonList rbtnList, string strSQL, string strValue, string strText, string strDisplay)
        {
            SqlConnection conFillRbtn = new SqlConnection(strConnectionString);//new SqlConnection(ConfigurationManager.AppSettings.Get("Connectionstring"));
            conFillRbtn.Open();
            SqlCommand cmdFillRbtn = new SqlCommand(strSQL, conFillRbtn);
            cmdFillRbtn.CommandTimeout = 0;
            SqlDataReader rdrFillRbtn = cmdFillRbtn.ExecuteReader();
            rbtnList.DataSource = rdrFillRbtn;
            rbtnList.DataValueField = strValue;
            rbtnList.DataTextField = strText;
            rbtnList.DataBind();
            rbtnList.Dispose();
            rdrFillRbtn.Close();
            rdrFillRbtn.Dispose();
            conFillRbtn.Close();
            conFillRbtn.Dispose();
            GC.Collect();
        }
        public string ReturnSingleValue(string strSQL)
        {
            string strValue = "";
            SqlConnection conValue = new SqlConnection();
            SqlCommand cmdValue = new SqlCommand();
            conValue.ConnectionString = strConnectionString;//ConfigurationManager.AppSettings.Get("Connectionstring");
            conValue.Open();
            cmdValue.Connection = conValue;
            cmdValue.CommandText = strSQL;
            SqlDataReader rdrValue = cmdValue.ExecuteReader();
            if (rdrValue.Read())
                strValue = rdrValue.GetValue(0).ToString();
            rdrValue.Close();
            rdrValue.Dispose();
            cmdValue.Dispose();
            conValue.Close();
            conValue.Dispose();
            return strValue;
        }
        public string ChangeYYYYMMDD(string strDate)
        {
            string[] strFinalDate;
            strFinalDate = strDate.Split('/');
            if (strFinalDate.Length != 3)
                strFinalDate = strDate.Split('-');
            if (strFinalDate.Length != 3)
                strFinalDate = strDate.Split('.');
            return strFinalDate[2] + '-' + strFinalDate[1] + '-' + strFinalDate[0];
        }
        public string ReturnDateorNull(string strDate)
        {
            string strResult;
            if (strDate == "")
                strResult = "NULL";
            else
                strResult = "'" + ChangeYYYYMMDD(strDate) + "'";
            return strResult;
        }

        public bool IsValidAdmissionNo(string strAdNo)
        {
            string strResult;
            strResult = ReturnSingleValue("SELECT AdmissionNo FROM CCStudentDetails WHERE AdmissionNo='" + strAdNo + "' ");
            if (strResult != "")
                return true;
            else
                return false;

        }
        public int ReturnNumericValue(string strSQL)
        {


            int intValue = 0;
            SqlConnection conValue = new SqlConnection();
            SqlCommand cmdValue = new SqlCommand();
            conValue.ConnectionString = strConnectionString;//ConfigurationManager.AppSettings.Get("Connectionstring");
            conValue.Open();

            cmdValue.Connection = conValue;
            cmdValue.CommandText = strSQL;
            SqlDataReader rdrValue = cmdValue.ExecuteReader();

            if (rdrValue.Read() == true)
            {
                intValue = Convert.ToInt32(rdrValue.GetValue(0));

            }

            rdrValue.Close();
            rdrValue.Dispose();
            cmdValue.Dispose();
            conValue.Close();
            conValue.Dispose();
            return intValue;

        }

        public void Sp_RunProc(string Sp_Name, SqlParameter[] parameters)
        {
            SqlConnection conExecute = new SqlConnection();
            SqlCommand cmdExecute = new SqlCommand();
            try
            {
                conExecute.ConnectionString = strConnectionString;//ConfigurationManager.AppSettings.Get("Connectionstring");
                if (conExecute.State == ConnectionState.Closed)
                {
                    conExecute.Open();
                }
                SqlCommand Cmd = new SqlCommand(Sp_Name, conExecute);
                for (int i = 0; i < parameters.Length; i++)
                {

                    Cmd.Parameters.Add(parameters.GetValue(i));

                }
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conExecute.Close();
            }

        }

        public string AcaStartDate()
        {
            string dteAcaStart;
            dteAcaStart = ReturnSingleValue("SELECT TOP 1 CONVERT(VARCHAR,A_Start_date,103) FROM SchoolDetailMaster");
            return dteAcaStart;
        }
        public bool IsValidUser(string strUserID)
        {
            int intResult;
            intResult = ReturnNumericValue("SELECT COUNT(*) FROM USERS WHERE User_ID='" + strUserID + "' ");
            if (intResult > 0)
                return true;
            else
                return false;
        }
        public bool IsValidDDMMYY(string strDate)
        {

            DateTime dteCheck;
            try
            {
                dteCheck = Convert.ToDateTime(strDate);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string ReturnTimeorNull(string strTIme)
        {
            string strResult;
            if (strTIme == "")
                strResult = "NULL";
            else
                strResult = "'" + strTIme + "'";
            return strResult;
        }

        public string ExecuteQuery(string strSQL)
        {
            SqlTransaction transExecute = null;
            SqlConnection conExecute = new SqlConnection();
            SqlCommand cmdExecute = new SqlCommand();
            string strResult = "";
            try
            {
                conExecute.ConnectionString = strConnectionString;//ConfigurationManager.AppSettings.Get("Connectionstring");
                if (conExecute.State == ConnectionState.Closed)
                    conExecute.Open();
                transExecute = conExecute.BeginTransaction();
                cmdExecute = new SqlCommand(strSQL, conExecute);
                cmdExecute.CommandTimeout = 0;
                cmdExecute.Transaction = transExecute;
                cmdExecute.ExecuteNonQuery();

                transExecute.Commit();
            }
            catch (SqlException sqlex)
            {
                if (transExecute != null)
                {
                    transExecute.Rollback();
                    strResult = sqlex.Message.Replace("'", "");
                }
            }
            catch (Exception ex)
            {
                if (transExecute != null)
                {
                    transExecute.Rollback();
                    strResult = ex.Message.Replace("'", "");
                }
            }
            finally
            {
                cmdExecute.Dispose();
                conExecute.Close();
                conExecute.Dispose();
                GC.Collect();
            }
            return strResult;
        }

        public string ExecuteQueryList(List<string> strSQL)
        {

            SqlTransaction transExecute = null;
            SqlConnection conExecute = new SqlConnection();
            SqlCommand cmdExecute = new SqlCommand();
            string strReturn = "";
            try
            {
                conExecute.ConnectionString = strConnectionString;//ConfigurationManager.AppSettings.Get("Connectionstring");
                if (conExecute.State == ConnectionState.Closed)
                    conExecute.Open();
                transExecute = conExecute.BeginTransaction();
                for (int intLoopVariable = 0; intLoopVariable < strSQL.Count; intLoopVariable++)
                {
                    cmdExecute = new SqlCommand(strSQL[intLoopVariable], conExecute);
                    cmdExecute.Transaction = transExecute;
                    cmdExecute.ExecuteNonQuery();
                }
                cmdExecute.CommandTimeout = 0;
                transExecute.Commit();

            }
            catch (SqlException sqlex)
            {
                if (transExecute != null)
                {
                    transExecute.Rollback();
                    strReturn = sqlex.Message.Replace("'", "");
                }
            }
            catch (Exception ex)
            {
                if (transExecute != null)
                {
                    transExecute.Rollback();
                    strReturn = ex.Message.Replace("'", "");
                }
            }
            finally
            {
                cmdExecute.Dispose();
                cmdExecute.Connection = null;
                conExecute.Close();
                conExecute.Dispose();
                GC.Collect();
            }
            return strReturn;
        }

        public void ExecuteQueryS(string strSQL, string strTemporyTable, string strHistory)
        {
            string[] strArraySQL = new string[100];
            string[] strArrayTemporyTable = new string[100];
            string[] strArrayHistory = new string[100];

            strArraySQL = strSQL.Split('~');
            strArrayTemporyTable = strTemporyTable.Split('~');
            strArrayHistory = strHistory.Split('~');
            SqlTransaction transExecute = null;
            SqlConnection conExecute = new SqlConnection();
            SqlCommand cmdExecute = new SqlCommand();
            try
            {
                conExecute.ConnectionString = strConnectionString;//ConfigurationManager.AppSettings.Get("Connectionstring");
                if (conExecute.State == ConnectionState.Closed)
                    conExecute.Open();
                transExecute = conExecute.BeginTransaction();
                for (int intLoopVariable = 0; intLoopVariable < strArrayTemporyTable.Length; intLoopVariable++)
                {
                    cmdExecute = new SqlCommand(strArrayTemporyTable[intLoopVariable], conExecute);
                    cmdExecute.Transaction = transExecute;
                    cmdExecute.ExecuteNonQuery();
                }
                for (int intLoopVariable = 0; intLoopVariable < strArraySQL.Length; intLoopVariable++)
                {
                    cmdExecute = new SqlCommand(strArraySQL[intLoopVariable], conExecute);
                    cmdExecute.Transaction = transExecute;
                    cmdExecute.ExecuteNonQuery();
                }
                for (int intLoopVariable = 0; intLoopVariable < strArrayHistory.Length; intLoopVariable++)
                {
                    cmdExecute = new SqlCommand(strArrayHistory[intLoopVariable], conExecute);
                    cmdExecute.Transaction = transExecute;
                    cmdExecute.ExecuteNonQuery();
                }

                transExecute.Commit();
            }
            catch (Exception ex)
            {
                if (transExecute != null)
                {
                    transExecute.Rollback();
                    //throw;
                    HttpContext.Current.Response.Write("<script>alert('" + ex.Message.Replace("'", "") + "');</script>");
                }
            }
            finally
            {
                cmdExecute.Dispose();
                conExecute.Close();
                conExecute.Dispose();
                GC.Collect();
            }
        }

        public SqlDataReader BindReader(string strSQL)
        {
            if ((Regex.IsMatch(strSQL.ToLower(), @"\bdelete\b") == true) || (Regex.IsMatch(strSQL.ToLower(), @"\bupdate\b") == true) || (Regex.IsMatch(strSQL.ToLower(), @"\binsert\b") == true)
              || (Regex.IsMatch(strSQL.ToLower(), @"\balter\b") == true) || (Regex.IsMatch(strSQL.ToLower(), @"\bdrop\b") == true) || (Regex.IsMatch(strSQL.ToLower(), @"\btruncate\b") == true)
              || (Regex.IsMatch(strSQL.ToLower(), @"foreign_keys") == true) || (Regex.IsMatch(strSQL.ToLower(), @"key_constraints") == true) || (Regex.IsMatch(strSQL.ToLower(), @"object_id") == true)
              || (Regex.IsMatch(strSQL.ToUpper(), @"INFORMATION_SCHEMA") == true) || (Regex.IsMatch(strSQL.ToLower(), @"sys.objects") == true) || (Regex.IsMatch(strSQL.ToLower(), @".objects") == true)
              || (Regex.IsMatch(strSQL.ToLower(), @"sys.columns") == true) || (Regex.IsMatch(strSQL.ToLower(), @"\bcursor\b") == true))
            {
                HttpContext.Current.Response.Write("<script>window.close();window.open('Logon.aspx','_parent');</script>");
                HttpContext.Current.Response.End();
            }

            SqlConnection conGetData = new SqlConnection(strConnectionString);//new SqlConnection(ConfigurationManager.AppSettings.Get("Connectionstring"));
            conGetData.Open();
            SqlCommand cmdGetData = new SqlCommand(strSQL, conGetData);
            cmdGetData.CommandTimeout = 0;
            SqlDataReader rdrGetData = cmdGetData.ExecuteReader(CommandBehavior.CloseConnection);
            return rdrGetData;
            conGetData.Close();
            conGetData.Dispose();
        }


        public DataSet BindDataSet(string strSQL)
        {
            SqlConnection conGetData = new SqlConnection(strConnectionString);//new SqlConnection(ConfigurationManager.AppSettings.Get("Connectionstring"));
            conGetData.Open();
            SqlCommand cmdGetData = new SqlCommand(strSQL, conGetData);
            cmdGetData.CommandTimeout = 0;
            SqlDataAdapter rdrAdptr = new SqlDataAdapter(cmdGetData);
            DataSet ds = new DataSet();
            rdrAdptr.Fill(ds);
            conGetData.Close();
            conGetData.Dispose();
            rdrAdptr.Dispose();
            return ds;
        }

        public DataSet BindGrid(string strIDEN)
        {
            SqlConnection sqlcon = new SqlConnection(strConnectionString);//new SqlConnection(ConfigurationManager.AppSettings.Get("Connectionstring"));
            DataSet ds = new DataSet();
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlAdptr = new SqlDataAdapter("spGirdBindMaster", sqlcon);
            sqlAdptr.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@IdentifiCation", strIDEN));
            sqlAdptr.Fill(ds);
            sqlcon.Close();
            sqlcon.Dispose();
            sqlAdptr.Dispose();
            return ds;

        }


        public string ExecuteCommandQuery(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection();
            SqlTransaction transExecute = null;

            string result;
            con.ConnectionString = strConnectionString;//ConfigurationManager.AppSettings.Get("Connectionstring");
            cmd.Connection = con;

            try
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                transExecute = con.BeginTransaction();
                cmd.ExecuteNonQuery();

                transExecute.Commit();
                result = "Success...";
                return result;
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2627)
                {
                    result = "Duplicate Value can not be inserted...";


                }
                else
                {
                    result = sqlex.Message;
                }
                transExecute.Rollback();
                return result;
            }


            catch (Exception ex)
            {

                result = ex.Message;
                transExecute.Rollback();
                return result;
            }

            finally
            {
                cmd.Dispose();
                cmd.Connection.Close();
                con.Close();
                con.Dispose();
                GC.Collect();
            }

        }

        public void ReturnStateCountry(string CityID)
        {

            string strResult;
            if (CityID != "")
            {
                System.Web.HttpContext.Current.Response.Clear();
                strResult = ReturnSingleValue("SELECT SM.StateName+'~'+MCM.CountryName AS Result FROM MTCityMaster CM INNER JOIN MTStateMaster SM ON CM.StateID=SM.StateID " +
                                              " INNER JOIN MTCountryMaster MCM ON SM.CountryID=MCM.CountryID WHERE CM.CityID='" + CityID + "'");

                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.ContentType = "text/xml";
                System.Web.HttpContext.Current.Response.Write(strResult);

                //end the response
                System.Web.HttpContext.Current.Response.End();
            }
            else
            {
                //clears the response written into the buffer and end the response.
                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.End();
            }


        }
        public void ExportToExcel(GridView GridName, HtmlForm frmForm, string StrHeading, string ExcelWord)
        {
            string attachment;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<Head align='center' style='font-weight:bold;font-family:Arial;font-size:16'>" + StrHeading + " </head>");
            HtmlForm form = new HtmlForm();
            if (ExcelWord == "Word")
            {
                attachment = "attachment; filename=" + GridName.ID + ".doc";
                HttpContext.Current.Response.ContentType = "application/ms-word";
            }
            else if (ExcelWord == "pdf")
            {
                attachment = "attachment; filename=" + GridName.ID + ".pdf";
                HttpContext.Current.Response.ContentType = "application/pdf";
            }
            else if (ExcelWord == "html")
            {
                attachment = "attachment; filename=" + GridName.ID + ".html";
                HttpContext.Current.Response.ContentType = "application/html";
            }
            else
            {
                attachment = "attachment; filename=" + GridName.ID + ".xls";
                HttpContext.Current.Response.ContentType = "application/ms-excel";
            }
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            StringWriter stw = new StringWriter(sb);
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            form.Controls.Add(GridName);
            frmForm.Controls.Add(form);
            form.RenderControl(htextw);
            HttpContext.Current.Response.Write(stw.ToString());
            HttpContext.Current.Response.End();

        }
        public void ExportToExcelPanel(Panel GridName, HtmlForm frmForm, string StrHeading, string ExcelWord)
        {
            string attachment;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<Head align='center' style='font-weight:bold;font-family:Arial;font-size:16'>" + StrHeading + " </head>");
            HtmlForm form = new HtmlForm();
            if (ExcelWord == "Word")
            {
                attachment = "attachment; filename=" + GridName.ID + ".doc";
                HttpContext.Current.Response.ContentType = "application/ms-word";
            }
            else if (ExcelWord == "pdf")
            {
                attachment = "attachment; filename=" + GridName.ID + ".pdf";
                HttpContext.Current.Response.ContentType = "application/pdf";
            }
            else
            {
                attachment = "attachment; filename=" + GridName.ID + ".xls";
                HttpContext.Current.Response.ContentType = "application/ms-excel";
            }
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            StringWriter stw = new StringWriter(sb);
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            form.Controls.Add(GridName);
            frmForm.Controls.Add(form);
            form.RenderControl(htextw);
            HttpContext.Current.Response.Write(stw.ToString());
            HttpContext.Current.Response.End();

        }
        public void pChangeButtonColor(Control parent)
        {

            foreach (Control ctlTemp in parent.Controls)
            {
                if (ctlTemp.GetType() == typeof(Button))
                {
                    if (((Button)(ctlTemp)).Enabled == true)
                        ((Button)(ctlTemp)).ForeColor = System.Drawing.Color.FromName("#4000000");
                    else
                        ((Button)(ctlTemp)).ForeColor = System.Drawing.Color.FromName("InactiveBorder");
                }


                if (ctlTemp.HasControls())
                    pChangeButtonColor(ctlTemp);

            }


        }
        public decimal ReturnDecimalValue(string strSQL)
        {
            decimal intValue = 0;
            SqlConnection conValue = new SqlConnection();
            SqlCommand cmdValue = new SqlCommand();
            conValue.ConnectionString = strConnectionString;//ConfigurationManager.AppSettings.Get("Connectionstring");
            conValue.Open();

            cmdValue.Connection = conValue;
            cmdValue.CommandText = strSQL;
            SqlDataReader rdrValue = cmdValue.ExecuteReader();

            if (rdrValue.Read() == true)
            {
                intValue = Convert.ToDecimal(rdrValue.GetValue(0));

            }

            rdrValue.Close();
            cmdValue.Dispose();
            conValue.Close();
            conValue.Dispose();
            return intValue;

        }
        //Honey For Library
        public void pRemoveAutoComplete(Control parent)
        {
            foreach (Control ctlTemp in parent.Controls)
            {
                if (ctlTemp.GetType() == typeof(TextBox))
                {
                    ((TextBox)(ctlTemp)).Attributes.Add("autocomplete", "off");

                }
                if (ctlTemp.HasControls())
                    pRemoveAutoComplete(ctlTemp);

            }
        }
        public string pExecuteQuery(string strSQL)
        {
            SqlTransaction transExecute = null;
            SqlConnection conExecute = new SqlConnection();
            SqlCommand cmdExecute = new SqlCommand();
            string strResult = "";
            try
            {
                conExecute.ConnectionString = strConnectionString;//ConfigurationManager.AppSettings.Get("Connectionstring");
                if (conExecute.State == ConnectionState.Closed)
                    conExecute.Open();
                transExecute = conExecute.BeginTransaction();
                cmdExecute = new SqlCommand(strSQL, conExecute);
                cmdExecute.Transaction = transExecute;
                cmdExecute.ExecuteNonQuery();

                transExecute.Commit();
            }
            catch (SqlException sqlex)
            {
                if (transExecute != null)
                {
                    transExecute.Rollback();
                    strResult = sqlex.Message.Replace("'", "");
                }
            }
            catch (Exception ex)
            {
                if (transExecute != null)
                {
                    transExecute.Rollback();
                    strResult = ex.Message.Replace("'", "");
                }
            }
            finally
            {
                cmdExecute.Dispose();
                conExecute.Close();
                conExecute.Dispose();
                GC.Collect();
            }
            return strResult;
        }
        public void ExportToExcelG(GridView GridName, HtmlForm frmForm, string StrHeading, string ExcelWord)
        {
            string attachment;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<Head align='center' style='font-weight:bold;font-family:Arial;font-size:16'>" + StrHeading + " </head>");
            HtmlForm form = new HtmlForm();
            if (ExcelWord == "Word")
            {
                attachment = "attachment; filename=" + GridName.ID + ".doc";
                HttpContext.Current.Response.ContentType = "application/ms-word";
            }
            else if (ExcelWord == "pdf")
            {
                attachment = "attachment; filename=" + GridName.ID + ".pdf";
                HttpContext.Current.Response.ContentType = "application/pdf";
            }
            else
            {
                attachment = "attachment; filename=" + GridName.ID + ".xls";
                HttpContext.Current.Response.ContentType = "application/ms-excel";
            }
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            StringWriter stw = new StringWriter(sb);
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            GridName.BorderWidth = 0;
            form.Controls.Add(GridName);
            frmForm.Controls.Add(form);
            form.RenderControl(htextw);
            HttpContext.Current.Response.Write(stw.ToString());
            HttpContext.Current.Response.End();

        }
        public string ExecuteQuery1(string strSQL)
        {
            string[] strArraySQL = strSQL.Split('~');

            SqlTransaction transExecute = null;
            SqlConnection conExecute = new SqlConnection();
            SqlCommand cmdExecute = new SqlCommand();
            try
            {
                conExecute.ConnectionString = ConfigurationManager.AppSettings.Get("Connectionstring");
                if (conExecute.State == ConnectionState.Closed)
                    conExecute.Open();
                transExecute = conExecute.BeginTransaction();
                for (int intLoopVariable = 0; intLoopVariable < strArraySQL.Length; intLoopVariable++)
                {
                    cmdExecute = new SqlCommand(strArraySQL[intLoopVariable], conExecute);
                    cmdExecute.Transaction = transExecute;
                    cmdExecute.ExecuteNonQuery();
                }
                transExecute.Commit();
            }
            catch (Exception ex)
            {
                if (transExecute != null)
                {
                    transExecute.Rollback();
                    // throw;

                    System.Web.HttpContext.Current.Response.Write("<script>alert('" + ex.Message.Replace("'", "") + "')</script>");



                }
            }
            finally
            {
                cmdExecute.Dispose();
                conExecute.Close();
            }
            return "";
        }
        public string pDisplayMessage(string strType, string strMessage, string StrLabel)
        {
            string StrReturn = "";
            if (strType == "1")
            {
                if (StrLabel == "")
                {
                    if (strMessage == "1")
                    {
                        StrReturn = "Saved Successfully";
                    }
                    if (strMessage == "2")
                    {
                        StrReturn = "Updated Successfully";
                    }
                    if (strMessage == "3")
                    {
                        StrReturn = "Deleted Successfully";
                    }
                    if (strMessage == "4")
                    {
                        StrReturn = "Data Is In Use";
                    }
                    if (strMessage == "5")
                    {
                        StrReturn = "Enter Valid Date";
                    }
                    // NEWLY ADDED GAURAV 
                    if (strMessage == "7")
                    {
                        StrReturn = " ** Select ** ";
                    }
                    if (strMessage == "8")
                    {
                        StrReturn = "Withdrawn Successfully ";
                    }
                    if (strMessage == "9")
                    {
                        StrReturn = "Acquisition Re-Entered Successfully";
                    }
                    if (strMessage == "10")
                    {
                        StrReturn = "Accession Code In Use";
                    }
                    if (strMessage == "11")
                    {
                        StrReturn = "Membership Already in Use";
                    }
                    if (strMessage == "12")
                    {
                        StrReturn = "Membership Cancelled";
                    }
                    if (strMessage == "13")
                    {
                        StrReturn = "Membership Renewed";
                    }
                    if (strMessage == "14")
                    {
                        StrReturn = "Membership Granted";
                    }
                    if (strMessage == "15")
                    {
                        StrReturn = "Membership Deleted";
                    }
                    if (strMessage == "16")
                    {
                        StrReturn = "Membership Temporarily Suspended";
                    }
                    if (strMessage == "17")
                    {
                        StrReturn = "Please Enter Collection Category";
                    }
                    //For Student Drop out Details(Added by Tinu)
                    if (strMessage == "311_1")
                    {
                        StrReturn = "Invalid Roll No";
                    }
                    if (strMessage == "311_2")
                    {
                        StrReturn = "Details Restored Successfully";
                    }
                    if (strMessage == "311_3")
                    {
                        StrReturn = "Please Clear Fee Data First";
                    }
                    if (strMessage == "310_1")
                    {
                        StrReturn = "Transferred Successfully";
                    }


                    // END ADDED


                    //For Student Drop out Details(Added by Tinu)
                    if (strMessage == "311_1")
                    {
                        StrReturn = "Invalid Roll No";
                    }
                    if (strMessage == "311_2")
                    {
                        StrReturn = "Details Restored Successfully";
                    }
                    if (strMessage == "311_3")
                    {
                        StrReturn = "Please Clear Fee Data First";
                    }
                    if (strMessage == "310_1")
                    {
                        StrReturn = "Transferred Successfully";
                    }
                    //For Student Promotion
                    if (strMessage == "309_1")
                    {
                        StrReturn = "Student Already Promoted To Next Class";
                    }
                    if (strMessage == "309_2")
                    {
                        StrReturn = "Next Academic Year Doesnt Exists";
                    }
                    //For Academic Session Master
                    if (strMessage == "101_1")
                    {
                        StrReturn = "Existing Academic Session Overlapping";
                    }
                    if (strMessage == "101_2")
                    {
                        StrReturn = "Current Session Cannot Be Deleted";
                    }
                    //For Change Password
                    if (strMessage == "128_1")
                    {
                        StrReturn = "Incorrect Password";
                    }
                    //Exam Mark Entry
                    if (strMessage == "1123_1")
                    {
                        StrReturn = "Subject assignment not done !";
                    }
                    if (strMessage == "1123_2")
                    {
                        StrReturn = "Permission is not given for mark entry";
                    }
                    // For Generated Report Card
                    if (strMessage == "1132_1")
                    {
                        StrReturn = "Report Card Generated";
                    }
                    if (strMessage == "1132_2")
                    {
                        StrReturn = "Temporary Data Deleted";
                    }
                    if (strMessage == "1132_3")
                    {
                        StrReturn = "Please Select the Report Card";
                    }

                    //For User Management
                    if (strMessage == "129_1")
                    {
                        StrReturn = "User Not Found";
                    }
                    if (strMessage == "129_2")
                    {
                        StrReturn = "Logger User Can't Delete";
                    }
                    //For Fine Setting Details
                    if (strMessage == "1012_1")
                    {
                        StrReturn = "Fine Already Assigned";
                    }
                    if (strMessage == "1018_2")
                    {
                        StrReturn = "Cannot put Negative Amount More then Structure Amount  ";

                    }
                    if (strMessage == "1018_3")
                    {
                        StrReturn = "Fee Paid Is Bigger Than Fixed Amount  ";

                    }
                    //For Fee Transfer
                    if (strMessage == "1013_1")
                    {
                        StrReturn = "Already Transferred";
                    }
                    if (strMessage == "1013_2")
                    {
                        StrReturn = "Transfer Fee Heads First";
                    }
                    if (strMessage == "1013_3")
                    {
                        StrReturn = "Transfer Fee Group & Fee Heads First";
                    }

                    if (strMessage == "1023")
                    {
                        StrReturn = "No Record Found";
                    }

                    // For Health Records

                    if (strMessage == "819_1")
                    {
                        StrReturn = "Please Select The Class & Section";
                    }
                    if (strMessage == "819_2")
                    {
                        StrReturn = "Please Select The Gender";
                    }
                    if (strMessage == "816_1")
                    {
                        StrReturn = "Please Enter the Date";
                    }
                    if (strMessage == "817_1")
                    {
                        StrReturn = "Please Enter The Valid Date";
                    }

                    if (strMessage == "1118_1")
                    {
                        StrReturn = "Mark Entry Exists";
                    }

                    // For Exam Group Modification
                    if (strMessage == "1135_1")
                    {
                        StrReturn = "Exam Group Modified Successfully!";
                    }
                    if (strMessage == "1135_2")
                    {
                        StrReturn = "Exam Group Cannot be Modified";
                    }
                    if (strMessage == "1135_3")
                    {
                        StrReturn = "Assign the Exams for Exam Group and Try Again!!!";
                    }
                    if (strMessage == "1135_4")
                    {
                        StrReturn = "Please Select Valid Information";
                    }


                }
                else
                {
                    if (strMessage == "5")
                    {
                        StrReturn = StrLabel.ToString() + " Already Exists";
                    }
                    if (strMessage == "6")
                    {
                        StrReturn = " ** Select " + StrLabel.ToString() + " ** ";
                    }
                    if (strMessage == "1018_1")
                    {
                        StrReturn = StrLabel.ToString() + " Does Not Exist";
                    }


                }
                return StrReturn;
            }
            else if (strType == "2")
            {
                if (StrLabel == "")
                {
                    if (strMessage == "1")
                    {
                        StrReturn = "ٍشرثي ٍعؤثسسبعممغ";
                    }
                    if (strMessage == "2")
                    {
                        StrReturn = "حيشفثي ٍعؤؤثسسبعممغ";
                    }
                    if (strMessage == "3")
                    {
                        StrReturn = "ثمثفثي ٍٍعؤؤثسسبعممغ";
                    }
                    if (strMessage == "4")
                    {
                        StrReturn = "شفش ÷×÷س ÷ى ‘سث";
                    }
                    if (strMessage == "5")
                    {
                        StrReturn = "ُثىفثق }شمهي [شفث";
                    }
                    //For Student Drop out Details(Added by Tinu)
                    if (strMessage == "311_1")
                    {
                        StrReturn = "÷ىرشمهي ٌخمم آخ";
                    }
                    if (strMessage == "311_2")
                    {
                        StrReturn = "[ثفشهمس ٌثسفخقثي ٍعؤؤثسسبعممغ";
                    }
                    if (strMessage == "311_3")
                    {
                        StrReturn = "؛مثشسث {مثشق ]ثث [شفش ]هقسف";
                    }
                    if (strMessage == "310_1")
                    {
                        StrReturn = "لإقشىسبثققثي ٍعؤؤثسسبعممغ";
                    }
                    //For Student Promotion
                    if (strMessage == "309_1")
                    {
                        //StrReturn = "Student Already Promoted To Next Class";
                        StrReturn = "ٍفعيثىف ِمقثشيغ ؛قخةخفثي لإخ آثءف {مشسس";
                    }
                    if (strMessage == "309_2")
                    {
                        //StrReturn = "Next Academic Year Doesnt Exists";
                        StrReturn = "آثءف ِؤشيثةهؤ إثشق [خثسىف ُءهسفس";
                    }
                    //For Academic Session Master
                    if (strMessage == "101_1")
                    {
                        StrReturn = "ُءهسفهىل ِؤشيثةهؤ ٍثسسهخى ×رثقمشححهىل";
                    }
                    if (strMessage == "101_2")
                    {
                        StrReturn = "{عققثىف ٍثسسهخى {شىىخف لآث [ثمثفثي";
                    }
                    //For Change Password
                    if (strMessage == "128_1")
                    {
                        //StrReturn = "Incorrect Password";
                        StrReturn = "÷ىؤخققثؤف ؛شسسصخقي";
                    }
                    //Exam Mark Entry
                    if (strMessage == "1123_1")
                    {
                        //StrReturn = "Subject assignment not done !";
                        StrReturn = "سعلاتثؤف شسسهلىةثىف ىخف يخىث"; ;
                    }
                    if (strMessage == "1123_2")
                    {
                        //StrReturn = "Permission is not given for mark entry";
                        StrReturn = "حثقةهسسهخى ىخف لهرثى بخق ’شن ىثفقغ";
                    }
                    // For Generated Report Card
                    if (strMessage == "1132_1")
                    {
                        //StrReturn = "Report Card Generated";
                        StrReturn = "قثحخقف ؤشقي لثىثقفشثي";
                    }
                    if (strMessage == "1132_2")
                    {
                        //StrReturn = "Temporary Data Deleted";
                        StrReturn = "فثةحخقشقع يشفش يثمثفثي";
                    }

                    //For User Management
                    if (strMessage == "129_1")
                    {
                        StrReturn = "‘سثق آخف ]خعىي";
                    }
                    if (strMessage == "129_2")
                    {
                        //StrReturn = "Logger User Can't Delete";
                        StrReturn = "/خللثق ‘سثق {شىطف [ثمثفث";
                    }
                    //For Fine Setting Details
                    if (strMessage == "1012_1")
                    {
                        StrReturn = "]هىث ِمقثشيغ ِسسهلىثي";
                    }
                    if (strMessage == "1018_2")
                    {
                        StrReturn = "{شىىخف ؛عف آشقلشفهرث ِةخعىف ’خقث لإاشى ٍفقعؤفعقث ِةخعىف";

                    }
                    if (strMessage == "1018_3")
                    {
                        StrReturn = "]ثث حشيه ÷ٍ ’خقث لإاشى ]هءثي ِةخعىلاف";

                    }
                    //For Fee Transfer
                    if (strMessage == "1013_1")
                    {
                        StrReturn = "ِمقثشيغ لإقشىسبثققثي";
                    }
                    if (strMessage == "1013_2")
                    {
                        StrReturn = "لإقشىسبثق ]ثث أثشيس ]هقسف";
                    }
                    if (strMessage == "1013_3")
                    {
                        StrReturn = "لإقشىسبثق ]ثث لأقخعح & ]ثث أثشيس ]هقسف";
                    }

                    if (strMessage == "1023")
                    {
                        StrReturn = "آخ ٌثؤخقي ]خعىي";
                    }

                }
                else
                {
                    if (strMessage == "5")
                    {
                        StrReturn = StrLabel.ToString() + " ِمقثشيغ ُءهسفس";
                    }
                    if (strMessage == "6")
                    {
                        StrReturn = " ** ٍثمثؤف  " + StrLabel.ToString() + " ** ";
                    }

                    if (strMessage == "1018_1")
                    {
                        StrReturn = StrLabel.ToString() + "[??? ??? ?????";
                    }
                }

            }
            return StrReturn;
        }

        public void pDisplayTypeValue(int intType)
        {
            if (intType == 2)
            {
                strDisplayType = "rtl";
                //  return  strDisplayType;
            }
            else if (intType == 1)
            {
                strDisplayType = "ltr";
                // return  strDisplayType;
            }
        }

        public class globals
        {
            public static string StrType = strDisplayType.ToString();
            public static string DisplayType
            {
                get
                {
                    return globals.StrType;
                }
            }
        }
        public bool isConnectionAvailable()
        {
            bool _success = false;
            //build a list of sites to ping, you can use your own
            //string[] sitesList = { "208.109.248.10", "208.109.248.105" };
            string[] sitesList = { "yahoo.com", "gmail.com" };
            //create an instance of the System.Net.NetworkInformation Namespace
            Ping ping = new Ping();
            //Create an instance of the PingReply object from the same Namespace
            PingReply reply;

            //int variable to hold # of pings not successful
            int notReturned = 0;
            try
            {
                //start a loop that is the lentgh of th string array we
                //created above
                for (int i = 0; i < sitesList.Length; i++)
                {
                    //use the Send Method of the Ping object to send the
                    //Ping request
                    reply = ping.Send(sitesList[i], 5000);
                    //reply = ping.Send(sitesList[i], 10);
                    //now we check the status, looking for,
                    //of course a Success status
                    if (reply.Status != IPStatus.Success)
                    {
                        //now valid ping so increment
                        notReturned += 1;
                    }
                    //check to see if any pings came back
                    if (notReturned == sitesList.Length)
                    {
                        _success = false;
                        //comment this back in if you have your own excerption
                        //library you use for you applications (use you own
                        //exception names)
                        //throw new ConnectivityNotFoundException(@"There doest seem to be a network/internet connection.\r\n 
                        //Please contact your system administrator");
                        //use this is if you don't your own custom exception library
                        //                    throw new Exception(@"There doest seem to be a network/internet connection.\r\n 
                        //                    Please contact your system administrator");
                    }
                    else
                    {
                        _success = true;
                    }
                }
            }
            //comment this back in if you have your own excerption
            //library you use for you applications (use you own
            //exception names)
            //catch (ConnectivityNotFoundException ex)
            //use this line if you don't have your own custom exception 
            //library
            catch (Exception ex)
            {
                _success = false;

            }
            return _success;
        }

        //Added by Chandan 
        public string fReplaceChars(string replaceStr)
        {
            //return replaceStr.Trim().Replace("'", "''").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&LT;", "<").Replace("&GT;", ">").Replace("~", "").Replace("`", "").Replace("^", "").Replace("&amp;", "&");
            return replaceStr.Trim().Replace("'", "''").Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&LT;", "<").Replace("&GT;", ">").Replace("~", "").Replace("^", "");

        }
        public string fReplaceChar(TextBox t)
        {
            return "LEFT('" + t.Text.Trim().Replace("'", "''").Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&LT;", "<").Replace("&GT;", ">").Replace("~", "").Replace("^", "") + "'," + t.MaxLength + ")";
        }
        public bool pCheckText(Control Parent)
        {
            string strSession = "";
            foreach (Control frmControl in Parent.Controls)
            {
                if (frmControl.GetType().FullName == "System.Web.UI.WebControls.TextBox")
                {
                    TextBox tempBox = (TextBox)frmControl;

                    string a = tempBox.Text;
                    if ((Regex.IsMatch(tempBox.Text.ToLower(), @"\bdelete\b") == true) || (Regex.IsMatch(tempBox.Text.ToLower(), @"\bupdate\b") == true) || (Regex.IsMatch(tempBox.Text.ToLower(), @"\binsert\b") == true)
                    || (Regex.IsMatch(tempBox.Text.ToLower(), @"\balter\b") == true) || (Regex.IsMatch(tempBox.Text.ToLower(), @"\bdrop\b") == true) || (Regex.IsMatch(tempBox.Text.ToLower(), @"\btruncate\b") == true))
                    {
                        tempBox.Text = "";
                        strSession = "A";
                    }

                }

                if (frmControl.GetType().FullName == "System.Web.UI.WebControls.DropDownList")
                {
                    DropDownList tempdlBox = (DropDownList)frmControl;
                    if (tempdlBox.Items.Count > 0)
                    {
                        if ((Regex.IsMatch(tempdlBox.SelectedItem.Text.ToLower(), @"\bdelete\b") == true) || (Regex.IsMatch(tempdlBox.SelectedItem.Text.ToLower(), @"\bupdate\b") == true) || (Regex.IsMatch(tempdlBox.SelectedItem.Text.ToLower(), @"\binsert\b") == true)
                || (Regex.IsMatch(tempdlBox.SelectedItem.Text.ToLower(), @"\balter\b") == true) || (Regex.IsMatch(tempdlBox.SelectedItem.Text.ToLower(), @"\bdrop\b") == true) || (Regex.IsMatch(tempdlBox.SelectedItem.Text.ToLower(), @"\btruncate\b") == true))
                        {
                            tempdlBox.Text = "";
                            strSession = "A";
                        }
                    }

                }


            }
            if (strSession == "")
            {
                return false;
            }
            else
            {
                HttpContext.Current.Response.Write("<script>window.close();window.open('Logon.aspx','_parent');</script>");
                HttpContext.Current.Response.End();
                return true;
            }
        }
        //BindDataTable
        public DataTable BindDataTable(string strSQL)
        {
            SqlConnection conGetData = new SqlConnection(strConnectionString);//new SqlConnection(ConfigurationManager.AppSettings.Get("Connectionstring"));
            conGetData.Open();
            SqlCommand cmdGetData = new SqlCommand(strSQL, conGetData);
            cmdGetData.CommandTimeout = 0;
            SqlDataAdapter rdrAdptr = new SqlDataAdapter(cmdGetData);
            DataTable dt = new DataTable();
            rdrAdptr.Fill(dt);
            conGetData.Close();
            conGetData.Dispose();
            rdrAdptr.Dispose();
            return dt;

        }
}
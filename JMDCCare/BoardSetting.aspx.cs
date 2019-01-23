﻿using System;
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

public partial class BoardSetting : System.Web.UI.Page
{
    Dbutility objDbutility = new Dbutility();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UID"] = 1;
        if (!IsPostBack)
        {
            txtBoard.Attributes.Add("AutoComplete", "off");
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
        //Building the Header row. style="display: none;"
        html.Append("  <thead>  <tr class=\"headings\">");
        int ColCount = 0;
        foreach (DataColumn column in dt.Columns)
        {
            if (ColCount == 0)
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
                if (ColCount == 0)
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
        DataTable dt = objDbutility.BindDataTable("SELECT BoardID, BoardName [Board Name] FROM BoardSetting  WHERE BoardID<>0 ORDER BY BoardName");
        return dt;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string strResult;
            string[] astrFlag = hdnFlag.Value.ToString().Split('^');
            if (astrFlag[0] == "N" || astrFlag[0] == "E" && astrFlag[2].Trim().ToUpper() != txtBoard.Value.Trim().ToUpper())
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(BoardName) FROM BoardSetting WHERE UPPER(BoardName) =" + objDbutility.fReplaceChar(txtBoard) + "") != 0)
                {
                    strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "5", lblBoard.Text.Trim().Split('<')[0]);
                    lblMessage.Text = strResult;
                    ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
                    return;
                }
            }
            if (astrFlag[0] == "N")
            {
                if (objDbutility.ReturnNumericValue("SELECT COUNT(*) FROM BoardSetting") == 0)
                {
                    strResult = objDbutility.ExecuteQuery("INSERT INTO BoardSetting(BoardID,BoardName) VALUES(0,'')");
                }
                strResult = objDbutility.ExecuteQuery("INSERT INTO BoardSetting(BoardID,BoardName,EntryUserID,EntryDate) SELECT (ISNULL(MAX(BoardID),0))+1," + objDbutility.fReplaceChar(txtBoard) + ", " +
                                      "" + Convert.ToInt32(Session["UID"]) + ",GetDate() FROM BoardSetting");
                strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuBoard','Board Name: " + (txtBoard.Value.Trim().Replace("'", "''") != "" ? txtBoard.Value.Trim().Replace("'", "''") : txtBoard.Value.Trim().Replace("'", "''")) + " ,Is Added')");

            }
            else
            {
                strResult = objDbutility.ExecuteQuery("UPDATE BoardSetting SET BoardName=" + objDbutility.fReplaceChar(txtBoard) + ",UpdateUserID=" + Convert.ToInt32(Session["UID"]) + ", " +
                                      "UpdateDate=GetDate() WHERE BoardID=" + astrFlag[1] + "");
                strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuBoard','Board Name: " + astrFlag[2].Trim().Replace("'","''") + " To " + (txtBoard.Value.Trim().Replace("'", "''") != "" ? txtBoard.Value.Trim().Replace("'", "''") : txtBoard.Value.Trim().Replace("'", "''")) + " ,Is Modified')");

            }
            BindData();
            txtBoard.Value = "";
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
            if (objDbutility.ReturnNumericValue("EXEC GetDataused 'BoardID','BoardSetting','" + astrFlag[0] + "'") > 0)
            {
                strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "4", "");
                hdnFlag.Value = "";
                txtBoard.Value = "";
                lblMessage.Text = strResult;
                ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);

                return;
            }
            strResult = objDbutility.ExecuteQuery("INSERT INTO UserUpdateDetails(UID,SessionID,UpdateDate,FormName,Details) VALUES(" + Session["UID"] + ",'" + Session.SessionID + "',GETDATE(),'mnuCountry','Board Name: " + (txtBoard.Value.Trim().Replace("'", "''") != "" ? txtBoard.Value.Trim().Replace("'", "''") : txtBoard.Value.Trim().Replace("'", "''")) + " ,Is Deleted')");
            strResult = objDbutility.ExecuteQuery("DELETE FROM BoardSetting WHERE BoardID= " + astrFlag[0] + "");
            BindData();
            txtBoard.Value = "";
            hdnFlag.Value = "";
            if (strResult == "")
            {
                strResult = objDbutility.pDisplayMessage("" + Session["Type"].ToString() + "", "3", "");
                //ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('" + strResult + "')</script>");
            }
            else
            {
               // ClientScript.RegisterStartupScript(this.GetType(), "displayScript", "<script language=javascript>alert('" + strResult + "')</script>");
            }
            lblMessage.Text = strResult;
            ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);
        }
    }
}
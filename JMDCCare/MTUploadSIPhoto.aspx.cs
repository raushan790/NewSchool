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
using System.IO;

public partial class MTUploadSIPhoto : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		string strResult = "";

		if (Request["TypeID"] == "ImgePath" && Session["Path"] != null)
		{
			strResult = Session["Path"].ToString();
			Response.Clear();
			Response.ContentType = "text/xml";
			Response.Write(strResult);
			Response.End();
		}

		if (Request["TypeID"] == "Image")
		{
			byte[] fileData = null;
			FileStream fs = new FileStream(Request["strFileName"], FileMode.Open, FileAccess.Read);
			fileData = new byte[(int)fs.Length];
			fs.Read(fileData, 0, (int)fs.Length);
			Response.ContentType = "image/gif";
			Response.BinaryWrite(fileData);
			Response.End();
			fs.Close();
			fs = null;
			return;
		}
		if (IsPostBack)
		{
			if (UploadPhoto.HasFile)
			{
				try
				{
					/*------------Added bY Manju on 11-10-2012----------------*/
					//if (UploadPhoto.PostedFile.ContentType != "application/pdf")
					if (UploadPhoto.PostedFile.ContentType == "image/jpeg" || UploadPhoto.PostedFile.ContentType == "image/jpg")
					{
						if (UploadPhoto.PostedFile.ContentLength <= (1024 * 20))
						{
							//UploadPhoto.SaveAs(Path.GetTempPath() + UploadPhoto.FileName);
							UploadPhoto.SaveAs(Path.GetTempPath() + Session.SessionID + UploadPhoto.FileName);
						}
						else
						{
							ClientScript.RegisterStartupScript(this.GetType(), "yy", "<script>alert('Image size should not be greater than 20kb');</script>");
							return;
						}
					}
					else if (UploadPhoto.PostedFile.ContentType == "application/pdf")
					{
						if (Request["Flag"] == "D")
						{
							//UploadPhoto.SaveAs(Path.GetTempPath() + UploadPhoto.FileName);
							UploadPhoto.SaveAs(Path.GetTempPath() + Session.SessionID + UploadPhoto.FileName);
						}
					}
					else
					{
						ClientScript.RegisterStartupScript(this.GetType(), "yy", "<script>alert('Please Select JPG,JPEG Format Photos Only');</script>");
						return;
					}
				}
				catch
				{
				}
				//ClientScript.RegisterStartupScript(this.GetType(), "wclose", "<script>window.returnValue='" + Path.GetTempPath().Replace("\\", "/") + UploadPhoto.FileName.Replace("\\", "-") + '^' + UploadPhoto.PostedFile.ContentLength + "';window.close();</script>");
				//ClientScript.RegisterStartupScript(this.GetType(), "wclose", "<script>window.returnValue='" + Path.GetTempPath().Replace("\\", "/") + UploadPhoto.FileName.Replace("\\", "-") + "';window.close();</script>");
				//Session["Path"] = Path.GetTempPath().Replace("\\", "/") + UploadPhoto.FileName.Replace("\\", "-");
				//Session["Length"] = UploadPhoto.PostedFile.ContentLength;
				Session["Path"] = Path.GetTempPath().Replace("\\", "/") + Session.SessionID + UploadPhoto.FileName.Replace("\\", "-");
				Session["Length"] = UploadPhoto.PostedFile.ContentLength;
				txtRetValue.Text = Session["Path"].ToString();
				System.Web.HttpBrowserCapabilities browser = Request.Browser;
				//if (hdnValue.Value == "safari")
				if (browser.Browser == "Chrome")
				{
					//ClientScript.RegisterStartupScript(this.GetType(), "wclose", "<script>window.onbeforeunload= function(){ window.opener.document.getElementById('hdnSImagePath').value = document.getElementById('txtRetValue').value;window.opener.ffillImage(); };window.close();</script>");
					ClientScript.RegisterStartupScript(this.GetType(), "wclose", "<script>window.onbeforeunload= function(){ window.opener.document.getElementById('hdnImage').value = document.getElementById('txtRetValue').value;window.opener.ffillImage(); };window.close();</script>");
				}
				else
				{
					//ClientScript.RegisterStartupScript(this.GetType(), "wclose", "<script>window.returnValue='" + Path.GetTempPath().Replace("\\", "/") + UploadPhoto.FileName.Replace("\\", "-") + "';window.close();</script>");
					ClientScript.RegisterStartupScript(this.GetType(), "wclose", "<script>window.returnValue='" + Path.GetTempPath().Replace("\\", "/") + Session.SessionID + UploadPhoto.FileName.Replace("\\", "-") + "';window.close();</script>");
				}
			}
			else
			{
				ClientScript.RegisterStartupScript(this.GetType(), "wclose", "<script>window.returnValue='';window.close();</script>");
			}
			//ClientScript.RegisterStartupScript(this.GetType(), "wclose", "<script>window.returnValue='" + UploadPhoto.PostedFile.FileName.Replace("\\", "/") + "';window.close();</script>");
			return;
		}
	}
}
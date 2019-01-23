<%@ WebHandler Language="C#" Class="ImgHandler" %>

using System;
using System.Web;

public class ImgHandler : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        System.Data.SqlClient.SqlDataReader rdr = null;
        System.Data.SqlClient.SqlConnection conn = null;
        System.Data.SqlClient.SqlCommand selcmd = null;
        try
        {
            if (context.Request.QueryString["imgid"] != "'" && context.Request.QueryString["imgid"] != "")
            {
                Dbutility objDbutility = new Dbutility();
                string ConnectionString = objDbutility.ReturnConnectionString(); ;// ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                conn = new System.Data.SqlClient.SqlConnection(ConnectionString);
                selcmd = new System.Data.SqlClient.SqlCommand("select pic from ImageDetailsTemp where imgid=" + context.Request.QueryString["imgid"], conn);
                conn.Open();
                rdr = selcmd.ExecuteReader();
                while (rdr.Read())
                {
                    context.Response.ContentType = "image/jpg";
                    context.Response.BinaryWrite((byte[])rdr["pic"]);
                }
                if (rdr != null)
                    rdr.Close();
            }
        }
        finally
        {
            if (conn != null)
                conn.Close();
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}
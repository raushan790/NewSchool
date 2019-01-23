using System;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data;



public partial class namoona_imgupl : System.Web.UI.Page
{

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

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    //Upload image to database
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      System.Drawing.Image imag = System.Drawing.Image.FromStream(flImage.PostedFile.InputStream);
      System.Data.SqlClient.SqlConnection conn = null;
        try
        {
          try
          {
                Dbutility objDbutility = new Dbutility();
                string ConnectionString = objDbutility.ReturnConnectionString(); ;// ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                conn = new System.Data.SqlClient.SqlConnection(ConnectionString);
                 conn.Open();
                System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand("Insert into [msg] (msgid, pic1) Values (1, @Pic)", conn);
            insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
            int queryResult = insertCommand.ExecuteNonQuery();
            if (queryResult == 1)
              lblRes.Text = "msg record Created Successfully";
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
      
    }
}

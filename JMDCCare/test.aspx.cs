using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class namoona_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "myModal", "ShowPopup();", true);

       // Response.Write("Button Clicked");
    }
}

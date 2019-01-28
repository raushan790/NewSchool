<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Home</title>
    <link rel="stylesheet" href="fonts/material-icon/css/material-design-iconic-font.min.css" />
    <link rel="stylesheet" href="css/style.css"/>
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="js/main.js"></script>
        <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
 
</head>
<body>
   <form id="frmHome" runat="server">
        <div class="main">
                                 <div class="messagealert" id="alert_container">
            </div>
                <section class="signin">
                    <div class="container">
                        <div class="signup-content">
                                <h2 class="form-title">Home</h2>
                                <div class="form-group">
                                    <asp:Label ID="lblName" Text="Welcome Raushan" CssClass="form-title"  runat="server"></asp:Label>
                                </div>
                              <p class="loginhere">
                               <a href="Login.aspx" class="loginhere-link">Sign Out</a>
                            </p>
                        </div>
                    </div>
                </section>

            </div>
    </form>
</body>
</html>

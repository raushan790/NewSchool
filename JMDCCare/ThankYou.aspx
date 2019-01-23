<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThankYou.aspx.cs" Inherits="ThankYou" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <title>Thank you</title>
    <link rel="stylesheet" href="fonts/material-icon/css/material-design-iconic-font.min.css" />
    <link rel="stylesheet" href="css/style.css"/>
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="js/main.js"></script>
        <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
 
</head>
<body>
        <form id="frmThankyou" runat="server">
        <div class="main">
            <div class="messagealert" id="alert_container">
            </div>
                <section class="signin">
                    <div class="container">
                        <div class="signup-content">
                               
                                <div class="form-group">
                                                <img class="center-block" style="height: 150px; margin-bottom: 20px;" src="../images/successCheck.png"/>
                                </div>
                             <h2 class="form-title">Thank you foe registration</h2>
                       

                            <p class="loginhere">
                                You have an account now. <a href="Login.aspx" class="loginhere-link">Sign in here</a>
                            </p>
                        </div>
                    </div>
                </section>

            </div>
    </form>
</body>
</html>

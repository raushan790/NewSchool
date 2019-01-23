<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
    <link rel="stylesheet" href="fonts/material-icon/css/material-design-iconic-font.min.css" />
    <link rel="stylesheet" href="css/style.css"/>
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="js/main.js"></script>
        <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
 
    <style type="text/css">
        .messagealert {
            width: 100%;
            position: fixed;
             top:0px;
            z-index: 100000;
            padding: 0;
            font-size: 15px;
        }
    </style>
    <script type="text/javascript">
        function validateEmail(emailField) {
            var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

            if (reg.test(emailField.value) == false) {
                //alert('Invalid Email Address');
                ShowMessage("Invalid Email Address","Error");
                return false;
            }

            return true;
        }

        function validateSave() {
            debugger;
            $('#close').click();
         if ($('#txtMobileNo').val() == "") {
                ShowMessage("Please enter Mobile No.!", "alert-dange");
                $('#txtMobileNo').focus();
                return false;
            }
        else if ($('#txtPassword').val() == "") {
                ShowMessage("Please enter password!", "alert-dange");
                $('#txtPassword').focus();
                return false;
            }
           
            return true;
        }
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a id="close" href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
        }
    </script>

</head>

<body>
    <form id="frmLogin" runat="server">
        <div class="main">
                                 <div class="messagealert" id="alert_container">
            </div>
                <section class="signin">
                    <!-- <img src="images/signup-bg.jpg" alt=""> -->
                    <div class="container">
                        <div class="signup-content">
                                <h2 class="form-title">Sign In</h2>
                                <div class="form-group">
						                <input id="txtMobileNo" runat="server"  class="form-input"  type="text" name="name" placeholder="Mobile No."  maxlength="10" />
                                </div>
                                <div class="form-group">
					            	<input id="txtPassword" runat="server" class="form-input"  type="password" name="pass" placeholder="*************"  maxlength="50" />
                                </div>
                                <div class="form-group">
        							  <asp:Button id="btnSignup" runat="server" class="form-submit" Text="Sign In" OnClick="btnSignup_Click" OnClientClick="return validateSave();"> </asp:Button>
                                </div>
                            <p class="loginhere">
                                Don't an account ? <a href="Register.aspx" class="loginhere-link">Sign up here</a>
                            </p>
                        </div>
                    </div>
                </section>

            </div>
    </form>
</body>
</html>

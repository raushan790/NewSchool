<%@ Page Title="" Language="C#" MasterPageFile="~/bankMaster.master" AutoEventWireup="true" CodeFile="Debit.aspx.cs" Inherits="Debit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Select2 -->
    <link href="assets/vendors/select2/dist/css/select2.min.css" rel="stylesheet">
    <!-- Switchery -->
    <link href="assets/vendors/switchery/dist/switchery.min.css" rel="stylesheet">
    <!-- starrr -->
    <link href="assets/vendors/starrr/dist/starrr.css" rel="stylesheet">
        <script src="assets/js/StandardValidation.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <!-- page content -->

        <div id="myModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
               </div>
                <div class="modal-body">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
               </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        Close</button>
               </div>
            </div>
        </div>
     </div>
             <div class="messagealert" id="alert_container">
            </div>
    <div class="right_col" role="main">

<%--         <div class="messagealert" id="alert_container">
            </div>--%>
        <div class="">
            <div class="page-title">
                <div class="title_right">
                    <h3>Debit Information</h3>
                </div>

                <div class="title_left">
                    <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                        <div class="input-group">
<%--                            <input type="text" class="form-control" placeholder="Search for...">--%>
                            <span class="input-group-btn">
<%--                                <button class="btn btn-default" type="button">Go!</button>--%>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2><small><span style="color:red;">*</span>Please type account no. and press enter....</small></h2>
                            <ul class="nav navbar-left panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                                <li><a class="foo bar" rel="nameClose" href="../debit"><i class="fa fa-close"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <br />
                            <div id="demo-form2" data-parsley-validate class="form-horizontal form-label-left">


                                 <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Accno">
                                        Enter Account No.
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" id="Accno" runat="server" class="form-control col-md-7 col-xs-12">
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="firstname">
                                        First Name <span class="required">*</span>
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" id="firstname" disabled="disabled" runat="server"  class="form-control col-md-7 col-xs-12">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="middlename" class="control-label col-md-3 col-sm-3 col-xs-12">Middle Name</label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input id="middlename" runat="server" disabled="disabled" class="form-control col-md-7 col-xs-12" type="text" name="middle-name">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="lastname">
                                        Last Name <span class="required">*</span>
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" runat="server" id="lastname" disabled="disabled" name="last-name"  class="form-control col-md-7 col-xs-12">
                                    </div>
                                </div>
                                 <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="email">
                                        Email Id 
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" runat="server" id="email" disabled="disabled" name="email"  class="form-control col-md-7 col-xs-12">
                                    </div>
                                </div>
                                 <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="FatherName">
                                        Father's Name <span class="required">*</span>
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" runat="server" id="FatherName" disabled="disabled" name="FatherName"  class="form-control col-md-7 col-xs-12">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Gender <span class="required">*</span></label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                    <p style="margin: 6px 7px 10px;"> 
                                    M:
                       
                                    <input type="radio" runat="server" disabled="disabled"  class="flat" name="gender" id="genderM" value="M" checked="" required />
                                    F:
                       
                                    <input type="radio"  runat="server" disabled="disabled" class="flat" name="gender" id="genderF" value="F" />

                                </p>

                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                        Date Of Birth <span class="required">*</span>
                                    </label>
                                    <div class="col-md-2 col-sm-2 col-xs-12">
                                            <input type="text" disabled="disabled"  class="form-control has-feedback-center" id="single_cal1" aria-describedby="inputSuccess2Status1" required="required" >
                                            <span class="fa fa-calendar-o form-control-feedback left" aria-hidden="true"></span>
                                            <span id="inputSuccess2Status1" class="sr-only">(success)</span>
                                              <input type="hidden" ID="txtDOB" runat="server" />
                                              <input type="hidden" ID="hndAccno" runat="server" />

                                </div>
                               </div>

                                  <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="panNo">
                                        Pan/UID/Adhar No. <span class="required">*</span>
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" runat="server" disabled="disabled" id="panNo" name="panNo"  placeholder="KYC Details" class="form-control col-md-7 col-xs-12">
                                    </div>
                                </div>
                                  <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="balance">
                                      Main Balance
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input  type="text" runat="server" id="balance" disabled="disabled"  name="balance"  placeholder="0.00" class="form-control col-md-7 col-xs-12">
                                    </div>
                                </div>
                                 <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="addbalance">
                                      Debit Balance
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input  type="text" runat="server" id="addbalance"  name="addbalance"  placeholder="0.00" class="form-control col-md-7 col-xs-12">
                                    </div>
                                </div>
                                <div class="ln_solid"></div>
                                <div class="form-group">
                                    <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                                        <asp:Button ID="btnNew" runat="server" class="btn btn-primary"  Text="Reset" OnClientClick="return pClearFields1('aspnetForm');" />
                                        <asp:Button ID="btnSave" runat="server"  class="btn btn-primary" Text="Save" OnClick="btnSave_Click"/>
                                        <asp:HiddenField ID="hdnFlag" runat="server" />
                                        <asp:Button ID="btnDisplay" runat="server" Text="Display" OnClick="btnDisplay_Click" Style="display: none;" />

                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- /page content -->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="end" runat="Server">
    <!-- bootstrap-wysiwyg -->
    <script src="assets/vendors/bootstrap-wysiwyg/js/bootstrap-wysiwyg.min.js"></script>
    <script src="assets/vendors/jquery.hotkeys/jquery.hotkeys.js"></script>
    <script src="assets/vendors/google-code-prettify/src/prettify.js"></script>
    <!-- jQuery Tags Input -->
    <script src="assets/vendors/jquery.tagsinput/src/jquery.tagsinput.js"></script>
    <!-- Switchery -->
    <script src="assets/vendors/switchery/dist/switchery.min.js"></script>
    <!-- Select2 -->
    <script src="assets/vendors/select2/dist/js/select2.full.min.js"></script>
    <!-- Parsley -->
    <script src="assets/vendors/parsleyjs/dist/parsley.min.js"></script>
    <!-- Autosize -->
    <script src="assets/vendors/autosize/dist/autosize.min.js"></script>
    <!-- jQuery autocomplete -->
    <script src="assets/vendors/devbridge-autocomplete/dist/jquery.autocomplete.min.js"></script>
    <!-- starrr -->
    <script src="assets/vendors/starrr/dist/starrr.js"></script>
    <script src="assets/vendors/bootstrap-wysiwyg/js/bootstrap-wysiwyg.min.js"></script>
    <script src="assets/vendors/jquery.hotkeys/jquery.hotkeys.js"></script>
    <script src="assets/vendors/google-code-prettify/src/prettify.js"></script>
    <script src="assets/vendors/jquery.tagsinput/src/jquery.tagsinput.js"></script>
    <script src="assets/vendors/switchery/dist/switchery.min.js"></script>
    <script src="assets/vendors/select2/dist/js/select2.full.min.js"></script>
    <script src="assets/vendors/autosize/dist/autosize.min.js"></script>
    <script src="assets/vendors/devbridge-autocomplete/dist/jquery.autocomplete.min.js"></script>
    <script src="assets/vendors/starrr/dist/starrr.js"></script>
    <script src="assets/js/StandardValidation.js"></script>
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
            $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a id="close" href="../credit.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
        }
        function ShowPopup() {
            $("#myModal").modal('show');
            pClearFields('aspnetForm');
            pLockControls('aspnetForm', 'U');
            Response.redirect('credit.aspx');
        }
        $(document).ready(function () {
            debugger;
            pLockControls('aspnetForm', 'L');            
            $('#<%=Accno.ClientID%>').attr('readonly', false);
            $('#<%=addbalance.ClientID%>').attr('readonly', false);
            // $('a.foo.bar[rel="nameClose"]').click(function () {
            //     fredirect();
            //});        
        });  
        function fBind_Student(e) {
            //debugger;
            var varKey;
            if (window.event)
                varKey = window.event.keyCode;
            else
                varKey = e.which;
            if ($('#<%=Accno.ClientID%>').val().length > 0) {
                if (varKey == 13 || varKey == 0) {
                    var strArray = $('#<%=Accno.ClientID%>').val().split('#');
                    if (strArray[0] != undefined) {
                        $('#<%=Accno.ClientID%>').val($.trim(strArray[0]));
                        $('#<%=btnDisplay.ClientID%>').click()
                        return false;
                    }
                    return false;
                }
            }
        }
   function pClearFields1(Parent) {
    var varElements = document.getElementById(Parent).getElementsByTagName('INPUT');
    for (var varForLoop = 0; varForLoop < varElements.length; varForLoop++) {
        if (varElements[varForLoop].type.toLowerCase() == 'text' || varElements[varForLoop].type.toLowerCase() == 'textarea') varElements[varForLoop].value = '';
        else if (varElements[varForLoop].type.toLowerCase() == 'checkbox') varElements[varForLoop].checked = false;
    }
    var varElements = document.getElementById(Parent).getElementsByTagName('SELECT');
    for (var varForLoop = 0; varForLoop < varElements.length; varForLoop++) {
        varElements[varForLoop].selectedIndex = -1;
    }
    var varElements = document.getElementById(Parent).getElementsByTagName('textarea');
    for (var varForLoop = 0; varForLoop < varElements.length; varForLoop++) {
        varElements[varForLoop].value = '';
       }
       return false;
}   

    </script></asp:Content>


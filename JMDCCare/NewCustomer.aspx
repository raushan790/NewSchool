<%@ Page Title="" Language="C#" MasterPageFile="~/bankMaster.master" AutoEventWireup="true" CodeFile="NewCustomer.aspx.cs" Inherits="NewCustomer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- bootstrap-wysiwyg -->
    <link href="assets/vendors/google-code-prettify/bin/prettify.min.css" rel="stylesheet">
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
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_right">
                    <h3>Customer Registration</h3>
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
<%--                            <h2>Form Design <small>different form elements</small></h2>--%>
                            <ul class="nav navbar-left panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                                    <ul class="dropdown-menu" role="menu">
                                        <li><a href="#">Settings 1</a>
                                        </li>
                                        <li><a href="#">Settings 2</a>
                                        </li>
                                    </ul>
                                </li>
                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <br />
                            <div id="demo-form2" data-parsley-validate class="form-horizontal form-label-left">

                                 <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Accno">
                                       Search By Account
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" id="txtsearch" runat="server"  class="form-control col-md-7 col-xs-12">
                                    </div>
                                </div>

                                 <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Accno">
                                        Account No.
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" id="Accno" runat="server" disabled="disabled"  class="form-control col-md-7 col-xs-12">
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="firstname">
                                        First Name <span class="required">*</span>
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" id="firstname" runat="server"  class="form-control col-md-7 col-xs-12">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="middlename" class="control-label col-md-3 col-sm-3 col-xs-12">Middle Name</label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input id="middlename" runat="server" class="form-control col-md-7 col-xs-12" type="text" name="middle-name">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="lastname">
                                        Last Name <span class="required">*</span>
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" runat="server" id="lastname" name="last-name"  class="form-control col-md-7 col-xs-12">
                                    </div>
                                </div>
                                 <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="email">
                                        Email Id 
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" runat="server" id="email" name="email"  class="form-control col-md-7 col-xs-12">
                                    </div>
                                </div>
                                 <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">
                                        Father's Name <span class="required">*</span>
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" runat="server" id="FatherName" name="last-name"  class="form-control col-md-7 col-xs-12">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Gender <span class="required">*</span></label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                    <p style="margin: 6px 7px 10px;"> 
                                    M:
                       
                                    <input type="radio" runat="server"  class="flat" name="gender" id="genderM" value="M" checked="" required />
                                    F:
                       
                                    <input type="radio"  runat="server" class="flat" name="gender" id="genderF" value="F" />

                                </p>

                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                        Date Of Birth <span class="required">*</span>
                                    </label>
                                    <div class="col-md-2 col-sm-2 col-xs-12">
                                            <input type="text"  class="form-control has-feedback-center" id="single_cal1" aria-describedby="inputSuccess2Status1" required="required" >
                                            <span class="fa fa-calendar-o form-control-feedback left" aria-hidden="true"></span>
                                            <span id="inputSuccess2Status1" class="sr-only">(success)</span>
                                              <input type="hidden" ID="txtDOB" runat="server" />
                                              <input type="hidden" ID="hndAccno" runat="server" />
                                </div>
                               </div>

                                  <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">
                                        Pan/UID/Adhar No. <span class="required">*</span>
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" runat="server" id="panNo" name="last-name"  placeholder="KYC Details" class="form-control col-md-7 col-xs-12">
                                    </div>
                                </div>
                                  <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">
                                        Balance
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input  type="text" runat="server" id="balance" disabled="disabled" name="last-name"  placeholder="0.00" class="form-control col-md-7 col-xs-12">
                                    </div>
                                </div>
                                <div class="ln_solid"></div>
                                <div class="form-group">
                                    <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                                           <asp:Button ID="btnNew" runat="server" class="btn btn-primary"  Text="New" OnClientClick="return fNew();"
                                               OnClick="btnNew_Click" />
                                        <asp:Button ID="btnEdit" runat="server" class="btn btn-primary"  Text="Edit"  OnClientClick="return fedit();" />
                                        <asp:Button ID="btnCancel" runat="server" class="btn btn-primary"  Text="Cancel"
                                               OnClick="btnCancel_Click" />
<%--                                        <button class="btn btn-primary" type="reset">Reset</button>--%>
                                        <asp:Button ID="btnSave" runat="server"  class="btn btn-primary" Text="Save" OnClick="btnSave_Click"/>
                                                                                        <asp:HiddenField ID="hdnFlag" runat="server" />
                                         <asp:HiddenField ID="hdnstatus" runat="server" />
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

    <script type="text/javascript">
        function ShowPopup() {
            $("#myModal").modal('show');
            pClearFields('aspnetForm');
            pLockControls('aspnetForm', 'U');
        }
        $(document).ready(function () {
            pLockControls('aspnetForm', 'L');
            $('#<%=txtDOB.ClientID%>').val($('#single_cal3').val());
            if ($('#<%=hdnFlag.ClientID%>').val().split('~').length > 1) {
                if ($('#<%=hdnFlag.ClientID%>').val().split('~')[0] == "N") {
                     pLockControls('aspnetForm', 'U');
                }
            }
            $('#<%=txtsearch.ClientID%>').attr('readonly', false);
            if ($('#<%=hdnstatus.ClientID%>').val() == "C"||  $('#<%=hdnstatus.ClientID%>').val() == "");
            {
                $('#<%=btnNew.ClientID%>').attr('disabled', false);
                $('#<%=btnSave.ClientID%>').attr('disabled', true);
                $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                $('#<%=btnCancel.ClientID%>').attr('disabled', false);
            }
            if ($('#<%=hdnstatus.ClientID%>').val() == "N") {
                $('#<%=btnNew.ClientID%>').attr('disabled', true);
                $('#<%=btnSave.ClientID%>').attr('disabled', false);
                $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                $('#<%=btnCancel.ClientID%>').attr('disabled', false);
            }
            if ($('#<%=hdnstatus.ClientID%>').val() == "E") {
                $('#<%=btnNew.ClientID%>').attr('disabled', true);
                $('#<%=btnSave.ClientID%>').attr('disabled', true);
                $('#<%=btnEdit.ClientID%>').attr('disabled', false);
                $('#<%=btnCancel.ClientID%>').attr('disabled', false);
            }
            if ($('#<%=hdnstatus.ClientID%>').val() == "EE") {
                $('#<%=btnNew.ClientID%>').attr('disabled', true);
                $('#<%=btnSave.ClientID%>').attr('disabled', false);
                $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                $('#<%=btnCancel.ClientID%>').attr('disabled', false);
                pLockControls('aspnetForm', 'U');
            }
             $('a.foo.bar[rel="nameClose"]').click(function () {
                 fredirect();
            });        
        });  
        function fedit() {
            $('#<%=hdnstatus.ClientID%>').val("EE");
        }
        function fNew() {
            $('#<%=hdnFlag.ClientID%>').val("N");
         <%--   $('#<%=btnNew.ClientID%>').attr('disabled', true);
            $('#<%=btnSave.ClientID%>').attr('disabled', false);
            $('#<%=btnEdit.ClientID%>').attr('disabled', true);
            $('#<%=btnCancel.ClientID%>').attr('disabled', false);--%>
            //pLockControls('aspnetForm', 'U');
        }
        function fBind_Student(e) {
            //debugger;
            var varKey;
            if (window.event)
                varKey = window.event.keyCode;
            else
                varKey = e.which;
            if ($('#<%=txtsearch.ClientID%>').val().length > 0) {
                if (varKey == 13 || varKey == 0) {
                    var strArray = $('#<%=txtsearch.ClientID%>').val().split('#');
                    if (strArray[0] != undefined) {
                        $('#<%=txtsearch.ClientID%>').val($.trim(strArray[0]));
                        $('#<%=btnDisplay.ClientID%>').click()
                        return false;
                    }
                    return false;
                }
            }
        }
    </script>
</asp:Content>


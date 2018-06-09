<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AcademicSession.aspx.cs" Inherits="AcademicSession" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="assets/vendors/select2/dist/css/select2.min.css" rel="stylesheet">
    <link href="assets/vendors/switchery/dist/switchery.min.css" rel="stylesheet">
    <link href="assets/vendors/starrr/dist/starrr.css" rel="stylesheet">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <!-- page content -->
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_right">
                    <h3>Academic Session</h3>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <ul class="nav navbar-right panel_toolbox">
                                <li><a  class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                                <li><a class="foo bar" rel="nameClose" href = "#"><i class="fa fa-close"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <br />
                            <div id="demo-form2" data-parsley-validate class="form-horizontal form-label-left">

<%--                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                        Title<span class="required">*</span>
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" maxlength="50" runat="server" id="txtTitleName" required="required" class="form-control col-md-7 col-xs-12">
                                    </div>
                                            <asp:HiddenField ID="hdnFlag" runat="server" />   
                                </div>--%>
                                <asp:HiddenField ID="hdnFlag" runat="server" />   
                                <div class="form-horizontal form-label-left input_mask">
                                <label class="control-label col-md-4 col-sm-4 col-xs-12" for="ASStart">Academic Session	
                                    <span class="required">*</span>
                               </label>
                                <div class="col-md-4 col-sm-4 col-xs-12 form-group has-feedback">
                                   <div class="col-md-6 xdisplay_inputx form-group has-feedback">
                                    <input type="text" maxlength="4"  runat="server" class="form-control has-feedback-center" id="inputAS1" required="required">
                                   </div>
                                </div>

                                <div class="col-md-4 col-sm-4 col-xs-12 form-group has-feedback">
                                    <div class="col-md-6 xdisplay_inputx form-group has-feedback">
                                     <input type="text" maxlength="4" runat="server"  class="form-control has-feedback-center" id="inputAS2" required="required" >
                                    </div>
                                </div>

                            <label class="control-label col-md-4 col-sm-4 col-xs-12" for="first-name">Academic Session	
                                    <span class="required">*</span>
                                    </label>
                                     <div class="col-md-4 col-sm-4 col-xs-12 form-group  has-feedback">
                                        <div class="control-group">
                                            <div class="controls">
                                                <div class="col-md-6 xdisplay_inputx form-group has-feedback">
                                                    <input type="text" runat="server" class="form-control has-feedback-center" id="single_cal3" aria-describedby="inputSuccess2Status3" >
                                                    <span class="fa fa-calendar-o form-control-feedback left" aria-hidden="true"></span>
                                                    <span id="inputSuccess2Status3" class="sr-only">(success)</span>
                                                </div>
                                            </div>
                                        </div>
                                      </div>
                                         <div class="col-md-4 col-sm-4 col-xs-12 form-group  has-feedback">
                                        <div class="control-group">
                                            <div class="controls">
                                                <div class="col-md-6 xdisplay_inputx form-group has-feedback">
                                                    <input type="text" runat="server" class="form-control has-feedback-center" id="single_cal4" aria-describedby="inputSuccess2Status4"  >
                                                    <span class="fa fa-calendar-o form-control-feedback left" aria-hidden="true"></span>
                                                    <span id="inputSuccess2Status4" class="sr-only">(success)</span>
                                                </div>
                                            </div>
                                        </div>
                                      </div>
                                </div>                         
                                 <div class="clearfix"></div>
                                <div class="ln_solid"></div>
                                <div class="form-group">
                                    <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3"> 
                                        <asp:Button id="btnNew" type="submit" runat="server" OnClientClick="return fNew()"  class="btn btn-primary" Text="New" />
                                        <asp:Button id="btnEdit" type="button" runat="server" OnClientClick="return fEdit()"  class="btn btn-primary" Text="Edit" />
                                        <asp:Button id="btnDelete" type="submit" runat="server" OnClientClick="return fValidateDelete()"  OnClick="btnDelete_Click" class="btn btn-primary" Text="Delete" />
                                        <asp:Button ID="btnSave" runat="server"  class="btn btn-primary" OnClick="btnSave_Click" Text="Save"/>
                                        <asp:Button ID="btnReset" runat="server"  class="btn btn-primary" OnClientClick="return fReset()" Text="Reset"/>
                                    </div>
                                </div>
                               
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="clearfix"></div>

                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <ul class="nav navbar-right panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                                <li><a class="foo bar" rel="nameClose"><i class="fa fa-close"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>

                        <div class="x_content">
                            <div class="table-responsive">
                                <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
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
    <script type="text/javascript">
        function addRowHandlers() {
           
    var table = document.getElementById("tableId");
    var rows = table.getElementsByTagName("tr");
    for (i = 0; i < rows.length; i++) {
        var currentRow = table.rows[i];
        var createClickHandler = 
            function(row) 
            {
                return function () {
                                        var cell = row.getElementsByTagName("td")[0];
                                        var titleText = cell.innerHTML;
                                        $('#main_inputAS1').val(row.getElementsByTagName("td")[0].cell.innerHTML);
                                        $('#main_inputAS2').val(row.getElementsByTagName("td")[1].cell.innerHTML);
                                        //$('#single_cal3').val(row.getElementsByTagName("td")[2].cell.innerHTML);
                                        //$('#single_cal4').val(row.getElementsByTagName("td")[3].cell.innerHTML);
                                        $('#main_hdnFlag').val(row.getElementsByTagName("td")[0].cell.innerHTML);
                                        $('#main_inputAS1').prop("disabled", true);
                                        $('#main_inputAS1').prop("disabled", true);
                                        //$('#single_cal3').prop("disabled", true);
                                        //$('#single_cal4').prop("disabled", true);
                                        $('#main_btnNew').attr('disabled', true);
                                        $('#main_btnEdit').attr('disabled', false);
                                        $('#main_btnSave').attr('disabled', true);
                                        //$('#main_btnDelete').attr('disabled', false);
                                        //if ($('#main_txtTitleName').val() == "") {
                                        //    $('btnReset').attr('disabled', false);
                                        //}
                                        //else {
                                        //    $('btnReset').attr('disabled', true);
                                        //}
                                };
            };

        currentRow.onclick = createClickHandler(currentRow);
    }
}
        function fControlStatus() {
            if ($('#main_txtTitleName').val() == "") {
                $('btnReset').attr('disabled', false);
            }
            else {
                $('btnReset').attr('disabled', true);
            }
            var hdnFlagValue = $('#main_hdnFlag').val();
            if (hdnFlagValue == "") {
                $('#main_btnNew').attr('disabled', false);
                $('#main_btnEdit').attr('disabled', true);
                $('#main_btnSave').attr('disabled', true);
                $('#main_btnDelete').attr('disabled', true);
                $('#main_txtTitleName').prop("disabled", true);
                $('#main_inputAS1').prop("disabled", true);
                $('#main_inputAS2').prop("disabled", true);
                //$('#single_cal3').prop("disabled", true);
                //$('#single_cal4').prop("disabled", true);
            }
            else {
                $('#main_btnEdit').attr('disabled', true);
                $('#main_btnNew').attr('disabled', true);
                $('#main_btnSave').attr('disabled', false);
                $('#main_btnDelete').attr('disabled', true);
                $('#main_txtTitleName').prop("disabled", true);
                $('#main_inputAS1').prop("disabled", true);
                $('#main_inputAS2').prop("disabled", true);
                //$('#single_cal3').prop("disabled", true);
                //$('#single_cal4').prop("disabled", true);
            }
        }
        function fNew()
        {
            $('#main_btnNew').attr('disabled', true);
            $('#main_btnEdit').attr('disabled', true);
            $('#main_btnSave').attr('disabled', false);
            $('#main_btnDelete').attr('disabled', true);
            $('#main_inputAS1').prop("disabled", false);
            $('#main_inputAS2').prop("disabled", false);
            //$('#single_cal3').prop("disabled", false);
            //$('#single_cal4').prop("disabled", false);
            $('#main_hdnFlag').val("N^");
            if ($('#main_txtTitleName').val()=="")
            {
                $('btnReset').attr('disabled', false);
            }
            else
            {
                $('btnReset').attr('disabled', true);
            }
            return false;
        }
        function fReset()
        {
            $('#main_txtTitleName').prop("disabled", true);
            $('#main_btnNew').attr('disabled', false);
            $('#main_btnEdit').attr('disabled', true);
            $('#main_btnSave').attr('disabled', true);
            $('#main_btnDelete').attr('disabled', true);
            $('#main_hdnFlag').val("");
            $('#main_inputAS1').focus();
            $('#main_inputAS1').val("");
            $('#main_inputAS2').val("");
            return false;
        }
        function fEdit()
        {
            $('#main_btnNew').attr('disabled', true);
            $('#main_btnEdit').attr('disabled', true);
            $('#main_btnSave').attr('disabled', false);
            $('#main_btnDelete').attr('disabled', true);
            $('#main_hdnFlag').val($('#main_hdnFlag').val() + "^E")
            $('#main_inputAS1').prop("disabled", false);
            $('#main_inputAS2').prop("disabled", false);
            //$('#single_cal3').prop("disabled", false);
            //$('#single_cal4').prop("disabled", false);
            $('#main_txtTitleName').focus();
            return false;
        }          
        window.onload = addRowHandlers();
        $(document).ready(function () {
            debugger;
            $("#main_inputAS1").keydown(function (event) {
                fNumberonly(event);
            });
            $("#main_inputAS2").keydown(function (event) {
                fNumberonly(event);
            });


            //$("#single_cal3").keydown(function (event) {
            //    $("#single_cal3").datepicker({
            //        inline: true,
            //        changeMonth: true,
            //        changeYear: true,
            //        minDate: -20,
            //        maxDate: "+1M +1D"
            //    });
            //});
            //$("#single_cal4").keydown(function (event) {
            //    $("#single_cal3").datepicker({
            //        inline: true,
            //        changeMonth: true,
            //        changeYear: true,
            //        minDate: -20,
            //        maxDate: "+1M +1D"
            //    });
            //});
             fControlStatus();
             $('a.foo.bar[rel="nameClose"]').click(function () {
                 fredirect();
            });        
        });   
</script>

</asp:Content>


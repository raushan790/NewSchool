<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TitleSetting.aspx.cs" Inherits="TitleSetting" %>

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
                    <h3>Tile Setting</h3>
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
                                <li><a class="foo bar" rel="123" href = "#"><i class="fa fa-close"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <br />
                            <div id="demo-form2" data-parsley-validate class="form-horizontal form-label-left">

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                        Title<span class="required">*</span>
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" maxlength="50" runat="server" id="txtTitleName" required="required" class="form-control col-md-7 col-xs-12">
                                    </div>
                                            <asp:HiddenField ID="hdnFlag" runat="server" />   
                                </div>
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
                       <%--           <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                                    <ul class="dropdown-menu" role="menu">
                                        <li><a href="#">Settings 1</a>
                                        </li>
                                        <li><a href="#">Settings 2</a>
                                        </li>
                                    </ul>
                                </li>--%>
                                <li><a class="foo bar" rel="123"><i class="fa fa-close"></i></a>
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
                    debugger;
                                        var cell = row.getElementsByTagName("td")[0];
                                        var titleText = cell.innerHTML;
                                        $('#main_txtTitleName').val(cell.innerHTML);
                                        $('#main_hdnFlag').val(cell.innerHTML);
                                        $('#main_txtTitleName').prop("disabled", true);
                                        $('#main_btnNew').attr('disabled', true);
                                        $('#main_btnEdit').attr('disabled', false);
                                        $('#main_btnSave').attr('disabled', true);
                                        $('#main_btnDelete').attr('disabled', false);
                                        if ($('#main_txtTitleName').val() == "") {
                                            $('btnReset').attr('disabled', false);
                                        }
                                        else {
                                            $('btnReset').attr('disabled', true);
                                        }
                                        //$('#main_hdnFlag').val("N^" + cell.innerHTML)
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
            }
            else {
                $('#main_btnEdit').attr('disabled', true);
                $('#main_btnNew').attr('disabled', true);
                $('#main_btnSave').attr('disabled', false);
                $('#main_btnDelete').attr('disabled', true);
                $('#main_txtTitleName').prop("disabled", true);
                $('#main_txtTitleName').focus();
            }
        }
        function fNew()
        {
            debugger;
            $('#main_btnNew').attr('disabled', true);
            $('#main_btnEdit').attr('disabled', true);
            $('#main_btnSave').attr('disabled', false);
            $('#main_btnDelete').attr('disabled', true);
            $('#main_txtTitleName').prop("disabled", false);
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
            debugger;
            $('#main_txtTitleName').prop("disabled", true);
            $('#main_btnNew').attr('disabled', false);
            $('#main_btnEdit').attr('disabled', true);
            $('#main_btnSave').attr('disabled', true);
            $('#main_btnDelete').attr('disabled', true);
            $('#main_hdnFlag').val("");
            $('#main_txtTitleName').val("");
            $('#main_txtTitleName').focus();
            return false;
        }
        function fEdit()
        {
            $('#main_txtTitleName').prop("disabled", false);
            $('#main_btnNew').attr('disabled', true);
            $('#main_btnEdit').attr('disabled', true);
            $('#main_btnSave').attr('disabled', false);
            $('#main_btnDelete').attr('disabled', true);
            $('#main_hdnFlag').val( $('#main_hdnFlag').val()+"^E")

            $('#main_txtTitleName').focus();
            return false;
        }
            
        function fValidate_On_Save()
        {                         
            var strArray=document.getElementById('hidFlag').value.split('^');
            if(stripBlanks(document.getElementById('txtTitleName1').value)=="")
            {
                pDisplayMessageclient("<%=Session["Type"].ToString() %>","7","" + document.getElementById('lblTitleName1').innerHTML);                
                document.getElementById('txtTitleName1').focus();
                return false;
            }
            if(strArray[0]=='E'&& strArray[2]==stripBlanks(document.getElementById('txtTitleName1').value))
            {
                pDisplayMessageclient("<%=Session["Type"].ToString() %>","4","");                
                document.getElementById('txtTitleName1').focus();
                return false;
            }      
        }
        function fValidateDelete()
        {
            if(confirm('Do you want to delete record.'))
            {
                return true;
            }
            else
            {
                return false;    
            }
        }
        window.onload = addRowHandlers();
        $(document).ready(function () {
            debugger;
            fControlStatus();
            $("#main_btnEdit").click(function () {
                $('#main_txtTitleName').prop("disabled", false);
            });
            $("#btnReset").click(function () {
                $('#main_hdnFlag').val("");
                $('#main_txtTitleName').val("");
            });
            $('a.foo.bar[rel="123"]').click(function () {
                //Do stuff when clicked
                window.location = "../TitleSetting.aspx";
            });        
        });
</script>

</asp:Content>


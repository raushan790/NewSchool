<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BoardSetting.aspx.cs" Inherits="BoardSetting" %>

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
                    <h3>Board Setting</h3>
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
                                <li><a class="foo bar" rel="lnkCloseCmd" href = "#"><i class="fa fa-close"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <br />
                            <div id="demo-form2" data-parsley-validate class="form-horizontal form-label-left">

                                <div class="form-group">
                                    <label id="lblBoardName" runat="server" class="control-label col-md-3 col-sm-3 col-xs-12" for="Class-name">
                                        Board
                                    </label><span class="required">*</span>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" maxlength="50" runat="server" id="txtBoard" required="required" class="form-control col-md-7 col-xs-12">
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
                                <li><a class="foo bar" rel="lnkCloseCmd"><i class="fa fa-close"></i></a>
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
                    $('#<%=txtBoard.ClientID%>').val(row.getElementsByTagName("td")[0].innerHTML);
                                        $('#<%=hdnFlag.ClientID%>').val(row.getElementsByTagName("td")[0].innerHTML);
                                        $('#<%=txtBoard.ClientID%>').prop("disabled", true);
                                        $('#<%=btnNew.ClientID%>').attr('disabled', true);
                                        $('#<%=btnEdit.ClientID%>').attr('disabled', false);
                                        $('#<%=btnSave.ClientID%>').attr('disabled', true);
                                        $('#<%=btnDelete.ClientID%>').attr('disabled', false);
                                        if ($('#<%=txtBoard.ClientID%>').val() == "") {
                                            $('#<%=btnReset.ClientID%>').attr('disabled', false);
                                        }
                                        else {
                                            $('#<%=btnReset.ClientID%>').attr('disabled', true);
                                        }
                                };
            };

        currentRow.onclick = createClickHandler(currentRow);
    }
}
        function fControlStatus() { 
            debugger;
            if ($('#<%=txtBoard.ClientID%>').val() == "") {
                $('#<%=btnReset.ClientID%>').attr('disabled', false);
            }
            else {
                $('#<%=btnReset.ClientID%>').attr('disabled', true);
            }
            var y = $('#<%=hdnFlag.ClientID%>').val();

            var hdnFlagValue = $('#<%=hdnFlag.ClientID%>').val();
            if (hdnFlagValue == "") {
                //$('#'<%=hdnFlag.ClientID%>'').attr('disabled', false);
                $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                $('#<%=btnSave.ClientID%>').attr('disabled', true);
                $('#<%=btnDelete.ClientID%>').attr('disabled', true);
                $('#<%=txtBoard.ClientID%>').prop("disabled", true);
            }
            else if($('#<%=hdnFlag.ClientID%>').val().split('^')[0])
            {
                $('#<%=txtBoard.ClientID%>').prop("disabled", false);
                $('#<%=btnNew.ClientID%>').attr('disabled', true);
                $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                $('#<%=btnSave.ClientID%>').attr('disabled', false);
                $('#<%=btnDelete.ClientID%>').attr('disabled', true);
                $('#<%=hdnFlag.ClientID%>').val("E^" + $('#<%=hdnFlag.ClientID%>').val())
                $('#<%=txtBoard.ClientID%>').focus();
                return false;
            }
            else {
                $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                $('#<%=btnNew.ClientID%>').attr('disabled', true);
                $('#<%=btnSave.ClientID%>').attr('disabled', false);
                $('#<%=btnDelete.ClientID%>').attr('disabled', true);
                $('#<%=txtBoard.ClientID%>').prop("disabled", true);
                $('#<%=txtBoard.ClientID%>').focus();
            }
        }
        function fNew()
        {
            debugger;
            $('#<%=btnNew.ClientID%>').attr('disabled', true);
            $('#<%=btnEdit.ClientID%>').attr('disabled', true);
            $('#<%=btnSave.ClientID%>').attr('disabled', false);
            $('#<%=btnDelete.ClientID%>').attr('disabled', true);
            $('#<%=txtBoard.ClientID%>').prop("disabled", false);
            $('#<%=hdnFlag.ClientID%>').val("N^");
            if ($('#<%=txtBoard.ClientID%>').val()=="")
            {
                $('#<%=btnReset.ClientID%>').attr('disabled', false);
            }
            else
            {
                $('#<%=btnReset.ClientID%>').attr('disabled', true);
            }
            return false;
        }
        function fReset()
        {
            $('#<%=txtBoard.ClientID%>').prop("disabled", true);
            $('#<%=btnNew.ClientID%>').attr('disabled', false);
            $('#<%=btnEdit.ClientID%>').attr('disabled', true);
            $('#<%=btnSave.ClientID%>').attr('disabled', true);
            $('#<%=btnDelete.ClientID%>').attr('disabled', true);
            $('#<%=hdnFlag.ClientID%>').val("");
            $('#<%=txtBoard.ClientID%>').val("");
            $('#<%=txtBoard.ClientID%>').focus();
            return false;
        }
        function fEdit()
        {
            $('#<%=txtBoard.ClientID%>').prop("disabled", false);
            $('#<%=btnNew.ClientID%>').attr('disabled', true);
            $('#<%=btnEdit.ClientID%>').attr('disabled', true);
            $('#<%=btnSave.ClientID%>').attr('disabled', false);
            $('#<%=btnDelete.ClientID%>').attr('disabled', true);
            $('#<%=hdnFlag.ClientID%>').val("E^"+$('#<%=hdnFlag.ClientID%>').val())
            $('#<%=txtBoard.ClientID%>').focus();
            return false;
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
            $('#<%=btnEdit.ClientID%>').click(function () {
                $('#<%=txtBoard.ClientID%>').prop("disabled", false);
            });
            $('#<%=btnReset.ClientID%>').click(function () {
                $('#<%=hdnFlag.ClientID%>').val("");
                $('#<%=txtBoard.ClientID%>').val("");
            });
            $('a.foo.bar[rel="lnkCloseCmd"]').click(function () {
                 fredirect();
            });        
        });
</script>

</asp:Content>


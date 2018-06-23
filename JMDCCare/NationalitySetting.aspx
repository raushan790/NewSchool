<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NationalitySetting.aspx.cs" Inherits="NationalitySetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="assets/vendors/select2/dist/css/select2.min.css" rel="stylesheet">
    <link href="assets/vendors/switchery/dist/switchery.min.css" rel="stylesheet">
    <link href="assets/vendors/starrr/dist/starrr.css" rel="stylesheet">



<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
    rel="stylesheet" type="text/css" />
<script type="text/javascript">
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <!-- page content -->
    <div id="dialog" style="display: none">
</div>

    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_right">
                    <h3>Nationality Setting</h3>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <ul class="nav navbar-right panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                                <li><a class="foo bar" rel="varRedirect" href="#"><i class="fa fa-close"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <br />
                            <div id="demo-form2" data-parsley-validate class="form-horizontal form-label-left">

                                <div class="form-group">
                                    <asp:Label id="lblNationalityName" runat="server" class="control-label col-md-3 col-sm-3 col-xs-12" for="Class-name">
                                          Nationality <span class="required">*</span>
                                    </asp:Label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" maxlength="50" runat="server" id="txtNationalityName" required="required" class="form-control col-md-7 col-xs-12">
                                    </div>
                                    <asp:HiddenField ID="hdnFlag" runat="server" />
                                </div>
                                <div class="ln_solid"></div>
                                <div class="form-group">
                                    <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                                        <asp:Button ID="btnNew" type="submit" runat="server"  class="btn btn-primary" Text="New" />
                                        <asp:Button ID="btnEdit" type="button" runat="server"  class="btn btn-primary" Text="Edit" />
                                        <asp:Button ID="btnDelete" type="submit" runat="server"  OnClick="btnDelete_Click" class="btn btn-primary" Text="Delete" />
                                        <asp:Button ID="btnSave" runat="server" class="btn btn-primary" OnClick="btnSave_Click" Text="Save" />
                                        <asp:Button ID="btnReset" runat="server" class="btn btn-primary" Text="Reset" />

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
                            <li><a class="foo bar" rel="varRedirect"><i class="fa fa-close"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>

                    <div class="x_content">
                        <div class="table-responsive">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /page content -->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="end" runat="Server">
    <script type="text/javascript">
        function addRowHandlers() {
            var table = document.getElementById("tableId");
            var rows = table.getElementsByTagName("tr");
            for (i = 0; i < rows.length; i++) {
                var currentRow = table.rows[i];
                var createClickHandler =
                    function (row) {
                        return function () {
                            var cell = row.getElementsByTagName("td")[1];
                            var titleText = cell.innerHTML;
                            $('#<%=txtNationalityName.ClientID%>').val(cell.innerHTML);
                            $('#<%=hdnFlag.ClientID%>').val(row.getElementsByTagName("td")[0].innerHTML+"^"+row.getElementsByTagName("td")[1].innerHTML);
                            $('#<%=txtNationalityName.ClientID%>').prop("disabled", true);
                            $('#<%=btnNew.ClientID%>').attr('disabled', true);
                            $('#<%=btnEdit.ClientID%>').attr('disabled', false);
                            $('#<%=btnSave.ClientID%>').attr('disabled', true);
                            $('#<%=btnDelete.ClientID%>').attr('disabled', false);
                        };
                    };
                currentRow.onclick = createClickHandler(currentRow);
            }
        }
        function fControlStatus() {
            var hdnFlagValue = $('#<%=hdnFlag.ClientID%>').val();
            if (hdnFlagValue == "") {
                $('#<%=btnNew.ClientID%>').attr('disabled', false);
                $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                $('#<%=btnSave.ClientID%>').attr('disabled', true);
                $('#<%=btnDelete.ClientID%>').attr('disabled', true);
                $('#<%=txtNationalityName.ClientID%>').prop("disabled", true);
            }
            else {
                $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                $('#<%=btnNew.ClientID%>').attr('disabled', true);
                $('#<%=btnSave.ClientID%>').attr('disabled', false);
                $('#<%=btnDelete.ClientID%>').attr('disabled', true);
                $('#<%=txtNationalityName.ClientID%>').prop("disabled", true);
                $('#<%=txtNationalityName.ClientID%>').focus();
            }
        }
        window.onload = addRowHandlers();
        $(document).ready(function () {
            debugger;
            $('td:nth-child(1),th:nth-child(1)').hide();
            fControlStatus();
            $('#<%=btnEdit.ClientID%>').click(function () {
                        $('#<%=txtNationalityName.ClientID%>').prop("disabled", false);
                        $('#<%=btnNew.ClientID%>').attr('disabled', true);
                        $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                        $('#<%=btnSave.ClientID%>').attr('disabled', false);
                        $('#<%=btnDelete.ClientID%>').attr('disabled', true);
                        $('#<%=hdnFlag.ClientID%>').val("E^"+$('#<%=hdnFlag.ClientID%>').val())
                        $('#<%=txtNationalityName.ClientID%>').focus();
            return false;
            });
            $('#<%=btnNew.ClientID%>').click(function () {
                    $('#<%=btnNew.ClientID%>').attr('disabled', true);
                    $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                    $('#<%=btnSave.ClientID%>').attr('disabled', false);
                    $('#<%=btnDelete.ClientID%>').attr('disabled', true);
                    $('#<%=txtNationalityName.ClientID%>').prop("disabled", false);
                    $('#<%=hdnFlag.ClientID%>').val("N^");
            });
            $('#<%=btnDelete.ClientID%>').click(function () {
            if (confirm('Do you want to delete record.')) {
                return true;
            }
            else {
                return false;
                }
            });

            $('#<%=btnReset.ClientID%>').click(function () {
                    $('#<%=txtNationalityName.ClientID%>').prop("disabled", true);
                    $('#<%=btnNew.ClientID%>').attr('disabled', false);
                    $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                    $('#<%=btnSave.ClientID%>').attr('disabled', true);
                    $('#<%=btnDelete.ClientID%>').attr('disabled', true);
                    $('#<%=hdnFlag.ClientID%>').val("");
                    $('#<%=txtNationalityName.ClientID%>').val("");
                    $('#<%=txtNationalityName.ClientID%>').focus();
                    return false;
            });
            $('a.foo.bar[rel="varRedirect"]').click(function () {
                 fredirect();
            });
        });
    </script>

</asp:Content>

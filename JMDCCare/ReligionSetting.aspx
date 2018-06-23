﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReligionSetting.aspx.cs" Inherits="ReligionSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="assets/vendors/select2/dist/css/select2.min.css" rel="stylesheet">
    <!-- Switchery -->
    <link href="assets/vendors/switchery/dist/switchery.min.css" rel="stylesheet">
    <!-- starrr -->
    <link href="assets/vendors/starrr/dist/starrr.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <!-- page content -->
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_right">
                    <h3>Religion Setting</h3>
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
                                    <label id="lblReligion" runat="server" class="control-label col-md-3 col-sm-3 col-xs-12" for="Class-name">
                                        Religion <span class="required">*</span>
                                    </label>
                                     <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" maxlength="50" runat="server" id="txtReligion" required="required" class="form-control col-md-7 col-xs-12">
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
                            <%--           <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                                    <ul class="dropdown-menu" role="menu">
                                        <li><a href="#">Settings 1</a>
                                        </li>
                                        <li><a href="#">Settings 2</a>
                                        </li>
                                    </ul>
                                </li>--%>
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
                            $('#<%=txtReligion.ClientID%>').val(cell.innerHTML);
                            $('#<%=hdnFlag.ClientID%>').val(row.getElementsByTagName("td")[0].innerHTML+"^"+row.getElementsByTagName("td")[1].innerHTML);
                            $('#<%=txtReligion.ClientID%>').prop("disabled", true);
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
                $('#<%=txtReligion.ClientID%>').prop("disabled", true);
            }
            else {
                $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                $('#<%=btnNew.ClientID%>').attr('disabled', true);
                $('#<%=btnSave.ClientID%>').attr('disabled', false);
                $('#<%=btnDelete.ClientID%>').attr('disabled', true);
                $('#<%=txtReligion.ClientID%>').prop("disabled", true);
                $('#<%=txtReligion.ClientID%>').focus();
            }
        }
        window.onload = addRowHandlers();
        $(document).ready(function () {
            $('td:nth-child(1),th:nth-child(1)').hide();
            fControlStatus();
            $('#<%=btnEdit.ClientID%>').click(function () {
                        $('#<%=txtReligion.ClientID%>').prop("disabled", false);
                        $('#<%=btnNew.ClientID%>').attr('disabled', true);
                        $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                        $('#<%=btnSave.ClientID%>').attr('disabled', false);
                        $('#<%=btnDelete.ClientID%>').attr('disabled', true);
                        $('#<%=hdnFlag.ClientID%>').val("E^"+$('#<%=hdnFlag.ClientID%>').val())
                        $('#<%=txtReligion.ClientID%>').focus();
            return false;
            });
            $('#<%=btnNew.ClientID%>').click(function () {
                    $('#<%=btnNew.ClientID%>').attr('disabled', true);
                    $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                    $('#<%=btnSave.ClientID%>').attr('disabled', false);
                    $('#<%=btnDelete.ClientID%>').attr('disabled', true);
                    $('#<%=txtReligion.ClientID%>').prop("disabled", false);
                    $('#<%=hdnFlag.ClientID%>').val("N^");
                    $('#<%=txtReligion.ClientID%>').focus();

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
                    $('#<%=txtReligion.ClientID%>').prop("disabled", true);
                    $('#<%=btnNew.ClientID%>').attr('disabled', false);
                    $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                    $('#<%=btnSave.ClientID%>').attr('disabled', true);
                    $('#<%=btnDelete.ClientID%>').attr('disabled', true);
                    $('#<%=hdnFlag.ClientID%>').val("");
                    $('#<%=txtReligion.ClientID%>').val("");
                    $('#<%=txtReligion.ClientID%>').focus();
                    return false;
            });
            $('a.foo.bar[rel="varRedirect"]').click(function () {
                 fredirect();
            });
        });
    </script>
</asp:Content>

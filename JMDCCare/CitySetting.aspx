<%@ Page Title="" Language="C#" EnableEventValidation="false"   MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CitySetting.aspx.cs" Inherits="CitySetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="assets/vendors/select2/dist/css/select2.min.css" rel="stylesheet">
    <link href="assets/vendors/switchery/dist/switchery.min.css" rel="stylesheet">
    <link href="assets/vendors/starrr/dist/starrr.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
        <div id="myModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                       <div class="modal-header">
                            <ul class="nav navbar-right panel_toolbox" style="min-width:23px !important;">
                                <li><a class="foo bar" rel="nameClose" href = '<%=ResolveUrl("~/City") %>'><i class="fa fa-close"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                <div class="modal-body">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
               </div>
                <div class="modal-footer">
                    <button id="btnpopupCose" type="button" class="btn btn-default" data-dismiss="modal">
                        Close</button>
               </div>
            </div>
        </div>
       </div>
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_right">
                    <h3>City Setting</h3>
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
                                   <asp:Label id="lblCity" runat="server" class="control-label col-md-3 col-sm-3 col-xs-12" for="Class-name">
                                         State <span class="required">*</span>
                                    </asp:Label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <input type="text" maxlength="50" runat="server" id="txtCity" required="required" class="form-control col-md-7 col-xs-12">
                                    </div>
                                    <asp:HiddenField ID="hdnFlag" runat="server" />
                                </div>
                                 <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">State</label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:DropDownList ID="ddlState" runat="server"  class="select2_group form-control" AutoPostBack="false" ></asp:DropDownList>
                                    </div>
                                     <input type="hidden" id="hdnCountry" runat="server" />
                                </div>
                                 <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Country</label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:DropDownList ID="ddlCountry" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                    </div>
                                     <input type="hidden" id="hdnddlVal" runat="server" />
                                </div>

                                <div class="ln_solid"></div>
                                <div class="form-group">
                                    <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-4">
                                        <asp:Button ID="btnNew" type="submit" runat="server"  class="btn btn-primary" Text="New" />
                                        <asp:Button ID="btnEdit" type="button" runat="server"  class="btn btn-primary" Text="Edit" />
                                        <asp:Button ID="btnDelete" type="submit" runat="server"  class="btn btn-primary" OnClick="btnDelete_Click" Text="Delete" /> 
                                        <asp:Button ID="btnSave" runat="server" class="btn btn-primary"  Text="Save" OnClick="btnSave_Click" /> 
                                        <asp:Button ID="btnReset" runat="server" class="btn btn-primary" Text="Reset" />

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="clearfix"></div>
              <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_content">
                            <div class="table-responsive">
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
              </div>
              <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="end" runat="Server">
    <script src="assets/vendors/bootstrap-wysiwyg/js/bootstrap-wysiwyg.min.js"></script>
    <script src="assets/vendors/jquery.hotkeys/jquery.hotkeys.js"></script>
    <script src="assets/vendors/google-code-prettify/src/prettify.js"></script>
    <script src="assets/vendors/jquery.tagsinput/src/jquery.tagsinput.js"></script>
    <script src="assets/vendors/switchery/dist/switchery.min.js"></script>
    <script src="assets/vendors/select2/dist/js/select2.full.min.js"></script>
    <script src="assets/vendors/parsleyjs/dist/parsley.min.js"></script>
    <script src="assets/vendors/autosize/dist/autosize.min.js"></script>
    <script src="assets/vendors/devbridge-autocomplete/dist/jquery.autocomplete.min.js"></script>
    <script src="assets/vendors/starrr/dist/starrr.js"></script>

<script type="text/javascript">
          $("#btnpopupCose").click(function () {
            window.location.href = '<%=ResolveUrl("~/City") %>';
        });

function ShowPopup() {
            $("#myModal").modal('show');            
        }
function fcahange() {
    $.ajax({
        type: "POST",
        url: "CitySetting.aspx/GetCountry",
        data: '{stateid: '+$('#<%=hdnddlVal.ClientID%>').val()+'}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            var ddlCustomers = $("[id*=ddlCountry]");
            $.each(r.d, function () {
                ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                $('#<%=hdnCountry.ClientID%>').val($(this['Value']));
                $('#<%=ddlCountry.ClientID%>').prop('disabled', true);
            });
        }
    });
}
        function addRowHandlers() {
            var table = document.getElementById("tableId");
            var rows = table.getElementsByTagName("tr");
            for (i = 0; i < rows.length; i++) {
                var currentRow = table.rows[i];
                var createClickHandler =
                    function (row) {
                        return function () {
                            debugger;
                            var cell = row.getElementsByTagName("td")[2];
                            var titleText = cell.innerHTML;
                            $('#<%=txtCity.ClientID%>').val(cell.innerHTML);
                            $('#<%=ddlState.ClientID%>').val(row.getElementsByTagName("td")[3].innerHTML);
                            $('#<%=hdnddlVal.ClientID%>').val(row.getElementsByTagName("td")[3].innerHTML);
                            fcahange();
                            //$('#<%=ddlCountry.ClientID%>').val(row.getElementsByTagName("td")[2].innerHTML);
                            $('#<%=hdnFlag.ClientID%>').val(row.getElementsByTagName("td")[0].innerHTML+"^"+row.getElementsByTagName("td")[1].innerHTML+"^"+row.getElementsByTagName("td")[2].innerHTML+"^"+row.getElementsByTagName("td")[3].innerHTML);
                            $('#<%=txtCity.ClientID%>').prop("disabled", true);
                            $('#<%=btnNew.ClientID%>').attr('disabled', true);
                            $('#<%=btnEdit.ClientID%>').attr('disabled', false);
                            $('#<%=btnSave.ClientID%>').attr('disabled', true);
                            $('#<%=btnDelete.ClientID%>').attr('disabled', false);
                            $('#<%=ddlCountry.ClientID%>').prop('disabled', true);
                            $('#<%=ddlState.ClientID%>').prop('disabled', true);
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
                $('#<%=txtCity.ClientID%>').prop("disabled", true);
                $('#<%=ddlCountry.ClientID%>').prop('disabled', true);
                $('#<%=ddlState.ClientID%>').prop('disabled', true);
            }
           else if (hdnFlagValue.split('^')[0] == "E" && hdnFlagValue.split('^')[0] != "N") {
                $('#<%=btnNew.ClientID%>').attr('disabled', true);
                $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                $('#<%=btnSave.ClientID%>').attr('disabled', false);
                $('#<%=btnDelete.ClientID%>').attr('disabled', false);
                $('#<%=txtCity.ClientID%>').prop("disabled", false);
                $('#<%=ddlCountry.ClientID%>').prop('disabled', false);
                $('#<%=ddlState.ClientID%>').prop('disabled', false);
                $('#<%=txtCity.ClientID%>').focus();
            }
           else if (hdnFlagValue.split('^')[0] == "N") {
                $('#<%=btnNew.ClientID%>').attr('disabled', true);
                $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                $('#<%=btnSave.ClientID%>').attr('disabled', false);
                $('#<%=btnDelete.ClientID%>').attr('disabled', true);
                $('#<%=txtCity.ClientID%>').prop("disabled", false);
                $('#<%=ddlCountry.ClientID%>').prop('disabled', false);
                $('#<%=ddlState.ClientID%>').prop('disabled', false);
                $('#<%=txtCity.ClientID%>').focus();
            }
            else {
                $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                $('#<%=btnNew.ClientID%>').attr('disabled', true);
                $('#<%=btnSave.ClientID%>').attr('disabled', false);
                $('#<%=btnDelete.ClientID%>').attr('disabled', true);
                $('#<%=txtCity.ClientID%>').prop("disabled", true);
                $('#<%=ddlCountry.ClientID%>').prop('disabled', true);
                $('#<%=ddlState.ClientID%>').prop('disabled', true);
                $('#<%=txtCity.ClientID%>').focus();
            }
        }
    window.onload = addRowHandlers();
    $(document).ready(function () {
            //$('td:nth-child(2),th:nth-child(1)').hide();
            //$('td:nth-child(3),th:nth-child(3)').hide();
            fControlStatus();
              $('#<%=ddlState.ClientID%>').change(function(){
                  var value = $("#<%=ddlState.ClientID%> option:selected").val();
                  $('#<%=hdnddlVal.ClientID%>').val(value);
              });
                $('#<%=ddlState.ClientID%>').change(function (e) {
                  fcahange();
                });
            $('#<%=btnEdit.ClientID%>').click(function () {
                        $('#<%=txtCity.ClientID%>').prop("disabled", false);
                        $('#<%=btnNew.ClientID%>').attr('disabled', true);
                        $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                        $('#<%=btnSave.ClientID%>').attr('disabled', false);
                        $('#<%=ddlCountry.ClientID%>').prop('disabled', false);
                        $('#<%=ddlState.ClientID%>').prop('disabled', false);
                        $('#<%=btnDelete.ClientID%>').attr('disabled', true);
                        $('#<%=hdnFlag.ClientID%>').val("E^"+$('#<%=hdnFlag.ClientID%>').val())
                        $('#<%=txtCity.ClientID%>').focus();
                        return false;
            });
            $('#<%=btnNew.ClientID%>').click(function () {
                    $('#<%=btnNew.ClientID%>').attr('disabled', true);
                    $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                    $('#<%=btnSave.ClientID%>').attr('disabled', false);
                    $('#<%=btnDelete.ClientID%>').attr('disabled', true);
                    $('#<%=txtCity.ClientID%>').prop("disabled", false);
                    $('#<%=ddlCountry.ClientID%>').prop('disabled', false);
                    $('#<%=ddlState.ClientID%>').prop('disabled', false);
                    $('#<%=ddlCountry.ClientID%>').prop('disabled', true);
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
                $('#<%=txtCity.ClientID%>').prop("disabled", true);
                    $('#<%=ddlCountry.ClientID%>').prop('disabled', true);
                    $('#<%=btnNew.ClientID%>').attr('disabled', false);
                    $('#<%=btnEdit.ClientID%>').attr('disabled', true);
                    $('#<%=btnSave.ClientID%>').attr('disabled', true);
                    $('#<%=btnDelete.ClientID%>').attr('disabled', true);
                    $('#<%=hdnFlag.ClientID%>').val("");
                    $('#<%=txtCity.ClientID%>').val("");
                    $('#<%=txtCity.ClientID%>').focus();
                    return false;
            });
            $('a.foo.bar[rel="varRedirect"]').click(function () {
                 fredirect();
            });
        });
    </script>
</asp:Content>






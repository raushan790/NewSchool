<%@ Page Title="" Language="C#" MasterPageFile="~/bankMaster.master" AutoEventWireup="true" CodeFile="Student.aspx.cs" Inherits="Student" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="assets/vendors/select2/dist/css/select2.min.css" rel="stylesheet">
    <link href="assets/vendors/switchery/dist/switchery.min.css" rel="stylesheet">
    <link href="assets/vendors/starrr/dist/starrr.css" rel="stylesheet">
    <script src="assets/js/StandardValidation.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
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
<%--        <div class="">--%>
            <div class="page-title">
                <div class="title_right">
                    <h3>Student Information</h3>
                </div>
            </div>
            <div class="clearfix"></div>
                    <div class="col-md-12 col-sm-12 col-xs-12">
                  <div class="x_panel">                       
                    <div class="x_content"> 
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="x_panel">
                       <div class="x_title">
                            <ul class="nav navbar-right panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                                <li><a class="foo bar" rel="nameClose" href="../Debit"><i class="fa fa-close"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">                                
                            <div class="col-md-9 col-sm-9 col-xs-12">
                                 <div class="form-horizontal form-label-left">
                                    <div class="form-group">
                                        <label ID="lblStuSelect" runat="server" class="control-label col-md-2 col-sm-2 col-xs-12">Student</label>
                                           <div class="col-md-10 col-sm-10 col-xs-12 form-group">
                                                 <asp:TextBox ID="txtStuSelect" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
<%--                                           <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="1000"
            EnableCaching="false" MinimumPrefixLength="2" ServiceMethod="GetCompletionList"  UseContextKey = "true" FirstRowSelected = "false"
            ServicePath="WSStudentSearch.asmx" TargetControlID="txtStuSelect" CompletionListElementID="divAutoComplete" >
        </cc1:AutoCompleteExtender>--%>
                                        <cc1:AutoCompleteExtender ServiceMethod="GetCompletionList" MinimumPrefixLength="2" 
    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" ServicePath="WSStudentSearch.asmx"  
    TargetControlID="txtStuSelect" UseContextKey = "true"
    ID="AutoCompleteExtender1" runat="server" FirstRowSelected = "false">
</cc1:AutoCompleteExtender>


                                          <div id="divAutoComplete" style="visibility: visible !important; display:block !important;" >
        </div>
                                            <asp:HiddenField ID="hfCustomerId" runat="server" />
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
                                     </div>                               
                                    <div class="form-group">
                                         <label  ID="lblAdmissionNo" runat="server"  class="control-label col-md-2 col-sm-2 col-xs-12">Adm.No. <span class="required" style="color: #ff0000">*</span></label>
                                        <div class="col-md-2 col-sm-2 col-xs-12 form-group">
                                         <asp:TextBox ID="txtAdmNo" runat="server"  MaxLength="30"  class="form-control"></asp:TextBox>
                                        </div>
                                         <label  ID="lblFeeNo" runat="server"  class="control-label col-md-2 col-sm-2 col-xs-12">  Fee No.<span class="required" style="color: #ff0000">*</span></label>
                                         <div class="col-md-2 col-sm-2 col-xs-12 form-group">
                                             <asp:TextBox ID="txtFeeNo" runat="server"  MaxLength="30" class="form-control"></asp:TextBox>
                                         </div>                       
                                         <label  ID="lblParentID" runat="server"  class="control-label col-md-2 col-sm-2 col-xs-12"> Parent ID</label>
                                        <div class="col-md-2 col-sm-2 col-xs-12 form-group">
                                        <asp:TextBox ID="txtParentID" runat="server" ToolTip="EnterFather Name or ParentID" class="form-control"></asp:TextBox>
                                   </div>
                                    </div>
                                    <div class="form-group">
                                          <label  ID="lblName" runat="server"  class="control-label col-md-2 col-sm-2 col-xs-12">Name<span class="required" style="color: #ff0000">*</span></label>
                                         <div class="col-md-4 col-sm-4 col-xs-12 form-group">
                                                 <asp:TextBox ID="txtFirstName" placeholder="First Name" runat="server" class="form-control"></asp:TextBox>
                                         </div>
                                         <div class="col-md-3 col-sm-3 col-xs-12 form-group">
                                                 <asp:TextBox ID="txtMiddleName" runat="server" placeholder="Middle Name" class="form-control"></asp:TextBox>
                                         </div>
                                         <div class="col-md-3 col-sm-3 col-xs-12 form-group">
                                                 <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name" class="form-control"></asp:TextBox>
                                         </div>
                                     </div>
                                    <div class="form-group">
                                            <label  ID="lblFName" runat="server"  class="control-label col-md-2 col-sm-2 col-xs-12">Father's&nbsp;Name</label>
                                            <div class="col-md-2 col-sm-2 col-xs-12 form-group"> 
                                                <asp:DropDownList ID="ddlFTitle" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                             </div>
                                            <div class="col-md-8 col-sm-8 col-xs-12 form-group">
                                                <asp:TextBox ID="txtFName" runat="server"  MaxLength="100"  class="form-control"></asp:TextBox>
                                             </div>
                                    </div>
                                    <div class="form-group">
                                            <label  ID="lblMName" runat="server"  class="control-label col-md-2 col-sm-2 col-xs-12"> Mother's&nbsp;Name</label>
                                            <div class="col-md-2 col-sm-2 col-xs-12 form-group"> 
                                                <asp:DropDownList ID="ddlMTitle" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                              </div>
                                             <div class="col-md-8 col-sm-8 col-xs-12 form-group">
                                                <asp:TextBox ID="txtMName" runat="server"  MaxLength="100"  class="form-control"></asp:TextBox>
                                            </div>
                                    </div>   
                                    <div class="form-group">
                                            <label  ID="lblClass" runat="server"  class="control-label col-md-2 col-sm-2 col-xs-12"> Class<span class="required" style="color: #ff0000">*</span></label>
                                            <div class="col-md-2 col-sm-2 col-xs-12 form-group">
                                                <asp:DropDownList ID="ddlClass" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                            </div>
                                            <label  ID="lblSection" runat="server"  class="control-label col-md-2 col-sm-2 col-xs-12">Section<span class="required" style="color: #ff0000">*</span></label>
                                            <div class="col-md-2 col-sm-2 col-xs-12 form-group"> 
                                                <asp:DropDownList ID="ddlSection" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                            </div>                       
                                            <label  ID="lblRollNo" runat="server"  class="control-label col-md-2 col-sm-2 col-xs-12">Roll No</label>
                                            <div class="col-md-2 col-sm-2 col-xs-12 form-group">
                                          <asp:TextBox ID="txtRollNo" runat="server" MaxLength="3" class="form-control"></asp:TextBox>
                                         </div>
                                       </div>
                                    <div class="form-group">
                                        <label  ID="lblStuDOB" runat="server"  class="control-label col-md-2 col-sm-2 col-xs-12">Date&nbsp;of&nbsp;Birth<span class="required" style="color: #ff0000">*</span></label>
                                        <div class="col-md-2 col-sm-2 col-xs-12 form-group"> 
<%--                                            <input type="text" class="form-control has-feedback-center"  style="padding-left: 0px; padding-right:0px !important;" id="single_cal3" aria-describedby="inputSuccess2Status3" required="required" >
                                            <input type="hidden" runat="server" id="txtStuDOB" value="" />--%>
                                           <div class="col-md-14 xdisplay_inputx form-group has-feedback" style="padding-left: 0px;">
                                            <input type="text"  class="form-control has-feedback-center" id="single_cal3" style="padding-left: 0px; padding-right:0px !important;" aria-describedby="inputSuccess2Status3" required="required" >
<%--                                            <span class="fa fa-calendar-o form-control-feedback left" aria-hidden="true"></span>
                                            <span id="inputSuccess2Status3" class="sr-only">(success)</span>--%>
                                              <input type="hidden" ID="txtStuDOB" runat="server" />
                                        </div>
                                            
                                        </div>

                                        <label  ID="lblAdmittedClass" runat="server"  class="control-label col-md-2 col-sm-2 col-xs-12">
                                              Admitted&nbsp;Class
                                          </label>
                                        <div class="col-md-2 col-sm-2 col-xs-12 form-group"> 
                                        <asp:DropDownList ID="ddlAdmittedClass" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                    </div>   
                                  
                                       <label  ID="lblGender" runat="server"  class="control-label col-md-2 col-sm-2 col-xs-12">Gender
                                           <span class="required" style="color: #ff0000">*</span>
                                      </label>
                                       <div class="col-md-2 col-sm-2 col-xs-12 form-group" >
                                            <p >B:              
                                            <input type="radio"  runat="server"  class="flat" name="Gender" id="rbtnMale" value="M" checked="" required />
<%--                                               <asp:RadioButton id="rbtnMale" runat="server" class="flat" name="Gender" value="M"/>--%>

                                                G:                       
                                            <input type="radio"  runat="server"  class="flat" name="Gender" id="rbtnFeMale" value="F" />
<%--                                                 <asp:RadioButton id="rbtnFeMale" runat="server" class="flat" name="Gender" value="F"/>--%>

                                             </p>      

                                       </div>
                                  </div>
                                  <div class="form-group">
                                    <label  ID="Label3" runat="server" class="control-label col-md-2 col-sm-2 col-xs-12">Lang.&nbsp;Known </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                         <asp:Panel ID="pnlLanguageKnown" runat="server"  ScrollBars="Vertical">
		                                    <div class="checkbox checkboxlist col-sm-9">
			                                    <asp:CheckBoxList ID="chkLanguageKnown" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow">
			                                    </asp:CheckBoxList>
		                                    </div>
	                                  </asp:Panel>
                                    </div>
                            <%--    </div>

                                 <div class="form-group">--%>
                                        <label ID="lblAdmission" runat="server"  class="control-label col-md-2 col-sm-2 col-xs-12">Admission</label>
                                        <div class="col-md-2 col-sm-2 col-xs-12 form-group">
                                            <p  style="padding-top: 7px;">N:             
                                            <input type="radio" runat="server" class="flat" name="Admission" id="rbtnAdmissionNew" value="N" checked="" required />
                                            O:                       
                                            <input type="radio"  runat="server" class="flat" name="Admission" id="rbtnAdmissionOld" value="O" />
                                             </p>                       

                                </div>
                                 </div>
                                </div>                         
                             </div>
                            <div class="col-md-3 col-sm-3 col-xs-12 profile_left">

                                <div class="profile_img">
                                         <div id="crop-avatar">
                                        <!-- Current avatar -->
                                        <asp:Image  ID="imgStudent" runat="server" class="img-responsive avatar-view"  
                                            alt="Avatar" title="StudentPhoto"  OnClientClick="javascript:return false;" />
                                    </div>
                                </div>
                                <br />
                                 <asp:FileUpload ID="flImage" ToolTip="Upload Photo" runat="server" style="color: transparent; direction: ltr;"  />
                                <br />
                                     <asp:Label ID="lblRes" runat="server" Text=" "></asp:Label>
                                 <br />
                                <asp:Button ID="btnUpload" runat="server" Text="Upload File" OnClick = "Upload"  />
                                   
                            </div>
                            </div> 
                        </div>
                        </div>
                    </div>
<%--         </div>--%>
            <div class="row">
                <div class="col-md-6 col-xs-12">
                    <div class="x_panel">
                          <div class="x_content">
                            <br>
                            <div class="form-horizontal form-label-left">

                                <div class="form-group">
                                        <label  ID="lblDateOfAdmission" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Date&nbsp;of&nbsp;Admission</label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <div class="col-md-14 xdisplay_inputx form-group has-feedback" style="padding-left: 0px;">
                                            <input type="text"  class="form-control has-feedback-center" id="single_cal1" aria-describedby="inputSuccess2Status1" required="required" >
                                            <span class="fa fa-calendar-o form-control-feedback left" aria-hidden="true"></span>
                                            <span id="inputSuccess2Status1" class="sr-only">(success)</span>
                                              <input type="hidden" ID="txtDOA" runat="server" />
                                        </div>
                                    </div> 
                                </div>
                                <div class="form-group">
                                    <label ID="Label2" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Fee Group<span class="required" style="color: #ff0000">*</span></label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                      <asp:DropDownList ID="ddlFeeGroup" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label ID="lblReligion" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Religion</label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                      <asp:DropDownList ID="ddlReligion" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                        <label ID="lblHouse" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">House</label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                          <asp:DropDownList ID="ddlHouse" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                        </div>
                                 </div>
                                <div class="form-group">
                                        <label ID="lblMotherTongue" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Mother&nbsp;Tongue</label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                          <asp:DropDownList ID="ddlMotherTongue" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                        </div>
                                 </div>
                                <div class="form-group">
                                        <label ID="lblNationality" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Nationality</label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                          <asp:DropDownList ID="ddlNationality" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                        </div>
                                 </div>
                                <div class="form-group">
                                        <label ID="lblBoardingCategory" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Boarding&nbsp;Categ.</label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                          <asp:DropDownList ID="ddlBoardingCategory" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                        </div>
                                 </div>
                                <div class="form-group">
                                        <label ID="lblBoard" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Board</label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                          <asp:DropDownList ID="ddlBoard" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                        </div>
                                 </div>
                         

                                <div class="form-group">
                                        <label ID="lblSchoolBus" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">School Bus</label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                          <asp:DropDownList ID="ddlSchoolBus" runat="server"  class="select2_group form-control" >
                                                    <asp:ListItem Value=" "></asp:ListItem>
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                          </asp:DropDownList>
                                        </div>
                                 </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-6 col-xs-12">
                    <div class="x_panel">
                          <div class="x_content">
                            <br>
                            <div class="form-horizontal form-label-left">

                                <div class="form-group">
                                        <label  ID="Label1" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Date&nbsp;of&nbsp;Join</label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <div class="col-md-14 xdisplay_inputx form-group has-feedback" style="padding-left: 0px;">
                                            <input type="text"  class="form-control has-feedback-center" id="single_cal2" aria-describedby="inputSuccess2Status2" required="required" >
                                            <span class="fa fa-calendar-o form-control-feedback left" aria-hidden="true"></span>
                                            <span id="inputSuccess2Status2" class="sr-only">(success)</span>
                                            <input type="hidden" ID="txtDateOFJoin" runat="server" />
                                        </div>
                                    </div> 
                                </div>
                                <div class="form-group">
                                    <label ID="lblFeeApplnFrom" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Fee&nbsp;Appl.&nbsp;From</label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                      <asp:DropDownList ID="ddlFeeApplnFrom" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label ID="lblSocCategory" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Social&nbsp;Category</label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                      <asp:DropDownList ID="ddlSocCategory" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label  ID="lblStuEmail" runat="server" class="control-label col-md-3 col-sm-3 col-xs-12">
                                       E-Mail
                                    </label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                        <asp:TextBox ID="txtStuEmail" runat="server" class="form-control" Style="text-transform: lowercase"></asp:TextBox>
                                    </div>
                                </div>                               
                                <div class="form-group">
                                    <label ID="lblStuLivingWith" runat="server" class="col-md-3 col-sm-3 col-xs-12 control-label">
                                       Living&nbsp;With
                                    </label>

                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                        <asp:DropDownList ID="ddlStuLiving" runat="server" class="select2_group form-control" >
                                              <asp:ListItem Value="0"></asp:ListItem>
                                                <asp:ListItem Value="4">Parent</asp:ListItem>
                                                <asp:ListItem Value="1">Father</asp:ListItem>
                                                <asp:ListItem Value="2">Mother</asp:ListItem>
                                                <asp:ListItem Value="3">Local Gaurdian</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label  ID="lblConcession" runat="server"  class="col-md-3 col-sm-3 col-xs-12 control-label">
                                         Concession&nbsp;Type</label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                        <asp:DropDownList ID="ddlConcessionType" runat="server" class="select2_group form-control" >
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label  ID="lblBloodGroup" runat="server"  class="col-md-3 col-sm-3 col-xs-12 control-label">
                                         Blood&nbsp;Group</label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                        <asp:DropDownList ID="ddlBloodGroup" runat="server" class="select2_group form-control" >
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label ID="lblBoardRegNo" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Board&nbsp;Reg.&nbsp;No.</label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                        <asp:TextBox ID="txtBoardRegNo" MaxLength="20" runat="server" class="form-control" Style="text-transform: lowercase"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label ID="lblCBSERollNo" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Board&nbsp;Roll&nbsp;No.</label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                        <asp:TextBox ID="txtCBSERollNo" MaxLength="50" runat="server" class="form-control" Style="text-transform: lowercase"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


        <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                  <div class="x_panel">                       
                    <div class="x_content">   
                            <div class="col-md-6 col-xs-12">
<%--                            <div class="x_panel">--%>
                                  <div class="x_content">
                                     <div class="alert alert-success alert-dismissible fade in" style="text-align: center;" >
                                       <strong>Residence Address</strong>                 
                                    </div>
                                    <div class="form-horizontal form-label-left">
                                        <div class="form-group">
                                            <label ID="lblRAddress" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Address</label>
                                            <div class="col-md-9 col-sm-9 col-xs-12">
                                               <textarea id="txtPresAddress" runat="server" class="form-control" name="message" data-parsley-trigger="keyup" data-parsley-maxlength="150"></textarea>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                                <label ID="lblRCity" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">City/District</label>
                                                <div class="col-md-9 col-sm-9 col-xs-12">
                                                  <asp:DropDownList ID="ddlRCity" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                                </div>
                                         </div>
                                        <div class="form-group">
                                                <label ID="Label8" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">State</label>
                                                <div class="col-md-9 col-sm-9 col-xs-12">
                                                  <asp:DropDownList ID="ddlRState" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                                </div>
                                         </div>
                                        <div class="form-group">
                                                <label ID="lblRcountry" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Country</label>
                                                <div class="col-md-9 col-sm-9 col-xs-12">
                                                  <asp:DropDownList ID="ddlRCountry" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                                </div>
                                         </div>
                                        <div class="form-group">
                                                <label ID="lblRpincode" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Pin&nbsp;Code</label>
                                                <div class="col-md-9 col-sm-9 col-xs-12">
                                                <asp:TextBox ID="txtRpincode" MaxLength="6" runat="server" class="form-control" Style="text-transform: lowercase"></asp:TextBox>
                                                </div>
                                         </div>
                                          <div class="form-group">
                                                <label ID="lblPresPhone" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Phone</label>
                                                <div class="col-md-9 col-sm-9 col-xs-12">
                                                <asp:TextBox ID="txtPresPhone" MaxLength="60" runat="server" class="form-control" Style="text-transform: lowercase"></asp:TextBox>
                                                </div>
                                         </div>
                                    </div>
                                </div>
                        </div>
                            <div class="col-md-6 col-xs-12">
                          <div class="x_content">
                             <div class="alert alert-success alert-dismissible fade in" style="text-align: center;" >
                               <strong>Permanent Address</strong>                 
                            </div>
                            <div class="form-horizontal form-label-left">
                                <div class="form-group">
                                    <label ID="lblPAddress" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Address</label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                       <textarea id="txtPerAddress" runat="server" class="form-control" name="message" data-parsley-trigger="keyup" data-parsley-maxlength="150"></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                        <label ID="lblPCity" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">City/District</label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                          <asp:DropDownList ID="ddlPCity" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                        </div>
                                 </div>
                                <div class="form-group">
                                        <label ID="lblPState" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">State</label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                          <asp:DropDownList ID="ddlPState" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                        </div>
                                 </div>
                                <div class="form-group">
                                        <label ID="lblPCountry" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Country</label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                          <asp:DropDownList ID="ddlPCountry" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                        </div>
                                 </div>
                                <div class="form-group">
                                        <label ID="lblPPincode" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Pin&nbsp;Code</label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                        <asp:TextBox ID="txtPerPincode" MaxLength="6" runat="server" class="form-control" Style="text-transform: lowercase"></asp:TextBox>
                                        </div>
                                 </div>
                                     <div class="form-group">
                                                <label ID="lblPerPhone" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Phon</label>
                                                <div class="col-md-9 col-sm-9 col-xs-12">
                                                <asp:TextBox ID="txtPerPhone" MaxLength="60" runat="server" class="form-control" Style="text-transform: lowercase"></asp:TextBox>
                                                </div>
                                         </div>
                            </div>
                        </div>
                     </div>
                     </div> 
                  </div>
                 </div>
          
                               <div class="form-group">
                                    <div  class="col-md-12 col-sm-12 col-xs-12" style="text-align: center !important;">
                                        <asp:Button ID="btnNew" runat="server" class="btn btn-primary"  Text="New" OnClientClick="return fNew();"
                                                OnClick="btnNew_Click"/>
                                        <button type="reset" class="btn btn-primary">Reset</button>
                                        <button type="submit" class="btn btn-success">Submit</button>
                                        <button type="button" class="btn btn-primary">Cancel</button>
                                         <asp:Button ID="btnSave" runat="server"  class="btn btn-primary" OnClick="btnSave_Click" Text="Save"/>
                                        <asp:HiddenField ID="hdnimageIDtemp" runat="server" />
                                                <asp:HiddenField ID="hdnFlag" runat="server" />
                                                <asp:HiddenField ID="hdntxtStuSelect" runat="server" />
                                                <asp:HiddenField ID="hdntxtParentID" runat="server" />
                                                <asp:HiddenField ID="hdnAdmNo" runat="server" />
                                        
                                           <asp:Button ID="btnDisplay" runat="server" Text="Display" OnClick="btnDisplay_Click"
        Style="display: none;" />
                                    </div>
                                </div>
                                 </div> 
                        <div>

                        </div>
                  </div>
                 </div>
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
<%--    <script src="assets/vendors/parsleyjs/dist/parsley.min.js"></script>--%>
    <script src="assets/vendors/autosize/dist/autosize.min.js"></script>
    <script src="assets/vendors/devbridge-autocomplete/dist/jquery.autocomplete.min.js"></script>
    <script src="assets/vendors/starrr/dist/starrr.js"></script>
    <script src="assets/js/StandardValidation.js"></script>
    <style type="text/css">
        input[type='file'] {
  color: transparent;    /* Hides your "No File Selected" */
  direction: ltr;        /* Sets the Control to Right-To-Left */
}

          .checkbox
        {
            padding-left: 20px;
        }
        .checkbox label
        {
            display: inline-block;
            vertical-align: middle;
            position: relative;
            padding-left: 5px;
        }
        .checkbox label::before
        {
            content: "";
            display: inline-block;
            position: absolute;
            width: 17px;
            height: 17px;
            left: 0;
            margin-left: -20px;
            border: 1px solid #cccccc;
            border-radius: 3px;
            background-color: #fff;
            -webkit-transition: border 0.15s ease-in-out, color 0.15s ease-in-out;
            -o-transition: border 0.15s ease-in-out, color 0.15s ease-in-out;
            transition: border 0.15s ease-in-out, color 0.15s ease-in-out;
        }
        .checkbox label::after
        {
            display: inline-block;
            position: absolute;
            width: 16px;
            height: 16px;
            left: 0;
            top: 0;
            margin-left: -20px;
            padding-left: 3px;
            padding-top: 1px;
            font-size: 11px;
            color: #555555;
        }
        .checkbox input[type="checkbox"]
        {
            opacity: 0;
            z-index: 1;
        }
        .checkbox input[type="checkbox"]:checked + label::after
        {
            font-family: "FontAwesome";
            content: "\f00c";
        }
         
        .checkbox-primary input[type="checkbox"]:checked + label::before
        {
            background-color: #337ab7;
            border-color: #337ab7;
        }
        .checkbox-primary input[type="checkbox"]:checked + label::after
        {
            color: #fff;
        }
    </style>

<script type="text/javascript">
    function SetContextKey() {
        debugger;
        var param = <%=Session["SchoolID"].ToString() %> + '~' + <%=Session["AcaStart"].ToString() %>;
        $find('<%=AutoCompleteExtender1.ClientID%>').set_contextKey($get(param));
    }
    function fBind_Student(e)
    {    
          debugger;
        var param = <%=Session["SchoolID"].ToString() %> + '~' + <%=Session["AcaStart"].ToString() %>;
        $find('<%=AutoCompleteExtender1.ClientID%>').set_contextKey($get(param));
    var varKey;
         if(window.event)
            varKey=window.event.keyCode;
         else
            varKey = e.which; 
         //$('#<%=txtStuSelect.ClientID%>').attr('readonly', false);
          if ( $('#<%=txtStuSelect.ClientID%>').is('[readonly]')) 
            {return false;
            } 
           if ($('#<%=txtStuSelect.ClientID%>').val().length>0)
           {  if(varKey==13 || varKey==0)
                 { 
                 var strArray= $('#<%=txtStuSelect.ClientID%>').val().split('#');
               if (strArray[1] != undefined) {
                   //document.getElementById('txtAdmNo').value = stripBlanks(strArray[1]);
                   $('#<%=txtAdmNo.ClientID%>').val($.trim(strArray[1]));
                   //document.getElementById('btnDisplay').click();
                   $('#<%=btnDisplay.ClientID%>').click()
                   return false;
               }    
                       return false;
                  }
            }  
    }

</script>


    <script type="text/javascript">

        function ShowPopup() {
            $("#myModal").modal('show');
            pClearFields('aspnetForm');
            pLockControls('aspnetForm', 'U');
        }

        function fNew() {
            debugger;
            $('#<%=hdnFlag.ClientID%>').val("N");
           // pClearFields('aspnetForm');  
            pLockControls('aspnetForm', 'U');  
            //pClearFields('aspnetForm');  
            //document.getElementById('hdnFlag').value="N";
            $('#<%=hdntxtStuSelect.ClientID%>').val("^");
            //document.getElementById('hdntxtStuSelect').value = '^';
            $('#<%=flImage.ClientID%>').attr('disabled', false);
            $('#<%=btnUpload.ClientID%>').attr('disabled', false);
            $('#<%=txtAdmNo.ClientID%>').focus();
        }
        $(document).ready(function () {
            debugger;
            if ($('#<%=txtStuDOB.ClientID%>').val().split('~').length > 1) {
                $('#single_cal3').val($('#<%=txtStuDOB.ClientID%>').val().split('~')[1]);
                // $('<%=txtStuDOB.ClientID%>').val($('#<%=txtStuDOB.ClientID%>').val().split('~')[0]);
            }
                   //  $('#<%=flImage.ClientID%>').attr('disabled', true);
                   //  $('#<%=btnUpload.ClientID%>').attr('disabled', true);
                    if ($('#<%=hdnimageIDtemp.ClientID%>').val() != "") {
                        $('#<%=imgStudent.ClientID%>').attr("src", "ImgHandler.ashx?imgid=" + $('#<%=hdnimageIDtemp.ClientID%>').val() + "");
                    }
                    if ($('#<%=hdnFlag.ClientID%>').val() == "") {
                        pLockControls('aspnetForm', 'L');   
                        $('#<%=flImage.ClientID%>').attr('disabled', true);
                        $('#<%=btnUpload.ClientID%>').attr('disabled', true);
                    }
                    $('#<%=txtStuSelect.ClientID%>').attr('readonly', false);
                    $('#<%=txtAdmNo.ClientID%>').attr('readonly', false);
                    $('#<%=txtFeeNo.ClientID%>').attr('readonly', false);                    
                    $('#<%=txtStuSelect.ClientID%>').focus();
             $('a.foo.bar[rel="nameClose"]').click(function () {
                 fredirect();
            });        
        });   
        function path() {
            alert('rk');
        }
    </script>
</asp:Content>


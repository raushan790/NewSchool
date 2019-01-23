<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="assets/vendors/select2/dist/css/select2.min.css" rel="stylesheet">
    <link href="assets/vendors/switchery/dist/switchery.min.css" rel="stylesheet">
    <link href="assets/vendors/starrr/dist/starrr.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_right">
                    <h3>Student Information</h3>
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
                            <div class="col-md-9 col-sm-9 col-xs-12">
                                 <div class="form-horizontal form-label-left">
                                    <div class="form-group">
                                        <label ID="lblStuSelect" runat="server" class="control-label col-md-2 col-sm-2 col-xs-12">Student</label>
                                           <div class="col-md-10 col-sm-10 col-xs-12 form-group">
                                                 <asp:TextBox ID="txtStuSelect" runat="server" class="form-control"></asp:TextBox>
                                            </div>
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
                                            <input type="text" class="form-control has-feedback-center"  style="padding-left: 0px; padding-right:0px !important;" id="single_cal3" aria-describedby="inputSuccess2Status3" required="required" >
                                            <input type="hidden" runat="server" id="txtStuDOB" value="" />
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
                                            <p >B:             <%-- style="padding-top: 7px;"   --%>      
                                            <input type="radio" class="flat" name="admission" id="genderM" value="M" checked="" required />
                                            G:                       
                                            <input type="radio" class="flat" name="admission" id="genderF" value="F" />
                                             </p>                       
                                       </div>
                                  </div>
                                  <div class="form-group">
                                    <label  ID="Label3" runat="server" class="control-label col-md-2 col-sm-2 col-xs-12">Lang.&nbsp;Known </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                         <asp:Panel ID="pnlLanguageKnown" runat="server"  ScrollBars="Vertical">
		                                    <div class="checkbox checkboxlist col-sm-9">
			                                    <asp:CheckBoxList ID="chkLanguageKnown" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow">
				                                    <asp:ListItem Text="Option one"></asp:ListItem>
				                                    <asp:ListItem Text="Option two"></asp:ListItem>
				                                    <asp:ListItem Text="Option three"></asp:ListItem>
			                                    </asp:CheckBoxList>
		                                    </div>
	                                  </asp:Panel>
                                    </div>
                            <%--    </div>

                                 <div class="form-group">--%>
                                        <label ID="lblAdmission" runat="server"  class="control-label col-md-2 col-sm-2 col-xs-12">Admission</label>
                                        <div class="col-md-2 col-sm-2 col-xs-12 form-group">
                                            <p  style="padding-top: 7px;">N:             
                                            <input type="radio" class="flat" name="gender" id="AdmissionN" value="N" checked="" required />
                                            O:                       
                                            <input type="radio" class="flat" name="gender" id="AdmissionO" value="O" />
                                             </p>                       

                                </div>
                                 </div>
                                </div>                         
                             </div>
                            <div class="col-md-3 col-sm-3 col-xs-12 profile_left">

                                <div class="profile_img">
                                         <div id="crop-avatar">
                                        <!-- Current avatar -->
                                        <img  ID="imgStudent" runat="server" class="img-responsive avatar-view" src="assets/images/picture.jpg" 
                                            alt="Avatar" title="StudentPhoto"  OnClientClick="javascript:return false;">
                                    </div>
                                </div>
                                <br />
                                 <asp:FileUpload ID="FileUpload1" ToolTip="Upload Photo" runat="server"  />
                                <br />
                                <asp:Button ID="btnUpload" runat="server" Text="Upload File"  />

                          
                                   
                            </div>
                            </div> 
                        </div>
                        </div>
                    </div>
         </div>
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
                                        <label ID="lblBoardingCategory" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Boarding&nbsp;Category</label>
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
                                          <asp:DropDownList ID="ddlSchoolBus" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                        </div>
                                 </div>

                                <div class="ln_solid"></div>
                                <div class="form-group">
                                    <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3">
                                        <button type="button" class="btn btn-primary">Cancel</button>
                                        <button type="reset" class="btn btn-primary">Reset</button>
                                        <button type="submit" class="btn btn-success">Submit</button>
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
                                    <label ID="lblFeeApplnFrom" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Fee Appl. From</label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                      <asp:DropDownList ID="ddlFeeApplnFrom" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label ID="lblSocCategory" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Social Category</label>
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
                                                <asp:ListItem Value="0">Parent</asp:ListItem>
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

  

                                <div class="ln_solid"></div>
                                <div class="form-group">
                                    <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3">
                                        <button type="button" class="btn btn-primary">Cancel</button>
                                        <button type="reset" class="btn btn-primary">Reset</button>
                                        <button type="submit" class="btn btn-success">Submit</button>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>


            </div>


        <%--<div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="x_panel">
                       
                        <div class="x_content">   
                         <div class="col-md-6 col-xs-12">
                    <div class="x_panel">
                          <div class="x_content">
                            <br>
                            <div class="form-horizontal form-label-left">
                                <div class="alert alert-success alert-dismissible fade in" role="alert">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">×</span>
                            </button>
                            <strong>Holy guacamole!</strong> Best check yo self, you're not looking too good.
                 
                        </div>
                                <div class="form-group">
                                        <label  ID="Label4" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Date&nbsp;of&nbsp;Admission</label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <div class="col-md-14 xdisplay_inputx form-group has-feedback" style="padding-left: 0px;">
                                            <input type="text"  class="form-control has-feedback-center" id="single_cal1" aria-describedby="inputSuccess2Status1" required="required" >
                                            <span class="fa fa-calendar-o form-control-feedback left" aria-hidden="true"></span>
                                            <span id="inputSuccess2Status1" class="sr-only">(success)</span>
                                              <input type="hidden" ID="Hidden1" runat="server" />
                                        </div>
                                    </div> 
                                </div>
                                <div class="form-group">
                                    <label ID="Label5" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Fee Group<span class="required" style="color: #ff0000">*</span></label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                      <asp:DropDownList ID="DropDownList1" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label ID="Label6" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Religion</label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                      <asp:DropDownList ID="DropDownList2" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                        <label ID="Label7" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">House</label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                          <asp:DropDownList ID="DropDownList3" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                        </div>
                                 </div>
                                <div class="form-group">
                                        <label ID="Label8" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Mother&nbsp;Tongue</label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                          <asp:DropDownList ID="DropDownList4" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                        </div>
                                 </div>
                                <div class="form-group">
                                        <label ID="Label9" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Nationality</label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                          <asp:DropDownList ID="DropDownList5" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                        </div>
                                 </div>
                                <div class="form-group">
                                        <label ID="Label10" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Boarding&nbsp;Category</label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                          <asp:DropDownList ID="DropDownList6" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                        </div>
                                 </div>
                                <div class="form-group">
                                        <label ID="Label11" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Board</label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                          <asp:DropDownList ID="DropDownList7" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                        </div>
                                 </div>
                         

                                <div class="form-group">
                                        <label ID="Label12" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">School Bus</label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                          <asp:DropDownList ID="DropDownList8" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                        </div>
                                 </div>

                                <div class="ln_solid"></div>
                                <div class="form-group">
                                    <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3">
                                        <button type="button" class="btn btn-primary">Cancel</button>
                                        <button type="reset" class="btn btn-primary">Reset</button>
                                        <button type="submit" class="btn btn-success">Submit</button>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

                          <div class="col-md-6 col-xs-12">
                    <div class="x_panel">
                          <div class="x_content">
                           <div class="alert alert-success alert-dismissible fade in" >
                            <button type="button" class="close" data-dismiss="alert">                                
                            </button>
                            <strong>Permanent Address</strong>
                 
                        </div>
                            <br>
                            <div class="form-horizontal form-label-left">
                                
                                <div class="form-group">
                                        <label  ID="Label13" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Date&nbsp;of&nbsp;Join</label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <div class="col-md-14 xdisplay_inputx form-group has-feedback" style="padding-left: 0px;">
                                            <input type="text"  class="form-control has-feedback-center" id="single_cal2" aria-describedby="inputSuccess2Status2" required="required" >
                                            <span class="fa fa-calendar-o form-control-feedback left" aria-hidden="true"></span>
                                            <span id="inputSuccess2Status2" class="sr-only">(success)</span>
                                            <input type="hidden" ID="Hidden2" runat="server" />
                                        </div>
                                    </div> 
                                </div>
                                <div class="form-group">
                                    <label ID="Label14" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Fee Appl. From</label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                      <asp:DropDownList ID="DropDownList9" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label ID="Label15" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Social Category</label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                      <asp:DropDownList ID="DropDownList10" runat="server"  class="select2_group form-control" ></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label  ID="Label16" runat="server" class="control-label col-md-3 col-sm-3 col-xs-12">
                                       E-Mail
                                    </label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                        <asp:TextBox ID="TextBox1" runat="server" class="form-control" Style="text-transform: lowercase"></asp:TextBox>
                                    </div>
                                </div>                               
                                <div class="form-group">
                                    <label ID="Label17" runat="server" class="col-md-3 col-sm-3 col-xs-12 control-label">
                                       Living&nbsp;With
                                    </label>

                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                        <asp:DropDownList ID="DropDownList11" runat="server" class="select2_group form-control" >
                                                <asp:ListItem Value="0">Parent</asp:ListItem>
                                                <asp:ListItem Value="1">Father</asp:ListItem>
                                                <asp:ListItem Value="2">Mother</asp:ListItem>
                                                <asp:ListItem Value="3">Local Gaurdian</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label  ID="Label18" runat="server"  class="col-md-3 col-sm-3 col-xs-12 control-label">
                                         Concession&nbsp;Type</label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                        <asp:DropDownList ID="DropDownList12" runat="server" class="select2_group form-control" >
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label  ID="Label19" runat="server"  class="col-md-3 col-sm-3 col-xs-12 control-label">
                                         Blood&nbsp;Group</label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                        <asp:DropDownList ID="DropDownList13" runat="server" class="select2_group form-control" >
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label ID="Label20" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Board&nbsp;Reg.&nbsp;No.</label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                        <asp:TextBox ID="TextBox2" MaxLength="20" runat="server" class="form-control" Style="text-transform: lowercase"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label ID="Label21" runat="server"  class="control-label col-md-3 col-sm-3 col-xs-12">Board&nbsp;Roll&nbsp;No.</label>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                        <asp:TextBox ID="TextBox3" MaxLength="50" runat="server" class="form-control" Style="text-transform: lowercase"></asp:TextBox>
                                    </div>
                                </div>

  

                                <div class="ln_solid"></div>
                                <div class="form-group">
                                    <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3">
                                        <button type="button" class="btn btn-primary">Cancel</button>
                                        <button type="reset" class="btn btn-primary">Reset</button>
                                        <button type="submit" class="btn btn-success">Submit</button>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>


                        </div> 
                        </div>
                        </div>
                    </div>--%>
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

</asp:Content>


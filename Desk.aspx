<%@ Page Title="" Language="C#" MasterPageFile="~/afcconfig.master" AutoEventWireup="true" CodeFile="Desk.aspx.cs" Inherits="configurator2_Desk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="../JS/html2canvas.js"></script>
    <script src="../JS/jquery.tooltip.js"></script>
   
    <link href="deskstyle.css" rel="stylesheet" />
 
    <script type="text/javascript">
        function MutExChkList(chk) {
            var chkList = chk.parentNode.parentNode.parentNode;
            var chks = chkList.getElementsByTagName("input");
            for (var i = 0; i < chks.length; i++) {
                if (chks[i] != chk && chk.checked) {
                    chks[i].checked = false;
                }
            }
        }
        function showImage(elementid) {
            if (document.getElementById(elementid).style.display == "none") {
                document.getElementById(elementid).style.display = "table";
            }
            else {
                document.getElementById(elementid).style.display = "none";
            }
        }
        // Get the modal
        var modal = document.getElementById('myModal');

        // Get the button that opens the modal
        //var btn = document.getElementById("myBtn");

        // Get the <span> element that closes the modal
        //var span = document.getElementsByClassName("close")[0];

        // When the user clicks the button, open the modal 
        //btn.onclick = function () {
        //    modal.style.display = "block";
        //}
        $('#myBtn').on('click', function ()
        {
            modal.style.display = "block";
        });


        // When the user clicks on <span> (x), close the modal
        //span.onclick = function () {
        //    modal.style.display = "none";
        //}
        $('.close').on('click', function () {
            modal.style.display = "block";
        });


        // When the user clicks anywhere outside of the modal, close it
        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--Send email panel--%>
    <div class="gap"></div> <div class="gap"></div>
    <div class="main-container vicky-config">
        <div class="container">
          
    <div class="row">
        <div class="breadcrumbDiv col-lg-12">
            <ul class="breadcrumb">
                <li><a href="../default.aspx">Home</a></li>
                <li><a href="default.aspx">Desk</a></li>
            </ul>
        </div>
    </div>
    <div class="clearfix"></div>
  
    <div class="row">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <Triggers>
      <%--          <asp:AsyncPostBackTrigger ControlID="btnUpdateQunatity" EventName="click" />
                <asp:AsyncPostBackTrigger ControlID="btnSendEmailpanel" EventName="click" />
                <asp:PostBackTrigger ControlID="btnHiddenCreatePdf" />
                <asp:PostBackTrigger ControlID="btndownload" />--%>
             
            </Triggers>
            <ContentTemplate>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:Panel ID="Panel5" runat="server" >      
                        <div class="form-horizontal">                            
                   <asp:Panel ID="Panel1"  runat="server" >
                   <asp:RadioButtonList ID="rdoDeskButton" runat="server"  AutoPostBack="True"  RepeatLayout="Flow"                       
                            OnSelectedIndexChanged="rdoDeskButton_SelectedIndexChanged"
                          RepeatDirection="Horizontal" ></asp:RadioButtonList>   
                       <asp:RadioButtonList ID="rdoCasterExtra" runat="server"  AutoPostBack="True"                         
                            OnSelectedIndexChanged="rdoCasterExtra_SelectedIndexChanged"
                          RepeatDirection="Horizontal" ></asp:RadioButtonList>         
                                         
                   <div class="color-container1" >                      
                        <label class="stepSegement">1. Desk Size</label>    
                        <asp:RadioButtonList ID="rdoDeskSize" runat="server"  RepeatLayout="Flow"
                            AutoPostBack="True"  RepeatDirection="Horizontal"  OnSelectedIndexChanged="rdoDeskSize_SelectedIndexChanged"  ></asp:RadioButtonList>                             
                        <asp:Label ID="lblDeskSize" runat="server" Text=""></asp:Label>    
                    </div>                      
                   <div  id="deskColor" runat="server" > 
                        <asp:Label ID="lblDeskColor" runat="server" Text=""></asp:Label>                                   
                        <asp:RadioButtonList ID="rdoDeskColor" runat="server"  AutoPostBack="True"  RepeatLayout="Flow"
                        RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoDeskColor_SelectedIndexChanged"></asp:RadioButtonList>                                 
                        <asp:Label ID="lblDeskColorDetail" runat="server" Text=""></asp:Label>    
                   </div>
                  <div id="deskLeg" runat="server" >                   
                       <asp:Label ID="lblDeskLeg" runat="server" Text=""></asp:Label>  
                       <asp:RadioButtonList ID="rdoDeskLeg" runat="server"   AutoPostBack="true" RepeatLayout="Flow"
                                RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoDeskLeg_SelectedIndexChanged"></asp:RadioButtonList>                         
                       <asp:Label ID="lblDeskLegDetail" runat="server" Text=""></asp:Label>                                                 
                   </div>
                   <div id="moldingColor" runat="server">  
                          <asp:Label ID="lblMoldingColor" runat="server" Text=""></asp:Label>
                         <asp:RadioButtonList ID="rdoMoldingColor" runat="server" AutoPostBack="True" RepeatLayout="Flow"
                                 RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoMoldingColor_SelectedIndexChanged1"></asp:RadioButtonList>
                         <asp:Label ID="lblMoldingColorList" runat="server" Text=""></asp:Label>   

                   </div>
                
                <%--    <div id="deskCaster" class="col-md-12 col-sm-12" runat="server">                      
                     
                     </div>    
                    <div id="moldingColor" class="col-md-12 col-sm-12" runat="server">                    
                           
                     </div> --%>
 
                 <div id="deskCaster" runat="server" >  
                           <asp:Label ID="lblDeskCaster" runat="server" Text=""></asp:Label>
                         <asp:RadioButtonList ID="rdoCaster" runat="server" AutoPostBack="True" RepeatLayout="Flow"                             
                             OnSelectedIndexChanged="rdoCaster_SelectedIndexChanged"
                                 RepeatDirection="Horizontal"></asp:RadioButtonList>
                         <asp:Label ID="lblCasterDetail" runat="server" Text=""></asp:Label>            
                        </div>

                 <div id="keyboardTray" runat="server" >     
                        <asp:Label ID="lblKeyboardTray" runat="server" Text=""></asp:Label>
                         <asp:RadioButtonList ID="rdoKeyboard" runat="server" AutoPostBack="True"    RepeatLayout="Flow"                      
                                 RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoKeyboard_SelectedIndexChanged"></asp:RadioButtonList>
                         <asp:Label ID="Label2" runat="server" Text=""></asp:Label>     
                     </div>

                 <div id="monitorArm" runat="server" Class="rdoMonitorArm">             
                        <asp:Label ID="lblMonitorArm" runat="server" Text=""></asp:Label>
                         <asp:RadioButtonList ID="rdoMonitorArm" runat="server"  AutoPostBack="true"    RepeatLayout="Flow"
                             RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoMonitorArm_SelectedIndexChanged" ></asp:RadioButtonList>
                         <asp:Label ID="Label8" runat="server" Text=""></asp:Label>  
                     </div> 
                       <div id="monitorArmSub" runat="server" >
                               <asp:Label ID="lblMonitorTypeSub" runat="server" Text=""></asp:Label>  
                                <asp:RadioButtonList ID="rdoMonitorTypeSub" runat="server"      RepeatLayout="Flow"
                                 AutoPostBack="True"    RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoMonitorTypeSub_SelectedIndexChanged" ></asp:RadioButtonList>
                            </div>


                    <div id="topCabinet" runat="server" >  
                        <asp:Label ID="lblTopCabinet" runat="server" Text=""></asp:Label>
                         <asp:RadioButtonList ID="rdoCabinet" runat="server"  AutoPostBack="true" RepeatLayout="Flow"
                                 RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoCabinet_SelectedIndexChanged"></asp:RadioButtonList>
                         <asp:Label ID="Label4" runat="server" Text=""></asp:Label>     
                     </div> 
                  <div id="deskBottomPanel" runat="server" >              
                        <asp:Label ID="lblDeskBottomPanel" runat="server" Text=""></asp:Label>
                         <asp:RadioButtonList ID="rdoDeskBottomPanel" runat="server"  AutoPostBack="true"  RepeatLayout="Flow"
                                 RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoDeskBottomPanel_SelectedIndexChanged" ></asp:RadioButtonList>
                         <asp:Label ID="Label6" runat="server" Text=""></asp:Label>     
                     </div> 
                  <div id="cpuHolder" runat="server" >  
                        <asp:Label ID="lblCpuHolder" runat="server" Text=""></asp:Label>
                         <asp:RadioButtonList ID="rdoCpuHolder" runat="server"  AutoPostBack="true"  RepeatLayout="Flow"
                                 RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoCpuHolder_SelectedIndexChanged" ></asp:RadioButtonList>
                       
                     </div> 
                   <div id="deskAccessories" runat="server" >  
                         <asp:Label ID="lblDeskAccessories" runat="server" Text=""></asp:Label>
                        <ul class="desk-accessories">
                        <li> <asp:CheckBoxList ID="chkPhoneArm" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="chkPhoneArm_SelectedIndexChanged"></asp:CheckBoxList>  </li>
                        <li> <asp:CheckBoxList ID="chkTaskLight" runat="server" AutoPostBack="true" OnSelectedIndexChanged="chkTaskLight_SelectedIndexChanged"></asp:CheckBoxList>  </li>
                        <li> <asp:CheckBoxList ID="chkUSBhub" runat="server" AutoPostBack="true" OnSelectedIndexChanged="chkUSBhub_SelectedIndexChanged"></asp:CheckBoxList></li>
                         </ul>
                        <ul class="desk-accessories">
                        <li> <asp:CheckBoxList ID="chkCupHolder" runat="server" AutoPostBack="true" OnSelectedIndexChanged="chkCupHolder_SelectedIndexChanged"></asp:CheckBoxList> </li>        
                        <li> <asp:CheckBoxList ID="chkWireManagement" runat="server" AutoPostBack="true" OnSelectedIndexChanged="chkWireManagement_SelectedIndexChanged" ></asp:CheckBoxList> </li>        
                      </ul>
                     </div>
                    
                    


                  <%--      </div>--%>
                       </asp:Panel>
                 
                  </div>     
            </div>
</asp:Panel>
                <div class="col-md-6 col-lg-6 col-sm-6 col-xs-12" style="float: left;">
                 
                       <asp:Button ID="btnCheckOut" runat="server" onclick="btnCheckOut_Click"  CssClass="btn btn-default" 
                    Text="Check Out" />
                    <div class="imageconfig screen" runat="server">
                        <asp:Panel ID="Panel2" runat="server"  CssClass="pnlPolCart">
                            <div class="container" id="imgpanel">

                    <div class="absolute" id="divFooterLeg">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgFooterLeg" runat="server"  Visible="False"  CssClass="deskleg img-responsive" />
                    </div>
                    </div>
                    <div class="absolute" id="divCasterAlone">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgCasterExra" runat="server"  Visible="False"  CssClass="deskleg img-responsive"/>
                    </div>
                    </div>
                    <div class="absolute">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgDeskButton" runat="server"  Visible="False"  CssClass="deskleg img-responsive" />
                    </div>
                    </div>
                    
                    <div class="absolute" id="divDeskLeg">
                    <div class=" relative" style="display: inline-block;">
                    <asp:Image ID="imgDeskLeg" runat="server"  Visible="False" CssClass="deskleg img-responsive"/>                               
                    </div>
                    </div>
                    <div class="absolute" id="divDeskColor">
                    <div class=" relative" style="display: inline-block;">
                        <asp:Image ID="imgDeskColor" runat="server" Visible="False" CssClass="deskcolor img-responsive"/>                                                                              
                    </div>
                    </div>
                    <div class="absolute" id="divCasterTop">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgCasterTop" runat="server"  Visible="False"  CssClass="img-responsive"/>                                  
                    </div>
                    </div>

                    <div class="absolute" id="divCaster">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgCaster" runat="server"  Visible="False"  CssClass="img-responsive"/>                                  
                    </div>
                    </div>

                    <div class="absolute" id="divMoldingColor">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgMoldingColor" Visible="False" runat="server"  CssClass="img-responsive"/>                                  
                    </div>
                    </div>

                              
                    <div class="absolute" id="divCabinet">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgCabinet" runat="server" Visible="False" CssClass="img-responsive"/>                                  
                    </div>
                    </div>
                                 
                    <div class="absolute" id="divTopShelfMoldingColor">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgTopShelfMoldingColor" runat="server" Visible="False" CssClass="img-responsive"/>                                  
                    </div>
                    </div>


                    <div class="absolute" id="divKeyboard">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgKeyboard" runat="server" Visible="False" CssClass="img-responsive"/>                                  
                    </div>
                    </div>
                              
                    <div class="absolute" id="divKeyboardMolding">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgKeyboardMolding" runat="server" Visible="False" CssClass="img-responsive"/>                                  
                    </div>
                    </div>

                    <div class="absolute" id="divMonitorArm">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgMonitorArm" runat="server"  Visible="False" CssClass="img-responsive"/>                                  
                    </div>
                    </div>
                    <div class="absolute" id="divMonitorArmSub">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgMonitorArmSub" runat="server"  Visible="False" CssClass="img-responsive"/>                                  
                    </div>
                    </div>


                    <div class="absolute" id="divDeskBottomPanel">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgDeskBottomPanel" runat="server" Visible="False" CssClass="img-responsive"/>                                  
                    </div>
                    </div>
                                
                    <div class="absolute" id="divDeskBottomMoldingColor">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgDeskBottomMoldingColor" runat="server" Visible="False" CssClass="img-responsive"/>                                  
                    </div>
                    </div>

                    <div class="absolute" id="divImgDeskCabinetFrameColor">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgDeskCabinetFrameColor" runat="server"  Visible="False" CssClass="img-responsive"/>                                  
                    </div>
                    </div>
                    <div class="absolute" id="divCpuHolder">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgCpuHolder" runat="server" Visible="False"  CssClass="img-responsive"/>                                  
                    </div>
                    </div>


                    <div class="absolute" id="divPhoneArm">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgPhoneArm" runat="server" Visible="False"  CssClass="img-responsive"/>                                  
                    </div>
                    </div>
                    <div class="absolute" id="divTaskLight">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgTaskLight" runat="server" Visible="False" CssClass="img-responsive"/>                                  
                    </div>
                    </div>
                    <div class="absolute" id="divDeskLamp">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgUSBhub" runat="server" Visible="False"  CssClass="img-responsive"/>                                  
                    </div>
                    </div>
                    <div class="absolute" id="divCupHolder">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgCupHolder" runat="server" Visible="False"  CssClass="img-responsive"/>                                  
                    </div>
                    </div>
                     <div class="absolute" id="divWiremanagement">
                    <div class="relative" style="display: inline-block;">
                        <asp:Image ID="imgWiremanagement" runat="server" Visible="False"  CssClass="img-responsive"/>                                  
                    </div>
                    </div>
                            </div>
                        </asp:Panel>


                    </div>
                    <div>
                        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                    </div>
                    <!--end row-->

                    <div class="clearfix"></div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
 
    <div class="gap"></div>
    <div class="gap"></div>
</div>
        </div>
  

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/CarityMaster.Master" AutoEventWireup="true" CodeBehind="ProfileDetails.aspx.cs" Inherits="PerfectCarity.ProfileDetails" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link href="Carity.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeader" runat="server">
   <asp:ToolkitScriptManager runat="server" ID="sm1"/>
            <table class="auto-style1">
               <tr>
                  <td class="auto-style7">&nbsp;</td>
                  <td>
                     <asp:ImageButton ID="ImageButton1" runat="server" Height="45px" ImageUrl="~/Images/carityNameWhite.png" Width="145px" />
                           </td>
                           <td>
                     <asp:Label ID="lbl_username" runat="server" Text="username"></asp:Label>
                     <asp:Image ID="imgSettings" runat="server" Height="25px" ImageUrl="~/Images/settings.png" Width="25px" />
                     <asp:HoverMenuExtender ID="imgSettings_hovermenuextender" runat="server" 
                        TargetControlID="imgSettings"
                        HoverCSSClass="popupHover" 
                        PopupControlID="PopupMenu" 
                        PopupPosition="Bottom" 
                        PopDelay="25">
                     </asp:HoverMenuExtender>
                     <asp:Panel ID="PopupMenu" runat="server" CssClass="popupMenu">
                        <br />
                        <asp:HyperLink ID="editUserLink" runat="server" Text="Account Settings" CssClass="dropDownLink" NavigateURL="~/EditUser.aspx"/>
                        <br />
                        <asp:LinkButton ID="editProfileLink" runat="server" Text="Edit Profile" OnClick="OnEditProfile_Click" CssClass="dropDownLink" />
                        <br />
                        <asp:HyperLink ID="addProfileLink" runat="server" Text="Create New Profile" CssClass="dropDownLink" NavigateURL="~/AddProfile.aspx" />
                        <br />
                        <asp:HyperLink ID="linkProfileLink" runat="server" Text="Link To Profile" CssClass="dropDownLink" NavigateURL="~/LinkProfile.aspx" />
                        <br />
                        <asp:LinkButton ID="logoutLink" runat="server" OnClick="OnLogout_Click" Text="Log Out" CssClass="dropDownLink" />
                     </asp:Panel>
                  </td>
               </tr>
   </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageDetails" runat="server">
   <div class="centerPanel">
      <asp:Panel ID="userInfoPanel" runat="server" Width="600px" HorizontalAlign="Left">
         <asp:Image ID="Image1" runat="server" Height="115px" Width="121px" />
         <asp:Label ID="lblProfileName" runat="server" Text="Profile Name" CssClass="pageHeader2"></asp:Label>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:ImageButton ID="ibEditProfile" runat="server" Height="30px" ImageUrl="~/Images/file_edit.png" Width="30px" />
         <br />
         <asp:TextBox ID="txtSearch" runat="server" CssClass="textBox" Height="25px" Width="550px"></asp:TextBox>
         <asp:ImageButton ID="searchButton" runat="server" Height="25px" ImageUrl="~/Images/Search.png" Width="25px" />
      </asp:Panel>
   </div>
   <div class="centerPanel">
      <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
         <ItemTemplate>
            <div class="repeater">
               <table>
                  <tr>
                     <td>
                        <asp:Image ID="behavior" runat="server" Height="20" Width="20" ImageURL='<%#Eval("behaviorImage") %>' />
                     </td>
                     <td>
                        <asp:Label ID="lblTime" runat="server" Text='<%#Eval("time") %>' ></asp:Label>
                     </td>
                     <td>
                        <asp:Label ID="lblBehaviorType" runat="server" Text="<%#Eval("behaviorType") %>"></asp:Label>
                     </td>
                  </tr>
                  <tr style="height: 100px">
                     <td style="width: 100px">
                        <asp:Image ID="entryImage" runat="server" Height="100" Width="100" ImageURL="~/LoadImagePage.aspx?ImageID="+'<%#Eval("image_id") %>' />
                     </td>
                     <td>
                        <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>' ></asp:Label>
                        <br />
                        <asp:Label ID="lblEntryPostedBy" runat="server" Text="Posted By: "+'<%#Eval("username") %>' ></asp:Label>
                     </td>
                  </tr>
               </table>
            </div>
         </ItemTemplate>
         <SeparatorTemplate>
            <hr />
         </SeparatorTemplate>
      </asp:Repeater>
   </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageFooter" runat="server">
</asp:Content>

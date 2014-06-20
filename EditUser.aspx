<%@ Page Title="" Language="C#" MasterPageFile="~/CarityMaster.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="PerfectCarity.EditUser" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link href="Carity.css" rel="stylesheet" />
   <style type="text/css">
      .auto-style7 {
         width: 252px;
      }
   
   </style>
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
                        <asp:LinkButton ID="editUserLink" runat="server" Text="Account Settings" OnClick="OnNavBarLink_Click" CssClass="dropDownLink" CommandName="~/EditUser.aspx"/>
                        <br />
                        <asp:LinkButton ID="editProfileLink" runat="server" Text="Edit Profile" OnClick="OnNavBarLink_Click" CssClass="dropDownLink" />
                        <br />
                        <asp:LinkButton ID="addProfileLink" runat="server" Text="Create New Profile" OnClick="OnNavBarLink_Click" CssClass="dropDownLink" CommandName="~/AddProfile.aspx" />
                        <br />
                        <asp:LinkButton ID="linkProfileLink" runat="server" Text="Link To Profile" OnClick="OnNavBarLink_Click" CssClass="dropDownLink" CommandName="~/LinkProfile.aspx" />
                        <br />
                        <asp:LinkButton ID="logoutLink" runat="server" OnClick="OnNavBarLink_Click" Text="Log Out" CssClass="dropDownLink" />
                     </asp:Panel>
                  </td>
               </tr>
   </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageDetails" runat="server">
   <div class="centerPanel">
      <div class="centerLeftJustified">
         <asp:Label ID="lblEditUser" runat="server" CssClass="pageTitle" ForeColor="#1C0F00" Text="Edit User"></asp:Label>
         <br />
         &nbsp;<asp:TextBox ID="txtName" runat="server" Style="font-size: large" PlaceHolder="Name" Width="200px"></asp:TextBox>
         <br />
         <br />
         <asp:Label ID="Label1" runat="server" CssClass="pageHeader2" Text="User Image"></asp:Label>
         <div class="editUserImage" style="width: 233px; height: 217px;">
            <asp:Image ID="imgUserImage" runat="server" Height="150px" Width="150px" />
            <br />
            &nbsp;
         <asp:FileUpload ID="fileUpload" runat="server" />
            <br />
            <asp:Button ID="UploadButton" runat="server" Text="Upload" OnClick="uploadButton_Click" />
         </div>
         &nbsp;
      <br />
         <asp:Label ID="lblSecurityQuestions" runat="server" CssClass="pageHeader2" Text="Security Questions"></asp:Label>
         <br />
         &nbsp;<asp:DropDownList ID="ddlSecurityQuest1" runat="server" Width="395px" AppendDataBoundItems="True" Font-Size="Large" Height="27px" TabIndex="2"></asp:DropDownList>
         <br />
         <br />
         &nbsp;<asp:TextBox ID="txtAnswer1" runat="server" Style="font-size: large" Width="385px" TabIndex="4"></asp:TextBox>
         <br />
         <br />
         &nbsp;<asp:DropDownList ID="ddlSecurityQuest2" runat="server" Width="395px" AppendDataBoundItems="True" Font-Size="Large" TabIndex="5"></asp:DropDownList>
         <br />
         <br />
         &nbsp;<asp:TextBox ID="txtAnswer2" runat="server" Style="font-size: large" Width="385px" TabIndex="6"></asp:TextBox>
         <br />
         <br />
         <br />
         <asp:Button ID="registerButton" runat="server" CssClass="button" Text="Save User" OnClick="registerButton_Click" Height="30px" TabIndex="7" Width="165px" />
         <br />
      </div>
   </div>
</asp:Content>

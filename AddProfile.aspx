<%@ Page Title="" Language="C#" MasterPageFile="~/CarityMaster.Master" AutoEventWireup="true" CodeBehind="AddProfile.aspx.cs" Inherits="PerfectCarity.AddProfile" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link href="Carity.css" rel="stylesheet" />
   <style type="text/css">
      .auto-style7 {
         width: 297px;
      }
      .auto-style9 {
         width: 513px;
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
                        <asp:LinkButton ID="editUserLink" runat="server" CommandName ="EditUser.aspx" Text="Edit User" CssClass="dropDownLink" OnClick="OnNavBarLink_Click" ></asp:LinkButton>
                        <br />
                        <asp:LinkButton ID="editProfileLink" runat="server" CommandName="EditProfile.aspx" Text="Edit Profile" OnClick="OnNavBarLink_Click" CssClass="dropDownLink" />
                        <br />
                        <asp:LinkButton ID="addProfileLink" runat="server" CommandName="AddProfile.aspx" Text="Create New Profile" CssClass="dropDownLink" OnClick="OnNavBarLink_Click" />
                        <br />
                        <asp:LinkButton ID="linkProfileLink" runat="server" CommandName="LinkProfile.aspx" Text="Link To Profile" CssClass="dropDownLink" OnClick="OnNavBarLink_Click" />
                        <br />
                        <asp:LinkButton ID="logoutLink" runat="server" CommandName="LoginRegistration.aspx" OnClick="OnNavBarLink_Click" Text="Log Out" CssClass="dropDownLink" />
                     </asp:Panel>
                  </td>
               </tr>
   </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageDetails" runat="server">
   <div class="centerPanel">
      <div class="centerLeftJustified">
         <asp:Label ID="lblEditUser" runat="server" CssClass="pageTitle" ForeColor="#1C0F00" Text="Create Profile"></asp:Label>
         <br />
         &nbsp;
            <asp:TextBox ID="txtName" runat="server" CssClass="textBox" Style="font-size: large" PlaceHolder="Name" Width="200px"></asp:TextBox>
         <br />
         <br />
         <asp:Label ID="Label1" runat="server" CssClass="pageHeader2" Text="Profile Image"></asp:Label>
         <div class="editProfileImage" style="width: 173px; height: 176px;">
            <asp:Image ID="imgProfileImage" runat="server" Height="150px" Width="150px" TabIndex="1" CssClass="editProfile"></asp:Image>
            <asp:FileUpload ID="fileUpload" runat="server" ></asp:FileUpload>
            <br />
            <asp:Button ID="UploadImage" runat="server" Text="Upload" OnClick="uploadButton_Click" ></asp:Button>
         </div>
         <br />
         <br />
         <asp:Label ID="Label2" runat="server" CssClass="pageHeader2" Text="Profile Users"></asp:Label>
         <br />
         <div class="addProfilePlaceholder">
            <asp:PlaceHolder ID="profileEmails" runat="server"></asp:PlaceHolder>
            &nbsp;
         </div>
         <br />
         <asp:ImageButton ID="addUser" runat="server" Height="30px" ImageUrl="~/Images/plus.png" Width="30px" OnClick="addUser_Click" CssClass="addUserImage" />
         <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="textBox" Enabled="False" ReadOnly="True" Placeholder="Email Address" Height="16px" Width="269px"></asp:TextBox>
         <asp:TextBox ID="userAccess" runat="server" CssClass="textBox" Enabled="False" ReadOnly="True" Placeholder="Access"></asp:TextBox>
         <br />
         <br />
         <asp:Button ID="createButton" runat="server" CssClass="button" Width="100px" Text="Create" OnClick="createButton_Click" />
      </div>
   </div>
</asp:Content>

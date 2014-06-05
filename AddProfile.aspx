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
                        <asp:HyperLink ID="editUserLink" runat="server" Text="Account Settings" CssClass="dropDownLink" NavigateURL="~/EditUser.aspx"/>
                        <br />
                        <asp:LinkButton ID="editProfileLink" runat="server" CommandName="EditProfile.aspx" Text="Edit Profile" OnClick="OnEditProfile_Click" CssClass="dropDownLink" />
                        <br />
                        <asp:HyperLink ID="addProfileLink" runat="server" Text="Create New Profile" CssClass="dropDownLink" NavigateURL="~/AddProfile.aspx" />
                        <br />
                        <asp:HyperLink ID="linkProfileLink" runat="server" Text="Link To Profile" CssClass="dropDownLink" NavigateURL="~/LinkProfile.aspx" />
                        <br />
                        <asp:LinkButton ID="logoutLink" runat="server" CommandName="LoginRegistration.aspx" OnClick="OnLogout_Click" Text="Log Out" CssClass="dropDownLink" />
                     </asp:Panel>
                  </td>
               </tr>
   </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageDetails" runat="server">
   <table class="auto-style1" style="width: 69%">
      <tr>
         <td class="auto-style8">
         <td style="padding-left: 25px; text-align: left;" class="auto-style9">
            <asp:Label ID="lblEditUser" runat="server" CssClass="pageTitle" ForeColor="#1C0F00" Text="Create Profile"></asp:Label>
            <br />
            &nbsp;<asp:TextBox ID="txtName" runat="server" style="font-size: large" PlaceHolder="Name" Width="276px" CssClass="textBox"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" CssClass="pageHeader2" Text="Profile Image"></asp:Label>
            <div class="editProfileImage" style="width: 173px; height: 176px;">               
               <asp:ImageButton ID="imgUserImage" runat="server" Height="150px" Width="150px" TabIndex="1"  OnClientClick="OpenFO();" CssClass="editProfile"></asp:ImageButton>
               <br />
               <script type="text/javascript">
                  function OpenFO() {
                     var ofd = document.getElementById("ofd");
                     ofd.click();
                     return false;
                  }
               </script>
               <input id="ofd" type="file" onchange="save(this);" style=" visibility:hidden;" />
            </div>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" CssClass="pageHeader2" Text="Profile Users"></asp:Label>
            <br />
            <br />
            <asp:Panel ID="profileEmails" runat="server" CssClass="profileUserEmails">

            </asp:Panel>
            <asp:Panel ID="profileUserAccess" runat="server" CssClass="profileUserAccess">

            </asp:Panel>
            <asp:ImageButton ID="addUser" runat="server" Height="30px" ImageUrl="~/Images/plus.png" Width="30px" OnClick="addUser_Click" CssClass="addUserImage" />
            <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="textBox" Enabled="False" ReadOnly="True" Placeholder ="Email Address" Height="16px" Width="269px"></asp:TextBox>
            <asp:TextBox ID="userAccess" runat="server" CssClass="textBox" Enabled="False" ReadOnly="True" Placeholder ="Access"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="createButton" runat="server" CssClass="button" Width ="100px" Text="Create" />
         </td>
         </td>
      </tr>
   </table>
</asp:Content>

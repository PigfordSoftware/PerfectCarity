<%@ Page Title="" Language="C#" MasterPageFile="~/CarityMaster.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="PerfectCarity.EditUser" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style type="text/css">
      .auto-style5 {
         width: 514px;
      }
      .auto-style6 {
         width: 221px;
      }
      #Select1 {
         width: 147px;
      }
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeader" runat="server">
   <asp:ScriptManager ID="asm" runat="server" />
   <table class="auto-style1">
      <tr>
         <td class="auto-style6">&nbsp;</td>
         <td class="auto-style5">
            <asp:ImageButton ID="ImageButton1" runat="server" Height="33px" ImageUrl="~/Images/carityLogo.png" Width="117px" />
         </td>
         <td style="text-align: left">
            <asp:Label ID="lblUsername" runat="server" Text="username"></asp:Label>
  
            <asp:HoverMenuExtender ID="lblUsername_HoverMenuExtender" runat="server" TargetControlID="lblUsername" PopupControlID="PopupMenu">
            </asp:HoverMenuExtender>
            <asp:Panel CssClass="popupMenu" ID="PopupMenu" runat="server">
               <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" Text="Edit" />
               <br />
               <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" Text="Delete" />
            </asp:Panel>
         </td>
      </tr>
   </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageDetails" runat="server">
</asp:Content>

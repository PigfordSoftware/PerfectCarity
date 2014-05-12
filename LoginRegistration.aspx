<%@ Page Title="Carity Login" Language="C#" MasterPageFile="~/CarityMaster.Master" AutoEventWireup="true" CodeBehind="LoginRegistration.aspx.cs" Inherits="PerfectCarity.LoginRegistration" %>
<%@ MasterType VirtualPath="~/CarityMaster.Master" %>

<asp:Content ID="loginHeader" runat="server" contentplaceholderid="cphHeader">
    <div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style6">
                    <asp:Image ID="Image1" runat="server" Height="37px" ImageUrl="~/Images/carityLogo.png" Width="109px" />
                </td>
                <td style="text-align: right; vertical-align: middle; padding-right: 20px;">
                    <asp:TextBox ID="txtUsername" runat="server" BorderStyle="Inset" Placeholder="Username"></asp:TextBox>
                    <asp:TextBox ID="txtPassword" runat="server" BorderStyle="Inset" Placeholder="Password" TextMode="Password"></asp:TextBox>
                    <asp:Button ID="loginButton" runat="server" BackColor="#009900" ForeColor="White" Text="Login" OnClick="loginButton_Click" />
                    <br />
                    <span class="auto-style7"><a href="ForgotPassword.aspx"><span class="auto-style8">Forgot Password</span></a>?</span><br />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style6 {
            width: 521px;
        }
        .auto-style7 {
            color: #FFFFFF;
            font-size: xx-small;
        }
        .auto-style8 {
            color: #FFFFFF;
        }
    </style>
</asp:Content>



<asp:Content ID="Content2" runat="server" contentplaceholderid="cphPageDetails">
    <table class="auto-style1">
        <tr>
            <td class="auto-style6" style="vertical-align: middle">&nbsp;&nbsp;This is Carity marketing infomation<br />
                anyone can user carity<br />
                it is fun and exciting.</td>
            <td>
                <br />
                <br />
                <asp:TextBox ID="txtRegEmailAddress" runat="server" Placeholder ="Email Address" Width="250px" style="margin-left: 0px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRegEmailAddress" runat="server" ControlToValidate="txtRegEmailAddress" ErrorMessage="Email Address Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:TextBox ID="txtRegUsername" runat="server" Placeholder="Username" ForeColor="Black" MaxLength="32" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRegUsername" runat="server" ControlToValidate="txtRegUsername" ErrorMessage="Username required" ForeColor="Red">*</asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:TextBox ID="txtRegPassword" runat="server" Placeholder="Password" MaxLength="32" Width="250px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRegPassword" runat="server" ErrorMessage="Enter new password" ForeColor="Red" ControlToValidate="txtRegPassword">*</asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:TextBox ID="txtRePassword" runat="server" MaxLength="32" Width="250px" style="margin-left: 0px" PlaceHolder="Confirm Password" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="cvPassword" runat="server" ControlToCompare="txtRegPassword" ControlToValidate="txtRePassword" ErrorMessage="Passwords do not mrry" ForeColor="Red">*</asp:CompareValidator>
                <br />
                <br />
                <asp:DropDownList ID="ddlSecurityQuest1" runat="server" Placeholder="1st Security Question" Width="250px" AppendDataBoundItems="True">
                    <asp:ListItem Text="--Select Security Question 1--" Value ="0"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvDDQuestion1" runat="server"  ErrorMessage="Security Question 1 must be selected." ForeColor="Red" ControlToValidate="ddlSecurityQuest1" InitialValue="0">*</asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:TextBox ID="txtAnswer1" runat="server" Placeholder="1st Answer" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAnswer1" runat="server" ControlToValidate="txtAnswer1" ErrorMessage="a" ForeColor="Red">*</asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:DropDownList ID="ddlSecurityQuest2" runat="server" Placeholder="2nd Security Question" Width="250px" AppendDataBoundItems="True">
                    <asp:ListItem Text="--Select Security Question 2--" Value ="0"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvDDQuestion2" runat="server" ControlToValidate="ddlSecurityQuest2" ErrorMessage="Please select 2nd security question." ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:TextBox ID="txtAnswer2" runat="server" Placeholder="2nd Answer" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAnswer2" runat="server" ControlToValidate="txtAnswer2" ErrorMessage="An answer is required from security question #2." ForeColor="Red">*</asp:RequiredFieldValidator>
                <br />
                <br />
                <span style="font-size:9.0pt;font-family:Calibri;
mso-ascii-font-family:Calibri;mso-fareast-font-family:+mn-ea;mso-bidi-font-family:
+mn-cs;color:#7F7F7F;mso-color-index:0;mso-font-kerning:12.0pt;language:en-US">By clicking Sign Up, you agree to our </span><span style="font-size:9.0pt;
font-family:Calibri;mso-ascii-font-family:Calibri;mso-fareast-font-family:+mn-ea;
mso-bidi-font-family:+mn-cs;color:#558ED5;mso-color-index:3;mso-font-kerning:
12.0pt;language:en-US;font-weight:bold">Terms</span><span style="font-size:
9.0pt;font-family:Calibri;mso-ascii-font-family:Calibri;mso-fareast-font-family:
+mn-ea;mso-bidi-font-family:+mn-cs;color:#7F7F7F;mso-color-index:0;mso-font-kerning:
12.0pt;language:en-US"> and that
                <br />
                you have read our </span><span style="font-size:9.0pt;font-family:Calibri;mso-ascii-font-family:Calibri;
mso-fareast-font-family:+mn-ea;mso-bidi-font-family:+mn-cs;color:#558ED5;
mso-color-index:3;mso-font-kerning:12.0pt;language:en-US;font-weight:bold">Data Use Policy<br />
                </span>
                <br />
                <asp:Button ID="registerButton" runat="server" BackColor="#009900" ForeColor="White" Text="Sign Up" OnClick="registerButton_Click" />
                <br />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>





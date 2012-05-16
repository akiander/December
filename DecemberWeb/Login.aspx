<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DecemberWeb.Login" Title="December Login Page" %>
<%@ Register src="Controls/Login.ascx" tagname="Login" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div>
        <table cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
            margin: 0px;">
            <tr>
                <td class="pageTitle">Login Page</td>
            </tr>
        </table>
   </div>
      <div>
        <table width="100%" cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
            margin: 0px;">
            <tr>
                <td style="text-align:left;" class="blockLeft">
                    <uc1:Login ID="Login1" runat="server" />
                    
                </td>
                
            </tr>
        </table>
    </div>
    
    <div>
        <table width="100%" cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
            margin: 0px;">
            <tr>
                <td style="text-align:left;" class="blockLeft">
                    <b>Not Registered Yet?</b> <a href="Register.aspx">Create an account!</a>
                    
                </td>
                
            </tr>
        </table>
    </div>
   
    
    
   
    

</asp:Content>

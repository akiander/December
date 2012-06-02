<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DecemberWeb._Default" Title="December Home Page" %>
<%@ Register src="Controls/Login.ascx" tagname="Login" tagprefix="uc1" %>
<%@ Register src="Controls/RandomQuoteViewer.ascx" tagname="RandomQuoteViewer" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <div>
        <table cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
            margin: 0px;">
            <tr>
                <td class="pageTitle">Home Page</td>
            </tr>
        </table>
   </div>

 <asp:LoginView id="LoginView_DefaultPage" runat="server">
    <AnonymousTemplate>
    
    <uc2:RandomQuoteViewer ID="RandomQuoteViewer1" runat="server" UseGlobalQuoteList="true" /> 
    
    <div>
        <table width="100%" cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
            margin: 0px;">
            <tr>
                <td class="blockFullLength">
                    Welcome to the December Project. This site will allow users to <b>create, manage and share a quote collection.         
                </td>
                
            </tr>
        </table>
    </div>
    <div>
        <table width="100%" cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
            margin: 0px;">
            <tr>
                <td style="text-align:left;" class="blockFullLength">
                    <uc1:Login ID="Login1" runat="server" DestinationPageAddress="../Secure/Default.aspx" />
                    
                </td>
                
            </tr>
        </table>
    </div>
                        
    <div>
        <table width="100%" cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
            margin: 0px;">
            <tr>
                <td style="text-align:left;" class="blockFullLength">
                    <b>Not Registered Yet?</b> <a href="Register.aspx">Create an account!</a>
                    
                </td>
                
            </tr>
        </table>
    </div>
    
    
                         
     
    </AnonymousTemplate>

    <LoggedInTemplate>
         
    <div>
        <table width="100%" cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
            margin: 0px;">
            <tr>
                <td style="" class="blockFullLength">
                    <b>Welcome back!</b> <a href="Secure/Default.aspx">Click here</a> to go to your quote collection.
                </td>
                
            </tr>
        </table>
    </div> 
        
        
    </LoggedInTemplate>
</asp:LoginView>


</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DecemberWeb.Default" 
Title="December My Quotes Page" %>

<%@ Register src="../Controls/RandomQuoteViewer.ascx" tagname="RandomQuoteViewer" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <table cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
            margin: 0px;">
            <tr>
                <td class="pageTitle">My Control Panel</td>
            </tr>
        </table>
   </div>
   
   <uc1:RandomQuoteViewer ID="RandomQuoteViewer1" runat="server" />
    <div>
        <table width="100%" cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
            margin: 0px;">
            <tr>
                <td style="height: 100px;cursor:pointer;" class="blockLeft" 
                    onclick="javascript:document.location = '/dec/secure/quotelist.aspx';">
                    <input type="button" class="button" value="My Quotes" />
                </td>
                <td style="height: 100px;cursor:pointer;" class="blockRight" 
                    onclick="javascript:document.location = '/dec/secure/categories.aspx';">
                    <input type="button" class="button" value="My Categories" />
                </td>
            </tr>
        </table>
    </div>
    
    
    
</asp:Content>

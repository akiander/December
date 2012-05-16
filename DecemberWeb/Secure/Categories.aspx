<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="DecemberWeb.Categories" 
Title="December Categories Page" %>
<%@ Register src="../Controls/CategoryList.ascx" tagname="CategoryList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
            margin: 0px;">
            <tr>
                <td class="pageTitle">My Categories</td>
            </tr>
        </table>
   </div>
    <uc1:CategoryList ID="CategoryList1" runat="server" />
</asp:Content>

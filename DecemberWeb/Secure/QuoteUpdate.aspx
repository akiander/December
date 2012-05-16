<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuoteUpdate.aspx.cs" Inherits="DecemberWeb.QuoteUpdate" Title="December Quote Update Page" %>
<%@ Register src="../Controls/CategoryUpdateControl.ascx" tagname="CategoryUpdateControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <uc1:CategoryUpdateControl ID="CategoryUpdateControl1" runat="server" />
    <br />
     If finished: <a href="QuoteList.aspx">Return to My Quotes page</a>.
    <br />
</asp:Content>

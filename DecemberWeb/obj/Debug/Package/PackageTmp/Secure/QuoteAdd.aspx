<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuoteAdd.aspx.cs" Inherits="DecemberWeb.QuoteAdd" 
Title="December Add Quote Page" %>
<%@ Register src="../Controls/QuoteAddControl.ascx" tagname="QuoteAdder" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:QuoteAdder ID="QuoteAdder1" runat="server" />
</asp:Content>

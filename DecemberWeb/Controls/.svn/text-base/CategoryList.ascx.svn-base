<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="DecemberWeb.Controls.CategoryList" %>
<asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" >
    <AlternatingItemTemplate>                
        <span class="quoteList">
            <a style="color:White;" href='QuoteList.aspx?s=<%# Eval("Text") %>'><%# Eval("Text") %></a>
        </span>
    </AlternatingItemTemplate>
    <ItemTemplate>
            <span class="quoteList">
                <a style="color:Silver;" href='QuoteList.aspx?s=<%# Eval("Text") %>'><%# Eval("Text") %></a>
            </span>
        </ItemTemplate>
    <LayoutTemplate>
        <div>
            <table width="100%" cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
                margin: 0px;">
                <tr>
                    <td class="blockLeft">
                        <div id="itemPlaceholderContainer" runat="server">
                            <span id="itemPlaceholder" runat="server" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </LayoutTemplate>
        <EmptyDataTemplate>
            <div>
            <table width="100%" cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
                margin: 0px;">
                <tr>
                    <td style="height: 100px; cursor: pointer;" class="blockLeft">
                        <span>There are no categories to display.</span>
                    </td>
                </tr>
            </table>
        </div>
            
        </EmptyDataTemplate>
        
</asp:ListView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetCategoryList" TypeName="DecemberWeb.Wrappers.QuoteListWrapper">
    </asp:ObjectDataSource>


<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuoteList.ascx.cs" Inherits="DecemberWeb.Controls.QuoteList" %>

    
<link href="../style/December.css" rel="stylesheet" type="text/css" />

    
<div>
    <table cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
        margin: 0px;">
        <tr>
            <td class="pageTitle">My Quotes</td>
        </tr>
    </table>
</div>
<div>
    <table width="100%" cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
        margin: 0px;">
        <tr>
            <td style="" class="blockFullLength">
                <span style="text-align:left;">
                    &nbsp;<asp:TextBox ID="txtSearch" CssClass="text" runat="server" style="width:250px;"></asp:TextBox>
                    <asp:Button ID="btnSearch" CssClass="button" Width="6em" runat="server" 
                    Text="Search" onclick="btnSearch_Click" />
                </span>
                <span>
                    <asp:DataPager ID="DataPager1" runat="server" PageSize="3" PagedControlID="ListView1">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowNextPageButton="true" ShowPreviousPageButton="true"
                                ShowFirstPageButton="true" ButtonCssClass="navbutton" ShowLastPageButton="true" />
                            <%--<asp:NumericPagerField ButtonType="Button" 
                                        NextPreviousButtonCssClass="navbutton" 
                                        NumericButtonCssClass="navbutton" 
                                         CurrentPageLabelCssClass="navbutton"
                                          ButtonCount="5" />--%>
                        </Fields>
                    </asp:DataPager>
                </span>
            </td>
        </tr>
    </table>
</div>

<asp:ListView ID="ListView1" runat="server" DataSourceID="myObjectDataSource" 
    InsertItemPosition="LastItem" OnItemInserting="ListView1_ItemInserting" >
    <ItemTemplate>
        <tr> 
            <td class="blockLeft">
                <asp:HiddenField ID="IdHiddenField" runat="server" Value='<%# Bind("Id") %>' />
                <asp:Label ID="TextLabel" CssClass="quoteList"  runat="server" Text='<%# Eval("Text") %>' />
                <asp:Label ID="CategoriesView" style="color:Silver" CssClass="quoteList" runat="server" Text='<%# Eval("CategoriesAsString") %>' />
            </td>
            <td class="blockMiddle">
                <asp:Label ID="AuthorLabel" style="color:White" CssClass="quoteList" runat="server" Text='<%# Eval("Author") %>' />
            </td>
            <td class="blockRight">
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                    Text="Edit" CssClass="button" Width="3em" />
                <asp:Button ID="deleteButton" CssClass="button" Width="4em" runat="server" 
                    OnClick="DeleteButtonInGrid_Click" CommandName='<%# Eval("Id") %>' Text='Delete' />
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr>
            
            <td class="blockLeft" >
                <asp:HiddenField ID="IdHiddenField" runat="server" Value='<%# Bind("Id") %>' />
                <asp:Label ID="TextLabel" CssClass="quoteList" runat="server" Text='<%# Eval("Text") %>' />
                <asp:Label ID="CategoriesView" style="color:Silver;" CssClass="quoteList" runat="server" Text='<%# Eval("CategoriesAsString") %>' />
            </td>
            <td class="blockMiddle">
                <asp:Label ID="AuthorLabel" style="color:White" CssClass="quoteList" runat="server" Text='<%# Eval("Author") %>' />
            </td>
            <td class="blockRight">
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                    Text="Edit" CssClass="button" Width="3em"  />
                <asp:Button ID="deleteButton" CssClass="button" Width="4em" runat="server" 
                    OnClick="DeleteButtonInGrid_Click" CommandName='<%# Eval("Id") %>' Text='Delete' />
                
            </td>
        </tr>
    </AlternatingItemTemplate>
    <LayoutTemplate>
        <table width="100%" cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
        margin: 0px;" class="quoteListTable">
            
            <tr runat="server" class="quoteListTableHeading">
                <th runat="server" class="blockLeft" style="width:60%">
                    Text</th>
                <th runat="server" class="blockMiddle" style="width:30%">
                    Author</th>
                <th runat="server" class="blockRight" style="width:10%">
                    <!-- Action Column --></th>
            </tr>
            <tr ID="itemPlaceholder" runat="server">
            </tr>
                    
        </table>
    </LayoutTemplate>
    <InsertItemTemplate>
        <tr>
            <td colspan="3"></td>
        </tr>
    </InsertItemTemplate>
    <SelectedItemTemplate>
        <tr>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </SelectedItemTemplate>
    
    <EditItemTemplate>
        <tr style="background-color:#FFF8DC;color:#FFFFFF;border-collapse:collapse;">
            <td class="blockLeft YellowBackground" >
                <asp:HiddenField ID="IdToEdit" runat="server" Value='<%# Bind("Id") %>' />
                <asp:TextBox ID="QuoteToEdit" TextMode="MultiLine" Rows="5" Width="95%" CssClass="text" runat="server" Text='<%# Bind("Text") %>' />
                <br />
                <br />
                <asp:TextBox ID="CategoryToEdit" Width="95%" CssClass="text" runat="server" Text='<%# Bind("CategoriesAsString") %>' />
                <act:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender_UpdateCategoryText" runat="server" 
                    TargetControlID="CategoryToEdit" 
                    WatermarkText="Enter Categories Here (comma-separated)"
                    WatermarkCssClass="watermarked">
                </act:TextBoxWatermarkExtender>
                <%--<asp:LinkButton ID="linkUpdateCategories" runat="server" Text="Update Categories" 
                    OnClick="UpdateCategories_Click" CommandName='<%# Eval("Id") %>'></asp:LinkButton>--%>
            </td>
            <td class="blockMiddle YellowBackground">
                <asp:TextBox ID="AuthorTextBox" TextMode="MultiLine"  Rows="5" Width="95%" CssClass="text" runat="server" Text='<%# Bind("Author") %>' />
            </td>
            <td class="blockRight YellowBackground">
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                    Text="Update"  CssClass="button" Width="5em" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                    Text="Cancel"  CssClass="button" Width="5em" />
                
            </td>
        </tr>
    </EditItemTemplate>
    </asp:ListView>
    <div style="text-align:right;"><asp:Label ID="RecordCount" runat="server"></asp:Label></div>
<asp:ObjectDataSource ID="myObjectDataSource" runat="server" 
    DataObjectTypeName="DecemberData.BusinessObjects.Quote"  
    DeleteMethod="DeleteQuote" InsertMethod="InsertQuote" 
    SelectMethod="GetQuotes" TypeName="DecemberWeb.Wrappers.QuoteListWrapper" 
    UpdateMethod="UpdateQuote">
        <selectparameters>
            <asp:querystringparameter name="searchText" querystringfield="s" defaultvalue="" />
          </selectparameters>
    </asp:ObjectDataSource>

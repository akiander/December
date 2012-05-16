<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryUpdateControl.ascx.cs"
    Inherits="DecemberWeb.Controls.CategoryUpdateControl" %>
<table border="0" width="480px">
    <tr>
        <td align="right">
        </td>
        <td>
            <asp:Label ID="CategoryToAddLabel" runat="server" AssociatedControlID="CategoryToAddText">Category To Add:</asp:Label><br />
            <nobr>
                <asp:TextBox ID="CategoryToAddText" runat="server" CssClass="text"></asp:TextBox>
                <asp:Button ID="AddCategoryButton" ValidationGroup="AddCategory" runat="server" OnClick="AddCategoryButton_Click" CssClass="button" Text="Add" Width="3em" />
            </nobr>
        </td>
    </tr>
    <tr>
        <td align="right">
        </td>
        <td>
            <asp:RequiredFieldValidator ID="CategoryRequired" runat="server" ControlToValidate="CategoryToAddText"
                ErrorMessage="<br />Category Name is required." ToolTip="Category Name is required." 
                ValidationGroup="AddCategory" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="categoryToAddIsValid" runat="server"
                                    ControlToValidate="CategoryToAddText" 
                                    ErrorMessage="<br />The category you are adding has invalid characters."
                                    ToolTip="Category contains invalid characters." Display="Dynamic" 
                                    ValidationGroup="AddCategory" 
                                    ValidationExpression="^[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
            <br />
            <span id="ErrorMessages" runat="server" style="color:red;"></span>
        </td>
    </tr>
    <tr>
        <td align="right"></td>
        <td>
            <asp:ListView ID="ListView1" runat="server">
                 <ItemTemplate>
                    <tr>
                        <td style="padding:0.8em;">
                            <asp:Label ID="CategoryLabel" CssClass="quoteList" runat="server" Text='<%# Bind("Text") %>' />
                        </td>
                        <td style="padding:0.8em;">
                            <asp:Button ID="RemoveButton" runat="server" 
                                OnClick="RemoveButton_Click" CommandName='<%# Bind("Text") %>' 
                                Text="Remove" CssClass="button" Width="5em" />
                            
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table id="Table1" runat="server">
                        <tr id="Tr1" runat="server">
                            <td id="Td1" runat="server">
                                <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                    style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr id="Tr2" runat="server" style="background-color:#DCDCDC;color: #000000;">
                                        <th id="Th1" runat="server">
                                            Category</th>
                                        <th id="Th2" runat="server">
                                            Action</th>
                                        
                                    </tr>
                                    <tr ID="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </td>
    </tr>
</table>

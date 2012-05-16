<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="DecemberWeb.Controls.Login" %>

 <asp:Login ID="myLogin" runat="server" DestinationPageUrl="~/Secure/Default.aspx" >
        <LayoutTemplate>
            <table border="0" cellpadding="1" cellspacing="0" 
                style="border-collapse:collapse;">
                <tr>
                    <td>
                        <table border="0" cellpadding="0">
                            <tr>
                                <td align="left" colspan="2">
                                    <b>Log In</b>
                                    <br />
                                    </td>
                            </tr>
                            <tr>
                                <td align="right">
                                   
                                </td>
                                <td>
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Email 
                                    Address:</asp:Label>
                                    <br />
                                    <asp:TextBox ID="UserName" runat="server" CssClass="text"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                        ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                        ToolTip="User Name is required." ValidationGroup="myLogin">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    
                                </td>
                                <td>
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                    <br />
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="text"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                        ControlToValidate="Password" ErrorMessage="Password is required." 
                                        ToolTip="Password is required." ValidationGroup="myLogin">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <%--<tr>
                                <td colspan="2">
                                    <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2">
                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                                        ValidationGroup="myLogin" CssClass="button" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:Login>
<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs"
    Inherits="DecemberWeb.Register" Title="December Registration Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div>
        <table cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
            margin: 0px;">
            <tr>
                <td class="pageTitle">Register</td>
            </tr>
        </table>
   </div>
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" ContinueDestinationPageUrl="Secure/Default.aspx"
        NavigationButtonStyle-CssClass="button">
        <NavigationButtonStyle CssClass="button" />
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                <ContentTemplate>
                    <div>
                        <table width="100%" cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
                            margin: 0px;">
                            <tr>
                                <td style="height: 100px; cursor: pointer; text-align: left;" class="blockLeft">
                                    <table border="0" width="480px">
                                        <tr>
                                            <td align="left" colspan="2">
                                                Sign Up for Your New Account
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr id="userNameRow" runat="server" visible="false">
                                            <td align="right">
                                            </td>
                                            <td>
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User 
                                Name:</asp:Label><br />
                                                <asp:TextBox ID="UserName" runat="server" CssClass="text"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                            </td>
                                            <td>
                                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail Address:</asp:Label>
                                                <br />
                                                <asp:TextBox ID="Email" runat="server" CssClass="text"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                                    ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                            </td>
                                            <td>
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label><br />
                                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="text"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                            </td>
                                            <td>
                                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label><br />
                                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" CssClass="text"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                                    ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required."
                                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                &nbsp;
                                                <!-- spacer row -->
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                The following section is <b>optional</b> but it will help you retrieve your account
                                                password if you forget it or lose it.
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                            </td>
                                            <td>
                                                <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Security 
                                Question (optional):</asp:Label><br />
                                                <asp:TextBox ID="Question" runat="server" CssClass="text"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                                    ErrorMessage="Security question is required." ToolTip="Security question is required."
                                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                            </td>
                                            <td>
                                                <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security 
                                Answer (optional):</asp:Label><br />
                                                <asp:TextBox ID="Answer" runat="server" CssClass="text"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                                    ErrorMessage="Security answer is required." ToolTip="Security answer is required."
                                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                                    ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                                    ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                                <asp:RegularExpressionValidator ID="emailValid" runat="server" ControlToValidate="Email"
                                                    ErrorMessage="<br />E-mail is invalid." ToolTip="Email is invalid." Display="Dynamic"
                                                    ValidationGroup="CreateUserWizard1" ValidationExpression="^[A-Za-z0-9._'%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2" style="color: Red;">
                                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                <ContentTemplate>
                    <table width="100%" cellpadding="0" cellspacing="0" style="border: 0px; padding: 0px;
                        margin: 0px;">
                        <tr>
                            <td style="height: 100px; cursor: pointer; text-align: left;" class="blockLeft">
                                <table border="0">
                                    <tr>
                                        <td align="left" colspan="2">
                                            <br />
                                            <b>Congratulations!</b>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            Your account has been successfully created.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <br />
                                            <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue"
                                                CssClass="button" Text="Login" ValidationGroup="CreateUserWizard1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    </div>
                </ContentTemplate>
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>

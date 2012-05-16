<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuoteAddControl.ascx.cs"
    Inherits="DecemberWeb.Controls.QuoteAddControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<script type="text/javascript">
        
        function onOk() {
            //Do nothing for now
        }
        
        // Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
            //$addHandler($get("showModalPopupClientButton"), 'click', showModalPopupViaClient);
            //$addHandler($get("hideModalPopupViaClientButton"), 'click', hideModalPopupViaClient);        
        }
        
        function showModalPopupViaClient(ev) {
            ev.preventDefault();
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.show();
        }
        
        function hideModalPopupViaClient(ev) {
            ev.preventDefault();        
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.hide();
        }
</script>
<asp:LinkButton ID="lnkOpenDialog" runat="server" Text="Add a Quote" />
<asp:Panel ID="pnlModalDialog" runat="server" Style="display: none" CssClass="modalPopup">
    <asp:Panel ID="pnlDragHandle" runat="server" Style="cursor: move; background-color: #DDDDDD;
        border: solid 1px Gray; color: Black">
        <div>
            <p>
                Enter Quote Details:</p>
        </div>
    </asp:Panel>
    <div>
        <asp:UpdatePanel ID="updatePanelInModalDialog" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <span id="quoteTable" runat="server">
                <table width="100%" class="quoteListTable">
                    <tr>
                        <td style="padding: 0.8em;">
                            <asp:TextBox ID="QuoteTextToInsert" Rows="3" TextMode="MultiLine" Width="90%" CssClass="text"
                                runat="server" />
                            <act:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender_InputQuoteText" runat="server"
                                TargetControlID="QuoteTextToInsert" WatermarkText="Enter Quote Text Here" WatermarkCssClass="watermarked">
                            </act:TextBoxWatermarkExtender>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="CategoryToInsert" TextMode="MultiLine" Width="90%" CssClass="text"
                                runat="server" />
                            <act:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender_InputCategoryText" runat="server"
                                TargetControlID="CategoryToInsert" WatermarkText="Enter Categories Here (comma-separated)"
                                WatermarkCssClass="watermarked">
                            </act:TextBoxWatermarkExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 0.8em;">
                            <asp:TextBox ID="AuthorToInsert" Rows="3" TextMode="MultiLine" Width="85%" CssClass="text"
                                runat="server" />
                            <act:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender_InputAuthorText" runat="server"
                                TargetControlID="AuthorToInsert" WatermarkText="Enter Author Here" WatermarkCssClass="watermarked">
                            </act:TextBoxWatermarkExtender>
                        </td>
                     </tr>
                    </table>
                </span>
                <span>
                    <table width="100%" class="quoteListTable">
                        <tr>
                            <td style="padding: 0.8em;color:Red;">
                                <asp:Label ID="lblAddQuoteFeedback" runat="server" Text=" "></asp:Label>
                            </td>
                        </tr>
                    </table>
                </span>
                <asp:Button ID="btnSave" CssClass="button" Width="4em" runat="server" OnClick="btnSave_Click"
                                    Text="Save" />
                
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    
    
    <asp:Button ID="btnOk" CssClass="button" Width="7em" runat="server" Text="Close Window" />
                                
    </div>
</asp:Panel>
<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" 
    TargetControlID="lnkOpenDialog"
    PopupControlID="pnlModalDialog" 
    BackgroundCssClass="modalBackground" 
    OkControlID="btnOk"
    OnOkScript="onOk()" 
    DropShadow="true"
    PopupDragHandleControlID="pnlDragHandle" />

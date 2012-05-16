<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RandomQuoteViewer.ascx.cs" Inherits="DecemberWeb.Controls.RandomQuoteViewer" %>

<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="primaryBackgroundColor blockFullLength">
                <div id="Div1" style="text-align: center; vertical-align: middle; padding: 12px; height:90%; color: #FFFFFF;  ">
                    <asp:Label ID="lblQuote" CssClass="singleQuoteView" Style="color: Black;" runat="server"></asp:Label>
                    &nbsp;
                    <asp:Label ID="lblAuthor" CssClass="singleQuoteView" runat="server"></asp:Label>
                    &nbsp;
                    <!--<span class="singleQuoteView" Style="color: Silver;" >(<asp:Label ID="lblCategories" runat="server"></asp:Label>)</span>-->
                    <span style="float: right;">
                        <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" CssClass="button"
                            Width="4em" Style="margin: 0.75em;" />
                    </span>
                    <asp:Timer ID="Timer1" runat="server" Interval="10000" OnTick="Timer1_Tick">
                    </asp:Timer>
                    <div style="clear: both;">
                    </div>
                    <div style="clear: both;">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>    
</div>
<%= Page.Form.DefaultButton %>

<act:UpdatePanelAnimationExtender ID="UpdatePanelAnimationExtender1" runat="server"
    TargetControlID="UpdatePanel1">
    <Animations>
        <OnUpdating>
            <Sequence>
                <%-- Fade out --%>
                <Parallel duration=".15" Fps="50">
                        <FadeOut AnimationTarget="up_container" minimumOpacity=".2" />
                          <%--<Color AnimationTarget="up_container" PropertyKey="backgroundColor"
                            EndValue="#FF0000" StartValue="#40669A" />--%>
                </Parallel>
            </Sequence>
        </OnUpdating>
        <OnUpdated>
            <Sequence>
                <%-- Do each of the selected effects --%>
                <Parallel duration=".15" Fps="50">
                         <FadeIn AnimationTarget="up_container" minimumOpacity=".2" />
                        <%--<Color AnimationTarget="up_container" PropertyKey="backgroundColor"
                            StartValue="#FF0000" EndValue="#40669A" />--%>
                </Parallel>
            </Sequence>
        </OnUpdated>
    </Animations>
</act:UpdatePanelAnimationExtender>
        
        
        

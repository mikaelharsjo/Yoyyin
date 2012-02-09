<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MultiMatcherControl.ascx.cs" Inherits="Yoyyin.Web.UserControls.MultiMatcherControl" %>
<%@ Import Namespace="Yoyyin.Web" %>

<%@ Register TagPrefix="yoyyin" TagName="UserImage" Src="~/UserControls/UserImage.ascx" %>
<h2>Matchande medlemmar</h2>
<div class="multipleMatchSummary">
    <div class="matchSummaryText"><asp:Literal ID="litMatchSummary" runat="server" /></div>
    <div class="matchSummaryPercentage"><asp:Literal ID="litMatchSummaryPercentage" runat="server" /></div>
    <br class="clear"/>
</div>

<asp:ListView ID="lstMatches" runat="server">
    <ItemTemplate>
        <div class='multipleMatchItem <%# Container.DataItemIndex%2 == 0 ? "odd" : "even" %>'>            
            <div class="multipleMatchImage">
                <yoyyin:UserImage ID="imageQuestion" runat="server" Width="50" User='<%# Eval("User") %>' />
            </div>
            <div class="multipleMatchDescription">            
                <%# Eval("Name") %>, <%# Eval("City") %><br />
                <a class="matchLink" data-id-userId='<%# Eval("UserId") %>'>Visa matching</a>
            </div>           
            <div class="multipleMatchPercentage">
                <%# Eval("Percentage") %>
            </div> 
            <br class="clear" />
        </div>
        
    </ItemTemplate>
</asp:ListView> 

<script type="text/javascript">
    $(".matchLink").click(function() {
        var currentUserId = '<%= Current.UserID %>';
        var userId = $(this).attr("data-id-userId");
        GetMatcher(currentUserId, userId);
    });
</script>
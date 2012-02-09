<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MatcherControl.ascx.cs" Inherits="Yoyyin.Web.UserControls.MatcherControl" %>
<%@ Register TagPrefix="yoyyin" TagName="UserImage" Src="~/UserControls/UserImage.ascx" %>

<h2>Matchningsresultat</h2>
<div id="matchFirstColumn">
    <yoyyin:UserImage ID="firstUserImage" runat="server" Width="50" />    
    <div class="matchUserNameContainer">
        <asp:Literal ID="litFirstUser" runat="server" />
    </div>    
</div>

<div id="matchSecondColumn">
    <yoyyin:UserImage ID="secondUserImage" runat="server" Width="50" />    
    <div class="matchUserNameContainer">
        <asp:Literal ID="litSecondUser" runat="server" />
    </div>    
</div>

<br class="clear" />

<div id="matchResult">
    <asp:Literal ID="litMatchResult" runat="server" />
</div>



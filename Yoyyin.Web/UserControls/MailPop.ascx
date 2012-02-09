<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MailPop.ascx.cs" Inherits="Yoyyin.Web.UserControls.MailPop" %>
<%@ Register Src="~/UserControls/UserImage.ascx" TagPrefix="yoyyin" TagName="UserImage" %>

<asp:HiddenField ID="hiddenToUserId" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hiddenFromUserId" runat="server" ClientIDMode="Static" />

<div class="padding">
    <div class="dialogHeader">
        <h2><asp:Literal ID="litHeader" runat="server" Text="Svara" /></h2>
        <img src="Styles/Images/fancy_close.png" alt="Stäng dialogen" class="dialogClose"
            onclick='$("#dialogMail").hide(); $("#popBg").hide();' /></div>
    <table class="mailPopTable">
        <tr valign="top" runat="server" id="tr1">
            <td colspan="2">
                Meddelande:&nbsp;
            </td>
        </tr>
        <tr runat="server" id="tr2">
            <td valign="top">
                <yoyyin:UserImage runat="server" ID="userImage" Width="70" />
            </td>
            <td class="paddingLeft">
                <asp:Literal ID="litMessage" runat="server" />
            </td>
        </tr>
        <tr runat="server" id="tr3"><td>&nbsp;</td></tr>
        <tr valign="top">
            <td colspan="2">
                <asp:Literal ID="litAnswer" runat="server" Text="Svara" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <textarea id="txtAnswer" rows="3" style="width: 350px;" />
            </td>
        </tr>
    </table>
    <button type="button" onclick="SendMail($('#hiddenFromUserId').val(), $('#hiddenToUserId').val(), $('#txtAnswer').val())">
        Skicka meddelandet</button>
    <button type="button" value="SKICKA" onclick="$('#dialogMail').hide(); $('#popBg').hide();">
            Stäng</button>

</div>

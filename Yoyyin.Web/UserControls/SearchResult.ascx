<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResult.ascx.cs" Inherits="Yoyyin.Web.UserControls.SearchResult" %>
<%@ Import Namespace="Yoyyin.Domain.Extensions" %>

<%@ Register Src="~/UserControls/UserImage.ascx" TagPrefix="yoyyin" TagName="UserImage" %>

<h3>Sökresulat</h3>
<asp:Literal ID="litCount" runat="server" />
<asp:ListView runat="server" ID="lstUsers" ItemPlaceholderID="divContent">
    <ItemTemplate>
        <tr>
            <td>
                <yoyyin:UserImage runat="server" UserID='<%# Eval("UserID") %>' Width="40" />
            </td>
            <td valign="top">
                <%# Eval("Name") %>
            </td>
            <td class="td">
                <strong><%# Eval("BusinessTitle") %></strong><br />
                <%# Eval("BusinessDescription").ToString().Truncate(100) %>
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table>
            <div id="divContent" runat="server" />
        </table>
    </LayoutTemplate>
</asp:ListView>
<div class="clear"><br /></div>
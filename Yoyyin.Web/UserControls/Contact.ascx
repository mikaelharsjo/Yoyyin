<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Contact.ascx.cs" Inherits="Yoyyin.Web.UserControls.Contact" %>
<%@ Import Namespace="Yoyyin.Web.Helpers" %>
<%--<%@ Register Src="~/UserControls/UserImage.ascx" TagPrefix="yoyyin" TagName="UserImage" %>--%>
<%@ Register Src="~/UserControls/Users.ascx" TagPrefix="yoyyin" TagName="Users" %>

<div class="marginBottom marginTop"><h2>Kontakta oss på Yoyyin</h2></div>

<yoyyin:Users ID="usersControl" runat="server" SrcUsers='<%# YoyyinOwners %>' />

<%--
<asp:ListView ID="lstMembers" runat="server" ItemPlaceholderID="divContent">
    <LayoutTemplate>
        <div id="divContent" runat="server" class="marginTop" />
    </LayoutTemplate>
    <ItemTemplate>
        <div class="left blueArrow">
            <a class='<%# WebHelpers.InaccesibleIfNotLoggedIn() %>' href='<%# "../Member.aspx?UserID=" + Eval("UserID") %>'>
                <yoyyin:UserImage runat="server" UserID='<%# Eval("UserId") %>' Width="90" />
            </a>
            <br />
            <a class='<%# WebHelpers.InaccesibleIfNotLoggedIn() %>' href='<%# "../Member.aspx?UserID=" + Eval("UserID") %>'>
                <%# WebHelpers.GetDisplayName(Eval("UserId")) %></a>
        </div>
        <div class="blueBox left" style="width: 770px;">
            <div>
                <h4><%# Eval("BusinessTitle") %></h4>
                <p>
                    <%# Eval("BusinessDescription") %>
                    <br /><a href='<%# "Member.aspx?UserID=" + Eval("UserID") %>'>Visa Yoyyin-profil</a>
                </p>
            </div>
        </div>
        <div class="extra">&nbsp;</div>
    </ItemTemplate>
</asp:ListView>
--%>
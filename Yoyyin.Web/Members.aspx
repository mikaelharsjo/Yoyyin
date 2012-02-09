<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Members.aspx.cs" Inherits="Yoyyin.Web.Members" EnableViewState="false" %>

<%@ Import Namespace="Yoyyin.Web" %>
<%@ Register Src="~/UserControls/Users.ascx" TagPrefix="yoyyin" TagName="Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        h4
        {
            font-family: Palatino Linotype, Book Antiqua, Georgia, Serif;
            font-size: 1.6em;
            line-height: 1.5em;
            margin-bottom: 0.7em;
            color: #484848;
            font-weight: bold;
        }
    </style>
    <h1>
        Affärspartners & branscher</h1>
    <p>
        Nedan visas alla registrerade affärspartners eller affärsidéer. Dom är grupperade
        efter branschtillhörighet.</p>
    <asp:ListView ID="lstSniHeads" runat="server" ItemPlaceholderID="divContent">
        <LayoutTemplate>
            <div id="divContent" runat="server" class="marginTop" />
        </LayoutTemplate>
        <ItemTemplate>
            <div class="segment paddingLeft marginBottom sni<%# Eval("SniHeadID")  %>">
                <%# Eval("Title") %></div>
            <%--<strong><%# Eval("SniItemTitle")%></strong><br /><br />--%>
            <yoyyin:Users runat="server" SrcUsers='<%# Eval("User") %>' />
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContentAfterJavaScriptIncluded">
    <script>
        $(document).ready(function () {
            $(".matchLink").click(function () {
                var currentUserId = '<%= Current.UserID %>';
                var userId = $(this).attr("data-id-userId");
                GetMatcher(currentUserId, userId);
            });
        });
    </script>
</asp:Content>

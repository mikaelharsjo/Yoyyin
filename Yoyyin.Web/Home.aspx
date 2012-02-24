<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableViewState="false"
    CodeBehind="Home.aspx.cs" Inherits="Yoyyin.Web.Home" %>
<%@ Import Namespace="Yoyyin.Web.Helpers" %>
<%@ Register Src="~/UserControls/UserImage.ascx" TagPrefix="yoyyin" TagName="UserImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        input[type=text]
        {
            width: 100px;
            height: 15px;
        }
    </style>
    <div class="span-24 last">
        <div class="span-6">
            <div>
                <div class="blueBox">
                    <div class="marginTop marginBottom textAlignCenter">
                        <yoyyin:UserImage runat="server" Width="185" />
                    </div>
                    <h3 class="h3">Dina kontakter</h3>
                    <div>
                        <div class="friendsContainer">
                            <asp:ListView ID="lstBookmarks" runat="server" ItemPlaceholderID="divContent">
                                <LayoutTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="1" style="border-collapse: collapse;">
                                        <div id="divContent" runat="server" />
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr id='div<%# Eval("BookmarkedUser.UserId")%>'>
                                        <td valign="middle">
                                            <yoyyin:UserImage runat="server" User='<%# Eval("BookmarkedUser") %>' Width="40" />
                                        </td>
                                        <asp:Image runat="server" ImageUrl='<%# Eval("OnlineImageUrl") %>'
                                            Visible="false" />&nbsp;
                                        <td valign="middle">
                                            <div class="friendItem">
                                                <a href='<%# Eval("ProfileUrl") %>'>
                                                    <%# Eval("DisplayName") %>    
                                                </a>
                                        </td>
                                        <td valign="top" align="right">
                                            <a class="lnkDeleteBookmark right" title="Ta bort kontakten" bookmarkeduserid='<%# Eval("BookmarkedUser.UserId") %>'>
                                                <img src="Styles/Images/cross.png" /></a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <i>Inga kontakter.</i>
                                </EmptyDataTemplate>
                            </asp:ListView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="span-12">
            <div id="tabs">
                <ul>
                    <li><a href="#tab-1">Matchande medlemmar</a></li>
                    <li><a href="#tab-2">Inkorg</a></li>
                    <li><a href="#tab-3">Skickat</a></li>
                    <li><a href="#tab-4">Ställ en fråga</a></li>
                </ul>
                <div id="tab-1">Matchning pågår...</div>
                <div id="tab-2">
                    <div class="marginBottom">
                        <div class="paddingBottomSmall">
                            <asp:ListView ID="lstMessages" runat="server" ItemPlaceholderID="divContent">
                                <LayoutTemplate>
                                    <table id="tblMessages" width="100%" cellpadding="5px" class="tblMail">
                                        <thead>
                                            <tr class="padding blueBg">                                                
                                                <th>
                                                    Från:
                                                </th>                                                
                                                <th>
                                                    Datum/Meddelande:
                                                </th>
                                            </tr>
                                        </thead>
                                        <div id="divContent" runat="server" />
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr class="whiteBg" valign="top">
                                        <td class="smallTD"><span style="display:none;"><%# Eval("Date") %></span> 
                                            <yoyyin:UserImage runat="server" UserID='<%# Eval("FromUserId") %>' Width="50" />
                                        </td>
                                        <td class="smallTD">
                                            <strong><a onclick='PopMail(<%# Eval("UserMessagesID") %>, "<%# CurrentUser.UserId %>", "<%# Eval("FromUserId") %>")'>
                                                <%# Eval("DisplayName") %>
                                            </a></strong>
                                            <a onclick='PopMail(<%# Eval("UserMessagesID") %>, "<%# CurrentUser.UserId %>", "<%# Eval("FromUserId") %>")'>
                                                <%# Eval("Date")%></a><br />
                                            <a onclick='PopMail(<%# Eval("UserMessagesID") %>, "<%# CurrentUser.UserId %>", "<%# Eval("FromUserId") %>")'>
                                                <%# Eval("MessageShort") %>
                                            </a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </div>
                </div>
                <div id="tab-3">
                    <div class="paddingBottomSmall">
                        <asp:ListView ID="lstMessagesSent" runat="server" ItemPlaceholderID="divContent"
                            class="tblMail">
                            <LayoutTemplate>
                                <table>
                                    <tbody>
                                        <th>
                                            Till:
                                        </th>
                                        <th>
                                            Datum:
                                        </th>
                                        <th>
                                            Meddelande:
                                        </th>                                    
                                        <div id="divContent" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="smallTD">
                                        <%--<a onclick='PopMail(<%# Eval("UserMessagesID") %>, "<%# Eval("FromUserId") %>", "<%# CurrentUser.UserId %>")'>--%>
                                        <%# Eval("ToDisplayName") %>
                                        <%--</a>--%>
                                    </td>
                                    <td class="smallTD">
                                        <%--<a onclick='PopMail(<%# Eval("UserMessagesID") %>, "<%# Eval("FromUserId") %>", "<%# CurrentUser.UserId %>")'>--%>
                                        <%# Eval("Date")%>
                                        <%--</a>--%>
                                    </td>
                                    <td class="smallTD">
                                        <%--<a onclick='PopMail(<%# Eval("UserMessagesID") %>, "<%# Eval("FromUserId") %>", "<%# CurrentUser.UserId %>")'>--%>
                                        <%# Eval("MessageShort") %>
                                        <%--</a>--%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <i>Inga meddelanden.</i>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </div>
                </div>
                <div id="tab-4">
                    <div class="paddingRight blueBox">
                        <h3>
                            Ställ en fråga eller testa en affärsidé.</h3>
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 60px;" valign="top" id="tdForumImage" runat="server">
                                    <yoyyin:UserImage runat="server" Width="50" />
                                </td>
                                <td valign="top">
                                    <textarea id="txtForumQuestion" rows="3" cols="80" style="width: 100%;" onfocus="this.rows=6"></textarea>
                                </td>
                            </tr>
                        </table>
                        <button runat="server" id="btnPostQuestionToForum" runat="server" clientidmode="Static">
                            Fråga</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="span-6 last">
            <div class="blueBox marginBottom">
                <h3>Bjud in en vän!</h3>
                <i>Yoyyin är för närvarande i stängt betaläge. Du som betatestare har däremot möjligheten att bjuda in vänner som du tror är intresserade av tjänsten.</i>
                <br />
                <input id="emailInite" type="email" value="Din väns e-postadress" class="inviteTextBox disabled" onfocus="this.disabled = false; searchBoxFocus(this, 'Din väns e-postadress');" onblur="searchBoxBlur(this, 'Din väns e-postadress');" /><br />
                <button id="btnSendInvite" class="marginTopSmall button green" onclick="return false;">Skicka inbjudan</button>
                <p id="pInfo" class="greenText"></p>
            </div>

            <div id="divLastQuestions" style="font-size: 0.9em; padding-left: 5px;"></div>
        </div>
    </div>
    <br />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentAfterJavaScriptIncluded"
    runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#tabs').tabs();

            ExecuteAjax(["controlName", "LatestPosts"], "LoadControl", function (data) { $("#divLastQuestions").html(data.d); }, OnError);
            MakeAjaxCall("LoadControl", { controlName: "MultiMatcherControl" }, function(data) { $("#tab-1").html(data); }, OnError);

            $(".lnkDeleteBookmark").click(function () {
                var BookmarkedUserID = $(this).attr("BookmarkedUserID");
                MakeAjaxCall("DeleteBookmark", { bookmarkUserID: BookmarkedUserID }, function () {
                    alert("Kontakten är borttagen.");
                    $("#div" + BookmarkedUserID).hide();
                }, OnError);
            });

            $("#btnSendInvite").click(function () {
                ExecuteAjax(["email", $("#emailInite").val(), "from", '<%= CurrentUser.Name %>', "fromEmail", '<%= CurrentEmail %>'], "SendInvite", function () { $("#pInfo").html("Din inbjudan har skickats"); }, function () { alert("Inbjudan kunde inte skickas, vänligen kontroller e-postadressen"); });
                return false;
            });
        });
    </script>
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LatestPosts.ascx.cs" Inherits="Yoyyin.Web.UserControls.LatestPosts" %>
<h3>Senaste frågorna</h3>
    <asp:ListView ID="lstForum" runat="server" ItemPlaceholderID="divContent">
        <LayoutTemplate>
            <ul class="latestQuestions">
                <div id="divContent" runat="server" />
            </ul>    
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <a class="lnkQuestion" href='<%# "Question.aspx?QuestionId=" + Eval("ID") %>'><%# Eval("ShortText") %></a> av <%# Eval("DisplayName") %><br/>
                <%# Eval("Date") %>
            </li>
        </ItemTemplate>
    </asp:ListView>

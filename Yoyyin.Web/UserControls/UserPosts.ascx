<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserPosts.ascx.cs" Inherits="Yoyyin.Web.UserControls.UserPosts" %>

<asp:ListView ID="lstQuestions" runat="server" ItemPlaceholderID="divContent">
        <LayoutTemplate>
            <h3 class="h3">Frågor & Svar</h3>
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

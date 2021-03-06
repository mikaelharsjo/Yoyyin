﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="Yoyyin.Web.QuestionPage" %>
<%@ Register TagPrefix="yoyyin" TagName="Question" Src="~/UserControls/Question.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="questionsBreadCrumbContainer">
        <a href="Questions.aspx">Diskutera</a> / <a id="lnkCategory" runat="server"></a> / <strong><asp:Literal ID="litBreadCrumb" runat="server" /></strong>
    </div>
    <button id="btnAnswerDialog" class="questionsButton" onclick="return false;" runat="server" runat="server" ClientIDMode="Static">Svara på frågan</button>

    <div id="holderForQuestionControl"></div>

    <div class="span-24 last">&nbsp;</div>
    <div id="divAnswerWhenLoggedIn" runat="server" class="span-24 last marginTopLarge">
        <h3>Ditt svar/kommentar</h3>
        <textarea id="txtAnswer" rows="4" cols="20" style="width: 930px;"></textarea>
        <div class="marginTop">
            <button id="btnAnswer" onclick="return false;">Skicka ditt svar</button>
        </div>
        <br/>
    </div>
    <br class="clear" />
    <div id="divAnswerWhenNotLoggedIn" class="infoNotMember" runat="server">
        <p>För att svara krävs att man är registrerad och inloggad.</p>
        <%--<p>Att bli medlem går snabbt och är gratis. Efter registreringen blir du också själv sökbar för framtida affärspartners.</p><a href='Register.aspx'>Klicka för att bli medlem</a> eller<br/><a id='lnkLogin' onclick='ShowLogin();'>Logga in</a> om du redan är det.")        --%>
    </div>
    <br class="clear" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContentAfterJavaScriptIncluded">
    <script type="text/javascript">
        $(document).ready(function () {
            var dictionary = new Array();
            dictionary[0] = AddJSONItem("QuestionId", <%= QuestionID %>);
            
            GetQuestionAnswers(dictionary);
            
            $("#btnAnswer").click(function () {
                MakeAjaxCall("AddAnswer", { text: $("#txtAnswer").val(), questionId: <%= QuestionID %> }, function() { GetQuestionAnswers(dictionary); });
            });

            $("#btnAnswerDialog").click(function() {
                MakeAjaxCall("LoadControlWithParams", { controlName: "NewAnswer", dictionary: dictionary }, function (data) { ShowQuestionDialog(data); });
            });
        });
    </script>
</asp:Content>
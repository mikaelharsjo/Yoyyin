<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewAnswer.ascx.cs" Inherits="Yoyyin.Web.UserControls.NewAnswer" %>
<h2>Skriv svaret nedan!</h2>
<textarea id="txtAnswerDialog" rows="3" cols="2" style="width: 360px;">
</textarea>
<div class="marginTop">
    <button type="button" id="btnSaveAnswerDialog">Spara</button> 
</div>

<script type="text/javascript">
    $("#btnSaveAnswerDialog").click(function () {
        var dictionary = new Array();
        dictionary[0] = AddJSONItem("QuestionId", <%= QuestionId %>);

        MakeAjaxCall("AddAnswer", { text: $("#txtAnswerDialog").val(), questionId: <%= QuestionId %> }, function() { EnableBackground(); GetQuestionAnswers(dictionary); });
    });
</script>


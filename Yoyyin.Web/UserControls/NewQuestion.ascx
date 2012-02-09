<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewQuestion.ascx.cs" Inherits="Yoyyin.Web.UserControls.NewQuestion" %>
<h2>Fråga på!</h2>
<input id="txtTitle" type="text" />
<textarea id="txtQuestionDialog" rows="3" cols="2" style="width: 360px;">
</textarea>
<div class="marginTop">
    <button type="button" id="btnSaveQuestion">Spara</button> 
</div>

<script type="text/javascript">
    $("#btnSaveQuestion").click(function () {
        MakeAjaxCall("AddQuestion", {title: $("#txtTitle").val(), text: $("#txtQuestionDialog").val(), category: <%= Category %>}, function() { EnableBackground(); location.href=location.href; });
    });
</script>


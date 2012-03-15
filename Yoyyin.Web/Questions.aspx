<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Questions.aspx.cs" Inherits="Yoyyin.Web.Questions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h1>Diskutera och ställ frågor om affärsidéer och företagande</h1>
<p>Här kan du få svar på frågor eller diskutera affärsidéer med andra medlemmar. Vi har grupperat frågorna enligt nedan.</p>
<table style="width: 100%;">
    <tr class="marginBottomLarge">
        <td><a href="Category.aspx?Category=0"><div class="imageBorder forumImage1">&nbsp;</div></a></td>        
        <td class="paddingLeftLarge verticalAlignTop" valign="top">
            <a href="Category.aspx?Category=0"><h2 class="h2">Affärsidéer</h2></a><p>Duger din affärsidé? Vill du läsa om andras? Kom in och dela med dig av dina idéer, och få feedback på dom från andra medlemmar. <a href="Category.aspx?Category=0">Visa alla affärsidéer</a><br />
            Senaste: <asp:Literal ID="litLastQuestionIdea" runat="server" />
            </p>
            
            <p><button class="btnQuestion" runat="server" id="btn1" data-category-id="0" onclick="return false;">Ställ en fråga om affärsidéer</button></p>
        </td>
    </tr>
    <tr class="marginBottomLarge">
        <td><a href="Category.aspx?Category=1"><div class="imageBorder forumImage2">&nbsp;</div></a></td>        
        <td class="paddingLeftLarge"><a href="Category.aspx?Category=1"><h2 class="h2">Snälla forumet, positiv kritik av affärsidéer</h2></a>
            <p>Här behöver inte affärsidéen vara hundra genomtänkt. Feedbacken ska vara positiv. Försök gärna förbättra affärsidéerna men säg inte att dom är dåliga. <a href="Category.aspx?Category=1">Visa affärsidéer i snälla forumet</a><br />
            Senaste: <asp:Literal ID="litLastQuestionFriendly" runat="server" />
            </p>
            <p><button id="btn2" runat="server" class="btnQuestion" data-category-id="1" onclick="return false;">Testa din affärsidé, hur tokig den än är</button></p>
        </td>
    </tr>
    <tr class="marginBottomLarge">
        <td><a href="Category.aspx?Category=2"><div class="imageBorder forumImage3">&nbsp;</div></a></td>        
        <td class="paddingLeftLarge"><a href="Category.aspx?Category=2"><h2 class="h2">Övriga frågor</h2></a>
            <p>Här kan du ställa valfria frågor kring t ex företagande, uppstart, affärsplan, partnerskap mm. <a href="Category.aspx?Category=2">Visa alla övriga frågor</a><br />
            Senaste: <asp:Literal ID="litLastQuestionBusiness" runat="server" />
            </p>
            <p><button runat="server" id="btn3" class="btnQuestion" data-category-id="2" onclick="return false;">Fråga nästan vad som helst</button></p>
        </td>
    </tr>
</table>
<br />
<br />

<div id="newQuestion" style="display: none;">
    <label for="txtTitle">Rubrik:</label><br/><input id="txtTitle" type="text" class="dialogInput" /><br/><br/>
    <label for="txtQuestionDialog">Fråga:</label><br/>
    <textarea id="txtQuestionDialog" rows="3" cols="2" class="dialogInput">
    </textarea>
    <div class="marginTop">
        <button type="button" id="btnSaveQuestion">Spara</button> 
    </div>
</div>


</asp:Content>
<asp:Content ContentPlaceHolderID="MainContentAfterJavaScriptIncluded" runat="server">
<script type="text/javascript">
    $(document).ready(function () {
        $(".btnQuestion").click(function () {
            //var category = $(this).attr("data-category-id");
            //var dictionary = new Array();
            //dictionary[0] = AddJSONItem("Category", category);
            //MakeAjaxCall("LoadControlWithParams", { controlName: "NewQuestion", dictionary: dictionary }, function (data) { ShowQuestionDialog(data); });
            $("#newQuestion").dialog({ title: "Fråga på" });
        });

        $("#btnSaveQuestion").click(function () {
            $.ajax({
                url: '/Question/Add',
                type: 'POST',
                cache: false,
                data: { Title: $("#txtTitle").val(), Text: $("#txtQuestionDialog").val() },
                success: function (data) {
                    alert(data);
                }
            });

        });
    });    
</script>
</asp:Content>

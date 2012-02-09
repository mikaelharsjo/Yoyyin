<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Question.ascx.cs" Inherits="Yoyyin.Web.UserControls.QuestionControl" %>
<%@ Import Namespace="Yoyyin.Web.Helpers" %>
<%@ Register TagPrefix="yoyyin" TagName="UserImage" Src="~/UserControls/UserImage.ascx" %>

<div class="span-24 marginTop marginBottom last">
    <div class="left blueArrow">                                        
        <yoyyin:UserImage ID="imageQuestion" runat="server" Width="80" />                    
    </div>
    <div class="blueBox left" style="width: 770px;">
        <div>
            <asp:Literal ID="litOwner" runat="server" />
            <a id="deleteLinkQuestion" runat="server" ClientIDMode="Static" class="deleteLink" data-itemName="frågan" title="Ta bort den här frågan"><img src="../Styles/Images/cross.png" /></a>
            <br />
            <asp:Literal ID="litQuestion" runat="server" />            
        </div>
    </div>                
</div>
<br class="clear" />
<h3 class="answerHeading">Svar:</h3>
<div class="answers">
    <asp:ListView ID="lstAnswers" runat="server" ItemPlaceholderID="divContent">
        <LayoutTemplate>
            <div id="divContent" runat="server"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="answer">
                <div class="answerImage">                                        
                    <yoyyin:UserImage ID="imageQuestion" runat="server" Width="60" UserID='<%# Eval("UserId") %>' />                    
                </div>
                <div class="answerBubble">
                    <div>
                        <%# WebHelpers.FormatHeading(Eval("DisplayName").ToString(), Eval("Date").ToString()) %>
                        <a class="deleteLinkInAnswer" data-itemName="svaret" data-answerId='<%# Eval("AnswerId") %>' runat="server" Visible='<%# Eval("DeleteAllowed") %>'><img src="../Styles/Images/cross.png" /></a> 
                        <br />
                        <%# Eval("Text") %>
                    </div>
                </div> 
                <br class="clear" />
            </div>                           
        </ItemTemplate>
        <EmptyDataTemplate>
            Bli först att besvara eller kommentera den här frågan!
        </EmptyDataTemplate>
    </asp:ListView>
</div>

<script>
    $("#deleteLinkQuestion").click(function () {
        var itemName = $(this).attr("data-itemName");
        var questionId = '<%= QuestionId %>';
        if (confirm("Är du säker att du vill ta bort den här " + itemName)) {
            MakeAjaxCall("DeleteQuestion", { questionId: questionId }, function () { ShowDialogTemporarily("Hela den här frågan är nu borttagen"); }, OnError);
        }
    });

    $(".deleteLinkInAnswer").click(function () {
        var itemName = $(this).attr("data-itemName");
        var answerId = $(this).attr("data-answerId");
        if (confirm("Är du säker att du vill ta bort det här " + itemName)) {
            MakeAjaxCall("DeleteAnswer", { answerId: answerId },
                function () {
                    ShowDialogTemporarily("Svaret är borttaget");
                    var dictionary = new Array(AddJSONItem("QuestionId", <%= QuestionId %>));
                    GetQuestionAnswers(dictionary);
                }, 
                OnError);
        }
    });
</script>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Yoyyin.Web.CategoryPage" %>
<%@ Register TagPrefix="yoyyin" TagName="UserImage" Src="~/UserControls/UserImage.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="questionsBreadCrumbContainer">
        <a href="Questions.aspx">Diskutera</a> / <asp:Literal ID="lnkCategory" runat="server" />
    </div>
    <button id="btnQuestion" class="right" runat="server" onclick="return false;" ClientIDMode="Static">Ställ en ny fråga</button>
    
    <asp:ListView ID="lstQuestions" runat="server" ItemPlaceholderID="trContent">
        <LayoutTemplate>
            <table>
                <thead>
                    <tr>
                        <th></th>
                        <th></th>                        
                        <th style="width: 80px;">Antal svar</th>
                    </tr>
                </thead>

                <tr runat="server" id="trContent"></tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td class="verticalAlignTop">
                    <yoyyin:UserImage ID="userImageLoggedIn" runat="server" Width="60" UserID='<%# Eval("UserId") %>' />
                </td>
                <td class="verticalAlignTop"><a href='Member.aspx?UserID=<%# Eval("UserId") %>'><%# Eval("DisplayName") %></a> 
                    <%# Eval("Date") %><br/>
                    <a href='Question.aspx?QuestionID=<%# Eval("QuestionID") %>'><%# Eval("ShortText") %></a>
                </td>                                
                <td>
                    <span class="answerCounter"><%# Eval("NumberOfAnswers") %></span>
                </td>
            </tr>      
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentAfterJavaScriptIncluded" runat="server">
<script>
    $(document).ready(function () {
        $("#btnQuestion").click(function () {
            var category = $(this).attr("data-category-id");
            var dictionary = new Array();
            dictionary[0] = AddJSONItem("Category", category);

            MakeAjaxCall("LoadControlWithParams", { controlName: "NewQuestion", dictionary: dictionary }, function (data) { ShowQuestionDialog(data); });
        });
    });    
</script>

</asp:Content>

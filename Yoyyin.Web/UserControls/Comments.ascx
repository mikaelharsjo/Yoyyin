<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comments.ascx.cs" Inherits="Yoyyin.Web.UserControls.Comments" %>
<%@ Import Namespace="Yoyyin.Web.Helpers" %>
<%@ Register Src="~/UserControls/UserImage.ascx" TagPrefix="uc" TagName="UserImage" %>

<asp:Literal ID="litComments" runat="server" ClientIDMode="Static" /><br />
<asp:ListView ID="lstComments" runat="server" ItemPlaceholderID="divContent">
    <LayoutTemplate>
        <table style="width: 100%">            
            <div runat="server" id="divContent"></div>            
        </table>        
    </LayoutTemplate>
    <ItemTemplate>
        <tr>
            <td valign="top" style='width: 50px; <%# GetStyle(Container.DataItem) %>'>
                <a href='<%# Eval("MemberUrl") %>'>
                    <uc:UserImage ID="UserImage1" UserID='<%# Eval("CommentUserId") %>' runat="server" Width="50" />
                </a>
            </td>
            <td valign="top" style='<%# GetStyle(Container.DataItem) %>'>
                <div class="whiteBox">
                    <strong><a href='<%# Eval("MemberUrl") %>'><%# Eval("UserName") %></a></strong>&nbsp;&nbsp;<%# WebHelpers.GetDate(Container.DataItem)%>
                    &nbsp;&nbsp;<a class="commentComment" data-commentid='<%# Eval("CommentID") %>'>Kommentera</a>
                    <img class="right COMMENT_DELETE" src="../Styles/Images/cross.png" title="Ta bort kommentar" runat="server" visible='<%# Eval("DeleteVisible") %>' CommentID='<%# Eval("CommentID") %>' /><br />
                    <%# Eval("Text") %>
                </div>
            </td>
        </tr>
    </ItemTemplate>
</asp:ListView>

    <div id="divDialogComment" class="dialog">
        <div class="padding">
            <div id="dialogInner">
                <div class='dialogHeader'><h3>Svara på denna kommentar</h3><img src='Styles/Images/fancy_close.png' alt='Stäng dialogen' class="dialogClose" onclick='$("#divDialogComment").hide();' /></div>
                <strong>Ditt svar</strong><br /><textarea rows='3' id="txtComment2" /><button class='button green' onclick="SaveComment('<%= CurrentUserID %>', '<%= UserId %>', $('#txtComment2').val(), commentID); $('#popBg').hide(); return false;">Svara</button>
            </div>
        </div>
    </div>

<script>
    $(".commentComment").click(function () {
        DisableBackground();

        $("#divDialogComment").show();
        $("#divDialogComment").center();

        $(".dialogClose").click(function (e) {
            $(".divDialogComment").hide();
            $("#popBg").hide();
        });
        commentID = $(this).attr("data-commentid");
    });
</script>

<div id="divNewComment" runat="server">
    <textarea rows="4" id="txtComment"></textarea>
    <p class="marginTop">
        <button type="button" onclick="SaveComment('<%= CurrentUserID %>', '<%= UserId %>', $('#txtComment').val())">Kommentera</button>
    </p>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $(".COMMENT_DELETE").click(function () {
            ExecuteAjax(["commentID", $(this).attr("CommentID")], "DeleteComment", function () { LoadComments('<%= UserId %>') }, OnError);
        });

        $("#txtComment").css("width", '<%= TextAreaWidth %>');
    });
</script>
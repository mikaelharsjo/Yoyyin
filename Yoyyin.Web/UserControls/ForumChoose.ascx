<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ForumChoose.ascx.cs" Inherits="Yoyyin.Web.UserControls.ForumChoose" %>
<h2>Välj var frågan ska hamna</h2>

    <asp:ListView ID="lstForum" runat="server" ItemPlaceholderID="divContent">
        <LayoutTemplate><div id="divContent" runat="server" /></LayoutTemplate>
        <ItemTemplate>
            <div id="divCategory" runat="server">
                <div><input type="radio" name="radio" id='<%# Eval("Key") %>' value='<%# Eval("Value") %>' /><label class="bold" for='<%# Eval("Key") %>'><%# GetTitle(Container.DataItem) %></label></div>
                <div class="paddingLeft marginBottom"><i><%# GetDescription(Container.DataItem) %></i></div>
            </div>
        </ItemTemplate>
    </asp:ListView>
    <div class="marginTop">
        <button type="button" id="btnSaveQuestionWithCategory">Spara</button> 
    </div>

<script type="text/javascript">
    $("#btnSaveQuestionWithCategory").click(function () {
        var category = $("input[name='radio']:checked").val();
        var text = '<%= Text %>';
        MakeAjaxCall("AddQuestion", { text: text, category: category }, function () { EnableBackground(); ShowDialogTemporarily("Din fråga har lagts till", 2000); });
    });
</script>

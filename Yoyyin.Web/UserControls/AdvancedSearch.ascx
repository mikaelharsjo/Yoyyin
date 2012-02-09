<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvancedSearch.ascx.cs" Inherits="Yoyyin.Web.UserControls.AdvancedSearch" %>

<h2>Avancerad sök</h2>
<table>
    <tr>
        <td>Fritext:</td>
        <td><input type="text" id="txtText" oninput="DoSearch()" /></td>        
    </tr>
    <tr>
        <td valign="top">Sök bland:</td>
        <td>
            <input type="checkbox" runat="server"  onchange="DoSearch()" clientidmode="Static" ID="chkentrepreneur" Value="0" title="Jag söker efter en person som kan starta upp och driva företag." /><label for="chkentrepreneur">Personer som kan starta upp och driva företag.</label><br />
            <input type="checkbox" runat="server" onchange="DoSearch()" clientidmode="Static" ID="chkinnovator" value="1" title="Jag söker efter folk med idéer som de vill." /><label for="chkinnovator">Folk med idéer som de vill förverkliga.</label><br />
            <input type="checkbox" ID="chkinvestor" runat="server" onchange="DoSearch()" clientidmode="Static" value="2" title="Jag söker efter spännande idéer och företag att investera i." /><label for="chkinvestor">Personer med spännande idéer och företag att investera i.</label><br />
<%--            <input type="checkbox" ID="chkfinancing" runat="server" onchange="DoSearch()" clientidmode="Static" value="3" title="Jag söker efter personer med kunskap och kapital att investera i min idé eller företag." /><label for="chkfinancing">Personer med kunskap och kapital att investera i min idé eller företag.</label><br />
            <input type="checkbox" ID="chkretiring" runat="server" onchange="DoSearch()" clientidmode="Static" value="4" title="Jag söker efter personer som kan ta över mitt företag då jag går i pension snart." /><label for="chkretiring">Personer som kan ta över mitt företag då jag går i pension snart.</label><br />
            <input type="checkbox" ID="chkbusinessman" runat="server" onchange="DoSearch()" clientidmode="Static" value="5" title="Jag söker kompetenser och delägare till min verksamhet." /><label for="chkbusinessman">Personer med kompetenser intresserade av delägarskap i min verksamhet.</label>
--%>
        </td>
    </tr>
    <tr>
        <td>Affärsområde/segment</td>
        <td>
            <asp:DropDownList ID="ddlSniHead" runat="server"
                Width="600px"
                DataTextField="Title"
                DataValueField="SniHeadID"
                AppendDataBoundItems="true"
                onchange="DoSearch()">
                <asp:ListItem Selected="True" Text="Välj affärsområde" Value="0" />                
            </asp:DropDownList>                       
        </td>
    </tr>
</table>
<div id="divSearchResult"></div>

<script type="text/javascript">
    function DoSearch() {
        DisableBackground();
        MakeAjaxCall("AdvancedSearch", { text: $("#txtText").val(), sniHead: $("#<%= ddlSniHead.ClientID %>").val(), isEntrepreneur: $("#chkentrepreneur").attr("checked") == "checked", isInnovator: $("#chkinnovator").attr("checked") == "checked", isInvestor: $("#chkinvestor").attr("checked") == "checked" }, function (data) { $("#divAjaxContentBelow").html(data); EnableBackground(); $("#divAjaxContentBelow").fadeIn(); }, OnError);
    }

    $(document).ready(function () {
        DoSearch();
    });
</script>
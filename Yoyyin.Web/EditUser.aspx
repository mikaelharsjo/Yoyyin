<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditUser.aspx.cs" Inherits="Yoyyin.Web.EditUser" EnableEventValidation="false"
    ValidateRequest="false" %>
<%@ Import Namespace="Yoyyin.Domain" %>
<%@ Import Namespace="Yoyyin.Domain.EntityHelpers" %>
<%@ Import Namespace="Yoyyin.Domain.Sni" %>
<%@ Import Namespace="Yoyyin.Web" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<%@ Register Src="~/UserControls/UserImage.ascx" TagPrefix="yoyyin" TagName="UserImage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        table input[type="text"], input[type="password"], textarea, select
        {
            min-width: 650px;
        }
        
        #txtSearch
        {
            min-width: 240px !important;
        }
        input[type=file]
        {
            font-family: Trebuchet, Calibri, Arial, Sans-Serif;
            font-size: 16px;
        }
        textarea
        {
            font-family: Trebuchet, Calibri, Arial, Sans-Serif !important;
            font-size: 16px;
        }
        input[type=text]
        {
            font-family: Trebuchet, Calibri, Arial, Sans-Serif;
            width: 100px;
            height: 15px;
        }
    </style>
    <asp:ScriptManager runat="server" EnablePageMethods="true" />
    <script runat="server">
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static CascadingDropDownNameValue[] GetSniItems(string knownCategoryValues, string category)
        {
            var kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            string sniHeadID = kv["SniHead"];

            var values = new List<CascadingDropDownNameValue>();
            var entityFactory = new EntityFactory();
            var userHelper = new UserHelper();

            var user = entityFactory.GetUser(Current.UserID);

            foreach (SniItem item in userHelper.GetSniItemsByHead(sniHeadID))
            {
                const int rowlength = 105;
                int index = 0;
                string title = item.Title;
                // split long items on multiple rows
                while (true)
                {
                    if (title.Length < rowlength)
                    {
                        values.Add(new CascadingDropDownNameValue(title, item.SniNo));
                        break;
                    }
                    values.Add(new CascadingDropDownNameValue(item.Title.Substring(index, rowlength) + "-", item.SniNo));
                    index += rowlength;

                    title = item.Title.Substring(index, item.Title.Length - index);
                }
            }

            return values.ToArray();
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static CascadingDropDownNameValue[] GetSniHead(string knownCategoryValues, string category)
        {
            var entityFactory = new EntityFactory();
            var userHelper = new UserHelper();

            var user = entityFactory.GetUser(Current.UserID);
            var values = new List<CascadingDropDownNameValue>();

            foreach (SniHead sniHead in userHelper.GetAllSniHeads())
            {
                values.Add(sniHead.SniHeadID == user.SniHeadID
                               ? new CascadingDropDownNameValue(sniHead.Title, sniHead.SniHeadID, true)
                               : new CascadingDropDownNameValue(sniHead.Title, sniHead.SniHeadID, false));
            }
            return values.ToArray();
        }            
        
    </script>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Personuppgifter</a></li>
            <li><a href="#tabs-2">Din affärsidé/sökprofil</a></li>
            <li><a href="#tabs-3">Inställningar</a></li>
        </ul>
        <div id="tabs-1">
            <div id="divImage">
                <yoyyin:UserImage runat="server" Width="120" />
                &nbsp; <a title="Ta bort bilden" id="lnkRemoveImage">
                    <img src="Styles/Images/cross.png" alt="Ta bort din bild" /></a>
            </div>
            <div id="divCV">
                <asp:HyperLink ID="lnkCV" runat="server" Target="_blank">CV</asp:HyperLink>&nbsp;
                <a title="Ta bort cv:n" id="lnkRemoveCV" runat="server" clientidmode="Static">
                    <img src="Styles/Images/cross.png" alt="Ta bort din CV" />
                </a>
            </div>
            <br class="clear" />
            <table>
                <tr>
                    <td>
                        E-postadress:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Eventuellt företagsnamn:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompanyName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Namn:
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Gatuadress:
                    </td>
                    <td>
                        <asp:TextBox ID="txtStreet" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Postnummer:
                    </td>
                    <td>
                        <asp:TextBox ID="txtZipCode" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Postadress/ort:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Telefon:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Webbplats: [http://]
                    </td>
                    <td>
                        <asp:TextBox ID="txtUrl" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Välj bild till din profil:
                    </td>
                    <td>
                        <asp:FileUpload ID="fileImage" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Välj en CV/meritförteckning:
                    </td>
                    <td>
                        <asp:FileUpload ID="fileCV" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="tabs-2">            
            <table>
                <tr>
                    <td>
                        Rubrik för din verksamhet:
                    </td>
                    <td>
                        <asp:TextBox ID="txtBusinessTitle" runat="server" Width="600px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Om verksamheten/affärsidén:
                    </td>
                    <td>
                        <asp:TextBox ID="txtBusinessDescription" runat="server" TextMode="MultiLine" Rows="5" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Taggar, din affärsidé:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearchWords" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Dina egna kompetenser:
                    </td>
                    <td>                        
                        <asp:TextBox ID="txtSearchWordsCompetence" runat="server" ClientIDMode="static" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Kompetenser du söker:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearchWordsCompetenceNeeded" runat="server" ClientIDMode="static" />
                    </td>
                </tr>

                <tr>
                    <td valign="top">
                        Jag söker:
                    </td>
                    <td>
                        <asp:Repeater ID="repUserTypes" runat="server">
                            <ItemTemplate>
                                <div class="marginBottomSmall">
                                    <asp:CheckBox ID="chkUserType" runat="server" ClientIDMode="Static"
                                        title="<%# WebHelpers.GetUserTypeDescription(Container.DataItem) %>"
                                        Text="<%# WebHelpers.GetUserTypeDescription(Container.DataItem) %>" />                                    
                                </div>
                                <div id="divEntrepreneur" runat="server" clientidmode="Static">
                                    <i>Här kan du lägga till valfri text:<br /></i>
                                    <asp:TextBox ID="txtUserTypeDescription" runat="server" CssClass="tbUserTypes" />
                                </div>     
                                <asp:HiddenField ID="hiddenUserType" runat="server" Value='<%# Eval("Value") %>' />
                            </ItemTemplate>
                        </asp:Repeater>                        
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Din roll:
                    </td>
                    <td>
                        <div class="marginBottom">
                            <input type="radio" runat="server" clientidmode="Static" name="radioRole" id="radioentrepreneurbusinessman"
                                value="0" title="Företagare/Entreprenör: Jag driver ett företag eller vill starta upp och driva ett företag." /><label
                                    for="radioentrepreneurbusinessman">Jag driver ett företag eller vill starta upp
                                    och driva ett företag. <strong>(Företagare/Entreprenör)</strong></label></div>
                        <div class="marginBottom">
                            <input type="radio" runat="server" clientidmode="Static" name="radioRole" id="radioinnovator"
                                value="1" title="Innovatör/Uppfinnare : Jag har idéer som behöver förverkligas." /><label
                                    for="radioinnovator">Jag har idéer som behöver förverkligas. <strong>(Innovatör/Uppfinnare)</strong></label></div>
                        <div class="marginBottom">
                            <input type="radio" runat="server" clientidmode="Static" name="radioRole" id="radioinvestor"
                                value="2" title="Jag söker efter spännande idéer och företag att investera i." /><label
                                    for="radioinvestor">Jag söker efter spännande idéer och företag att investera i.
                                    <strong>(Finansiär)</strong></label></div>
                        <div class="marginBottom">
                            Något annat:<asp:TextBox ID="bindUserTypeDescription" runat="server" /></div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Välj arbetsområde:
                    </td>
                    <td>
                        <act:CascadingDropDown ID="CascadingDropDown1" runat="server" TargetControlID="ddlSniHeadID"
                            Category="SniHead" ServiceMethod="GetSniHead" PromptText="Välj först område" />
                        <br />
                        <br />
                        <asp:DropDownList ID="ddlSniHeadID" runat="server" Width="700px" DataTextField="Title"
                            DataValueField="SniHeadID" />
                        <br />
                        <br />
                        <act:CascadingDropDown ID="CascadingDropDown2" runat="server" TargetControlID="ddlSniNo"
                            ParentControlID="ddlSniHeadID" ServiceMethod="GetSniItems" Category="Model" />
                        <asp:DropDownList ID="ddlSniNo" runat="server" Width="700px" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="tabs-3">
            <table>
                <tr>
                    <td>
                        Visa e-post? (för andra medlemmar)
                    </td>
                    <td>
                        <asp:CheckBox ID="chkShowEmail" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Visa adress?
                    </td>
                    <td>
                        <asp:CheckBox ID="chkShowAddress" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Visa på karta?
                    </td>
                    <td>
                        <asp:CheckBox ID="chkShowOnMap" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:Label ID="ErrorMessage" runat="server" CssClass="errorText" />
    <div class="blueBox" runat="server" id="divInfo" visible="false">
        <asp:Literal ID="litInfo" runat="server" />
    </div>
    <div class="marginBottom marginTop">
        <asp:Button Text="Spara" OnClick="btnSave_Click" runat="server" />&nbsp;&nbsp;&nbsp;
        <button onclick="location.href = 'Member.aspx'; return false;">
            Avbryt</button>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContentAfterJavaScriptIncluded" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#tabs').tabs();

            InitializeAutoComplateMultipleCompetences("txtSearchWordsCompetenceNeeded");
            InitializeAutoComplateMultipleCompetences("txtSearchWordsCompetence");

            $("#lnkRemoveImage").click(function () {
                ExecuteAjax(["userID", "<%= UserID %>"], "RemoveImageFromUser", function () { $("#divImage").fadeOut(); }, OnError);
            });

            $("#lnkRemoveCV").click(function () {
                ExecuteAjax(["userID", "<%= UserID %>"], "RemoveCvFromUser", function () { $("#divCV").fadeOut(); }, OnError);
            });
        });
    </script>
</asp:Content>

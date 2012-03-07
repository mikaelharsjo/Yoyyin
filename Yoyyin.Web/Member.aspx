<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false"
    CodeBehind="Member.aspx.cs" Inherits="Yoyyin.Web.Member" EnableViewState="true" %>
<%@ Import Namespace="Yoyyin.Web.Helpers" %>
<%@ Register Src="~/UserControls/UserImage.ascx" TagPrefix="yoyyin" TagName="UserImage" %>
<%@ Register TagPrefix="yoyyin" Src="UserControls/UserPosts.ascx" tagName="UserPosts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView runat="server" ID="loginView" EnableViewState="false">
        <LoggedInTemplate>
            <div id="dialogArrow" class="dialogArrow">
                &nbsp;</div>
            <div class="span-24 last">
                &nbsp;</div>
            <%= GetHtmlForSniHeader()%>
            <div class="span-24 last">
                &nbsp;</div>
            <div class="span-24 last marginTop">
                <div class="span-6">
                    <div>
                        <div class="blueBox">
                            <div>
                                <div class="marginTop textAlignCenter">
                                    <yoyyin:UserImage ID="userImageLoggedIn" runat="server" Width="185" />
                                </div>
                            </div>
                            <div>
                                <h3>
                                    <%= CurrentUser.Name %></h3>
                            </div>
                            <div>
                                <div>
                                    <strong>
                                        <%= CurrentUserPresentation.SniHeadTitle %></strong></div>
                                <div id="divStreet" runat="server">
                                    <%= CurrentUser.Street %></div>
                                <div id="divZipCode" runat="server">
                                    <%= CurrentUser.ZipCode + " " + CurrentUser.City %></div>
                                <div id="divPhone" runat="server">
                                    <%= CurrentUser.Phone %></div>
                                <div id="divEmail" runat="server">
                                    <%= WebHelpers.GetEmail(CurrentUser.UserId)%></div>
                                <div id="divUrl2" runat="server">
                                    <a href='<%= CurrentUserPresentation.ExternalUrlHref %>' target="_blank">
                                        <%= CurrentUserPresentation.ExternalUrlText %>
                                    </a>
                                </div>
                                <div class="marginBottom">
                                    <asp:HyperLink ID="lnkCV" runat="server" Target="_blank">CV</asp:HyperLink>
                                </div>
                                
                                <div id="divPublicLink" runat="server" visible="false">
                                    <div>
                                        Publik länk till din profil:</div>
                                    <a target="_blank" href='<%= CurrentUserPresentation.PublicProfileUrl %>'><%= CurrentUserPresentation.PublicProfileUrl %>></a>
                                </div>
                                <div class="marginTop marginBottomLarge" runat="server" id="divEdit">
                                    <a href="EditUser.aspx">Redigera profil</a><br />
                                    <a id="lnkChangePasswordDialog">Byt lösenord</a>
                                    <div class="marginTop" runat="server" id="divDelete">
                                        <a id="lnkInactivate">Inaktivera konto</a><br />
                                        <a id="lnkDelete">Avsluta konto</a>
                                    </div>
                                </div>
                                <yoyyin:UserPosts runat="server" ID="userPosts" />
                            </div>
                        </div>
                    </div>
                </div>
                <div runat="server" id="divOwnDescriptionAndTitle" visible="false">
                    <div class="span-18 last marginBottom">
                        <h2 class="h2 marginBottom">
                            <%= CurrentUser.BusinessTitle %></h2>
                        <div class="marginTop marginBottom">
                            <%= CurrentUser.BusinessDescription %></div>
                    </div>
                    <div class="span-12" runat="server">
                        <div class="blueBox">
                            <div class="comments">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="span-6 last" runat="server" id="divMembers">
                    <div class="marginLeft">
                        <div class="blueBox marginBottom">
                            <h3>
                                Dina senaste besökare</h3>
                            <div>
                                <div class="padding">
                                    <asp:ListView ID="lstVisits" runat="server" ItemPlaceholderID="divContent" EnableViewState="false">
                                        <LayoutTemplate>
                                            <div id="divContent" runat="server" />
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <div>
                                                <asp:Image runat="server" ImageUrl='<%# Eval("OnlineImageUrl") %>' />&nbsp;
                                                <a href='<%# Eval("ProfileUrl") %>'>
                                                    <%# Eval("DisplayName")%>
                                                </a>
                                            </div>
                                            <div class="small"><%# Eval("VisitDate") %></div>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <i>Inga besökare.</i>
                                        </EmptyDataTemplate>
                                    </asp:ListView>
                                </div>
                            </div>
                        </div>
                        <div class="blueBox">
                            <h3>
                                Nya medlemmar</h3>
                            <div>
                                <asp:ListView ID="lstNewest" runat="server" ItemPlaceholderID="divContent">
                                    <LayoutTemplate>
                                        <div id="divContent" runat="server" />
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <div>
                                            <asp:Image runat="server" ImageUrl='<%# Eval("OnlineImageUrl") %>' />&nbsp;
                                            <a href='<%# Eval("ProfileUrl") %>'>
                                                <%# Eval("DisplayName") %>
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="span-18 last" id="divContact" runat="server">
                    <div class="paddingLeft">
                        <div class="memberHeaderLeft">
                            <span class="h2 marginBottom">
                                <%= CurrentUser.BusinessTitle %>
                            </span>
                        </div>
                        <div class="memberHeaderRight hideWhenSearch">
                            <div class="memberHeaderItem">
                                <button id="lnkBookmark"  runat="server" onclick="return false;" clientidmode="Static">
                                    Addera kontakt&nbsp;&nbsp;<img src="Styles/Images/star.png" alt="Addera kontakt" />
                                </button>
                            </div>
                            <div class="memberHeaderItem">
                                <button onclick="PopMail(0, '<%= VisitingUserId %>', '<%= CurrentUser.UserId %>'); return false;" clientidmode="Static">
                                    Yoyyin-mail&nbsp;&nbsp;<img src="Styles/Images/email.png" alt="Skicka mail"  />
                                </button>
                            </div>
                            <div class="memberHeaderItem">
                                <button id="btnMatch" onclick="return false;">
                                    Matcha&nbsp;&nbsp;<img src="Styles/Images/True.png" alt="Matcha" />
                                </button>
                            </div>

                        </div>
                        <br class="extra" />
                        <div class="marginTop marginBottom">
                            <%= CurrentUser.BusinessDescription %></div>
                        <div class="marginTop marginBottom">
                            <h3>
                                Jag söker:</h3>
                            <%= GetUserTypesNeeded() %>
                        </div>
                        <div class="blueBox">
                            <div class="comments">
                            </div>
                        </div>
                        <div>
                            <div class="bold marginTopLarge">
                                Skicka ett privat meddelande till
                                <%= CurrentUserPresentation.DisplayName %>
                            </div>
                            <div>
                                <textarea rows="4" id="txtMessage" cols="500" style="width: 670px;"></textarea></div>
                            <p class="marginTop">
                                <button type="button" onclick="<%= GetSendMailScript() %>">
                                    Skicka meddelandet</button>
                            </p>
                            <div id="divMailLoader" class="marginTop">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </LoggedInTemplate>
        <AnonymousTemplate>
            <%= GetHtmlForSniHeader()%>
            <div class="span-6">
                <div>
                    <div class="blueBox">
                        <div>
                            <div class="marginTop textAlignCenter">
                                <yoyyin:UserImage runat="server" ID="userImageAnonymous" Width="185" />
                            </div>
                        </div>
                        <div>
                            <h3><%= CurrentUserPresentation.DisplayName %></h3>
                        </div>
                        <div>
                            <div>
                                <strong>
                                    <%= CurrentUserPresentation.SniHeadTitle  %></strong></div>
                            <div id="divUrl" runat="server">
                                <a href='<%= CurrentUserPresentation.ExternalUrlHref %>' target="_blank" title='<%= CurrentUserPresentation.ExternalUrlText %>'>
                                    <%= CurrentUserPresentation.ExternalUrlText%>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="span-18 last">
                <div class="paddingLeft">
                    <h1>
                        <%= CurrentUser.BusinessTitle %></h1>
                    <div class="marginBottomLarge">
                        <%= CurrentUser.BusinessDescription %></div>
                    <div class="infoNotMember">                        
                            <p>
                                Om du vill kontakta
                                <%= CurrentUserPresentation.DisplayName %> 
                                måste du vara medlem.</p>
                            <p>
                                Att bli medlem går snabbt och är gratis. Efter registreringen blir du också själv
                                sökbar för framtida affärspartners.</p>
                            <a href='Register.aspx' rel="nofollow">Klicka för att bli medlem</a>
                            <%--eller<br/>--%>
                            <a id='lnkLogin' onclick='ShowLogin();'>Logga in</a>
                            <%--om du redan är det.--%>                        
                    </div>
                </div>
            </div>
            </div> </div> </div>
        </AnonymousTemplate>
    </asp:LoginView>
    <div class="extra">
        &nbsp;</div>
    <div runat="server" id="divSelfVisit" visible="false">
        <div class="dialog" id="divWelcome">
            <div class="padding">
                <div class="dialogHeader">
                    <h2>
                        Välkommen till Yoyyin</h2>
                    <img src="Styles/Images/fancy_close.png" alt="Stäng dialogen" class="dialogClose" /></div>
                <p>
                    Registreringen är nu klar och du är redo att börja använda Yoyyin.</p>
                <p>
                    Du har blivit förflyttad till "Min profil". Detta är din utgångspunkt på Yoyyin,
                    här kan du redigera din profil, läsa och svara på meddelanden mm.</p>
                <p>
                    Lycka till i jakten på en affärspartner.</p>
            </div>
        </div>
        <div class="dialog" id="divInactivate">
            <div class="padding">
                <div class="dialogHeader">
                    <h2>
                        Inaktivering av konto</h2>
                    <img src="Styles/Images/fancy_close.png" alt="Stäng dialogen" class="dialogClose" /></div>
                <div id="divInactivateMessage">
                    <p>
                        Är du säker att du vill inaktivera ditt konto?</p>
                    <p>
                        Du kommer då inte längre att synas någonstans på webbplatsen, inte dyka upp i sökningar
                        mm.</p>
                    <p>
                        Du har dock möjligheten att logga in och aktivera ditt konto när du vill. Då fungerar
                        allt som vanligt igen</p>
                </div>
                <button type="button" onclick="InActivateUser('<%= UserIDOfUserBeingViewed %>')">
                    Inaktivera</button>
                <button type="button" onclick="$('.dialog').hide(); $('#popBg').hide();">
                    Avbryt</button>
            </div>
        </div>
        <div class="dialog" id="divDelete">
            <div class="padding">
                <div class="dialogHeader">
                    <h2>
                        Borttagning av konto</h2>
                    <img src="Styles/Images/fancy_close.png" alt="Stäng dialogen" class="dialogClose" /></div>
                <div id="divDeleteMessage">
                    <p>
                        Vill du verkligen ta bort ditt konto?</p>
                    <p>
                        Gör du det så raderas allt som du gjort på webbplatsen. Alla meddelanden, kommentarer
                        mm.</p>
                    <p>
                        Om du istället väljer att inaktivera ditt konto har du möjligheten att logga in
                        och aktivera ditt konto när du vill. Då fungerar allt som vanligt igen</p>
                </div>
                <button class="deleteAccountButton" type="button" onclick="DeleteUser('<%= UserIDOfUserBeingViewed %>')">
                    Ta bort</button>
                <button class="deleteAccountButton" type="button" onclick="InActivateUser('<%= UserIDOfUserBeingViewed %>')">
                    Inaktivera</button>
                <button class="deleteAccountButton" type="button" onclick="$('.dialog').hide(); $('#popBg').hide();">
                    Avbryt</button>
            </div>
        </div>
        <div class="dialog" id="divChangePasswordDialog">
            <div class="padding">
                <div class="dialogHeader">
                    <span class="h2">Byt lösenord</span>
                    <img src="Styles/Images/fancy_close.png" alt="Stäng dialogen" class="dialogClose" /></div>
                <div>
                    <asp:ChangePassword runat="server" CancelButtonText="Avbryt" ChangePasswordTitleText=""
                        ID="changePassword" ChangePasswordButtonText="Ändra lösenord" ChangePasswordFailureText="Antingen är lösenordet felaktigt eller så är det nya lösenordet ogiltigt. Nytt lösenords minimilängd: {0}."
                        ConfirmNewPasswordLabelText="Bekräfta nytt lösenord:" ConfirmPasswordCompareErrorMessage="Bekräfta lösenord måste överensstämma med Nytt lösenord."
                        ConfirmPasswordRequiredErrorMessage="Bekräfta lösenord krävs." ContinueDestinationPageUrl="~/Content.aspx?PageID=1131&PageTypeID=3"
                        NewPasswordLabelText="Nytt lösenord:" NewPasswordRegularExpressionErrorMessage="Vänligen ange ett annat lösenord."
                        NewPasswordRequiredErrorMessage="Nytt lösenord krävs." PasswordLabelText="Lösenord:"
                        PasswordRequiredErrorMessage="Lösenord krävs." SuccessText="Ditt lösenord har nu blivit ändrat!"
                        SuccessTitleText="Lösenordet är nu ändrat" UserNameLabelText="Användarnamn:"
                        UserNameRequiredErrorMessage="Användarnamn krävs.">
                        <ChangePasswordTemplate>
                            <table border="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="currentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword"
                                            Text="Lösenord:" /><br />
                                        <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" />
                                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                            ErrorMessage="Lösenord krävs." ToolTip="Lösenord krävs." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="newPasswordLabel" runat="server" AssociatedControlID="NewPassword"
                                            Text="Nytt lösenord:" /><br />
                                        <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" />
                                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                            ErrorMessage="Nytt lösenord krävs." ToolTip="Nytt lösenord krävs." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="confirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword"
                                            Text="Bekräfta nytt lösenord:" /><br />
                                        <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" />
                                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                            ErrorMessage="Bekräfta lösenord krävs." ToolTip="Bekräfta lösenord krävs." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                            ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="Bekräfta lösenord måste överensstämma med Nytt lösenord."
                                            ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="color: red">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Button ID="changePasswordButton" runat="server" CssClass="button green" CommandName="ChangePassword"
                                            Text="Ändra lösenord" ValidationGroup="ChangePassword1" formnovalidate="true" />
                                        <asp:Button ID="cancelButton" runat="server" CssClass="button green" CausesValidation="False"
                                            CommandName="Cancel" Text="Ångra" formnovalidate="true" />
                                    </td>
                                </tr>
                            </table>
                        </ChangePasswordTemplate>
                        <SuccessTemplate>
                            <asp:Label ID="changePasswordSuccessLabel" runat="server" Text="Ditt lösenord har nu blivit ändrat!" />
                            <br />
                            <asp:Button ID="continueButton" runat="server" CausesValidation="False" CommandName="Continue"
                                Text="Continue" />
                        </SuccessTemplate>
                    </asp:ChangePassword>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContentAfterJavaScriptIncluded" runat="server">
    <script type="text/javascript">
        
        <%= GetInitializeScript() %>      
        <asp:Literal ID="litJavaScript" runat="server" />  
    </script>
</asp:Content>

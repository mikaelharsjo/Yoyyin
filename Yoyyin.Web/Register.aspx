<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Yoyyin.Web.Register" EnableEventValidation="false" %>
<%@ Import Namespace="Yoyyin.Domain" %>
<%@ Import Namespace="Yoyyin.Domain.EntityHelpers" %>
<%@ Import Namespace="Yoyyin.Domain.Sni" %>
<%@ Import Namespace="Yoyyin.Web.Helpers" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/UserImage.ascx" TagPrefix="yoyyin" TagName="UserImage" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager runat="server" EnablePageMethods="true" />   
        <script runat="server">
            [System.Web.Services.WebMethod]
            [System.Web.Script.Services.ScriptMethod]
            public static CascadingDropDownNameValue[] GetItemsForHead(string knownCategoryValues, string category)
            {
                StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
                string sniHeadID = kv["SniHead"];

                var values = new List<CascadingDropDownNameValue>();

                var userHelper = new UserHelper();
                foreach (SniItem item in userHelper.GetSniItemsByHead(sniHeadID))
                {
                    const int ROWLENGTH = 105;
                    int index = 0;
                    string title = item.Title;
                    // split long items on multiple rows
                    while (true)
                    {
                        if (title.Length < ROWLENGTH)
                        {
                            values.Add(new CascadingDropDownNameValue(title, item.SniNo));
                            break;
                        }
                        else
                        {
                            values.Add(new CascadingDropDownNameValue(item.Title.Substring(index, ROWLENGTH) + "-", item.SniNo));
                            index += ROWLENGTH;

                            title = item.Title.Substring(index, item.Title.Length - index);
                        }
                    }
                }

                return values.ToArray();
            }

            [System.Web.Services.WebMethod]
            [System.Web.Script.Services.ScriptMethod]
            public static CascadingDropDownNameValue[] GetSniHead(string knownCategoryValues, string category)
            {
                var values = new List<CascadingDropDownNameValue>();

                var userHelper = new UserHelper();
                foreach (SniHead sniHead in userHelper.GetAllSniHeads())
                {
                    values.Add(new CascadingDropDownNameValue(sniHead.Title, sniHead.SniHeadID, false));
                }
                return values.ToArray();
            }
                       
        </script> 
        <style>input[type=text]{ width: 370px;}</style>   

    <div class="dialog" id="divWelcome">
        <div class="padding">
            <div class="dialogHeader"><h2>Välkommen till Yoyyin</h2>
                <img src="Styles/Images/fancy_close.png" alt="Stäng dialogen" class="dialogClose" /></div>
            <p>Ditt konto är nu skapat och du är inloggad.</p>            
            <p>Du ser att du är inloggad på verktygsmenyn som dykt upp här ovanför. Denna visas alltid när man är inloggad. Här kan du bland annat söka medlemmar men även finna redskap som kan underlätta ditt företagande. Eftersom du nu är medlem kan du se andra medlemmars hela profil och kontakta dem du vill.</p>
            <p>Vi rekommenderar dock att du tar dig tid och fyller i resten av uppgifterna. Då blir du nämligen själv sökbar för andra medlemmar.</p>
            <p>Lycka till i jakten på en affärspartner.</p>
        </div>
    </div>

    <div class="span-5">

        <div class="blueBox marginTop paddingLeft paddingRight">
            <div class="paddingTop">
                <p class="textAlignCenter">
                    <asp:Image ID="imgYoyyin" runat="server" ImageUrl="~/Styles/Images/avatarSmall.png" AlternateText="Yoyyin" CssClass="imageBorder" style="width: 155px;" />
                    <yoyyin:UserImage ID="userImage" runat="server" Visible="false" Width="155" />
                </p>
            </div>
            <div id="UserName"></div>
            <div id="name"><asp:Literal ID="litName" runat="server" /></div>
            <div id="Email" style="word-wrap: break-word;"><asp:Literal ID="litEmail" runat="server" /></div>
        </div>
    </div>
    <div class="span-1">&nbsp;</div>
    <div class="span-11 last" id="divRegister">              
        <asp:CreateUserWizard ID="wizard" runat="server"
            NavigationButtonStyle-CssClass="button green" FinishCompleteButtonStyle-CssClass="button green"
            HeaderText="Bli medlem" HeaderStyle-CssClass="h2" ActiveStepIndex="0" 
            TextBoxStyle-CssClass="wizTextBox" 
            CreateUserButtonText="Jag godkänner. Skapa konto." UserNameLabelText="Användarnamn:" PasswordLabelText="Lösenord:" ConfirmPasswordLabelText="Upprepa lösenord:" EmailLabelText="E-post:"
            DisplaySideBar="false" FinishCompleteButtonText="Klar" StartNextButtonText="Nästa" StepPreviousButtonText="Tillbaka" FinishPreviousButtonText="Tillbaka" ContinueButtonText="Fortsätt" StepNextButtonText="Nästa"
            LoginCreatedUser="true"
            OnCreatedUser="OnCreatedUser"
            OnNextButtonClick="nextButtonClick" ValidatorTextStyle-CssClass="errorText" OnFinishButtonClick="wizard_FinishButtonClick"
            ConfirmPasswordCompareErrorMessage="Lösenord och bekräftat lösenord måste matcha"
            ConfirmPasswordRequiredErrorMessage="Lösenord måste bekräftas"
            DuplicateEmailErrorMessage="E-postadressen finns redan registrerad"
            DuplicateUserNameErrorMessage="Det finns redan ett konto med denna e-postadress, kanske har du bara glömt ditt lösenord?"
            EmailRegularExpressionErrorMessage="E-postadressen är felaktig"
            EmailRequiredErrorMessage="E-post adress måste anges"
            InvalidPasswordErrorMessage="Lösenordet är inte giltigt, för kort?"
            InvalidEmailErrorMessage="E-postadressen är felaktig"
            PasswordRequiredErrorMessage="Lösenord måste anges"
            UnknownErrorMessage="Ett fel har uppstått, vänligen försök igen"
            UserNameRequiredErrorMessage="Användarnamn måste anges"
            RequireEmail="false">         
            <WizardSteps>
                <asp:CreateUserWizardStep ID="createUserWizardStep" runat="server">
                    <ContentTemplate>                        
                        <asp:ImageButton ID="btnFacebook" runat="server" Text="Hämta uppgifter från Facebook" OnClick="BtnFacebook_Click" ImageUrl="~/Styles/Images/fbButton.png" CausesValidation="false" 
                            style="position:absolute; top: 170px; left: 46%;" />
                        <div class="marginBottom bold">Steg 1 (av 7) - Kontouppgifter</div>                      
                       
                        <div class="marginBottom"><asp:Label id="ErrorMessage" runat="server" CssClass="errorText" /></div>
                        <table>
                            <tr>
                                <td>E-postadress:</td>
                                <td><asp:TextBox ID="UserName" runat="server" CssClass="emailRegister" /></td>
                            </tr>
                            <tr>
                                <td>Lösenord:</td>
                                <td><asp:TextBox ID="Password" runat="server" CssClass="emailRegister" minlength="6" ClientIDMode="Static" TextMode="Password" /></td>
                            </tr>
                            <tr>
                                <td>Upprepa lösenord:&nbsp;&nbsp;</td>
                                <td><asp:TextBox ID="Password2" runat="server" TextMode="Password" CssClass="emailRegister" /></td>
                            </tr>
                        </table>
                            <div class="span-3 marginTop">Användaravtal:</div>
                            <div class="span-5 marginTop"><a href="Files/AnvandaravtalYoyyinv1_0.pdf" target="_blank">Läs avtalet som pdf&nbsp;&raquo;</a></div>
                        <textarea rows="5" cols="80" style="width:100%;" readonly="readonly" onfocus="this.rows=10" name="legal">
Välkommen till Yoyyin. Yoyyin är en matchningstjänst som sammanför entreprenörer, innovatörer och företagare som vill starta eller utveckla företag tillsammans. För att kunna
delta fullt ut i Yoyyingemenskapen måste du vara medlem. För att bli medlem i Yoyyin måste du läsa igenom och bekräfta detta användaravtal. Genom att acceptera bekräftar du att du
förstår, accepterar och förbinder dig att följa bestämmelserna i detta användaravtal mellan dig, i detta avtal hädanefter kallad Medlemmen, och Yoyyin.

1 § Genom att acceptera detta medlemsavtal åtar sig medlemmen att följa de regler och bestämmelser som följer av detta avtal, medlemmen åtar sig också att vid alla medlemmens
förehavanden via Yoyyin iaktta och följa gällande lagar och förordningar samt att även i övrigt visa vederbörlig hänsyn i kontakten med andra medlemmar.

2 § Genom att acceptera detta avtal garanterar medlemmen att all information som medlemmen gör tillgänglig eller på annat sätt sprider via Yoyyin är korrekt, ej omfattas av
sekretess och att spridande av informationen inte bryter mot gällande rätt eller bestämmelser i detta avtal. Medlemmen garanterar också att sådan information inte behäftas av
kontraktuella åtaganden eller övriga begränsningar samt att informationen eller spridandet av denna inte kränker tredje parts rättigheter. I det fall så skulle ske är medlemmen förpliktad att utan dröjsmål meddela Yoyyin.

3 § Medlemmen åtar sig att inte sprida information som kan uppfattas som stötande, kränkande eller brottsligt. Detta innebär att alla former av hets mot folkgrupp, personangrepp, sexuellt orienterat material, politiskt och religiöst relaterade budskap samt material som kan uppfattas som anstötligt i något hänseende samt allt övrigt material som
bryter mot Yoyyins riktlinjer är förbjudet och kan i tillämpliga fall leda till polisanmälan.

4 § Medlemmen garanterar att alla bilder personen laddar upp i sin profil föreställer medlemmen och i övrigt följer detta avtal. Medlemmen åtar sig också att följa Yoyyins anvisningar gällande registrering av personuppgifter för medlemskap.

5 § Genom att acceptera detta avtal förbinder sig medlemmen att följa Yoyyins Upphovsrättsliga policy. Länk till policy (upprättas i samband med skarpa versionen)

6 § Yoyyin kontrollerar inte medlemmens personuppgifter eller riktigheten hos av medlem angivna uppgifter eller annan information medlem sprider på Yoyyin. Om medlemmen misstänker obehörigt användande av personuppgifter eller övriga brott mot Yoyyins riktlinjer eller användaravtal måste medlemmen kontakta Yoyyin.

7 § Yoyyin förbehåller sig rätten att omedelbart och utan föregående information avstänga medlem samt att omedelbart häva avtal med medlem som i sitt agerande på Yoyyin bryter
mot gällande lagar och förordningar eller mot bestämmelserna i detta avtal. Yoyyin förbehåller sig också rätten att utan föregående information uppdatera och modifiera detta
medlemsavtal, samt Yoyyins övriga riktlinjer och processer.

8 § Det är ej tillåtet att använda automatiserade metoder för att samla eller tillgå information från Yoyyin, detta inkluderar men är ej begränsat till mjukvara såsom ”spindlar” och liknande.

9 § Medlemmen får endast länka till Yoyyins förstasida, s.k ”djuplänkning” är ej tillåtet.

10 § Medlemmen får inte utan skriftligt tillstånd i separat avtal med behörig företrädare hävda eller implicera samhörighet med Yoyyin. Medlemmen får ej heller utan skriftligt avtal från
behörig företrädare för Yoyyin använda eller hänvisa till Yoyyins varumärke, logotyp eller Yoyyin i övrigt i egen eller tredje parts verksamhet.

11 § Det är ej tillåtet att göra intrång i Yoyyins upphovsrättsligt skyddade material, affärshemligheter eller varumärke. Detta innefattar, men är ej begränsat till försök att radera,
täcka över eller på annat störa Yoyyins grafiska profil, varumärke samt annat material publicerat av Yoyyin, Yoyyins samarbetspartners eller andra medlemmar.

12 § Det är ej tillåtet att på något vis, manuellt eller automatiskt, störa Yoyyins funktion eller utseende. Detta innefattar men är ej begränsat till försök att kringgå eller störa Yoyyins
säkerhetsfunktion, drift eller inloggningsfunktion, samt spridande av virus samt liknande mjukvara, att via automatiserade eller manuella metoder utföra reverse engineering,
dekompilera, avkoda eller på annat sätt vara delaktig i härledandet eller spridandet av Yoyyins källkod.

13 § Det är ej tillåtet att använda information, material eller uppgifter från Yoyyin i verksamhet som till någon del konkurrerar eller avser att konkurrera med Yoyyin.

14 § Yoyyin förbehåller sig rätten att utan föregående information ensidigt ändra och utöka detta avtal med bindande verkan. I det fall medlemmen ej godkänner avtalsändring kan
medlemmen lämna Yoyyin genom att avsluta sitt medlemskap.

15 § Alla medlemmens personuppgifter på Yoyyin omfattas av Personuppgiftslagen (SFS 1998:204) i detta avtal hädanefter förkortad PuL. Detta innebär att uppgifter om dig endast
registreras med ditt samtycke, samt att dessa behandlas korrekt och i enlighet med PuL och god personuppgiftssed. För vidare information om PuL,följ denna länk: PuL

16 § Yoyyin har ingen möjlighet att övervaka eller kontrollera riktigheten i uppgifter och information som medlem eller annan sprider eller på annat sätt gör tillgängligt via Yoyyin.
Yoyyin ansvarar ej för att material och information medlemmen gör tillgänglig eller sprider på Yoyyin är i enlighet med bestämmelserna i detta avtal och gällande rätt.

17 § Varje medlem och annan person är fullt ansvarig för all information, övrigt material och personuppgifter vederbörande sprider eller på annat sätt gör tillgängligt via Yoyyin. Detta
innebär att Yoyyin ej tar ansvar för stötande eller brottsligt material, sekretessbrott, förtal eller liknande från medlems sida. Vi ber dig därför att omgående kontakta oss om du upplever något sådant på Yoyyin.

18 § Det är ej tillåtet att manuellt eller automatiskt sprida massmeddelanden via Yoyyin, all kontakt med potentiella affärspartners och liknande skall ske direkt och personligen riktat.

19 § Det är ej tillåtet att utan skriftligt avtal med Yoyyin använda Yoyyin för rekrytering, ej heller för att skapa eller utveckla säljnätverk eller att använda Yoyyin för andra kommersiella syften utöver det i ingressen till detta avtal angivna syftet med Yoyyin.

20 § Genom att acceptera detta avtal godkänner medlemmen att Yoyyin via e-post kontaktar medlemmen med exempelvis nyheter och information.

21 § Avstående att agera i anledning av medlem eller annans kontraktsbrott medför ej att Yoyyin godkänner eller stöder sagda agerande.

22 § Yoyyin arbetar för att alltid kunna ge sina medlemmar hög funktionalitet och ypperlig service. Yoyyin garanterar ej att sidan alltid är nåbar, eller att uppkoppling alltid kan ske utan fördröjning eller hinder. Yoyyin garanterar ej heller att driftsavbrott eller driftstörningar ej sker, och tar inget ansvar för skada som medlem lider av detta.

23 § Om medlemmen vill avsluta sitt medlemskap sker detta genom att följa instruktionerna för avslutande av medlemskap. Dessa finns i anslutning till dina medlemsuppgifter. Vid eventuellt avslutande av medlemsavtal raderas dina personuppgifter omedelbart och permanent från Yoyyins register.

24 § Yoyyin har rätt att avsluta leverans av tjänsten, stänga plattformen permanent eller periodvis samt att avsluta medlemmens avtal utan förvarning, även i det fall avtalsbrott ej skett. Även i de fall Yoyyin avslutar en medlems avtal raderas dennes personuppgifter permanent.

25 § Detta avtal utgör hela avtalet mellan Yoyyin och medlemmen, och ersätter alla eventuella överenskommelser mellan Yoyyin och medlemmen avseende avtalets innehåll.
</textarea>

                        <div class="marginTop"><i>Genom att klicka på "Jag godkänner" nedan accepterar du <a href="Files/AnvandaravtalYoyyinv1_0.pdf" target="_blank">Användarvillkoren</a> ovan och <a href=#>Yoyyins Upphovsrättsliga policy</a>.</i></div>                                
                    </ContentTemplate>
                </asp:CreateUserWizardStep>
                <asp:TemplatedWizardStep runat="server">
                    <ContentTemplate>                        
                        <div class="marginBottom bold">Steg 2 (av 7) - Fyll i personuppgifter</div>
                        
                        <div class="marginBottom">
                            Eventuellt företagsnamn:<br />
                            <asp:TextBox ID="companyName" runat="server" />
                        </div>
                        <div class="marginBottom">
                            <div>
                                Namn:<br /><asp:TextBox ID="name" runat="server" CssClass="required wizTextBox" /><img src="Styles/Images/magnifier.png" alt="Sökbart" class="searchable" />
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="Namn måste anges" CssClass="errorText" ControlToValidate="name" />
                            </div>
                            <div>
                                Alias:<br /><asp:TextBox ID="alias" runat="server" CssClass="wizTextBox" />
                            </div>
                            <div>
                                Gatuadress:<br /><asp:TextBox ID="street" runat="server" CssClass="required" /><img src="Styles/Images/magnifier.png" alt="Sökbart" class="searchable" />
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="Adress måste anges" CssClass="errorText" ControlToValidate="street" />
                            </div>
                            <div class="span-3">Postnummer:</div><div class="span-7 last">Stad/ort</div>
                            <div class="span-3">
                                <asp:TextBox ID="zipCode" runat="server" width="80px" CssClass="required" /><img src="Styles/Images/magnifier.png" alt="Sökbart" class="searchable" />
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="Postnummer måste anges" CssClass="errorText" ControlToValidate="zipCode" />
                            </div>
                            <div class="span-7 last">
                                <asp:TextBox ID="city" runat="server" width="150px" CssClass="required" /><img src="Styles/Images/magnifier.png" alt="Sökbart" class="searchable" />
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="Stad/ort måste anges" CssClass="errorText" ControlToValidate="city" />
                            </div>
                            <div class="clear"></div>
                            <div class="span-3">Telefon:</div><div class="span-7 last">Webbplats: [http://]</div>
                            <div class="span-3"><asp:TextBox ID="phone" runat="server" width="100px" /></div><div class="span-7 last"><asp:TextBox ID="url" runat="server" style="width: 250px;"  /></div>
                        </div>          
                    </ContentTemplate>       
                </asp:TemplatedWizardStep>  
                <asp:TemplatedWizardStep runat="server">
                    <ContentTemplate>         
                        <div class="marginBottom bold">Steg 3 (av 7) - Vad är din roll?</div>               
                        <div>
                            <div class="marginBottom"><input type="radio" name="radioRole" id="radioentrepreneurbusinessman" checked="checked" value="0" title="Företagare/Entreprenör: Jag driver ett företag eller vill starta upp och driva ett företag." /><label for="radioentrepreneurbusinessman">Jag driver ett företag eller vill starta upp och driva ett företag. <strong>(Företagare/Entreprenör)</strong></label></div>
                            <div class="marginBottom"><input type="radio" name="radioRole" id="radioinnovator" value="1" title="Innovatör/Uppfinnare : Jag har idéer som behöver förverkligas." /><label for="radioinnovator">Jag har idéer som behöver förverkligas. <strong>(Innovatör/Uppfinnare)</strong></label></div>
                            <div class="marginBottom"><input type="radio" name="radioRole" id="radioinvestor" value="2" title="Jag söker efter spännande idéer och företag att investera i." /><label for="radioinvestor">Jag söker efter spännande idéer och företag att investera i. <strong>(Finansiär)</strong></label></div>
                            <div class="marginBottom">Något annat:<asp:TextBox ID="txtUserTypeDescription" runat="server" /></div>
                        </div>
                    </ContentTemplate>
                </asp:TemplatedWizardStep> 
                <asp:TemplatedWizardStep runat="server">
                    <ContentTemplate>         
                        <div class="marginBottom bold">Steg 4 (av 7) - Vad söker du?</div>  
                        <asp:Repeater ID="repUserTypes" runat="server">
                            <ItemTemplate>
                                <div class="marginBottomSmall">
                                    <asp:CheckBox ID="chkUserType" runat="server" CssClass="checkBoxUserTypeToggleSlide" data-userType='<%# Eval("Value") %>'
                                        title="<%# WebHelpers.GetUserTypeDescriptionAndTitle(Container.DataItem) %>"
                                        Text="<%# WebHelpers.GetUserTypeDescriptionAndTitle(Container.DataItem) %>" />                               
                                </div>
                                <div id="divEntrepreneur" runat="server" clientidmode="Static" class="userTypesDescriptions" data-userType='<%# Eval("Value") %>'>
                                    <i>Här kan du lägga till valfri text:<br /></i>
                                    <asp:TextBox ID="txtUserTypeDescription" runat="server" CssClass="tbUserTypes" />
                                </div>   
                                <asp:HiddenField ID="hiddenUserType" runat="server" Value='<%# Eval("Value") %>' />                                  
                            </ItemTemplate>
                        </asp:Repeater>   
                    </ContentTemplate>
                </asp:TemplatedWizardStep>                                  
                <asp:TemplatedWizardStep runat="server" Title="Ladda upp" EnableViewState="true">
                    <ContentTemplate>
                        <div class="marginBottom bold">Steg 5 (av 7) - Taggar & Kompetenser</div>
                        <strong>Taggar, din affärsidé</strong><br />
                        För att andra lättare ska kunna hitta din affärsidé kan du tagga den med egenskaper/kompetenser/sökord. Ange dessa nedan separerade med kommatecken.&nbsp;<br /><i>Ex. pizzeria,städbolag,e-handel</i></div>
                        <div>
                            <asp:TextBox ID="txtSearchWords" runat="server" Width="350px" />
                        </div>
                        <div class="marginTop">
                        <strong>Dina egna kompetenser</strong><br />
                        För att andra lättare ska kunna hitta din profil kan du tagga den med kompetenser du har. Ange dessa nedan separerade med kommatecken.&nbsp;<br /><i>Ex. programmering,marknadsföring,köra truck</i></div>
                        <div>
                            <asp:TextBox ID="txtSearchWordsCompetence" runat="server" ClientIDMode="Static" Width="350px" />
                        </div>
                        <div class="marginTop">
                        <strong>Kompetenser du söker</strong><br />
                        Här anger du kompetenser du söker hos en ev affärspartner. Ange dessa nedan separerade med kommatecken.&nbsp;<br /><i>Ex. telefonförsäljning,restaurang</i></div>
                        <div>
                            <asp:TextBox ID="txtSearchWordsCompetenceNeeded" runat="server" ClientIDMode="Static" Width="350px" />
                        </div>
                        <script type="text/javascript">
                            $(document).ready(function() {
                                InitializeAutoComplateMultipleCompetences("txtSearchWordsCompetenceNeeded");
                                InitializeAutoComplateMultipleCompetences("txtSearchWordsCompetence");
                            });
                        </script>

                    </ContentTemplate>
                </asp:TemplatedWizardStep>      

                <asp:TemplatedWizardStep runat="server" Title="Ladda upp" EnableViewState="true">
                    <ContentTemplate>
                        <div class="marginBottom bold">Steg 6 (av 7) - Bild & CV</div>
                        <div>Välj bild till din profil:</div>
                        <div><asp:FileUpload ID="fileImage" runat="server" /></div>

                        <div class="marginTop">Välj en CV/meritförteckning:</div>
                        <div><asp:FileUpload ID="fileCV" runat="server" /></div>

                    </ContentTemplate>
                </asp:TemplatedWizardStep>      
                <asp:TemplatedWizardStep runat="server" Title="Din verksamhet/affårsidé">
                    <ContentTemplate>
                        <div class="marginBottom bold">Sista steget - Presentera din affärsidé</div>
                        <div>Rubrik för din verksamhet/affärsidé:</div>
                        <div class="marginBottom">
                            <asp:TextBox ID="businessTitle" runat="server" /><img src="Styles/Images/magnifier.png" alt="Sökbart" class="searchable" />
                            <br />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="businessTitle" ErrorMessage="Du måste fylla i Rubrik för din verksamhet" CssClass="errorText" />                 
                        </div>
                        <div>Om verksamheten/affärsidén eller om dig själv</div>
                        <div class="marginBottom">
                            <asp:TextBox ID="businessDesc" runat="server" TextMode="MultiLine" Rows="5" Width="330px" Columns="70" /><img src="Styles/Images/magnifier.png" alt="Sökbart" class="searchable" />
                            <br />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="businessDesc" ErrorMessage="Du måste fylla i 'Om verksamheten/affärsidén'" CssClass="errorText" />
                        </div>
                        <div>Välj arbetsområde/affärssegment:</div>
                        <div class="marginBottom">
                            <ajaxToolkit:CascadingDropDown ID="CascadingDropDown1" runat="server"                                
                                TargetControlID="ddlSniHead" 
                                Category="SniHead"                                                                
                                ServiceMethod="GetSniHead"
                                PromptText="Välj först område" />
                                                    
                            <asp:DropDownList ID="ddlSniHead" runat="server"
                                DataTextField="Title"
                                DataValueField="SniHeadID"
                                Width="500px"                                
                                style="position:relative;z-index: 9999;" />                       
                        </div>
                        <div class="marginBottom">
                            <ajaxToolkit:CascadingDropDown
                                ID="CascadingDropDown2"
                                runat="server"
                                TargetControlID="ddlSniItem"
                                ParentControlID="ddlSniHead"
                                ServiceMethod="GetItemsForHead"                                
                                Category="Model" />
                            <asp:DropDownList ID="ddlSniItem" runat="server" ClientIDMode="Static" Width="500px" style="position:relative;z-index: 9999;" />                                                    
                        </div>
                    </ContentTemplate>
                </asp:TemplatedWizardStep>                    
            </WizardSteps>
        </asp:CreateUserWizard>
    </div>
    <div class="span-1">&nbsp;</div>
    <div class="span-6">
        <div class="blueBox">                       
            <div id="divTips" runat="server"></div>                     
        </div><p class="textAlignCenter"><img src="Styles/Images/register.png" /></p>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContentAfterJavaScriptIncluded" runat="server">
    <script type="text/javascript">
        <asp:Literal ID="litJS" runat="server" />
    </script>
</asp:Content>

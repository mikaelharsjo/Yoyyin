var browserCheck = (document.all) ? 1 : 0; // ternary operator statements to check if IE. set 1 if is, set 0 if not.
var _forumUserID = 13009; // guest
function ExecuteAjax(paramArray, method, successCallBack, errorCallBack) {

    //Create list of parameters in the form:
    var paramList = '';
    if (paramArray.length > 0) {
        for (var i = 0; i < paramArray.length; i += 2) {
            if (paramList.length > 0) {
                paramList += ',';
            }
            paramList += '"' + paramArray[i] + '":'
            if (isArray(paramArray[i + 1])) {
                paramList += "[";
                for (var j = 0; j < paramArray[i + 1].length; j++) {
                    if (j > 0) paramList += ",";

                    paramList += '"' + escapeNewLineChars(paramArray[i + 1][j]) + '"'
                }
                paramList += "]";
            }
            else
                paramList += '"' + escapeNewLineChars(paramArray[i + 1]) + '"';
        }
    }
    paramList = '{' + paramList + '}';

    $.ajax({
        type: "POST",
        url: "Service.svc/" + method,
        data: paramList,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: successCallBack,
        error: errorCallBack
    });
}

function MakeAjaxCall(methodName, dataObject, onCompleteMethod, context, onFailMethod) {
    if (dataObject == null)
        dataObject = new Object();

    $.ajax({
        type: "POST",
        url: "/Service.svc/" + methodName,
        data: JSON.stringify(dataObject),
        contentType: "application/json; charset=utf-8",
        dataType: "json",                             //do not specify datatype. it will mess up the datafilter
        success: function (msg) {
            if (msg != null && typeof (msg) != "undefined" && msg.hasOwnProperty('d'))
                msg = msg.d;
            if (typeof onCompleteMethod === "function")
                onCompleteMethod(msg, context);
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            if (onFailMethod != null) {
                onFailMethod(xmlHttpRequest, textStatus, errorThrown);
            }
            else
                OnAjaxFailed(xmlHttpRequest, textStatus, errorThrown);
        }
    });
}

function OnAjaxFailed(xmlHttpRequest, textStatus, errorThrown) {
    alert("Fel vid ajax-anrop: " + xmlHttpRequest.responseText + " " + textStatus + " " + errorThrown);
}


function QuickSearch(text) {    
    Loading("#divAjaxContent");
    ExecuteAjax(["text", text], "QuickSearch", OnQuickSearchSuccess, OnError);
}

function QuickSearchDefault(text) {
    Loading("#divAjaxContentDefault");
    ExecuteAjax(["text", text], "QuickSearch", OnQuickSearchDefaultSuccess, OnError);
}

function OnQuickSearchSuccess(data) {
    $(".hideWhenSearch").hide();
    var sInfo = $("#searchInfo");
    if (sInfo != null)
        sInfo.show();
    $("#divAjaxContent").html(data.d);
}

function OnQuickSearchDefaultSuccess(data) {
    $(".hideWhenSearch").hide();
    var sInfo = $("#searchInfo");
    if (sInfo != null)
        sInfo.show();
    $("#divAjaxContentDefault").html(data.d);
}

function Loading(divLoading) {
    $(divLoading).html('<img src="Styles/Images/ajaxLoader.gif" class="paddingLeft" />');
}

function PopUser(e, clickedLink) {
    var dialog = $("#dialog");
    dialog.css("top", e.pageY);
    dialog.css("left", e.pageX);
    var userID = clickedLink.attr("id");
    if (userID != "")
        ExecuteAjax(["userId", userID], "GetUserProfile", 
            function (data) {
                $("#dialogInner").html(data.d);
                $("#dialog").show();
            }, 
            OnError);
}

function PopSecret(e) {
    var dialog = $("#dialog");

    dialog.css("top", e.pageY);
    dialog.css("left", e.pageX);
        
    //dialog.css("height", "140px");
    dialog.css("width", "280px");
    //dialog.css("left", clickedLink.position().left);

    $("#dialogInner").html("<p>Denna funktion kräver att man är registrerad och inloggad.</p><p>Att bli medlem går snabbt och är gratis. Efter registreringen blir du också själv sökbar för framtida affärspartners.</p><a href='Register.aspx'>Klicka för att bli medlem</a> eller<br/><a id='lnkLogin' onclick='ShowLogin();'>Logga in</a> om du redan är det.");
    dialog.show();
    $("#dialogArrow").show();
}

function OnDialogSuccess(data) {
    if (data.d != "")
        ShowDialog(data.d);
}

function ShowDialog(content) {
    $("#dialogInner").html(content);
    $("#dialog").show();
    $("#dialog").center();
    DisableBackground();
}

function ShowDialogTemporarily(content, milliseconds) {
    if (milliseconds == undefined)
        milliseconds = 3000;
    $("#dialogInner").html(content);
    var dialog = $("#dialog");
    dialog.show();
    dialog.center();
    setTimeout(function () { dialog.hide(); }, milliseconds);
}


function OnDialogMailSuccess(data) {
    DisableBackground();
    $("#dialogMailInner").html(data.d);
    $("#dialogMail").show();
    $("#dialogMail").center();
    $("#dialogMailInner").show();
}



function OnControlLoaded(data) {
    var div = document.getElementById('divAjaxContent');

    if (div != null)
        div.innerHTML = data.d;
}

function searchBoxFocus(textBox, defaultValue) {
    if (defaultValue == textBox.value) {
        textBox.value = '';
        textBox.style.color = '#484848';
        textBox.style.fontStyle = 'normal';
    }
}

function searchBoxBlur(textBox, defaultValue) {
    
    if (textBox.value.length == 0) {
        textBox.value = defaultValue;
        textBox.style.color = '#999999';
        textBox.style.fontStyle = 'italic';
    }
}

function OnError(xhr, ajaxOptions, thrownError) {
    alert("error; " + xhr.status + " " + xhr.responseText);
}

function PopMail(userMessagesID, fromUserId, toUserId) {
    ExecuteAjax(["userMessagesID", userMessagesID, "fromUserId", fromUserId, "toUserId", toUserId], "GetMailPop", OnDialogMailSuccess, OnError);
}

function SendMail(fromUserId, toUserId, message) {
    if (message.length > 0) {
        Loading("#divMailLoader");
        ExecuteAjax(["fromUserId", fromUserId, "toUserId", toUserId, "message", message], "SendMail", CloseMailPop, OnError);
    }
}

function SaveComment(fromUserId, toUserId, text, commentID) {
    if (commentID == undefined)
        commentID = 0;
    ExecuteAjax(["fromUserId", fromUserId, "toUserId", toUserId, "text", text, "commentID", commentID], "SaveComment", function () { $("#txtComment").val(""); LoadComments(toUserId, 500); }, OnError);
    return false;
}

function LoadComments(userId, textAreaWidth) {
    //ExecuteAjax(["userId", userId], "LoadComment", OnCommentsLoaded, OnError);
    MakeAjaxCall("LoadComment", { userId: userId, textAreaWidth: textAreaWidth }, OnCommentsLoaded, OnError);
}

function OnCommentsLoaded(data) {
    $(".comments").html(data);
}

function CloseMailPop() {
    $("#divMailLoader").html("<span class='greenText'>Meddelandet har skickats</span>");
    $('#dialogMail').hide();
    $('#txtMessage').val("");
    $("#popBg").hide();
}

function searchKeyPress(e) {
    // look for window.event in case event isn't passed in
    if (window.event) { e = window.event; }
    if (e.keyCode == 13) {
        QuickSearch(document.getElementsByName("txtSearch")[0].value);
    }
}

function disableEnterKey(e) {
    //alert(e);
    var key;
    if (window.event)
        key = window.event.keyCode; //IE
    else
        key = e.which; //firefox      

    return (key != 13);
}

function detectFile() {
    var idval = document.getElementById("fileUpload").value;
 
    if (idval.length > 5)
    {
        if (idval.indexOf(":") && idval.indexOf("."))
        {
            document.getElementById("btnFileUpload").click();
        }
    }
}

jQuery.fn.center = function (absolute) {
    return this.each(function () {
        var t = jQuery(this);

        t.css({
            position: absolute ? 'absolute' : 'fixed',
            left: '50%',
            top: '50%',
            zIndex: '99'
        }).css({
            marginLeft: '-' + (t.outerWidth() / 2) + 'px',
            marginTop: '-' + (t.outerHeight() / 2) + 'px'
        });

        if (absolute) {
            t.css({
                marginTop: parseInt(t.css('marginTop'), 10) + jQuery(window).scrollTop(),
                marginLeft: parseInt(t.css('marginLeft'), 10) + jQuery(window).scrollLeft()
            });
        }
    });
};

function slideSwitch() {
    var $active = $('#slideshow DIV.active');

    if ($active.length == 0) $active = $('#slideshow DIV:last');

    // use this to pull the images in the order they appear in the markup
    var $next = $active.next().length ? $active.next()
        : $('#slideshow DIV:first');

    // uncomment the 3 lines below to pull the images in random order

    // var $sibs  = $active.siblings();
    // var rndNum = Math.floor(Math.random() * $sibs.length );
    // var $next  = $( $sibs[ rndNum ] );


    $active.addClass('last-active');

    $next.css({ opacity: 0.0 })
        .addClass('active')
        .animate({ opacity: 1.0 }, 3000, function () {
            $active.removeClass('active last-active');
        });
}

function OnFeedBackSuccess() {
    $("#feedBackText").html("Meddelandet har tagits emot, Tack för att du hjälper till att förbättra Yoyyin.");
    setTimeout(EnableBackground, 2000);
}

function escapeNewLineChars(valueToEscape) {
    if (isNaN(valueToEscape)) {
        if (valueToEscape != null && valueToEscape != "") {
            var tmp = valueToEscape.replace(/\n/g, "\\n");
            return tmp.replace(/"/g, "'");
        } else {
            return valueToEscape;
        }
    }
    else
        return valueToEscape;
}

function isArray(obj) {
    return obj.constructor == Array;
}

function ShowLogin() {
    $("#popBg").show();
    var login = $("#divLogin");
    login.show();
    login.center();
    $(".userNameInLoginDialog").focus();

    $("#popBg").click(function () {
        login.hide();
        $("#popBg").hide();
    });
}

function DeleteUser(userId) {
    ExecuteAjax(["userId", userId], "DeleteUser", function () { $(".deleteAccountButton").hide(); $("#divDeleteMessage").html("<p>Ditt konto är nu avslutat</p><p>Välkommen åter.</p><br />"); setTimeout(function () { location.href = "Default.aspx"; }, 2000); }, OnError);
}

function InActivateUser(userId) {
    ExecuteAjax(["userId", userId], "InActivateUser", function () { $("#divDelete").hide(); $("#divInactivateMessage").html("<p>Ditt konto är nu avaktiverat</p><br />"); $("#divInactivate").show(); }, OnError);

}

function InitializeFeed() {
    var feeds = [
            {
                title: 'Svenskt näringsliv',
                url: 'http://www.svensktnaringsliv.se/rss/toppnyheter.xml'
            },
            {
                title: 'Skatteverket',
                url: 'http://www.skatteverket.se/4.dfe345a107ebcc9baf800017640/12.dfe345a107ebcc9baf800017646.portlet?state=rss&contentType=text/xml;charset=UTF-8'
            },
            {
                title: 'Bloggat om företagande och entreprenörskap',
                url: 'http://www.twingly.com/search.rss?q=entrepren%C3%B6r+|+aff%C3%A4rspartner|f%C3%B6retagare|aff%C3%A4rsid%C3%A9'
            }
          ];

    var options = {
        stacked: true,
        horizontal: false,
        title: "L&#228;sv&#228;rt för f&ouml;retagare"
    };

    new GFdynamicFeedControl(feeds, 'feedGadget', options);
}

function DisableBackground() {
    $('#popBg').show();
    $('#popBg').click(function () {
        EnableBackground();
    });
}

function EnableBackground() {
    $('#popBg').hide();
    $('#dialog').hide();
    $('.dialog').hide();
    $('#divDialog').hide();
}


function InitializeMasterPage() {
    google.load('feeds', '1');

    var _gaq = _gaq || [];
    _gaq.push(['_setAccount', 'UA-19929748-1']);
    _gaq.push(['_setDomainName', '.yoyyin.com']);
    _gaq.push(['_trackPageview']);

    (function () {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
    })();

    $(document).ready(function () {

        $("a:[href='Register.aspx']").hide();

        $("#lnkContactYoyyin").click(function () {
            DisableBackground();
            ExecuteAjax(["controlName", "Contact"], "LoadControl", function (data) { EnableBackground(); $("#divAjaxContent").html(data.d); $("#mainDiv").html(""); }, OnError);
        });

        $("#lnkAdvancedSearch").click(function () {
            DisableBackground();
            MakeAjaxCall("LoadControl", { controlName: "AdvancedSearch" }, function (data) { EnableBackground(); $("#divAjaxContent").html(data); $("#mainDiv").html(""); }, OnError);
        });


        $("#tabs").tabs();

        _forumUserID = $("#hiddenForumUserID").val();

        $("#btnSearch").click(function () {
            QuickSearch(document.getElementsByName("txtSearch")[0].value);
        });

        $("#btnSearchTop").click(function () {
            QuickSearch(document.getElementsByName("txtSearchTop")[0].value);
        });

        $("#btnSearchDefault").click(function () {
            QuickSearchDefault(document.getElementsByName("txtSearch")[0].value);
        });

        
        $("#txtSearch").autocomplete({ source: 'Handlers/ProfileSearchAutoCompleteHandler.ashx' });
        $("#txtSearchTop").autocomplete({ source: 'Handlers/ProfileSearchAutoCompleteHandler.ashx' });

        $("#txtSearch").keyup(function (event) {
            if (event.keyCode == 13) {
                QuickSearch(document.getElementsByName("txtSearch")[0].value);
            }
        });

        $("#txtSearch").keyup(function (event) {
            if (event.keyCode == 13) {
                QuickSearch(document.getElementsByName("txtSearch")[0].value);
            }
        });

        $("#txtSearchTop").keyup(function (event) {
            if (event.keyCode == 13) {
                QuickSearch(document.getElementsByName("txtSearchTop")[0].value);
            }
        });

        $(".popLink").hoverIntent(ShowPop, HidePop);

        function ShowPop(e) {
            PopUser(e, $(this));
        }
        function HidePop() {
            $("#dialog").hide();
            $("#dialogArrow").hide();
        }

        $(".secretLink").click(function () {
            return false;
        });

        var config = {
            over: ShowSecret, // function = onMouseOver callback (REQUIRED)    
            timeout: 4000, // number = milliseconds delay before onMouseOut    
            out: HideSecret // function = onMouseOut callback (REQUIRED)    
        };

        $(".secretLink").hoverIntent(config);

        function ShowSecret(e) {
            PopSecret(e);
        }

        function HideSecret() {
            $("#dialog").hide();
            $("#dialogArrow").hide();
        }

        $("#lnkLogin").click(function (e) {
            ShowLogin();

        });

        $(".passwordRecovery").click(function (e) {
            $("#divLogin").hide();
            $("#divPasswordRecovery").show();
            $("#divPasswordRecovery").center();
            $("#popBg").show();

            $("#popBg").click(function () {
                $("#divPasswordRecovery").hide();
                $("#popBg").hide();
            });
        });

        $(".feedBack").click(function (e) {
            $("#divFeedBack").center();
            $("#divFeedBack").show();
            $("#popBg").show();

            $("#popBg").click(function () {
                $("#divFeedBack").hide();
                $("#popBg").hide();
            });
        });

        $("#btnFeedBack").click(function () {
            Loading("#feedBackText");
            var email = $("#txtFBEmail").val();
            var name = $("#txtFBName").val();
            var subject = $("#txtFBSubject").val();
            var body = $("#txtFBBody").val();

            if ((email + name + subject + body).length > 0) {
                body = name + " " + body;
                ExecuteAjax(["fromEmail", email, "toEmail", "", "subject", subject, "body", body], "SendMailSmtp", OnFeedBackSuccess, function () { HideLoading(); });
            }
        });

        $(".dialogClose").click(function (e) {
            $(".dialog").hide();
            $("#popBg").hide();
        });

        $(".checkBoxUserTypeToggleSlide").change(function () {
            var userTypeSelected = $(this).attr("data-userType");
            $("div.userTypesDescriptions").each(function () {
                var userType = $(this).attr("data-userType");
                if (userType == userTypeSelected)
                    $(this).slideToggle();
            });
        });
    });

    $(document).ready(function () {

        $(".lnkQuestion").click(function () {
            ExecuteAjax(["TopicID", $(this).attr("topicID")], "GetTopic",
                    function (data) {
                        $("#divFeedBack").html(data.d); $("#divFeedBack").center(); $("#divFeedBack").show(); $("#popBg").show();
                        $("#popBg").click(function () {
                            $("#divFeedBack").hide();
                            $("#popBg").hide();
                        });
                    },
                    OnError);
        });

        if ($("#hiddenLoggedIn").val() == "true")
            $(".slideRight").hide();

        InitializeFeed();

        $("#btnPostQuestionToForum").click(function () {
            var dictionary = new Array();
            dictionary[0] = AddJSONItem("Text", $("#txtForumQuestion").val());

            MakeAjaxCall("LoadControlWithParams", { controlName: "ForumChoose", dictionary: dictionary }, function (data) { ShowDialog(data); });

            return false;
        });


        $(".tblMail").dataTable({
            //"bJQueryUI": true,
            "aaSorting": [[ 0, "desc" ]],            
            "iDisplayLength": 5,
            "aLengthMenu": [[5, 25, 100, -1], [5, 25, 100, "Alla"]],
            //"aoColumns": [{ "bSortable": false }],
            "oLanguage": {                
                "sLengthMenu": "Visar _MENU_ st",
                "sPrevious": "Föregående",
                "sNext": "Nästa",
                "sSearch": "Sök",
                "sInfoFiltered": "(filtrerat från totalt _MAX_ st)"
            },
            "bSort": false
        });
    });

    $(function () {
        setInterval("slideSwitch()", 10000);
    });
    

    /* Facebook stuff */
    window.fbAsyncInit = function () {
        FB.init({ appId: '121423681248178', status: true, cookie: true,
            xfbml: true
        }); // 107424245989069
    };
    (function () {
        var e = document.createElement('script');
        e.type = 'text/javascript';
        e.src = document.location.protocol +
          '//connect.facebook.net/en_US/all.js';
        e.async = true;
        document.getElementById('fb-root').appendChild(e);
    } ());
}

// TODO: Remove visitingUserId, ICurrentUser should do
function InitializeMemberPage(currentUserId, visitingUserId) {
    $(document).ready(function () {
        LoadComments(currentUserId, 500);

        $("#btnMatch").click(function () {
            GetMatcher(visitingUserId, currentUserId);
        });

        $("#lnkInactivate").click(function () {
            $("#divInactivate").show();
            $("#divInactivate").center();
            $('#popBg').show();
            $('#popBg').click(function () {
                $('#divInactivate').hide();
                $('#popBg').hide();
            });
        });

        $("#lnkDelete").click(function () {
            $("#divDelete").show();
            $("#divDelete").center();
            $('#popBg').show();
            $('#popBg').click(function () {
                $('#divDelete').hide();
                $('#popBg').hide();
            });
        });

        $("#lnkChangePasswordDialog").click(function () {
            $("#divChangePasswordDialog").show();
            $("#divChangePasswordDialog").center();
            $('#popBg').show();
            $('#popBg').click(function () {
                $('#divChangePasswordDialog').hide();
                $('#popBg').hide();
            });
        });

        $("#lnkBookmark").click(function () {
            if (visitingUserId == currentUserId)
                alert("Du kan inte addera dig själv.");
            else
                ExecuteAjax(["bookmarkUserID", currentUserId], "AddBookmark", function () { ShowDialogTemporarily("Kontakten är sparad"); }, OnError);
        });
    });
}

function AddJSONItem(key, value) {
    return { "Key": key, "Value": value };
}

function ShowQuestionDialog(html) {
    ShowDialog(html);

    $("#txtAnswerDialog").focus();
    $("#txtQuestionDialog").focus();
}

function GetQuestionAnswers(dictionary) {
    MakeAjaxCall("LoadControlWithParams", { controlName: "Question", dictionary: dictionary }, function (data) { $("#holderForQuestionControl").html(data); });
}

function GetMatcher(firstUserId, secondUserId) {
    var dictionary = new Array();
    dictionary[0] = AddJSONItem("FirstUserId", firstUserId);
    dictionary[1] = AddJSONItem("SecondUserId", secondUserId);

    MakeAjaxCall("LoadControlWithParams", { controlName: "MatcherControl", dictionary: dictionary }, function (data) { $("#dialog").css("width", "700px"); ShowDialog(data); });
}

/* AutoComplete Helpers */
function split(val) {
    return val.split(/,\s*/);
}
function extractLast(term) {
    return split(term).pop();
}

function InitializeAutoComplateMultipleCompetences(textBoxId) {
    $("#" + textBoxId)
        // don't navigate away from the field on tab when selecting an item
        .bind("keydown", function(event) {
            if (event.keyCode === $.ui.keyCode.TAB &&
                $(this).data("autocomplete").menu.active) {
                event.preventDefault();
            }
        })
        .autocomplete({
                source: function(request, response) {
                    $.getJSON("Handlers/CompetencesAutoCompleteHandler.ashx", {
                        term: extractLast(request.term)
                    }, response);
                },
                search: function() {
                    // custom minLength
                    var term = extractLast(this.value);
                },
                focus: function() {
                    // prevent value inserted on focus
                    return false;
                },
                select: function(event, ui) {
                    var terms = split(this.value);
                    // remove the current input
                    terms.pop();
                    // add the selected item
                    terms.push(ui.item.value);
                    // add placeholder to get the comma-and-space at the end
                    terms.push("");
                    this.value = terms.join(", ");
                    return false;
                }
            });
}

/* End AutoComplete Helpers */
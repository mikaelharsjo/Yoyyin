
/// <reference path="../../sammy.js" />
yoyyin.register = function ($, sammy, mustache) {

    var buttonsMarkup = "<div class='form-actions'><a class='btn' href='/#/register/{{previousStep}}'>Föregående</a><a class='btn btn-primary' href='/#/register/{{nextStep}}'>Nästa</a></div><form>";

    var appendButtons = function (step) {
        var buttons = mustache.to_html(buttonsMarkup, step);
        return step.markup + buttons;
    };

    var setHero = function (params) {
        require(["text!../../Templates/Register/hero.htm"], function (heroTemplate) {
            if ($(".featured").html() == null) {
                $("#body").prepend(mustache.render(heroTemplate, params));
            } else {
                setQuestion(params.Headline);
                setDescription(params.Description);
            }
        });
    };

    var setQuestion = function (question) {
        $(".featured").find("h1").text(question);
    };

    var setDescription = function (description) {
        $(".featured").find("p").text(description);
    };

    var appRegister = $.sammy("#sectionMainContent", function () {
        this.get("#/register/personalInfo", function (context) {

            require(["text!../../Templates/Register/personalInfo.htm"], function (template) {
                setHero({ Headline: "Kul att du vill bli medlem, först vill vi höra om dig själv" });

                context.swap(appendButtons({ markup: template, previousStep: "personalInfo", nextStep: "wanted" }));
                // TODO: move to module
                $.get("/Tagging/Competences/", function (competences) {
                    $("#competences").tagit({ availableTags: competences });
                });
            });
        });

        this.get("#/register/wanted", function (context) {
            setHero({ Headline: "Vad söker du?" });

            require(["text!../../Templates/Register/wanted.htm", "register/wanted"], function (template, wanted) {
                context.swap(appendButtons({ markup: template, previousStep: "personalInfo", nextStep: "location" }));
                wanted.init();
            });
        });

        this.get("#/register/location", function (context) {
            setHero({
                Headline: "Vilken adress ska användas för visning på karta?",
                Description: "Vi har hämtat adressen nedan från din nuvarande position. Vi använder bara denna för visning på karta och liknande i samband med sökningar."
            });

            // had trouble moving this to templates
            var template = "<div class='ui-helper-clearfix'><div class='stepLeft'><label class='control-label' for='street'>Gatuadress:</label><input type='text' class='input-xlarge' id='street' value='{{Street}}' /><label class='control-label' for='zipCode'>Postnummer:</label><input type='text' class='input-xlarge' id='zipCode' value='{{ZipCode}}' /><label class='control-label' for='city'>Stad/ort:</label><input type='text' class='input-xlarge' id='city' value='{{City}}' /><label class='control-label' for='city'>Land:</label><input type='text' class='input-xlarge' id='country' value='{{Country}}' /></div><div id='registerMap' class='stepRight thumbnail'></div></div>";

            require(["register/location"], function (location) {
                location.getContent(function (data) {
                    var html = mustache.render(template, data);
                    context.swap(appendButtons({ markup: html, previousStep: "wanted", nextStep: "userType" }));

                    $("div.form-actions").append("<a class='btn btn-warning' href='/#/register/userType'>Visa mig inte på kartor</a>")
                });
            });
        });

        this.get("#/register/userType", function (context) {
            setHero({ Headline: "Vilken är din roll/titel?" });

            require(["register/userType"], function (userType) {
                userType.init(function (html) {
                    context.swap(appendButtons({ markup: html, previousStep: "location", nextStep: "userTypesNeeded" }), function () {

                        $("#btnSaveUserType").click(function () {
                            $(this).button("loading");
                            userType.save();
                        });
                    });
                });
            });
        });

        this.get("#/register/userTypesNeeded", function (context) {
            setHero({ Headline: "Vilken sorts affärspartner söker du?" });

            require(["register/userTypesNeeded"], function (userTypesNeeded) {
                userTypesNeeded.init(function (html) {
                    context.swap(appendButtons({ markup: html, previousStep: "userType", nextStep: "tags" }), function () {

                        $("#btnSaveUserType").click(function () {
                            $(this).button("loading");
                            userType.save();
                        });

                        $(":checkbox").change(function () {
                            if ($(this).is(":checked")) {
                                $(this)
                                    .parent()
                                    .append($("<div><label>Lägg till valfri text: <input type='text' /></label></div>"));
                            } else {
                                $(this)
                                    .parent()
                                    .find("div")
                                    .remove();
                            }
                        });
                    });
                });
            });
        });

        this.get("#/register/tags", function (context) {
            setHero({ Headline: "Vilka kompetenser söker du?" });

            require(["text!../../Templates/Register/tags.htm", "register/tags"], function (template, tags) {

                context.swap(appendButtons({ markup: template, previousStep: "userTypesNeeded", nextStep: "upload" }), function () {
                    tags.init();
                    $.get("/Matching/GetQuickSearchTypeAheadItems/", function (items) {
                        $("#tags").tagit({ availableTags: items });
                    });

                    $.get("/Tagging/Competences/", function (competences) {
                        $("#competencesNeeded").tagit({ availableTags: competences });
                    });
                });
            });
        });

        this.get("#/register/upload", function (context) {
            setHero({ Headline: "Bild och CV" });

            require(["text!../../Templates/Register/upload.htm"], function (template) {
                context.swap(appendButtons({ markup: template, previousStep: "tags", nextStep: "idea" }));
            });
        });

        this.get("#/register/idea", function (context) {
            setHero({ Headline: "Sista steget - Nu vill vi höra om din affärsidé" });

            require(["text!../../Templates/Register/idea.htm", "register/idea"], function (template, idea) {
                context.swap(appendButtons({ markup: template, previousStep: "upload", nextStep: "idea" }));
                idea.init();
                $("div.form-actions").append("<a class='btn btn-warning' href='/#/register/userType'>Jag har ingen affärsidé</a>");
            });
        });
    });

    $(function () {
        appRegister.run();
    });

} (jQuery, Sammy, Mustache);
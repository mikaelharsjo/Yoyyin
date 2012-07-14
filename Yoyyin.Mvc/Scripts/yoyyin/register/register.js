/// <reference path="../../sammy.js" />
yoyyin.register = function ($, sammy, mustache, location, userType, userTypesNeeded, tags) {
    var buttonsMarkup = "<div class='form-actions'><a class='btn' href='/#/register/{{previousStep}}'>Föregående</a><a class='btn btn-primary' href='/#/register/{{nextStep}}'>Nästa</a></div><form>";

    var appendButtons = function (step) {
        var buttons = mustache.to_html(buttonsMarkup, step);
        return step.markup + buttons;
    };

    var setQuestion = function (question) {
        $(".featured").find("h1").text(question);
    };

    var setDescription = function (description) {
        $(".featured").find("p").text(description);
    };

    var appRegister = $.sammy("#sectionMainContent", function () {
        this.get("#/register/personalInfo", function (context) {
            setQuestion("Kul att du vill bli medlem, först vill vi höra om dig själv");
            setDescription("");

            require(["text!../Templates/Register/personalInfo.htm"], function (template) {
                context.swap(appendButtons({ markup: template, previousStep: "personalInfo", nextStep: "location" }));
                $.get("/Tagging/Competences/", function (competences) {
                    $("#competences").tagit({ availableTags: competences });
                });
            });
        });

        this.get("#/register/location", function (context) {
            setQuestion("Vilken adress ska användas för visning på karta?");
            setDescription("Vi har hämtat adressen nedan från din nuvarande position. Vi använder bara denna för visning på karta och liknande i samband med sökningar.");
            // had trouble moving this to templates
            var template = "<div class='ui-helper-clearfix'><div class='stepLeft'><label class='control-label' for='street'>Gatuadress:</label><input type='text' class='input-xlarge' id='street' value='{{Street}}' /><label class='control-label' for='zipCode'>Postnummer:</label><input type='text' class='input-xlarge' id='zipCode' value='{{ZipCode}}' /><label class='control-label' for='city'>Stad/ort:</label><input type='text' class='input-xlarge' id='city' value='{{City}}' /><label class='control-label' for='city'>Land:</label><input type='text' class='input-xlarge' id='country' value='{{Country}}' /></div><div id='registerMap' class='stepRight thumbnail'></div></div>";

            location.getContent(function (data) {
                var html = mustache.render(template, data);
                context.swap(appendButtons({ markup: html, previousStep: "personalInfo", nextStep: "userType" }));

                $("div.form-actions").append("<a class='btn btn-warning' href='/#/register/userType'>Visa mig inte på kartor</a>")
            });
        });

        this.get("#/register/userType", function (context) {
            setQuestion("Vilken är din roll/titel?");
            setDescription("");

            userType.init(function (html) {
                context.swap(appendButtons({ markup: html, previousStep: "location", nextStep: "userTypesNeeded" }), function () {

                    $("#btnSaveUserType").click(function () {
                        $(this).button("loading");
                        userType.save();
                    });
                });
            });
        });

        this.get("#/register/userTypesNeeded", function (context) {
            setQuestion("Vad söker du?");
            setDescription("");
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
                        }
                        else {
                            $(this)
                                    .parent()
                                    .find("div")
                                    .remove();
                        }
                    });
                });
            });
        });

        this.get("#/register/tags", function (context) {
            setQuestion("Vilka kompetenser har du/söker du?");
            tags.setDescription();

            require(["text!../Templates/Register/tags.htm"], function (template) {
                context.swap(appendButtons({ markup: template, previousStep: "userTypesNeeded", nextStep: "upload" }), function () {
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
            setQuestion("Bild och CV");
            setDescription("");

            require(["text!../Templates/Register/upload.htm"], function (template) {
                context.swap(appendButtons({ markup: template, previousStep: "tags", nextStep: "idea" }));
            });
        });

        this.get("#/register/idea", function (context) {
            setQuestion("Sista steget - Nu vill vi höra om din affärsidé");
            setDescription("");

            require(["text!../Templates/Register/idea.htm"], function (template) {
                context.swap(appendButtons({ markup: template, previousStep: "upload", nextStep: "idea" }));

                $("div.form-actions").append("<a class='btn btn-warning' href='/#/register/userType'>Jag har ingen affärsidé</a>")
            });
        });
    });

    $(function () {
        appRegister.run();
    });

} (jQuery, Sammy, Mustache, yoyyin.register.location, yoyyin.register.userType, yoyyin.register.userTypesNeeded, yoyyin.register.tags);
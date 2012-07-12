/// <reference path="../../sammy.js" />
yoyyin.register =  function ($, sammy, mustache, location, userType, userTypesNeeded, tags) {
        var buttonsMarkup = "<div class='form-actions'><a class='btn' href='/#/register/{{previousStep}}'>Föregående</a> <a class='btn btn-primary' href='/#/register/{{nextStep}}'>Nästa</a></div><form>";

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
                require(["text!HTMLPage1.tpl"], function(template){
                    context.swap(appendButtons({ markup: template, previousStep: "personalInfo", nextStep: "location" }));    
                });
                var stepPersonalMarkup = "<div><label class='control-label' for='name'>Namn:</label><input type='text' class='input-xlarge' id='name' /><p class='help-block'>Supporting help text</p><label class='control-label' for='alias'>Alias:</label><input type='text' class='input-xlarge' id='alias' /><p class='help-block'>Supporting help text</p></div>";

                setQuestion("Först behöver vi lite personuppgifter");
                setDescription("");

                
            });

            this.get("#/register/location", function (context) {
                setQuestion("Vilken adress ska användas för visning på karta?");
                setDescription("Vi använder bara din address...");
                var stepLocationMarkup = "<div class='ui-helper-clearfix'><div class='stepLeft'><label class='control-label' for='street'>Gatuadress:</label><input type='text' class='input-xlarge' id='street' value='{{Street}}' /><label class='control-label' for='zipCode'>Postnummer:</label><input type='text' class='input-xlarge' id='zipCode' value='{{ZipCode}}' /><label class='control-label' for='city'>Stad/ort:</label><input type='text' class='input-xlarge' id='city' value='{{City}}' /><label class='control-label' for='city'>Land:</label><input type='text' class='input-xlarge' id='country' value='{{Country}}' /><label class='checkbox'><input type='checkbox'> Visa mig inte på kartan</label></div><div id='registerMap' class='stepRight thumbnail'></div></div>";
                
                location.getContent(function (data) {
                    var html = mustache.render(stepLocationMarkup, data);
                    context.swap(appendButtons({ markup: html, previousStep: "personalInfo", nextStep: "userType" }));
                });
            });

            this.get("#/register/userType", function (context) {
                setQuestion("Vilken är din roll?");
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
                var tagsMarkup = "<h3>Dina kompetenser</h3><label>För att andra lättare ska kunna hitta din profil kan du lägga till kompetenser du har. För kortare meningar skriv bindestreck.<br /><i>Ex. programmering,marknadsföring,köra-truck</i></div><ul id='competences'></ul></label><h3>Kompetenser du söker</h3><label>Här anger du kompetenser du söker hos en ev affärspartner.<br /><i>Ex. telefonförsäljning,restaurang</i></label><ul id='competencesNeeded'></ul><h3>Tagga din affärsidé</h3><label>För att andra lättare ska kunna hitta din affärsidé kan du lägga till egenskaper/taggar.<br /><i>Ex. pizzeria,städbolag,e-handel</i></label><ul id='tags'></ul>";

                context.swap(appendButtons({ markup: tagsMarkup, previousStep: "userTypesNeeded", nextStep: "upload" }), function () {
                    $.get("/Matching/GetQuickSearchTypeAheadItems/", function (items) {
                        $("#tags").tagit({ availableTags: items });
                    });

                    $.get("/Tagging/Competences/", function (competences) {
                        $("#competences").tagit({ availableTags: competences });
                        $("#competencesNeeded").tagit({ availableTags: competences });
                    });
                });
                //));
            });

            this.get("#/register/upload", function (context) {
                setQuestion("Bild och CV");
                setDescription("");
                var uploadMarkup = "<label>Välj bild till din profil: <input type='file' /></label><label>Välj en CV/meritförteckning: <input type='file' /></label>";
                context.swap(appendButtons({ markup: uploadMarkup, previousStep: "tags", nextStep: "idea" }));
            });

            this.get("#/register/idea", function (context) {
                setQuestion("Sista steget - Nu vill vi höra om din affärsidé");
                setDescription("");
                var ideaMarkup = "<div class='ui-helper-clearfix'><div class='stepLeft'><label for='title'>Rubrik för din verksamhet/affärsidé:</label><input type='text' id='title' class='input-xlarge' /><label for='description'>Om verksamheten/affärsidén eller om dig själv:</label><textarea class='input-xlarge' id='description' /></div><div class='stepRight'><label>Välj arbetsområde/affärssegment:</label><select class='input-xlarge'></select></div></div>";
                context.swap(appendButtons({ markup: ideaMarkup, previousStep: "upload", nextStep: "idea" }));
            });
        });

        $(function () {
            appRegister.run();
        });

    } (jQuery, Sammy, Mustache, yoyyin.register.location, yoyyin.register.userType, yoyyin.register.userTypesNeeded, yoyyin.register.tags);
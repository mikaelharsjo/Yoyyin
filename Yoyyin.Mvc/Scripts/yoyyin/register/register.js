/// <reference path="../../sammy.js" />
yoyyin.register.location =
    function ($, sammy, mustache, location, userType, userTypesNeeded) {
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


            this.get("#/register/:step", function (context) {
                var step = this.params["step"];

                var stepPersonalMarkup = "<div><label class='control-label' for='name'>Namn:</label><input type='text' class='input-xlarge' id='name' /><p class='help-block'>Supporting help text</p><label class='control-label' for='alias'>Alias:</label><input type='text' class='input-xlarge' id='alias' /><p class='help-block'>Supporting help text</p></div>";
                var stepLocationMarkup = "<div class='ui-helper-clearfix'><div class='stepLeft'><label class='control-label' for='street'>Gatuadress:</label><input type='text' class='input-xlarge' id='street' value='{{Street}}' /><label class='control-label' for='zipCode'>Postnummer:</label><input type='text' class='input-xlarge' id='zipCode' value='{{ZipCode}}' /><label class='control-label' for='city'>Stad/ort:</label><input type='text' class='input-xlarge' id='city' value='{{City}}' /><label class='control-label' for='city'>Land:</label><input type='text' class='input-xlarge' id='country' value='{{Country}}' /><label class='checkbox'><input type='checkbox'> Visa mig inte på kartan</label></div><div id='registerMap' class='stepRight thumbnail'></div></div>";

                switch (step) {
                    case "personalInfo":
                        setQuestion("Först behöver vi lite personuppgifter");
                        setDescription("");

                        context.swap(appendButtons({ markup: stepPersonalMarkup, previousStep: "personalInfo", nextStep: "location" }));

                        break;
                    case "location":
                        setQuestion("Vilken adress ska användas för visning på karta?");
                        setDescription("Vi använder bara din address...");
                        location.getContent(function (data) {
                            var html = mustache.render(stepLocationMarkup, data);
                            context.swap(appendButtons({ markup: html, previousStep: "personalInfo", nextStep: "userType" }));
                        });

                        //alert("location getContent");

                        break;
                    case "userType":
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

                        break;

                    case "userTypesNeeded":
                        setQuestion("Vad söker du?");
                        setDescription("");

                        userTypesNeeded.init(function (html) {
                            context.swap(appendButtons({ markup: html, previousStep: "userType", nextStep: "userTypesNeeded" }), function () {

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
                }
            });
        });

        $(function () {
            appRegister.run("#/register/userType");
        });

    } (jQuery, Sammy, Mustache, yoyyin.register.location, yoyyin.register.userType, yoyyin.register.userTypesNeeded);
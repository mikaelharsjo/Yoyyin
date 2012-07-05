yoyyin.register.location =
    function ($, sammy, mustache, location, userType) {
        var buttonsMarkup = "<div class='form-actions'><a class='btn' href='/#/register/{{previousStep}}'>Föregående</button> <a class='btn btn-primary' href='/#/register/{{nextStep}}'>Nästa</a></div><form>";

        var appendButtons = function (step) {
            var buttons = mustache.to_html(buttonsMarkup, step);
            return step.markup + buttons;
        };

        var appRegister = $.sammy("#sectionMainContent", function () {


            this.get("#/register/:step", function (context) {
                var step = this.params["step"];

                var stepPersonalMarkup = "<section><hgroup class='title'><h1>Först behöver vi lite personuppgifter.</h1></hgroup></div></section><div class='main-content'><label class='control-label' for='name'>Namn:</label><input type='text' class='input-xlarge' id='name' /><p class='help-block'>Supporting help text</p><label class='control-label' for='alias'>Alias:</label><input type='text' class='input-xlarge' id='alias' /><p class='help-block'>Supporting help text</p></div>";
                var stepLocationMarkup = "<section><hgroup class='title'><h1>Vilken adress ska användas för visning på karta?</h1></hgroup></div></section><div class='ui-helper-clearfix'><div class='stepLeft'><label class='control-label' for='street'>Gatuadress:</label><input type='text' class='input-xlarge' id='street' value='{{Street}}' /><label class='control-label' for='zipCode'>Postnummer:</label><input type='text' class='input-xlarge' id='zipCode' value='{{ZipCode}}' /><label class='control-label' for='city'>Stad/ort:</label><input type='text' class='input-xlarge' id='city' value='{{City}}' /><label class='control-label' for='city'>Land:</label><input type='text' class='input-xlarge' id='country' value='{{Country}}' /><label class='checkbox'><input type='checkbox'> Visa mig inte på kartan</label></div><div id='registerMap' class='stepRight thumbnail'></div></div>";
                var stepUserTypeTemplate = "<h1>Vad är din roll?</h1>";

                switch (step) {
                    case "personalInfo":
                        context.swap(appendButtons({ markup: stepPersonalMarkup, previousStep: "personalInfo", nextStep: "location" }));

                        break;
                    case "location":
                        location.getContent(function (data) {
                            var html = mustache.render(stepLocationMarkup, data);
                            context.swap(appendButtons({ markup: html, previousStep: "personalInfo", nextStep: "userType" }));
                        });

                        //alert("location getContent");

                        break;
                    case "userType":
                        userType.init(function (data) {
                            console.log(data);
                            var html = stepUserTypeTemplate + "<div>" +  data + "</div>";
                            console.log(html);
                            context.swap(appendButtons({ markup: html, previousStep: "location", nextStep: "location" }));
                        });

                        break;
                }
            });
        });

        $(function () {
            appRegister.run("#/register/userType");
        });

    } (jQuery, Sammy, Mustache, yoyyin.register.location, yoyyin.register.userType);
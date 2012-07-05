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
                var stepUserType = "<h1>Vad är din roll?</h1><div></div>";


                switch (step) {
                    case "personalInfo":
                        context.swap(appendButtons({ markup: stepPersonalMarkup, previousStep: "personalInfo", nextStep: "location" }));

                        break;
                    case "location":
                        location.getContent();

                        break;
                    case "userType":
                        var markup = userType.getContent();

                        context.swap(appendButtons({ markup: markup, previousStep: "location", nextStep: "location" }));
                        break;
                }
            });
        });

        $(function () {
            appRegister.run("#/register/location");
        });

    } (jQuery, Sammy, Mustache, yoyyin.register.location, yoyyin.register.userType);
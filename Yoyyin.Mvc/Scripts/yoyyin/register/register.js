yoyyin.register.location =
    function ($, sammy, location, mustache) {
        var buttonsMarkup = "<div class='form-actions'><a class='btn' href='/#/register/{{previousStep}}'>Föregående</button> <a class='btn btn-primary' href='/#/register/{{nextStep}}'>Nästa</a></div><form>";

        var appendButtons = function(step) {
            var buttons = mustache.to_html(buttonsMarkup, step);
            return step.markup + buttons;
        };

        var appRegister = $.sammy("#sectionMainContent", function() {


            this.get("#/register/:step", function(context) {
                var step = this.params["step"];


                var stepPersonalMarkup = "<section><hgroup class='title'><h1>Först behöver vi lite personuppgifter.</h1></hgroup></div></section><div class='main-content'><label class='control-label' for='name'>Namn:</label><input type='text' class='input-xlarge' id='name' /><p class='help-block'>Supporting help text</p><label class='control-label' for='alias'>Alias:</label><input type='text' class='input-xlarge' id='alias' /><p class='help-block'>Supporting help text</p></div>";

                switch (step) {
                case "personalInfo":
                    context.swap(appendButtons({ markup: stepPersonalMarkup, previousStep: "personalInfo", nextStep: "location" }));

                    break;
                case "location":
                    location.getContent();
                        //context.swap(buttonsMarkup);

                    break;
                }
            });
        });

        $(function() {
            appRegister.run("#/register/location");
        });

    }(jQuery, yoyyin.register.location, Mustache);
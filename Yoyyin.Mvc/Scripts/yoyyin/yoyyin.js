(function ($, location) {
    var appRegister = $.sammy("#sectionMainContent", function () {
        //this.use(Sammy.Mustache, "html");
        var user = {};
        user.Street = "Stockholm";

        this.get("#/register/:step", function (context) {
            var step = this.params["step"];

            var buttonsMarkup = "<div class='form-actions'><button type='submit' class='btn btn-primary'>Spara</button><button class='btn'>Cancel</button></div><form>";
            var stepPersonalMarkup = "<section><hgroup class='title'><h1>Först behöver vi lite personuppgifter.</h1></hgroup></div></section><div class='main-content'><label class='control-label' for='name'>Namn:</label><input type='text' class='input-xlarge' id='name' /><p class='help-block'>Supporting help text</p><label class='control-label' for='alias'>Alias:</label><input type='text' class='input-xlarge' id='alias' /><p class='help-block'>Supporting help text</p></div>";
            var stepLocationMarkup = "<section><hgroup class='title'><h1>Var är du?</h1></hgroup></div></section><div class='main-content'><label class='control-label' for='street'>Gatuadress:</label><input type='text' class='input-xlarge' id='street' /><label class='control-label' for='zipCode'>Postnummer:</label><input type='text' class='input-xlarge' id='zipCode' /><label class='control-label' for='city'>Stad/ort:</label><input type='text' class='input-xlarge' id='city' /></div>";

            switch (step) {
                case "personalInfo":
                    context.swap(stepPersonalMarkup + buttonsMarkup);
                    break;
                case "location":
                    console.log(user);
                    location.setUser(user);
                    context.swap(location.getContent());
                    break;
            }
        });
    });

    $(function () {
        $(".registerLink").registerLink();
        $("#formQuickSearch").quickSearch({ $placeHolder: $("#sectionMainContent") });
        $('#carousel').carousel();

        appRegister.run("#/register/location");
    });

})(jQuery, yoyyin.register.location);
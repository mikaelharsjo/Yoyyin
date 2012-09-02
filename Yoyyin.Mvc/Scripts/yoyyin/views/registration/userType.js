define(["mustache", "views/registration/step", "views/shared/userTypeRadioButtonList", "text!templates/registration/userType.htm", "models/userType"], function (mustache, StepView, UserTypesRadioButtonList, template, UserType) {
    var renderRadios = function () {
        var radios = new UserTypesRadioButtonList({ el: $("#radios") });
        radios.render();
    };

    return StepView.extend({
        render: function () {
            this.setHero({ Headline: "Vilken är din roll/titel?" });
            this.appendButtons({ markup: mustache.render(template), previousStep: "location", nextStep: "userTypesNeeded" });
            renderRadios();
        },
        events: { "click button": "save" },
        save: function () {
            var userType = new UserType({
                Title: $("#title").val(),
                Description: $("#description").val()
            });

            userType.save();
            renderRadios();
        },
    })
});
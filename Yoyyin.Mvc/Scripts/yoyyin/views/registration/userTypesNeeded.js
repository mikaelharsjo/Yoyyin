define(["mustache", "views/registration/step", "views/shared/userTypeCheckBoxList", "text!templates/registration/userType.htm", "models/userType"], function (mustache, StepView, UserTypesCheckBoxList, template, UserType) {
    var renderCheckBoxes = function () {
        var checkBoxes = new UserTypesCheckBoxList({ el: $("#radios") });
        checkBoxes.render();
    };

    var wireCheckBoxes = function () {
        $(":checkbox").change(function () {
            if ($(this).is(":checked")) {
                console.log("changed");
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
    };

    return StepView.extend({
        render: function () {
            this.setHero({ Headline: "Vilken är din roll/titel?" });
            this.appendButtons({ markup: mustache.render(template), previousStep: "userType", nextStep: "tags" });
            renderCheckBoxes();
            wireCheckBoxes();
        },
        events: { "click button": "save" },
        save: function () {
            var userType = new UserType({
                Title: $("#title").val(),
                Description: $("#description").val()
            });

            userType.save();
            renderCheckBoxes();
        }
    })
});
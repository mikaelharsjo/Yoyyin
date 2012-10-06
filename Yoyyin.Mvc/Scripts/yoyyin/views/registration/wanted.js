define(["views/registration/step", "text!templates/registration/wanted.htm"], function (StepView, template) {
    return StepView.extend({
        render: function () {
            this.setHero({ Headline: "Vad söker du?" });
            this.appendButtons({ markup: template, previousStep: "personalInfo", nextStep: "location" });

            $("#wantsFinancing").change(function () {
                $("#financing").toggle();
            });
        },


        save: function () {
            console.log(this.model.toJSON());
        }
    });
});

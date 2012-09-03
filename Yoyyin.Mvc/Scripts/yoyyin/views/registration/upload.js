define(["views/registration/step", "text!templates/registration/upload.htm"], function (StepView, template) {
    return StepView.extend({
        render: function () {
            this.setHero({ Headline: "Bild och CV" });
            this.appendButtons({ markup: template, previousStep: "tags", nextStep: "idea" })
        }
    });
});
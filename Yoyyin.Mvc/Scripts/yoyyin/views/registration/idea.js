define(["views/registration/step", "text!templates/registration/idea.htm", "views/shared/sniCascadingDropDown"], function (StepView, template, CascadingDropDownView) {
    return StepView.extend({
        render: function () {
            this.setHero({ Headline: "Sista steget - Nu vill vi höra om din affärsidé" });
            this.appendButtons({ markup: template, previousStep: "upload", nextStep: "idea" });
            $("div.form-actions").append("<a class='btn btn-warning' href='/#/register/userType'>Jag har ingen affärsidé</a>");

            var view = new CascadingDropDownView({ el: $("#sniDropDowns") });
            view.render();
        }
    });
});

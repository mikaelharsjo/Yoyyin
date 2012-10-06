define(["views/registration/step", "views/shared/tags/competences", "text!templates/registration/personalInfo.htm"], function (StepView, CompetencesView, template) {
    return StepView.extend({
        initialize: function () {
            console.log("step personal");
        },
        render: function () {
            this.setHero({ Headline: "Kul att du vill bli medlem, först vill vi höra om dig själv" });
            this.appendButtons({ markup: template, previousStep: "personalInfo", nextStep: "wanted" });
            var view = new CompetencesView({ el: $("#competences") });

            this.model.set("name", "Mikael H");
        },

        buildEvents: function () {
            var parentEvents = this._super('buildEvents');

            return _.extend({
                'click #submit': 'submit'
            }, parentEvents);
        },

        save: function () {
            console.log(this.model.toJSON());
        }
    });
});
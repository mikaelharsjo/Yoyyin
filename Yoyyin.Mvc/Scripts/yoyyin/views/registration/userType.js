define(["views/registration/step", "views/shared/userTypeRadioButtonList"], function (StepView, UserTypesRadioButtonList) {
    return StepView.extend({
        //collection: UserTypes,

        render: function () {
            this.setHero({ Headline: "Vilken är din roll/titel?" });
            var radios = new UserTypesRadioButtonList({ el: this.el });
            radios.render();
            //this.$el.html(radios.render());
        }
    })
});
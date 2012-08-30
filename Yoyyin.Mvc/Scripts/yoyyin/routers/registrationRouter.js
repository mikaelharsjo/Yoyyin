define(["backbone", "views/registration/stepPersonalInfo"], function (Backbone, StepView) {
    return Backbone.Router.extend({
        routes: {
            "step1": "step1"
        },
        step1: function () {
            console.log("step1");
            var view = new StepView({ el: $("#sectionMainContent") });
            view.render();
        }
    });
});
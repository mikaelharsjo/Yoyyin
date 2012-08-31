define(["backbone", "views/registration/stepPersonalInfo", "views/registration/wanted"], function (Backbone, StepView, WantedView) {
    return Backbone.Router.extend({
        routes: {
            "personalInfo": "personalInfo",
            "wanted": "wanted"
        },
        personalInfo: function () {
            console.log("step1");
            var view = new StepView();
            view.render();
        },
        wanted: function () {
            var view = new WantedView();
            view.render();            
        }
    });
});
define(["backbone", "views/registration/stepPersonalInfo", "views/registration/wanted", "views/registration/location"], function (Backbone, PersonalInfoView, WantedView, LocationView) {
    return Backbone.Router.extend({
        routes: {
            "personalInfo": "personalInfo",
            "wanted": "wanted",
            "location": "location"
        },
        personalInfo: function () {
            console.log("step1");
            var view = new PersonalInfoView();
            view.render();
        },
        wanted: function () {
            var view = new WantedView();
            view.render();
        },
        location: function () {
            var view = new LocationView();
            view.render();
        }
    });
});
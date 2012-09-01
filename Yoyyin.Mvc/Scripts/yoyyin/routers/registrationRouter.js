define(["backbone", "views/registration/stepPersonalInfo", "views/registration/wanted", "views/registration/location", "views/registration/userType"], function (Backbone, PersonalInfoView, WantedView, LocationView, UserTypeView) {
    return Backbone.Router.extend({
        routes: {
            "personalInfo": "personalInfo",
            "wanted": "wanted",
            "location": "location",
            "userType": "userType"
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
        },
        userType: function () {
            var view = new UserTypeView();
            view.render();
        }
    });
});
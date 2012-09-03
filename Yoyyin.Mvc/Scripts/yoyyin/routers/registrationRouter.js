define(["backbone", "views/registration/stepPersonalInfo", "views/registration/wanted", "views/registration/location", "views/registration/userType", "views/registration/userTypesNeeded", "views/registration/tags"], function (Backbone, PersonalInfoView, WantedView, LocationView, UserTypeView, UserTypesNeededView, TagsView) {
    return Backbone.Router.extend({
        routes: {
            "personalInfo": "personalInfo",
            "wanted": "wanted",
            "location": "location",
            "userType": "userType",
            "userTypesNeeded": "userTypesNeeded",
            "tags": "tags"
        },
        personalInfo: function () {
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
        },
        userTypesNeeded: function () {
            var view = new UserTypesNeededView();
            view.render();
        },
        tags: function () {
            var view = new TagsView();
            view.render();
        }
    });
});
define(["backbone", "views/registration/stepPersonalInfo", "views/registration/wanted", "views/registration/location", "views/registration/userType", "views/registration/userTypesNeeded", "views/registration/tags", "views/registration/upload"], function (Backbone, PersonalInfoView, WantedView, LocationView, UserTypeView, UserTypesNeededView, TagsView, UploadView) {
    return Backbone.Router.extend({
        routes: {
            "personalInfo": "personalInfo",
            "wanted": "wanted",
            "location": "location",
            "userType": "userType",
            "userTypesNeeded": "userTypesNeeded",
            "tags": "tags",
            "upload": "upload"

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
        },
        upload: function () {
            var view = new UploadView();
            view.render();
        }
    });
});
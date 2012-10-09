define(["backbone", "views/registration/personalInfo", "views/registration/wanted", "views/registration/location", "views/registration/userType", "views/registration/userTypesNeeded", "views/registration/tags", "views/registration/upload", "views/registration/idea", "models/user"], function (Backbone, PersonalInfoView, WantedView, LocationView, UserTypeView, UserTypesNeededView, TagsView, UploadView, IdeaView, User) {
    return Backbone.Router.extend({
        initialize: function () {
            this.user = new User();
        },
        routes: {
            "personalInfo": "personalInfo",
            "wanted": "wanted",
            "location": "location",
            "userType": "userType",
            "userTypesNeeded": "userTypesNeeded",
            "tags": "tags",
            "upload": "upload",
            "idea": "idea"
        },
        personalInfo: function () {
            var view = new PersonalInfoView();
            view.model = this.user;
            view.render();
        },
        wanted: function () {
            var view = new WantedView();
            view.model = this.user;
            view.render();
        },
        location: function () {
            var view = new LocationView();
            view.model = this.user;
            view.render();
        },
        userType: function () {
            var view = new UserTypeView();
            view.model = this.user;
            view.render();
        },
        userTypesNeeded: function () {
            var view = new UserTypesNeededView();
            view.model = this.user;
            view.render();
        },
        tags: function () {
            var view = new TagsView();
            view.model = this.user;
            view.render();
        },
        upload: function () {
            var view = new UploadView();
            view.model = this.user;
            view.render();
        },
        idea: function () {
            var view = new IdeaView();
            view.model = this.user;
            view.render();
        }
    });
});
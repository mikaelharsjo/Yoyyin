﻿define(["underscore", "backbone", "mustache", "models/user", "models/currentUser", "views/users/user", "views/users/users", "views/currentUser/dashboard", "views/currentUser/inbox", "views/ideas/all", "views/currentUser/editProfile"], function (_, Backbone, mustache, UserModel, CurrentUserModel, UserView, UsersView, Dashboard, Inbox, ViewOfAllIdeas, EditProfile) {
    var Router = Backbone.Router.extend({
        initialize: function () {
            //this.users = new UserCollection(); // { model: UserModel });
            //this.currentUser = new CurrentUserModel();
        },
        routes: {
            "editProfile": "editProfile",
            "inbox": "inbox",
            "user/:id": "user",
            "users": "users",
            "dashboard": "dashboard",
            "ideas/all": "allIdeas"
        },

        editProfile: function () {
            var view = new EditProfile({ el: $("#body") });
        },

        allIdeas: function () {
            var view = new ViewOfAllIdeas({ el: $("#body") });
        },
        user: function (id) {
            var user = new UserModel({ id: id });

            user.fetch({
                success: function () {
                    var view = new UserView({ model: user, el: $("#body") });
                    view.render();
                }
            });
        },

        inbox: function () {
            var inbox = new Inbox({ el: $("#body") });
        },

        users: function () {
            var view = new UsersView({ el: $("#body") });

        },

        dashboard: function () {
            var view = new Dashboard({ el: $("#body") });
        }
    });

    return Router;
}); 
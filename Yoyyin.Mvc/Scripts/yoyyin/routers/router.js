define(["underscore", "backbone", "mustache", "models/user", "models/currentUser", "views/users/user", "views/users/users", "views/currentUser/dashboard", "views/currentUser/inbox", "views/ideas/all"], function (_, Backbone, mustache, UserModel, CurrentUserModel, UserView, UsersView, Dashboard, Inbox, ViewOfAllIdeas) {
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
            "ideas/list": "ideasList"
        },

        ideasList: function () {
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

            console.log("user route");
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
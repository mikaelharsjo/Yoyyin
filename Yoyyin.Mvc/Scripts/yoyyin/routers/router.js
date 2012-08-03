define(["underscore", "backbone", "mustache", "models/currentUser", "models/user", "models/currentUser", "collections/users", "views/users/user", "views/users/users", "views/currentUser/dashboard", "views/currentUser/inbox"], function (_, Backbone, mustache, CurrentUserModel, UserModel, CurrentUserModel, UserCollection, UserView, UsersView, Dashboard, Inbox) {
    var Router = Backbone.Router.extend({
        initialize: function () {
            this.users = new UserCollection(); // { model: UserModel });
            this.currentUser = new CurrentUserModel();
        },
        routes: {
            "editProfile": "editProfile",
            "inbox": "inbox",
            "user/:id": "user",
            "users": "users",
            "dashboard": "dashboard"
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
            inbox.render();
        },

        users: function () {
            var view = new UsersView({ collection: this.users, el: $("#body") });
            view.render();

        },

        dashboard: function () {
            console.log(this.currentUser);
            var view = new Dashboard({ model: this.currentUser });
            view.render();
        }
    });

    return Router;
}); 
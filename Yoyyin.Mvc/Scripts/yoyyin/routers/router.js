define(["underscore", "backbone", "mustache", "models/currentUser", "models/user", "collections/users", "views/users/user", "views/users/users"], function (_, Backbone, mustache, CurrentUserModel, UserModel, UserCollection, UserView, UsersView) {
    var Router = Backbone.Router.extend({
        initialize: function () {
            this.users = new UserCollection(); // { model: UserModel });
        },
        routes: {
            "editProfile": "editProfile",
            "inbox": "inbox",
            "user/:id": "user",
            "users": "users"
        },

        user: function (id) {
            //console.log(this.users);
            var user = new UserModel({ id: id });  //this.users.last(); // get(id);  //("6e37b452-4f92-45e0-875b-01dd92de7686"); //"   id);

            user.fetch({
                success: function () {
                    var view = new UserView({ model: user, el: $("#body") });
                    view.render();        
                }
            });

            console.log("user route");
        },

        inbox: function () {
            //var inbox = new Inbox();
        },

        users: function () {
            console.log("users route");
            console.log(this.users);
            var view = new UsersView({ collection: this.users, el: $("#body") });
            view.render();

        },
        //    editProfile: function () {
        //        console.log("editPRofile yo oy oy");
        //        require(["text!../../Templates/Member/editProfile.htm"], function (template) {
        //            $.get("/CurrentUser/Get", function (user) {
        //                console.log(user);
        //                context.swap(mustache.render(template, user));
        //            });
        //        });
        //    },
        search: function (query, page) {

        }

    });

    return Router;
}); 
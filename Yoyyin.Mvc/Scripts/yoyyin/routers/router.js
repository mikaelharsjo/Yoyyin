define([], function () {
    var Router = Backbone.Router.extend({
        routes: {
            "help": "help",
            "editProfile": "editProfile",
            "search/:query/p:page": "search"
        },

        help: function () {
            console.log("help");
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
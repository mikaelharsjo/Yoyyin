require(["routers/router", "views/currentUser/dashboard", "views/currentUser/userBox", "models/currentUser"], function (Router, DashboardView, UserBox, CurrentUserModel) {      //["model/user", "model/message", "collections/messages", "collections/users", "views/editProfile", "views/loggedIn", "views/messages/unReadMessages", "views/messages/inbox", "routers/router"], function (User, Message, Messages, Users, EditProfile, LoggedIn, UnReadMessages, Inbox, Router) {
    // models
    //var user = new User();

    // collections
    //var messages = new Messages();
    //var users = new Users();

    // views
    //var editProfile = new EditProfile({ el: $("#body"), model: user });
    //var loggedIn = new LoggedIn({ el: $("#loggedIn"), model: user });
    //var unReadMessages = new UnReadMessages({ el: $("#unReadMessages"), collection: messages });
    //var inbox = new Inbox({ el: $("#body"), collection: messages });    

    var that = this;
    var currentUser = new CurrentUserModel();

    currentUser.fetch({
        success: function () {
            var userBox = new UserBox({ model: currentUser, el: $("#userBox") });
            userBox.render();

            var dashboard = new DashboardView({ model: currentUser, el: $("#body") });
            dashboard.render();
        }
    });

    //userBox.render();
    var router = new Router();
    Backbone.history.start(); //{ pushState: true, root: '/' });
    //router.navigate();
});
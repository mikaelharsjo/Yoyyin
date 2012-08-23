require(["routers/router", "views/currentUser/dashboard", "views/currentUser/userBox", "views/currentUser/navigation", "models/currentUser"], function (Router, DashboardView, UserBox, NavigationView, CurrentUserModel) {
    var that = this;
    var currentUser = new CurrentUserModel();

    currentUser.fetch({
        success: function () {
            var userBox = new UserBox({ model: currentUser, el: $("#userBox") });
            userBox.render();

            var dashboard = new DashboardView({ model: currentUser, el: $("#body") });
            dashboard.render();

            var navigation = new NavigationView({ el: $("#subMenu"), model: currentUser });
            navigation.render();
        }
    });
    
    //currentUser.on("sync", function)
    


    //userBox.render();
    var router = new Router();
    Backbone.history.start(); //{ pushState: true, root: '/' });
    //router.navigate();
});
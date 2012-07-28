require(["model/user", "model/message", "collections/messages", "views/editProfile", "views/loggedIn", "views/unReadMessages", "routers/router"], function (User, Message, Messages, EditProfile, LoggedIn, UnReadMessages, Router) {
    // models
    var user = new User();
    
    // collections
    var messages = new Messages();

    // views
    var editProfile = new EditProfile({ el: $("#body"), model: user });
    var loggedIn = new LoggedIn({ el: $("#loggedIn"), model: user });
    var unReadMessages = new UnReadMessages({ el: $("#unReadMessages"), collection: messages });

    var router = new Router();
    Backbone.history.start();
    router.navigate();
});


//yoyyin.member = function ($, sammy, mustache) {

//    var appMember = $.sammy("#sectionMainContent", function () {

//        this.get("#/member/matcher", function (context) {
//            require(["text!../../Templates/Member/matcher.htm"], function (template) {
//                context.swap(mustache.render(template));
//            });
//        });

//        this.get("#/member/editProfile", function (context) {
//            require(["text!../../Templates/Member/editProfile.htm"], function (template) {
//                $.get("/CurrentUser/Get", function (user) {
//                    console.log(user);
//                    context.swap(mustache.render(template, user));
//                });
//            });
//        });

//        this.get("#/member/inbox", function (context) {
//            debugger;
//            this.load("/CurrentUser/Messages", { json: true })
//                .renderEach("Templates/Member/message.htm")
//                .swap();
//        });
//    });

//    $(function () {
//        appMember.run();
//    });

//} (jQuery, Sammy, Mustache);
/// <reference path="../../sammy.js" />
yoyyin.member = function ($, sammy, mustache) {

    var currentUser;

    $.get("/CurrentUser/Get", function (user) {
        currentUser = user;
        console.log(currentUser);
    });

    var appMember = $.sammy("#sectionMainContent", function () {
        this.get("#/member/matcher", function (context) {
            require(["text!../../Templates/Member/matcher.htm"], function (template) {
                context.swap(mustache.render(template));
            });
        });
        this.get("#/member/editProfile", function (context) {
            require(["text!../../Templates/Member/editProfile.htm"], function (template) {
                context.swap(mustache.render(template));
            });
        });
    });

    $(function () {
        appMember.run();
    });

} (jQuery, Sammy, Mustache);
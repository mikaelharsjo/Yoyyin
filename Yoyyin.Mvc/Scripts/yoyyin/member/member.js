/// <reference path="../../sammy.js" />
yoyyin.register = function ($, sammy, mustache) {
    
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
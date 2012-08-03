define([], function() {
    var EditProfile = Backbone.View.extend({
        initialize: function() {
            //this.model.bind("change", this.render, this);
        },
        render: function() {
            var that = this;
            require(["text!../../Templates/Member/editProfile.htm"], function(template) {
                $(that.el).html(Mustache.render(template, that.model.toJSON));
            });
        }
//    yoyyin.routers.MemberRouter.on("route:editProfile": function() {
//        console.log("route event");
//    });
    });

    return EditProfile;
});
define(["backbone", "mustache"], function (Backbone, mustache) {
    var loggedIn = Backbone.View.extend({
        initialize: function () {
            this.model.bind("change", this.render, this);
            //this.render();
        },
        render: function () {
            var that = this;
            require(["text!templates/CurrentUser/profile.htm", "text!templates/CurrentUser/dashboard.htm"], function (profileTemplate, dashboardTemplate) {
                var user = that.model.toJSON();
                console.log(user);
                //user.ImageSrc = user.HasImage ? "/Images/" + user.UserId + ".jpg??width=20&height=20" : "/Images/glyphicons_003_user@2x.png?width=20&height=20";
                var dashboard = { ProfileMarkup : mustache.render(profileTemplate, user), user: user };

                $(that.el).html(mustache.render(dashboardTemplate, dashboard));
                //$(that.el).find("img").attr("src");
                //$(that.el).prepend("apa");
            });
        }
    });

    return loggedIn;
});
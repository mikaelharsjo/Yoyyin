define(["backbone", "mustache", "models/currentUser"], function (Backbone, mustache, CurrentUser) {
    var loggedIn = Backbone.View.extend({
        initialize: function () {
            var that = this;
            this.model = new CurrentUser();
            this.model.fetch({
                success: function () {
                    that.render();
                }
            });
            this.model.bind("change", this.render, this);
        },
        render: function () {
            var that = this;
            require(["text!templates/CurrentUser/profile.htm", "text!templates/CurrentUser/dashboard.htm"], function (profileTemplate, dashboardTemplate) {
                var user = that.model.toJSON();
                var dashboard = { ProfileMarkup: mustache.render(profileTemplate, user), user: user };

                $(that.el).html(mustache.render(dashboardTemplate, dashboard));

            });
        }
    });

    return loggedIn;
});
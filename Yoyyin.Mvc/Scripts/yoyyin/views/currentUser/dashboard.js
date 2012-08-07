define(["backbone", "mustache", "text!templates/CurrentUser/profile.htm", "text!templates/CurrentUser/dashboard.htm"], function (Backbone, mustache, profileTemplate, dashboardTemplate) {
    var loggedIn = Backbone.View.extend({
        initialize: function () {
            this.model.bind("change", this.render, this);
        },
        render: function () {
            var user = this.model.toJSON();
            var dashboard = { ProfileMarkup: mustache.render(profileTemplate, user), user: user };

            $(this.el).html(mustache.render(dashboardTemplate, dashboard));

            return this;
        }
    });

    return loggedIn;
});
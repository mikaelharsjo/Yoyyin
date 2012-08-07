define(["backbone", "models/currentUser", "text!templates/CurrentUser/editProfile.htm"], function (Backbone, CurrentUserModel, template) {
    return Backbone.View.extend({
        initialize: function () {
            //this.model.bind("change", this.render, this);
            var that = this;
            this.model = new CurrentUserModel();
            this.model.fetch({
                success: function () {
                    that.render();
                }
            });
        },
        render: function () {
            $(this.el).html(Mustache.render(template, this.model.toJSON));
            return this;
        }
    });
});
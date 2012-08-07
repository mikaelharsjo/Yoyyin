define(["backbone", "mustache", "text!templates/CurrentUser/userBox.htm"], function (Backbone, mustache, template) {
    return Backbone.View.extend({
        initialize: function () {
            this.model.bind("change", this.render, this);
        },
        render: function () {
            var user = this.model.toJSON();
            user.ImageSrc = user.HasImage ? "/Images/" + user.UserId + ".jpg??width=20&height=20" : "/Images/glyphicons_003_user@2x.png?width=20&height=20";
            $(this.el).html(mustache.render(template, user));
        }
    });
});
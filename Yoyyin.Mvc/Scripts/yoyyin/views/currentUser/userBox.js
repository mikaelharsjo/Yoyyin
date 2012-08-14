define(["backbone", "mustache", "text!templates/CurrentUser/userBox.htm"], function (Backbone, mustache, template) {
    return Backbone.View.extend({
        initialize: function () {
            this.model.bind("change", this.render, this);
        },
        render: function () {
           $(this.el).html(mustache.render(template, this.model.toJSON()));
        }
    });
});
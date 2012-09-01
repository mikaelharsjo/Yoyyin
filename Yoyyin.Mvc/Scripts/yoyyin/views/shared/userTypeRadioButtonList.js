define(["backbone", "mustache", "collections/userTypes", "text!templates/shared/userTypeRadio.htm"], function (Backbone, mustache, UserTypes, template) {
    return Backbone.View.extend({
        initialize: function () {
            var that = this;
            this.collection = new UserTypes();
            this.collection.fetch({
                success: function () {
                    that.render();
                }
            });
        },
        render: function () {
            var markup = "";
            this.collection.each(function (userType) {            
                markup += mustache.render(template, userType.toJSON());
            });

            this.$el.html(markup);
        }
    });
});
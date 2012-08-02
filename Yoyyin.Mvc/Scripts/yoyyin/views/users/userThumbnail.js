define(["underscore", "backbone", "mustache", "text!../../../../Templates/Member/User/image.htm"], function (_, Backbone, mustache, imageTemplate){
    return Backbone.View.extend({     
        initialize: function () {
            this.render();
        },
        render: function () {
            var user = this.model.toJSON();
            //user.Image = mustache.render(imageTemplate, user);

            $(this.el).html(mustache.render(imageTemplate, user));
        }
    });
});
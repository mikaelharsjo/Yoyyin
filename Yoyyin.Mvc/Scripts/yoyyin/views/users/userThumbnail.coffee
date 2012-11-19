define ["underscore", "backbone", "mustache", "text!../../../../Templates/Member/User/image.htm"], (_, Backbone, mustache, imageTemplate) ->
    class UserThumbnail extends Backbone.View
        render: ->
            user = this.model.toJSON();
            #user.Image = mustache.render(imageTemplate, user);
            @$el.html mustache.render(imageTemplate, user)
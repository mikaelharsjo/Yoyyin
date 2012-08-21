define(["backbone", "mustache", "models/currentUser", "text!templates/shared/modal.htm", "text!templates/user/newMessage.htm", "text!templates/user/image.htm"], function (Backbone, mustache, CurrentUserModel, modalTemplate, newMessageTemplate, imageTemplate) {
    return Backbone.View.extend({
        render: function () {
            var that = this;
            this.model = new CurrentUserModel();
            this.model.fetch({
                success: function () {
                    var imageMarkup = mustache.render(imageTemplate, { Src: that.model.toJSON().ProfileImageSrc });
                    var body = mustache.render(newMessageTemplate, { imageMarkup: imageMarkup });
                    var markup = mustache.render(modalTemplate, { title: "Nytt meddelande", body: body, actionText: "Skicka" });
                    $(markup).modal("show");
                }
            });
        }
    });
});
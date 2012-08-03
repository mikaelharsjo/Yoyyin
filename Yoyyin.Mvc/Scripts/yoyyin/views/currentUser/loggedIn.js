define([], function () {
    var loggedIn = Backbone.View.extend({
        initialize: function () {
            this.model.bind("change", this.render, this);
        },
        render: function () {
            var that = this;
            require(["text!../../Templates/Member/loggedIn.htm"], function (template) {
                var user = that.model.toJSON();
                user.ImageSrc = user.HasImage ? "/Images/" + user.UserId + ".jpg??width=20&height=20" : "/Images/glyphicons_003_user@2x.png?width=20&height=20";
                $(that.el).html(Mustache.render(template, user));
                //$(that.el).find("img").attr("src");
                //$(that.el).prepend("apa");
            });
        }
    });

    return loggedIn;
});
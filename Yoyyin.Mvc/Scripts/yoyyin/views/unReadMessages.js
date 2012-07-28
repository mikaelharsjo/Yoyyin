define([], function () {
    var unReadMessages = Backbone.View.extend({
        initialize: function () {
            this.collection.on("sync", this.render, this);
        },
        render: function () {
            var that = this;
            require(["text!../../Templates/Member/unReadMessages.htm"], function (template) {
                $(that.el).html(Mustache.render(template, { Count: that.collection.length }));
            });
        }
    });

    return unReadMessages;
});
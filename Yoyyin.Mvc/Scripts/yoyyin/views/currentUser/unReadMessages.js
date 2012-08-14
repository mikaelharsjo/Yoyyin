define([], function () {
    var unReadMessages = Backbone.View.extend({
        initialize: function () {
            this.collection.on("sync", this.render, this);
        },
        render: function () {
            var that = this;
            require(["text!../../Templates/Member/Messages/unReadMessages.htm"], function (template) {
                $(that.el).html(Mustache.render(template, { Count: that.collection.length }));
            });
        },
        events: {
            "click span": "click"
        },
        click: function () {
            var that = this;
            require(["views/messages/inbox"], function (Inbox) {
                var inbox = new Inbox({ el: $("#body"), collection: that.collection });
                inbox.render();
            });
        }
        //display: function()
    });

    return unReadMessages;
});
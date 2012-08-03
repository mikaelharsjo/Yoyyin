define(["collections/messages"], function (Messages) {
    var inbox = Backbone.View.extend({
        initialize: function () {
            var that = this;
            this.collection = new Messages();
            this.collection.fetch({
                success: function () {
                    that.render();
                }
            });
            this.collection.on("sync", this.render, this);
        },
        render: function () {
            var that = this;
            require(["text!templates/Shared/pageHeader.htm", "text!templates/CurrentUser/inbox.htm"], function (pageHeader, template) {
                $(that.el).html(Mustache.render(pageHeader, { Heading: "Inkorgen", SubHeading: "Senaste överst" }));
                var $table = $("<table>").addClass("table table-striped");
                that.collection.each(function (message) {
                    console.log(message.toJSON());
                    $table.append(Mustache.render(template, message.toJSON()));
                });

                $(that.el).append($table);
            });
        }
    });

    return inbox;
});
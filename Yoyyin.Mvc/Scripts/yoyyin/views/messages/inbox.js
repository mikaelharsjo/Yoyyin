define([], function () {
    var inbox = Backbone.View.extend({
        initialize: function () {
            this.collection.on("sync", this.render, this);
        },
        render: function () {
            var that = this;
            require(["text!../../Templates/Shared/pageHeader.htm", "text!../../Templates/Member/Messages/inbox.htm"], function (pageHeader, template) {
                $(that.el).html(Mustache.render(pageHeader, { Heading: "Inkorgen", SubHeading: "Senaste överst" }));
                var $table = $("<table>").addClass("table table-striped");
                //$(that.el).append("<table class='table table-striped'>");
                that.collection.each(function (message) {
                    console.log(template);
                    $table.append(Mustache.render(template, message.toJSON()));
                });
                
                $(that.el).append($table);
            });
        }
    });

    return inbox;
});
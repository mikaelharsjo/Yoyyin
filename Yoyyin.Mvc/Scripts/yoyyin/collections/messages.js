define(function () {
    var Messages = Backbone.Collection.extend({
        url: "/Messages/GetAll",
        initialize: function () {
            this.fetch();
        }
    });

    return Messages;
});


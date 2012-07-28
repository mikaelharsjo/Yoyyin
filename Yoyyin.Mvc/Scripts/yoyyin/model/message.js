define([], function () {
    var Message = Backbone.Model.extend({
        urlRoot: "/Message/Get",
        initialize: function () {
        }
    });

    return Message;
});

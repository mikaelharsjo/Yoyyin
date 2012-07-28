define([], function () {
    var User = Backbone.Model.extend({
        urlRoot: "/CurrentUser/Get",
        initialize: function () {
            this.fetch();
        }
    });

    return User;
});

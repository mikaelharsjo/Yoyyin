define(["backbone"], function (Backbone) {
    var User = Backbone.Model.extend({
        urlRoot: "/CurrentUser/Get",
        initialize: function () {
            this.fetch();
        }
    });

    return User;
});

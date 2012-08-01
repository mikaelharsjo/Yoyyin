define(["backbone", "models/user"], function (Backbone, UserModel) {
    return Backbone.Collection.extend({
        url: "/User/All",
        model: UserModel,
        initialize: function () {
            this.fetch();
        }
    });
});

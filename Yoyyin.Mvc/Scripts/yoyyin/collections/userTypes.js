define(["backbone", "models/userType"], function (Backbone, UserTypeModel) {
    return Backbone.Collection.extend({
        url: "/UserTypes",
        model: UserTypeModel,
        initialize: function () {
            //this.fetch();
        }
    });
});

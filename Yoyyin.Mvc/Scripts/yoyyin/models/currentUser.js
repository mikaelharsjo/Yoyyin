define(["backbone"], function (Backbone) {
    return Backbone.Model.extend({
        urlRoot: "/CurrentUser/Get",
        initialize: function () {
            //this.fetch();
        }
    });
});

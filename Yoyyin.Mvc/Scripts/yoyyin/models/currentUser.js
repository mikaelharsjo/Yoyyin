define(["backbone"], function (Backbone) {
    return Backbone.Model.extend({
        urlRoot: "/CurrentUser/Get",
        initialize: function () {
            this.on("all", function(e) { console.log(e); });
        }
    });
});

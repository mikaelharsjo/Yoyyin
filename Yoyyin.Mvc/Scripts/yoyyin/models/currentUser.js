define(["backbone"], function (Backbone) {
    return Backbone.Model.extend({
        urlRoot: "/CurrentUser",
        initialize: function () {
            this.on("all", function(e) { console.log(e); });
        }
    });
});

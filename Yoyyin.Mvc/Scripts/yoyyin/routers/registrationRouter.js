define(["backbone"], function (Backbone) {
    return Backbone.Router.extend({
        routes: {
            "step1": "step1"
        },
        step1: function () {
            console.log("step1");
        }
    });
});
define(["backbone", "models/matching/match"], function (Backbone, Match) {
    return Backbone.Collection.extend({
        url: "Matching/Mega",
        model: Match,
        intialize: function () {
            console.log("megamatch");
        }
    });
});
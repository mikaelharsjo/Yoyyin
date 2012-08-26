define(["backbone"], function (Backbone) {
    return Backbone.Model.extend({
        urlRoot: "/CurrentUser",
        initialize: function () {
            this.on("all", function (e) { console.log(e); });
        },
        getImageSrc: function () {
            return this.get("HasImage") ? "/Content/Upload/Images/" + this.id + ".jpg" : "/Images/glyphicons_003_user@2x.png";
        }
    });
});

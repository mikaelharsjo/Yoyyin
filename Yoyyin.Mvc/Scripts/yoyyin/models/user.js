define(["backbone"], function (Backbone) {
    return Backbone.Model.extend({
        //urlRoot: "/User/Get/" + this.id,
        url: function () {
            return "/User/Get/" + this.id;
        },
        initialize: function () {
            //this.fetch();
        }
    });

});
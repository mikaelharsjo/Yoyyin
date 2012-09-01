define(["views/registration/step", "collections/userTypes"], function (StepView, UserTypes) {
    return StepView.extend({
        //collection: UserTypes,
        initialize: function () {
            console.log("initialize");
            var that = this;
            this.collection = new UserTypes();
            this.collection.fetch({
                success: function () {
                    that.render();
                }
            });
        },
        render: function () {
            this.setHero({ Headline: "Vilken är din roll/titel?" });
            this.collection.each(function (userType) {
                console.log(userType);
            });
        }
    })
});
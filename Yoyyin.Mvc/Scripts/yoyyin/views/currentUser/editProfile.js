define(["backbone", "mustache", "text!templates/CurrentUser/editProfile.htm", "text!templates/shared/pageHeader.htm", "views/shared/tags/competences"], function (Backbone, mustache, template, headerTemplate, CompetencesView) {
    return Backbone.View.extend({
        render: function () {
            var markup = mustache.render(headerTemplate, { Heading: "Redigera din profil", SubHeading: "Spara när du är klar" });
            var user = this.model.toJSON();

            user.competencesMarkup = "";
            $.each(user.Competences, function (index, competence) {
                user.competencesMarkup += "<li>" + competence + "</li>";
            });
            markup += Mustache.render(template, user);
            $(this.el).html(markup);

            var view = new CompetencesView({ el: $("#competences") });

            return this;
        },
        events: {
            "click a.btn": "save"
        },
        save: function () {
            console.log("save");
            debugger;
            this.model.set("Competences", $("#competences").tagit("assignedTags"));
            this.model.set("Name", $("#name").val());
            this.model.set("Alias", $("#alias").val());
            this.model.save();
        }
    });
});
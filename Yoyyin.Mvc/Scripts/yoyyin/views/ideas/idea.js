define(["backbone", "mustache", "text!templates/Shared/userTypeLabel.htm", "text!templates/Shared/idea.htm", "text!templates/Shared/competenceLabel.htm"], function (Backbone, mustache, userTypeLabelTemplate, ideaTemplate, competenceLabelTemplate) {
    return Backbone.View.extend({
        initialize: function () {
            //this.render();
        },
        render: function () {
            var idea = this.model.toJSON();
            idea.UserTypesNeededMarkup = "";
            $.each(idea.UserTypesNeeded, function (index, userType) {
                idea.UserTypesNeededMarkup += mustache.render(userTypeLabelTemplate, { Title: userType });
            });

            idea.CompetencesNeededMarkup = "";
            console.log(idea);
            $.each(idea.CompetencesNeeded, function (index, competence) {
                idea.CompetencesNeededMarkup += mustache.render(competenceLabelTemplate, { Competence: competence });
            });

            $(this.el).html(mustache.render(ideaTemplate, idea));
        }
    });
}); 
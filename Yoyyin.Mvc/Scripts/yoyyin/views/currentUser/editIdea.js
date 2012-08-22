define(["backbone", "mustache", "text!templates/shared/pageHeader.htm", "text!templates/currentUser/editIdea.htm"], function (Backbone, mustache, pageHeaderTemplate, editIdeaTemplate) {
    return Backbone.View.extend({
        render: function () {
            var pageHeader = mustache.render(pageHeaderTemplate, { Heading: "Redigera din affärsidé" });
            var firstIdea = this.model.get("Ideas")[0];
            firstIdea.competencesNeededMarkup = "";
            $.each(firstIdea.SearchProfile.CompetencesNeeded, function (index, competence) {
                firstIdea.competencesNeededMarkup += "<li>" + competence + "</li>";
            });

            firstIdea.searchWordsMarkup = "";
            $.each(firstIdea.SearchProfile.SearchWords, function (index, word) {
                firstIdea.searchWordsMarkup += "<li>" + word + "</li>";
            });

            var body = mustache.render(editIdeaTemplate, firstIdea);
            this.$el.html(pageHeader + body);

            $.get("/Matching/GetQuickSearchTypeAheadItems/", function (items) {
                $("#tags").tagit({ availableTags: items });
            });

            $.get("/Tagging/Competences/", function (competences) {
                $("#competencesNeeded").tagit({ availableTags: competences });
            });
        },
        events: {
            "click a.btn": "save"
        },
        save: function () {
            this.model.save();
            console.log("save");
        }
    });
});
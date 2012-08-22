define(["backbone", "mustache", "models/currentUser", "text!templates/shared/pageHeader.htm", "text!templates/currentUser/editIdea.htm"], function (Backbone, mustache, CurrentUser, pageHeaderTemplate, editIdeaTemplate) {
    return Backbone.View.extend({
        render: function () {
            var that = this;
            this.model = new CurrentUser();
            this.model.fetch({
                success: function () {
                    console.log(that.model);
                    var pageHeader = mustache.render(pageHeaderTemplate, { Heading: "Redigera din affärsidé" });
                    var firstIdea = that.model.get("Ideas")[0];
                    firstIdea.competencesNeededMarkup = "";
                    $.each(firstIdea.SearchProfile.CompetencesNeeded, function (index, competence) {
                        firstIdea.competencesNeededMarkup += "<li>" + competence + "</li>";
                    });

                    firstIdea.searchWordsMarkup = "";
                    $.each(firstIdea.SearchProfile.SearchWords, function (index, word) {
                        firstIdea.searchWordsMarkup += "<li>" + word + "</li>";
                    });
                    
                    console.log(firstIdea);
                    var body = mustache.render(editIdeaTemplate, firstIdea);
                    that.$el.html(pageHeader + body);

                    $.get("/Matching/GetQuickSearchTypeAheadItems/", function (items) {
                        $("#tags").tagit({ availableTags: items });
                    });

                    $.get("/Tagging/Competences/", function (competences) {
                        $("#competencesNeeded").tagit({ availableTags: competences });
                    });
                }
            });
        }
    });
});
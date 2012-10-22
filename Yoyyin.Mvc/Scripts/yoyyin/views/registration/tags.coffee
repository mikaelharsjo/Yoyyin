define ["views/registration/step", "views/shared/tags/competences", "views/shared/tags/searchWords", "text!templates/registration/tags.htm"], (StepView, CompetencesTagsView, SearchWordsTagsView, template) ->
    class Tags extends StepView
        render: ->
            @setHero
                Headline: "Vilka kompetenser söker du?"            
            @appendButtons
                markup: template
                previousStep: "userTypesNeeded"
                nextStep: "upload"

            competencesTagsView = new CompetencesTagsView
                el: $ "#competencesNeeded"
            competencesTagsView.render()

            searchWordsTagsView = new SearchWordsTagsView
                el: $ "#tags"
            searchWordsTagsView.render()
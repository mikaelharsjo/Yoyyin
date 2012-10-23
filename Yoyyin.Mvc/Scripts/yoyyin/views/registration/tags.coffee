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

        saveStep: ->
            ideas = @model.get "Ideas"
            idea = ideas[0] || {}
            idea.SeachProfile = idea.SeachProfile || {}
            idea.SeachProfile.CompetencesNeeded = @_getTags 'competencesNeeded'
            idea.SearchWords = @_getTags 'tags'
            @model.set 'Ideas', ideas

            console.log idea

        _getTags: (id) ->
            $("#" + id).tagit 'assignedTags'
            
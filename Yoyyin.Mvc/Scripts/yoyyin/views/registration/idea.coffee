define ["views/registration/step", "text!templates/registration/idea.htm", "views/shared/sniCascadingDropDown", "views/shared/tags/competences", "views/shared/tags/searchWords"], (StepView, template, CascadingDropDownView, CompetencesTagsView, SearchWordsTagsView) ->
    class Idea extends StepView
        render: ->
            @setHero
              Headline: "Sista steget - Nu vill vi höra om din affärsidé"

            @appendButtons
              markup: template
              previousStep: "upload"
              nextStep: "idea"

            $("div.form-actions").append "<a class='btn btn-warning' href='/#/register/userType'>Jag har ingen affärsidé</a>"

            @dropDown = new CascadingDropDownView
              el: $ "#sniDropDowns"
            @dropDown.render()

            competencesTagsView = new CompetencesTagsView
                el: $ "#competencesNeeded"
            competencesTagsView.render()

            searchWordsTagsView = new SearchWordsTagsView
                el: $ "#tags"
            searchWordsTagsView.render()

        _getTags: (id) ->
            $("#" + id).tagit 'assignedTags'

          saveStep: ->
            ideas = @model.get "Ideas"
            idea = ideas[0]
            idea.CompanyName = @$el.find('#companyName').val()
       	    idea.Title = @$el.find('#title').val()
       	    idea.Description = @$el.find('#description').val()
       	    idea.SniNo = @dropDown.getHeadVal()
       	    idea.SniHeadId = @dropDown.getItemVal()
            idea.SearchProfile.CompetencesNeeded = @_getTags 'competencesNeeded'
            idea.SearchWords = @_getTags 'tags'

            console.log @model
            @model.save()


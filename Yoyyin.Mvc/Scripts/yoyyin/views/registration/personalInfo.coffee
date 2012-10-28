define ["views/registration/step", "views/shared/tags/competences", "text!templates/registration/personalInfo.htm"], (StepView, CompetencesView, template) ->
    class PersonalInfo extends StepView
        className: 'personalInfo'

        initialize: ->
            console.log("step personal")
        
        render: ->
            @setHero(Headline: "Kul att du vill bli medlem, först vill vi höra om dig själv" )
            @appendButtons(markup: template, previousStep: "personalInfo", nextStep: "wanted" )
            view = new CompetencesView
                el: $ "#competences"
            $('#urls').tagit()    

        saveStep: ->
            @model.set "Name", @$el.find('#name').val()
            @model.set "Alias", @$el.find('#alias').val()
            @model.set "Email", @$el.find('#email').val()
            @model.set "Presentation", @$el.find('#userDescription').val()
            # totdo refactor
            @model.set "Competences", @_getTags 'competences'
            @model.set 'Urls', @_getTags 'urls'
            console.log @model.toJSON()

        _getTags: (id) ->
            $("#" + id).tagit 'assignedTags'
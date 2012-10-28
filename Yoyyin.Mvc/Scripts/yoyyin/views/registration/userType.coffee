define ["mustache", "views/registration/step", "views/shared/userTypeRadioButtonList", "text!templates/registration/userType.htm", "models/userType"], (mustache, StepView, UserTypesRadioButtonList, template, UserType) ->
    class UserType extends StepView
        _renderRadios: ->
            radios = new UserTypesRadioButtonList
                el: $ "#radios"

        render: ->
            @setHero
                Headline: "Vilken är din roll/titel?"
            @appendButtons
                markup: mustache.render(template)
                previousStep: "location"
                nextStep: "userTypesNeeded"
            @_renderRadios()        

        events: 
            "click button": "add"
            "click .btn-primary": "save"

        add: ->
            userType = new UserType
                Title: $("#title").val()
                Description: $("#description").val()

            userType.save()
            renderRadios()

        saveStep: ->
            @model.set "UserType", $("#radios").find(":checked").val()
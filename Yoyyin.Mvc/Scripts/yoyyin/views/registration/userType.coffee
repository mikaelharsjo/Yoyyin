define ["mustache", "views/registration/step", "views/shared/userTypeRadioButtonList", "text!templates/registration/userType.htm", "models/userType"], (mustache, StepView, UserTypesRadioButtonList, template, UserType) ->
    class UserType extends StepView
        _renderRadios: ->
            radios = new UserTypesRadioButtonList
                el: $ "#radios"
            radios.render()

        render: ->
            @setHero
                Headline: "Vilken är din roll/titel?"
            @appendButtons
                markup: mustache.render(template)
                previousStep: "location"
                nextStep: "userTypesNeeded"
            renderRadios()        

        events: 
            "click button": "save"

        save: ->
            userType = new UserType
                Title: $("#title").val()
                Description: $("#description").val()

            userType.save()
            renderRadios()
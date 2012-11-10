define ["mustache", "views/registration/step", "views/shared/userTypeCheckBoxList", "text!templates/registration/userType.htm", "models/userType"], (mustache, StepView, UserTypesCheckBoxList, template, UserType) ->
    class UserTypesNeeded extends StepView
        _renderCheckBoxes: ->
            checkBoxes = new UserTypesCheckBoxList
                el: $ "#radios"

        _wireCheckBoxes: ->
            $(":checkbox").change(->
                if $(this).is ":checked"                 
                    $(this).parent().append $("<div><label>Lägg till valfri text: <input type='text' /></label></div>")      
                else
                    $(this).parent().find("div").remove())

        render: ->
            @setHero
                Headline: "Vad söker du för roller?"

            @appendButtons
                markup: mustache.render template
                previousStep: "userType"
                nextStep: "upload"

            @_renderCheckBoxes()
            @_wireCheckBoxes()

        events: 
            "click button": "add"
            "click .btn-primary": "save"
        
        add: ->
            userType = new UserType
                Title: $("#title").val()
                Description: $("#description").val()

            userType.save()
            renderCheckBoxes()

        saveStep: ->
            ideas = @model.get "Ideas"
            idea = ideas[0]
            idea.SearchProfile = {}
            idea.SearchProfile.UserTypesNeeded = {}

            idea.SearchProfile.UserTypesNeeded.UserTypeIds = []
            for $checkBox in $("#radios").find(":checked")
                idea.SearchProfile.UserTypesNeeded.UserTypeIds.push $checkBox.value

            @model.set 'Ideas', [idea]

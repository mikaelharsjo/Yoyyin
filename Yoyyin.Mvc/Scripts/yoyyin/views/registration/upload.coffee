define ["views/registration/step", "text!templates/registration/upload.htm"], (StepView, template) ->
    class Upload extends StepView
        render: ->
            @setHero
            	Headline: "Bild och CV"
            @appendButtons
            	markup: template
            	previousStep: "userTypesNeeded"
            	nextStep: "idea"
            $('.btn-group').find('btn').button()

        saveStep: ->
            image = @model.get 'Image'
            image.Avatar = $('input[name=avatar]:checked').val()
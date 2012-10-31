define ["views/registration/step", "text!templates/registration/upload.htm"], (StepView, template) ->
    class Upload extends StepView
        render: ->
            @setHero
            	Headline: "Bild och CV"
            @appendButtons
            	markup: template
            	previousStep: "tags"
            	nextStep: "idea"
            $('.btn-group').find('btn').button()

        saveStep: ->
            console.log 'To implement'
define ["views/registration/step", "text!templates/registration/upload.htm"], (StepView, template) ->
    class Upload extends StepView
        render: ->
            @setHero
            	Headline: "Bild och CV"
            @appendButtons
            	markup: template
            	previousStep: "tags"
            	nextStep: "idea"

        saveStep: ->
            console.log 'To implement'
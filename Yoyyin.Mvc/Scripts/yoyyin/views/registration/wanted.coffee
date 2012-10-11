define ["views/registration/step", "text!templates/registration/wanted.htm"], (StepView, template) ->
    class Wanted extends StepView
        render: ->
            @setHero({ Headline: "Vad söker du?" })
            @appendButtons(
                markup: template
                previousStep: "personalInfo"
                nextStep: "location")

            $("#wantsFinancing").change ->
                $("#financing").toggle()
            
        save: ->
            lookingFor = 
                JoinOrBeJoined: $("#JoinOrBeJoined").is(":checked")
                PartnerToMyIdea: $("#PartnerToMyIdea").is(":checked")
                IdeasToJoin: $("#IdeasToJoin").is(":checked")
                Investements: $("#Investments").is(":checked")
                Financing: $("#Financing").is(":checked")
            @model.set("LookingFor", lookingFor)
            console.log(this.model.toJSON())
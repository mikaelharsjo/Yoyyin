define ["views/registration/step", "text!templates/registration/wanted.htm"], (StepView, template) ->
    class Wanted extends StepView
        render: ->
            @setHero
                Headline: "Vad söker du?"
            @appendButtons
                markup: template
                previousStep: "personalInfo"
                nextStep: "location"

            $("#wantsFinancing").change ->
                $("#financing").toggle()
            
        save: ->
            financingIsSelected = $("#wantsFinancing").is(":checked")
            lookingFor = 
                JoinOrBeJoined: $("#JoinOrBeJoined").is(":checked")
                PartnerToMyIdea: $("#PartnerToMyIdea").is(":checked")
                IdeasToJoin: $("#IdeasToJoin").is(":checked")
                Investements: $("#Investments").is(":checked")
                Financing: financingIsSelected 
            @model.set("LookingFor", lookingFor)

            if financingIsSelected
                idea = 
                    Funding: 
                        WantsFinancing: true
                        Amount: $("#amount").val()
                        Description: $("#description").val()

                ideas = @model.get('Ideas')
                ideas[0] = idea

            console.log(this.model.toJSON())
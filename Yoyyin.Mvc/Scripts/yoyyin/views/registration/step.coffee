define ["backbone", "mustache", "text!templates/registration/form.htm", "text!templates/registration/hero.htm", "text!templates/registration/buttons.htm"], (backbone, mustache, formTemplate, heroTemplate, buttonsTemplate) ->
    class Step extends backbone.View
        el: $("#sectionMainContent")

        initialize: ->
            @$el.off()                  

        appendButtons: (step) ->
            buttons = mustache.render(buttonsTemplate, step)
            @$el.html(mustache.render(formTemplate, { markup: step.markup }) + buttons)

        setHero: (params) ->
            $("header.jumbotron").find(".container").html("")
            @setQuestion(params.Headline)
            @setDescription(params.Description)        

        setQuestion: (question) ->
            $("header.jumbotron").find(".container").append("<h2>" + question + "</h2>")

        setDescription: (description) ->
            $("header.jumbotron.container").append("<p class='lead'>" + description + "</p>")

        events: 
            "click .btn-primary": "save"

        save: ->
            console.log "base saving"
            this.save()
define(["backbone", "mustache", "text!templates/registration/hero.htm", "text!templates/registration/buttons.htm"], function (Backbone, mustache, heroTemplate, buttonsTemplate) {
    //var buttonsMarkup = "<div class='form-actions'><a class='btn' href='/#/{{previousStep}}'>Föregående</a><a class='btn btn-primary' href='/#/{{nextStep}}'>Nästa</a></div><form>";

    return Backbone.View.extend({
        el: $("#sectionMainContent"),

        appendButtons: function (step) {
            var buttons = mustache.render(buttonsTemplate, step);
            this.$el.html(step.markup + buttons);
        },

        setHero: function (params) {
            $("header.jumbotron").find(".container").html("");
            this.setQuestion(params.Headline);
            this.setDescription(params.Description);
        },

        setQuestion: function (question) {
            $("header.jumbotron").find(".container").append("<h1>" + question + "</h1>");
        },

        setDescription: function (description) {
            $("header.jumbotron.container").append("<p class='lead'>" + description + "</p>");
        }
    });
});
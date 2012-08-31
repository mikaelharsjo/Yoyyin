define(["backbone", "mustache", "text!templates/registration/hero.htm"], function (Backbone, mustache, heroTemplate) {
    var buttonsMarkup = "<div class='form-actions'><a class='btn' href='/#/{{previousStep}}'>Föregående</a><a class='btn btn-primary' href='/#/{{nextStep}}'>Nästa</a></div><form>";

    return Backbone.View.extend({
        el: $("#sectionMainContent"),

        appendButtons: function (step) {
            var buttons = mustache.to_html(buttonsMarkup, step);
            this.$el.html(step.markup + buttons);
        },

        setHero: function (params) {
            if ($(".featured").html() == null) {
                $("#body").prepend(mustache.render(heroTemplate, params));
            } else {
                this.setQuestion(params.Headline);
                this.setDescription(params.Description);
            }
        },

        setQuestion: function (question) {
            $(".featured").find("h1").text(question);
        },

        setDescription: function (description) {
            $(".featured").find("p").text(description);
        }
    });
});
define(["backbone", "mustache", "text!templates/registration/form.htm", "text!templates/registration/hero.htm", "text!templates/registration/buttons.htm"], function (Backbone, mustache, formTemplate, heroTemplate, buttonsTemplate) {

    return Backbone.View.extend({
        el: $("#sectionMainContent"),

        initialize: function (options) {
            this.delegateEvents(this.buildEvents());
        },

        buildEvents: function () {
            return {
                'click #loadmore': 'loadMore'
            };
        },

        appendButtons: function (step) {
            var buttons = mustache.render(buttonsTemplate, step);
            this.$el.html(mustache.render(formTemplate, { markup: step.markup }) + buttons);
        },

        setHero: function (params) {
            $("header.jumbotron").find(".container").html("");
            this.setQuestion(params.Headline);
            this.setDescription(params.Description);
        },

        setQuestion: function (question) {
            $("header.jumbotron").find(".container").append("<h2>" + question + "</h2>");
        },

        setDescription: function (description) {
            $("header.jumbotron.container").append("<p class='lead'>" + description + "</p>");
        },
        events: {
            "click .btn-primary": "save"
        },
        save: function () {
            this.save();
        }
    });
});
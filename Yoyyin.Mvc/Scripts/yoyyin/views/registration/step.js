// Generated by CoffeeScript 1.3.3
(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; };

  define(["backbone", "mustache", "text!templates/registration/form.htm", "text!templates/registration/hero.htm", "text!templates/registration/buttons.htm"], function(backbone, mustache, formTemplate, heroTemplate, buttonsTemplate) {
    var Step;
    return Step = (function(_super) {

      __extends(Step, _super);

      function Step() {
        return Step.__super__.constructor.apply(this, arguments);
      }

      Step.prototype.el = $("#sectionMainContent");

      Step.prototype.initialize = function() {
        return this.$el.off();
      };

      Step.prototype.appendButtons = function(step) {
        var buttons;
        buttons = mustache.render(buttonsTemplate, step);
        return this.$el.html(mustache.render(formTemplate, {
          markup: step.markup
        }) + buttons);
      };

      Step.prototype.setHero = function(params) {
        $("header.jumbotron").find(".container").html("");
        this.setQuestion(params.Headline);
        return this.setDescription(params.Description);
      };

      Step.prototype.setQuestion = function(question) {
        return $("header.jumbotron").find(".container").append("<h2>" + question + "</h2>");
      };

      Step.prototype.setDescription = function(description) {
        return $("header.jumbotron.container").append("<p class='lead'>" + description + "</p>");
      };

      Step.prototype.events = {
        "click .btn-primary": "save"
      };

      Step.prototype.save = function() {
        console.log("base saving");
        return this.saveStep();
      };

      return Step;

    })(backbone.View);
  });

}).call(this);

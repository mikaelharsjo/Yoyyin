// Generated by CoffeeScript 1.3.3
(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; };

  define(["views/registration/step", "text!templates/registration/idea.htm", "views/shared/sniCascadingDropDown"], function(StepView, template, CascadingDropDownView) {
    var Idea;
    return Idea = (function(_super) {

      __extends(Idea, _super);

      function Idea() {
        return Idea.__super__.constructor.apply(this, arguments);
      }

      Idea.prototype.render = function() {
        this.setHero({
          Headline: "Sista steget - Nu vill vi höra om din affärsidé"
        });
        this.appendButtons({
          markup: template,
          previousStep: "upload",
          nextStep: "idea"
        });
        $("div.form-actions").append("<a class='btn btn-warning' href='/#/register/userType'>Jag har ingen affärsidé</a>");
        this.dropDown = new CascadingDropDownView({
          el: $("#sniDropDowns")
        });
        return this.dropDown.render();
      };

      Idea.prototype.saveStep = function() {
        var idea;
        idea = this.model.get('idea');
        idea = {
          CompanyName: this.$el.find('#companyName').val(),
          Title: this.$el.find('#title').val(),
          Description: this.$el.find('#description').val(),
          SniNo: this.dropDown.getHeadVal(),
          SniHeadId: this.dropDown.getItemVal()
        };
        console.log(idea);
        this.model.set("Ideas", [idea]);
        console.log(this.model);
        return this.model.save();
      };

      return Idea;

    })(StepView);
  });

}).call(this);

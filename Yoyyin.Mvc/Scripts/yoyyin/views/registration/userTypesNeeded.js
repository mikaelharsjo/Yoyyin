// Generated by CoffeeScript 1.3.3
(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; };

  define(["mustache", "views/registration/step", "views/shared/userTypeCheckBoxList", "text!templates/registration/userType.htm", "models/userType"], function(mustache, StepView, UserTypesCheckBoxList, template, UserType) {
    var UserTypesNeeded;
    return UserTypesNeeded = (function(_super) {

      __extends(UserTypesNeeded, _super);

      function UserTypesNeeded() {
        return UserTypesNeeded.__super__.constructor.apply(this, arguments);
      }

      UserTypesNeeded.prototype._renderCheckBoxes = function() {
        var checkBoxes;
        return checkBoxes = new UserTypesCheckBoxList({
          el: $("#radios")
        });
      };

      UserTypesNeeded.prototype._wireCheckBoxes = function() {
        return $(":checkbox").change(function() {
          if ($(this).is(":checked")) {
            return $(this).parent().append($("<div><label>Lägg till valfri text: <input type='text' /></label></div>"));
          } else {
            return $(this).parent().find("div").remove();
          }
        });
      };

      UserTypesNeeded.prototype.render = function() {
        this.setHero({
          Headline: "Vad söker du för roller?"
        });
        this.appendButtons({
          markup: mustache.render(template),
          previousStep: "userType",
          nextStep: "upload"
        });
        this._renderCheckBoxes();
        return this._wireCheckBoxes();
      };

      UserTypesNeeded.prototype.events = {
        "click button": "add",
        "click .btn-primary": "save"
      };

      UserTypesNeeded.prototype.add = function() {
        var userType;
        userType = new UserType({
          Title: $("#title").val(),
          Description: $("#description").val()
        });
        userType.save();
        return renderCheckBoxes();
      };

      UserTypesNeeded.prototype.saveStep = function() {
        var $checkBox, idea, ideas, _i, _len, _ref;
        ideas = this.model.get("Ideas");
        idea = ideas[0];
        idea.SearchProfile = {};
        idea.SearchProfile.UserTypesNeeded = {};
        idea.SearchProfile.UserTypesNeeded.UserTypeIds = [];
        _ref = $("#radios").find(":checked");
        for (_i = 0, _len = _ref.length; _i < _len; _i++) {
          $checkBox = _ref[_i];
          idea.SearchProfile.UserTypesNeeded.UserTypeIds.push($checkBox.value);
        }
        return this.model.set('Ideas', [idea]);
      };

      return UserTypesNeeded;

    })(StepView);
  });

}).call(this);

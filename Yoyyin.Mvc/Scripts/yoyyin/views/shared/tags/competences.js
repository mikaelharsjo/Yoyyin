// Generated by CoffeeScript 1.3.3
(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; };

  define(["backbone"], function(backbone) {
    var Competences;
    return Competences = (function(_super) {

      __extends(Competences, _super);

      function Competences() {
        return Competences.__super__.constructor.apply(this, arguments);
      }

      Competences.prototype.initialize = function() {
        var _this = this;
        return $.get("/Tagging/Competences/", function(competences) {
          return _this.$el.tagit({
            availableTags: competences
          });
        });
      };

      return Competences;

    })(backbone.View);
  });

}).call(this);

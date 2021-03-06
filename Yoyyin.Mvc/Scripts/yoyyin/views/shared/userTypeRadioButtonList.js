// Generated by CoffeeScript 1.3.3
(function() {
  var __bind = function(fn, me){ return function(){ return fn.apply(me, arguments); }; },
    __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; };

  define(["backbone", "mustache", "collections/userTypes", "text!templates/shared/userTypeRadio.htm"], function(backbone, mustache, UserTypes, template) {
    var UserTypeRadioButtonList;
    return UserTypeRadioButtonList = (function(_super) {

      __extends(UserTypeRadioButtonList, _super);

      function UserTypeRadioButtonList() {
        this.render = __bind(this.render, this);
        return UserTypeRadioButtonList.__super__.constructor.apply(this, arguments);
      }

      UserTypeRadioButtonList.prototype.initialize = function() {
        this.collection = new UserTypes();
        this.collection.on('reset', this.render);
        return this.collection.fetch();
      };

      UserTypeRadioButtonList.prototype.render = function() {
        var markup;
        markup = "";
        this.collection.each(function(userType) {
          return markup += mustache.render(template, userType.toJSON());
        });
        return this.$el.html(markup);
      };

      return UserTypeRadioButtonList;

    })(backbone.View);
  });

}).call(this);

// Generated by CoffeeScript 1.3.3
(function() {
  var __bind = function(fn, me){ return function(){ return fn.apply(me, arguments); }; },
    __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; };

  define(["backbone", "mustache", "collections/userTypes", "text!templates/shared/userTypeCheckBox.htm"], function(backbone, mustache, UserTypes, template) {
    var UserTypeCheckBoxList;
    return UserTypeCheckBoxList = (function(_super) {

      __extends(UserTypeCheckBoxList, _super);

      function UserTypeCheckBoxList() {
        this.render = __bind(this.render, this);
        return UserTypeCheckBoxList.__super__.constructor.apply(this, arguments);
      }

      UserTypeCheckBoxList.prototype.initialize = function() {
        this.collection = new UserTypes();
        this.collection.on('reset', this.render);
        return this.collection.fetch();
      };

      UserTypeCheckBoxList.prototype.render = function() {
        var markup;
        markup = "";
        this.collection.each(function(userType) {
          return markup += mustache.render(template, userType.toJSON());
        });
        return this.$el.html(markup);
      };

      return UserTypeCheckBoxList;

    })(backbone.View);
  });

}).call(this);

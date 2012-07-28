/// <reference path="../sammy.js" />
var yoyyin = { };
yoyyin.register = { };

yoyyin.model = yoyyin.model || { };
yoyyin.model.special = yoyyin.model.special || { };
yoyyin.routers = yoyyin.routers || { };
yoyyin.views = yoyyin.views || { };

require.config({ baseUrl: "/Scripts/yoyyin" });

$(function($) {
    $("#formQuickSearch").quickSearch({ $placeHolder: $("#sectionMainContent") });
    $('#carousel').carousel();
});
    






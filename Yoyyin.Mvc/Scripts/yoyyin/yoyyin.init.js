/// <reference path="../sammy.js" />
var yoyyin = {};
yoyyin.register = {};

require.config({ baseUrl: "/Scripts/yoyyin" });

$(function($) {
    $("#formQuickSearch").quickSearch({ $placeHolder: $("#sectionMainContent") });
    $('#carousel').carousel();
});
    






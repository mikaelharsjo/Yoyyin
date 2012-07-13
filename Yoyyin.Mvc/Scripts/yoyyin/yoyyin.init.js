/// <reference path="../sammy.js" />
var yoyyin = {};
yoyyin.register = {};

require.config({ baseUrl: "/Scripts" });

$(function($) {
    $("#formQuickSearch").quickSearch({ $placeHolder: $("#sectionMainContent") });
    $('#carousel').carousel();
});
    






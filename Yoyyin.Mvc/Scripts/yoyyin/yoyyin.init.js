/// <reference path="../sammy.js" />
var yoyyin = {};
yoyyin.register = {};

require.config({ baseUrl: "/Scripts/lib" });

$(function($) {
    $("#formQuickSearch").quickSearch({ $placeHolder: $("#sectionMainContent") });
    $('#carousel').carousel();
});
    






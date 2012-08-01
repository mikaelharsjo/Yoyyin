/// <reference path="../sammy.js" />
var yoyyin = { };
yoyyin.register = { };

yoyyin.model = yoyyin.model || { };
yoyyin.model.special = yoyyin.model.special || { };
yoyyin.routers = yoyyin.routers || { };
yoyyin.views = yoyyin.views || { };

define('mustache', ['../lib/mustache'], function () {
    // Tell Require.js that this module returns a reference to Mustache
    return Mustache; // from global
});

require.config({
    baseUrl: "/Scripts/yoyyin",
    paths: {
        "underscore": "../lib/underscore",
        "backbone": "../lib/backbone"//,
        //"mustache": "../lib/mustache"
    },
    'shim':
	{
	    backbone: {
	        'deps': ['jquery', 'underscore'],
	        'exports': 'Backbone'
	    }
	}
});

$(function($) {
    $("#formQuickSearch").quickSearch({ $placeHolder: $("#sectionMainContent") });
    $('#carousel').carousel();
});
    






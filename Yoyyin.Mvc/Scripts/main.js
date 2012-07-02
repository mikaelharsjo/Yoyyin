require.config({
    //baseUrl: "/Scripts",
    paths: {
        jquery: 'https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min'
    }//,
    //priority: ['jquery']
});

define('sammy', ['jquery', 'http://cdnjs.cloudflare.com/ajax/libs/sammy.js/0.7.1/sammy.min.js'], function (undefined) { return Sammy; });
define('bootstrap', ['jquery', 'http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/2.0.2/bootstrap.min.js'], function ($, undefined) { return undefined; });

require(["yoyyin/register/register", "bootstrap"], function (appRegister, b) {
    //$("#formQuickSearch").quickSearch({ $placeHolder: $("#sectionMainContent") });
    
    
    
    
    debugger;
    $('#carousel').carousel();
    appRegister.run("#/register/location");
});

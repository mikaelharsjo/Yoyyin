/// <reference path="../sammy.js" />
var yoyyin = { };
    
(function($) {
    var app = $.sammy("#sectionMainContent", function() {
        this.use(Sammy.Mustache, "html");

        this.get('#/', function(context) {
            context.swap("apa");
        });

        this.get("#/register/:step", function(context) {
            
            context.swap(this.params["step"]);
        });
    });

    $(function () {
        $(".registerLink").registerLink();
        $("#formQuickSearch").quickSearch({ $placeHolder: $("#sectionMainContent") });
        $('#carousel').carousel();

        app.run("#/register");
    });

})(jQuery);


// initialize




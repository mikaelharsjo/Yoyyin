﻿yoyyin.register.tags = function () {
    var template = "<p>Har du svårt att hitta på kompetenser? <a id='showAllCompetences'>Visa andras kompetenser</a></p>";
    return {
        setDescription: function () {
            $(".featured").find("p").html(template);

            $("#showAllCompetences").click(function () {
                $.get("/Tagging/CompetencesPartial", function (markup) {
                    $("<div></div>").append(markup).dialog({ width: "700", title: "Kompetenser" });
                });
            });
        }
    };
} ();
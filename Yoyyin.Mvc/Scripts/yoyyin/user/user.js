yoyyin.user = function (mustache) {
    $.sammy("#sectionMainContent", function () {
        this.get("#/user/all", function (context) {
            // TODO: find better way
            $(".featured").hide();
            $(".featured + .main-content").css("background", "none");
            
            require(["text!../../Templates/User/row.htm", "text!../../Templates/User/table.htm", "text!../../Templates/User/competenceLabel.htm", "text!../../Templates/User/image.htm"], function (rowTemplate, tableTemplate, competenceTemplate, imageTemplate) {
                $.getJSON("/User/All", function (users) {
                    var markup = "";
                    $.each(users, function (index, user) {
                        user.CompetencesMarkup = "";
                        $.each(user.Competences, function (index, competence) {
                            user.CompetencesMarkup += mustache.to_html(competenceTemplate, { Competence: competence });
                        });
                        
                        var imageMarkup = mustache.render(imageTemplate, { Src: user.SmallProfileImageSrc });
                        user.ImageMarkup = imageMarkup;

                        markup += mustache.render(rowTemplate, user);
                    });

                    markup = mustache.to_html(tableTemplate, { rows: markup });
                    context.swap(markup);
                });
            });
        });
    });
} (Mustache);
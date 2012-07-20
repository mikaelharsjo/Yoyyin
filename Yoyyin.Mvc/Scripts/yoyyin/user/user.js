yoyyin.user = function (mustache) {
    $.sammy("#sectionMainContent", function () {
        this.get("#/user/all", function (context) {
            // TODO: find better way
            $(".featured").hide();
            $(".featured + .main-content").css("background", "none");

            require(["text!../../Templates/User/row.htm", "text!../../Templates/User/container.htm", "text!../../Templates/User/competenceLabel.htm", "text!../../Templates/User/image.htm", "text!../../Templates/User/userTypeLabel.htm"], function (rowTemplate, containerTemplate, competenceTemplate, imageTemplate, userTypeLabelTemplate) {
                $.getJSON("/User/All", function (users) {
                    var markup = "";
                    $.each(users, function (index, user) {
                        user.CompetencesNeededMarkup = "";
                        $.each(user.CompetencesNeeded, function (index, competence) {
                            user.CompetencesNeededMarkup += mustache.to_html(competenceTemplate, { Competence: competence });
                        });
                        
                        user.CompetencesMarkup = "";
                        $.each(user.Competences, function (index, competence) {
                            user.CompetencesMarkup += mustache.to_html(competenceTemplate, { Competence: competence });
                        });

                        user.UserType = mustache.to_html(userTypeLabelTemplate, { Title: user.UserType});

                        user.UserTypesNeededMarkup = "";
                        $.each(user.UserTypesNeeded, function (index, userType) {
                            user.UserTypesNeededMarkup += mustache.to_html(userTypeLabelTemplate, { Title: userType });
                        });

                        var imageMarkup = mustache.render(imageTemplate, { Src: user.SmallProfileImageSrc });
                        user.ImageMarkup = imageMarkup;

                        markup += mustache.render(rowTemplate, user);
                    });

                    markup = mustache.to_html(containerTemplate, { items: markup });
                    context.swap(markup);
                });
            });
        });
    });
} (Mustache);
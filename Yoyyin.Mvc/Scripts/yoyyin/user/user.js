yoyyin.user = function (mustache) {
    var appUser = $.sammy("#sectionMainContent", function () {
        this.get("#/user/all", function (context) {
            console.log("all users");

            require(["text!../../Templates/User/userRow.htm"], function (template) {

                $.getJSON("/User/All", function (users) {
                    var markup = "";
                    $.each(users, function (index, user) {
                        competenceTemplate = "<span class='label label-info'>{{Competence}}</span>&nbsp;";
                        user.CompetencesMarkup = "";
                        $.each(user.Competences, function (index, competence) {
                            //markup += competence;
                            user.CompetencesMarkup += mustache.to_html(competenceTemplate, { Competence: competence });
                            console.log(competence);
                        });
                        markup += mustache.render(template, user);
                    });
                    context.swap(markup);
                });

            });
        });
    });
} (Mustache);
yoyyin.register.userType = function (mustache) {
    var userTypeRadioTemplate = "<label class='radio'><input name='optionsRadios' id='optionsRadios1' value='{{UserTypeId}}' checked='checked' type='radio'><strong>{{Title}}</strong> {{Description}}</label>";

    return {
        init: function (callback) {
            var markup = "<div class='ui-helper-clearfix'><div class='stepLeft'>";
            $.getJSON("/UserType/All", function (userTypes) {
                $.each(userTypes, function (index, userType) {
                    markup += mustache.render(userTypeRadioTemplate, userType);
                });

                markup += "</div>";

                var $markup = $(markup);

                $markup.append("<div class='stepRight'><h3>Ingen roll som passar?</h3><p>Hitta på en egen roll</p><label>Namn</label><input type='text' /><label>Beskrivning</label><input type='text' /></div></div>");
                

                if (callback) {
                    var html = $("<div>").append($markup.clone()).html();
                    callback(html);
                }
            });
        }
    };
} (Mustache)
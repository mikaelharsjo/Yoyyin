﻿yoyyin.register.userType = function (mustache) {
    var userTypeRadioTemplate = "<label class='radio'><input name='optionsRadios' id='optionsRadios1' value='{{UserTypeId}}' checked='checked' type='radio'><strong>{{Title}}</strong> {{Description}}</label>";

    return {
        init: function (callback) {
            var stepLeft = "<div class='ui-helper-clearfix'><div class='stepLeft'>";
            $.getJSON("/UserType/All", function (userTypes) {
                $.each(userTypes, function (index, userType) {
                    stepLeft += mustache.render(userTypeRadioTemplate, userType);
                });

                stepLeft += "</div>";
                var $markup = $(stepLeft);

                var $stepRight = $("<div class='stepRight'><h3>Ingen roll som passar?</h3><p>Hitta på en egen roll</p><label>Namn</label><input type='text' /><label>Beskrivning</label><input type='text' /><br /></div>");

                var $saveButton = $("<button id='btnSaveUserType' class='btn' data-loading-text='Sparar...' >Spara</button>")
                //$saveButton.button();
                $stepRight.append($saveButton);

                $markup = $markup.append($stepRight.append($saveButton));

                if (callback) {
                    // looks tricky but it´s just to get the markup
                    var html = $("<div>").append($markup.clone()).html();
                    callback(html);
                }
            });
        },
        save: function () {
            console.log("save user type");
        }
    };
} (Mustache)
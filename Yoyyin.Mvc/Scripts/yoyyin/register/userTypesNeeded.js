﻿define(function(mustache) {
    var userTypeRadioTemplate = "<label class='checkbox'><input name='optionsRadios' id='optionsRadios1' value='{{UserTypeId}}' type='checkbox' /><strong>{{Title}}</strong> {{Description}}</label>";

    return {
        init: function(callback) {
            var stepLeft = "<div class='ui-helper-clearfix'><div class='stepLeft'>";
            $.getJSON("/UserType/All", function(userTypes) {
                $.each(userTypes, function(index, userType) {
                    stepLeft += Mustache.render(userTypeRadioTemplate, userType);
                });

                stepLeft += "</div>";
                var $markup = $(stepLeft);

                var $stepRight = $("<div class='stepRight'><h3>Ingen roll som passar?</h3><p>Hitta på en egen roll</p><label>Titel:</label><input type='text' id='title' /><label>Beskrivning</label><input type='text' id='description' /><br /></div>");

                var $saveButton = $("<button id='btnSaveUserType' class='btn btn-primary' data-loading-text='Sparar...' >Lägg till</button>")
                $stepRight.append($saveButton);

                $markup = $markup.append($stepRight.append($saveButton));

                if (callback) {
                    // looks tricky but it´s just to get the markup
                    var html = $("<div>").append($markup.clone()).html();
                    callback(html);
                }
            });
        },
        save: function() {
            var userType = {
                Title: $("#title").val(),
                Description: $("#description").val()
            };

            $.post("/UserType/Create", userType, function() {              
                $(".stepLeft").append(Mustache.render(userTypeRadioTemplate, userType))
                $("#btnSaveUserType").button("reset");
            }
            );
        }
    };
});
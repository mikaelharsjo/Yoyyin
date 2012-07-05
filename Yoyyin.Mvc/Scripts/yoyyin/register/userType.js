yoyyin.register.userType = function (mustache) {
    var userTypeRadioTemplate = "<label class='radio'><input name='optionsRadios' id='optionsRadios1' value='{{UserTypeId}}' checked='checked' type='radio'><strong>{{Title}}</strong> {{Description}}</label>";

    //<input type='radio' name='radioRole' id='radioentrepreneurbusinessman' checked='checked' value='0' title='{{Title}}' /><label for='radioentrepreneurbusinessman'>Jag driver ett företag eller vill starta upp och driva ett företag. <strong>(Företagare/Entreprenör)</strong></label>";
    return {
        init: function (callback) {
            var markup = "";
            $.getJSON("/UserType/All", function (userTypes) {
                $.each(userTypes, function (index, userType) {
                    markup += mustache.render(userTypeRadioTemplate, userType);
                });

                callback(markup);
            });

            return markup;
        }
    };
} (Mustache)
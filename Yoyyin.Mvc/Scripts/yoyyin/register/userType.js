yoyyin.register.userType = function (mustache) {
    var userTypeRadioTemplate = "<input type='radio' name='radioRole' id='radioentrepreneurbusinessman' checked='checked' value='0' title='{{Title}}' /><label for='radioentrepreneurbusinessman'>Jag driver ett företag eller vill starta upp och driva ett företag. <strong>(Företagare/Entreprenör)</strong></label>";
    return {
        getContent: function () {
            var markup = "";
            $.getJSON("/UserType/All", function (userTypes) {
                $.each(userTypes, function (index, userType) {
                    console.log(userType);
                    markup += mustache.render(userTypeRadioTemplate, userType);
                    console.log(markup);
                });
            });

            return markup;
        }
    };
} (Mustache)
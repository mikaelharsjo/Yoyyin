yoyyin.register = function () {
    return {
        open: function () {
            $.get("/Register/Step1", function (result) {
                var output = Mustache.render("<form class='form-horizontal'><fieldset>{{View}}</fieldset><form>", result);
                console.log(result);
                $("" + output + "<fieldset>").dialog({ title: "Bli medlem", modal: true, width: 800 });
            });
        }
    };
} ();
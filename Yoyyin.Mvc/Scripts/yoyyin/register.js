yoyyin.register = function () {
    return {
        open: function () {
            $.get("/Register/Step1", function (html) {
                console.log(html);
                $("<form class='form-horizontal'>" + html + "<fieldset>").dialog({ title: "Bli medlem", modal: true, width: 800 });
            });
        }
    };
} ();
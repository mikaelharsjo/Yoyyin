yoyyin.register = function () {
    return {
        open: function () {
            $.get("/Register/Step1", function (result) {
                var step1 =
                    {
                        view: result
                    };
                //var html = Mustache.render("<form class='form-horizontal'><fieldset>{{view}}</fieldset><form>", step1);
                var html = "<form><fieldset>" + result + "</fieldset><div class='form-actions'><button type='submit' class='btn btn-primary'>Spara</button><button class='btn'>Cancel</button></div><form>";
                console.log(result);
                $(html).dialog({ title: "Bli medlem", modal: true, width: 800 });
            });
        }
    };
} ();
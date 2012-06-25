yoyyin.register = function () {
    var stepPersonalMarkup = "<section><hgroup class='title'><h1>Först behöver vi lite personuppgifter.</h1></hgroup></div></section><div class='main-content'><label class='control-label' for='name'>Namn:</label><input type='text' class='input-xlarge' id='name' /><p class='help-block'>Supporting help text</p><label class='control-label' for='alias'>Alias:</label><input type='text' class='input-xlarge' id='alias' /><p class='help-block'>Supporting help text</p><label class='control-label' for='street'>Gatuadress:</label><input type='text' class='input-xlarge' id='street' /><label class='control-label' for='zipCode'>Postnummer:</label><input type='text' class='input-xlarge' id='zipCode' /><label class='control-label' for='city'>Stad/ort:</label><input type='text' class='input-xlarge' id='city' /></div>";
    var buttonsMarkup = "<div class='form-actions'><button type='submit' class='btn btn-primary'>Spara</button><button class='btn'>Cancel</button></div><form>";
    
    return {
        open: function () {
            //$.get("/Register/Step1", function (result) {
            //var html = Mustache.render("<form class='form-horizontal'><fieldset>{{view}}</fieldset><form>", step1);
            var html = "<form><fieldset>" + stepPersonalMarkup + "</fieldset>" + buttonsMarkup;
            $(html).dialog({ title: "Bli medlem", modal: true, width: 800 });
        }
    };
} ();
yoyyin.register.location = function (mustache) {
    var stepLocationMarkup = "<section><hgroup class='title'><h1>Var är du?</h1></hgroup></div></section><div class='main-content'><label class='control-label' for='street'>Gatuadress:</label><input type='text' class='input-xlarge' id='street' value='{{Street}}' /><label class='control-label' for='zipCode'>Postnummer:</label><input type='text' class='input-xlarge' id='zipCode' value='{{ZipCode}}' /><label class='control-label' for='city'>Stad/ort:</label><input type='text' class='input-xlarge' id='city' value='{{City}}' /></div><div id='registerMap'></div>";

    var getPosition = function (options) {
        navigator.geolocation.getCurrentPosition(
            lookupCountry,
            null,
            options);
    };

    var lookupCountry = function (position) {
        var latlng = new google.maps.LatLng(
                            position.coords.latitude,
                            position.coords.longitude);

        var geoCoder = new google.maps.Geocoder();
        geoCoder.geocode({ location: latlng }, displayResults);
    };

    var displayResults = function (results, status) {

        var parts = results[0].address_components;
        var location = {
            Street: parts[1].long_name + " " + parts[0].long_name,
            City: parts[2].long_name,
            Country: parts[3].long_name,
            ZipCode: parts[4].long_name
        };

        $("#sectionMainContent").html(mustache.render(stepLocationMarkup, location));

        $("#registerMap").goMap();
    };

    return {
        getContent: function () {
            getPosition();
            //return markup + "apa";
        }
    };
} (Mustache);
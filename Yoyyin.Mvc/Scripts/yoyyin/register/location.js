define('mustache', function(mustache) {
    var stepLocationMarkup = "<section><hgroup class='title'><h1>Var är du?</h1></hgroup></div></section><div class='ui-helper-clearfix'><div class='stepLeft'><label class='control-label' for='street'>Gatuadress:</label><input type='text' class='input-xlarge' id='street' value='{{Street}}' /><label class='control-label' for='zipCode'>Postnummer:</label><input type='text' class='input-xlarge' id='zipCode' value='{{ZipCode}}' /><label class='control-label' for='city'>Stad/ort:</label><input type='text' class='input-xlarge' id='city' value='{{City}}' /></div><div id='registerMap' class='stepRight thumbnail'></div></div>";

    var getPosition = function(options) {
        navigator.geolocation.getCurrentPosition(
            lookupCountry,
            null,
            options);
    };

    var lookupCountry = function(position) {
        var latlng = new google.maps.LatLng(
            position.coords.latitude,
            position.coords.longitude);

        var geoCoder = new google.maps.Geocoder();
        geoCoder.geocode({ location: latlng }, displayResults);
    };

    var displayResults = function(results, status) {
        console.log(results[0]);
        var parts = results[0].address_components;
        var location = {
            Street: parts[1].long_name + " " + parts[0].long_name,
            City: parts[2].long_name,
            Country: parts[3].long_name,
            ZipCode: parts[4].long_name,
            Latitude: results[0].geometry.location.$a,
            Longitude: results[0].geometry.location.ab
        };

        var markup = mustache.render(stepLocationMarkup, location);
        stepLocationMarkup = markup + "<div class='form-actions'><a class='btn' href='/#/register/personalInfo'>Föregående</button> <a class='btn btn-primary'>Nästa</a></div><form>";

        $("#sectionMainContent").html(stepLocationMarkup);

        $("#registerMap").goMap({
            latitude: location.Latitude,
            longitude: location.Longitude,
            zoom: 12,
            maptype: 'ROADMAP',
            markers: [{
                latitude: location.Latitude,
                longitude: location.Longitude,
                html: { content: "<h2>Hej</h2><p>hoppla</p>" }
            }]
        });
    };

    return {
        getContent: function() {
            getPosition();
            //return markup + "apa";
        }
    };
});
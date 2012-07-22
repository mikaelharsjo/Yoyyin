yoyyin.register.location = function () {
    var callback;

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
        console.log(results[0]);

        var location = {
            Street: parts[1].long_name + " " + parts[0].long_name,
            City: parts[2].long_name,
            Country: parts[3].long_name,
            ZipCode: parts[4].long_name,
            Latitude: results[0].geometry.location.lat(),
            Longitude: results[0].geometry.location.lng()
        };

        callback(location);

        console.log(location);
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
        getContent: function (setCallback) {
            callback = setCallback;
            getPosition();
        }
    };
} ();
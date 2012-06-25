yoyyin.register.location = function () {
    var getPosition = function (options) {
        navigator.geolocation.getCurrentPosition(
            lookupCountry,
            null,
            options);
    };

    var lookupCountry = function (position) {
        console.log(position);
//        var latlng = new google.maps.LatLng(
//                            position.coords.latitude,
//                            position.coords.longitude);

//        var geoCoder = new google.maps.Geocoder();
//        geoCoder.geocode({ location: latlng }, displayResults);
    };

    var displayResults = function (results, status) {
        // here you can look through results ...
        $("body").append("<div>").text(results[0].formatted_address);
    };
    return {
        getContent: function () {
            return getPosition();
        }
    };
} ();
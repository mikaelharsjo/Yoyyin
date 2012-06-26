yoyyin.register.location = function () {
    var user = {};
    var that = this;

    var setPosition = function (options) {
        console.log(that.user);
        navigator.geolocation.getCurrentPosition(
            lookupCountry,
            null,
            options);
    };

    var lookupCountry = function (position) {
        console.log(user);
        var latlng = new google.maps.LatLng(
                            position.coords.latitude,
                            position.coords.longitude);

        var geoCoder = new google.maps.Geocoder();
        geoCoder.geocode({ location: latlng }, addLocationToUser);
    };

    var addLocationToUser = function (results, status) {
        var parts = results[0].address_components;
        that.user.Street = parts[1] + " " + parts[0];
        that.user.City = parts[2];
        that.user.Country = parts[3];
        that.user.ZipCode = parts[4];
    };

    var displayResults = function (results, status) {
        // here you can look through results ...
        console.log(results[0]);
        $("body").append("<div>").text(results[0].formatted_address);
    };
    return {
        setUser: function (currUser) {
            console.log("setting user");
            this.user = currUser;
        },
        getContent: function () {
            setPosition();
            return user.Street;
        }
    };
} ();
define(["views/registration/step", "text!templates/registration/location.htm", "mustache"], function (StepView, template, Mustache) {
    var callback;

    var getPosition = function (callback) {
        this.callback = callback;
        navigator.geolocation.getCurrentPosition(
            lookupCountry,
            null,
            callback);
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
            ZipCode: parts[4].long_name,
            Latitude: results[0].geometry.location.lat(),
            Longitude: results[0].geometry.location.lng()
        };

        this.callback(location);

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

    return StepView.extend({
        render: function () {
            this.setHero({
                Headline: "Vilken adress ska användas för visning på karta?",
                Description: "Vi har hämtat adressen nedan från din nuvarande position. Vi använder bara denna för visning på karta och liknande i samband med sökningar."
            });

            //this.appendButtons({ markup: template, previousStep: "personalInfo", nextStep: "location" });
            //callback =
            var that = this;
            getPosition(function (data) {
                var html = Mustache.render(template, data);
                that.$el.html(html);

                //this.appendButtons({ markup: html, previousStep: "wanted", nextStep: "userType" });

                $("div.form-actions").append("<a class='btn btn-warning' href='/#/register/userType'>Visa mig inte på kartor</a>")
            });
        }
    });
});

define ["views/registration/step", "text!templates/registration/location.htm", "mustache"], (StepView, template, Mustache) ->
   class Location extends StepView
        getPosition: (callback) ->
            @callback = callback
            navigator.geolocation.getCurrentPosition(geoCodeCoords, getPositonErrorHandler)

        getPositonErrorHandler: ->
            @callback()

        geoCodeCoords: (position) ->
            latlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude)

            geoCoder = new google.maps.Geocoder()
            geoCoder.geocode({ location: latlng }, displayResults)

        displayResults: (results, status) ->
            parts = results[0].address_components

            location = 
                Street: parts[1].long_name + " " + parts[0].long_name
                City: parts[2].long_name
                Country: parts[3].long_name
                ZipCode: parts[4].long_name
                Latitude: results[0].geometry.location.lat()
                Longitude: results[0].geometry.location.lng()

            @callback(location)

            latLng = new google.maps.LatLng(location.Latitude, location.Longitude)
            mapOptions =
                center: latLng
                zoom: 12
                mapTypeId: google.maps.MapTypeId.ROADMAP

            map = new google.maps.Map document.getElementById("registerMap"), mapOptions

            marker = new google.maps.Marker
                position: latLng
                map: map
                title: "Här kommer du att visas"
    
        render: ->
            @setHero
                Headline: "Vilken adress ska användas för visning på karta?",
                Description: "Vi har hämtat adressen nedan från din nuvarande position. Vi använder bara denna för visning på karta och liknande i samband med sökningar."

            getPosition((data) =>
                html = Mustache.render(template, data || {})
                btnMarkup = "<a class='btn btn-warning' href='/#/userType'>Visa mig inte på kartor</a>"
                @appendButtons
                    markup: html
                    previousStep: "wanted"
                    nextStep: "userType"
                    extraButtonMarkup: btnMarkup)

        save: ->
            adress = @model.get("Adress")
            adress.set("City", @$el.find("#city").val())
            adress.set("Country", @$el.find("#country").val())
            adress.set("Street", @$el.find("#street").val())
            adress.set("ZipCode", @$el.find("#zipCode").val())
            console.log(@model)
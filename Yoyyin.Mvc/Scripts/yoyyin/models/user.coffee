define ["backbone"], (backbone) ->
    class User extends backbone.Model
        url: ->
            "/User/Get/#{@id}"
            
        defaults:
       		Name: ''
        	CVFileName: ''
        	Active: true
        	UserTypeDescription: ''
        	Address:
                Coordinate:
                    Latitude: null
                    Longitude: null
        	Settings: {}
        	Email: ''        
        	UserType: 0
        	Urls: []
        	Ideas:[
                SearchProfile: {}
                Funding: {}
                Comments: []                
            ]
        	Competences: []
        	Image: {}
        	Presentation: ''
        	LookingFor: {}
        	
define ["backbone"], (backbone) ->
    class User extends backbone.Model
        initialize: ->
            @on 'all', (e) ->
                console.log e 

        urlRoot: ->
            "/User/"
            
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
        	Image:
                HasImage: false
                Avatar: ''

        	Presentation: ''
        	LookingFor: {}
        	
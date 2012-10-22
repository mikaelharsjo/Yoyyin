define ["backbone"], (Backbone) ->
    class User extends Backbone.Model
        url: ->
            return "/User/Get/" + @id
            
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
        	Ideas:[]
        	Competences: []
        	Image: {}
        	Presentation: ''
        	LookingFor: {}
        	
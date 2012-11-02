define ["backbone"], (backbone) ->
	class Messages extends backbone.Collection    
        url: "/Messages/GetAll"
        initialize: ->
            @fetch()

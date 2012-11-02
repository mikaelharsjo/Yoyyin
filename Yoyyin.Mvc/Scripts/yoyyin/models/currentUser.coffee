define ["backbone"], (backbone) ->
	class CurrentUser extends backbone.Collection    
        urlRoot: "/CurrentUser"
        initialize: ->
            @on "all", (e) ->
            	console.log e

		getImageSrc: ->
			return @get("HasImage") ? "/Content/Upload/Images/" + @id + ".jpg" : "/Images/glyphicons_003_user@2x.png"

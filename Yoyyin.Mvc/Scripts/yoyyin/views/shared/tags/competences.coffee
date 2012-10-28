define ["backbone"], (backbone) ->
	class Competences extends backbone.View
		initialize: ->
			$.get("/Tagging/Competences/", (competences) =>
				@$el.tagit
					availableTags: competences)
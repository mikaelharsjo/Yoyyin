define ["backbone", "models/matching/match"], (backbone, Match) ->
	class MegaMatch extends backbone.Collection    
        url: "Matching/Mega"
        model: Match
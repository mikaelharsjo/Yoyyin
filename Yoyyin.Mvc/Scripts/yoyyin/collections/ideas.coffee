define ["backbone", "models/idea"], (backbone, Idea) ->
    class Idea extends backbone.Collection    
        url: "/Idea/All"
        model: Idea
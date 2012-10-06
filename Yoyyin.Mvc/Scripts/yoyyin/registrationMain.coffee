define 'mustache', ['../lib/mustache'], ->
    return Mustache; 
    
require.config
    baseUrl: "/Scripts/yoyyin"
    paths: 
        "underscore": "../lib/underscore"
        "backbone": "../lib/backbone"    
    'shim':    
        backbone: 
            'deps': ['jquery', 'underscore']
            'exports': 'Backbone'

require ['backbone', "routers/registrationRouter"], (backbone, Router) ->
    router = new Router()
    backbone.history.start()
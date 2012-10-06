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

$ ->
    $("#formQuickSearch").quickSearch
        $placeHolder: $("#sectionMainContent")

    $('#carousel').carousel()

require ["backbone","routers/router", "views/currentUser/dashboard", "views/currentUser/userBox", "views/currentUser/navigation", "models/currentUser"], (backbone, Router, DashboardView, UserBox, NavigationView, CurrentUserModel) ->
    currentUser = new CurrentUserModel

    currentUser.fetch
        success: ->
            userBox = new UserBox
                model: currentUser
                el: $ "#userBox"
            userBox.render

            dashboard = new DashboardView
                model: currentUser
                el: $ "#body"
            dashboard.render

            navigation = new NavigationView
                el: $ "#subMenu"
                model: currentUser
            navigation.render()

    router = new Router()
    backbone.history.start()
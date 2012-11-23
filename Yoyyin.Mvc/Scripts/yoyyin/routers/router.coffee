define ["underscore", "backbone", "mustache", "models/user", "models/currentUser", "views/users/user", "views/users/users", "views/currentUser/dashboard", "views/currentUser/inbox", "views/ideas/all", "views/currentUser/editProfile"], (_, Backbone, mustache, UserModel, CurrentUserModel, UserView, UsersView, Dashboard, Inbox, ViewOfAllIdeas, EditProfile) ->
    class Router extends Backbone.Router
        routes:
            "editProfile": "editProfile",
            "inbox": "inbox",
            "user/:id": "user",
            "users": "users",
            "dashboard": "dashboard",
            "ideas/all": "allIdeas"       

        editProfile: ->
            view = new EditProfile
                el: $ "#body"

        allIdeas: ->
            view = new ViewOfAllIdeas
                el: $ "#body"
        
        user: (id) ->
            user = new UserModel
                id: id

            view = new UserView
                model: user
                el: $ "#body"

            user.fetch()                      

        inbox: ->
            inbox = new Inbox
                el: $ '#body'        

        users: ->
            view = new UsersView
                el: $ "#body"        

        dashboard: ->
            view = new Dashboard
                el: $ "#body"
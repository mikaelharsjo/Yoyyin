define ["backbone", "views/registration/personalInfo", "views/registration/wanted", "views/registration/location", "views/registration/userType", "views/registration/userTypesNeeded", "views/registration/tags", "views/registration/upload", "views/registration/idea", "models/user"], (Backbone, PersonalInfoView, WantedView, LocationView, UserTypeView, UserTypesNeededView, TagsView, UploadView, IdeaView, User) ->
    class RegistrationRouter extends Backbone.Router
        initialize: ->
            @user = new User()

        routes:
            "personalInfo": "personalInfo",
            "wanted": "wanted",
            "location": "location",
            "userType": "userType",
            "userTypesNeeded": "userTypesNeeded",
            "tags": "tags",
            "upload": "upload",
            "idea": "idea"
        
        personalInfo: ->
            view = new PersonalInfoView()
                model: @user
            view.render()
        
        wanted: ->
            view = new WantedView
                model: @user
            view.render()
        
        location: ->
            view = new LocationView
                model: @user
            view.render()
        
        userType: ->
            view = new UserTypeView
                model: @user
            view.render()

        userTypesNeeded: ->
            view = new UserTypesNeededView
                model: @user
            view.render()

        upload: ->
            view = new UploadView
                model: @user
            view.render()

        idea: ->
            view = new IdeaView
                model: @user
            view.render()
define ["backbone", "models/userType"], (backbone, UserTypeModel) ->
    class UserTypes extends backbone.Collection    
        url: "/UserTypes"
        model: UserTypeModel
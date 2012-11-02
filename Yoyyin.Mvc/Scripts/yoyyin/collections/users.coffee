define ["backbone", "models/user"], (backbone, UserModel) ->
    class Users extends backbone.Collection    
        url: "/User/All"
        model: UserModel
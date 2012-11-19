define ["backbone", "mustache", "models/currentUser", "text!templates/shared/modal.htm", "text!templates/user/newMessage.htm", "text!templates/user/image.htm"], (backbone, mustache, CurrentUserModel, modalTemplate, newMessageTemplate, imageTemplate) ->
    class NewMessage extends backbone.View
        render: ->            
            imageMarkup = mustache.render imageTemplate,
                Src: that.model.toJSON().ProfileImageSrc
            body = mustache.render newMessageTemplate, 
                imageMarkup: imageMarkup
            markup = mustache.render(modalTemplate, 
                title: "Nytt meddelande", body: body, actionText: "Skicka" )
            $(markup).modal "show"
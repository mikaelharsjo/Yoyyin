define ["backbone", "mustache", "collections/userTypes", "text!templates/shared/userTypeRadio.htm"], (backbone, mustache, UserTypes, template) ->
    class UserTypeRadioButtonList extends backbone.View
        initialize: ->            
            @collection = new UserTypes()
            @collection.on 'reset', @render
            @collection.fetch()           
                
        render: =>
            markup = "";
            @collection.each (userType) ->            
                markup += mustache.render(template, userType.toJSON())

            @$el.html(markup);
        
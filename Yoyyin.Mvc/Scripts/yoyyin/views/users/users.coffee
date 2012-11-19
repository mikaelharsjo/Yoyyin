define ["backbone", "mustache", "collections/users", "text!templates/Shared/pageHeader.htm", "text!templates/User/container.htm", "text!templates/User/item.htm", "text!templates/Shared/competenceLabel.htm", "text!templates/User/image.htm", "text!templates/Shared/userTypeLabel.htm"], (backbone, mustache, UserCollection, pageHeaderTemplate, containerTemplate, itemTemplate, competenceTemplate, imageTemplate, userTypeLabelTemplate) ->
    class Users extends backbone.View
        initialize: ->
            @collection.on "change", @render

        render: ->
            markup = mustache.render pageHeaderTemplate, 
                Heading: "Personer"
                SubHeading: "Kanske din nästa affärspartner?"

            @collection.each (user) ->
                user = user.toJSON()
                user.CompetencesNeededMarkup = ""

                $.each user.CompetencesNeeded, (index, competence) ->
                    user.CompetencesNeededMarkup += mustache.to_html competenceTemplate, 
                        Competence: competence

                user.CompetencesMarkup = ""
                $.each user.Competences, (index, competence) ->
                    user.CompetencesMarkup += mustache.to_html competenceTemplate, 
                        Competence: competence

                user.UserType = mustache.to_html userTypeLabelTemplate, 
                    Title: user.UserType

                user.UserTypesNeededMarkup = ""
                $.each user.UserTypesNeeded, (index, userType) ->
                    user.UserTypesNeededMarkup += mustache.to_html userTypeLabelTemplate, 
                        Title: userType

                imageMarkup = mustache.render imageTemplate, 
                    Src: user.ProfileImageSrc
                user.ImageMarkup = imageMarkup
                markup += mustache.render itemTemplate, user

            markup = mustache.to_html containerTemplate, 
                items: markup
            @$el.html markup

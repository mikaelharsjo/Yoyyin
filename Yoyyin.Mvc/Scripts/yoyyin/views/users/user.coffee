define ["underscore", "backbone", "mustache", "models/user", "models/idea", "views/ideas/idea", "views/matching/dialogMatcher", "text!templates/User/image.htm", "text!templates/User/details.htm", "text!templates/Shared/idea.htm", "text!templates/Shared/userTypeLabel.htm", "text!templates/Shared/competenceLabel.htm", "text!templates/Shared/comment.htm", "views/users/newMessage"], (_, backbone, mustache, UserModel, IdeaModel, IdeaView, DialogMatcher, imageTemplate, detailsTemplate, ideaTemplate, userTypeLabelTemplate, competenceLabelTemplate, commentTemplate, NewMessage) ->
    class User extends backbone.View
        render: ->
            user = this.model.toJSON()
            user.Image = mustache.render(imageTemplate, user)

            user.IdeasMarkup = "";
            $.each(user.Ideas, (index, idea) ->
                $ideaEl = $ "<div></div>"
                model = new IdeaModel
                    idea
                var ideaView = new IdeaView
                    model: model
                    el: $ideaEl
                ideaView.render()

                user.IdeasMarkup += $ideaEl.html()

                idea.CommentsMarkup = "<div class='page-header'><h2>Kommentarer. <small>Här får man tycka vad man vill, men var snälla<small></h2></div>"
                $.each(idea.Comments, (index, comment) ->
                    idea.CommentsMarkup += mustache.render(commentTemplate, comment)

                idea.CommentsMarkup += "<button class='btn'><i class='text-icon icon-comment'></i> Lägg till kommentar</button>"
                user.IdeasMarkup += mustache.render(ideaTemplate, idea)

            markup = mustache.render(detailsTemplate, user)
            @$el.html markup

        events:
            "click button#match": "match",
            "click button#sendMessage": "sendMessage",
            "click button#addToFavorites": "addToFavorites"

        match: ->
            view = new DialogMatcher
                userId: this.model.id
        
        sendMessage: ->
            view = new NewMessage()
            view.render()
        
        addToFavorites: ->
            console.log("adding to favorites")

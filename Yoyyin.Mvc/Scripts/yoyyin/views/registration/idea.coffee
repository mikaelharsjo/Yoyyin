define ["views/registration/step", "text!templates/registration/idea.htm", "views/shared/sniCascadingDropDown"], (StepView, template, CascadingDropDownView) ->
    class Idea extends StepView
        render: ->
            @setHero({ Headline: "Sista steget - Nu vill vi höra om din affärsidé" })
            @.appendButtons({ markup: template, previousStep: "upload", nextStep: "idea" })
            $("div.form-actions").append("<a class='btn btn-warning' href='/#/register/userType'>Jag har ingen affärsidé</a>")

            view = new CascadingDropDownView({ el: $("#sniDropDowns") })
            view.render();

       	save: ->
       		idea = 
       			CompanyName: @$el.find('#companyName').val()
       			Title: @$el.find('#title').val()
       			Description: @$el.find('#description').val()
       			SniNo: $("#sniDropDowns")
       			SniHeadId: $("#sniDropDowns")
       			Funding: {}
       			SearchProfile: {}
       			Comments: []
       		@model.set("Ideas", [idea])


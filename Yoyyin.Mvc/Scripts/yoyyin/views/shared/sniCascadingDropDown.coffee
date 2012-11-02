define ["backbone", "mustache", "text!templates/shared/sniDropDowns.htm", "collections/sniHeads"], (backbone, mustache, template, SniHeads) ->
    class SniCascadingDropDown extends backbone.View
        _wireUpDropDowns: ->
            $("#heads").change ->
                items = $(this).find(":selected").data("items")
                if (items? != undefined)
                    $("#items").show().find("option").remove();

                    $.each(items, (index, item) ->
                        $option = $("<option>").text(item.Title).val(item.SniNo)
                        $("#items").append($option))

        initialize: ->
            @collection = new SniHeads()
        
        render: ->
            console.log 'todo,refactor'       
            @collection.fetch(
                success: =>
                    @.collection.each( (sniHead) ->
                        sniHead = sniHead.toJSON()
                        $option = $("<option>").text(sniHead.Title).val(sniHead.SniHeadId).data("items", sniHead.Items)
                        $("#heads").append($option)))

            @$el.html(template)
            @_wireUpDropDowns()

        getHeadVal: ->
            sniHeadVal = $('#heads').val()
            return null if sniHeadVal is ""
            sniHeadVal

        getItemVal: ->
            $('#items').val()   
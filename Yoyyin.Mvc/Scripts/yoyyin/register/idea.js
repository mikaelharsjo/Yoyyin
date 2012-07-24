define(function () {
    return {
        init: function () {
            $.get("/Sni/Heads", function (heads) {
                $.each(heads, function (index, head) {
                    var $option = $("<option>")
                                    .text(head.Title)
                                    .val(head.SniHeadId)
                                    .data("items", head.Items);
                    $("#heads").append($option);
                });

                $("#heads").change(function () {
                    var items = $(this).find(":selected").data("items");
                    if (items != undefined) {
                        $("#items")
                            .show()
                            .find("option")
                            .remove();
                        //console.log($(this).data("items"));
                        $.each(items, function(index, item) {
                            var $option = $("<option>")
                                .text(item.Title)
                                .val(item.SniNo);

                            $("#items").append($option);
                        });
                    }
                });
            });
        }
    };
});
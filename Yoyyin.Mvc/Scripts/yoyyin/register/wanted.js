define(function () {
    return {
        init: function () {
            $("#wantsFinancing").change(function () {
                $("#financing").toggle();
            });
        }
    };
});
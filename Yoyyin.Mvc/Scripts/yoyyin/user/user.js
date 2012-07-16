yoyyin.user = function () {
    var appUser = $.sammy("#sectionMainContent", function () {
        this.get("#/user/all", function (context) {
            console.log("all users");
        });
    });
} ();
$("#search").on("keyup", function () {
    var value = $(this).val().toLowerCase();
    $("#contacts *").filter(function () {
        let item = $(this).text().toLowerCase().indexOf(value) > -1;
        $(this).toggle(item);
    });
});

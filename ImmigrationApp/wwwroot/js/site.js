function ShowToaster(type, text) {
    let toasterType;
    let title;
    switch (type) {
        case 1:
        default:
            toasterType = "success";
            title = "Success";
            break;
        case 0:
            toasterType = "error";
            title = "Error!";
            break;
    }
    toasting.create({
        "title": "" + title + "",
        "text": "" + text + "",
        "type": "" + toasterType + "",
    });
}
$(function () {
    $("#category").select2({
        //theme: "classic",
        ajax: {
            url: "/Job/Gettitle",
            contentType: "application/json; charset=utf-8",
            delay: 250,
            data: function (params) {
                var query =
                {
                    term: params.term,
                };
                return query;
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
                        return {
                            id: item.id,
                            text: item.name
                        };
                    }),
                };
            },
            cache: true
        },
        placeholder: 'Search for a Category',
        minimumInputLength: 3,
        allowClear: true,
        closeOnSelect: true,
    });
});
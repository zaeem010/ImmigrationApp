$(document).ready(function () {
    //Autocomplete for citystate
    $("#citystate").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Home/GetData_1",
                data: {
                    term: request.term
                },
                success: function (data) {
                    var dataloop = [];
                    for (var i = 0; i < data.length; i++) {
                        let loop = {
                            id: data[i].cityregion,
                            label: data[i].cityregion,
                            value: data[i].cityregion,
                        };
                        dataloop.push(loop);
                    }
                    response(dataloop);
                }
            });
        },
        delay: 1,
        minLength: 2,
        select: function (event, ui) {
            //$('#SkId').val(ui.item.id);
        }
    });
})
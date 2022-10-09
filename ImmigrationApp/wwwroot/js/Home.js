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
    //Autocomplete for Jobcategory
    $("#Headline").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Home/GetData_2",
                data: {
                    term: request.term
                },
                success: function (data) {
                    debugger;
                    var dataloop = [];
                    for (var i = 0; i < data.length; i++) {
                        let loop = {
                            id: data[i].id,
                            label: data[i].title,
                            value: data[i].title,
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
        }
    });
    //Autocomplete for Jobcategory
    $("#JobCategory").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Candidate/GetCategory",
                data: {
                    term: request.term
                },
                success: function (data) {
                    var dataloop = [];
                    //headline
                    for (var i = 0; i < data.title.length; i++) {
                        let loop = {
                            id: data.title[i].title,
                            label: data.title[i].title,
                            value: data.title[i].title,
                        };
                        dataloop.push(loop);
                    }
                    //category
                    for (var i = 0; i < data.category.length; i++) {
                        let loop = {
                            id: data.category[i].id,
                            label: data.category[i].name,
                            value: data.category[i].name,
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
            debugger;
            $('#HomeDTO_category').val(ui.item.id);
        }
    });
})
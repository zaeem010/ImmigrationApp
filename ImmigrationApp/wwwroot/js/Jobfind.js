$(function () {
    $('#category, input[name="type"]').on('change', function () {
        search();
    });
    $('input[id="title"]').keyup(delay(function (e) {
        search();
    }, 100));
    $('input[id="address"]').keyup(delay(function (e) {
        search();
    }, 100));
});
function search() {
    let SearchDTO = {};
    SearchDTO.types = [];
    SearchDTO.Title = $('#title').val();
    SearchDTO.category = $('#category').val();
    SearchDTO.address = $('#address').val();
    //
    $('#types li input[type="checkbox"]:checked').each(function (i) {
        SearchDTO.types.push($(this)[0].defaultValue);
    });
    //
    debugger;
    $.ajax({
        type: "POST",
        url: '/FindJob/searchjob',
        data: SearchDTO,
        success: (res) => {
            if (res !== null && res.length !== 0) {
                $('.job-sidebar-list-single').children().remove();
                let row = '';
                for (var i = 0; i < res.length; i++) {
                    let imgpath = "/Front/no-image.png";
                    if (res[i].logoPath) {
                        imgpath = "/Upload/" + res[i].logoPath;
                    }
                    row += '<div class="sidebar-list-single">';
                    row += '<div class="top-company-list">';
                    row += '<div class="company-list-logo">';
                    row += '<a href=/JobPost/JobDetail/' + res[i].slugName + '>';
                    row += '<img src="' + imgpath + '" alt="Logo" />';
                    row += '</a>';
                    row += '</div>';
                    row += '<div class="company-list-details">';
                    row += '<h3><a href=/JobPost/JobDetail/' + res[i].slugName + '>' + res[i].title + '</a></h3>';
                    row += '<p class="company-state">';
                    row += '<i class="fa fa-map-marker"></i>';
                    if (res[i].specificAddress) {
                        row += '<span>' + res[i].city + ', ' + res[i].province + '</span>';
                    } else {
                        row += '<span>' + res[i].addressToAdvertise + '</span>';
                    }
                    row += '</p>';
                    row += '<p class="open-icon">';
                    row += '<i class="fa fa-clock-o"></i>';
                    if (res[i].dayPassed > 0) {
                        row += '<span>' + res[i].dayPassed + ' days ago</span>';
                    }
                    else if (res[i].hourPassed > 0) {
                        row += '<span>' + res[i].hourPassed + ' hours ago</span>';
                    }
                    else if (res[i].minPassed > 0) {
                        row += '<span>' + res[i].minPassed + ' minutes ago</span>';
                    }
                    else {
                        row += '<span>Posted Now</span>';
                    }
                    row += '</p>';
                    row += '<p class="varify">';
                    row += '<i class="fa fa-check"></i>';
                    switch (res[i].showBy) {
                        case "Range":
                            row += '<span>Minimum $' + res[i].minPay.toFixed().replace(/\d(?=(\d{3})+\.)/g, '$&,') + ' To Maximum $' + res[i].maxPay.toFixed().replace(/\d(?=(\d{3})+\.)/g, '$&,') + ' ' + res[i].rate + '</span>';
                            break;
                        case "Starting Amount":
                            row += '<span>Starting From $' + res[i].amount.toFixed().replace(/\d(?=(\d{3})+\.)/g, '$&,') + ' ' + res[i].rate + '</span>';
                            break;
                        case "Maximun Amount":
                            row += '<span>Maximun To $' + res[i].amount.toFixed().replace(/\d(?=(\d{3})+\.)/g, '$&,') + ' ' + res[i].rate + '</span>';
                            break;
                        case "Excat Amount":
                            row += '<span>Fixed Price $' + res[i].amount.toFixed().replace(/\d(?=(\d{3})+\.)/g, '$&,') + ' ' + res[i].rate + '</span>';
                            break;
                    }
                    row += '</p>';
                    row += '</div>';
                    row += '<div class="company-list-btn">';
                    row += '<a href="#" class="jobguru-btn">Apply Now</a>';
                    row += '</div>';
                    row += '</div>';
                    row += '</div>';
                }
                $('.job-sidebar-list-single').append(row);
            }
            else {
                $('.job-sidebar-list-single').html('<h3 class="text-danger">No record Found! please refine your search.</h3>');
            }
        }
    });
}
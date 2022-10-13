//
$(function () {
    $('#keyword, #category, #address').on('change', function () {
        search();
    });
    $(':input').delayKeyup(function () {
        search();
    }, 1000);

});
function search() {
    let SearchcanidateDTO = {};
    SearchcanidateDTO.keyword = $('#keyword').val();
    SearchcanidateDTO.category = $('#category').val();
    SearchcanidateDTO.address = $('#address').val();
    
    //
    $.ajax({
        type: "POST",
        url: '/Candidate/searchcanidate',
        data: SearchcanidateDTO,
        success: (res) => {
            if (res !== null && res.length !== 0) {
                $('.candidate-list-page').children().remove();
                let row = '';
                for (var i = 0; i < res.length; i++) {
                    row += '<div class="single-candidate-list">';
                    row += '<div class="main-comment">';
                    row += '<div class="candidate-text">';
                    row += '<div class="candidate-info">';
                    row += '<div class="candidate-title">';
                    row += '<h3><a href="/Candidate/Profile-View/' + res[i].slugName + '/' + res[i].callBy + '">' + res[i].firstName + ' ' + res[i].lastName + ' (' + res[i].headline +')</a></h3>';
                    row += '</div>';
                    row += '</div>';
                    row += '<div class="candidate-text-inner">';
                    row += '' + res[i].summary + '';
                    row += '</div>';
                    row += '<div class="candidate-text-bottom">';
                    row += '<div class="candidate-text-box">';
                    row += '<p class="company-state"><i class="fa fa-map-marker"></i> ' + res[i].city + '</p>';
                    row += '</div>';
                    row += '<div class="candidate-action">';
                    row += '<a href="/Candidate/Profile-View/' + res[i].slugName + '/' + res[i].callBy +'" class="jobguru-btn-2">view profile</a> ';
                    row += '<a href="#" class="jobguru-btn-2">Send message</a>';
                    row += '</div>';
                    row += '</div>';
                    row += '</div>';
                    row += '</div>';
                    row += '</div>';
                }
                $('.candidate-list-page').append(row);
            }
            else {
                $('.candidate-list-page').html('<h3 class="text-danger">No record Found! please refine your search.</h3>');
            }
        }
    });
}
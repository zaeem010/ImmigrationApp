$(function () {
    let SearchDTO = {};
    SearchDTO.types = [];
    SearchDTO.Title = $('#title').val();
    SearchDTO.category = $('#category').val();
    SearchDTO.datepost = $('#datepost').val();
    //
    $('#types li input[type="checkbox"]:checked').each(function (i) {
        SearchDTO.types.push($(this)[0].defaultValue);
    });

    $.ajax({
        type: "POST",
        url: '/Job/Save',
        data: Job,
        success: (res) => {
            if (res !== null) {
                if (res == "Registerd Successfully") {
                    
                }
            }
            else {
                //ShowError(res.error);
            }
        }
    });
});
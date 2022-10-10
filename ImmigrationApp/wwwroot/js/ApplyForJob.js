function myapply(val) {
    if (val =="Web Profile") {
        $.ajax({
            type: "POST",
            url: '/FindJob/Getstatus',
            data: { term: val },
            success: (res) => {
                if (res !== null) {
                    $('#profileviewer').empty();
                    $('#profileviewer').html(
                        `<label>View your web profile</label>
                                            <a href="${res}">Zaeem Khan <i class="fa fa-external-link" aria-hidden="true"></i></a>`
                    );
                }
            }
        });
    }
    else if (val == "Resume") {
        $.ajax({
            type: "POST",
            url: '/FindJob/Getstatus',
            data: { term: "val" },
            success: (res) => {
                if (res !== null) {
                    $('#profileviewer').empty();
                    $('#profileviewer').html(
                        `<label>View your resume</label>
                                            <a href="${res}">Zaeem Khan <i class="fa fa-external-link" aria-hidden="true"></i></a>`
                    );
                }
            }
        });
    }
}
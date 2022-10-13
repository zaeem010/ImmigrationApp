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
                                            <a target="_blank" href="${res.url}">${res.user.fullName} <i class="fa fa-external-link" aria-hidden="true"></i></a>`
                    );
                    $("#sub").text("Apply");
                    $("#sub").attr("disabled", false);
                }
            }
        });
    }
    if (val == "Resume") {
        $.ajax({
            type: "POST",
            url: '/FindJob/Getstatus',
            data: { term: val },
            success: (res) => {
                if (res !== null) {
                    $('#profileviewer').empty();
                    let s = "";
                    if (res.url != "") {
                         s = `<label>View your resume</label>
                                            <a target="_blank" href="${res.url}">${res.user.fullName} <i class="fa fa-external-link" aria-hidden="true"></i></a>`;
                        $("#sub").attr("disabled", false);
                        $("#sub").text("Apply");
                    }
                    if (res.url == "") {
                        s = `<label>View your resume</label>
                                             <h5 class="text-danger">No resume Found please upload your resume first and then Apply for this job..!</h5>`;
                        $("#sub").attr("disabled", true);
                        $("#sub").text("Disabled");
                    }
                    $('#profileviewer').html(s);
                }
            }
        });
    }
}
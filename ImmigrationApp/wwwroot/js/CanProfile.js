$(document).ready(function () {
    GetYear();
    //Autocomplete for skill
    $("#Skname").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Candidate/GetSkill",
                data: {
                    term: request.term
                },
                success: function (data) {
                    var dataloop = [];
                    for (var i = 0; i < data.length; i++) {
                        let loop = {
                            id: data[i].id,
                            label: data[i].name,
                            value: data[i].name,
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
    //
    $('#CustomResume_Summary').richText();
    $('#wdes').richText();
    //
    $('#educationclick').click(function () {
        $("#edclass").toggleClass("fa-plus-circle fa-minus-circle");
    });
    //
    $('#workclick').click(function () {
        $("#wclass").toggleClass("fa-plus-circle fa-minus-circle");
    });
    //
    $('#enrolled').change(function () {
        if (this.value == "true") {
            $('#tmonth').prop('disabled', true);
            $('#tyear').prop('disabled', true);
        }
        if (this.value == "false") {
            $('#tmonth').prop('disabled', false);
            $('#tyear').prop('disabled', false);
        }
    });
    //
    $('#wenrolled').change(function () {
        if (this.value == "true") {
            $('#wtmonth').prop('disabled', true);
            $('#wtyear').prop('disabled', true);
        }
        if (this.value == "false") {
            $('#wtmonth').prop('disabled', false);
            $('#wtyear').prop('disabled', false);
        }
    });
    //Remove
    $("#worktable").on("click", "#DeleteButton", function () {
        var result = confirm('Do you want to perform this action?');
        if (!result) {
            return false;
        } else {
            $(this).closest("tr").remove();

        }
    });
    //
    $("#educationtable").on("click", "#DeleteButton", function () {
        var result = confirm('Do you want to perform this action?');
        if (!result) {
            return false;
        } else {
            $(this).closest("tr").remove();

        }
    });
    $("#skilltable").on("click", "#DeleteButton", function () {
        var result = confirm('Do you want to perform this action?');
        if (!result) {
            return false;
        } else {
            $(this).closest("tr").remove();

        }
    });
});
//Get Year
function GetYear() {
    let currYear = new Date().getFullYear();
    let futureYear = currYear + 50;
    let pastYear = currYear - 50;
    let sop = '';
    for (let year = pastYear; year <= futureYear; year++) {

        sop = '<option value="' + year + '">' + year +'</option>';
        if (year === currYear) {
            sop = '<option value="' + year + '" selected>' + year + '</option>';
        }
        $('.dropdownYear').append(sop);
    }
}
//Add Education
function AddEducation() {
    let leveleducation = $('#leveleducation').val();
    let filedstudy = $('#filedstudy').val();
    let schoolname = $('#schoolname').val();
    let country = $('#country').val();
    let city = $('#city').val();
    let enrolled = $('#enrolled').val();
    let fmonth = $('#fmonth').val();
    let fyear = $('#fyear').val();
    let tmonth = $('#tmonth').val();
    let tyear = $('#tyear').val();

    if (enrolled == "true") {
        //var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        //tmonth = months[new Date().getMonth()];
        //tyear = new Date().getFullYear();
        tmonth = "Pre";
        tyear = "sent";
    }

    if (leveleducation == "") {
        ShowToaster(0, "Level Of Education is required.!");
        return false;
    }
    else if (filedstudy == "") {
        ShowToaster(0, "filed of study is required.!");
        return false;
    }
    else if (schoolname == "") {
        ShowToaster(0, "School Name is required.!");
        return false;
    }
    else if (country == "") {
        ShowToaster(0, "Country is required.!");
        return false;
    }
    else if (city == "") {
        ShowToaster(0, "City is required.!");
        return false;
    }
    else {
        //
        let table = '';
        table += '<tr>';
        table += '<td class="d-none">' + leveleducation + '</td>';
        table += '<td class="d-none">' + filedstudy + '</td>';
        table += '<td class="d-none">' + schoolname + '</td>';
        table += '<td class="d-none">' + country + '</td>';
        table += '<td class="d-none">' + city + '</td>';
        table += '<td class="d-none">' + enrolled + '</td>';
        table += '<td class="d-none">' + fmonth + '</td>';
        table += '<td class="d-none">' + fyear + '</td>';
        table += '<td class="d-none">' + tmonth + '</td>';
        table += '<td class="d-none">' + tyear + '</td>';
        table += '<td>' + leveleducation + ' in ' + filedstudy + '</td>';
        table += '<td>' + schoolname + ' - ' + city + '</td>';
        if (enrolled == "true") {
            table += '<td>' + fmonth + ' ' + fyear + ' to ' + tmonth + tyear + '</td>';
        } else {
            table += '<td>' + fmonth + ' ' + fyear + ' to ' + tmonth + ' ' + tyear + '</td>';
        }
        table += '<td><a class="btn" id="DeleteButton"><i class="fa fa-trash"></i></a></td>';
        table += '</tr>';
        $('#educationtable').append(table);
        //
        $('#leveleducation').val('');
        $('#filedstudy').val('');
        $('#schoolname').val('');
        $('#country').val();
        $('#city').val('');
        $('#enrolled').val('false');
        $('#fmonth').val('Janaury');
        $('#fyear').val(new Date().getFullYear());
        $('#tmonth').val('Janaury');
        $('#tyear').val(new Date().getFullYear());
        //
        $('#tmonth').prop('disabled', false);
        $('#tyear').prop('disabled', false);
    }
}
//Add work
function Addwork() {
    let jobtitle = $('#jobtitle').val();
    let company = $('#company').val();
    let des = $('#wdes').val();
    let country = $('#wcountry').val();
    let city = $('#wcity').val();
    let enrolled = $('#wenrolled').val();
    let fmonth = $('#wfmonth').val();
    let fyear = $('#wfyear').val();
    let tmonth = $('#wtmonth').val();
    let tyear = $('#wtyear').val();

    if (enrolled == "true") {
        tmonth = "Pre";
        tyear = "sent";
    }

    if (jobtitle == "") {
        ShowToaster(0, "job title is required.!");
        return false;
    }
    else if (company == "") {
        ShowToaster(0, "company name is required.!");
        return false;
    }
    else if (country == "") {
        ShowToaster(0, "Country is required.!");
        return false;
    }
    else if (city == "") {
        ShowToaster(0, "City is required.!");
        return false;
    }
    else {
        //
        let table = '';
        table += '<tr>';
        table += '<td class="d-none">' + jobtitle + '</td>';
        table += '<td class="d-none">' + company + '</td>';
        table += '<td class="d-none">' + country + '</td>';
        table += '<td class="d-none">' + city + '</td>';
        table += '<td class="d-none">' + enrolled + '</td>';
        table += '<td class="d-none">' + fmonth + '</td>';
        table += '<td class="d-none">' + fyear + '</td>';
        table += '<td class="d-none">' + tmonth + '</td>';
        table += '<td class="d-none">' + tyear + '</td>';
        table += '<td class="d-none">' + des + '</td>';
        table += '<td>' + jobtitle + ' in ' + company + '</td>';
        table += '<td>' + company + ' - ' + city + '</td>';
        if (enrolled == "true") {
            table += '<td>' + fmonth + ' ' + fyear + ' to ' + tmonth + tyear + '</td>';
        } else {
            table += '<td>' + fmonth + ' ' + fyear + ' to ' + tmonth + ' ' + tyear + '</td>';
        }
        table += '<td>' + des + '</td>';
        table += '<td><a class="btn" id="DeleteButton"><i class="fa fa-trash"></i></a></td>';
        table += '</tr>';
        $('#worktable').append(table);
        //
        $('#jobtitle').val('');
        $('#company').val('');
        $('#wcountry').val();
        $('#wcity').val('');
        $('#wenrolled').val('false');
        $('#wfmonth').val('Janaury');
        $('#wfyear').val(new Date().getFullYear());
        $('#wtmonth').val('Janaury');
        $('#wtyear').val(new Date().getFullYear());
        $('#wdes').val('').trigger('change');
        //
        $('#wtmonth').prop('disabled', false);
        $('#wtyear').prop('disabled', false);
    }
}
//Add Skill
function AddSkill() {
    let Skname = $('#Skname').val();
    let Sklevel = $('#Sklevel').val();
    if (Skname == "") {
        ShowToaster(0, "Skill is required.!");
        return false;
    }
    else {
        //
        let table = '';
        table += '<tr>';
        table += '<td>' + Skname + '</td>';
        table += '<td>' + Sklevel + '</td>';
        table += '<td><a class="btn" id="DeleteButton"><i class="fa fa-trash"></i></a></td>';
        table += '</tr>';
        $('#skilltable').append(table);
        //
        $('#Skname').val('');
        $('#Sklevel').val('Standard');
    }
}
//Update Profile
function Updateprofile() {
    let CustomResume = {};
    CustomResume.ResumeEducationList = [];
    CustomResume.ResumeExperienceList = [];
    CustomResume.ResumeLanguageChildList = [];
    CustomResume.ResumeLinkChildList = [];
    CustomResume.ResumeSkillChildList = [];
    //
    CustomResume.Id = $('#CustomResume_Id').val();
    CustomResume.Email = $('#CustomResume_Email').val();
    CustomResume.SlugName = $('#CustomResume_SlugName').val();
    //
    CustomResume.FirstName = $('#CustomResume_FirstName').val();
    CustomResume.LastName = $('#CustomResume_LastName').val();
    CustomResume.Country = $('#CustomResume_Country').val();
    CustomResume.City = $('#CustomResume_City').val();
    CustomResume.Street = $('#CustomResume_Street').val();
    CustomResume.PostalCode = $('#CustomResume_PostalCode').val();
    CustomResume.Headline = $('#CustomResume_Headline').val();
    CustomResume.PhoneNumber = $('#CustomResume_PhoneNumber').val();
    CustomResume.Summary = $('#CustomResume_Summary').val();
    CustomResume.Relocate = $('#CustomResume_Relocate').val();
    CustomResume.ShowtoPublic = $('#CustomResume_ShowtoPublic').val();
    CustomResume.UserId = $('#CustomResume_UserId').val();
    CustomResume.ResumeUrlPath = $('#CustomResume_ResumeUrlPath').val();

    //table skill table
    $('#skilltable tbody tr').each((index, elem) => {
        $tr = $(elem);
        // check for empty row
        if ($tr.find('td').length > 1) {
            const data = {
                Id: 0,
                CustomResumeId: CustomResume.Id,
                SkillName: $tr.find("td:eq(0)").text(),
                SkillLevel: $tr.find("td:eq(1)").text(),
            }
            CustomResume.ResumeSkillChildList.push(data);
        }
    });
    //table ResumeEducationList
    $('#educationtable tbody tr').each((index, elem) => {
        $tr = $(elem);
        // check for empty row
        if ($tr.find('td').length > 1) {
            const data = {
                Id: 0,
                CustomResumeId: CustomResume.Id,
                LevelofEducation: $tr.find("td:eq(0)").text(),
                FieldofStudy: $tr.find("td:eq(1)").text(),
                SchoolName: $tr.find("td:eq(2)").text(),
                StudyCountry: $tr.find("td:eq(3)").text(),
                StudyCity: $tr.find("td:eq(4)").text(),
                CurrentlyEnrolled: $tr.find("td:eq(5)").text(),
                FromYear: $tr.find("td:eq(6)").text(),
                FromMonth: $tr.find("td:eq(7)").text(),
                ToYear: $tr.find("td:eq(9)").text(),
                ToMonth: $tr.find("td:eq(8)").text(),
            }
            CustomResume.ResumeEducationList.push(data);
        }
    });

    //table ResumeExperienceList
    $('#worktable tbody tr').each((index, elem) => {
        $tr = $(elem);
        // check for empty row
        if ($tr.find('td').length > 1) {
            const data = {
                Id: 0,
                CustomResumeId: CustomResume.Id,
                JobTitle: $tr.find("td:eq(0)").text(),
                Company: $tr.find("td:eq(1)").text(),
                JobCountry: $tr.find("td:eq(2)").text(),
                JobCity: $tr.find("td:eq(3)").text(),
                CurrentlyEnrolled: $tr.find("td:eq(4)").text(),
                FromYear: $tr.find("td:eq(5)").text(),
                FromMonth: $tr.find("td:eq(6)").text(),
                ToYear: $tr.find("td:eq(8)").text(),
                ToMonth: $tr.find("td:eq(7)").text(),
                Description: $tr.find("td:eq(9)").html(),
            }
            CustomResume.ResumeExperienceList.push(data);
        }
    });
    var _customResume = new FormData();
    const resumeurlpath = document.getElementById("w_screen").files[0];
    if (resumeurlpath != undefined) {
        _customResume.append("candidaterequest", resumeurlpath);
    }
    _customResume.append("candidaterequest", JSON.stringify(CustomResume));
    //Post/Update
    $.ajax({
        url: '/Candidate/Update',
        type: "POST",
        contentType: false,
        processData: false,
        data: _customResume,
        dataType: "json",
        success: (res) => {
            if (res !== null) {
                if (res == "Updated Successfully") {
                    ShowToaster(1, "Updated Job Successfully .!");
                    setTimeout(function () {
                        window.location.reload();
                    }, 1500);
                }
            }
            else {
                //ShowError(res.error);
            }
        }
    });
}
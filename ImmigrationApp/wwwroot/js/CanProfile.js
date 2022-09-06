$(document).ready(function () {
    GetYear();
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
});
//GetYear
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
//AddEducation
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
        var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        tmonth = months[new Date().getMonth()];
        tyear = new Date().getFullYear();
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
        table += '<td>' + fmonth + ' ' + fyear + ' to ' + tmonth + ' ' + tyear + '</td>';
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
        $('#fyear').val('2022');
        $('#tmonth').val('Janaury');
        $('#tyear').val('2022');
        //
        $('#tmonth').prop('disabled', false);
        $('#tyear').prop('disabled', false);
    }
}
//Addwork
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
        var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        tmonth = months[new Date().getMonth()];
        tyear = new Date().getFullYear();
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
        table += '<td>' + fmonth + ' ' + fyear + ' to ' + tmonth + ' ' + tyear + '</td>';
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
        $('#wfyear').val('2022');
        $('#wtmonth').val('Janaury');
        $('#wtyear').val('2022');
        $('#wdes').val('').trigger('change');
        //
        $('#wtmonth').prop('disabled', false);
        $('#wtyear').prop('disabled', false);
    }
}
// 
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
                ToYear: $tr.find("td:eq(8)").text(),
                ToMonth: $tr.find("td:eq(9)").text(),
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
                ToYear: $tr.find("td:eq(7)").text(),
                ToMonth: $tr.find("td:eq(8)").text(),
                Description: $tr.find("td:eq(9)").text(),
            }
            CustomResume.ResumeExperienceList.push(data);
        }
    });
    //Post/Update
    $.ajax({
        type: "POST",
        url: '/Candidate/Update',
        data: CustomResume,
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
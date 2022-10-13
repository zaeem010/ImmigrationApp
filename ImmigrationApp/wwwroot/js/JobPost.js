$(function () {
    $("#jobcategroy").select2({
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
    jobcategory($('.categorytext').text());
    ///
    $("#Job_Street1").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/GoogleApi/Addressautocomplete",
                data: {
                    term: request.term
                },
                success: function (data) {
                    debugger;
                    var dataloop = [];
                    if (data.status ==="OK") {
                        for (var i = 0; i < data.predictions.length; i++) {
                            let loop = {
                                id: data.predictions[i].description,
                                label: data.predictions[i].description,
                                value: data.predictions[i].description,
                            };
                            dataloop.push(loop);
                        }
                    } else {
                        let loop = {
                            id: "no record found...!",
                            label: "no record found...!",
                            value: "no record found...!",
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
    $("#Job_City").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/GoogleApi/Cityautocomplete",
                    data: {
                        term: request.term
                    },
                    success: function (data) {
                        var dataloop = [];
                        for (var i = 0; i < data.length; i++) {
                            let loop = {
                                id: data[i].city,
                                label: data[i].city,
                                value: data[i].city,
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
    $("#Job_Province").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/GoogleApi/Provinceautocomplete",
                    data: {
                        term: request.term
                    },
                    success: function (data) {
                        var dataloop = [];
                        for (var i = 0; i < data.length; i++) {
                            let loop = {
                                id: data[i].countrycode,
                                label: data[i].region,
                                value: data[i].countrycode,
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
    //
});
function jobcategory(val)
{
    $('.jobcategory').html('');
    if (val.trim() !== "" && val !== undefined)
    {
        $('.jobcategory').html('<span>' + val + '</span>&nbsp;<a onclick="jobcategory()"><i class="fa fa-times"></i></a>');
    }
}
$(document).ready(function () {
    $('#SpecificAddress').hide();
    $('#NoSpecificAddress').hide();
    $('#excatpay').hide();
    $('#Job_StartDate').prop('disabled', true);
    $('#Job_DeadlineDate').prop('disabled', true);
    $('#Job_Description').richText();
    //
    SpecificAddress($('#Job_SpecificAddress').val());
    PlanedstartDate($('#Job_PlanedstartDate').val());
    Deadline($('#Job_Deadline').val());
    ShowPayby($('#Job_ShowPayby').val());
    //Speicfy Address
    $('#Job_SpecificAddress').change(function (e) {
        SpecificAddress(this.value);
    });
    //PlanedstartDate
    $('#Job_PlanedstartDate').change(function (e) {
        PlanedstartDate(this.value);
    });
    //DeadlineDate
    $('#Job_Deadline').change(function (e) {
        Deadline(this.value);
    });
    //ShowPayby
    $('#Job_ShowPayby').bind('load change', function () {
        ShowPayby(this.value);
    });
});
function ShowPayby(val) {
    if (val == "Range") {
        $('#excatpay').hide();
        $('#PayRange').show();
        $('#PayRange1').show();
    }
    else {
        $('#excatpay').show();
        $('#PayRange').hide();
        $('#PayRange1').hide();
    }
}
function Deadline(val) {
    if (val == "true") {
        $('#Job_DeadlineDate').prop('disabled', false);
    }
    else if (val == "false") {
        $('#Job_DeadlineDate').prop('disabled', true);
        $('#Job_DeadlineDate').val('');
    }
}
function PlanedstartDate(val)
{
    if (val == "true") {
        $('#Job_StartDate').prop('disabled', false);
    }
    else if (val == "false") {
        $('#Job_StartDate').prop('disabled', true);
        $('#Job_StartDate').val('');
    }
}
function SpecificAddress(val)
{
    if (val == "") {
        $('#SpecificAddress').hide();
        $('#NoSpecificAddress').hide();
    }
    else if (val == "true") {
        $('#SpecificAddress').show();
        $('#NoSpecificAddress').hide();
        //$('#Job_Street').val('');
        //$('#Job_Province').val('');
        //$('#Job_City').val('');
        //$('#Job_PostalCode').val('');
    }
    else if (val == "false") {
        $('#SpecificAddress').hide();
        $('#NoSpecificAddress').show();
        //$('#Job_AddressToAdvertise').val('');
    }
}
function SaveJob()
{
    let Job = {};
    Job.JobScheduleChildList = [];
    Job.SupplementalPayChildList = [];
    Job.BenefitOfferedChildList = [];
    Job.JobTypeChildList = [];
    //
    Job.Id = $('#Job_Id').val()|| 0;
    Job.CallBy = $('#Job_CallBy').val();
    Job.Title = $('#Title_Category').val() || "";
    Job.SpecificAddress = $('#Job_SpecificAddress').val() || "";

    Job.PlanedstartDate = $('#Job_PlanedstartDate').val() || "";
    Job.Numberofvaccant = $('#Job_Numberofvaccant').val() || "";
    Job.HireSpeed = $('#Job_HireSpeed').val() || "";
    Job.ShowPayby = $('#Job_ShowPayby').val() || "";
    Job.Rate = $('#Job_Rate').val() || "";
    Job.Description = $('#Job_Description').val() || "";
    Job.ResumeSubmit = $('#Job_ResumeSubmit').val() || "";
    Job.Deadline = $('#Job_Deadline').val() || "";
    Job.Latitude = $('#Job_Latitude').val() || 0;
    Job.Longitude = $('#Job_Longitude').val() || 0;
    Job.UserId = $('#UserId').val();
    Job.CompanyInfoId = $('#CompanyId').val();
    Job.JobSubCategoryId = $('#Job_JobSubCategoryId').val();
    Job.PostDateTime = $('#Job_PostDateTime').val();
    Job.Verify = $('#Job_Verify').val();
    //Condition Values
    //1
    Job.Street =  "";
    Job.City =  "";
    Job.Province =  "";
    Job.PostalCode =  "";
    //2
    Job.AddressToAdvertise =  "";
    //3
    Job.StartDate = "";
    //4
    Job.MinPay = 0;
    Job.MaxPay = 0;
    //5
    Job.Amount = 0;
    //6
    Job.DeadlineDate = "";
    //Condition Values End
    //
    if (Job.SpecificAddress == "true")
    {
        Job.Street = $('#Job_Street').val() || "";
        Job.City = $('#Job_City').val() || "";
        Job.Province = $('#Job_Province').val() || "";
        Job.PostalCode = $('#Job_PostalCode').val() || "";
    }
    if (Job.SpecificAddress == "false") {
        Job.AddressToAdvertise = $('#Job_AddressToAdvertise').val() || "";
    }
    //
    if (Job.PlanedstartDate) {
        Job.StartDate = $('#Job_StartDate').val() || "";
    }
    //
    if (Job.ShowPayby == "Range") {
        Job.MinPay = $('#Job_MinPay').val() || "";
        Job.MaxPay = $('#Job_MaxPay').val() || "";
    }
    else
    {
        Job.Amount = $('#Job_Amount').val() || "";
    }
    //
    if (Job.Deadline == "true") {
        Job.DeadlineDate = $('#Job_DeadlineDate').val() || "";
    }
    $('#Jobtype li input[type="checkbox"]:checked').each(function (i) {
        const type = {
            JobId: Job.Id,
            JobTypeId: $(this)[0].defaultValue
        };
        Job.JobTypeChildList.push(type);
    });
    $('#JobSchedule li input[type="checkbox"]:checked').each(function (i) {
        const type = {
            JobId: Job.Id,
            JobScheduleId: $(this)[0].defaultValue
        };
        Job.JobScheduleChildList.push(type);
    });
    $('#JobSupp li input[type="checkbox"]:checked').each(function (i) {
        const type = {
            JobId: Job.Id,
            SupplementalPayId: $(this)[0].defaultValue
        };
        Job.SupplementalPayChildList.push(type);
    });
    $('#JobBenefit li input[type="checkbox"]:checked').each(function (i) {
        const type = {
            JobId: Job.Id,
            BenefitOfferedId: $(this)[0].defaultValue
        };
        Job.BenefitOfferedChildList.push(type);
    });
    $.ajax({
        type: "POST",
        url: '/Job/Save',
        data: Job,
        success: (res) => {
            if (res !== null) {
                if (res == "Registerd Successfully") {
                    ShowToaster(1, "Posted Job Successfully please wait to get your job Verified .!");
                    setTimeout(function () {
                        window.location.replace('/Job/Manage-Jobs');
                    }, 1500);
                }
                if (res == "Updated Successfully"){
                    ShowToaster(1, "Updated Job Successfully .!");
                    setTimeout(function () {
                        window.location.replace('/Job/Manage-Jobs');
                    }, 1500);
                }
            }
            else {
                //ShowError(res.error);
            }
        }
    });
}
﻿$(document).ready(function () {
    $('#SpecificAddress').hide();
    $('#NoSpecificAddress').hide();
    $('#excatpay').hide();
    $('#Job_StartDate').prop('disabled', true);
    $('#Job_DeadlineDate').prop('disabled', true);
    $('#Job_Description').richText();
    //Speicfy Address
    $('#Job_SpecificAddress').change(function (e) {
        if (this.value == "")
        {
            $('#SpecificAddress').hide();
            $('#NoSpecificAddress').hide();
        }
        else if (this.value == "true")
        {
            $('#SpecificAddress').show();
            $('#NoSpecificAddress').hide();
        }
        else if (this.value == "false")
        {
            $('#SpecificAddress').hide();
            $('#NoSpecificAddress').show();
        }
    });
    //PlanedstartDate
    $('#Job_PlanedstartDate').change(function (e) {
        if (this.value == "true")
        {
            $('#Job_StartDate').prop('disabled', false);
        }
        else if (this.value == "false")
        {
            $('#Job_StartDate').prop('disabled', true);
            $('#Job_StartDate').val('');
        }
    });
    //DeadlineDate
    $('#Job_Deadline').change(function (e) {
        if (this.value == "true")
        {
            $('#Job_DeadlineDate').prop('disabled', false);
        }
        else if (this.value == "false")
        {
            $('#Job_DeadlineDate').prop('disabled', true);
            $('#Job_DeadlineDate').val('');
        }
    });
    //ShowPayby
    $('#Job_ShowPayby').bind('load change', function () {
        debugger;
        if (this.value == "Range")
        {
            $('#excatpay').hide();
            $('#PayRange').show();
            $('#PayRange1').show();
        }
        else
        {
            $('#excatpay').show();
            $('#PayRange').hide();
            $('#PayRange1').hide();
        }
    });
});
function SaveJob()
{
    let Job = {};
    Job.JobScheduleChildList = [];
    Job.SupplementalPayChildList = [];
    Job.BenefitOfferedChildList = [];
    Job.JobTypeChildList = [];
    //
    Job.Id = $('#Job_Id').val()|| 0;
    Job.Title = $('#Job_Title').val() || "";
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
    Job.DeadlineDate = $('#Job_DeadlineDate').val() || "";
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
                        location.reload();
                    }, 1500);
                }
                if (res == "Updated Successfully"){
                    ShowToaster(1, "Updated Job Successfully .!");
                    setTimeout(function () {
                        location.reload();
                    }, 1500);
                }
            }
            else {
                //ShowError(res.error);
            }
        }
    });
}
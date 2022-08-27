$(document).ready(function () {
    $('#SpecificAddress').hide();
    $('#NoSpecificAddress').hide();
    $('#excatpay').hide();
    $('#Job_StartDate').prop('disabled', true);
    $('#Job_DeadlineDate').prop('disabled', true);

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
    $('#Job_ShowPayby').change(function (e) {
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
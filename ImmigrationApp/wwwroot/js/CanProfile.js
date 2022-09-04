$(document).ready(function () {
    GetYear();

});
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
    //
    let table = '';
    table += '<tr>';
    table += '<td class="d-none">' + leveleducation + '</td>';
    table += '<td class="d-none">' + filedstudy + '</td>';
    table += '<td class="d-none">' + schoolname + '</td>';
    table += '<td class="d-none">' + country + '</td>';
    table += '<td class="d-none">' + city + '</td>';
    table += '<td class="d-none">' + fmonth + '</td>';
    table += '<td class="d-none">' + fyear + '</td>';
    table += '<td class="d-none">' + tmonth + '</td>';
    table += '<td class="d-none">' + tyear + '</td>';
    table += '<td>' + leveleducation + ' in ' + filedstudy + '</td>';
    table += '<td>' + schoolname + ' - ' + city + '</td>';
    table += '<td>' + fmonth + ' ' + fyear + ' to ' + tmonth + ' ' + tyear + '</td>';
    table += '<td><a class="btn"><i class="fa fa-edit"></i></a></td>';
    table += '</tr>';
    $('#educationtable').append(table);
}

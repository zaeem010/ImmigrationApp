
$(document).ready(function () {
    //-------------------------------SELECT CASCADING-------------------------//
    var selectedCountry = selectedRegion = selectedCity = countryCode = "";

    // This is a demo API key for testing purposes. You should rather request your API key (free) from http://battuta.medunes.net/
    var BATTUTA_KEY = "fe5215a664e57945dcc0b74ea7a7faa2";
    // Populate country select box from battuta API
    url =
        "https://battuta.medunes.net/api/country/all/?key=" +
        BATTUTA_KEY +
        "&callback=?";

    // EXTRACT JSON DATA.
    $.getJSON(url, function (data) {
        console.log(data);
        $.each(data, function (index, value) {
            // APPEND OR INSERT DATA TO SELECT ELEMENT. Set the country code in the id section rather than in the value.
            $("#country").append(
                '<option id="' + value.code + '" value="' + value.name + '">' + value.name + "</option>"
            );
        });
    });
    // Country selected --> update region list .
    $("#country").change(function () {
        selectedCountry = this.options[this.selectedIndex].text;
        countryCode = $(this).children(":selected").attr("id");
        url =
            "https://battuta.medunes.net/api/region/" +
            countryCode +
            "/all/?key=" +
            BATTUTA_KEY +
            "&callback=?";
        debugger;
        $.getJSON(url, function (data) {
            $("#region option").remove();
            let _states = [];
            $.each(data, function (index, value) {
                const dat = {
                    region: value.region,
                    countrycode: countryCode
                }
                _states.push(dat);
                $("#region").append(
                    '<option value="' + value.region + '">' + value.region + "</option>"
                );
                // APPEND OR INSERT DATA TO SELECT ELEMENT.
            });
            var _savestate = new FormData();
            _savestate.append("myRequest", JSON.stringify(_states));
            //$.ajax({
            //    url: '/Home/GetStates',
            //    type: "POST",
            //    contentType: false,
            //    processData: false,
            //    data: _savestate,
            //    dataType: "json",
            //    success: (data) => {
            //        if (data !== null) {
                        
            //        }
            //    }
            //});
            //
        });
    });
    // Region selected --> updated city list
    $("#region").on("change", function () {
        selectedRegion = this.options[this.selectedIndex].text;
        // Populate country select box from battuta API
        region = $("#region").val();
        url =
            "https://battuta.medunes.net/api/city/" +
            countryCode +
            "/search/?region=" +
            region +
            "&key=" +
            BATTUTA_KEY +
            "&callback=?";
        $.getJSON(url, function (data) {
            console.log(data);
            $("#city option").remove();
            debugger;
            let mycity = [];

            $.each(data, function (index, value) {
                const dat = {
                    cityregion: `${value.city},${value.region}`,
                    city: value.city,
                    region: value.region,
                    countrycode: countryCode,
                    latitude: value.latitude,
                    longitude: value.longitude,
                }
                mycity.push(dat);
                // APPEND OR INSERT DATA TO SELECT ELEMENT.
                $("#city").append(
                    '<option value="' + value.city + '">' + value.city + "</option>"
                );
            });
            var _savecity = new FormData();
            _savecity.append("myRequest", JSON.stringify(mycity));
            $.ajax({
                url: '/Home/Getcity',
                type: "POST",
                contentType: false,
                processData: false,
                data: _savecity,
                dataType: "json",
                success: (data) => {
                    if (data !== null) {

                    }
                }
            });
        });
    });
    // city selected --> update location string
    $("#city").on("change", function () {
        selectedCity = this.options[this.selectedIndex].text;
        $("#location").html(
            "Locatation: Country: " +
            selectedCountry +
            ", Region: " +
            selectedRegion +
            ", City: " +
            selectedCity
        );
    });
});

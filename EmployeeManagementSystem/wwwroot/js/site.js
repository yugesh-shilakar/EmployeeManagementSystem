﻿$(document).ready(function () {

    AjaxCall('/Employee/GetCityByDistrictId', null).done(function (response) {
        if (response.cityList.length > 0) {
            $('#districtDropdown').html('');
            var options = '';
            options += '<option value="">Select</option>';
            for (var i = 0; i < response.length; i++) {
                options += '<option value="' + response.cityList[i].id + '">' + response.cityList[i].name + '</option>';
            }
            $('#districtDropdown').append(options);

        }
    }).fail(function (error) {
        alert(error.StatusText);
    });

});
$('#districtDropdown').on("change", function () {
    debugger;
    var district = $('#districtDropdown').val();
    var obj = { district: district };
    AjaxCall('/Employee/GetCityByDistrictId', obj, 'POST').done(function (response) { 
        if (response.cityList.length > 0) {
            $('#cityDropdown').html('');
            var options = '';
            options += '<option value="Select">Select</option>';
            for (var i = 0; i < response.cityList.length; i++) {
                options += '<option value="' + response.cityList[i].id + '">' + response.cityList[i].name + '</option>';
            }
            $('#cityDropdown').append(options);
        }
    }).fail(function (error) {
        alert(error.StatusText);
    });
});
function AjaxCall(url, data, type) {
    return $.ajax({
        url: url,
        type: type ? type : 'GET',
        data: data,
    });
}
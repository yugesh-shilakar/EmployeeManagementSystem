$(document).ready(function () {

   

});

$('#districtDropdown').on("change", function () {
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

var cityId = $('#city').val();
var object = { district: $('#districtDropdown').val() };
AjaxCall('/Employee/GetCityByDistrictId', object, 'POST').done(function (response) {
    if (response.cityList.length > 0) {
        $('#cityDropdown').html('');
        var options = '';
        options += '<option value="Select">Select</option>';
        for (var i = 0; i < response.cityList.length; i++) {
            if (response.cityList[i].id == cityId) {
                options += '<option value="' + response.cityList[i].id + '"selected>' + response.cityList[i].name + '</option>';

            }
            else {
                options += '<option value="' + response.cityList[i].id + '">' + response.cityList[i].name + '</option>';

            }
        }
        $('#cityDropdown').append(options);
    }
}).fail(function (error) {
    alert(error.StatusText);
});
function AjaxCall(url, data, type) {
    return $.ajax({
        url: url,
        type: type ? type : 'GET',
        data: data,
    });
}
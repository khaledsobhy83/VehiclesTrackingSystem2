window.onload = maxWindow;

function maxWindow() {
    window.moveTo(0, 0);


    if (document.all) {
        top.window.resizeTo(screen.availWidth, screen.availHeight);
    }

    else if (document.layers || document.getElementById) {
        if (top.window.outerHeight < screen.availHeight || top.window.outerWidth < screen.availWidth) {
            top.window.outerHeight = screen.availHeight;
            top.window.outerWidth = screen.availWidth;
        }
    }
}
function OnCustomerChanged(selectedValue) {

    searchVehicles();
}
function getServiceUrl() {

    var statusId = getSelectedStatus();
    
    var customerId = $("#DDlCustomers :selected").val();

    var serviceURL = 'http://localhost:17645/API/Vehicle/Get';

    if (statusId > 0 && customerId > 0) {

        serviceURL = 'http://localhost:17645/API/Vehicle/SearchVehicles?customerId=' + customerId + '&status=' + statusId
    }
    else if (customerId > 0) {

        serviceURL = 'http://localhost:17645/API/Vehicle/GetByCustomer/' + customerId
    }
    else if (statusId > 0) {

        serviceURL = 'http://localhost:17645/API/Vehicle/GetByStatus/' + statusId
    }
    else {
        serviceURL = 'http://localhost:17645/API/Vehicle/Get';
    }
    return serviceURL;
}
function searchVehicles() {

    
    var serviceURL = getServiceUrl();

    $.ajax({
        type: 'GET',
        url: serviceURL
    }).done(function (result) {

        $("#tblVehicles").jqGrid("clearGridData", true)

        $("#tblVehicles").jqGrid('setGridParam', { data: result });
        
        $("#tblVehicles").trigger("reloadGrid");

    }).error(function (jqXHR, textStatus, errorThrown) {

        alert(jqXHR.responseText || textStatus);
    });
}


function GetAllVehciles() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:17645/API/Vehicle/Get'
    }).done(function (data) {
        displayResults(data);
    }).error(function (jqXHR, textStatus, errorThrown) {
        alert(jqXHR.responseText || textStatus);
    });
}
function GetCustomersList() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:17645/API/Customer/Get'
    }).done(function (data) {

        var options = "";

        options = "<option value='-1'>All</option>";

        $.each(data, function (a, b) {
            options += "<option value='" + b.CustomerId + "'>" + b.CustomerName + "</option>";
        });

        $("#DDlCustomers").html(options);

    }).error(function (jqXHR, textStatus, errorThrown) {
        alert(jqXHR.responseText || textStatus);
    });
}


function displayResults(vlist) {

    jQuery("#tblVehicles").jqGrid({
        
        datastr: vlist,
        datatype: "jsonstring",
        jsonReader: { repeatitems: false },
        height: 'auto',
        gridview: true,
        colNames: ['Customer Name', 'Registration No', 'Vehicle Id', 'Vehicle Status'],
        colModel: [
        { name: 'CustomerName', index: 'CustomerName', width: 150, stype: 'text' },
        { name: 'RegistrationNo', index: 'RegistrationNo', width: 150 },
        { name: 'VehicleId', index: 'VehicleId', width: 150 },
           { name: 'VehicleStatus', index: 'VehicleStatus', width: 150}
        ],
        viewrecords: true,
        rowNum: 10,
        sortname: 'CustomerName',
        viewrecords: true,
        sortorder: "desc",
        caption: ""
    });
}

function getSelectedStatus() {

    var status = $('input[name=group1]:checked').val();
    
    return status;
}

$(document).ready(function () {

    GetCustomersList();

    GetAllVehciles();

    $("#rdOnline").click(function (e) {
        searchVehicles();
    });
    $("#rdOffline").click(function (e) {
        searchVehicles();
    });
    $("#rdAll").click(function (e) {
        searchVehicles();
    });
    $('#DDlCustomers').on('change', function () {
        OnCustomerChanged(this.value);
    })
    //var myVar = setInterval(function () { myTimer() }, 6000);
    //function myTimer() {
    //    var status = getSelectedStatus();

    //    if (status == -1)
    //        searchVehicles(0, 0);
    //    else
    //        searchVehicles(1, status);
    //}
});
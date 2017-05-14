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
    searchVehicles(2, selectedValue);
}

function getServiceUrl(type, paramaterValue) {
    var serviceURL = 'http://localhost:17645/API/Vehicle/Get';

    if (type == 1) {

        serviceURL = 'http://localhost:17645/API/Vehicle/GetByStatus/' + paramaterValue
    }
    else if (type == 2) {

        serviceURL = 'http://localhost:17645/API/Vehicle/GetByCustomer/' + paramaterValue
    }
    return serviceURL;
}
function searchVehicles(type, paramaterValue) {

    var serviceURL = getServiceUrl(type, paramaterValue);

    $.ajax({
        type: 'GET',
        url: serviceURL
    }).done(function (result) {
        console.log(result.length);
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
        console.log(data.length);
        displayResults(data);
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
function getSelectedStatus(){
    var status = $('input[name=group1]:checked').val();
    
    return status;
}
$(document).ready(function () {

    GetAllVehciles();

    $("#rdOnline").click(function (e) {
        searchVehicles(1,0);
    });
    $("#rdOffline").click(function (e) {
        searchVehicles(1, 1);
    });
    $("#rdAll").click(function (e) {
        searchVehicles(0, 0);
    });

    //var myVar = setInterval(function () { myTimer() }, 6000);
    //function myTimer() {
    //    var status = getSelectedStatus();

    //    if (status == -1)
    //        searchVehicles(0, 0);
    //    else
    //        searchVehicles(1, status);
    //}
});
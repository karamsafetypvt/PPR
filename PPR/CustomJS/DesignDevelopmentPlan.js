/*const { Toast } = require("bootstrap");*/

var getid = 0;
$(document).ready(function () {
    var getQueryString = function (field, url) {
        var href = url ? url : window.location.href;
        var reg = new RegExp('[?&]' + field + '=([^&#]*)', 'i');
        var string = reg.exec(href);
        return string ? string[1] : null;
    };
     getid = getQueryString('ProjectID');
})

function ShowDevelopmentsheet(ActivityID, PlanID,ActivityName) {
    if (PlanID == '0') {
        alert('To click this option need to Save form first time.')
        return;
    }
    $("#partialDiv1").empty();
    $.ajax(
        {
            type: 'Get',
            url: '/DesignDevelopmetPlan/ShowDevelopmentsheet?ActivityID=' + ActivityID + '&ProjectID=' + getid,
            success:
                function (response) {
                    $("#partialDiv1").append(response);
                    $('#myModal1').modal('show');
                    $("#PlanID").val(PlanID);
                    $("#ProjectID").val(getid);
                    $("#ActivityID").val(ActivityID);
                    $("#HeaderName1").text('Development Sheet - '+ActivityName);
                },
            error:
                function (response) {
                    alert("Error: " + response);

                }
        });
}

function GetData(PageName, Modelname, PlanID,CompletionDate) {
    if (PlanID == '0') {
        alert('To click this option need to Save form first time.')
        return;
    }
    $("#partialDiv").empty();
    $.ajax(
        {
            type: 'Get',
            url: '/DesignDevelopmetPlan/DesignDataSheet?PageName=_' + PageName + '&ProjectID=' + getid + '&PlanID=' + PlanID + '&CompletionDate=' + CompletionDate,
            success:
                function (response) {
                    $("#partialDiv").empty();
                    $("#partialDiv").append(response);
                    $("#HeaderName").html(Modelname);
                    $('#myModal').modal('show');
                    $("#PlanID").val(PlanID);
                    $("#ProjectID").val(getid);
                },
            error:
                function (response) {
                    alert("Error: " + response);
                  
                }
        });
}
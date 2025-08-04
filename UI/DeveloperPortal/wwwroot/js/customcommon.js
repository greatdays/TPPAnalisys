/* Function LoadPartialView
 *** This function is used for load partial view in div.***
--------------------------------------------------------------------------------------------------------------------------*/
function LoadPartialView(actionPath, parameter, containerName) {
    AjaxCommunication.CreateRequest(this.window, "GET", actionPath, 'html', parameter,
        function (data) {
            $(containerName).html(data);
        },
        function (xhr, status) {
            alert(status);
        }, true, null, false);
}

/* Function LoadPopUpPartialView
***This function is used for load partial view in popUp div.*** 
--------------------------------------------------------------------------------------------------------------------------*/
function LoadPopUpPartialView(actionPath, parameter, containerName) {
    AjaxCommunication.CreateRequest(this.window, "GET", actionPath, 'html', parameter,
        function (data) {
            $(containerName).html(data).modal('show');
            return false;
        },
        function (xhr, status) {
            alert(status);
        }, true, null, false);
}
/* Function LoadTabData
*** This function is used for load data table.***
--------------------------------------------------------------------------------------------------------------------------*/

function LoadTabData(url, tabId, forceLoad = false) {
    if ($("#" + tabId).html() == "" || forceLoad) {
        AjaxCommunication.CreateRequest(this.window, "GET", url, "", null,
            function (result) {
                $("#" + tabId).html(result);
            }, null, true, null, false);
    }
}

/* Function SetRoleAccess
*** This function is used for load data table.***
--------------------------------------------------------------------------------------------------------------------------*/
function SetRoleAccess(accesstype) {
    var roleElements = $('[role-access');
    accesstype = accesstype.toUpperCase();
    roleElements.each(function (index, item) {

        if (accesstype == "FULLACCESS" || accesstype == "EDITACCESS") {
            $(item).removeClass("no-access");
            $(item).addClass("allow-access");
        }
        else if (accesstype == "READONLYACCESS") {
            $(item).removeClass("no-access");
            $(item).addClass("readonly-access");
        }
    });
}
//function ShowMessage(title, body, isShow = true) {
//    $("#modalSuccessTitle").text(title);
//    $("#modalSuccessBody").html(body);
//    if (isShow) {
//        $("#divModalImportSuccess").modal('show');
//    }
//    else {
//        $("#divModalImportSuccess").modal('hide');
//    }
//}
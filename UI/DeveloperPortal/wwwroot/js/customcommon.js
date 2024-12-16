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
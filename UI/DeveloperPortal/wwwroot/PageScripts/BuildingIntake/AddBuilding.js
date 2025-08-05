
function addBuildingInfo() {
    /*var url = '@Url.Action("AddBuilding", "BuildingIntake", new { area = "Construction" })'*/
    var url = "/Construction/BuildingIntake/AddBuilding"
    var model = { SiteInformationData: SiteInformationData, caseId: Id };
    AjaxCommunication.CreateRequest(this.window, "POST", url, 'html', model,
        function (response) {
            $("#modal-building-add").empty().html(response).modal('show');
            return false;
        },
        null, true, null, false);
}

$("#frmSaveAddBuilding").submit(function (event) {
    var selectedSite = SiteInformationData.find(site => site.fileNumber === $('.ddlProjectSiteId option:selected').text());
    if (selectedSite != null) {
        $("#SelectedSiteId").val(selectedSite.caseID);
    }
    event.preventDefault(); // Prevent normal form submission
    if (BeginSaveAddBuilding()) {
        //AjaxCommunication.CreateRequest(this.window, "POST", "/Construction/BuildingIntake/SaveBuilding", '', $(this).serialize(),
        //    function (response) {
        //        SuccessSaveAddBuilding(response);
        //    },
        //    null, true, null, false);
        $.ajax({
            url: "/Construction/BuildingIntake/SaveBuilding",// "@Url.Action("SaveBuilding", new { controller = "BuildingIntake", area = "Construction" })",
            type: "POST",
            data: $(this).serialize(),
            success: function (data) {
                if (data.result.status) {
                    reloadParkingGrid = true;
                    ReloadBuildingDt();
                    $("#modal-building-add").modal('hide');
                }
                else {
                    alert('error occured...');
                }
            }
        });
    }
});

// form begin.
function BeginSaveAddBuilding() {
    var form = $("#frmSaveAddBuilding");
    $(form).removeData("validator").removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse($(form));
    var validator = $(form).validate();
    var isModelValid = $(form).valid();

    if (false == isModelValid) {
        validator.focusInvalid();
        return false;
    }
    return true;
}
function SaveAddBuilding() {
    $('#frmSaveAddBuilding').submit();
}
function HideShowAddressPanel() {
    var addAddress = document.getElementById('AddAddress');
    if (addAddress.checked == true) {
        $("#IsAddAddress").val("True");
        $("#BuildingAddressID").prop("disabled", true);
        $("#divAddressDetails").show();
        $('span[data-valmsg-for="BuildingAddressID"]').empty();
        $("#BuildingAddressID").val("");
    }
    else {
        $("#IsAddAddress").val("False");
        $("#BuildingAddressID").prop("disabled", false);
        $("#divAddressDetails").hide();
    }
}

var BuildingInformation =
{
    initBuildingSummary:function ()  {
        $("#buildingSummaryForm").submit(function (event) {
            event.preventDefault(); // Prevent normal form submission
            BuildingInformation.submitBuildingSummary($(this).serialize());
        });
        BuildingInformation.resetBulidingSummary();
    },
    editBuildingSummary: function (projectSiteId) {
        /*var url = '@Url.Action("GetBuildingDetails", "BuildingIntake", new { area = "Construction" })'*/
        var url = 'Construction/BuildingIntake/GetBuildingDetails'
        var model = { projectSiteId: projectSiteId, caseId: Id };
        AjaxCommunication.CreateRequest(this.window, "GET", url, 'object', model,
            function (response) {
                var $dropdown = $('#BuildingDescriptionDL');
                $dropdown.empty(); // Clear existing options
                var buildingDescriptionDL = response.buildingDescriptionList;
                $.each(buildingDescriptionDL, function (i, item) {
                    $dropdown.append($('<option>').val(item.text).text(item.text));
                });
                $('#BuildingDescriptionDL').val($('#lblBuildingDescription').text().trim()).change();

                //Address
                $dropdown = $('#BuildingAddressDL');
                $dropdown.empty(); // Clear existing options

                $dropdown.append($('<option>').val('').text('Choose Building Address'));
                var list = response.buildingAddressList;
                $.each(list, function (i, item) {
                    $dropdown.append($('<option>').val(item.value).text(item.text));
                });
                $('#BuildingAddressDL').val($('#BuildingAddressId').val()).change();

                //ApplicableCodesDL
                $dropdown = $('#ApplicableCodesDL');
                $dropdown.empty(); // Clear existing options
                list = response.lutApplicableAccessibilityStandardList;
                $.each(list, function (i, item) {
                    $dropdown.append($('<option>').val(item.value).text(item.text));
                });

                $('#ApplicableCodesDL').multiselect({
                    nonSelectedText: 'None Selected',
                    includeSelectAllOption: true,
                    enableFiltering: false,
                    maxHeight: 300,
                    numberDisplayed: 30,

                });
                $('#ApplicableCodesDL').val($('#LutApplicableAccessibilityStandardId').val().split(",")).change()
                $('#ApplicableCodesDL').multiselect("refresh");
                $(".input-building-summary").addClass("input-building-summary-edit");
                $(".input-building-summary").removeClass("view-control-height");
                $("#editBuildingSummary").hide();
                $("#updateBuildingSummary").show();
                $("#cancelEditBuildingSummary").show();
                $("#ResidentialSpaces").focus();
                $(".radio-building-summary").attr("disabled", false);
                $(".radio-building-summary-lable").hide();
                $(".radio-building-summary-edit").show();
                return false;
            }, null, true, null, false);

    },
    submitBuildingSummary: function (data) {
        $('#cm_loader').attr("hidden", false);
        $('.blockUI').attr("hidden", true);
        $('.btn.btn-primary').attr("disabled", true);
        $.ajax({
            url: 'Construction/BuildingIntake/SaveBuildingSummary',//"@Url.Action("SaveBuildingSummary", new { controller = "BuildingIntake", area = "Construction" })",
            type: "POST",
            data: data,
            success: function (response) {
                $('#cm_loader').attr("hidden", true);
                $('.btn.btn-primary').attr("disabled", false);
                BuildingInformationData = [];
                BuildingInformation.resetBulidingSummary();
                ReloadBuildingDt();
                showMessage("Success", "Building Informantion Updated Successfully.");
            },
            error: function (xhr) {
                $('#cm_loader').attr("hidden", true);
                $('.btn.btn-primary').attr("disabled", false);
                BuildingInformation.resetBulidingSummary();
                ReloadBuildingDt();
                showMessage("Error", "Error occurred, please try again.");
            }
        });
    },
    resetBulidingSummary: function () {
        $(".input-building-summary").removeClass("input-building-summary-edit");
        $(".input-building-summary").addClass("view-control-height");
        $(".radio-building-summary").attr("disabled", true);
        $(".radio-building-summary-lable").show();
        $(".radio-building-summary-edit").hide();

        $("#editBuildingSummary").show();
        $("#cancelEditBuildingSummary").hide();
        $("#updateBuildingSummary").hide();
    },
    cancelBuildingSummary: function () {
        BuildingInformation.resetBulidingSummary();
        ReloadBuildingDt();
    }
};


//Building Summary






//Building Summary


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

function ReloadBuildingDt() {
    if (dtBuildingDataTable)
        dtBuildingDataTable.api().ajax.reload();
}


var dtBuildingDataTable;

var ParkingInformation =
{
    init: function () {
       
        ParkingInformation.reset();
        ParkingInformation.CalculateTotal("chargingStations", "chargingStationsTotal");

        $('.input-parking').on("keypress", function (e) {
            var charCode = (e.which) ? e.which : event.keyCode
            if (String.fromCharCode(charCode).match(/[^0-9]/g))
                return false;
        });
        $('.residentialSpaces').on('change', function () {
            ParkingInformation.CalculateTotal("residentialSpaces", "residentialSpacesTotal")
        });
        $('.comercialSpaces').on('change', function () {
            ParkingInformation.CalculateTotal("comercialSpaces", "comercialSpacesTotal")
        });
        $('.commercialcharging').on('change', function () {
            ParkingInformation.CalculateTotal("commercialcharging", "commercialchargingTotal")
        });
        $('.chargingStations').on('change', function () {
            ParkingInformation.CalculateTotal("chargingStations", "chargingStationsTotal")
        });
    },

    CalculateTotal: function (sourceElement, totalElement) {
        var total = 0;
        $("." + sourceElement).each(function (index, elem) {
            if (!isNaN($(elem).val()) && $(elem).val() !== '') {
                total += parseInt($(elem).val());
            }
        });
        $('.' + totalElement).val(total);
    },
    reset: function () {
        $(".input-parking-edit").addClass("input-parking");
        $(".input-parking").removeClass("input-parking-edit");

        $(".radio-parking").attr("disabled", true);

        $("#editParkingInfo").show();
        $("#updateBuildingParking").hide();
        $("#cancelEditParking").hide();
    },
    edit: function () {
        $(".input-parking").addClass("input-parking-edit");
        $(".input-parking-edit").removeClass("input-parking");
        $("#editParkingInfo").hide();
        $("#updateBuildingParking").show();
        $("#cancelEditParking").show();
        $("#ResidentialSpaces").focus();
        $(".radio-parking").attr("disabled", false);
    },
    update: function () {
        $('#cm_loader').attr("hidden", false);
        $('.blockUI').attr("hidden", true);
        $('.btn.btn-primary').attr("disabled", true);

        AjaxCommunication.CreateRequest(this.window, "POST", APPURL + "BuildingIntake/UpdateParkingDetail", "html", $('#ParkingInfoForm').serialize(),
            function (response) {
                $('#cm_loader').attr("hidden", true);
                $('.btn.btn-primary').attr("disabled", false);

                if (response == true) {
                    BuildingInformationData = [];
                    ParkingInformation.reset();
                    BuildingInformation.ReloadBuildingCurrentPage();
                    showMessage("Success", "Record Updated Successfully.");
                }
                else {
                    showMessage("Error", "Error occurred, please try again.");
                }
            }, function (xhr) {
                $('#cm_loader').attr("hidden", true);
                $('.btn.btn-primary').attr("disabled", false);
                ParkingInformation.reset();
                BuildingInformation.ReloadBuildingCurrentPage();
                showMessage("Error", "Error occurred, please try again.");
            }, true, null, false);
    },
    cancel: function () {
        ParkingInformation.reset();
        BuildingInformation.ReloadBuildingDt();
    }

}

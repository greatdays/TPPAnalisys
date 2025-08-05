var ParkingInformation=
{   
    init:function () 
    {
        $("#ParkingInfoForm").submit(function (event) {
        event.preventDefault(); // Prevent normal form submission
        $('#cm_loader').attr("hidden", false);
        $('.blockUI').attr("hidden", true);
        $('.btn.btn-primary').attr("disabled", true);
        $.ajax({
             //   url: "@Url.Action("UpdateParkingDetail", new { controller = "ProjectDetail", area = "Construction" })",
                url: "Construction/ProjectDetail/UpdateParkingDetail",
            type: "POST",
            data: $(this).serialize(),
           
            success: function (response) {
                $('#cm_loader').attr("hidden", true);
                $('.btn.btn-primary').attr("disabled", false);
                BuildingInformationData = [];
                ParkingInformation.reset();
                ReloadBuildingDt();
                showMessage("Success", "Record Updated Successfully.");
            },
            error: function (xhr) {
                $('#cm_loader').attr("hidden", true);
                $('.btn.btn-primary').attr("disabled", false);
                ParkingInformation.reset();
                ReloadBuildingDt();
                showMessage("Error", "Error occurred, please try again.");
            }
            });
        });
        ParkingInformation.reset();
        ParkingInformation.calculateTotal("chargingStations", "chargingStationsTotal");

        $('.input-parking').on("keypress", function (e) {
            var charCode = (e.which) ? e.which : event.keyCode
            if (String.fromCharCode(charCode).match(/[^0-9]/g))
                return false;
        });
        $('.residentialSpaces').on('change', function () {
            calculateTotal("residentialSpaces", "residentialSpacesTotal")
        });
        $('.comercialSpaces').on('change', function () {
            calculateTotal("comercialSpaces", "comercialSpacesTotal")
        });
        $('.commercialcharging').on('change', function () {
            calculateTotal("commercialcharging", "commercialchargingTotal")
        });
        $('.chargingStations').on('change', function () {
            calculateTotal("chargingStations", "chargingStationsTotal")
        });
    },
    calculateTotal: function (sourceElement,totalElement) {
        var total = 0;
        $("." + sourceElement).each(function (index, elem) {
            if (!isNaN($(elem).val()) && $(elem).val() !== '') {
                total += parseInt($(elem).val());
            }
        });
        $('.' + totalElement).val(total);
    },
    reset:function () {
        $(".input-parking-edit").addClass("input-parking");
        $(".input-parking").removeClass("input-parking-edit");

        $(".radio-parking").attr("disabled",true);

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
     update: function ()
    {
        $('#ParkingInfoForm').submit();
    },
    cancel: function () {
        ParkingInformation.resetData();
        ReloadBuildingDt();
    }
   
}

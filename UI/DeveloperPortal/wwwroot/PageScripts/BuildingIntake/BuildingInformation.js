var dtBuildingDataTable;
var BuildingInformation =
{
     load: function()
    {
        dtBuildingDataTable = $('#dtPrkingData').dataTable({
            ajax: {
                url: APPURL + 'ProjectDetail/GetBuildingInformation',
                data: function (d) {
                    d.caseId = Id;
                    if (reloadParkingGrid==false)
                    {
                        d.BuildingInformationData = JSON.stringify(BuildingInformationData);
                    }
                    reloadParkingGrid = false
                },
                type: 'Post',
                "headers": {
                    "Content-Type": "application/x-www-form-urlencoded"
                },
                dataType: 'json'
            },
            "columns": [{ "data": 'parkingData' }],

            processing: true,
            serverSide: true,
            pageLength: 1,
            pagingType: 'numbers',
            "paging": true,
            "searching": false,
            "ordering": false,
            "dom": "<'row'<'<'col-sm-12'p>>",
            "oLanguage": {
                "sEmptyTable": "No record found."
            }
        });

        dtBuildingDataTable.on('draw.dt', function () {
            if ($("#dtPrkingData_paginate .select-site-title").length == 0) {
                $("#dtPrkingData_paginate").prepend("<div class='select-site-title'>Select Building:</div>")
            }
            $(".dataTables_length").hide();
            var buildingData =dtBuildingDataTable.fnGetData();
            if (buildingData.length > 0) {
                $("#dtPrkingData_paginate").show()
                var pageItems = $("#dtPrkingData_paginate .paginate_button");
                var buildingList = buildingData[0].buildingList;
                BuildingInformationData = buildingData[0].buildingInformationData;
                    for (var i = 0; i < pageItems.length; i++) {
                        var text = pageItems[i].text
                        if (text != '…') {
                            if (parseInt(text).toString() != "NaN") {
                                pageItems[i].text=buildingList[parseInt(text) - 1];
                            }
                        }
                    }
            }
            else { $("#dtPrkingData_paginate").hide();}
        });
    },
    initBuildingSummary:function ()  {
        $("#buildingSummaryForm").submit(function (event) {
            event.preventDefault(); // Prevent normal form submission
            $('#BuildingAddressId').val($('#BuildingAddressDL').val());
            BuildingInformation.submitBuildingSummary($(this).serialize());
        });
        BuildingInformation.resetBulidingSummary();
    },
    editBuildingSummary: function (projectSiteId) {
        var url = APPURL + 'BuildingIntake/GetBuildingDetails'
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

                $('select#ApplicableCodesDL').multiselect({});

                $('#divApplicableCodesDL .multiselect').on('click', function () {
                    setTimeout(function () {
                        if ($("#divApplicableCodesDL .multiselect-container").is(":visible")) { $("#divApplicableCodesDL .multiselect-container").hide() }
                        else {
                            $("#divApplicableCodesDL .multiselect-container").show()
                        }
                    }, 200); // 2000 ms = 2 seconds
                });
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
            url: APPURL + 'BuildingIntake/SaveBuildingSummary',//"@Url.Action("SaveBuildingSummary", new { controller = "BuildingIntake", area = "Construction" })",
            type: "POST",
            data: data,
            success: function (response) {
                $('#cm_loader').attr("hidden", true);
                $('.btn.btn-primary').attr("disabled", false);
                BuildingInformationData = [];
                BuildingInformation.resetBulidingSummary();
                BuildingInformation.ReloadBuildingDt();
                showMessage("Success", "Building Informantion Updated Successfully.");
            },
            error: function (xhr) {
                $('#cm_loader').attr("hidden", true);
                $('.btn.btn-primary').attr("disabled", false);
                BuildingInformation.resetBulidingSummary();
                BuildingInformation.ReloadBuildingDt();
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
        BuildingInformation.ReloadBuildingDt();
    },
    AddBuildingInfo: function () {
        var model = { SiteInformationData: SiteInformationData, caseId: Id };
        var token = $('input[name="__RequestVerificationToken"]').val();
        model.__RequestVerificationToken = token;
        $.ajax({
            url: APPURL + 'BuildingIntake/AddBuilding',
            type: 'POST',
            data: model,
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            headers: {
                'RequestVerificationToken': token,
                'X-Requested-With': 'XMLHttpRequest'
            },
            success: function (response) {
                $("#modal-building-add").empty().html(response).modal('show');
               // console.log("Success", response);
               // $("#successMsg").text("Account updated successfully!").removeClass("d-none");
            },
            error: function (xhr) {
                console.error("❌ Error", xhr.status, xhr.responseText);
            }
        });


        /*var url = '@Url.Action("AddBuilding", "BuildingIntake", new { area = "Construction" })'*/
        //var url = APPURL + "BuildingIntake/AddBuilding"
        //var model = { SiteInformationData: SiteInformationData, caseId: Id };
        //AjaxCommunication.CreateRequest(this.window, "POST", url, 'html', model,
        //function (response) {
        //    $("#modal-building-add").empty().html(response).modal('show');
        //    return false;
        //},
        //null, true, null, false);
    },
    SaveAddBuilding: function () {
        debugger
        var selectedSite = SiteInformationData.find(site => site.fileNumber === $('.ddlProjectSiteId option:selected').text());
        if (selectedSite != null) {
            $("#SelectedSiteId").val(selectedSite.caseID);
        }
        //event.preventDefault(); // Prevent normal form submission
        if (BuildingInformation.BeginSaveAddBuilding()) {
            //AjaxCommunication.CreateRequest(this.window, "POST", "/Construction/BuildingIntake/SaveBuilding", '', $(form).serialize(),
            //    function (response) {
            //        SuccessSaveAddBuilding(response);
            //    },
            //    null, true, null, false);
            var form = $("#frmSaveAddBuilding");
            $.ajax({
                url: APPURL + "BuildingIntake/SaveBuilding",// "@Url.Action("SaveBuilding", new { controller = "BuildingIntake", area = "Construction" })",
                type: "POST",
                data: $(form).serialize(),
                success: function (data) {
                    if (data.result.status) {
                        reloadParkingGrid = true;
                        BuildingInformation.ReloadBuildingDt();
                        $("#modal-building-add").modal('hide');
                    }
                    else {
                        alert('error occured...');
                    }
                }
            });
        }
    }  ,
    HideShowAddressPanel: function () {
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
    },
    BeginSaveAddBuilding:function () {
        var form = $("#frmSaveAddBuilding");
        $(form).removeData("validator").removeData("unobtrusiveValidation");
        if ($.validator.unobtrusive != undefined) {
            $.validator.unobtrusive.parse($(form));
            var validator = $(form).validate();
            var isModelValid = $(form).valid();

            if (false == isModelValid) {
                validator.focusInvalid();
                return false;
            }
        }
        return true;
    },
    ReloadBuildingDt:function () {
        if (dtBuildingDataTable)
        dtBuildingDataTable.api().ajax.reload();
        }

};

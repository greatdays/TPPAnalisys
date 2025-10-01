
var SiteInformation=
{   
    Init:function () 
    {
    },
   
    LoadSiteInformation:function()
    {
        $.fn.dataTableExt.pager.numbers_length = 50;
        if (IsLoadSiteInformationTab) {
            return;
        }
        var dtSiteDataTable = $('#dtSiteData').dataTable({
            ajax: {
                url: APPURL + 'ProjectDetail/GetSiteInformation',
                type: 'POST',
                data: function (d) {
                    d.SiteInformationData = SiteInformationData,
                        d.caseId = Id

                },
                "headers": {
                    "Content-Type": "application/x-www-form-urlencoded"
                },
                dataType: 'json'

            },
            "columns": [
                {
                    "data": 'siteInfomationData'
                }
            ],
            processing: true,
            serverSide: true,
            pagingType: 'numbers',
            pageLength: 1,
            "paging": true,
            "searching": true,
            "ordering": false,
            "dom": "<'row'<'<'col-sm-12'p>>",
            "oLanguage": {
                "sEmptyTable": "No record found."
            }
        });
        dtSiteDataTable.on('draw.dt', function () {
             if ($("#dtSiteData_paginate .select-site-title").length == 0) {
                $("#dtSiteData_paginate").prepend("<div class='select-site-title'>Select Site:  </div> " )
            }

            $(".dataTables_length").hide();
            var siteData = $('#dtSiteData').dataTable().fnGetData();

            var siteLength = siteData.length;
            if (siteLength > 0) {
                $("#dtSiteData_paginate").show();
                documentControlViewModelId = siteData[0].documentControlViewModelId;
                logsControlViewModelId = siteData[0].logsControlViewModelId;
                ContactControlViewModelId = siteData[0].contactControlViewModelId;
                SiteInformationData = siteData[0].siteInformationData;
                var pageItems = $("#tabSiteInformation .paginate_button");
                var siteList = siteData[0].siteList;
                for (var i = 0; i < pageItems.length; i++) {
                    var text = pageItems[i].text
                     if (text != '…') {
                         if (parseInt(text).toString() != "NaN") {
                             pageItems[i].text=siteList[parseInt(text) - 1];
                         }
                     }
                }
                $("#btnSiteInformation").text("Site Information (" + siteList.length + ")");
            }
            else { $("#dtSiteData_paginate").hide(); }
        });
        $("#siteInformationPopup").on("hide.bs.modal", function (e) {
            if ($(e.target).attr("id") !== "siteInformationPopup") {
                $('#siteInformationPopup').modal("show");
            }
        })
        $("#siteInformationPopup").on("hidden.bs.modal", function (e) {
            if ($(e.target).attr("id") !== "siteInformationPopup") {
                $('#siteInformationPopup').modal("show");
            }

        })
        IsLoadSiteInformationTab = true;
    },
    ShowActionPopupClick: function (actionType, title, caseId, refProjectSiteID) 
    {
        popupCaseId = caseId;
        popuprefProjectSiteID = refProjectSiteID;
        popupTitle = title;
        if ($.fn.DataTable.isDataTable('#tableSiteDetails')) { $('#tableSiteDetails').DataTable().destroy(); }
        $('#tableSiteDetails').empty(); var url = "";
         switch (actionType) {
            case "SitInformation":
                url = '';//'@Url.Action("RenderTab", "Tab", new { area = "ComCon" })?tabName=Retrofit%20Site%20Case%20Detail%20-%20New&Id=' + caseId + '&projectSiteId=' + refProjectSiteID;
                window.open(url,'_blank');
                break;
            case "BuidlingInformation":
                var columns = [
                    { data: 'BuildingAddress', title: "Building Address" },
                    { data: 'OwnerNameOrCompany', title: "Owner Name / Company" },
                    { data: 'PMName', title: "PM Name" },
                    { data: 'BuildingFileNumber', title: "Building File #" }
                ];
                url = 'Construction/ConstructionNew/GetBuildingInformation?caseId=' + caseId;
                SiteInformation.LoadSiteActionTable(title, url, columns);
                break;
            case "AllSiteInformation":
                var columns = [
                    { data: 'ServiceRequestNumber', title: "Site #" },
                    { data: 'NoOfBuldings', title: "Number Of Buildings" },
                    { data: 'AcHPSiteNumber', title: "AcHP Site #" },
                    { data: 'AssigneeName', title: "Assignee" },
                    { data: 'Status', title: "Site Status" }
                ];
                url = 'Construction/ConstructionNew/GetAllSiteCasesForSiteDetail?caseId=' + caseId;
                SiteInformation.LoadSiteActionTable(title, url, columns);
                break;
            case "Inspection":
                var columns = [
                    { data: 'Inspectionid', title: "Inspection id" },
                    { data: 'InspectionRound', title: "Inspection Round" },
                    { data: 'InspectedStartOn', title: "Inspection Start Date" },
                    { data: 'InspectedEndOn', title: "Inspection End Date" },
                    { data: 'Inpector', title: "Inspector" },
                    { data: 'ViolationsAdded', title: "Violations Added" },
                    { data: 'ViolationsCleared', title: "Violations Cleared" },
                    { data: 'ViolationsRemaining', title: "Violations Remaining" },
                    { data: 'Status', title: "Status" },
                    { data: 'Notice', title: "Notice" }
                ];
                url = 'Construction/ConstructionNew/GetInpectionHistoryForProject?caseId=' + caseId;
                SiteInformation.LoadSiteActionTable(title, url, columns);
                break;
             //case "Documents":
             //    url = '@Url.Action("GetFilesById", "DMS", new { area = "Document" })?Id=' + caseId + '&projectId=' + refProjectSiteID + '&controlViewModelId=' + documentControlViewModelId
             //    SiteInformation.LoadSiteAction(title, url);
             //    break;
            // case "Logs":
            //     url = '@Url.Action("RenderActivityLogsById", "ActivityLogsComponent", new { area = "ComCon" })?Id=' + caseId + '&projectId=' + refProjectSiteID + '&controlViewModelId=' + logsControlViewModelId;
            //    SiteInformation.LoadSiteAction(title, url);
            //     break;
            default:
        }

    },
    LoadSiteAction: function (title, url) 
    {
        AjaxCommunication.CreateRequest(this.window, "GET", url, "", null,
            function (result) {
               SiteInformation.ShowActionPopup(title, result);
            }, null, true, null, false);
    },
    ShowActionPopup:function (title, data) 
    {
        $("#siteInformationPopupTitle").html(title)
        $("#siteInformationPopupBody").html(data)
        $('#siteInformationPopup').modal("show");
    },
    LoadSiteActionTable:function (title, url, columns) {
        $('#tableSiteDetails').dataTable({
            ajax: {
                url: url,
                type: 'Get',
                "headers": {
                    "Content-Type": "application/x-www-form-urlencoded"
                },
                dataType: 'json',
                dataSrc: ''
            },
            "columns": columns,
            "paging": true,
            "searching": true,
            "ordering": false,
            "dom": "<'row'<'col-sm-4'l><'col-sm-4'p><'col-sm-4'f>>",
            "oLanguage": {
                "sEmptyTable": "No record found."
            }
        });
        SiteInformation.ShowActionPopup(title, "");
    },
    AddSiteInfo: function () {
        var model = { SiteInformationData: SiteInformationData, caseId: Id };
        //var token = $('input[name="__RequestVerificationToken"]').val();
        //model.__RequestVerificationToken = token;
        $.ajax({
            url: APPURL + 'SiteDetail/AddSite',
            type: 'POST',
            data: model,
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            headers: {
                'RequestVerificationToken': token,
                'X-Requested-With': 'XMLHttpRequest'
            },
            success: function (response) {
                $("#modal-site-add").empty().html(response).modal('show');
                // console.log("Success", response);
                // $("#successMsg").text("Account updated successfully!").removeClass("d-none");
            },
            error: function (xhr) {
                console.error("❌ Error", xhr.status, xhr.responseText);
            }
        });
    },
   
    DisplayModal: function () {
        // Example:
        var modal = document.getElementById("modal-site-add");
        // Check if it prints null
        modal.style.display = "block"; // <-- this will fail if modal is null


        $('#modal-site-add').modal('show');
        // $('#ActionModal').modal('show');
       

        document.getElementById('noAPNData').style.display = 'none';
        document.getElementById('APNError').style.display = 'none';

        $('#APNInput').val('');

        //// Clear the dropdown list, resetting it to the default option
        $('#SiteAddressControlSelect').empty().append('<option value="" disabled selected>Please Select a Site Address</option>');

        //// Clear the project and property name input fields
        $('#projectNameInput').val('');
        $('#propertyNameInput').val('');

        // Remove any validation error messages that might be visible
        $('.validation-error').remove();
        $('#validationMessage').hide(); // Hide the main validation message if it's visible
       
        
        document.getElementById("CreateNewProjectSiteId").style.display = "none";

        $.ajax({
            url: APPURL + "Account/GetAllLookupData",
            type: 'GET',
            dataType: 'json',
            success: function (data) {
               

                // Direction
                $.each(data.direction, function (i, item) {
                    $('#PreDirectionSelect').append($('<option>').text(item.directionText).attr('value', item.directionValue));
                });
                $('#PreDirectionSelect').val(0);

                // StreetType
                $.each(data.streetType, function (i, item) {
                    $('#StreetTypeSelect').append($('<option>').text(item.streetTypeText).attr('value', item.streetTypeValue));
                });
                $('#StreetTypeSelect').val(0);

                //// UserRole
                //$.each(data.userRole, function (i, item) {
                //    $('#UserRole').append($('<option>').text(item.roleName).attr('value', item.roleID));
                //});
                //$('#UserRole').val(0);
            },
            error: function (xhr) {
                console.error("Error fetching lookup data", xhr);
            }
        });
    },
    GetAPNProjectAddress: function () {

        const input = document.getElementById("APNInput");
        const value = input.value.trim();
        document.getElementById("noAPNData").style.display = "none";
        if (value === '') {
            document.getElementById("APNError").style.display = "block";
            return;
        }
        else {
            document.getElementById("APNError").style.display = "none";
            setTimeout(SiteInformation.SerachOnAPNClick, 300);
        }
    },

    SerachOnAPNClick: function () {
        var token = $('input[name="__RequestVerificationToken"]').val();
        var ctlIndex = GetControlIndex();
        //console.log('ProjCount: ' + ctlIndex);
        const input = document.getElementById("APNInput");
        const APNNumber = input.value.trim();

        document.getElementById("noAPNData").style.display = "none";
        $.ajax({
            url: APPURL + 'Dashboard?handler=GetAPNProjectName',
            type: 'POST',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            headers: {
                'RequestVerificationToken': token
            },
            data: { APNNumber: APNNumber },
            success: function (response) {

                if (response.apnSearchSiteAddresslst == null && response.apnSearchProjectInfolst == null) {
                    document.getElementById("noAPNData").style.display = "block";
                    document.getElementById("CreateNewProjectSiteId").style.display = "none";
                    /*document.getElementById("saveBtn").style.display = "None";*/
                    return;
                }

                if (response.apnSearchSiteAddresslst != null) {
                    var projectList = response.apnSearchSiteAddresslst.map(p => ({
                        id: p.siteAddressID,
                        fullAddress: p.fullAddress
                    }));
                }
                var dropdown = $('#SiteAddressControlSelect');
                dropdown.empty().append('<option value="" disabled selected>Please Select a Site Address</option>');


                // Check if the response is valid and has data
                if (response.apnSearchSiteAddresslst != null && projectList && projectList.length > 0) {
                  /*  document.getElementById("saveBtn").style.display = "inline-block";*/
                    document.getElementById("CreateNewProjectSiteId").style.display = "block";
                    // Loop through the data and add options to the dropdown
                    $.each(projectList, function (i, item) {
                        dropdown.append($('<option>', {
                            value: item.id,      // Assuming the C# object has a 'id' property
                            text: item.fullAddress // Assuming the C# object has a 'projectName' property
                        }));
                    });
                }
                else {
                    document.getElementById("CreateNewProjectSiteId").style.display = "none";
                }

               

            },
            error: function (xhr) {
                console.error("Error:", xhr.status, xhr.responseText);
                callback(null, null, false);
            }
        });
    },
    toggleManualAddress: function () {
        const checkbox = document.getElementById("manualAddressCheck");
        const manualFields = document.getElementById("manualAddressFields");
        if (checkbox.checked) {
            $("#IsAddAddress").val("True");
            manualFields.style.display = "block";   // show fields
        } else
        {
            $("#IsAddAddress").val("True");
            manualFields.style.display = "none";    // hide fields
        }
    },
    SaveAddSite: function () {
       
        debugger
        //var selectedSite = SiteInformationData.find(site => site.fileNumber === $('.ddlProjectSiteId option:selected').text());
        //if (selectedSite != null) {
        //    $("#SelectedSiteId").val(selectedSite.caseID);
        //}
        //event.preventDefault(); // Prevent normal form submission
        if (SiteInformation.BeginSaveAddSite()) {
            //AjaxCommunication.CreateRequest(this.window, "POST", "/Construction/BuildingIntake/SaveBuilding", '', $(form).serialize(),
            //    function (response) {
            //        SuccessSaveAddBuilding(response);
            //    },
            //    null, true, null, false);
            var form = $("#frmSaveAddSite");
            $.ajax({
                url: APPURL + "ProjectDetail/CreateSite",// "@Url.Action("SaveBuilding", new { controller = "BuildingIntake", area = "Construction" })",
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
    },
    BeginSaveAddSite: function () {
        var form = $("#frmSaveAddSite");
        $(form).removeData("validator").removeData("unobtrusiveValidation");
       
        console.log("siteformdata");
        console.log(form);
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

}
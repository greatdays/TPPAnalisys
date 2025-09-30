var gridBuildingDropdowData = [];
var allUnitsData = [];
var BuildingInformationData = [];
var UnitGridData = [];
var dtBuildingDataTable;
var kgridEditModelData = {};
var windowTemplate;
var kednoWindow = "";

var UnitMatrixInformation =
{

    init: function () {
        windowTemplate = kendo.template($("#windowTemplate").html());
        kednoWindow = $("#kednoWindow").kendoWindow({
            title: "Are you sure you want to delete this unit?",
            visible: false, //the window will not appear before its .open method is called
            width: "400px",

        }).data("kendoWindow");

        $("#uploadUnitExcel").click(function () {
            $("#modalImportUnits").modal('show');
        });
        $('#search-unit-grid').keyup(function (e) {
            var value = this.value.toLowerCase().trim();

            $('#unitKgrid').find('table tr').each(function (index) {
                if (!index) return;
                $(this).find("td").each(function () {
                    var id = $(this).text().toLowerCase().trim();
                    var not_found = (id.indexOf(value) == -1);
                    $(this).closest('tr').toggle(!not_found);
                    return not_found;
                });
            });
            SetRoleAccess(accessType);
        });
    },
    downloadSampleExcel: function () {
        const fileUrl = "Document/ImportUnitMatrixSample.xlsx";

        const link = document.createElement("a");
        link.href = APPURL + fileUrl;
        link.download = "ImportUnitMatrixSample.xlsx";
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);

        const overlay = document.getElementById("loadingOverlay");
        if (overlay) {
            overlay.style.display = "none";
        }
    },
    LoadUnitMatrix: function () {
        dataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    /* url: '@Url.Action("GetUnitDetails", "ProjectDetail", new { area = "Construction" })',*/

                    url: APPURL + "ProjectDetail/GetUnitDetails",
                    dataType: "json"
                    , method: "post"
                    , contentType: "application/json"
                },
                update: {
                    /*url: '@Url.Action("UpdateUnitDetails", "ProjectDetail", new { area = "Construction" })',*/
                    url: APPURL + "ProjectDetail/UpdateUnitDetails",
                    method: "post",
                    dataType: "json"
                    , contentType: "application/json"
                },
                destroy: {
                    /*url: '@Url.Action("DeleteUnitDetail", "ProjectDetail", new { area = "Construction" })',*/
                    url: APPURL + "ProjectDetail/DeleteUnitDetail",
                    method: "post",
                    dataType: "json"
                    , contentType: "application/json"
                },
                create: {
                    /*url: '@Url.Action("AddUnitDetail", "ProjectDetail", new { area = "Construction" })',*/
                    url: APPURL + "ProjectDetail/AddUnitDetail",
                    method: "post",
                    dataType: "json"
                    , contentType: "application/json"
                },
                parameterMap: function (options, operation) {
                    if (operation !== "read" && options.models) {
                        $('#cm_loader').attr("hidden", false);
                        $('.blockUI').attr("hidden", true);
                        //Update Ids based on vales
                        if (options.models.length > 0) {
                            options.models[0].unitType = "";
                        }
                        UnitGridData = [];
                        return JSON.stringify(options.models);
                    }
                    options.caseId = Id;
                    options.projectId = ProjectId;
                    if (operation == "read" && reloadUntiGrid) {
                        reloadUntiGrid = false;
                        options.page = 1;
                        options.pageSize = 20;
                        options.skip = 0;
                        options.take = 20;
                    }
                    else { options.unitGridData = UnitGridData; }
                    return JSON.stringify(options);
                }
            },
            pageSize: 20,
            batch: true,
            serverPaging: true,
            serverSorting: true,
            schema: {
                total: function (response) {
                    return response._total;
                },
                model: {
                    id: "unitID",
                    fields: {
                        unitID: { editable: false, nullable: true },
                        achpNo: { validation: { required: true } },
                        unitNum: { type: "string" },
                        managersUnit: { type: "boolean" },
                        totalBedroom: { type: "string", validation: { required: true } },
                        floorPlanType: { type: "string", },
                        floorPlanTypeID: { type: "number" },
                        unitType: { type: "string", defaultValue: { Value: 0, Text: "Select" } },
                        additionalAccecibility: { type: "string" },
                        isCompliant: { type: "boolean" },
                        isCSA: { type: "boolean" },
                        isVCA: { type: "boolean" }
                    }
                },
                noRecords: true,
                data: function (response) {
                    if (response.totalUnitsCount) {
                        UnitMatrixInformation.SetUnitTotalGridData(response.totalUnitsCount);
                        gridBuildingDropdowData = response.buildingDropDownList;
                    }

                    UnitGridData = response.unitGridData;
                    if (response.success == true) {
                        showMessage("Success", response.message);
                    }
                    if (response.success == false) {
                        showMessage("Error", "Error occurred, please try again.");
                    }
                    if (response.isRefreshGrid) {

                        var grid = $('#unitKgrid').data('kendoGrid');
                        grid.dataSource.read();

                    }
                    $('#cm_loader').attr("hidden", true);
                    return response ? response.data : response;
                }
            }
        });
        var gridCommand = [];
        var gridToolbar = [];
        if (isEditAccess) {
            gridToolbar = [{ name: "create", text: "Add" }];
            gridCommand = [
                { name: "edit", text: { edit: " ", update: " ", cancel: " " } },
                {
                    name: "Delete", text: "<span class='k-icon k-i-close'></span>",
                    click: function (e) {

                        //add a click event listener on the delete button
                        e.preventDefault(); //prevent page scroll reset
                        var tr = $(e.target).closest("tr"); //get the row for deletion
                        var data = this.dataItem(tr); //get the row data so it can be referred later

                        kednoWindow.content(windowTemplate(data)); //send the row data object to the template and render it
                        kednoWindow.center().open();

                        $("#yesButton").click(function () {
                            dataSource.remove(data)  //prepare a "destroy" request
                            dataSource.sync()  //actually send the request (might be ommited if the autoSync option is enabled in the dataSource)
                            kednoWindow.close();
                        })
                        $("#noButton").click(function () {
                            kednoWindow.close();
                        })

                    }
                }
            ]
        }

        $("#unitKgrid").kendoGrid({
            dataSource: dataSource,
            height: 600,
            sortable: true,
            scrollable: {
                endless: true
            },
            pageable: {
                numeric: false,
                previousNext: false
            },

            editable: {
                mode: "inline",
                confirmation: true,
                confirmDelete: "No"
            },
            edit: UnitMatrixInformation.onGridEdit,
            toolbar: gridToolbar,
            columns: [
                { field: "achpNo", title: "ACHP #", width: "150px", editor: UnitMatrixInformation.BuildingDropDownEditor, template: "#=achpNo#" },
                { field: "unitNum", title: "Unit #", width: "80px" },
                { field: "managersUnit", title: "Managers Unit", width: "80px", template: UnitMatrixInformation.ManagersUnitTemplate },
                { field: "totalBedroom", title: "Unit Type", width: "110px", editor: UnitMatrixInformation.TotalBedroomDropDownEditor, template: UnitMatrixInformation.TotalBedroomTemplate },
                {
                    field: "floorPlanTypeID",                // 👈 bind to ID
                    title: "Floor Plan Type",
                    width: "150px",
                    editor: UnitMatrixInformation.FloorPlanDropDownEditor,
                    template: "#= floorPlanType ? floorPlanType : '' #"   // show readable text
                },
                { field: "unitType", title: "Unit Designation Mobility, Communication, FHA / 11A / 11B)", editor: UnitMatrixInformation.UnitTypeDropDownEditor, template: UnitMatrixInformation.UnitTypeTemplate, width: "150px" },
                { field: "additionalAccecibility", title: "Additional Accessibility Requirement: Universal Design, EAP, Unruh", width: "150px" },
                { field: "isCompliant", title: "Compliant Yes or No", template: UnitMatrixInformation.IsCompliantTemplate, width: "80px" },
                { field: "isCSA", title: "Unit Designated for Compliance With CSA", template: UnitMatrixInformation.IsComplianceWithCSATemplate, width: "120px" },
                { field: "isVCA", title: "Unit Designated for Compliance With VCA", template: UnitMatrixInformation.IsComplianceWithVCATemplate, width: "120px" },
                {
                    command: gridCommand, title: "&nbsp;", width: "80px"
                }]
        });
        ParkingInformation.init();
        UnitMatrixInformation.GetUnitModalData();
    },
    GetUnitModalData: function () {
        window.setTimeout(function () {
            var url = APPURL + "ProjectDetail/GetUnitModalData?caseId=" + Id;
            AjaxCommunication.CreateRequest(this.window, "GET", url, "", null,
                function (result) {
                    kgridEditModelData = result;
                }, null, true, null, false);
        }, 1000);
    },
    onGridEdit: function (arg) {
        var buildingId = arg.model.buildingId;
        if (buildingId) {
            var buildingddl = $("[name^='achpNo']").data("kendoDropDownList");
            buildingddl.readonly();
        }
    },
    TotalBedroomDropDownEditor: function (container, options) {
        $('<input required name="' + options.field + '"/>')
            .appendTo(container)
            .kendoDropDownList({
                autoBind: false,
                dataTextField: "text",
                dataValueField: "text",
                dataSource: kgridEditModelData.lutTotalBedrooms,
                change: function (e) {
                    var dataItem = e.sender.dataItem();
                    options.model.set("LutTotalBedroomID", dataItem.value);
                }
            });

    },
    BuildingDropDownEditor: function (container, options) {
        $('<input required name="' + options.field + '"/>')
            .appendTo(container)
            .kendoDropDownList({

                autoBind: false,
                dataTextField: "buildingFileNumber",
                dataValueField: "buildingFileNumber",
                dataSource: BuildingInformationData,
                change: function (e) {
                    var dataItem = e.sender.dataItem();
                    options.model.set("BuildingId", dataItem.buildingId);
                    options.model.set("CaseId", dataItem.caseId);
                }
            });
    },
    UnitTypeDropDownEditor: function (container, options) {
        $('<input  name="' + options.field + '"/>')
            .appendTo(container)
            .kendoDropDownList({
                autoBind: false,
                dataTextField: "text",
                dataValueField: "text",
                dataSource: kgridEditModelData.lutUnitType,
                change: function (e) {
                    var dataItem = e.sender.dataItem();
                    options.model.set("LutUnitTypeID", dataItem.value);
                }

            });
    },
    FloorPlanDropDownEditor: function (container, options) {
        $('<input required name="floorPlanTypeID"/>')
            .appendTo(container)
            .kendoDropDownList({
                autoBind: true,
                dataTextField: "name",
                dataValueField: "floorPlanTypeID",
                dataSource: kgridEditModelData.lutFloorPlanType,
                value: options.model.floorPlanTypeID,
                change: function (e) {
                    var dataItem = e.sender.dataItem();
                    options.model.set("floorPlanTypeID", dataItem.floorPlanTypeID);
                    options.model.set("floorPlanType", dataItem.name);
                }
            });
    },
    TotalBedroomTemplate: function (data) {
        switch (data.totalBedroom) {
            case "1":
                data.totalBedroom = "1 Bedroom";
                break;
            case "2":
                data.totalBedroom = "2 Bedroom";
                break;
            case "3":
                data.totalBedroom = "3 Bedroom";
                break;
            case "4":
                data.totalBedroom = "4 Bedroom";
                break;
            case "5+":
                data.totalBedroom = "5 Bedroom";
                break;
            default:

                break;
        }
        return data.totalBedroom == null ? "" : data.totalBedroom;
    },
    FloorPlanTemplate: function (data) {
        return data.floorPlanType == null ? "" : data.floorPlanType;
    },
    UnitTypeTemplate: function (data) {
        return data.unitType == null ? "" : data.unitType;
    },
    ManagersUnitTemplate: function (data) {
        return data.managersUnit ? "Yes" : "No";;

    },
    IsCompliantTemplate: function (data) {
        return data.isCompliant ? "Yes" : "No";
    },
    IsComplianceWithCSATemplate: function (data) {
        return data.isCSA ? "Yes" : "No";
    },
    IsComplianceWithVCATemplate: function (data) {
        return data.isVCA ? "Yes" : "No";
    },
    SetUnitTotalGridData: function (data) {
        if ($(".k-unit-grid-title").length == 0) {
            $("#unitKgrid .k-grid-add").html("Add <i class='fa fa-plus'></i>");
            $(".k-grid-toolbar", "#unitKgrid").prepend("<span class='k-grid-header-title k-unit-grid-title'>Unit Information </span>");
            //$(".k-grid-toolbar", "#unitKgrid").prepend("<span class='k-grid-header-title k-unit-grid-title'>Unit: Distribution & Designation By Unit Type, Floor Plan Type, Accessible Unit Type </span>");
        }

        $("#lblSROCount").text(data.sroCount);
        $("#lblStudioCount").text(data.StudioCount);
        $("#lblEfficiencyCount").text(data.efficiencyCount);
        $("#lblBedroom1Count").text(data.bedroom1Count);
        $("#lblBedroom2Count").text(data.bedroom2Count);
        $("#lblBedroom3Count").text(data.bedroom3Count);
        $("#lblBedroom4Count").text(data.bedroom4Count);
        $("#lblBedroom5Count").text(data.bedroom5Count);
        $("#lblManagerUnitCount").text(data.managerUnitCount);
        $("#lblTotalCount").text(data.totalCount);

        $("#lblUnitDesignatedCSACount").text(data.unitDesignatedCSACount);
        $("#lblUnitDesignatedVCACount").text(data.unitDesignatedVCACount);
        $("#lblTotalMobilityUntCount").text(data.totalMobilityUntCount);
        $("#lblTotalCommunicationUntCount").text(data.totalCommunicationUntCount);
        $("#lblTotalAdaptableUntCount").text(data.totalAdaptableUntCount);
        $("#lblTotalMobilityUnitsPer").text(data.totalMobilityUnitsPer);
        $("#lblTotalCommunicationsPer").text(data.totalCommunicationsPer);
        $("#lblTotalCommunicationCount").text(data.totalCommunicationCount);
        $("#lblTotalMobilityUnitsVCAPer").text(data.totalMobilityUnitsVCAPer);
        $("#lblTotalMobilityUnitsVCACount").text(data.TotalMobilityUnitsVCACount);
        $("#lblTotalMobilityUnitsCSAPer").text(data.TotalMobilityUnitsCSAPer);
        $("#lblTotalMobilityUnitsCSACount").text(data.TotalMobilityUnitsCSACount);
    },
    ///FOr IMPORT
    ImportInit: function () {
        var myDropzone = new Dropzone("div#divDropZone", {
            url: APPURL + 'ProjectDetail/ImportUnitInformation',
            paramName: "file",
            clickable: "#divDropZone",
            filesizeBase: 1024,
            uploadMultiple: false,
            autoProcessQueue: false,
            addRemoveLinks: true,
            autoDiscover: false,
            acceptedFiles: ".xls,.xlsx", // file types.
            dictMaxFilesExceeded: 'You can not upload any more files.',
            dictRemoveFile: 'Remove file',
            dictDefaultMessage: 'Drop files here to upload',
            dictCancelUpload: 'Cancel upload',
            init: function () {
                myDropzone = this;
                this.on("sending", function (data, xhr, formData) {
                    formData.delete('ProjectId');
                    formData.delete('ProjectSiteID');
                    formData.delete('Id');
                    formData.delete('FileNumber');

                    formData.append('ProjectId', $('#ProjectId').val());
                    formData.append('ProjectSiteID', $('#ProjectSiteID').val());
                    formData.append('Id', $('#Id').val());
                    formData.append('FileNumber', $('#FileNumber').val());
                });

                this.on('success', function (file, response) {
                    fnUnblockUI();
                    var myDropZone = eval("dropzone");
                    if (response.result.status) {
                        myDropzone.removeAllFiles();
                        myDropZone.removeAllFiles();

                        ShowMessage("Suceess!", response.result.message, true);
                        $("#modalImportUnits").modal('hide');

                    } else {
                        myDropzone.removeAllFiles();
                        $("#modalImportUnits").modal('show');
                        ShowMessage("Error!", response.result.errorMessage, true);
                    }
                });

                this.on("error", function (file, message) {
                    this.removeFile(file);
                    fnUnblockUI();
                    ShowMessage("Error!", message, true);
                });
            }
        });
        eval("dropzone" + " = myDropzone");
        $("#modalDismiss").click(function () {
            reloadUntiGrid = true;
            $('#unitKgrid').data('kendoGrid').dataSource.read();
            $('#unitKgrid').data('kendoGrid').refresh();
            reloadParkingGrid = true;
            $('#dtPrkingData').DataTable().ajax.reload();
        });
        $("#unitImport").click(function () {
            UnitMatrixInformation.Import();
        });
    },
    Import: function () {
        myDropzone = eval("dropzone");
        if (myDropzone.getQueuedFiles().length < 1) {
            $("#errorMsg").show();
            $("#errorMsg").html('At least one file is required');
            return false;
        }
        $("#errorMsg").hide();
        if ($("#unit-upload-form").valid()) {
            fnBlockUI();
            myDropzone.processQueue();
        }
        return true;
    }

}

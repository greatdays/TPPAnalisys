
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
                url: 'ProjectDetail/GetSiteInformation',
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
                $("#dtSiteData_paginate").prepend("<div class='select-site-title'>Select Site:</div>")
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
            // case "Documents":
            //     url = '@Url.Action("GetFilesById", "DMS", new { area = "Documents" })?Id=' + caseId + '&projectId=' + refProjectSiteID + '&controlViewModelId=' + documentControlViewModelId
            //     SiteInformation.LoadSiteAction(title, url);
            //     break;
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
    }
}
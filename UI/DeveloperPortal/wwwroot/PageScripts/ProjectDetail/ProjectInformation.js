var ProjectInformation=
{   
        init:function ()  {

        },

        projectActions: function() {
             var url = 'ProjectDetail/GetProjectActionsByCaseId';
           $.ajax({
               url: url,
               data: {caseId: Id, projectId: ProjectId},
               type: "GET",
               contentType: "application/json",
               success: function (result) {
                   $('#divProjectActions').html(result);
               },
               error: function (error) {
                   console.log("There was an error in getting project actions.")
                   console.log(error);
               }
           });
        },
        openTab: function (evt, tabName) {
            // Get all elements with class="tabcontent" and hide them
            $(".tabcontent").css("display", "none");
            // Get all elements with class="tablinks" and remove the class "active"
            $(".tablinks").removeClass("active");
            // Show the current tab, and add an "active" class to the button that opened the tab
            document.getElementById(tabName).style.display = "block";
            if (evt) { evt.currentTarget.className += " active"; }
            var url = "";
            debugger;
            switch (tabName) {
                case "tabSiteInformation":
                    SiteInformation.LoadSiteInformation();
                break;
                // case "tabImportantDates":
                //     url = '@Url.Action("ImportantDates", "Construction", new { area = "Construction" })?id=' + Id;
                //     LoadTabData(url, "divImportantDates");
                //     break;
                case "tabProjectParticipants":
                    ProjectParticipants.LoadProjectParticipants();
                     //console.log("Id: " + Id);
                     //url = '@Url.Action("RenderContactById", "ProjectDetail", new { area = "ComCon" })?Id=' + Id + '&projectId=' + ProjectId + '&controlViewModelId=' + ContactControlViewModelId;
                     //LoadTabData(url, "divProjectParticipants");
                     break;
                // case "tabPolicyContacts":
                //     url = '@Url.Action("RenderContactById", "Render", new { area = "ComCon" })?Id=' + Id + '&projectId=' + ProjectId + '&controlViewModelId=' + ProjectId;
                //     LoadTabData(url, "divPolicyContacts");
                //     break;
                // case "tabDocuments":
                //     var url = '@Url.Action("GetFilesByIdNew", "DMS", new { area = "Document", caseId = "__id__" })';
                //     url = url.replace("__id__", Id);
                //     console.log(url);
                //     LoadTabData(url, "divDocument", true);
                //     break;
                // case "tabLogs":
                //     url = '@Url.Action("RenderActivityLogsById", "ActivityLogsComponent", new { area = "ComCon" })?Id=' + Id + '&projectId=' + ProjectId + '&controlViewModelId=' + ProjectId;
                //     LoadTabData(url, "divLogs");
                //     break;
                default:
            }
        },
        printSelectedTabs: function ()
        {
            //Todo
        },
        helpImage: function()
        {
            $("#myModalHelp").modal('show');
        }
}
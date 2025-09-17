var ProjectInformation=
{   
        init:function ()  {

        },

        projectActions: function() {
            var url = APPURL + 'ProjectDetail/GetProjectActionsByCaseId';
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

            switch (tabName) {
                case "tabSiteInformation":
                    SiteInformation.LoadSiteInformation();
                   break;
                case "tabDevelopmentTeamList":
                    DevelopmentTeam.LoadParticipants();
                     break;
                 case "tabDocuments":
                    var caseId = Id; // Replace with your method to get case ID
                    // Replace with your method
                    console.log(Id);
                    DMS.LoadDocuments(caseId);
                    break;

                case "tabFundingSource":
                    if (window.FundingSource) {
                        FundingSource.LoadFundingSources(Id);
                    } else {
                        console.error("FundingSource class not loaded yet");
                    }
                    break;
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
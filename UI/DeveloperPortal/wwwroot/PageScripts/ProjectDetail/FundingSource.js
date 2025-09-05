
var FundingSource=
{   
    Init:function () 
    {
    },
   
    LoadFundingInformation: function (caseId, controlViewModelId = 0, targetDiv = 'divFundingSource')
    {
        const url = 'FundingSource/FundingSource';

        $.ajax({
            url: url,
            type: 'GET',
            data: {
                caseId: parseInt(caseId),
                controlViewModelId: parseInt(controlViewModelId)
            },
            success: function (html) {
                $(`#${targetDiv}`).html(html);
                //DMS.HideLoader();

                // Initialize DMS Manager after content is loaded
                setTimeout(() => {
                    if (window.dmsManager) {
                        window.dmsManager.destroy(); // Clean up existing instance
                    }
                    window.dmsManager = new DMSManager();
                }, 100);
            },
            error: function (xhr, status, error) {
                //DMS.HideLoader();
                console.error('DMS Load Error:', error);

                // Show error message in the target div
                //$(`#${targetDiv}`).html(`
                //    <div class="alert alert-danger" role="alert">
                //        <h4 class="alert-heading">Error Loading Documents</h4>
                //        <p>Failed to load documents. Please try again.</p>
                //        <hr>
                //        <p class="mb-0">
                //            <button class="btn btn-outline-danger" onclick="DMS.LoadDocuments(${caseId}, ${controlViewModelId}, '${targetDiv}')">
                //                <i class="fas fa-redo"></i> Retry
                //            </button>
                //        </p>
                //    </div>
                //`);
            }
        });
    },

    
}
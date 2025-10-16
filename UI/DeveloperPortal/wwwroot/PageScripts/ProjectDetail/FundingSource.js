var FundingSource = {

    LoadFundingSources: function (caseId, projectId, controlViewModelId = 0, targetDiv = 'divFundingSource') {
        if (!caseId) {
            console.error('CaseId is required');
            return;
        }
        debugger;

       
        $.ajax({
            url: APPURL + 'FundingSource/GetFundingSourcesById',
            type: 'GET',
            cache: false, // <— prevents browser caching
            data: { caseId, projectId, controlViewModelId },
            success: function (html) {
                $('#divFundingSource').empty().html(html);
            },
            error: function (xhr) {
                console.error('Error loading funding sources:', xhr.responseText);
            }
        });
    },


    DeleteFundingSource: function (id) {
        
        const data = { id: id };
        const url = APPURL + 'FundingSource/DeleteFundingSource';

        AjaxCommunication.CreateRequest(this.window, "POST", url, "html", data,
            function (result) {
                var CaseID = $('#CaseId').val();
                var ProjectID = $('#ProjectId').val();
                const url = APPURL + 'FundingSource/GetFundingSourcesById';
                const data = { caseId: CaseID, projectId: ProjectID };
                AjaxCommunication.CreateRequest(this.window, "GET", url, "html", data,
                    function (result) {
                        $("#divFundingSource").html(result);
                    }, null, true, null, false);


            }, null, true, null, false);
    },

  

    EditFundingSource: function (id) {
        
        $('#editFundingSourceModal .modal-body').empty();
        const data = { id: id };
        const url = APPURL + 'FundingSource/EditFundingSource';
        AjaxCommunication.CreateRequest(this.window, "GET", url, "html", data,
            function (result) {
                $('#editFundingSourceModal .modal-body').html(result);
                $('#editFundingSourceModal').modal('show');
            }, null, true, null, false);
    },

    showEditModals: function (id) {
        // const data = { id: id };
        $.get(APPURL + 'FundingSource/GetById', { id })
            .done((data) => {
                if (!data) {
                    this.showMessage('No funding source found', 'error');
                    return;
                }
                this.populateEditForm(data);
                $('#EditFundingSourceModalLabel, #modalTitleEdit').text('Edit Funding Source');
                new bootstrap.Modal(this.$modalEdit[0]).show();
            })
            .fail(() => this.showMessage('Failed to load funding source data', 'error'));
    },

    





}




// Global functions for backward compatibility

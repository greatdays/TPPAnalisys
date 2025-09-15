var FundingSource = {

    LoadFundingSources: function (caseId, controlViewModelId = 0, targetDiv = 'divFundingSource') {
        if (!caseId) {
            console.error('CaseId is required');
            return;
        }

        $.get(APPURL + 'FundingSource/GetFundingSourcesById', { caseId, controlViewModelId })
            .done((html) => {
                $(`#divFundingSource`).html(html);

            });
    },


    DeleteFundingSource: function (id) {
        debugger;
        const data = { id: id };
        const url = APPURL + 'FundingSource/DeleteFundingSource';

        AjaxCommunication.CreateRequest(this.window, "POST", url, "html", data,
            function (result) {
                var CaseID = $('#CaseId').val();
                const url = APPURL + 'FundingSource/GetFundingSourcesById';
                const data = { caseId: CaseID };
                AjaxCommunication.CreateRequest(this.window, "GET", url, "html", data,
                    function (result) {
                        $("#divFundingSource").html(result);
                    }, null, true, null, false);


            }, null, true, null, false);
    },

  

    EditFundingSource: function (id) {
        debugger;
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

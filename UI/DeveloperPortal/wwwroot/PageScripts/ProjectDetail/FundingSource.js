/**
 * Funding Source Management System - Corrected Version
 */
window.FundingSourceManager = class FundingSourceManager {
    constructor() {
        this.dataTable = null;
        this.$table = $('#fundingSourceTable');

        // Form and modal selectors
        this.$formAdd = $('#addFundingSourceForm');
        this.$formEdit = $('#editFundingSourceForm');
        this.$modalAdd = $('#addFundingSourceModal');
        this.$modalEdit = $('#editFundingSourceModal');

        this.$messageContainer = $('#messageContainer');
        this.init();
    }

    init() {
        // Only initialize if all core elements are present in the DOM
        if (!this.$table.length || !this.$formAdd.length || !this.$modalAdd.length) {
            console.warn('FundingSourceManager: Required elements not found. Initialization skipped.');
            return;
        }

        $(document).ready(() => {
            this.initDataTable();
            this.bindEvents();
        });
    }

    /** Initialize DataTable */
    initDataTable() {
        if (!this.$table.length) return;

        if ($.fn.DataTable.isDataTable(this.$table)) {
            this.$table.DataTable().destroy();
        }

        this.dataTable = this.$table.DataTable({
            paging: true,
            searching: true,
            ordering: true,
            responsive: true,
            language: { emptyTable: "No funding sources available" },
            columnDefs: [
                { targets: -1, orderable: false, searchable: false } // Last column (Actions)
            ]
        });
    }

    /** Bind DOM Events */
    bindEvents() {
        // Show Add Modal
        $('#btnAddFundingSource').on('click', (e) => {
            e.preventDefault();
            this.resetForm(this.$formAdd);
            this.hideFormErrors(this.$formAdd);
            $('#addFundingSourceLabel').text('Add Funding Source');
            new bootstrap.Modal(this.$modalAdd[0]).show();
        });

        // Show Edit Modal
        $(document).on('click', '.btn-edit', (e) => {
            e.preventDefault();
            const id = $(e.currentTarget).data('id');
            this.showEditModal(id);
        });

        // Delete Funding Source
        $(document).on('click', '.btn-delete', (e) => {
            e.preventDefault();
            this.deleteFundingSource($(e.currentTarget).data('id'));
        });

        // Save (Add)
        this.$formAdd.on('submit', (e) => {
            e.preventDefault();
            this.saveFundingSource(this.$formAdd, '/FundingSource/Create', this.$modalAdd);
        });

        // Save (Edit)
        this.$formEdit.on('submit', (e) => {
            e.preventDefault();
            this.saveFundingSource(this.$formEdit, '/FundingSource/Update', this.$modalEdit);
        });

        // Remove current file (Edit)
        $(document).on('click', '#removeCurrentFile', (e) => {
            e.preventDefault();
            this.removeCurrentFile();
        });

        // Reset modals when hidden
        this.$modalAdd.on('hidden.bs.modal', () => {
            this.resetForm(this.$formAdd);
            this.hideFormErrors(this.$formAdd);
            this.resetSubmitButton(this.$formAdd);
        });

        this.$modalEdit.on('hidden.bs.modal', () => {
            this.resetForm(this.$formEdit);
            this.hideFormErrors(this.$formEdit);
            this.resetSubmitButton(this.$formEdit);
            $('#removeFileFlag').remove();
        });
    }

    /** Show Edit Modal */
    showEditModal(id) {
        $.get('/FundingSource/GetById', { id })
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
    }

    /** Populate Edit Form Fields */
    populateEditForm(data) {

        $('#editFundingSourceId').val(data.fundingSourceId || 0);
        $('#editCaseId').val(data.caseId || '');
        $('#editDocumentID').val(data.documentID || 0);
        $('#editFundingSourceName').val(data.fundingSource);
        $('#editFileName').val(data.fileName);
        $('#editMU_Unit').val(data.mU_Unit);
        $('#editHV_Unit').val(data.hV_Unit);
        $('#editNotes').val(data.notes);



        if (data.fileName && data.fileName.trim() !== '') {
            $('#currentFileName').text(data.fileName);
            $('#currentFileInfo').show();
        } else {
            $('#currentFileInfo').hide();
        }

        $('#editFileUploader').val('');
        $('#removeFileFlag').remove();
    }
    /** Remove Current File */
    removeCurrentFile() {
        $('#currentFileInfo').hide();
        $('#editFileName').val('');
        $('#editDocumentID').val('');
        if ($('#removeFileFlag').length === 0) {
            this.$formEdit.append('<input type="hidden" id="removeFileFlag" name="RemoveFile" value="true" />');
        }
    }

    /** Save Funding Source (Create/Update) */
    saveFundingSource($form, url, $modal) {
        if (!this.validateForm($form)) return;

        this.setSubmitButtonLoading($form, true);
        this.hideFormErrors($form);

        const formData = new FormData($form[0]);

        const fileInput = $form.find('input[type="file"]')[0];
        if (fileInput && fileInput.files.length > 0 && fileInput.files[0].size > 10485760) {
            this.showFormError($form, 'File size must be less than 10MB');
            this.setSubmitButtonLoading($form, false);
            return;
        }

        $.ajax({
            url,
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST'
        })
            .done((response) => {
                if (response && response.success === false) {
                    this.showFormError($form, response.message || 'Failed to save funding source');
                    return;
                }

                bootstrap.Modal.getInstance($modal[0]).hide();
                this.reloadTable();
                this.showMessage('Funding source saved successfully!', 'success');

                if (typeof loadFundingInformation === 'function') {
                    loadFundingInformation();
                }
            })
            .fail((xhr) => {
                let errorMessage = 'Failed to save funding source';
                if (xhr.responseJSON && xhr.responseJSON.message) {
                    errorMessage = xhr.responseJSON.message;
                }
                this.showFormError($form, errorMessage);
            })
            .always(() => {
                this.setSubmitButtonLoading($form, false);
            });
    }

    /** Delete Funding Source */
    deleteFundingSource(id) {
        if (!confirm('Are you sure you want to delete this funding source?')) return;

        $.post('/FundingSource/Delete', { id })
            .done(() => {
                this.reloadTable();
                this.showMessage('Funding source deleted successfully!', 'success');

                if (typeof loadFundingInformation === 'function') {
                    loadFundingInformation();
                }
            })
            .fail(() => this.showMessage('Failed to delete funding source', 'error'));
    }

    /** Validate Form Fields */
    validateForm($form) {
        this.hideFormErrors($form);
        let isValid = true;
        let errorMessage = '';

        const fundingSourceField = $form.find('#FundingSource').length ?
            $form.find('#FundingSource') : $form.find('#editFundingSourceName');

        if (fundingSourceField.length === 0) {
            console.error('validateForm: Funding source field not found');
            this.showFormError($form, 'Funding source field not found');
            return false;
        }

        if (fundingSourceField.val().trim() === '') {
            errorMessage = 'Funding Source is required';
            fundingSourceField.addClass('is-invalid');
            isValid = false;
        }

        const muField = $form.find('#MU_Unit').length ? $form.find('#MU_Unit') : $form.find('#editMU_Unit');
        const hvField = $form.find('#HV_Unit').length ? $form.find('#HV_Unit') : $form.find('#editHV_Unit');

        const validatePercent = (field, label) => {
            if (field.length === 0) return true;
            const val = field.val();
            if (val !== '' && (isNaN(val) || parseFloat(val) < 0 || parseFloat(val) > 100)) {
                errorMessage = `${label} must be a number between 0 and 100`;
                field.addClass('is-invalid');
                return false;
            }
            return true;
        };

        if (!validatePercent(muField, 'MU (%)')) isValid = false;
        if (!validatePercent(hvField, 'HV (%)')) isValid = false;

        if (!isValid) {
            this.showFormError($form, errorMessage);
        }

        return isValid;
    }

    /** Show Form Error */
    showFormError($form, message) {
        const isEditForm = $form.attr('id') === 'editFundingSourceForm';
        const errorContainer = isEditForm ? $('#editFundingError') : $('#addFundingError');

        if (errorContainer.length) {
            errorContainer.find('span').text(message);
            errorContainer.show();
        } else {
            this.showMessage(message, 'error');
        }
    }

    /** Hide Form Errors */
    hideFormErrors($form) {
        const isEditForm = $form.attr('id') === 'editFundingSourceForm';
        if (isEditForm) {
            $('#editFundingError').hide();
        } else {
            $('#addFundingError').hide();
        }
        $form.find('.form-control').removeClass('is-invalid is-valid');
    }

    /** Set Submit Button Loading State */
    setSubmitButtonLoading($form, loading) {
        const $btn = $form.find('button[type="submit"]');
        // const $spinner = $btn.find('.spinner-border');
        const $text = $btn.find('span');

        if (loading) {
            // $spinner.show();
            $text.text($form.attr('id') === 'editFundingSourceForm' ? 'Updating...' : 'Saving...');
            $btn.prop('disabled', true);
        } else {
            //  $spinner.hide();
            $text.text($form.attr('id') === 'editFundingSourceForm' ? 'Save Changes' : 'Add Funding Source');
            $btn.prop('disabled', false);
        }
    }

    /** Reset Submit Button */
    resetSubmitButton($form) {
        this.setSubmitButtonLoading($form, false);
    }

    /** Reload DataTable */
    reloadTable() {
        const caseId = $('#CaseId').val() || $('#editCaseId').val();
        if (!caseId) return;

        // Fetch the raw data as JSON, not HTML
        $.get('/FundingSource/GetFundingSourcesByCaseIdJson', { caseId })
            .done((data) => {
                // Re-render the table with the new data
                this.updateTableData(data);
                this.showMessage('Table reloaded successfully.', 'success');
            })
            .fail(() => this.showMessage('Failed to reload funding sources', 'error'));
    }

    updateTableData(data) {
        // Destroy the old DataTable instance to avoid conflicts
        if ($.fn.DataTable.isDataTable(this.$table)) {
            this.$table.DataTable().destroy();
        }

        // Clear the existing table body
        this.$table.find('tbody').empty();

        // Rebuild the table rows with the new data
        let html = '';
        data.forEach(fs => {
            html += `
            <tr data-id="${fs.fundingSourceId}">
                <td>${fs.fundingSource}</td>
                <td>${fs.fileName}</td>
                <td>${fs.notes}</td>
                <td>${fs.mU_Unit}</td>
                <td>${fs.hV_Unit}</td>
                <td>${new Date(fs.createdDate).toLocaleDateString()}</td>
                <td>
                    <button class="btn btn-sm btn-warning btn-edit" data-id="${fs.fundingSourceId}">
                        <i class="fas fa-edit"></i>
                    </button>
                    <button class="btn btn-sm btn-danger btn-delete" data-id="${fs.fundingSourceId}">
                        <i class="fas fa-trash-alt"></i>
                    </button>
                </td>
            </tr>
        `;
        });
        this.$table.find('tbody').html(html);

        // Re-initialize DataTable on the new content
        this.initDataTable();
    }



    /** Reset Form */
    resetForm($form) {
        if ($form && $form.length && $form[0]) {
            $form[0].reset();
            $form.find('.form-control').removeClass('is-valid is-invalid');

            if ($form.attr('id') === 'editFundingSourceForm') {
                $('#currentFileInfo').hide();
                $('#editFileUploader').val('');
            }
        } else {
            console.warn('resetForm: Form element not found or invalid.');
        }
    }

    /** Show Bootstrap Alert Message */
    showMessage(message, type) {
        const alertClass = type === 'success' ? 'alert-success' : 'alert-danger';
        const alertHtml = `
            <div class="alert ${alertClass} alert-dismissible fade show" role="alert">
                ${message}
                <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
            </div>
        `;

        this.$messageContainer.html(alertHtml);
        setTimeout(() => this.$messageContainer.empty(), 5000);

        if (type === 'success' && typeof showSuccessMessage === 'function') {
            showSuccessMessage(message);
        }
    }
}

/** Static Helper Class */
window.FundingSource = class FundingSource {
    static LoadFundingSources(caseId, controlViewModelId = 0, targetDiv = 'divFundingSource') {
        if (!caseId) {
            console.error('CaseId is required');
            return;
        }

        $.get('/FundingSource/GetFundingSourcesById', { caseId, controlViewModelId })
            .done((html) => {
                $(`#${targetDiv}`).html(html);
                setTimeout(() => {
                    if (window.fundingSourceManager) {
                        window.fundingSourceManager = null;
                    }
                    window.fundingSourceManager = new window.FundingSourceManager();
                }, 100);
            })
            .fail(() => {
                $(`#${targetDiv}`).html('<div class="alert alert-danger">Failed to load funding sources</div>');
            });
    }

    static RefreshFundingSources() {
        if (window.fundingSourceManager) {
            // window.fundingSourceManager.reloadTable();
        }
    }
}

// Global functions for backward compatibility
window.populateEditModal = function (fundingSource) {
    if (window.fundingSourceManager) {
        window.fundingSourceManager.populateEditForm(fundingSource);
    }
};

// Auto-init
$(document).ready(() => {
    if (!window.fundingSourceManager && $('#fundingSourceTable').length > 0) {
        window.fundingSourceManager = new window.FundingSourceManager();
    }
});
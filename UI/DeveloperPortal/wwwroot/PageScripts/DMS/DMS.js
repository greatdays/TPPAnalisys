/**
 * Document Management System (DMS) JavaScript Module
 * Handles document table initialization, file upload modal, and AJAX operations
 */
class DMSManager {
    constructor() {
        this.dataTable = null;
        this.addFileModal = null;
        this.modalConfig = window.dmsModalConfig || {};
        this.config = window.dmsConfig || {};
        this.init();
    }

    /**
     * Initialize the DMS functionality
     */
    init() {
        $(document).ready(() => {
            this.initializeDataTable();
            this.bindEvents();
            this.initializeModal();
        });
    }

    /**
     * Initialize DataTable with configuration
     */
    initializeDataTable() {
        // Destroy existing DataTable if it exists
        if ($.fn.DataTable.isDataTable('#dmsDataTable')) {
            $('#dmsDataTable').DataTable().destroy();
        }

        this.dataTable = $('#dmsDataTable').DataTable({
            stripeClasses: [],
            paging: true,
            info: true,
            searching: true,
            scrollX: true,
            language: {
                emptyTable: "No documents available"
            },
            order: [[0, 'desc']], // Order by date (first column) descending
            columnDefs: [
                {
                    targets: 0, // Date column
                    type: 'date'
                },
                {
                    targets: -1, // Actions column (last column, safer than hardcoding 5)
                    orderable: false,
                    searchable: false
                }
            ],
          
            columns: [
                { data: 'UploadedDate', defaultContent: '' },
                { data: 'Name', defaultContent: '' },
                { data: 'Category', defaultContent: '' },
                { data: 'UploadedBy', defaultContent: '' },
                { data: 'Roles', defaultContent: '' },
                { data: 'actions', defaultContent: '-' } // fallback for empty actions
            ]

        });
    }


    /**
     * Initialize modal-specific functionality
     */
    initializeModal() {
        // Initialize Bootstrap modal instance
        const modalElement = document.getElementById(this.modalConfig.modalId);
        if (modalElement) {
            this.addFileModal = new bootstrap.Modal(modalElement);
        }
    }

    /**
     * Bind all event handlers
     */
    bindEvents() {
        // Show modal on Add File button click
        $('#btn-add-file').on('click', () => this.showAddFileModal());

        // Handle file upload
        $(`#${this.modalConfig.uploadButtonId}`).on('click', () => this.handleFileUpload());

        // Handle modal events
        $(`#${this.modalConfig.modalId}`).on('hidden.bs.modal', () => this.onModalHidden());
        $(`#${this.modalConfig.modalId}`).on('show.bs.modal', () => this.onModalShow());

        // File input validation
        $(`#${this.modalConfig.fileInputId}`).on('change', (e) => this.validateFile(e));

        // Form validation on input change
        $(`#${this.modalConfig.categoryId}, #${this.modalConfig.statusId}`).on('change', (e) => this.validateField(e.target));
    }

    /**
     * Show the Add File modal
     */
    showAddFileModal() {
        if (this.addFileModal) {
            this.addFileModal.show();
        }
    }

    /**
     * Handle modal show event
     */
    onModalShow() {
        this.resetUploadForm();
        this.hideError();
    }

    /**
     * Handle modal hidden event
     */
    onModalHidden() {
        this.resetUploadForm();
        this.hideError();
        //this.hideUploadSpinner();
    }

    /**
     * Validate individual form field
     * @param {HTMLElement} field - The form field to validate
     */
    validateField(field) {
        const $field = $(field);
        const value = $field.val();
        const isValid = value && value.trim() !== '';

        if (isValid) {
            $field.removeClass('is-invalid').addClass('is-valid');
        } else {
            $field.removeClass('is-valid').addClass('is-invalid');
        }

        return isValid;
    }

    /**
     * Validate selected file
     * @param {Event} event - File input change event
     */
    validateFile(event) {
        const file = event.target.files[0];
        const $fileInput = $(event.target);

        if (!file) {
            $fileInput.removeClass('is-valid').addClass('is-invalid');
            return false;
        }

        // Check file size
        if (this.modalConfig.maxFileSize && file.size > this.modalConfig.maxFileSize) {
            this.showError(`File size exceeds maximum limit of ${this.formatFileSize(this.modalConfig.maxFileSize)}`);
            $fileInput.removeClass('is-valid').addClass('is-invalid');
            return false;
        }

        // Check file extension
        if (this.modalConfig.allowedExtensions && this.modalConfig.allowedExtensions.length > 0) {
            const fileExtension = '.' + file.name.split('.').pop().toLowerCase();
            if (!this.modalConfig.allowedExtensions.includes(fileExtension)) {
                this.showError('File type not allowed. Please select a supported file format.');
                $fileInput.removeClass('is-valid').addClass('is-invalid');
                return false;
            }
        }

        $fileInput.removeClass('is-invalid').addClass('is-valid');
        this.hideError();
        return true;
    }

    /**
     * Validate entire form
     * @returns {boolean} - Whether the form is valid
     */
    validateForm() {
        const categoryValid = this.validateField(document.getElementById(this.modalConfig.categoryId));

        const fileInput = document.getElementById(this.modalConfig.fileInputId);
        const fileValid = fileInput.files.length > 0 && this.validateFile({ target: fileInput });

        return categoryValid && fileValid;
    }

    /**
     * Handle file upload process
     */
    handleFileUpload() {
        if (!this.validateForm()) {
            this.showError('Please fill in all required fields and select a valid file.');
            return;
        }

        const files = $(`#${this.modalConfig.fileInputId}`).get(0).files;

        if (files.length === 0) {
            this.showError("Please select a file to upload.");
            return;
        }

        const formData = this.buildFormData(files[0]);
        const uploadUrl = this.getUploadUrl();

        console.log(uploadUrl);

        this.performUpload(formData, uploadUrl);
    }

    /**
     * Build FormData object for file upload
     * @param {File} file - The selected file
     * @returns {FormData} - Formatted form data
     */
    buildFormData(file) {
        const formData = new FormData();

        // The controller expects the file as the first form file
        formData.append("", file); // Empty name as controller accesses Files[0]

        // Add form fields as expected by the existing controller
        formData.append("ProjectId", $('#ProjectId').val());
        formData.append("FolderName", $('#FolderName').val());
        formData.append("FolderId", $('#FolderId').val());

        // Add additional fields for potential future use
        formData.append("Category", $(`#${this.modalConfig.categoryId}`).val());

        // Add description if provided
        const description = $(`#${this.modalConfig.descriptionId}`).val();
        if (description && description.trim() !== '') {
            formData.append("Description", description.trim());
        }

        return formData;
    }

    /**
     * Get the upload URL
     * @returns {string} - Upload URL
     */
    getUploadUrl() {
        return this.config.uploadUrl || '/Document/DMS/UploadFile';
    }

    /**
     * Perform the AJAX file upload
     * @param {FormData} formData - Form data to upload
     * @param {string} url - Upload URL
     */
    performUpload(formData, url) {
       // this.showUploadSpinner();
        this.hideError();
        this.disableUploadButton();
        console.log("url" + url)
        $.ajax({
            url: url,
            data: formData,
            processData: false,
            contentType: false,
            type: "POST",
            success: (data) => this.handleUploadSuccess(data),
            error: (xhr, status, error) => this.handleUploadError(xhr, status, error),
            complete: () => this.enableUploadButton()
        });
    }

    /**
     * Handle successful file upload
     * @param {Object} data - Response data (folder path from controller)
     */
    handleUploadSuccess(data) {
        //this.hideUploadSpinner();

        // The controller returns the folder path as JSON
        if (data) {
            this.showSuccess('File uploaded successfully!');

            // Close modal after a brief delay to show success message
            setTimeout(() => {
                this.addFileModal.hide();
            }, 1000);

            // Wait for modal to close, then reload Documents tab
            $(`#${this.modalConfig.modalId}`).one('hidden.bs.modal', () => {
                this.reloadDocumentsTab();
            });
        } else {
            this.showError('Upload completed but no response received');
        }
    }

    /**
     * Handle upload error
     * @param {Object} xhr - XMLHttpRequest object
     * @param {string} status - Status text
     * @param {string} error - Error message
     */
    handleUploadError(xhr, status, error) {
        //this.hideUploadSpinner();
        let errorMessage = "Upload failed. Please try again.";

        // Handle different types of error responses
        if (xhr.responseJSON) {
            if (typeof xhr.responseJSON === 'string') {
                errorMessage = xhr.responseJSON;
            } else if (xhr.responseJSON.message) {
                errorMessage = xhr.responseJSON.message;
            }
        } else if (xhr.responseText) {
            try {
                const responseObj = JSON.parse(xhr.responseText);
                errorMessage = responseObj.message || responseObj.error || xhr.responseText;
            } catch (e) {
                errorMessage = xhr.responseText;
            }
        }

        this.showError(errorMessage);
    }

    /**
     * Show error message in modal
     * @param {string} message - Error message to display
     */
    showError(message) {
        $('#uploadError').show();
        $('#uploadErrorMessage').text(message);
    }

    /**
     * Hide error message
     */
    hideError() {
        $('#uploadError').hide();
        $('#uploadErrorMessage').text('');
    }

    /**
     * Show success message (can be enhanced with a success alert)
     * @param {string} message - Success message
     */
    showSuccess(message) {
        // You can implement a success notification here
        console.log('Upload successful:', message);
    }

    /**
     * Show upload spinner and update button text
     */
    //showUploadSpinner() {
    //    $('#uploadSpinner').show();
    //    $('#uploadButtonText').text('Uploading...');
    //}

    ///**
    // * Hide upload spinner and reset button text
    // */
    //hideUploadSpinner() {
    //    $('#uploadSpinner').hide();
    //    $('#uploadButtonText').text('Upload');
    //}

    /**
     * Disable upload button during upload
     */
    disableUploadButton() {
        $(`#${this.modalConfig.uploadButtonId}`).prop('disabled', true);
    }

    /**
     * Enable upload button
     */
    enableUploadButton() {
        $(`#${this.modalConfig.uploadButtonId}`).prop('disabled', false);
    }

    /**
     * Reload the documents tab content
     */
    reloadDocumentsTab() {
        const caseId = $('#ProjectId').val();
        const controlViewModelId = $('#FolderId').val();

       // this.showLoader();

        $.ajax({
            url: 'Document/DMS/GetFilesById', // Match your existing route
            type: 'GET',
            data: {
                caseId: parseInt(caseId), // Convert to int as expected by controller
                controlViewModelId: parseInt(controlViewModelId) // Convert to int as expected by controller
            },
            success: (html) => {
                $('#divDocument').html(html);
               // this.hideLoader();
                // Reinitialize DataTable after content reload
                setTimeout(() => {
                    this.initializeDataTable();
                }, 100); // Small delay to ensure DOM is updated
            },
            error: (xhr) => {
                this.hideLoader();
                console.error('Reload error:', xhr);
                alert("Failed to reload documents tab. Please refresh the page.");
            }
        });
    }

    /**
     * Show loading overlay
     */
    //showLoader() {
    //    $('#loadingOverlay').show();
    //}

    /**
     * Hide loading overlay
     */
   /* hideLoader() {
        $('#loadingOverlay').hide();
    }*/

    /**
     * Reset the upload form
     */
    resetUploadForm() {
        const form = document.getElementById(this.modalConfig.formId);
        if (form) {
            form.reset();
        }

        // Reset validation classes
        $(`#${this.modalConfig.categoryId}, #${this.modalConfig.statusId}, #${this.modalConfig.fileInputId}`)
            .removeClass('is-valid is-invalid');
    }

    /**
     * Format file size for display
     * @param {number} bytes - File size in bytes
     * @returns {string} - Formatted file size
     */
    formatFileSize(bytes) {
        if (bytes === 0) return '0 Bytes';
        const k = 1024;
        const sizes = ['Bytes', 'KB', 'MB', 'GB'];
        const i = Math.floor(Math.log(bytes) / Math.log(k));
        return parseFloat((bytes / Math.pow(k, i)).toFixed(2)) + ' ' + sizes[i];
    }

    /**
     * Refresh the data table
     */
    refreshDataTable() {
        if (this.dataTable) {
            this.dataTable.ajax.reload();
        }
    }

    /**
     * Destroy and cleanup
     */
    destroy() {
        if (this.dataTable) {
            this.dataTable.destroy();
        }

        // Unbind events
        $('#btn-add-file').off('click');
        $(`#${this.modalConfig.uploadButtonId}`).off('click');
        $(`#${this.modalConfig.modalId}`).off('hidden.bs.modal show.bs.modal');
        $(`#${this.modalConfig.fileInputId}`).off('change');
        $(`#${this.modalConfig.categoryId}, #${this.modalConfig.statusId}`).off('change');
    }
}

/**
 * Static DMS Class for external tab loading functionality
 * This provides a simple interface similar to SiteInformation.LoadSiteInformation()
 */
 class DMS {
    /**
     * Load DMS documents view - Main entry point for tab switching
     * @param {number} caseId - Project/Case ID
     * @param {number} controlViewModelId - Control View Model ID (optional)
     * @param {string} targetDiv - Target div ID to load content into (default: 'divDocument')
     */
     static LoadDocuments(caseId, controlViewModelId = 0, targetDiv = 'divDocument') {
        // Show loading overlay
       // DMS.ShowLoader();

        const url = 'Document/DMS/GetFilesById';

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
                $(`#${targetDiv}`).html(`
                    <div class="alert alert-danger" role="alert">
                        <h4 class="alert-heading">Error Loading Documents</h4>
                        <p>Failed to load documents. Please try again.</p>
                        <hr>
                        <p class="mb-0">
                            <button class="btn btn-outline-danger" onclick="DMS.LoadDocuments(${caseId}, ${controlViewModelId}, '${targetDiv}')">
                                <i class="fas fa-redo"></i> Retry
                            </button>
                        </p>
                    </div>
                `);
            }
        });
    }

    /**
     * Initialize DMS with configuration
     * @param {object} config - DMS configuration object
     */
    static Initialize(config = {}) {
        window.dmsConfig = { ...window.dmsConfig, ...config };
    }

    /**
     * Show global loader
     */
   /* static ShowLoader() {
        let loader = $('#dmsGlobalLoader');
        if (loader.length === 0) {
            // Create loader if it doesn't exist
            $('body').append(`
                <div id="dmsGlobalLoader" style="display:none; position:fixed; top:0; left:0; width:100%; height:100%; background:rgba(255,255,255,0.8); z-index:1055; text-align:center; padding-top:20%;">
                    <div class="spinner-border text-primary" role="status" style="width: 4rem; height: 4rem;">
                        <span class="visually-hidden">Loading documents...</span>
                    </div>
                    <div style="margin-top: 10px; font-weight: bold;">Loading documents...</div>
                </div>
            `);
            loader = $('#dmsGlobalLoader');
        }
        loader.show();
    }*/

    /**
     * Hide global loader
     */
   /* static HideLoader() {
        $('#dmsGlobalLoader').hide();
    }*/

    /**
     * Refresh current documents view
     */
    static RefreshDocuments() {
        if (window.dmsManager) {
            window.dmsManager.reloadDocumentsTab();
        }
    }

    /**
     * Get current DMS manager instance
     * @returns {DMSManager|null} Current DMS manager instance
     */
    static GetManager() {
        return window.dmsManager || null;
    }

    /**
     * Check if DMS is currently loaded
     * @returns {boolean} Whether DMS is loaded
     */
    static IsLoaded() {
        return window.dmsManager !== null && $('#dmsDataTable').length > 0;
    }
}

// Global configuration object (to be populated from server-side)
window.dmsConfig = window.dmsConfig || {};
window.dmsModalConfig = window.dmsModalConfig || {};

// Make DMS available globally
window.DMS = DMS;

// Initialize DMS when DOM is ready (for backward compatibility)
$(document).ready(function () {
    // Only initialize if we're on a page that has the DMS table
    if ($('#dmsDataTable').length > 0) {
        window.dmsManager = new DMSManager();
    }
});

// Export for module usage if needed
if (typeof module !== 'undefined' && module.exports) {
    module.exports = { DMSManager, DMS };
}
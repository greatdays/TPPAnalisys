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
        //$(document).ready(() => {
        $(() => {
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
        if ($.fn.DataTable && $.fn.DataTable.isDataTable('#dmsDataTable')) {
            $('#dmsDataTable').DataTable().destroy();
        }

        // Only initialize if the table exists
        if ($('#dmsDataTable').length === 0) {
            console.warn('DMS DataTable element not found');
            return;
        }

        this.dataTable = $('#dmsDataTable').DataTable({
            stripeClasses: [],
            paging: true,
            info: true,
            searching: true,
            scrollX: true,
            responsive: true,
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
                    targets: -1, // Actions column (last column)
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
            ],
            error: function (xhr, error, code) {
                console.error('DataTable error:', error);
            }
        });
    }

    /**
     * Initialize modal-specific functionality
     */
    initializeModal() {
        // Initialize Bootstrap modal instance
        const modalElement = document.getElementById(this.modalConfig.modalId);
        if (modalElement && typeof bootstrap !== 'undefined') {
            this.addFileModal = new bootstrap.Modal(modalElement);
        } else if (modalElement) {
            // Fallback for older Bootstrap versions
            this.addFileModal = $(modalElement);
        } else {
            console.warn('Modal element not found:', this.modalConfig.modalId);
        }
    }

    /**
     * Bind all event handlers
     */
    bindEvents() {
        // Show modal on Add File button click
        $('#btn-add-file').off('click').on('click', (e) => {
            e.preventDefault();
            this.showAddFileModal();
        });

        // Handle file upload
        $(`#${this.modalConfig.uploadButtonId}`).off('click').on('click', (e) => {
            e.preventDefault();
            this.handleFileUpload();
        });

        // Handle modal events
        if (this.modalConfig.modalId) {
            $(`#${this.modalConfig.modalId}`)
                .off('hidden.bs.modal')
                .on('hidden.bs.modal', () => this.onModalHidden())
                .off('show.bs.modal')
                .on('show.bs.modal', () => this.onModalShow());
        }

        // File input validation
        if (this.modalConfig.fileInputId) {
            $(`#${this.modalConfig.fileInputId}`)
                .off('change')
                .on('change', (e) => this.validateFile(e));
        }

        // Form validation on input change
        if (this.modalConfig.categoryId || this.modalConfig.statusId) {
            $(`#${this.modalConfig.categoryId}, #${this.modalConfig.statusId}`)
                .off('change')
                .on('change', (e) => this.validateField(e.target));
        }
    }

    /**
     * Show the Add File modal
     */
    showAddFileModal() {
        if (this.addFileModal) {
            if (typeof this.addFileModal.show === 'function') {
                this.addFileModal.show();
            } else {
                // Fallback for jQuery modal
                this.addFileModal.modal('show');
            }
        } else {
            console.warn('Modal not initialized');
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
    }

    /**
     * Validate individual form field
     * @param {HTMLElement} field - The form field to validate
     */
    validateField(field) {
        if (!field) return false;

        const $field = $(field);
        const value = $field.val();
        const isValid = value && value.toString().trim() !== '';

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
        let isValid = true;

        // Validate category if required
        if (this.modalConfig.categoryId) {
            const categoryValid = this.validateField(document.getElementById(this.modalConfig.categoryId));
            isValid = isValid && categoryValid;
        }

        // Validate file
        if (this.modalConfig.fileInputId) {
            const fileInput = document.getElementById(this.modalConfig.fileInputId);
            const fileValid = fileInput && fileInput.files.length > 0 && this.validateFile({ target: fileInput });
            isValid = isValid && fileValid;
        }

        return isValid;
    }

    /**
     * Handle file upload process
     */
    handleFileUpload() {
        if (!this.validateForm()) {
            this.showError('Please fill in all required fields and select a valid file.');
            return;
        }

        const fileInputId = this.modalConfig.fileInputId;
        if (!fileInputId) {
            this.showError('File input not configured');
            return;
        }

        const files = $(`#${fileInputId}`).get(0).files;

        if (files.length === 0) {
            this.showError("Please select a file to upload.");
            return;
        }

        const formData = this.buildFormData(files[0]);
        const uploadUrl = this.getUploadUrl();

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

        // Add form fields with null checks
        const projectId = $('#ProjectId').val();
        const folderName = $('#FolderName').val();
        const folderId = $('#FolderId').val();

        if (projectId) formData.append("ProjectId", projectId);
        if (folderName) formData.append("FolderName", folderName);
        if (folderId) formData.append("FolderId", folderId);

        // Add additional fields for potential future use
        if (this.modalConfig.categoryId) {
            const category = $(`#${this.modalConfig.categoryId}`).val();
            if (category) formData.append("Category", category);
        }

        // Add description if provided
        if (this.modalConfig.descriptionId) {
            const description = $(`#${this.modalConfig.descriptionId}`).val();
            if (description && description.trim() !== '') {
                formData.append("Description", description.trim());
            }
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
        this.hideError();
        this.disableUploadButton();
        LoadingOverlay.show();

        $.ajax({
            url: url,
            data: formData,
            processData: false,
            contentType: false,
            type: "POST",
            timeout: 300000, // 5 minutes timeout
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
        if (data) {
            this.showSuccess('File uploaded successfully!');

            // Close modal after a brief delay to show success message
            setTimeout(() => {
                if (this.addFileModal) {
                    if (typeof this.addFileModal.hide === 'function') {
                        this.addFileModal.hide();
                        LoadingOverlay.hide();
                    } else {
                        this.addFileModal.modal('hide');
                        LoadingOverlay.hide();
                    }
                }
            }, 1000);

            // Wait for modal to close, then reload Documents tab
            if (this.modalConfig.modalId) {
                $(`#${this.modalConfig.modalId}`).one('hidden.bs.modal', () => {
                    this.reloadDocumentsTab();
                });
            } else {
                // Fallback if no modal ID
                setTimeout(() => {
                    this.reloadDocumentsTab();
                }, 1500);
            }
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
        let errorMessage = "Upload failed. Please try again.";

        try {
            // Handle different types of error responses
            if (xhr.responseJSON) {
                if (typeof xhr.responseJSON === 'string') {
                    errorMessage = xhr.responseJSON;
                } else if (xhr.responseJSON.message) {
                    errorMessage = xhr.responseJSON.message;
                } else if (xhr.responseJSON.error) {
                    errorMessage = xhr.responseJSON.error;
                }
            } else if (xhr.responseText) {
                try {
                    const responseObj = JSON.parse(xhr.responseText);
                    errorMessage = responseObj.message || responseObj.error || xhr.responseText;
                } catch (parseError) {
                    errorMessage = xhr.responseText;
                }
            }

            // Handle specific HTTP status codes
            if (xhr.status === 413) {
                errorMessage = "File is too large. Please select a smaller file.";
            } else if (xhr.status === 415) {
                errorMessage = "Unsupported file type. Please select a supported file format.";
            } else if (xhr.status === 0 && status === 'timeout') {
                errorMessage = "Upload timed out. Please try again with a smaller file.";
            }
        } catch (e) {
            console.error('Error parsing upload error response:', e);
        }

        this.showError(errorMessage);
    }

    /**
     * Show error message in modal
     * @param {string} message - Error message to display
     */
    showError(message) {
        const errorElement = $('#uploadError');
        const messageElement = $('#uploadErrorMessage');

        if (errorElement.length && messageElement.length) {
            errorElement.show();
            messageElement.text(message);
        } else {
            console.error('Upload Error:', message);
            // Fallback alert if error elements don't exist
            alert('Upload Error: ' + message);
        }
    }

    /**
     * Hide error message
     */
    hideError() {
        $('#uploadError').hide();
        $('#uploadErrorMessage').text('');
    }

    /**
     * Show success message
     * @param {string} message - Success message
     */
    showSuccess(message) {
        const successElement = $('#uploadSuccess');
        const messageElement = $('#uploadSuccessMessage');

        if (successElement.length && messageElement.length) {
            successElement.show();
            messageElement.text(message);
            // Auto-hide after 3 seconds
            setTimeout(() => {
                successElement.hide();
            }, 3000);
        } else {
            console.log('Upload successful:', message);
        }
    }

    /**
     * Disable upload button during upload
     */
    disableUploadButton() {
        if (this.modalConfig.uploadButtonId) {
            const $button = $(`#${this.modalConfig.uploadButtonId}`);
            $button.prop('disabled', true);

            // Store original text if not already stored
            if (!$button.data('original-text')) {
                $button.data('original-text', $button.text());
            }
            $button.text('Uploading...');
        }
    }

    /**
     * Enable upload button
     */
    enableUploadButton() {
        if (this.modalConfig.uploadButtonId) {
            const $button = $(`#${this.modalConfig.uploadButtonId}`);
            $button.prop('disabled', false);

            // Restore original text
            const originalText = $button.data('original-text');
            if (originalText) {
                $button.text(originalText);
            }
        }
    }

    /**
     * Reload the documents tab content
     */
    reloadDocumentsTab() {
        const caseId = $('#ProjectId').val();
        const controlViewModelId = $('#FolderId').val();

        if (!caseId) {
            console.error('ProjectId not found for reload');
            return;
        }

        $.ajax({
            url: 'Document/DMS/GetFilesById',
            type: 'GET',
            data: {
                caseId: parseInt(caseId) || 0,
                controlViewModelId: parseInt(controlViewModelId) || 0
            },
            success: (html) => {
                $('#divDocument').html(html);

                // Reinitialize DataTable after content reload
                setTimeout(() => {
                    this.initializeDataTable();
                }, 100);
            },
            error: (xhr) => {
                console.error('Reload error:', xhr);
                const errorMsg = "Failed to reload documents tab. Please refresh the page.";

                if ($('#divDocument').length) {
                    $('#divDocument').html(`
                        <div class="alert alert-danger" role="alert">
                            ${errorMsg}
                            <button class="btn btn-outline-danger btn-sm ms-2" onclick="location.reload()">
                                Refresh Page
                            </button>
                        </div>
                    `);
                } else {
                    alert(errorMsg);
                }
            }
        });
    }

    /**
     * Reset the upload form
     */
    resetUploadForm() {
        if (this.modalConfig.formId) {
            const form = document.getElementById(this.modalConfig.formId);
            if (form) {
                form.reset();
            }
        }

        // Reset validation classes
        const elementsToReset = [
            this.modalConfig.categoryId,
            this.modalConfig.statusId,
            this.modalConfig.fileInputId,
            this.modalConfig.descriptionId
        ].filter(Boolean);

        elementsToReset.forEach(id => {
            $(`#${id}`).removeClass('is-valid is-invalid');
        });

        // Hide success message
        $('#uploadSuccess').hide();
    }

    /**
     * Format file size for display
     * @param {number} bytes - File size in bytes
     * @returns {string} - Formatted file size
     */
    formatFileSize(bytes) {
        if (bytes === 0) return '0 Bytes';
        const k = 1024;
        const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB'];
        const i = Math.floor(Math.log(bytes) / Math.log(k));
        return parseFloat((bytes / Math.pow(k, i)).toFixed(2)) + ' ' + sizes[i];
    }

    /**
     * Refresh the data table
     */
    refreshDataTable() {
        if (this.dataTable && typeof this.dataTable.ajax !== 'undefined') {
            this.dataTable.ajax.reload();
        } else if (this.dataTable) {
            this.dataTable.draw();
        }
    }

    /**
     * Destroy and cleanup
     */
    destroy() {
        try {
            // Destroy DataTable
            if (this.dataTable && $.fn.DataTable.isDataTable('#dmsDataTable')) {
                this.dataTable.destroy();
                this.dataTable = null;
            }

            // Unbind events
            $('#btn-add-file').off('click');

            if (this.modalConfig.uploadButtonId) {
                $(`#${this.modalConfig.uploadButtonId}`).off('click');
            }

            if (this.modalConfig.modalId) {
                $(`#${this.modalConfig.modalId}`).off('hidden.bs.modal show.bs.modal');
            }

            if (this.modalConfig.fileInputId) {
                $(`#${this.modalConfig.fileInputId}`).off('change');
            }

            if (this.modalConfig.categoryId || this.modalConfig.statusId) {
                $(`#${this.modalConfig.categoryId}, #${this.modalConfig.statusId}`).off('change');
            }

            // Clean up modal reference
            this.addFileModal = null;
        } catch (error) {
            console.error('Error during DMS cleanup:', error);
        }
    }
}

/**
 * Static DMS Class for external tab loading functionality
 */
class DMS {
    /**
     * Load DMS documents view - Main entry point for tab switching
     * @param {number} caseId - Project/Case ID
     * @param {number} controlViewModelId - Control View Model ID (optional)
     * @param {string} targetDiv - Target div ID to load content into (default: 'divDocument')
     */
    static LoadDocuments(caseId, controlViewModelId = 0, targetDiv = 'divDocument') {
        if (!caseId) {
            console.error('CaseId is required for LoadDocuments');
            return;
        }

        const url = 'Document/DMS/GetFilesById';

        $.ajax({
            url: url,
            type: 'GET',
            data: {
                caseId: parseInt(caseId) || 0,
                controlViewModelId: parseInt(controlViewModelId) || 0
            },
            success: function (html) {
                $(`#${targetDiv}`).html(html);

                // Initialize DMS Manager after content is loaded
                setTimeout(() => {
                    if (window.dmsManager) {
                        window.dmsManager.destroy(); // Clean up existing instance
                    }
                    window.dmsManager = new DMSManager();
                }, 100);
            },
            error: function (xhr, status, error) {
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
     * Refresh current documents view
     */
    static RefreshDocuments() {
        if (window.dmsManager) {
            window.dmsManager.reloadDocumentsTab();
        } else {
            console.warn('DMS Manager not initialized');
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
        return !!(window.dmsManager && $('#dmsDataTable').length > 0);
    }
}

// Global configuration objects
window.dmsConfig = window.dmsConfig || {};
window.dmsModalConfig = window.dmsModalConfig || {};

// Make DMS available globally
window.DMS = DMS;

// Initialize DMS when DOM is ready (for backward compatibility)
$(document).ready(function () {
    // Only initialize if we're on a page that has the DMS table
    if ($('#dmsDataTable').length > 0) {
        // Clean up any existing instance first
        if (window.dmsManager) {
            window.dmsManager.destroy();
        }
        window.dmsManager = new DMSManager();
    }
});

// Export for module usage if needed
if (typeof module !== 'undefined' && module.exports) {
    module.exports = { DMSManager, DMS };
}
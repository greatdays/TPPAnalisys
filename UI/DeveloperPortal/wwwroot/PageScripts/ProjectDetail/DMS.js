/**
 * Document Management System (DMS) JavaScript Module
 * Handles document table initialization, file upload modal, and AJAX operations
 * Fixed version - prevents double file upload issue
 */
window.DMSManager = class DMSManager {
    constructor() {
        this.dataTable = null;
        this.addFileModal = null;
        this.modalConfig = window.dmsModalConfig || {};
        this.config = window.dmsConfig || {};
        this.$table = null;
        this.isInitialized = false;
        this.isUploading = false; // Add upload state tracking

        // Bind methods to the class instance to maintain `this` context
        this.bindEvents = this.bindEvents.bind(this);
        this.handleFileUpload = this.handleFileUpload.bind(this);
        this.reloadDocumentsTab = this.reloadDocumentsTab.bind(this);
    }

    /**
     * Initializes the DMS functionality.
     */
    init() {
        // Destroy any existing instance first
        if (window.dmsManager && window.dmsManager !== this) {
            console.log("Destroying existing DMSManager instance");
            window.dmsManager.destroy();
        }

        if (this.isInitialized) {
            console.warn("DMSManager is already initialized. Skipping.");
            return;
        }

        this.$table = $("#dmsDataTable");
        if (this.$table.length === 0) {
            console.warn("DMSManager: #dmsDataTable not found. Skipping.");
            return;
        }

        this.initializeDataTable();
        this.initializeModal();
        this.bindEvents();
        this.isInitialized = true;

        // Set the global reference
        window.dmsManager = this;
        console.log("DMSManager initialized successfully");
    }

    /**
     * Initialize DataTable.
     * This function is called every time the table content is reloaded to ensure
     * DataTables correctly recognizes the new data.
     */
    initializeDataTable() {
        if (!$.fn.DataTable) {
            console.error("DataTables plugin not loaded");
            return;
        }

        try {
            // Check if a DataTable instance already exists and destroy it
            // before re-initialization to prevent conflicts.
            if (this.$table === null) { this.$table = $("#dmsDataTable"); }
            if ($.fn.DataTable.isDataTable(this.$table)) {
                this.$table.DataTable().destroy();
                // Note: Clearing the table content is now done by the server-rendered HTML
                // in the reloadDocumentsTab method, so we don't need to empty it here.
            }

            // Initialize the DataTable with the provided configuration.
            this.dataTable = this.$table.DataTable({
                paging: true,
                searching: true,
                ordering: true,
                responsive: true,
                language: { emptyTable: "No documents available" },
                columnDefs: [
                    { targets: -1, orderable: false, searchable: false } // Last column (Actions)
                ]
            });
        } catch (error) {
            console.error("Error initializing DataTable:", error);
            // This error often indicates a mismatch between the number of <thead> columns and <tbody> data cells.
            this.handleDataTableError();
        }
    }

    /**
     * Handle DataTable init errors by displaying a user-friendly message.
     */
    handleDataTableError() {
        this.$table.html(
            `<div class="alert alert-warning"><h5>Table Loading Issue</h5>
             <p>Could not initialize documents table. This may be due to a server-side error, missing table structure, or JavaScript conflicts.</p>
             <button class="btn btn-outline-warning btn-sm" onclick="location.reload()">Refresh</button>
             </div>`
        );
    }

    /**
     * Modal setup.
     */
    initializeModal() {
        const el = document.getElementById(this.modalConfig.modalId);
        if (el) {
            // Use native Bootstrap.Modal if available, fall back to jQuery.
            this.addFileModal = typeof bootstrap !== "undefined" ? new bootstrap.Modal(el) : $(el);
        }
    }

    /**
     * Binds all necessary event listeners for the DMS module.
     * Fixed version with proper namespacing to prevent duplicate handlers.
     */
    bindEvents() {
        // First, unbind any existing DMS events to prevent duplicates
        $(document).off(".dms");

        // Event for the "Add Document" button with namespace
        $(document).on("click.dms", "#btn-add-file", (e) => {
            e.preventDefault();
            this.showAddFileModal();
        });

        // Event for the file upload button inside the modal with namespace
        if (this.modalConfig.uploadButtonId) {
            $(document).on("click.dms", `#${this.modalConfig.uploadButtonId}`, (e) => {
                e.preventDefault();
                this.handleFileUpload();
            });
        }

        // Events for the upload modal to reset the form with namespace
        if (this.modalConfig.modalId) {
            const sel = `#${this.modalConfig.modalId}`;
            $(document).on("hidden.bs.modal.dms", sel, () => this.onModalHidden());
            $(document).on("show.bs.modal.dms", sel, () => this.onModalShow());
        }

        // Event to validate the file input on change with namespace
        if (this.modalConfig.fileInputId) {
            $(document).on("change.dms", `#${this.modalConfig.fileInputId}`, (e) => this.validateFile(e));
        }
    }

    /**
     * Shows the file upload modal.
     */
    showAddFileModal() {
        if (this.addFileModal) {
            typeof this.addFileModal.show === "function"
                ? this.addFileModal.show()
                : this.addFileModal.modal("show");
        }
    }

    onModalShow() {
        this.resetUploadForm();
        this.hideError();
    }

    onModalHidden() {
        this.resetUploadForm();
        this.hideError();
        this.isUploading = false; // Reset upload state when modal is hidden
    }

    /**
     * Resets the file upload form fields and styling.
     */
    resetUploadForm() {
        if (this.modalConfig.fileInputId) {
            $(`#${this.modalConfig.fileInputId}`).val("").removeClass("is-valid is-invalid");
        }
        if (this.modalConfig.categoryId) {
            $(`#${this.modalConfig.categoryId}`).val("").removeClass("is-valid is-invalid");
        }
        if (this.modalConfig.statusId) {
            $(`#${this.modalConfig.statusId}`).val("").removeClass("is-valid is-invalid");
        }
        if (this.modalConfig.descriptionId) {
            $(`#${this.modalConfig.descriptionId}`).val("").removeClass("is-valid is-invalid");
        }
        this.hideError();
        $("#uploadSuccess").hide();
        $("#uploadSuccessMessage").text("");
    }

    /**
     * Validates a single form field to ensure it is not empty.
     * @param {HTMLElement} field - The DOM element of the field to validate.
     * @returns {boolean} - True if the field is valid, otherwise false.
     */
    validateField(field) {
        if (!field) return false;
        const $f = $(field);
        const valid = $f.val()?.toString().trim() !== "";
        $f.toggleClass("is-valid", valid).toggleClass("is-invalid", !valid);
        return valid;
    }

    /**
     * Validates the file input against size and extension constraints.
     * @param {Event} event - The change event from the file input.
     * @returns {boolean} - True if the file is valid, otherwise false.
     */
    validateFile(event) {
        const file = event.target.files[0];
        const $f = $(event.target);

        if (!file) {
            $f.removeClass("is-valid").addClass("is-invalid");
            return false;
        }

        if (this.modalConfig.maxFileSize && file.size > this.modalConfig.maxFileSize) {
            this.showError(`File too large. Max: ${this.formatFileSize(this.modalConfig.maxFileSize)}`);
            $f.removeClass("is-valid").addClass("is-invalid");
            return false;
        }

        if (this.modalConfig.allowedExtensions?.length > 0) {
            const ext = "." + file.name.split(".").pop().toLowerCase();
            if (!this.modalConfig.allowedExtensions.includes(ext)) {
                this.showError("File type not allowed.");
                $f.removeClass("is-valid").addClass("is-invalid");
                return false;
            }
        }

        $f.removeClass("is-invalid").addClass("is-valid");
        this.hideError();
        return true;
    }

    /**
     * Validates the entire upload form before submission.
     * @returns {boolean} - True if the form is valid, otherwise false.
     */
    validateForm() {
        const fileInput = document.getElementById(this.modalConfig.fileInputId);
        let valid = !!fileInput && fileInput.files.length > 0 && this.validateFile({ target: fileInput });
        if (this.modalConfig.categoryId) {
            valid = valid && this.validateField(document.getElementById(this.modalConfig.categoryId));
        }
        return valid;
    }

    /**
     * Handles the file upload process, from validation to AJAX submission.
     * Fixed version with proper duplicate upload prevention.
     */
    handleFileUpload() {
        console.log("handleFileUpload called - timestamp:", Date.now());

        // Prevent multiple simultaneous uploads
        if (this.isUploading) {
            console.log("Upload already in progress, ignoring duplicate request");
            return;
        }

        const uploadButton = $(`#${this.modalConfig.uploadButtonId}`);
        if (uploadButton.prop('disabled')) {
            console.log("Upload button is disabled, ignoring request");
            return;
        }

        if (!this.validateForm()) {
            this.showError("Please fill all required fields with a valid file.");
            return;
        }

        const files = $(`#${this.modalConfig.fileInputId}`).get(0)?.files;
        if (!files?.length) {
            this.showError("Please select a file.");
            return;
        }

        // Set upload state
        this.isUploading = true;

        const formData = this.buildFormData(files[0]);
        this.performUpload(formData, this.getUploadUrl());
    }

    /**
     * Builds the FormData object for the file upload.
     * @param {File} file - The file to upload.
     * @returns {FormData} - The FormData object.
     */
    buildFormData(file) {
        const fd = new FormData();
        fd.append("file", file);

        ["ProjectId", "FolderName", "FolderId"].forEach((f) => {
            const v = $(`#${f}`).val();
            if (v) fd.append(f, v);
        });

        if (this.modalConfig.categoryId) {
            const cat = $(`#${this.modalConfig.categoryId}`).val();
            if (cat) fd.append("Category", cat);
        }
        if (this.modalConfig.descriptionId) {
            const desc = $(`#${this.modalConfig.descriptionId}`).val();
            if (desc?.trim()) fd.append("Description", desc.trim());
        }
        return fd;
    }

    getUploadUrl() {
        return this.config.uploadUrl || "/DMS/UploadFile";
    }

    /**
     * Performs the AJAX request to upload the file.
     * @param {FormData} fd - The FormData object.
     * @param {string} url - The upload URL.
     */
    performUpload(fd, url) {
        this.hideError();
        this.disableUploadButton();
        typeof LoadingOverlay !== "undefined" && LoadingOverlay.show();

        $.ajax({
            url,
            data: fd,
            processData: false,
            contentType: false,
            type: "POST",
            timeout: 300000,
            success: this.handleUploadSuccess.bind(this),
            error: this.handleUploadError.bind(this),
            complete: () => {
                this.enableUploadButton();
                this.isUploading = false; // Reset upload state
                typeof LoadingOverlay !== "undefined" && LoadingOverlay.hide();
            }
        });
    }

    /**
     * Handles a successful upload response.
     */
    handleUploadSuccess() {
        this.showSuccess("File uploaded successfully!");
        // Hide the modal using the correct method based on its type.
        if (this.addFileModal) {
            typeof this.addFileModal.hide === "function"
                ? this.addFileModal.hide()
                : this.addFileModal.modal("hide");
        }
        this.reloadDocumentsTab();
    }

    /**
     * Handles a failed upload response and displays an error message.
     * @param {object} xhr - The XMLHttpRequest object from the failed request.
     */
    handleUploadError(xhr) {
        let msg = "Upload failed.";
        try {
            const res = xhr.responseJSON || JSON.parse(xhr.responseText || "{}");
            msg = res.message || res.error || xhr.responseText || msg;
        } catch (e) {
            console.error("Failed to parse error response:", e);
        }
        // Check for common HTTP status codes and provide a more specific message.
        if (xhr.status === 413) msg = "File too large.";
        if (xhr.status === 415) msg = "Unsupported file format.";
        if (xhr.status === 0 && xhr.statusText === "timeout") msg = "Upload timed out.";
        this.showError(msg);
    }

    /**
     * Displays an error message in the designated container.
     * @param {string} msg - The error message to display.
     */
    showError(msg) {
        const el = $("#uploadError");
        if (el.length) {
            $("#uploadErrorMessage").text(msg);
            el.show();
        } else {
            // Fallback to console.error if the element is not found.
            console.error("Upload Error:", msg);
        }
    }

    /**
     * Hides the error message container.
     */
    hideError() {
        $("#uploadError").hide();
        $("#uploadErrorMessage").text("");
    }

    /**
     * Displays a success message in the designated container.
     * @param {string} msg - The success message to display.
     */
    showSuccess(msg) {
        const el = $("#uploadSuccess");
        if (el.length) {
            $("#uploadSuccessMessage").text(msg);
            el.show();
            // Automatically hide the message after 3 seconds.
            setTimeout(() => el.hide(), 3000);
        } else {
            console.log("Success:", msg);
        }
    }

    /**
     * Disables the upload button and sets a loading state.
     */
    disableUploadButton() {
        if (this.modalConfig.uploadButtonId) {
            const $b = $(`#${this.modalConfig.uploadButtonId}`);
            if (!$b.data("original-text")) $b.data("original-text", $b.text());
            $b.prop("disabled", true).text("Uploading...");
        }
    }

    /**
     * Enables the upload button and restores its original text.
     */
    enableUploadButton() {
        if (this.modalConfig.uploadButtonId) {
            const $b = $(`#${this.modalConfig.uploadButtonId}`);
            $b.prop("disabled", false).text($b.data("original-text"));
        }
    }

    /**
     * Reloads the documents table by fetching new HTML from the server.
     */
    reloadDocumentsTab() {
        const caseId = $("#ProjectId").val();
        const controlId = $("#FolderId").val();
        if (!caseId) {
            console.error("ProjectId missing");
            return;
        }

        $.get("/DMS/GetFilesById", { caseId, controlViewModelId: controlId })
            .done((html) => {
                // Replace the entire HTML content of the document table.
                $("#divDocument").html(html);
                // Re-initialize the DataTable on the new content.
                this.initializeDataTable();
            })
            .fail(() => {
                $("#divDocument").html("<div class='alert alert-danger'>Failed to load documents.</div>");
            });
    }

    /**
     * Formats a file size in bytes to a human-readable string.
     * @param {number} bytes - The file size in bytes.
     * @returns {string} - The formatted file size.
     */
    formatFileSize(bytes) {
        if (bytes === 0) return "0 Bytes";
        const k = 1024,
            sizes = ["Bytes", "KB", "MB", "GB", "TB"];
        const i = Math.floor(Math.log(bytes) / Math.log(k));
        return `${parseFloat((bytes / Math.pow(k, i)).toFixed(2))} ${sizes[i]}`;
    }

    /**
     * Destroys the DMSManager instance, clearing the DataTable and event listeners.
     * Enhanced version with proper cleanup.
     */
    destroy() {
        console.log("Destroying DMSManager instance");

        if (this.dataTable && $.fn.DataTable.isDataTable(this.$table)) {
            this.dataTable.destroy();
            this.dataTable = null;
        }

        // Remove all DMS-namespaced events
        $(document).off(".dms");

        // Clean up modal
        if (this.addFileModal) {
            // Hide modal if it's currently shown
            try {
                if (typeof this.addFileModal.hide === "function") {
                    this.addFileModal.hide();
                } else if (this.addFileModal.modal) {
                    this.addFileModal.modal("hide");
                }
            } catch (e) {
                console.warn("Error hiding modal during destroy:", e);
            }
            this.addFileModal = null;
        }

        // Clear references and state
        this.$table = null;
        this.isInitialized = false;
        this.isUploading = false;

        // Clear global reference only if it points to this instance
        if (window.dmsManager === this) {
            window.dmsManager = null;
        }
    }
};

/**
 * Static DMS Class
 * Provides a public API for interacting with the DMSManager.
 * Fixed version with proper cleanup and initialization.
 */
window.DMS = class DMS {
    static LoadDocuments(caseId, controlViewModelId = 0, targetDiv = "divDocument") {
        if (!caseId) {
            console.error("CaseId required");
            return;
        }

        // Always destroy existing manager first
        if (window.dmsManager) {
            console.log("Destroying existing DMSManager before loading new documents");
            window.dmsManager.destroy();
        }

        $.get("/DMS/GetFilesById", { caseId, controlViewModelId })
            .done((html) => {
                $(`#${targetDiv}`).html(html);

                // Check if the table exists in the new HTML before initializing
                if ($("#dmsDataTable").length > 0) {
                    // Use requestAnimationFrame for better timing than setTimeout
                    requestAnimationFrame(() => {
                        window.dmsManager = new window.DMSManager();
                        window.dmsManager.init();
                    });
                } else {
                    console.warn("No dmsDataTable found in loaded HTML");
                }
            })
            .fail(() => {
                $(`#${targetDiv}`).html("<div class='alert alert-danger'>Failed to load documents.</div>");
            });
    }

    static Initialize(config = {}) {
        window.dmsConfig = { ...window.dmsConfig, ...config };
    }

    static RefreshDocuments() {
        window.dmsManager ? window.dmsManager.reloadDocumentsTab() : console.warn("DMS not initialized");
    }

    static GetManager() {
        return window.dmsManager || null;
    }

    static IsLoaded() {
        return !!(window.dmsManager && $("#dmsDataTable").length > 0);
    }
};

// Global init for pages with the DMS table present on load.
// Enhanced version with proper cleanup check.
$(() => {
    if ($("#dmsDataTable").length > 0 && !window.dmsManager) {
        console.log("Initializing DMSManager on document ready...");
        window.dmsManager = new window.DMSManager();
        window.dmsManager.init();
    }
});
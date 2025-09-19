/**
 * Document Management System (DMS) JavaScript Module
 * Handles document table initialization, modal operations for adding files,
 * and deleting documents with grid reload.
 */
window.DMSManager = class DMSManager {
    constructor() {
        this.dataTable = null;
        this.modal = null;
        this.isInitialized = false;

        // Bind all necessary methods
        this.bindEvents = this.bindEvents.bind(this);
        this.handleFormSubmission = this.handleFormSubmission.bind(this);
        this.handleDelete = this.handleDelete.bind(this);
        this.reloadGrid = this.reloadGrid.bind(this);
        this.showError = this.showError.bind(this);
        this.showServerError = this.showServerError.bind(this);
        this.validateFile = this.validateFile.bind(this);
        this.validateForm = this.validateForm.bind(this);
        this.performAjaxSubmission = this.performAjaxSubmission.bind(this);
    }

    init() {
        if (window.dmsManager && window.dmsManager !== this) {
            console.log("DMSManager: Destroying existing instance");
            window.dmsManager.destroy();
        }

        if (this.isInitialized) {
            console.warn("DMSManager: Already initialized. Skipping.");
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
        window.dmsManager = this;
        console.log("DMSManager initialized successfully");
    }

    destroy() {
        console.log("DMSManager: Destroying instance");
        if (this.dataTable && $.fn.DataTable.isDataTable(this.$table)) {
            this.dataTable.destroy();
            this.dataTable = null;
        }
        $(document).off(".dms");
        this.$table = null;
        this.isInitialized = false;
        if (window.dmsManager === this) {
            window.dmsManager = null;
        }
    }

    initializeDataTable() {
        try {
            if ($.fn.DataTable.isDataTable(this.$table)) {
                this.$table.DataTable().destroy();
            }
            this.dataTable = this.$table.DataTable({
                paging: true,
                searching: true,
                ordering: true,
                responsive: true,
                language: { emptyTable: "No documents available" },
                columnDefs: [
                    { targets: -1, orderable: false, searchable: false }
                ]
            });
        } catch (error) {
            console.error("DMSManager: Error initializing DataTable:", error);
        }
    }

    initializeModal() {
        const el = document.getElementById("addFileModal");
        if (el) {
            this.modal = typeof bootstrap !== "undefined" ? new bootstrap.Modal(el) : $(el);
        }
    }

    bindEvents() {
        console.log("DMSManager: Attaching event listeners...");
        $(document).off(".dms");

        $(document).on("click.dms", "#btn-add-file", (e) => {
            e.preventDefault();
            this.showAddModal();
        });

        $(document).on("click.dms", "#uploadFile", (e) => {
            e.preventDefault();
            this.handleFormSubmission();
        });

        $('#addFileModal').on('show.bs.modal', () => {
            this.loadCategories();
        });

        $(document).on("click.dms", ".btn-delete-file", (e) => {
            e.preventDefault();
            const documentId = $(e.target).closest("button").data("id");
            if (documentId) {
                this.handleDelete(documentId);
            }
        });

        $(document).on("click.dms", "#cancelUpload", (e) => {
            const form = $('#uploadForm');
            form[0].reset();
            form.find('.is-invalid').removeClass('is-invalid');
            form.find('.invalid-feedback').hide();  // hide validation messages
        });
    }

    showAddModal() {
        if (this.modal) {
            const form = $('#uploadForm');
            form[0].reset();
            form.find('.is-invalid').removeClass('is-invalid');
           // this.loadCategories();
            this.modal.show();
        }
    }

    // Add this method to your DMSManager class
    validateFile(file) {
        const allowedExtensions = ['.pdf', '.doc', '.docx', '.xls', '.xlsx', '.ppt', '.pptx', '.txt', '.jpg', '.jpeg', '.png', '.gif'];
        const extension = file.name.substring(file.name.lastIndexOf('.')).toLowerCase();

        if (!allowedExtensions.includes(extension)) {
            return { isValid: false, message: `File type not allowed: ${file.name}.` };
        }

        return { isValid: true };
    }

    // This is the missing showError method
    showError(fieldId, message) {
        const field = $(`#${fieldId}`);
        const errorDiv = field.siblings('.invalid-feedback');
        if (errorDiv.length) {
            errorDiv.text(message).show();
        }
        field.addClass('is-invalid');
    }

    handleFormSubmission() {
        const form = $('#uploadForm')[0];
        if (!form) {
            console.error("DMSManager: Form not found.");
            return;
        }

        const files = $('#fileuploader')[0].files;

        // First, check for general form validity (e.g., category selected)
        if (!this.validateForm(form)) {
            return;
        }

        // Then, validate each file individually
        let isValid = true;
        for (let i = 0; i < files.length; i++) {
            const validationResult = this.validateFile(files[i]);
            if (!validationResult.isValid) {
                this.showError('fileuploader', validationResult.message);
                isValid = false;
                break; // Stop checking after the first invalid file
            }
        }

        if (!isValid) {
            return; // Exit if any file is invalid
        }

        // If all files are valid, proceed with the AJAX submission
        const formData = new FormData();
        for (let i = 0; i < files.length; i++) {
            formData.append("Files", files[i]);
        }

        formData.append("Category", $('#category').val());
        formData.append("Comments", $('#comments').val());
        formData.append("ProjectId", $("#ProjectId").val());
        formData.append("FolderName", $("#FolderName").val());
        formData.append("FolderId", $("#FolderId").val());

        const url = window.dmsConfig.uploadUrl;
        this.performAjaxSubmission(formData, url);
    }

    validateForm(form) {
        let isValid = true;
        const category = $('#category').val().trim();
        const fileInput = $('#fileuploader');
        const fileCount = fileInput[0]?.files?.length;

        $('#category, #fileuploader').removeClass('is-invalid');

        if (category === "") {
            $('#category').addClass('is-invalid');
            isValid = false;
        }

        if (fileCount === 0) {
            $('#fileuploader').addClass('is-invalid');
            isValid = false;
        }

        return isValid;
    }

    // Add a method to display the server-side error message
    showServerError(message) {
        const errorDiv = $("#uploadError");
        if (errorDiv.length) {
            $("#uploadErrorMessage").text(message);
            errorDiv.show();
        } else {
            alert(message); // Fallback to an alert if the element doesn't exist
        }
    }

    // Update the performAjaxSubmission method
    performAjaxSubmission(formData, url) {
        if (this.modal) this.modal.hide();
        typeof LoadingOverlay !== "undefined" && LoadingOverlay.show();

        $.ajax({
            url: url,
            type: "POST",
            data: formData,
            processData: false,
            contentType: false,
            success: () => {
                this.reloadGrid();
            },
            error: (xhr) => {
                alert('An error occurred while uploading.');
                console.error("Ajax submission failed:", xhr);
            },
            complete: () => {
                typeof LoadingOverlay !== "undefined" && LoadingOverlay.hide();
            }
        });
    }
    loadCategories() {
        const dropdown = $("#category");

        $.ajax({
            url: window.dmsConfig.getCategoriesUrl,
            type: "GET",
            success: (data) => {
                dropdown.empty();
                dropdown.append('<option value="">-- Select Category --</option>');

                // Corrected part: Iterate over the object's properties
                // The data is the JSON object returned from the server
                // not a simple array.
                for (const key in data) {
                    if (data.hasOwnProperty(key)) {
                        const item = data[key];
                        if (item.group && item.group.name) {
                            let group = dropdown.find("optgroup[label='" + item.group.name + "']");
                            if (group.length === 0) {
                                group = $("<optgroup>", { label: item.group.name }).appendTo(dropdown);
                            }
                            $("<option>", { value: item.value, text: item.text }).appendTo(group);
                        } else {
                            $("<option>", { value: item.value, text: item.text }).appendTo(dropdown);
                        }
                    }
                }
            },
            error: (xhr, status, error) => {
                console.error("Failed to load categories:", error);
                dropdown.empty();
                dropdown.append('<option value="">-- Failed to load categories --</option>');
            }
        });
    }



    // New method for handling the delete action
    handleDelete(documentId) {
        if (!documentId) {
            console.error("DMSManager: documentId is required to delete.");
            return;
        }

        if (!confirm("Are you sure you want to delete this document?")) {
            return;
        }

        // Show loading overlay
        typeof LoadingOverlay !== "undefined" && LoadingOverlay.show();

        $.ajax({
            url: window.dmsConfig.deleteUrl,
            type: "POST",
            data: { id: documentId },
            dataType: "json", // Expect a JSON response from the controller
            success: (response) => {
                if (response.success) {
                    alert("Document deleted successfully.");
                    this.reloadGrid();
                } else {
                    alert(response.message || "Failed to delete document.");
                }
            },
            error: (xhr) => {
                console.error("DMS: Delete failed:", xhr);
                alert("An error occurred while deleting document.");
            },
            complete: () => {
                typeof LoadingOverlay !== "undefined" && LoadingOverlay.hide();
            }
        });
    }

    // Method to reload the entire grid
    reloadGrid() {
        const caseId = $("#ProjectId").val();
        const folderId = $("#FolderId").val();
        const targetDiv = "divDocument";

        if (!caseId) {
            console.error("DMSManager: ProjectId is missing for grid reload.");
            return;
        }

        // Pass the required IDs to the static LoadDocuments method
        DMS.LoadDocuments(caseId, folderId, targetDiv);
    }
};

window.DMS = class DMS {
    static LoadDocuments(caseId, controlViewModelId = 0, targetDiv = "divDocument") {
        if (!caseId) {
            console.error("DMS: CaseId required");
            return;
        }
        if (window.dmsManager) {
            window.dmsManager.destroy();
        }

        $.get(APPURL +  'DMS/GetFilesById', { caseId, controlViewModelId })
            .done((html) => {
                $(`#${targetDiv}`).html(html);
                if ($("#dmsDataTable").length > 0) {
                    requestAnimationFrame(() => {
                        window.dmsManager = new window.DMSManager();
                        window.dmsManager.init();
                    });
                } else {
                    console.warn("DMS: No dmsDataTable found in loaded HTML");
                }
            })
            .fail(() => {
                $(`#${targetDiv}`).html("<div class='alert alert-danger'>Failed to load documents.</div>");
            });
    }

    static AddDocument() {
        if (window.dmsManager) {
            window.dmsManager.showAddModal();
        }
    }

    static SaveDocument() {
        if (window.dmsManager) {
            window.dmsManager.handleFormSubmission();
        } else {
            console.error("DMS Manager not initialized. Cannot save document.");
        }
    }

    // Public API method for deleting a document
    static DeleteDocument(documentId) {
        if (window.dmsManager) {
            window.dmsManager.handleDelete(documentId);
        } else {
            console.error("DMS Manager not initialized. Cannot delete document.");
        }
    }
};

$(() => {
    if ($("#dmsDataTable").length > 0 && !window.dmsManager) {
        console.log("DMS: Initializing on document ready...");
        window.dmsManager = new window.DMSManager();
        window.dmsManager.init();
    }
});
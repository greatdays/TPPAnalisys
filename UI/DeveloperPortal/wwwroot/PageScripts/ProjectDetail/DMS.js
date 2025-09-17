/**
 * Document Management System (DMS) JavaScript Module
 * Handles document table initialization and modal operations for adding files.
 */
window.DMSManager = class DMSManager {
    constructor() {
        this.dataTable = null;
        this.modal = null;
        this.isInitialized = false;

        this.bindEvents = this.bindEvents.bind(this);
        this.handleFormSubmission = this.handleFormSubmission.bind(this);
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
            this.handleFormSubmission(e);
        });
    }

    showAddModal() {
        if (this.modal) {
            const form = $('#uploadForm');
            form[0].reset();
            form.find('.is-invalid').removeClass('is-invalid');
            this.modal.show();
        }
    }

    handleFormSubmission(e) {
        const form = $('#uploadForm')[0];
        if (!form) {
            console.error("DMSManager: Form not found.");
            return;
        }

        const formData = new FormData();
        const files = $('#fileuploader')[0].files;

        if (!this.validateForm(form)) {
            e.preventDefault();
            return;
        }

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
                // CORRECTED: Call the static method to reload the documents tab
                DMS.LoadDocuments(
                    $("#ProjectId").val(),
                    $("#FolderId").val(),
                    "divDocument" // Assuming the target div is 'divDocument'
                );
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

    // You can keep a simplified showSuccess if needed, but it's no longer the main action
    showSuccess(msg) {
        alert(msg);
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

        $.get('/DMS/GetFilesById', { caseId, controlViewModelId })
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
};

$(() => {
    if ($("#dmsDataTable").length > 0 && !window.dmsManager) {
        console.log("DMS: Initializing on document ready...");
        window.dmsManager = new window.DMSManager();
        window.dmsManager.init();
    }
});
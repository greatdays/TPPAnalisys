
var FloorPlanType = {
    bathroomTypeOptions: "",
    bathroomOptionValues: "",
    LutBathroomType: [],
    FloorPlanEditDropZone: "",
    LutTotalBathroomTypeOption: [], 
    init: function () {
        this.loadFloorPlans();
        this.bindEditFloorPlanModal();
        this.bindBathroomDropdownChange();
    },

    bindBathroomDropdownChange: function () {
        $(document).on('change', '#bathroom', function () {

            FloorPlanType.onSelectBathroomCount();
        });
    },

    bindEditFloorPlanModal: function () {        
        $(document).on('click', '.edit-floorplan', function () {
            const floorPlanId = $(this).data('id');
            const modal = $('#editFloorPlanType');

            modal.find('#edit_floorPlan').html('<p>Loading...</p>');
            modal.modal('show');

            $.get(APPURL + 'FloorPlanType/_EditFloorPlanType', { id: floorPlanId }, function (data) {
                modal.find('#edit_floorPlan').html(data);
                
                FloorPlanType.initializeEditDropzone();
            });
        });

        $('#editFloorPlanType').on('hidden.bs.modal', function () {
            $(this).find('#edit_floorPlan').html('');
        });
    },
    // Separate function
    initializeEditDropzone: function () {      
        Dropzone.autoDiscover = false;

        // Create new Dropzone instance
         FloorPlanType.FloorPlanEditDropZone = new Dropzone("#divDropZoneFloorPlanEdit", {
            //url: '/FloorPlanType/_EditFloorPlanType',
            url:'#',
            autoProcessQueue: false,
            uploadMultiple: true,
            parallelUploads: 20,
            maxFiles: 20,
            paramName: "Files",
            clickable: true,
            acceptedFiles: ".jpg,.jpeg,.png,.gif,.pdf",
            addRemoveLinks: false,
            maxFilesize: 20,
            previewTemplate: `
                    <div class="dz-preview dz-file-preview card p-2 shadow-sm border rounded" 
                        style="width: 180px; margin: 10px; display: flex; flex-direction: column;">
                        <div class="mb-2">
                            <p class="mb-1 font-weight-bold dz-filename">
                                <span data-dz-name></span>
                            </p>
                            <small class="text-muted"><span data-dz-size></span></small>
                        </div>
                        <div class="progress mb-2">
                            <div class="progress-bar bg-success" role="progressbar" 
                                style="width:0%;" data-dz-uploadprogress></div>
                        </div>
                        <button class="btn btn-sm btn-danger mt-auto" data-dz-remove>Remove</button>
                        <div class="text-danger small mt-1" data-dz-errormessage></div>
                    </div>
                `,
             init: function () {
                 
            }
        });
        },

        loadFloorPlans: function (isChanged) {      
        const projectId = $('#hiddenProjectID').val();

        $.ajax({
            url: APPURL + 'FloorPlanType/GetFloorPlanTypes',
            type: 'GET',
            data: { projectId: projectId },
            cache: false,
            success: function (data) {
                const table = $('#floorPlanTable');
                if (isChanged) {
                    kgridEditModelData.lutFloorPlanType = data;
                }

                // Destroy previous instance if exists
                if ($.fn.DataTable.isDataTable('#floorPlanTable')) {
                    table.DataTable().clear().destroy();
                }


                // ✅ Define columns using mapping
                const floorPlanColumns = [
                    { data: 'name', title: "Floor Plan Type" },
                    { data: 'squareFeet', title: "Square Feet" },
                    { data: 'bathroomTypes', title: "Number of Bedroom" },
                    { data: 'bathroomOption', title: "Number of Bathroom" },
                    { data: 'groupBathroomTypes', title: "Bathroom Type" },
                    { data: 'groupBathroomOption', title: "Bathroom Option" },
                    {
                        data: null,
                        title: "Action",
                        orderable: false,
                        render: function (data, type, row) {
                            return `
                             <button class="editbtn btn k-button k-button-icontext k-grid-edit btn btn-sm btn-action constructionbtn edit-floorplan"
                                data-id="${row.floorPlanTypeID}" data-used="${row.isUsed}" data-name="${row.name}">
                                <span class="fa fa-pencil primary-font-color"></span>
                            </button>
                            <button class="deletebtn btn k-button btn btn-sm btn-action constructionbtn delete-floorplan"
                                data-id="${row.floorPlanTypeID}" data-name="${row.name}" data-used="${row.isUsed}"
                                onclick="FloorPlanType.deleteFloorPlan(${row.floorPlanTypeID}, '${row.name}', '${row.isUsed}')">
                               <i class="fas fa-trash-alt deletecontent"></i>
                            </button>
                        `;
                        }
                    }
                ];

                // ✅ Initialize DataTable
                table.DataTable({
                    data: data || [],
                    columns: floorPlanColumns,
                    paging: true,
                    searching: true,
                    ordering: true,
                    pageLength: 10,
                    lengthChange: false,
                    language: {
                        emptyTable: "No floor plans found."
                    }
                });

            },
            error: function (err) {
                console.error('Error loading floor plans:', err);
            }
        });
    },

    SaveeditedFloorPlan: function () {
        var isValid = true;
        $('#lblError_fp_siteId_edit').html('');
        if ($('#siteList_edit').val() == 'Select') {
            $('#lblError_fp_siteId_edit').html('Please select a valid Site');
            isValid = false;
        }
        $('#lblError_fp_buildings_edit').html('');
        if ($('#buildings_edit').val() == 'Select Building' || $('#buildings').val() == '-Select Building-') {
            $('#lblError_fp_buildings_edit').html('Please select a valid Structure');
            isValid = false;
        }
        $('#lblError_fp_bedroom_edit').html('');
        if ($('#bedroom_edit').val() == 'Select') {
            $('#lblError_fp_bedroom_edit').html('Please select a valid Bedroom');
            isValid = false;
        }
        $('#lblError_fp_bathroom_edit').html('');
        if ($('#bathroom_edit').val() == 'Select') {
            $('#lblError_fp_bathroom_edit').html('Please select a valid bathroom');
            isValid = false;
        }
        $('#lblError_fp_floorplan_edit').html('');
        if ($('#floorplan_edit').val() == '') {
            $('#lblError_fp_floorplan_edit').html('Please enter a valid floorplan name');
            isValid = false;
        }
        $('#lblError_fp_squarefeet_edit').html('');
        if ($('#squarefeet_edit').val() == '') {
            $('#lblError_fp_squarefeet_edit').html('Please enter a valid squarefeet');
            isValid = false;
        }
        $('.edit_bTypes').each(function (index, elem) {
            if ($(elem).val() == '' || $(elem).val() == '0') {
                isValid = false;
                var spanId = $(elem).attr('id') + '_span';
                $('#' + spanId).html('select a valid type');
            }
        });
        $('.edit_bOptions').each(function (index, elem) {
            if ($(elem).is(":visible") && ($(elem).val() == '' || $(elem).val() == '0')) {
                isValid = false;
                var spanId = $(elem).attr('id') + '_span';
                $('#' + spanId).html('select a valid option');
            }
        });
        if ($('#bTypes_0_edit_option').attr('style') === "") {

            var selectedValue = $('#bTypes_0_edit_option').val();
            if (selectedValue == '0') {
                $('#bTypes_0_edit_span_option').html('select a valid option');
                isValid = false;
            }
        }
        if (isValid) {
            // Delay to ensure DOM is ready
            setTimeout(function () {
                var formEl = document.getElementById('editFloorPlanForm');
                if (!formEl) {
                    console.warn("Form element not found!");
                    return;
                }

                var formData = new FormData(formEl);

                // Optional: add Dropzone files here if needed
                if (FloorPlanType.FloorPlanEditDropZone) {
                    FloorPlanType.FloorPlanEditDropZone.getAcceptedFiles().forEach(file => {
                        formData.append("Files", file);
                    });
                }
                $.ajax({
                    url: APPURL + 'FloorPlanType/_EditFloorPlanType',
                    type: 'POST',
                    data: formData,
                    processData: false, 
                    contentType: false,
                    success: function (response) {                
                        if (response.success) {
                            var modalEl = document.getElementById('editFloorPlanType');
                            var modalInstance = bootstrap.Modal.getInstance(modalEl);
                            if (modalInstance) modalInstance.hide();
                            FloorPlanType.loadFloorPlans();
                            FloorPlanType.showEditFloorPlanAlert(response.message || "Floor Plan updated successfully!", 'success');

                        } else {
                            FloorPlanType.showEditFloorPlanAlert(response.message || "Something went wrong while updating.", 'danger');
                        }
                    },
                    error: function () {
                        $('#editFloorPlanMessage').html('<div class="alert alert-danger">An unexpected error oc curred.</div>');
                    }
                });

            }, 10);
        }
    },
    safeHideModal: function (modalSelector) {
        const $modal = $(modalSelector);

        if ($modal.length && $modal.hasClass('show')) {
            $modal.modal('hide');
        }
    },
    toggleBathroomOption: function (cmb) {
        const id = $(cmb).attr('id');
        const selectedText = $('#' + id + ' option:selected').text();

        if (selectedText === 'Full') {
            $('#' + id + '_option').show().prop('required', true);
            $('#' + id + '_option_span').show();
        } else {
            $('#' + id + '_option').hide().prop('required', false);
            $('#' + id + '_option_span').hide();
        }
    },
    saveFloorPlan: function () {
        var isValid = true;

        // Clear previous validation messages
        $('#lblError_fp_bedroom, #lblError_fp_bathroom, #lblError_fp_floorplan, #lblError_fp_squarefeet').html('');

        if ($('#bedroom').val() == 'Select') {
            $('#lblError_fp_bedroom').html('Please select a valid Bedroom');
            isValid = false;
        }

        if ($('#bathroom').val() == 'Select') {
            $('#lblError_fp_bathroom').html('Please select a valid bathroom');
            isValid = false;
        }

        if ($('#floorplan').val().trim() === '') {
            $('#lblError_fp_floorplan').html('Please enter a valid floorplan name');
            isValid = false;
        }

        if ($('#squarefeet').val().trim() === '') {
            $('#lblError_fp_squarefeet').html('Please enter a valid squarefeet');
            isValid = false;
        }

        $('.add_bTypes').each(function (index, elem) {
            var spanId = $(elem).attr('id') + '_span';
            $('#' + spanId).html('');
            if ($(elem).val() == '' || $(elem).val() == '0') {
                isValid = false;
                $('#' + spanId).html('Select a valid type');
            }
        });

        $('.add_bOptions').each(function (index, elem) {
            var spanId = $(elem).attr('id') + '_span';
            $('#' + spanId).html('');
            if ($(elem).is(":visible") && ($(elem).val() == '' || $(elem).val() == '0')) {
                isValid = false;
                $('#' + spanId).html('Select a valid option');
            }
        });

        if (isValid) {
            var formData = $('#floorPlanForm').serialize();

            $.ajax({
                type: 'POST',
                url: APPURL + 'FloorPlanType/AddFloorPlanType',
                data: formData,
                success: function (response) {
                    if (response.success) {
                        showMessage("Success", response.message);
                        var modalEl = document.getElementById('addFloorPlanType');
                        var modalInstance = bootstrap.Modal.getInstance(modalEl); // get existing instance
                        if (modalInstance) {
                            modalInstance.hide(); // close the modal
                        }
                        $('#floorPlanForm')[0].reset();
                        $('#bathroomTypeDiv').empty();
                        $('.text-danger').html('');
                        FloorPlanType.loadFloorPlans(true);
                    } else {
                        showMessage("Error", "Something went wrong.");
                    }
                },
                error: function (xhr) {
                    let message = "Something went wrong.";
                    if (xhr.responseJSON && xhr.responseJSON.message) {
                        message = xhr.responseJSON.message;
                    } else if (xhr.responseText) {
                        message = xhr.responseText;
                    }
                    showMessage("Error", "Error: " + message);

                }
            });

        }
    },
    onSelectBathroomCount_Edit: function () {
        $('#bathroomTypeDiv_edit').empty();
        var selectedTotalBathroom = $("#bathroom_edit option:selected").text();
        var totalCount = 0;

        switch (selectedTotalBathroom) {
            case 'Select': totalCount = 0; break;
            case '1': totalCount = 1; break;
            case '1.5':
            case '2': totalCount = 2; break;
            case '2.5':
            case '3': totalCount = 3; break;
            case '3.5':
            case '3+':
            case '4': totalCount = 4; break;
            default: totalCount = 5;
        }

        var dynamicTable = '<h6>Bathroom Type </h6>'
            + '<table class="table table-bordered text-center table-fixed" >'
            + '<thead class="thead-light"><tr><th>Sr. no.</th><th>Type</th><th>Options</th></tr></thead><tbody>';

        for (var i = 0; i < totalCount; i++) {
            dynamicTable += '<tr><td>' + (i + 1) + '</td>';
            dynamicTable += '<td><select class="form-control edit_bTypes" name="bathroomTypes" id="bTypes_' + (i + 1) + '_edit" onchange="FloorPlanType.toggleBathroomOptionEdit(this);" name="LutBathroomTypeID">';
            dynamicTable += '<option value="0">-Select Bathroom Type-</option>';

            // ✅ Safe iteration over LutBathroomType
            if (Array.isArray(FloorPlanType.LutBathroomType)) {
                FloorPlanType.LutBathroomType.forEach(function (value) {
                    dynamicTable += '<option value="' + value.value + '">' + value.text + '</option>';
                });
            }

            dynamicTable += '</select><span class="text-danger" id="bTypes_' + (i + 1) + '_edit_span"></span></td>';

            dynamicTable += '<td><select class="form-control edit_bOptions" name="bathroomOption" id="bTypes_' + (i + 1) + '_edit_option" style="display:none;" name="LutBathroomTypeOptionID">';
            dynamicTable += '<option value="0">-Select Bathroom Option-</option>';
            if (Array.isArray(FloorPlanType.LutFloorBathrommOptions)) {
                FloorPlanType.LutFloorBathrommOptions.forEach(function (value) {
                    dynamicTable += '<option value="' + value.value + '">' + value.text + '</option>';
                });
            }

            dynamicTable += '</select><span class="text-danger" id="bTypes_' + (i + 1) + '_edit_option_span"></span></td></tr>';
        }

        dynamicTable += '</tbody></table>';
        $('#bathroomTypeDiv_edit').html(dynamicTable);
    },
    onSelectBathroomCount: function () {
        $('#bathroomTypeDiv').empty();
        var selectedTotalBathroom = $("#bathroom option:selected").text();
        var totalCount = 0;

        switch (selectedTotalBathroom) {
            case 'Select': totalCount = 0; break;
            case '1': totalCount = 1; break;
            case '1.5':
            case '2': totalCount = 2; break;
            case '2.5':
            case '3': totalCount = 3; break;
            case '3.5':
            case '3+':
            case '4': totalCount = 4; break;
            default: totalCount = 5;
        }

        var dynamicTable = '<h6>Bathroom Type </h6>'
            + '<table class="table table-bordered text-center table-fixed" style="width: 592px;">'
            + '<thead class="thead-light"><tr><th>Sr. no.</th><th>Type</th><th>Options</th></tr></thead><tbody>';

        for (var i = 0; i < totalCount; i++) {
            dynamicTable += '<tr><td>' + (i + 1) + '</td>';
            dynamicTable += '<td><select class="form-control add_bTypes" name="bathroomTypes" id="bTypes_' + (i + 1) + '" onchange="FloorPlanType.toggleBathroomOption(this);" required>';
            dynamicTable += '<option value="0">-Select Bathroom Type-</option>';
            if (Array.isArray(FloorPlanType.LutBathroomType)) {
                FloorPlanType.LutBathroomType.forEach(function (value) {
                    dynamicTable += '<option value="' + value.value + '">' + value.text + '</option>';
                });
            }

            dynamicTable += '</select><span class="text-danger" id="bTypes_' + (i + 1) + '_span"></span></td>';

            dynamicTable += '<td><select class="form-control add_bOptions" name="bathroomOption" id="bTypes_' + (i + 1) + '_option" style="display:none;" required>';
            dynamicTable += '<option value="0">-Select Bathroom Option-</option>';

            if (Array.isArray(FloorPlanType.LutTotalBathroomTypeOption)) {

                FloorPlanType.LutTotalBathroomTypeOption.forEach(function (value) {
                    dynamicTable += '<option value="' + value.value + '">' + value.text + '</option>';
                });
            }

            dynamicTable += '</select><span class="text-danger" id="bTypes_' + (i + 1) + '_option_span"></span></td></tr>';
        }

        dynamicTable += '</tbody></table>';
        $('#bathroomTypeDiv').html(dynamicTable);
    },
    toggleBathroomOptionEdit: function (cmb) {
        var id = $(cmb).attr('id');
        var text = $('#' + id + ' option:selected').text();
        if (text === 'Full') {
            $('#' + id + '_option').show();
            $('#bTypes_0_edit_span_option').show();
        } else {
            $('#' + id + '_option').hide();
            $('#bTypes_0_edit_span_option').hide();
        }
    },

    limitText: function (field, maxChar) {
        var ref = $(field),
            val = ref.val();
        if (val.length >= maxChar) {
            ref.val(val.substr(0, maxChar));
        }
    },

    deleteFloorPlan: function (id, name, isUsed) {
        if (isUsed === 'true') {
            showMessage("Error", `Cannot delete "${name}" because it is in use.`);
            return;
        }

        if (confirm(`Are you sure you want to delete "${name}"?`)) {
            $.ajax({
                url: APPURL + 'FloorPlanType/DeleteFloorPlan',
                type: 'POST',
                data: { floorPlanTypeId: id },
                success: function () {
                    showMessage("Success", `"${name}" deleted successfully.`);
                    FloorPlanType.loadFloorPlans(true);
                },
                error: function (err) {
                    showMessage("Error", `Failed to delete "${name}".`);
                }
            });
        }
    },
    deleteFloorPlanFile: function (docId, fileName) {

        $.ajax({
            url: APPURL + 'FloorPlanType/DeleteFile', 
            type: 'POST',
            data: { docId: docId },
            success: function (response) {
                if (response.success) {
                    FloorPlanType.deleteEditFloorPlanAlert(response.message || "File deleted successfully!", 'success');
                   // alert('File deleted successfully.');
                    // refresh table or remove row dynamically
                    $(`button[onclick*="${docId}"]`).closest('tr').remove();
                } else {
                    alert('Failed to delete file: ' + response.message);
                }
            },
            error: function (xhr, status, error) {
                alert('Error deleting file: ' + error);
            }
        });
    },
    showEditFloorPlanAlert: function (message, type = 'primary') {
       
        const alertBox = $('#EditfloorPlanAlert');
        const alertMessage = $('#EditfloorPlanAlertMessage');

        // Reset styles
        alertBox
            .removeClass('alert-primary alert-success alert-danger alert-warning')
            .addClass(`alert-${type}`);

        alertMessage.text(message);

        // Show alert
        alertBox.fadeIn(200).addClass('show');

        // Auto hide after 2 seconds
        setTimeout(() => {
            alertBox.fadeOut(300, function () {
                $(this).removeClass('show');
            });
        }, 20000);
    },
    deleteEditFloorPlanAlert: function (message, type = 'primary') {
       
        const alertBox = $('#deletefloorPlanAlert');
        const alertMessage = $('#deletefloorPlanAlertMessage');

        // Reset styles
        alertBox
            .removeClass('alert-primary alert-success alert-danger alert-warning')
            .addClass(`alert-${type}`);

        alertMessage.text(message);

        // Show alert
        alertBox.fadeIn(200).addClass('show');

        // Auto hide after 2 seconds
        setTimeout(() => {
            alertBox.fadeOut(300, function () {
                $(this).removeClass('show');
            });
        }, 20000);
    },
    
};

// Initialize when DOM is ready
$(document).ready(function () {
    FloorPlanType.init();
    var addModal = document.getElementById('addFloorPlanType');
    if (addModal) {
        addModal.addEventListener('hidden.bs.modal', function () {
            document.getElementById('floorPlanForm').reset();
            document.getElementById('bathroomTypeDiv').innerHTML = '';
            document.querySelectorAll('.text-danger').forEach(function (el) {
                el.innerHTML = '';
            });
        });
    }
    var activeTab = localStorage.getItem('floorplanActiveTab');
    if (activeTab) {
        $('.tab button.tablinks').removeClass('active');
        $('.tabcontent').hide();

        $('#' + activeTab).show();

        $('.tab button').filter(function () {
            return $(this).attr('onclick').includes("'" + activeTab + "'");
        }).addClass('active');

        localStorage.removeItem('floorplanActiveTab');
    }
});
// Initialize event handler for #squarefeet_edit keyup event
$(document).on('keyup', '#squarefeet_edit', function () {
    FloorPlanType.limitText(this, 5);
});


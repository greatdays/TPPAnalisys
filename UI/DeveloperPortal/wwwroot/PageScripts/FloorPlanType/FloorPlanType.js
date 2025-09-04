
var FloorPlanType = {
    bathroomTypeOptions: "",
    bathroomOptionValues: "",
    LutBathroomType: [],
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

            $.get('/FloorPlanType/_EditFloorPlanType', { id: floorPlanId }, function (data) {
                modal.find('#edit_floorPlan').html(data);

            });
        });

        $('#editFloorPlanType').on('hidden.bs.modal', function () {
            $(this).find('#edit_floorPlan').html('');
        });
    },

    loadFloorPlans: function () {
        const projectId = $('#hiddenProjectID').val();

        $.ajax({
            url: '/FloorPlanType/GetFloorPlanTypes',
            type: 'GET',
            data: { projectId: projectId },
            success: function (data) {
                const tbody = $('#floorPlanTableBody');
                tbody.empty();

                if (!data || data.length === 0) {
                    tbody.append('<tr><td colspan="7" class="text-center">No floor plans found.</td></tr>');
                    return;
                }

                $.each(data, function (i, fPlan) {
                    const row = `
                        <tr>
                            <td>${fPlan.name}</td>
                            <td>${fPlan.squareFeet}</td>
                            <td>${fPlan.bathroomTypes}</td>
                            <td>${fPlan.bathroomOption}</td>
                            <td>${fPlan.groupBathroomTypes}</td>
                            <td>${fPlan.groupBathroomOption}</td>
                            <td>
                                <button class="btn btn-sm btn-action constructionbtn edit-floorplan" data-id="${fPlan.floorPlanTypeID}" data-used="${fPlan.isUsed}" data-name="${fPlan.name}">
                                    <span class="fa fa-pencil primary-font-color"></span>
                                </button>
                                <button class="btn btn-sm btn-action constructionbtn delete-floorplan" data-id="${fPlan.floorPlanTypeID}" data-name="${fPlan.name}" data-used="${fPlan.isUsed}"   onclick="FloorPlanType.deleteFloorPlan(${fPlan.floorPlanTypeID}, '${fPlan.name}', '${fPlan.isUsed}')">
                                    <span class="fa fa-trash primary-font-color"></span>
                                </button>
                            </td>
                        </tr>`;
                    tbody.append(row);
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
        console.log($('#siteList_edit').val());
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
            console.log($(elem).val());
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

        if (isValid) {
            var formData = $('#editFloorPlanForm').serialize();

            console.log(formData);
            $.ajax({
                url: '/FloorPlanType/_EditFloorPlanType',
                type: 'POST',
                data: formData,
                contentType: "application/x-www-form-urlencoded",
                success: function (response) {
                    alert(response.message);
                    var modalEl = document.getElementById('editFloorPlanType');
                    var modalInstance = bootstrap.Modal.getInstance(modalEl); // get existing instance
                    if (modalInstance) {
                        modalInstance.hide(); // close the modal
                    }
                    FloorPlanType.loadFloorPlans();
                    //location.href = window.location.href;
                },
                error: function () {
                    $('#editFloorPlanMessage').html('<div class="alert alert-danger">An unexpected error occurred.</div>');
                }
            });
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
        } else {
            $('#' + id + '_option').hide().prop('required', false);
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
                url: '/FloorPlanType/AddFloorPlanType',
                data: formData,
                success: function (response) {
                    if (response.success) {
                        alert(response.message);

                        // Close the modal
                        localStorage.setItem('floorplanActiveTab', 'partialContainer');
                        location.reload();
                        //// Clear form and reset dynamic sections
                        $('#floorPlanForm')[0].reset();
                        $('.text-danger').html('');
                        $('#bathroomTypeDiv').empty();

                        // Reload the floor plan table
                        FloorPlanType.loadFloorPlans();

                    } else {
                        alert('Something went wrong.');
                    }
                },
                error: function (xhr) {
                    let message = "Something went wrong.";
                    if (xhr.responseJSON && xhr.responseJSON.message) {
                        message = xhr.responseJSON.message;
                    } else if (xhr.responseText) {
                        message = xhr.responseText;
                    }
                    alert("Error: " + message);
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

            // ✅ Safe iteration over LutFloorBathrommOptions
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
        } else {
            $('#' + id + '_option').hide();
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
            alert(`Cannot delete "${name}" because it is in use.`);
            return;
        }

        if (confirm(`Are you sure you want to delete "${name}"?`)) {
            $.ajax({
                url: '/FloorPlanType/DeleteFloorPlan',
                type: 'POST',
                data: { floorPlanTypeId: id },
                success: function () {
                    alert(`"${name}" deleted successfully.`);
                    FloorPlanType.loadFloorPlans();
                },
                error: function (err) {
                    alert(`Failed to delete "${name}".`);
                    console.error(err);
                }
            });
        }
    }
};

// Initialize when DOM is ready
$(document).ready(function () {
    FloorPlanType.init();
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


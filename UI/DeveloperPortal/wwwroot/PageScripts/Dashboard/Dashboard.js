var Dashboard =
{
    init: function () {
        console.log("Dashboard.init() called");

        $(document).on('click', '.btnDel', function (e) {
            e.preventDefault(); // in case <a> reloads page
            console.log("Delete button clicked");

            $(this).closest('div.row').remove();
        });

        $('#tblMyProjects').DataTable({
            "bPaginate": true,
            "bSort": true,
            "pageLength": 10,
            "bInfo": true,
            "bRetrieve": true,
            "bFilter": true,
            "bLengthChange": true,
            "LengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]]
        });
    },

    handleSubmit: function (e) {
        //e.preventDefault(); // prevent form from reloading page

        // Clear previous message
        $('#validationMessage').hide().text('');

        var projects = [];

        // Collect all hidden projectIds
        $('#divProjects input[name="projectIds[]"]').each(function () {
            projects.push($(this).val());
        });

        if (projects.length === 0) {
            $('#validationMessage').text("Please add at least one project before submitting.").show();
            return;
        }

        $.post(APPURL + "Dashboard/SubmitProjects", { projects: projects }, function (response) {
            if (response.success) {
                $('#ActionModal').modal('hide');
                Dashboard.PopulateMyProjectData();
            } else {
                $('#validationMessage').text(response.message || "Submission failed.").show();
            }
        });
    },


    handleSubmitAPN: function (e) {
        $('.validation-error').remove();
        $('#validationMessageAPN').hide().text('');

        var isValid = true;

        // --- Basic Validations (always required) ---
        var projectName = $('#projectNameInput').val().trim();
        if (projectName === '') {
            $('#projectNameInput').after('<span class="text-danger validation-error"> * Project Name is required.</span>');
            isValid = false;
        }

        var propertyName = $('#propertyNameInput').val().trim();
        if (propertyName === '') {
            $('#propertyNameInput').after('<span class="text-danger validation-error"> * Property Name is required.</span>');
            isValid = false;
        }

        // --- Construct Data Model ---
        const isManual = $('#manualAddressCheck').is(':checked') || $('#noAPNData').is(':visible');
        var provisionRequest = {
            ProjectName: projectName,
            PropertyName: propertyName,
            APN: $('#APNInput').val().trim(),
            ProjectAddress:null,
            RefSiteAddressId: null,
            SiteAddressID: null,
            HouseNum: null,
            HouseFracNum: null,
            PreDirCd: null,
            StreetName: null,
            StreetTypeCd: null,
            City: null,
            Zip: null,
            // ProjectAddress, UserName, and LutProjectFundId will be set server-side.
        };

        // --- Conditional Validation and Data Population (Address) ---
        if (isManual) {
            // Scenario: APN not found OR user checked "enter it manually"
            provisionRequest.HouseNum = $('#ma_house').val().trim();
            provisionRequest.StreetName = $('#ma_street').val().trim();
            provisionRequest.City = $('#ma_city').val().trim();
            provisionRequest.Zip = $('#ma_zip').val().trim();

            if (provisionRequest.HouseNum === '') {
                $('#ma_house').after('<span class="text-danger validation-error"> * Required</span>');
                isValid = false;
            }
            if (provisionRequest.StreetName === '') {
                $('#ma_street').after('<span class="text-danger validation-error"> * Required</span>');
                isValid = false;
            }
            if (provisionRequest.City === '') {
                $('#ma_city').after('<span class="text-danger validation-error"> * Required</span>');
                isValid = false;
            }
            if (provisionRequest.Zip === '') {
                $('#ma_zip').after('<span class="text-danger validation-error"> * Required</span>');
                isValid = false;
            }

            // Add non-required manual fields
            provisionRequest.HouseFracNum = $('#ma_frac').val().trim();
            provisionRequest.PreDirCd = $('#ma_predir').val();
            provisionRequest.StreetTypeCd = $('#ma_streettype').val();

        } else {
            // Dropdown Address Selection
            var selectedOption = $('#SiteAddressControlSelect option:selected');
            var aahrSiteId = selectedOption.val();

            if (aahrSiteId === null || aahrSiteId === '') {
                $('#SiteAddressControlSelect').after('<span class="text-danger validation-error"> * Please select a site address.</span>');
                isValid = false;
            } else {
                provisionRequest.SiteAddressID = aahrSiteId; // aahr id from value
                provisionRequest.RefSiteAddressId = selectedOption.data('ref-id'); // pcms id from data attribute
                provisionRequest.ProjectAddress = selectedOption.text(); // full address text for the API
            }
        }


        // --- Submission ---
        if (isValid) {
            $.ajax({
                type: "POST",
                url: APPURL + "Dashboard/CreateProject",
                data: JSON.stringify(provisionRequest),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.success) {
                        $('#ActionModal').modal('hide');
                        Dashboard.PopulateMyProjectData();
                    } else {
                        $('#validationMessageAPN').text(response.message || "Submission failed.").show();
                    }
                },
                error: function (xhr, status, error) {
                    console.error("AJAX Error:", error);
                    $('#validationMessageAPN').text("An unexpected error occurred during submission.").show();
                }
            });
        }

        //const input = document.getElementById("APNInput");
        //const value = input.value.trim();
        //document.getElementById("noAPNData").style.display = "none";
        //if (value === '') {
        //    document.getElementById("APNError").style.display = "block";
        //    return;
        //}
        //else {
        //    document.getElementById("APNError").style.display = "none";
        //}

        //var selectedSiteAddress = $('#SiteAddressControlSelect').val();
        //if (selectedSiteAddress === null || selectedSiteAddress === '') {
        //    $('#SiteAddressControlSelect').after('<span class="text-danger validation-error"> * Please select a site address.</span>');
        //    isValid = false;
        //}

        //var projectName = $('#projectNameInput').val().trim();
        //if (projectName === '') {
        //    $('#projectNameInput').after('<span class="text-danger validation-error"> * Project Name is required.</span>');
        //    isValid = false;
        //}

        //var propertyName = $('#propertyNameInput').val().trim();
        //if (propertyName === '') {
        //    $('#propertyNameInput').after('<span class="text-danger validation-error"> * Property Name is required.</span>');
        //    isValid = false;
        //}

        //if (isValid) {
        //    var projectModel = {
        //        SiteAddressID: $('#SiteAddressControlSelect').val(),
        //        ProjectAddress: $('#SiteAddressControlSelect option:selected').text(),
        //        ProjectName: projectName,
        //        PropertyNameInput: propertyName,
        //        APN: $('#APNInput').val().trim()
        //    };

        //    // Use $.ajax for full control over the request
        //    $.ajax({
        //        type: "POST",
        //        url: APPURL + "Dashboard/CreateProject",
        //        data: JSON.stringify(projectModel), // Convert the object to a JSON string
        //        contentType: "application/json; charset=utf-8", // Set the content type
        //        dataType: "json",
        //        success: function (response) {
        //            if (response.success) {
        //                $('#ActionModal').modal('hide');
                       
        //                Dashboard.PopulateMyProjectData();
        //            } else {
        //                $('#validationMessage').text(response.message || "Submission failed.").show();
        //            }
        //        },
        //        error: function (xhr, status, error) {
        //            console.error("AJAX Error:", error);
        //        }
        //    });
        //}
    },


    PopulateMyProjectData: function () {

        if ($.fn.DataTable.isDataTable('#tblMyProjects')) {
            $('#tblMyProjects').DataTable().clear().destroy();
        }
        $('#tblMyProjects').DataTable({
            ajax: {
                url: APPURL + 'Dashboard/GetMyProjectData',
                data: {},
                type: 'POST',
                "headers": {
                    "Content-Type": "application/x-www-form-urlencoded"
                },
                dataType: 'json',
                dataSrc: ''
            },

            columns: [
                {
                    data: 'acHPFileProjectNumber',
                    render: function (data, type, row, meta) {
                        // render event defines the markup of the cell text
                        if (row.caseId) {
                            if (row.caseId.match(/href="([^"]*)/)) {
                                var a = '<a class="dashboard-anchor-plan-review" href="#">' + row.acHPFileProjectNumber + '</a>';
                                var href = row.caseId.match(/href="([^"]*)/)[1];
                                var queryString = href.split("?")[1] || ""; // Get query string safely
                                var separator = queryString ? "&" : ""; // Add '&' only if query string exists
                                var url = APPURL + "projectdetail?" + queryString + separator + "aahrProjectID=" + encodeURIComponent(row.aahrProjectID);
                                a = '<a class="dashboard-anchor-plan-review" href="' + url + '">' + row.acHPFileProjectNumber + '</a>';
                                return a;
                            }
                            else {
                                return row.caseId.replace('View Project', row.acHPFileProjectNumber);
                            }
                        }
                        return "";
                    }
                },
                { data: 'projectName' },
                { data: 'projectAddress', },
                { data: 'type' },
                { data: 'status' }

            ],
            initComplete: function (settings, json) {
                if (json && json.length > 0) {
                    var fileNumber = json[0].reviewNoteAcHPFileProjectNumber;

                    if (fileNumber && fileNumber.trim() !== "") {
                        $(".project-notifications p").html(
                            "<b> Action Required.</b> New comments on your project(s): <b>" + fileNumber.trim() + "</b>"
                        );
                        $(".project-notifications").show();
                    } else {
                        $(".project-notifications").hide();
                    }
                } else {
                    $(".project-notifications").hide();
                }
            }
        });
    },

    PopulateData: function (tableName, dashboardCategory) {

        //var APPURL = '@Configuration["AppSettings:ApplicationURL"]';

        $('#' + tableName).DataTable({
            ajax: {
                url: APPURL + 'Dashboard/GetProjectData',
                data: { name: dashboardCategory },
                type: 'POST',
                "headers": {
                    "Content-Type": "application/x-www-form-urlencoded"
                },
                dataType: 'json',
                dataSrc: ''
            },
            columns: [
                {
                    data: 'projectName',
                    render: function (data, type, row, meta) { // render event defines the markup of the cell text
                        var a = '<a class="dashboard-anchor-plan-review" href="#">' + row.projectName + '</a>';
                        if (dashboardCategory == 'PlanReview') {
                            var href = row.caseId.match(/href="([^"]*)/)[1];
                            var queryString = href.split("?");
                            var url = APPURL + "planReview/index?" + queryString[1];
                            a = '<a class="dashboard-anchor-plan-review" href="' + url + '">' + row.projectName + '</a>';

                        }
                        return a;

                    }
                }
            ]
        });
    },

    showTab1: function () {
        // Deactivate all tabs and their content
        document.querySelectorAll('.tab, .tab-content').forEach(el => {
            el.classList.remove('active', 'show');
        });

        // Activate tab-1
        document.querySelector('.tab[data-tab="1"]').classList.add('active');

        // Activate tab-1 content
        document.getElementById('tab-1').classList.add('active', 'show');
    },

    DisplayModal: function () {
        setTimeout(Dashboard.showTab1, 300);

        $('#ActionModal').modal('show');
        // $('#ActionModal').modal('show');
        document.getElementById('acHpError').style.display = 'none';
        document.getElementById('noData').style.display = 'none';
        document.getElementById("acHpInput").value = '';
        document.getElementById('divProjects').innerHTML = '';

        document.getElementById('noAPNData').style.display = 'none';
        document.getElementById('APNError').style.display = 'none';

        $('#APNInput').val('');

        // Clear the dropdown list, resetting it to the default option
        $('#SiteAddressControlSelect').empty().append('<option value="" disabled selected>Please Select a Site Address</option>');

        // Clear the project and property name input fields
        $('#projectNameInput').val('');
        $('#propertyNameInput').val('');

        // Remove any validation error messages that might be visible
        $('.validation-error').remove();
        $('#validationMessage').hide(); // Hide the main validation message if it's visible
        var tableBody = $("#tblExistingProjectDetails tbody");
        tableBody.empty();
        document.getElementById("ExistingProjectNameId").style.display = "none";
        document.getElementById("CreateNewProjectId").style.display = "none";
    },


    addProject: function () {
        const input = document.getElementById("acHpInput");
        const value = input.value.trim();
        document.getElementById("noData").style.display = "none";
        if (value === '') {
            document.getElementById("acHpError").style.display = "block";
            return;
        }
        else {
            document.getElementById("acHpError").style.display = "none";
            setTimeout(Dashboard.AddClick, 300);
        }
    },

    GetAPNProject: function () {

        const input = document.getElementById("APNInput");
        const value = input.value.trim();
        document.getElementById("noAPNData").style.display = "none";
        if (value === '') {
            document.getElementById("APNError").style.display = "block";
            return;
        }
        else {
            document.getElementById("APNError").style.display = "none";
            setTimeout(Dashboard.SerachAPNClick, 300);
        }
    },

    AddClick: function () {
        var ctlIndex = GetControlIndex();
        /*        console.log('ProjCount: ' + ctlIndex);*/
        const input = document.getElementById("acHpInput");
        const achpNumber = input.value.trim();


        Dashboard.GetACHPDetail(achpNumber, function (streetName, retAchp, projectId, found) {
            var achpNumbers = new Set();
            var isDuplicate = false;

            $('#divProjects input[name="projectIds[]"]').each(function () {
                if ($(this).val() === projectId) {
                    $('#divAdd').next('.text-danger-custom').remove();
                    $('#validationMessage').text("ACHP number already Added : " + retAchp).show();
                    isDuplicate = true;
                    return false; // break loop
                }
            });

            if (isDuplicate) {
                return;
            } else {
                $('#validationMessage').text("Duplicate Project Found: " + retAchp).hide();
            }

            if (!found) {
                $('#divAdd').next('.text-danger-custom').remove();
                document.getElementById("noData").style.display = "block";
                $('#btnAdd').prop('disabled', false);
                return;
            } else {
                document.getElementById("noData").style.display = "none";
            }

            streetName = streetName.replace(/LOS ANGELES.*/g, ""); // Clean address
            var ctlIndex = GetControlIndex();

            // build full block as its own row
            var html = `
						<div class="row justify-content-md-center mb-2" id="div${ctlIndex}">
							<div class="col-md-8 border-no-right row-padding">
								${retAchp} - ${streetName}
							</div>
							<div class="col-md-2 text-right border-no-left row-padding">
								<a role="button" class="k-button k-button-icontext k-grid-Delete btnDel">
									<span class="k-icon k-i-delete"></span>
								</a>
							</div>
							<input type="hidden" name="projectIds[]" value="${projectId}" />
						</div>`;

            $('#divProjects').append(html);
            $('#btnAdd').prop('disabled', false);
        });
    },
    setDisplay: function (id, on) {
        var el = document.getElementById(id);
        if (el) el.style.display = on ? "block" : "none";
    },
    clearInput: function (id) {
        var el = document.getElementById(id);
        if (el) el.value = "";
    },
    resetAPNUI: function () {
        // Hide all conditional sections
        Dashboard.setDisplay("noAPNData", false);
        Dashboard.setDisplay("CreateNewProjectId", false);   // Path A container
        Dashboard.setDisplay("SiteAddressSelection", false); // wrapper for dropdown (if present)
        Dashboard.setDisplay("ManualAddressForm", false);    // manual form under Path A
        Dashboard.setDisplay("NoAddressFormWrap", false);    // Path B container
        Dashboard.setDisplay("ExistingProjectNameId", false);

        // Reset dropdown + checkbox
        var $ddl = $('#SiteAddressControlSelect');
        if ($ddl.length) {
            $ddl.empty().append('<option value="" disabled selected>Please Select a Site Address</option>');
        }
        var chk = document.getElementById('manualAddressCheck');
        if (chk) chk.checked = false;

        // Clear manual address fields (both variants, if present)
        ["ma_house", "ma_frac", "ma_street", "ma_city", "ma_zip",
            "fa_house", "fa_frac", "fa_street", "fa_city", "fa_zip"].forEach(Dashboard.clearInput);
    },
    SerachAPNClick: function () {
        var token = $('input[name="__RequestVerificationToken"]').val();
        var ctlIndex = GetControlIndex();
        //console.log('ProjCount: ' + ctlIndex);
        const input = document.getElementById("APNInput");
        const APNNumber = input.value.trim();

        // Always clear prior state before handling a new search
        Dashboard.resetAPNUI();

        //document.getElementById("noAPNData").style.display = "none";

        $.ajax({
            url: APPURL + 'Dashboard/GetAPNProjectName',
            type: 'POST',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            headers: {
                'RequestVerificationToken': token
            },
            data: { APNNumber: APNNumber },
            success: function (response) {

            /*    console.log("AJAX Success:", response);*/

                var apnExists = response.apnExists;

                // Display always on option 
                document.getElementById("ProjectMeta").style.display = "block";

                if (apnExists) {
                    // APN exists in master data
                    document.getElementById("CreateNewProjectId").style.display = "block";
                   
                    if (response.apnSearchSiteAddresslst != null) {
                        var siteaddresslist = response.apnSearchSiteAddresslst.map(p => ({
                            id: p.siteAddressID,
                            fullAddress: p.fullAddress
                        }));
                    }

                    var dropdown = $('#SiteAddressControlSelect');
                    dropdown.empty().append('<option value="" disabled selected>Please Select a Site Address</option>');

                    // Loop through the data and add options to the dropdown
                    $.each(response.apnSearchSiteAddresslst, function (i, item) {
                        var $option = $('<option>', {
                            value: item.id,
                            text: item.fullAddress
                        });
                       /* console.log("refSiteAddressID:", item.refSiteAddressID);*/
                        // Correctly set the data attribute using the casing from your server's JSON response.
                        $option.attr('data-ref-id', item.refSiteAddressID);
                        dropdown.append($option);
                    });

                    document.getElementById("SiteAddressSelection").style.display = "block";
                }
                else {
                    // APN does not exist in master -> show the "not found" notice
                    document.getElementById("noAPNData").style.display = "block";
                    document.getElementById("CreateNewProjectId").style.display = "none";
                    document.getElementById("SiteAddressSelection").style.display = "none";
                    document.getElementById("ManualAddressForm").style.display = "block";
                }


                //// Normalize inputs
                //const addresses = response.apnSearchSiteAddresslst || [];
                //const projects = response.apnSearchProjectInfolst || [];
                //const apnExists = response.apnExists === true;

                //if (response.apnSearchSiteAddresslst == null && response.apnSearchProjectInfolst == null) {
                //    document.getElementById("noAPNData").style.display = "block";
                //    document.getElementById("CreateNewProjectId").style.display = "none";
                //    document.getElementById("ExistingProjectNameId").style.display = "none";
                //    return;
                //}

                //if (response.apnSearchSiteAddresslst != null) {
                //    var projectList = response.apnSearchSiteAddresslst.map(p => ({
                //        id: p.siteAddressID,
                //        fullAddress: p.fullAddress
                //    }));
                //}

                // Prepare dropdown
                //var dropdown = $('#SiteAddressControlSelect');
                //dropdown.empty().append('<option value="" disabled selected>Please Select a Site Address</option>');

                // Default UI
                //const show = (id, on) => { var el = document.getElementById(id); if (el) el.style.display = on ? "block" : "none"; };
                //show("noAPNData", false);
                //show("CreateNewProjectId", false);


                // If this element was removed, the call is safe (guarded)
/*                show("ExistingProjectNameId", false);*/

                //// Populate addresses if we have them
                //if (addresses.length > 0) {
                //    var projectList = addresses.map(p => ({ id: p.siteAddressID, fullAddress: p.fullAddress }));
                //    $.each(projectList, function (i, item) {
                //        dropdown.append($('<option>', { value: item.id, text: item.fullAddress }));
                //    });
                //    show("CreateNewProjectId", true);   // user can proceed (address selected or manual path if you have it)
                //    return;
                //}

                //show("ProjectMeta", true);
               
/*                console.log("ProjectMeta Show");*/

                //if (apnExists) {
                //    console.log("APN exists in master data");
                //   /* show("CreateNewProjectId", false);   // your current markup expects addresses for this section*/
                //    if (response.apnSearchSiteAddresslst != null) {
                //        show("SiteAddressSelection", true);
                //        /*document.getElementById("CreateNewProjectId").style.display = "block";*/
                //        // Loop through the data and add options to the dropdown
                //        $.each(projectList, function (i, item) {
                //            dropdown.append($('<option>', {
                //                value: item.id,      // Assuming the C# object has a 'id' property
                //                text: item.fullAddress // Assuming the C# object has a 'projectName' property
                //            }));
                //        });
                //    }


                //} else {
                //    // APN does not exist in master -> show the "not found" notice
                //    show("noAPNData", true);
                //    show("CreateNewProjectId", false);
                //}

                //// Check if the response is valid and has data
                //if (response.apnSearchSiteAddresslst != null && projectList && projectList.length > 0) {

                //    document.getElementById("CreateNewProjectId").style.display = "block";
                //    // Loop through the data and add options to the dropdown
                //    $.each(projectList, function (i, item) {
                //        dropdown.append($('<option>', {
                //            value: item.id,      // Assuming the C# object has a 'id' property
                //            text: item.fullAddress // Assuming the C# object has a 'projectName' property
                //        }));
                //    });
                //}
                //else {
                //    document.getElementById("CreateNewProjectId").style.display = "none";
                //}
                //        //Removed ExistingProjectNameId block as per new requirement - ekim on 10 / 12 / 2025
                //        //Let user go ahead and create project entry with new APN and not have mapping to an existing Project

                //        //        var gridData = response.apnSearchProjectInfolst;

                //        //        var tableBody = $("#tblExistingProjectDetails tbody");
                //        //        tableBody.empty();
                //        //        if (gridData != null && gridData.length > 0) {

                //        //            document.getElementById("ExistingProjectNameId").style.display = "block";


                //        //            gridData.forEach(function (project) {
                //        //                tableBody.append
                //        //                    (`
                //        //                <tr>
                //        //                    <td>${project.achpNumber}</td>
                //        //                    <td>${project.projectName}</td>
                //        //                    <td>
                //        //                        <button class="btn btn-link" type="button" onclick="Dashboard.LinkProject(event, '${project.projectID}')">
                //        //                            Link Project
                //        //                        </button>
                //        //                    </td>
                //        //                </tr>
                //        //`           );
                //        //            });

                //        //        }
                //        //        else {
                //        //            document.getElementById("ExistingProjectNameId").style.display = "none";
                //        //        }

            },
            error: function (xhr) {
                console.error("Error:", xhr.status, xhr.responseText);
                callback(null, null, false);
            }
        });
    },
    toggleManualAddress: function () {
        const checkbox = document.getElementById("manualAddressCheck");
        const manualFields = document.getElementById("ManualAddressForm");
        if (checkbox.checked) {
/*            $("#IsAddAddress").val("True");*/
            manualFields.style.display = "block";   // show fields
        } else {
/*            $("#IsAddAddress").val("false");*/
            manualFields.style.display = "none";    // hide fields
        }
    },

    LinkProject: function (event, projectId) {
        $('#validationMessage').hide().text('');
        var projects = [];
        if (projectId > 0) {
            projects.push(projectId);
            if (projects.length === 0) {
                $('#validationMessage').text("Please add at least one project before submitting.").show();
                return;
            }

            $.post(APPURL + "Dashboard/SubmitProjects", { projects: projects }, function (response) {
                if (response.success) {
                    $('#ActionModal').modal('hide');
                    Dashboard.PopulateMyProjectData();
                } else {
                    $('#validationMessage').text(response.message || "Submission failed.").show();
                }
            });
        }
        else {
            alert("Project Not found");
        }

    },

    GetACHPDetail: function (achpNumber, callback) {
        var token = $('input[name="__RequestVerificationToken"]').val();

        $.ajax({
            url: APPURL + 'Dashboard/GetACHPDetails',
            type: 'POST',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            dataType: 'json',
            headers: {
                'RequestVerificationToken': token
            },
            data: { achpNumber: achpNumber },
            success: function (data) {
                var respCode = data.responseCode;
                var retAchp = data.achpNumber;
                var streetName = data.streetName;
                var projectId = data.projectId;
                var response = data.response;

                if (response && response !== '[]') {
                    callback(streetName, retAchp, projectId, true);
                } else {
                    callback(null, null, null, false);
                }
            },
            error: function (xhr) {
                console.error("Error:", xhr.status, xhr.responseText);
                callback(null, null, null, false);
            }
        });
    }


   
}
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

        console.log("Submitting projects:", projects);
        debugger;
        //var APPURL = '@Configuration["AppSettings:ApplicationURL"]';
        // Send to backend
        $.post(APPURL + "Dashboard?handler=SubmitProjects", { projects: projects }, function (response) {
            if (response.success) {
                $('#ActionModal').modal('hide');
                Dashboard.PopulateMyProjectData();
            } else {
                $('#validationMessage').text(response.message || "Submission failed.").show();
            }
        });
    },


    handleSubmitANP: function (e) {
        $('.validation-error').remove();

        var isValid = true;


        const input = document.getElementById("APNInput");
        const value = input.value.trim();
        document.getElementById("noAPNData").style.display = "none";
        if (value === '') {
            document.getElementById("APNError").style.display = "block";
            return;
        }
        else {
            document.getElementById("APNError").style.display = "none";
        }

        var selectedSiteAddress = $('#SiteAddressControlSelect').val();
        if (selectedSiteAddress === null || selectedSiteAddress === '') {
            $('#SiteAddressControlSelect').after('<span class="text-danger validation-error"> * Please select a site address.</span>');
            isValid = false;
        }

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

        if (isValid) {
            var projectModel = {
                SiteAddressID: $('#SiteAddressControlSelect').val(),
                ProjectAddress: $('#SiteAddressControlSelect option:selected').text(),
                ProjectName: projectName,
                PropertyNameInput: propertyName,
                APN: $('#APNInput').val().trim()
            };

            // Use $.ajax for full control over the request
            $.ajax({
                type: "POST",
                url: APPURL + "Dashboard?handler=CreateProject",
                data: JSON.stringify(projectModel), // Convert the object to a JSON string
                contentType: "application/json; charset=utf-8", // Set the content type
                dataType: "json",
                success: function (response) {
                    if (response.success) {
                        $('#ActionModal').modal('hide');
                        Dashboard.clearAPNForm();
                        Dashboard.PopulateMyProjectData();
                    } else {
                        $('#validationMessage').text(response.message || "Submission failed.").show();
                    }
                },
                error: function (xhr, status, error) {
                    console.error("AJAX Error:", error);
                }
            });
        }
    },

    clearAPNForm: function () {
        // Clear the value of the APN input field
        $('#APNInput').val('');

        // Clear the dropdown list, resetting it to the default option
        $('#SiteAddressControlSelect').empty().append('<option value="" disabled selected>Please Select a Site Address</option>');

        // Clear the project and property name input fields
        $('#projectNameInput').val('');
        $('#propertyNameInput').val('');

        // Remove any validation error messages that might be visible
        $('.validation-error').remove();
        $('#validationMessage').hide(); // Hide the main validation message if it's visible
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
                                var queryString = href.split("?");
                                var url = APPURL + "projectdetail?" + queryString[1];
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
                            "You have new comments on the following project(s): <b>" + fileNumber.trim() + "</b>"
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

    DisplayModal: function () {
        $('#ActionModal').modal('show');
        document.getElementById('acHpError').style.display = 'none';
        document.getElementById('noData').style.display = 'none';
        document.getElementById("acHpInput").value = '';
        document.getElementById('divProjects').innerHTML = '';
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
        debugger;
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
        console.log('ProjCount: ' + ctlIndex);
        const input = document.getElementById("acHpInput");
        const achpNumber = input.value.trim();
        debugger;

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

    SerachAPNClick: function () {
        var token = $('input[name="__RequestVerificationToken"]').val();
        var ctlIndex = GetControlIndex();
        console.log('ProjCount: ' + ctlIndex);
        const input = document.getElementById("APNInput");
        const APNNumber = input.value.trim();
        debugger;
        document.getElementById("noAPNData").style.display = "none";
        $.ajax({
            url: APPURL + 'Dashboard?handler=GetAPNProjectName',
            type: 'POST',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            headers: {
                'RequestVerificationToken': token
            },
            data: { APNNumber: APNNumber },
            success: function (response) {
                var dropdown = $('#SiteAddressControlSelect');
                dropdown.empty().append('<option value="" disabled selected>Please Select a Site Address</option>');

                // Check if the response is valid and has data
                if (response && response.length > 0) {
                    // Loop through the data and add options to the dropdown
                    $.each(response, function (i, item) {
                        dropdown.append($('<option>', {
                            value: item.id,      // Assuming the C# object has a 'id' property
                            text: item.fullAddress // Assuming the C# object has a 'projectName' property
                        }));
                    });
                } else {
                    document.getElementById("noAPNData").style.display = "block";

                }
            },
            error: function (xhr) {
                console.error("Error:", xhr.status, xhr.responseText);
                callback(null, null, false);
            }
        });
    },

    GetACHPDetail: function (achpNumber, callback) {
        debugger;
        var token = $('input[name="__RequestVerificationToken"]').val();
        //var APPURL = '@Configuration["AppSettings:ApplicationURL"]';
        $.ajax({
            url: APPURL + 'Dashboard?handler=GetACHPDetails',
            type: 'POST',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            headers: {
                'RequestVerificationToken': token
            },
            data: { achpNumber: achpNumber },
            success: function (data) {
                var retJson = data;

                var respCode = data.responseCode;
                var retAchp = data.achpNumber;
                var streetName = data.streetName;
                var projectId = data.projectId
                var response = data.response;

                if (response && response !== '[]') {
                    callback(streetName, retAchp, projectId, true);
                } else {
                    callback(null, null, null, false);
                }
            },
            error: function (xhr) {
                console.error("Error:", xhr.status, xhr.responseText);
                callback(null, null, false);
            }
        });
    },



}
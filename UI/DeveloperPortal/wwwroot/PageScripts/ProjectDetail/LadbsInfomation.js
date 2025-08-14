var dtPermitNumberDataTable;
var ldbsPropSnapshotId
var LadbsInformation=
{   
        init:function (propSnapshotId)  {
            ldbsPropSnapshotId=propSnapshotId;
            LadbsInformation.initPermitNumberList();
        },
        initPermitNumberList: function () 
        {

            if (!$.fn.DataTable.isDataTable('#dtPermitNumberData')) {
                dtPermitNumberDataTable = $('#dtPermitNumberData').dataTable({
                ajax: {
                        url: APPURL + 'ProjectDetail/GetPermitNumbers',
                    data: function (d) {
                        d.PropSnapshotID =ldbsPropSnapshotId
                    },
                    type: 'Post',
                    headers: {
                        "Content-Type": "application/x-www-form-urlencoded"
                    },
                    dataType: 'json'
                },
                columns: [{ data: 'permitData' }],
                processing: true,
                serverSide: true,
                pageLength: 1,
                pagingType: 'numbers',
                paging: true,
                searching: false,
                ordering: false,
                sorting: false,
                dom: "<'row'<'<'col-sm-12'p>>",
                oLanguage: {
                    sEmptyTable: "No record found."
                }
            })
            .on('preXhr.dt', function () {
                $('#loaderOverlay').fadeIn(100); // Show loading spinner
            })
            .on('xhr.dt', function () {
                $('#loaderOverlay').fadeOut(300); // Hide loading spinner
            });

            dtPermitNumberDataTable.on('draw.dt', function () {
                if ($("#dtPermitNumberData_paginate .select-site-title").length == 0) {
                    $("#dtPermitNumberData_paginate").prepend("<div class='select-site-title'>Permit Numbers: </div><br/>");
                }

                $(".dataTables_length").hide();
                var PermitNumberData = $('#dtPermitNumberData').dataTable().fnGetData();

                if (PermitNumberData.length > 0) {
                    $("#dtPermitNumberData_paginate").show();
                    var pageItems = $("#dtPermitNumberData_paginate .paginate_button ");
                    var permitList = PermitNumberData[0].permitList;
                    for (var i = 0; i < pageItems.length; i++) {
                        var text = pageItems[i].text
                        if (text != '…') {
                            if (parseInt(text) !== NaN) {
                                pageItems[i].text=permitList[parseInt(text) - 1];
                            }
                        }
                    }


                    if (pageItems.length == 0) {
                        $(".permit-number-buttons").attr("hidden", true);
                        $("#dtPermitNumberData_wrapper").attr("hidden", true);
                        $("#permit-number-directions").attr("hidden", true);
                    } else {
                        $(".permit-number-buttons").attr("hidden", false);
                        $("#dtPermitNumberData_wrapper").attr("hidden", false);
                        $("#permit-number-directions").attr("hidden", false);
                    }
                        $('#loaderOverlay').fadeOut(300);
                } else {
                    $("#dtPermitNumberData_paginate").hide();
                    $('#loaderOverlay').fadeOut(300);
                }

                $("a.paginate_button[aria-controls='dtPermitNumberData']").on('dblclick', function () {
                    var params = this.text.split(" ");
                    $("#permitNumberInformationPopup").modal("show");
                    $("#permitNumberInformationPopupTitle").html(`Permit Details: ${this.text}`);
                    $.ajax({
                        type: "GET",
                        url: APPURL + "ProjectDetail/GetPermitDetails",
                        data: {
                            PropsnapshotID:ldbsPropSnapshotId,
                            PermitNumber: params[0]
                        },
                        success: function (data) {
                            $("#permitNumberInformationPopup .modal-body").html(data);
                        },
                        error: function (result) {
                            console.log(result)
                        }
                    });
                });

                $("#dtPermitNumberData .sorting_disabled").attr("hidden", true);
            });
        }
        else {
            var table = $('#dtPermitNumberData').DataTable();
            $('#loaderOverlay').fadeIn(100); // Show loader before refresh
            table.clear().draw();
            table.ajax.reload(null, false); // false to stay on current page
            table.one('xhr', function () {
                $('#loaderOverlay').fadeOut(300); // Hide loader after refresh
            });
        }
    },
    syncPermitNumbers: function () {

        $('#invalid-permit-message').empty().hide();
        
        $.ajax({
            type: "POST",
            url: APPURL + "ProjectDetail/SaveLADBSData",
            data: {
                PropsnapshotID: ldbsPropSnapshotId,
                PermitNumber: null
            },
            success: function (data) {
                console.log(data)
                LadbsInformation.initPermitNumberList();
                // Show invalid permits, if any
                if (data.invalid && data.invalid.length > 0) {
                    const quotedInvalids = data.invalid.map(p => `"${p}"`).join(", ");

                    $('#invalid-permit-message')
                        .html(`
            <div class="alert alert-danger mt-2">
                <strong>Invalid Permit Numbers:</strong> ${quotedInvalids}<br/>
                <small class="text-muted">
                    Note: Permit numbers should contain dashes (e.g., 20016-10000-12345).
                    Other special characters, spaces, or unstructured words will be treated as invalid.
                </small>
            </div>
        `).show();
                } else {
                    $('#invalid-permit-message').empty().hide();
                }
            },
            error: function (result) {
                console.log(result)
            }
        });

    },

   linkPermitNumber: function () {

        $('#invalid-permit-message').empty().hide();
        var permitNumber = $("#LADBS_PermitNumber").val();
        
        if ((permitNumber === null || permitNumber.trim() === "")) {
            $("#LADBSerror").text("Permit Number or Department field is empty!");
            $("#LADBSerror").attr("hidden", false);
        }
        else {
            $.ajax({
                type: "POST",
                url: APPURL + "ProjectDetail/SaveLADBSData",
                data: {
                    PropsnapshotID: ldbsPropSnapshotId,
                    PermitNumber: permitNumber
                },
                success: function (data) {
                    console.log(data)
                    // Show invalid permits, if any
                    if (data.invalid && data.invalid.length > 0) {
                        const quotedInvalids = data.invalid.map(p => `"${p}"`).join(", ");

                        $('#invalid-permit-message')
                            .html(`
                            <div class="alert alert-danger mt-2">
                                Permit number <strong>${quotedInvalids}</strong> does not exist.<br/>
                                <small class="text-muted">
                                    Note: Permit numbers should contain dashes (e.g., 20016-10000-12345).
                                    Other special characters, spaces, or unstructured words will be treated as invalid.
                                </small>
                            </div>`).show();
                    } else {
                        $('#invalid-permit-message').empty().hide();
                    }
                },
                error: function (result) {
                    console.log(result)
                }
            });
            $('#loaderOverlay').fadeIn(100); // Show loading spinner
            $('#dtPermitNumberData').DataTable().clear().draw();

            LadbsInformation.initPermitNumberList();
        }
    },

    updatePermitNumber:function () {

        $('#invalid-permit-message').empty().hide();
        var params = $("#dtPermitNumberData_wrapper .active a").text().split(" ");
        console.log(params)
        $.ajax({
            type: "POST",
            url: APPURL + "ProjectDetail/SaveLADBSData",
            data: {
                PropsnapshotID: ldbsPropSnapshotId,
                PermitNumber: params[0]
            },
            success: function (data) {
                if (data == "OK") {
                    $/*('#loaderOverlay').fadeIn(100); // Show loading spinner*/
                    $("#LADBSerror").attr("hidden", true);
                    $("#dtPermitNumberData_wrapper .active a").dblclick();
                }
                else {
                    $("#LADBSerror").attr("hidden", false);
                }
            },
            error: function (result) {
                console.log(result)
            }
        });
    },

   deletePermitNumber: function() {

        $('#invalid-permit-message').empty().hide();
        var params = $("#dtPermitNumberData_wrapper .active a").text().split(" ");

        $.ajax({
            type: "POST",
            url: APPURL + "ProjectDetail/SaveLADBSData",
            data: {
                PropsnapshotID: ldbsPropSnapshotId,
                PermitNumber: params[0],
                Delete: true
            },
            success: function (data) {
                if (data == "OK") {
                    $('#loaderOverlay').fadeIn(100); // Show loading spinner
                    $("#LADBSerror").attr("hidden", true);

                    $('#dtPermitNumberData').DataTable().clear().draw();

                    LadbsInformation.initPermitNumberList();
                }
                else {
                    $("#LADBSerror").attr("hidden", false);
                }
            },
            error: function (result) {
                console.log(result)
            }
        });
    }

};
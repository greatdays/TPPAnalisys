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

            if ($.fn.DataTable.isDataTable('#dtPermitNumberData')) {
                $('#dtPermitNumberData').dataTable().fnDestroy();
            } dtPermitNumberDataTable = $('#dtPermitNumberData').dataTable({
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
            });

            dtPermitNumberDataTable.on('draw.dt', function () {
                if ($("#dtPermitNumberData_paginate .select-site-title").length == 0) {
                    $("#dtPermitNumberData_paginate").prepend("<div class='select-site-title'>Permit Numbers: </div><br/>");
                }

                $(".dataTables_length").hide();
                var PermitNumberData = $('#dtPermitNumberData').dataTable().fnGetData();

                if (PermitNumberData.length > 0 && PermitNumberData[0]!="") {
                    $("#dtPermitNumberData_paginate").show();
                    var pageItems = $("#dtPermitNumberData_paginate .paginate_button ");
                    var permitList = PermitNumberData[0].permitList;
                    for (var i = 0; i < pageItems.length; i++) {
                        var text = pageItems[i].text
                        if (text != '…') {
                            if (parseInt(text) !== NaN || parseInt(text) !== 'undefined' || parseInt(text) !== 'Previous') {
                                if (permitList[parseInt(text) - 1]) {
                                    pageItems[i].text = permitList[parseInt(text) - 1];
                                }
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
                } else {
                    $("#dtPermitNumberData_paginate").hide();
                }

                $("a.paginate_button[aria-controls='dtPermitNumberData']").on('dblclick', function () {
                    var params = this.text.split(" ");
                    $("#permitNumberInformationPopup").modal("show");
                    $("#permitNumberInformationPopupTitle").html(`Permit Details: ${this.text}`);
                    var payLoad = {
                        PropsnapshotID: ldbsPropSnapshotId,
                        PermitNumber: params[0]
                    };
                    AjaxCommunication.CreateRequest(this.window, "GET", APPURL + "ProjectDetail/GetPermitDetails", "", payLoad,
                        function (data) {
                            $("#permitNumberInformationPopup .modal-body").html(data);
                        }, null, true, null, false);
                });

                $("#dtPermitNumberData .sorting_disabled").attr("hidden", true);
            });
    },
    syncPermitNumbers: function () {

        $('#invalid-permit-message').empty().hide();

        var payLoad = {
            PropsnapshotID: ldbsPropSnapshotId,
            PermitNumber: null
        };
        AjaxCommunication.CreateRequest(this.window, "POST", APPURL + "ProjectDetail/SaveLADBSData", "", payLoad,
            function (data) {
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
            }, null, true, null, false);

    },

   linkPermitNumber: function () {
       $('#invalid-permit-message').empty().hide();
       $("#LADBSerror").attr("hidden", true);
        var permitNumber = $("#LADBS_PermitNumber").val();
        if ((permitNumber === null || permitNumber.trim() === "")) {
            $("#LADBSerror").text("Permit Number or Department field is empty!");
            $("#LADBSerror").attr("hidden", false);
        }
        else {
            var payLoad = {
                PropsnapshotID: ldbsPropSnapshotId,
                PermitNumber: permitNumber
            };
            AjaxCommunication.CreateRequest(this.window, "POST", APPURL + "ProjectDetail/SaveLADBSData", "", payLoad ,
                function (data) {
                    LadbsInformation.LinkPermitNumberSuccess(data);
                }, null, true, null, false);
        }
    },
    LinkPermitNumberSuccess: function (data) {
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
            LadbsInformation.initPermitNumberList();
            $("#LADBS_PermitNumber").val("")
        }
    },

    updatePermitNumber:function () {

        $('#invalid-permit-message').empty().hide();
        var params = $("#dtPermitNumberData_wrapper a.current").text().split(" ");
        var payLoad = {
            PropsnapshotID: ldbsPropSnapshotId,
            PermitNumber: params[0]
            };
        AjaxCommunication.CreateRequest(this.window, "POST", APPURL + "ProjectDetail/SaveLADBSData", "", payLoad,
            function (data) {
                if (data == "OK") {
                    $("#LADBSerror").attr("hidden", true);
                    $("#dtPermitNumberData_wrapper a.current").dblclick();
                }
                else {
                    $("#LADBSerror").attr("hidden", false);
                }
            }, null, true, null, false);
    },

   deletePermitNumber: function() {

        $('#invalid-permit-message').empty().hide();
        var params = $("#dtPermitNumberData_wrapper a.current").text().split(" ");

       var payLoad = {
           PropsnapshotID: ldbsPropSnapshotId,
           PermitNumber: params[0],
           Delete: true
       };
       AjaxCommunication.CreateRequest(this.window, "POST", APPURL + "ProjectDetail/SaveLADBSData", "", payLoad,
           function (data) {
               if (data == "OK") {
                   $("#LADBSerror").attr("hidden", true);
                   $('#dtPermitNumberData').DataTable().clear().draw();
               }
               else {
                   $("#LADBSerror").attr("hidden", false);
               }
           }, null, true, null, false);
    }
};
var IsLoadDevelopmentTeamTab = false;
var DevelopmentTeam =
{
    Init: function () {

        $("#PrimaryAssociationTypes").multiselect('rebuild');
        $("#AssociationTypes").multiselect('rebuild');
        $("#frmAddNewContact").on("submit", function (e) {
            debugger;
            if (!DevelopmentTeam.OnBegin()) { // custom function
                e.preventDefault(); // cancel submit if OnBegin returns false
                return;
            }

            e.preventDefault();
            var form = $(this);
            var url = 'DevelopmentTeam/SaveContact';
            $.ajax({
                url: url,
                type: form.attr("method"),
                data: new FormData(this),
                processData: false,
                contentType: false,
                success: function (response) {
                    DevelopmentTeam.OnSuccess(response); // your custom function
                }
            });
        });

    },
    LoadParticipants: function () {
        if (IsLoadDevelopmentTeamTab == false) {
            if ($.fn.DataTable.isDataTable('#dtDevelopmentTeamList')) {
                $('#dtDevelopmentTeamList').DataTable().destroy();
            }
            var url = 'DevelopmentTeam/List?projectId=' + ProjectId + '&caseId=' + Id;
            AjaxCommunication.CreateRequest(this.window, "GET", url, "", null,
                function (result) {
                    $('#divDevelopmentTeamList').html(result);
                    DevelopmentTeam.LoadDataTable();
                }, null, true, null, false);

            IsLoadDevelopmentTeamTab = false;
        }
    },
    LoadDataTable: function (result) {
        //var columns =
        //    [
        //        { data: 'contactName', title: "Name" },
        //        { data: 'email', title: "Email" },
        //        { data: 'phone', title: "Phone" },
        //        { data: 'fullAddress', title: "Full Address" },
        //        { data: 'contactType', title: "Type" },
        //        { data: 'source', title: "Source" },
        //        { data: 'status', title: "Status" },
        //        {
        //            data: null, title: "Actions",
        //            orderable: false, searchable: false,
        //            render: function (data, type, row) {
        //                return '<button role="button" class="editbtn btn k-button k-button-icontext k-grid-edit" title="Edit"  data-id="' + data.contactId + '"><i class="fas fa-pen editcontent"></i></button>&nbsp;'
        //                    + '<button role="button" class="deletebtn btn k-button k-button-icontext k-grid-Delete" title="Delete" data-id="' + data.contactId + '" onclick = "confirmDeleteContact(' + data.contactId + ',' + data.Name + ',' + data.ContactIdentifierID +')"><i class="fas fa - trash - alt deletecontent"></i></button>';

        //            }

        //        }
        //    ];

        $('#dtDevelopmentTeamList').dataTable({
            //data: result,
            //"columns": columns,
            processing: true,
            pageLength: 10,
            "paging": true,
            "searching": true,
            "ordering": false
        });
        //$('#dtDevelopmentTeamList tbody').on('click', '.deletebtn', function () {
        //    const id = $(this).data('id');
        //});
        //$('#dtDevelopmentTeamList tbody').on('click', '.editbtn', function () {
        //    const id = $(this).data('id');

        //});
    },
    Delete: function (contactId, contactName, contactIdentifierId) {
        $('#DeleteContactPopup .deleteContactId').val(contactId);
        $('#DeleteContactPopup .deleteContactIdentifierId').val(contactIdentifierId);
        $('#DeleteContactPopup .contactName').html(contactName);
        $('#DeleteContactPopup').modal('show');
    },
    Edit: function (ContactId) {
        var url = 'DevelopmentTeam/EditContact';
        AjaxCommunication.CreateRequest(this.window, 'POST', url, 'html', { controlViewId: ContactId, renderModel: null },
            function (data) {
                $('#AddContact').html(data);
                $('#ContactPopup').modal('show');
                $('#PopupTitle').html("Edit Contact");
            }, null, true, null, false);

    },
    Add: function (ContactId) {
        var url = 'DevelopmentTeam/AddContact';
        AjaxCommunication.CreateRequest(this.window, 'POST', url, 'html', { controlViewId: 0, renderModel: null },
            function (data) {
                $('#AddContact').html(data);
                $('#ContactPopup').modal('show');
                $('#PopupTitle').html("Add Contact");
            }, null, true, null, false);
    },
    SaveCotntact: function () {
        $('#frmAddNewContact').submit();
    },
    OnBegin: function () {
        debugger;
        var isVAlid = true;
        var identifierType = $('input[name="IdentifierType"]:checked').val();
        if (identifierType == "Structure" || identifierType == "Unit" || identifierType == "Address") {
            if ($('#identifierDropdown').val() == "0") {
                $('span[data-valmsg-for="IdentifierValue"]').html("Please select value");
                isVAlid = false;
            }
        }
        $('span[data-valmsg-for="IdentifierValue"]').empty();

        var regx = /^[A-Za-z0-9]+$/;
        var selectedA = $("#AssociationTypes option:selected");    /*Current Selected Values*/
        selectedA.each(function () {
            if ($(this).text() == 'CASP') {
                if ($.trim($("#CASpNumber").val()) == "") {
                    $("span[data-valmsg-for='CASpNumber']").html('Please enter CASP number');
                    $("#CASpNumber").focus();
                    isVAlid = false;
                }
                else if (!regx.test($("#CASpNumber").val())) {
                    $("span[data-valmsg-for='CASpNumber']").html('CASP number only accept alphanumeric value.');
                    $("#CASpNumber").focus();
                    isVAlid = false;
                }
            }
        });
        return isVAlid;
    },
    OnSuccess: function (data) {
        debugger;
        if (data==true) {
            

                $('#ContactPopup').modal("hide");
                if (contactRenderCallback) { contactRenderCallback(); }
            
        }
        else {
            $('#ContactPopup').modal("hide");
            $('#Error').modal("show");
        }
    }
}
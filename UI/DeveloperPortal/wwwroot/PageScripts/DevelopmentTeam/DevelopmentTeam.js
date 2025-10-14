var IsLoadDevelopmentTeamTab = false;
var DevelopmentTeam =
{
    Init: function () {
        // validate CASp number
        var regx = /^[A-Za-z0-9]+$/;
        $('#CASpNumber').keyup(function () {
            if (!regx.test(this.value) && $("#CASpNumber").val() != "") {
                $("span[data-valmsg-for='CASpNumber']").html('CASP number only accept alphanumeric value.');
            }
            else {
                $("span[data-valmsg-for='CASpNumber']").html('');
            }
        });


        $("#Type").change(function () {
            var selectedV = this.value;
            /*hide sohw contractor type*/
            if (selectedV.indexOf("Contractor") != -1) {
                $('#divContractorType').show();
            }
            else {
                $('#divContractorType').hide();
                $("#ContractorType").val("");
            }

            /*hide sohw CASP number*/
            if (selectedV.indexOf("CASP") != -1) {
                $("#divCASP").css('display', 'block');
            }
            else {
                $("#divCASP").css('display', 'none');
                $("#CASpNumber").val("");
            }
        });

        $('#ContactTypeListId').on('change', function () {
            if ($(this).val() == "Contractor") {
                $('#divContractorType').show();
            }
            else {
                $('#divContractorType').hide();
                $("#ContractorType").val("");
            }
        });

        $("#frmAddNewContact").on("submit", function (e) {
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
        if ($.fn.DataTable.isDataTable('#dtDevelopmentTeamList')) {
            $('#dtDevelopmentTeamList').DataTable().destroy();
        }
        var url = 'DevelopmentTeam/List?projectId=' + ProjectId + '&caseId=' + Id;
        AjaxCommunication.CreateRequest(this.window, "GET", url, "", null,
            function (result) {
                $('#divDevelopmentTeamList').html(result);
                DevelopmentTeam.LoadDataTable();
            }, null, true, null, false);

    },
    LoadDataTable: function (result) {
        $('#dtDevelopmentTeamList').dataTable({
            processing: true,
            pageLength: 10,
            "paging": true,
            "searching": true,
            ordering: true,
            responsive: true
        });
    },
    Delete: function (contactId, contactName, contactIdentifierId) {
        $('#DeleteContactPopup .deleteContactId').val(contactId);
        $('#DeleteContactPopup .deleteContactIdentifierId').val(contactIdentifierId);
        $('#DeleteContactPopup .contactName').html(contactName);
        $('#DeleteContactPopup').modal('show');
    },
    DeleteContact: function () {
        var contactId = $('#DeleteContactPopup .deleteContactId').val();
        var contactIdentifierId = $('#DeleteContactPopup .deleteContactIdentifierId').val();
        var url = APPURL + 'DevelopmentTeam/DeleteContact';
        AjaxCommunication.CreateRequest(this.window, 'POST', url, 'html', { contactId: contactId, contactIdentifierId: contactIdentifierId, refProjectId: ProjectId, refProjectSiteId: 0 },
            function (data) {
                if (data) {
                    $('#DeleteContactPopup').modal("hide");
                    DevelopmentTeam.LoadParticipants();
                    showMessage("Success", "Contact deleted Successfully.");
                }
                else {
                    $('#DeleteContactPopup').modal("hide");
                    $("#cnt_SuccessErrorMsg").html();
                    showMessage("Error", "Error occured while deleting contact.");

                }
            }, null, true, null, false);
    },
    Edit: function (contactIdentifierId, assnPropContactID, companyName) {
        var url = APPURL + 'DevelopmentTeam/EditContact ';
        var para = {
            ContactIdentifierId: contactIdentifierId,
            companyName: companyName,
            apn: "",
            caseId: Id,
            projectId: ProjectId,
        };
        if (contactList) {
            var contact = contactList.filter(c => c.contactIdentifierId == contactIdentifierId && c.assnPropContactID == assnPropContactID);
            if (contact && contact.length > 0) {
                para = contact[0];
                para.caseId = Id;
                para.projectId = ProjectId;
            }
        }
        AjaxCommunication.CreateRequest(this.window, 'POST', url, 'html', para,
            function (data) {
                $('#AddContact').html(data);
                $('#ContactPopup').modal('show');
                $('#PopupTitle').html("Edit Contact");
            }, null, true, null, false);

    },
    Add: function (contactId) {

        var url = APPURL + 'DevelopmentTeam/AddContact';
        var para = {
            contactId: contactId,
            apn: "",
            caseId: Id,
            projectId: ProjectId,
        };
        AjaxCommunication.CreateRequest(this.window, 'POST', url, 'html', para,
            function (data) {
                $('#AddContact').html(data);
                $(".emailRequire").hide();
                $('#ContactPopup').modal('show');
                $('#PopupTitle').html("Add Contact");
            }, null, true, null, false);
    },
    SaveCotntact: function () {
        $('#frmAddNewContact').submit();
    },
    OnBegin: function () {
        $("#loadingOverlay").hide();
        if ($("#Email").val() == "") {
            $(".emailRequire").show();
        }
        $("#Company").attr("data-val", 'false');
        $("#AddressLine2").attr("data-val", 'false');
        $("#PhoneExtension").attr("data-val", 'false');
        $("#MiddleName").attr("data-val", 'false');
        $("#PrimaryAssociationTypes").attr("data-val", 'false');
        $("#PhoneHome").attr("data-val", 'false');
        $("#PhoneCell").attr("data-val", 'false');
        $("#IsMarkedForMailing").attr("data-val", 'false');
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

        if (isVAlid) {
            var form = $("#frmAddNewContact");
            $(form).removeData("validator").removeData("unobtrusiveValidation");

            if ($.validator.unobtrusive) {
                $.validator.unobtrusive.parse($(form));
            }
            else { false }

            var validator = $(form).validate();
            var isModelValid = $(form).valid();

            if (false == isModelValid) {
                validator.focusInvalid();
                isVAlid = false;
            }
            $("#loadingOverlay").hide()
        }

        return isVAlid;
    },
    OnSuccess: function (data) {
        if (data == true) {
            $('#ContactPopup').modal("hide");
            IsLoadDevelopmentTeamTab = true;
            DevelopmentTeam.LoadParticipants()
        }
        else {
            $('#ContactPopup').modal("hide");
            $('#Error').modal("show");
        }
    }
}
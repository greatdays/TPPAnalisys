var cntFName = 0, cntLName = 0;

function SetMaxLength(ctlId, maxLength) {
    $('#' + ctlId).attr('maxlength', maxLength);
}

function ValidateName(ctlId, charCode) {
    var ctl = '#' + ctlId;
    var regex = new RegExp("^[a-zA-Z \.\'\-]+$");
    var fieldVal = $(ctl).val();
    var test = !regex.test(fieldVal);

    if (fieldVal != '') {
        if (test) {//invalid character exist
            if (ctlId == 'FirstName') {
                $(ctl).next('.text-danger').remove();
                $(ctl).after("<span class='text-danger' id='ctlFNameErr'>Only alphabets, spaces and the following symbols ' . - are allowed.</span>");
            }
            if (ctlId == 'MiddleName') {
                $(ctl).next('.text-danger').remove();
                $(ctl).after("<span class='text-danger' id='ctlMNameErr'>Only alphabets, spaces and the following symbols ' . - are allowed.</span>");
            }
            if (ctlId == 'LastName') {
                $('#ctlLNameErr').remove();
                $(ctl).after("<span class='text-danger' id='ctlLNameErr'>Only alphabets, spaces and the following symbols ' . - are allowed.</span>");
            }
        }
        else {
            if (ctlId == 'FirstName') {
                $(ctl).next('.text-danger').remove();
            }
            if (ctlId == 'MiddleName') {
                $(ctl).next('.text-danger').remove();
            }
            if (ctlId == 'LastName') {
                $(ctl).next('.text-danger').remove();
            }
        }
    }
    else {
        if (ctlId == 'FirstName') {
            $(ctl).next('.text-danger').remove();
            $(ctl).after("<span class='text-danger' id='ctlFNameErr'>Please enter your first name.</span>");
        }
        if (ctlId == 'MiddleName') {
            $(ctl).next('.text-danger').remove();
        }
        if (ctlId == 'LastName') {
            $(ctl).next('.text-danger').remove();
            $(ctl).after("<span class='text-danger' id='ctlLNameErr'>Please enter your last name.</span>");
        }
    }
}

function ValidateEmail(ctlId) {
    var ctl = '#' + ctlId;
    var email = $(ctl).val();

    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    var retVal = emailReg.test(email);

    if (!retVal) {
        $(ctl).next('.text-danger').remove();
        $(ctl).after("<span class='text-danger' id='ctlEmailErr'>Please enter a valid email address</span>");
    }
    else {
        $(ctl).next('.text-danger').remove();
    }
}

function ValidatePassword(ctlId) {
    var ctl = '#' + ctlId;
    var len = $(ctl).val().length;
    var ctlVal = $(ctl).val();

    if (ctlVal == '') {
        $(ctl).next('.text-danger').remove();
        $(ctl).after("<span class='text-danger' id='ctlPwdErr'>Please enter a password.</span>");
    }
    else {
        if (len < 6) {
            $(ctl).next('.text-danger').remove();
            $(ctl).after("<span class='text-danger' id='ctlPwdErr'>Password is not long enough.</span>");
        }
        else {
            $(ctl).next('.text-danger').remove();

            var pwd = $('#ConfirmPassword').val();
            var ctlConfPwd = '#ConfirmPassword';
            if (pwd != ctlVal) {
                $(ctlConfPwd).next('.text-danger').remove();
                $(ctlConfPwd).after("<span class='text-danger' id='ctlConfPwdErr'>Password does not match.</span>");
            }
            else {
                $(ctlConfPwd).next('.text-danger').remove();
            }
        }
    }
}

function ValidateConfirmPassword(ctlId) {
    var ctl = '#' + ctlId;
    var len = $(ctl).val().length;
    var ctlVal = $(ctl).val();

    if (ctlVal == '') {
        $(ctl).next('.text-danger').remove();
        $(ctl).after("<span class='text-danger' id='ctlConfPwdErr'>Please enter a password.</span>");
    }
    else {
        if (len < 6) {
            $(ctl).next('.text-danger').remove();
            $(ctl).after("<span class='text-danger' id='ctlConfPwdErr'>Password is not long enough.</span>");
        }
        else {
            var pwd = $('#Password').val();
            if (pwd != ctlVal) {
                $(ctl).next('.text-danger').remove();
                $(ctl).after("<span class='text-danger' id='ctlConfPwdErr'>Password does not match.</span>");
            }
            else {
                $(ctl).next('.text-danger').remove();
            }
        }
    }
}

function CheckIfEmpty(ctlId, key, msg) {
    var isErr = false;
    var ctl = '#' + ctlId;
    var ctlType = $(ctl).attr('type') == undefined ? $('#StreetDirection').get(0).tagName : $(ctl).attr('type');
    var message = '';

    if (msg != '') {
        message = msg;
    }
    else {
        message = 'Please enter your ' + key;
    }

    var errCount = $(ctl).next('.text-danger').length;

    switch (ctlType.toLowerCase()) {
        case 'text':
            if ($(ctl).val() == '' && errCount == 0) {
                isErr = true;
            }
            break;
        case 'select':
            var selIndex = $(ctl).prop('selectedIndex');
            if (selIndex == 0 && errCount == 0) {
                isErr = true;
            }
            break;
        default:
    }

    if (isErr) {
        $(ctl).next('.text-danger').remove();
        $(ctl).after("<span class='text-danger' id='ctl" + ctlId + "'>" + message + "</span>");
    }
}

function ClearErrorMessage(ctlId) {
    var ctl = '#' + ctlId;
    $(ctl).next('.text-danger').remove();
}

function IsTermsAndConditionsAccepted(ctlDivId, ctlId) {
    var ctl = '#' + ctlId;
    var ctlDiv = '#' + ctlDivId;
    var isAccepted = $(ctl).is(':checked');

    if (!isAccepted) {
        $(ctlDiv).next('.text-danger').remove();
        $(ctlDiv).after("<span class='text-danger' id='ctl" + ctlId + "'>Please agree to the Terms and Conditions.</span>");
    }
    else {
        $(ctlDiv).next('.text-danger').remove();
    }
}


//stopping from moving forward from one partial view to another without filling the details

function validateStep(stepContainer) {
    //console.log("called ", stepContainer);
    let isValid = true;

    $(stepContainer).find('[data-required="true"]').each(function () {
        let field = $(this);

        // Skip validation if hidden
        if (!field.is(':visible')) {
            return;
        }

        if (field.is(':radio')) {
            let group = field.attr('name');
            if ($('input[name="' + group + '"]:checked').length === 0) {
                isValid = false;
            }
        }
        else if (field.is(':checkbox')) {
            if (!field.is(':checked')) {
                isValid = false;
            }
        }
        else if (field.is('select')) {
            if (!field.val() || field.val() === "0") {
                isValid = false;
            }
        }
        else {
            if (!field.val().trim()) {
                isValid = false;
            }
        }
    });

    return isValid;
}

//function validateStep(stepContainer) {
//    console.log("called ", stepContainer);
//    let isValid = true;

//    $(stepContainer).find('[data-required="true"]:visible').each(function () {
//        let field = $(this);

//        if (field.is(':radio')) {
//            let group = field.attr('name');
//            if ($('input[name="' + group + '"]:checked').length === 0) {
//                isValid = false;
//            }
//        }
//        else if (field.is(':checkbox')) {
//            if (!field.is(':checked')) {
//                isValid = false;
//            }
//        }
//        else if (field.is('select')) {
//            // placeholder values like "" or "0" are invalid
//            if (!field.val() || field.val() === "0") {
//                isValid = false;
//            }
//        }
//        else {
//            if (!field.val() || field.val().trim() === "") {
//                isValid = false;
//            }
//        }
//    });

//    return isValid;
//}



//ends here



/* Contact Methods form validation */
function InitializeContactMethods() {
    console.log("contact method intialize");
    SetMaxLength('Extension', 5);
    SetMaxLength('UnitNumber', 20);
    SetMaxLength('City', 20);

    $('#PhoneNumber').mask('(999)999-9999')
    $('#ZipCode,#Extension').mask('99999');
    $('#POBox').val('No');
    $('#divPOBoxNo').show();

    $('#POBox[value="No"]').attr("checked", true);
    OnPOBoxChanged();

    $('#PhoneNumber').on('keyup', function () {
        ValidatePhone('PhoneNumber');
    });

    $('input[type=radio][name=POBox]').on('click', function () {
        OnPOBoxChanged();
    });

    $('#PhoneType').on('change', function () {
        ValidatePhoneType('PhoneType');
    });

    //fetch data to initialize PhoneType
    /*http://43svc/AAHRDev.Api/api/user/lookuplist"*/
    $.ajax({
        url: APPURL + "Account/GetLookupData?lookup=State", 
        type: 'GET',
        async: false,
        dataType: 'json',
        contentType: 'application/json',
        headers: {
            "Content-Type": "application/x-www-form-urlencoded"
        },
        data: "",
        success: function (data) {
            //console.log('success: ' + data);
            var json = JSON.parse(data);
            console.log('json: ' + json);
            //debugger;
            for (var index = 0; index < json.length; index++) {
                var stateName = json[index].StateName;
                var stateId = json[index].StateId;

                $('#State').append($('<option>').text(stateName).attr('value', stateId));
            }
            $('#State').val(0);
        },
        error: function (xhr) { }
    });
    //console.log('about to call phonetype');
    $.ajax({
        url: APPURL + "Account/GetLookupData?lookup=PhoneType",
        type: 'GET',
        async: false,
        dataType: 'json',
        contentType: 'application/json',
        headers: {
            "Content-Type": "application/x-www-form-urlencoded"
        },
        data: "",
        success: function (data) {
            //console.log('success: ' + data);
            var json = JSON.parse(data);
            console.log('PhoneType json: ' + json);
            //debugger;
            for (var index = 0; index < json.length; index++) {
                var phoneTypeText = json[index].PhoneTypeText;
                var phoneTypeValue = json[index].PhoneTypeValue;

                $('#PhoneType').append($('<option>').text(phoneTypeText).attr('value', phoneTypeValue));
            }
            $('#PhoneType').val(0);
        },
        error: function (xhr) { }
    });
    //console.log('about to call directions');
    $.ajax({
        url: APPURL + "Account/GetLookupData?lookup=Direction",
        type: 'GET',
        async: false,
        dataType: 'json',
        contentType: 'application/json',
        headers: {
            "Content-Type": "application/x-www-form-urlencoded"
        },
        data: "",
        success: function (data) {
            //console.log('success: ' + data);
            var json = JSON.parse(data);
            console.log('Direction json: ' + json);
            //debugger;
            for (var index = 0; index < json.length; index++) {
                var directionText = json[index].DirectionText;
                var directionValue = json[index].DirectionValue;

                $('#StreetDirection').append($('<option>').text(directionText).attr('value', directionValue));
            }
            $('#StreetDirection').val(0);
        },
        error: function (xhr) { }
    });

    //StreetType
    $.ajax({
        url: APPURL + "Account/GetLookupData?lookup=StreetType",
        type: 'GET',
        async: false,
        dataType: 'json',
        contentType: 'application/json',
        headers: {
            "Content-Type": "application/x-www-form-urlencoded"
        },
        data: "",
        success: function (data) {
            //console.log('success: ' + data);
            var json = JSON.parse(data);
            console.log('Street Type json: ' + json);
            //debugger;
            for (var index = 0; index < json.length; index++) {
                var streetTypeText = json[index].StreetTypeText;
                var streetTypeValue = json[index].StreetTypeValue;

                $('#StreetType').append($('<option>').text(streetTypeText).attr('value', streetTypeValue));
            }
            $('#StreetType').val(0);
        },
        error: function (xhr) { }
    });
    
}

function ValidatePhone(ctlId) {
    var ctl = '#' + ctlId;
    var ctlVal = $(ctl).cleanVal(); //get unmasked value

    var len = ctlVal.length;

    switch (len) {
        case 10:
            $(ctl).next('.text-danger').remove();
            break;
        case 0:
            $(ctl).next('.text-danger').remove();
            $(ctl).after("<span class='text-danger' id='ctl" + ctlId + "'>Please enter your phone number.</span>");
            break;
        default:
            $(ctl).next('.text-danger').remove();
            $(ctl).after("<span class='text-danger' id='ctl" + ctlId + "'>Input a valid 10 digit phone number.</span>");
    }
}

function ValidatePhoneType(ctlId) {
    var ctl = '#' + ctlId;
    var ctlVal = $(ctl).val();
    
    switch (ctlVal) {
        case '0':
            $(ctl).after("<span class='text-danger' id='ctl" + ctlId + "'>Please select a Phone Type.</span>");
            break;
        default:
            $(ctl).next('.text-danger').remove();
    }
}
function OnPOBoxChanged() {
    var selectedVal = $('input[name="POBox"]:checked').val();
    var delay = 600;
    var poBoxField = $('#POBoxNumber');

    if (selectedVal === 'Yes') {
        $('#divPOBoxYes').show(delay);
        $('#divPOBoxNo').hide(delay);
        poBoxField.attr('data-required', 'true');

        // Clear street fields
        clearMailingFields(["StreetNumber", "StreetDirection", "StreetName", "StreetType", "UnitNumber"]);

    } else {
        $('#divPOBoxYes').hide(delay);
        $('#divPOBoxNo').show(delay);
        poBoxField.removeAttr('data-required');
        poBoxField.val('');

        // Clear POBox
        clearMailingFields(["POBoxNumber"]);
    }

    // Re-run validation
    var currentStep = $('#divPOBoxYes').closest('.setup-content');
    var nextBtn = currentStep.find('.nextBtn');

    if (validateStep(currentStep)) {
        nextBtn.prop('disabled', false).removeClass('disabled-btn');
    } else {
        nextBtn.prop('disabled', true).addClass('disabled-btn');
    }
}

function clearMailingFields(fields) {
    let applicantJson = localStorage.getItem("ApplicantJson");
    if (!applicantJson) return;
    console.log("called clearning ");
    let data = JSON.parse(applicantJson);
    let contactInfo = data.Applicant.find(x => x.step === "ContactInfo")?.Data || {};
    console.log("contact info", contactInfo);
    fields.forEach(f => {
        let camelKey = f.charAt(0).toLowerCase() + f.slice(1); // e.g. StreetNumber → streetNumber
        if (contactInfo.hasOwnProperty(camelKey)) {
            contactInfo[camelKey] = "";
        }
    });

    // save back
    let idx = data.Applicant.findIndex(x => x.step === "ContactInfo");
    if (idx > -1) {
        data.Applicant[idx].Data = contactInfo;
    }

    localStorage.setItem("ApplicantJson", JSON.stringify(data));
}




//function OnPOBoxChanged() {
//    var selectedVal = $('#POBox:checked').val();
//    var delay = 600;
//    switch (selectedVal) {
//        case 'Yes':
//            $('#divPOBoxYes').show(delay);
//            $('#divPOBoxNo').hide(delay);
//            break;
//        case 'No':
//            $('#divPOBoxYes').hide(delay);
//            $('#divPOBoxNo').show(delay);
//            break;
//    }
//    var currentStep = $('#divPOBoxYes').closest('.setup-content');
//    var nextBtn = currentStep.find('.nextBtn');

//    if (validateStep(currentStep)) {
//        nextBtn.prop('disabled', false).removeClass('disabled-btn');
//    } else {
//        nextBtn.prop('disabled', true).addClass('disabled-btn');
//    }
//}

function CheckIfPOBoxFieldsAreEmpty() {
    var selectedVal = $('#POBox:checked').val();
    switch (selectedVal) {
        case 'Yes':
            ClearErrorMessage('StreetNumber');
            //ClearErrorMessage('StreetDirection');
            ClearErrorMessage('StreetName');
            //ClearErrorMessage('StreetType');
            //ClearErrorMessage('UnitNumber');

            CheckIfEmpty('POBoxNumber', '', 'P.O. Box Number is required');
            break;
        case 'No':
            ClearErrorMessage('POBoxNumber');

            CheckIfEmpty('StreetNumber', 'street number', '');
            //CheckIfEmpty('StreetDirection', 'street direction', '');
            CheckIfEmpty('StreetName', 'street name', '');
            //CheckIfEmpty('StreetType', 'street type', '');
            //CheckIfEmpty('UnitNumber', 'unit number', '');
            break;
    }
}

function GetControlIndex() {
    var retCtlIndex = 0;
    var projCount = $('#divProjects').children().length;
    var tempIndex = projCount;

    if (projCount > 0) {
        while (retCtlIndex < 1) {
            if ($('#div' + tempIndex).length == 0) {
                retCtlIndex = tempIndex;
            }
            else {
                tempIndex = tempIndex + 1;
            }
        }
    }
    else {
        retCtlIndex = 1;
    }
    //alert('ret: ' + retCtlIndex);
    return retCtlIndex;
}

function SaveLocalData(currentStep) {
    var json = localStorage.getItem('ApplicantJson');
    var j = $.parseJSON(json);
 
    switch (currentStep) {
        case "step-0":
            // AccountType - get selected radio label
            var selectedRadio = $('input[name="AccountType"]:checked');
            if (selectedRadio.length === 0) {
                console.warn("No account type selected.");
                break;
            }

            var selectedId = selectedRadio.val(); // e.g., "1138"
            var accountTypeLabel = $(`label[for="AccountType_${selectedId}"]`).text().trim();

            var step0Json = { 'accountType': accountTypeLabel };

            // Update the correct step in the JSON array
            let step0 = j.Applicant.find(x => x.step === "AccountType");
            if (step0) {
                step0.Data = step0Json;
            } else {
                j.Applicant.push({ step: "AccountType", Data: step0Json });
            }
            break;

        case "step-1":
            // Personal Information
            var step1Json = {
                firstName: $('#FirstName').val(),
                lastName: $('#LastName').val(),
                middleName: $('#MiddleName').val(),
                email: $('#Email').val(),
                companyName: $('#CompanyName').val(),
                title: $('#Title').val(),
                password: $('#Password').val()
            };

            let step1 = j.Applicant.find(x => x.step === "YourInfo");
            if (step1) {
                step1.Data = step1Json;
            } else {
                j.Applicant.push({ step: "YourInfo", Data: step1Json });
            }

            break;

        case "step-2":
            var isPOBox = $('input[name="POBox"]:checked').val() === "Yes";

            var step2Json = {
                phoneNumber: $('#PhoneNumber').val(),
                city: $('#City').val(),
                state: $('#State').val(),
                zipCode: $('#ZipCode').val(),
                phoneType: $('#PhoneType').val(),
                extension: $('#Extension').val(),
                streetNumber: isPOBox ? "" : $('#StreetNumber').val(),
                streetDirection: isPOBox ? "" : $('#StreetDirection').val(),
                streetName: isPOBox ? "" : $('#StreetName').val(),
                streetType: isPOBox ? "" : $('#StreetType').val(),
                unitNumber: isPOBox ? "" : $('#UnitNumber').val(),
                poBoxNumber: isPOBox ? $('#POBoxNumber').val() : "",
                poBox: $('input[name="POBox"]:checked').val()
            };

            let step2 = j.Applicant.find(x => x.step === "ContactInfo");
            if (step2) {
                step2.Data = step2Json;
            } else {
                j.Applicant.push({ step: "ContactInfo", Data: step2Json });
            }
            break;


        default:
            console.warn("Unrecognized step:", currentStep);
            break;
    }

    // ✅ Save updated data back to localStorage
    localStorage.setItem("ApplicantJson", JSON.stringify(j));
    console.log("Updated ApplicantJson:", localStorage.getItem("ApplicantJson"));
    populateSummary();
}


//function SaveLocalData(currentStep) {
//    var json = localStorage.getItem('ApplicantJson');
//    var j = $.parseJSON(json)
    
//    switch (currentStep) {
//        case "step-0":
//            var accountType = $('#AccountType option:selected').text();
//            var step0Json = { 'accountType': accountType };
//            j["Applicant"][2]["Data"] = step0Json;

//            break;
//        case "step-1":
//            var firstName = $('#FirstName').val();
//            var lastName = $('#LastName').val();
//            var middleName = $('#MiddleName').val();
//            var email = $('#Email').val();
//            var companyName = $('#CompanyName').val();
//            var title = $('#Title').val();
//            var password = $('#Password').val();

//            var step1Json = { 'firstName': firstName, 'lastName': lastName, 'middleName': middleName, 'email': email, 'companyName': companyName, 'title': title, 'password': password };

//            /*
//            New structure:
//            {
//                "Applicant":[
//                    {
//                        "step": "YourInfo",
//                        "Data": step1Json
//                    },
//                    {
//                        "step": "ContactInfo",
//                        "Data": step2Json
//                    },
//                    {
//                        "step": "ProjectList",
//                        "Data": step3Json
//                    }
//                ]
//            }
//            */
//            localStorage.setItem('YourInfo', JSON.stringify(step1Json));
//            console.log(JSON.stringify(step1Json));
//            j["Applicant"][0]["Data"] = step1Json;
            
//            break;
//        case "step-2":
//            var phoneNumber = $('#PhoneNumber').val();
//            var city = $('#City').val();
//            var state = $('#State').val();
//            var zipCode = $('#ZipCode').val();
//            var phoneType = $('#PhoneType').val();
//            var extension = $('#Extension').val();
//            var streetNumber = $('#StreetNumber').val();
//            var streetDirection = $('#StreetDirection').val();
//            var streetName = $('#StreetName').val();
//            var streetType = $('#StreetType').val();
//            var unitNumber = $('#UnitNumber').val();
//            var poBoxNumber = $('#POBoxNumber').val();
//            var poBox = $('#POBox:checked').val();

//            var step2Json = { 'phoneNumber': phoneNumber, 'city': city, 'state': state, 'zipCode': zipCode, 'phoneType': phoneType, 'extension': extension, 'streetNumber': streetNumber, 'streetDirection': streetDirection, 'streetName': streetName, 'streetType': streetType, 'unitNumber': unitNumber, 'poBoxNumber': poBoxNumber, 'poBox': poBox };

//            localStorage.setItem('ContactInfo', JSON.stringify(step2Json));
//            j["Applicant"][1]["Data"] = step2Json;
//            break;
//        //case "step-3":
//        //    var jsonObj = [];
//        //    $('#divProjects > div').each(function (index) {
//        //        console.log('index: ' + index);
//        //        var proj = $('#div' + (index + 1) + '>:first-child').text();
//        //        jsonObj.push(proj);
//        //    })
//        //    localStorage.setItem('ProjectList', JSON.stringify(jsonObj));
//        //    j["Applicant"][2]["Data"] = JSON.stringify(jsonObj);
//        //    break;
//        default:
//    }
//    localStorage.setItem("ApplicantJson", JSON.stringify(j));
//    console.log(localStorage.getItem("ApplicantJson"));
//}
/*Summary Page*/
function LoadSummaryPage() {
    var yourInfo = localStorage.getItem('YourInfo');
    var contactInfo = localStorage.getItem('ContactInfo');
    //var projList = localStorage.getItem('ProjectList');
    var json = '';

    if (yourInfo != undefined) {
        json = JSON.parse(yourInfo);
        var name = json.firstName + ' ' + json.lastName;

        $('#spnName').text(name);
        $('#spnCompanyName').text(json.companyName);
        $('#spnTitle').text(json.title);
        $('#spnLoginId').text(json.email);
    };

    if (contactInfo != undefined) {
        json = JSON.parse(contactInfo);
        //console.log('contact Info JSON: ' + json);
        var phoneNumber = json.phoneNumber;
        var extn = json.extension;
        var poBox = json.poBox;
        var poBoxNumber = json.poBoxNumber;
        var streetNumber = json.streetNumber;
        var streetName = json.streetName;
        var streetDirection = json.streetDirection;
        var streetType = json.streetType;
        var unitNumber = json.unitNumber;
        var city = json.city;
        var state = json.state;
        var zip = json.zipCode;

        var line2 = city + ', ' + state + ' ' + zip;
        var line1 = '';

        if (poBox == 'Yes') {
            line1 = 'P.O. Box ' + poBoxNumber //+ ' ' + streetDirection + ' ' + streetName + ' ' + streetType + ' ' + 
            
        }
        else {
            //number dir name type unit#
            //state, state zip
            line1 = streetNumber + ' ' + streetDirection + ' ' + streetName + ' ' + streetType + ' ' + unitNumber
        }
        //console.log('poBox: ' + poBox + 'line1: ' + line1);

        $('#spnPhoneNumber').text(phoneNumber);
        $('#spnExtn').text(extn);
        $('#spnMailingAddress1').text(line1);
        $('#spnMailingAddress2').text(line2);
    }

    //console.log('projList:' + projList);
    if (projList != undefined) {
        json = JSON.parse(projList);
        var spanProj = '';
        console.log('json lenght:' + json.length);

        $('#divProjectsSummary').empty();

        if (json.length > 0) {
            for (index = 0; index < json.length; index++) {
                spanProj = "<span style = 'display:block'>" + json[index] + "</span>";
                $('#divProjectsSummary').append(spanProj);
            }
        }
        else {
            $('#spnNone').remove();
            spanProj = "<span style = 'display:block' id='spnNone'>None</span>";
            $('#divProjectsSummary').append(spanProj);
        }
    }
}
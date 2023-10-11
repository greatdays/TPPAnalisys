function fnBlockUI_withMessage(message) {

    var displayMsg = message;

    $.blockUI({
        message: '<span id="blockUIMessage" role="status" aria-live="polite"><i class="fas fa-spinner fa-spin" title="' + displayMsg + '"></i>' + displayMsg +'</span>',
        css: {
            top: "50%",
            left: "38%",
            width: "auto",
            height: "auto",
            textAlign: "center",
            color: "#000",
            "font-size": "30px",
            border: "0px",
            backgroundColor: "#ffffff",
            padding: "0px",
            margin: 0,
            opacity: 1,
            cursor: "wait",
            "z-index": 1555

        },
        overlayCSS: {
            opacity: "0.25",
            "z-index": 1551
        }
    });
    $('.hcidlas-portal-mein').removeAttr('aria-busy');
    $('.hcidlas-portal-mein').attr('aria-busy', 'true');
    $('#sr-status-only').html(displayMsg);
}

function fnUnblockUI_withMessage() {
    $.unblockUI();
    $(document.activeElement.id).focus();
    $('.hcidlas-portal-mein').removeAttr('aria-busy');
    $('.hcidlas-portal-mein').attr('aria-busy', 'false');
    $('#sr-status-only').html('');
}





function fnBlockUI_Signup() {
    $.blockUI({
        message: '<span id="blockUIMessage" role="status" aria-live="polite"><i class="fas fa-spinner fa-spin" title="Creating your account, please wait..."></i>Creating your account, please wait...</span>',
        css: {
            top: "50%",
            left: "38%",
            width: "auto",
            height: "auto",
            textAlign: "center",
            color: "#000",
            "font-size": "30px",
            border: "0px",
            backgroundColor: "#ffffff",
            padding: "0px",
            margin: 0,
            opacity: 1,
            cursor: "wait",
            "z-index": 1555

        },
        overlayCSS: {
            opacity: "0.25",
            "z-index": 1551
        }
    });
    $('.hcidlas-portal-mein').removeAttr('aria-busy');
    $('.hcidlas-portal-mein').attr('aria-busy', 'true');
    $('#sr-status-only').html('Creating your account, please wait...');
}

function fnUnblockUI_Signup() {
    $.unblockUI();
    $(document.activeElement.id).focus();
    $('.hcidlas-portal-mein').removeAttr('aria-busy');
    $('.hcidlas-portal-mein').attr('aria-busy', 'false');
    $('#sr-status-only').html('');
}

function fnBlockUI_UpdateProfile() {
    $.blockUI({
        message: '<span id="blockUIMessage" role="status" aria-live="polite"><i class="fas fa-spinner fa-spin" title="Updating your account, please wait..."></i>Updating your account, please wait...</span>',
        css: {
            top: "50%",
            left: "38%",
            width: "auto",
            height: "auto",
            textAlign: "center",
            color: "#000",
            "font-size": "30px",
            border: "0px",
            backgroundColor: "#ffffff",
            padding: "0px",
            margin: 0,
            opacity: 1,
            cursor: "wait",
            "z-index": 1555

        },
        overlayCSS: {
            opacity: "0.25",
            "z-index": 1551
        }
    });
    $('.hcidlas-portal-mein').removeAttr('aria-busy');
    $('.hcidlas-portal-mein').attr('aria-busy', 'true');
    $('#sr-status-only').html('Updating your account, please wait...');
}

function fnUnblockUI_UpdateProfile() {
    $.unblockUI();
    $(document.activeElement.id).focus();
    $('.hcidlas-portal-mein').removeAttr('aria-busy');
    $('.hcidlas-portal-mein').attr('aria-busy', 'false');
    $('#sr-status-only').html('');
}

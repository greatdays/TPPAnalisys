// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/************************************************************************************************************ 
ACCORDIAN
*************************************************************************************************************/
// function used for collapsable accrodian when IsCollapse flag maintain in database.
function accrodianSlideToggle(h3Id, contentDivId, isCollapsed) {
    
    if (isCollapsed == null) { isCollapsed = true; }
    if (isCollapsed) {
        $(contentDivId).hide();
        $(h3Id).addClass('downarrow');
        $(h3Id).attr("aria-expanded", true);
    }
    else {
        $(h3Id).addClass('uparrow');
        //AAHR-18
        $(h3Id).attr("aria-expanded", true);
    }
    $(h3Id).click(function () {
        $(contentDivId).slideToggle("fast", function () {
            if ($(h3Id).hasClass('downarrow')) {
                $(h3Id).removeClass('downarrow');
                $(h3Id).addClass('uparrow');
                $(h3Id).attr("aria-expanded", true);
            }
            else {
                $(h3Id).removeClass('uparrow');
                $(h3Id).addClass('downarrow');
                $(h3Id).attr("aria-expanded", false);
            }
        });
        return false;
    });
}

function CollapseAll() {
    if ($('#CollapseIn').is(':visible') == true) {
        $('#CollapseIn').hide();
        $('#CollapseOut').show();
        $(".card-header-title.uparrow").each(function () {
            $(this).click()
        })
    }
    else {
        $('#CollapseOut').hide();
        $('#CollapseIn').show();
        $(".card-header-title.downarrow").each(function () {
            $(this).click()
        })
    }
}

// Tooltip initialization
window.initializeTooltip = (element) => {
    var tooltip = new bootstrap.Tooltip(element, {
        trigger: 'hover focus'
    });
};

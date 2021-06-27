////////////////////////////////////////////////////////////// Handlers:
$(function () {

    $('[id*=ch_IsSuggestion]').change(function () {

        var isChecked = ($(this).attr('checked') == 'checked' ? true : false);
        changeEnable(isChecked);

    });

});
////////////////////////////////////////////////////////////// Functions:
function changeEnable(enabled) {
    $('[id*=tb_SuggestedBy]').attr('disabled', !enabled);
    $('[id*=uc_DateOfSuggest]').attr('disabled', !enabled);
    $('[id*=tb_LetterNo]').attr('disabled', !enabled);
    if (enabled)
        $('[id*=tb_SuggestedBy]').focus();
}

function openMap(root) {
    var shape = $("[id*=hid_ShapeInfo]").val();
    if ($.trim(shape).length > 0) {
        OpenFull(root + 'ToolWindows/Map.aspx?type=passname&shape=' + shape);
    }
    else {
        OpenFull(root + 'ToolWindows/Map.aspx?type=passname');
    }
    return false;
}
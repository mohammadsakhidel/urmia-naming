function openMap(root, point, shape) {
    if ($.trim(shape).length > 0) {
        OpenFull(root + 'ToolWindows/Map.aspx?shape=' + shape + '&type=passway&point=' + point);
    }
    else {
        OpenFull(root + 'ToolWindows/Map.aspx?type=passway&point=' + point);
    }
    return false;
}

function openNames(root) {
    Open(root + 'ToolWindows/SelectPassName.aspx', '', 750, 450);
}

function openMosavabs(root) {
    Open(root + 'ToolWindows/SelectMosavab.aspx', '', 750, 450);
}
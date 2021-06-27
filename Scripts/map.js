function SaveShapeInfo() {
    var shapeInfo = document.forms[0]["WindowContent_uc_MapShapeEditor_hid_Shape"].value;
    var myForm = opener.document.forms[0];
    // for passway form:
    if (document.forms[0]["WindowContent_uc_MapShapeEditor_hid_Type"].value == 'passway') {
        myForm["ContentPlace_ContentPlace_uc_PasswayEditor_hid_ShapeInfo"].value = shapeInfo;
        myForm["ContentPlace_ContentPlace_uc_PasswayEditor_tb_Length"].value = document.forms[0]["WindowContent_uc_MapShapeEditor_hid_Distance"].value;
    }
    else if (document.forms[0]["WindowContent_uc_MapShapeEditor_hid_Type"].value == 'passname') {
        myForm["ContentPlace_ContentPlace_uc_PassNameEditor_hid_ShapeInfo"].value = shapeInfo;
    }
    window.close();
}

function SavePasswayBegin() {

    var latlng = String(document.forms[0]["hid_LastPoint"].value);
    if (latlng.length > 0) {

        var myForm = opener.document.forms[0];
        myForm["tb_BeginingLatitude"].value = latlng.split(',')[0];
        myForm["tb_BeginingLongitude"].value = latlng.split(',')[1];

    }
    window.close();

}

function SavePasswayEnd() {

    var latlng = String(document.forms[0]["hid_LastPoint"].value);
    if (latlng.length > 0) {

        var myForm = opener.document.forms[0];
        myForm["tb_EndingLatitude"].value = latlng.split(',')[0];
        myForm["tb_EndingLongitude"].value = latlng.split(',')[1];

    }
    window.close();

}
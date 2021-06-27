function ReturnShomare(shomare) {
    var myForm = opener.document.forms[0];
    myForm["ctl00$ctl00$ContentPlace$ContentPlace$uc_PasswayEditor$tb_MosavabID"].value = shomare;
    window.close();
}
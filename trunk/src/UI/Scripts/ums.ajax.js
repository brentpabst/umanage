function cancelPostback() {
    var objMan = Sys.WebForms.PageRequestManager.getInstance();
    if (objMan.get_isInAsyncPostBack())
        objMan.abortPostBack();
}
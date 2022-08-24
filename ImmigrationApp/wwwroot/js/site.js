function ShowToaster(type, text) {
    let toasterType;
    let title;
    switch (type) {
        case 1:
        default:
            toasterType = "success";
            title = "Success";
            break;
        case 0:
            toasterType = "error";
            title = "Error!";
            break;
    }
    toasting.create({
        "title": "" + title + "",
        "text": "" + text + "",
        "type": "" + toasterType + "",
    });
}
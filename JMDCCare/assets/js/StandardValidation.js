﻿function fNumberonly(event) {
    // Allow only backspace and delete
    if (event.keyCode == 46 || event.keyCode == 8) {
        // let it happen, don't do anything
    }
    else {
        // Ensure that it is a number and stop the keypress
        if (event.keyCode < 48 || event.keyCode > 57) {
            event.preventDefault();
        }
    }
}
function fValidateDelete() {
    if (confirm('Do you want to delete record.')) {
        return true;
    }
    else {
        return false;
    }
}
function fredirect() {
    window.location = "../TitleSetting.aspx";
}

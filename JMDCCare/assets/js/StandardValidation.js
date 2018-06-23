function fNumberonly(event) {
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
function Priority_Constraint(e) {
    var varKey;
    if (window.event)
        varKey = window.event.keyCode;
    else
        varKey = e.which;
    if (varKey >= 48 && varKey <= 57 || varKey == 8 || varKey == 127 || varKey == 0)
        return true;
    else
        return false;
}
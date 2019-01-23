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
function pClearFields(Parent) {
    var varElements = document.getElementById(Parent).getElementsByTagName('INPUT');
    for (var varForLoop = 0; varForLoop < varElements.length; varForLoop++) {
        if (varElements[varForLoop].type.toLowerCase() == 'text' || varElements[varForLoop].type.toLowerCase() == 'textarea') varElements[varForLoop].value = '';
        else if (varElements[varForLoop].type.toLowerCase() == 'checkbox') varElements[varForLoop].checked = false;
    }
    var varElements = document.getElementById(Parent).getElementsByTagName('SELECT');
    for (var varForLoop = 0; varForLoop < varElements.length; varForLoop++) {
        varElements[varForLoop].selectedIndex = -1;
    }
    var varElements = document.getElementById(Parent).getElementsByTagName('textarea');
    for (var varForLoop = 0; varForLoop < varElements.length; varForLoop++) {
        varElements[varForLoop].value = '';
    }
}
function pUnLockControls(Parent) {
    var varElements = document.getElementById(Parent).getElementsByTagName('INPUT');
    for (var varForLoop = 0; varForLoop < varElements.length; varForLoop++) {
        if (varElements[varForLoop].type.toLowerCase() == 'text' || varElements[varForLoop].type.toLowerCase() == 'textarea')
            varElements[varForLoop].readOnly = false;
        else if (varElements[varForLoop].type.toLowerCase() == 'radio' || varElements[varForLoop].type.toLowerCase() == 'checkbox')
            varElements[varForLoop].disabled = false;
    }
    var varElements = document.getElementById(Parent).getElementsByTagName('SELECT');
    for (var varForLoop = 0; varForLoop < varElements.length; varForLoop++) {
        varElements[varForLoop].disabled = false;
    }
    var varElements = document.getElementById(Parent).getElementsByTagName('textarea');
    for (var varForLoop = 0; varForLoop < varElements.length; varForLoop++) {
        varElements[varForLoop].readOnly = false;
    }
}
function pLockControls(Parent, cflag) {
    debugger;
    if (cflag == "L") {
        var varElements = document.getElementById(Parent).getElementsByTagName('INPUT');
        for (var varForLoop = 0; varForLoop < varElements.length; varForLoop++) {
            if (varElements[varForLoop].type.toLowerCase() == 'text' || varElements[varForLoop].type.toLowerCase() == 'textarea')
                varElements[varForLoop].readOnly = true;
            else if (varElements[varForLoop].type.toLowerCase() == 'radio' || varElements[varForLoop].type.toLowerCase() == 'checkbox')
                varElements[varForLoop].disabled = true;
        }
        var varElements = document.getElementById(Parent).getElementsByTagName('SELECT');
        for (var varForLoop = 0; varForLoop < varElements.length; varForLoop++) {
            if (varElements[varForLoop].id != 'lstCDisplay') varElements[varForLoop].disabled = true;
        }
        var varElements = document.getElementById(Parent).getElementsByTagName('textarea');
        for (var varForLoop = 0; varForLoop < varElements.length; varForLoop++) {
            varElements[varForLoop].readOnly = true;
        }
    }
    else {
        var varElements = document.getElementById(Parent).getElementsByTagName('INPUT');
        for (var varForLoop = 0; varForLoop < varElements.length; varForLoop++) {
            if (varElements[varForLoop].type.toLowerCase() == 'text' || varElements[varForLoop].type.toLowerCase() == 'textarea')
                varElements[varForLoop].readOnly = false;
            else if (varElements[varForLoop].type.toLowerCase() == 'radio' || varElements[varForLoop].type.toLowerCase() == 'checkbox')
                varElements[varForLoop].disabled = false;
        }
        var varElements = document.getElementById(Parent).getElementsByTagName('SELECT');
        for (var varForLoop = 0; varForLoop < varElements.length; varForLoop++) {
            varElements[varForLoop].disabled = false;
        }
        var varElements = document.getElementById(Parent).getElementsByTagName('textarea');
        for (var varForLoop = 0; varForLoop < varElements.length; varForLoop++) {
            varElements[varForLoop].readOnly = false;
        }
    }
}
function ShowPopup() {
    debugger;
    $("#myModal").modal('show');
    pClearFields('aspnetForm');  
}

// event handler to initialize text in input box and clear onFocus
// Usage:
// onFocus="initTextInput(this,'clear')"
// onBlur="initTextInput(this,'setDefault') 
function initTextInput(element, action, text, cssname, checkForDefault) {
    var txt = text;
    if (text == null || text == "") {
        txt = "SEARCH"
    }

    if (element != null) {
        switch (action) {
            case 'clear':
                cl = cssname;
                if (cssname == null) {
                    cl = 'searchboxsub-on';
                }
                if (element.value == txt) {
                    element.value = "";
                    element.className = cl;
                }
                break;
            case 'setDefault':
                cl = cssname;
                if (cssname == null) {
                    cl = 'searchboxsub';
                }
                if (element.value == "") {
                    element.value = txt;
                    element.className = cl;
                }
                break;
            default:
                break;
        }
    }
}

function checkForDefaultInput(fieldId, defaultInput) {
    var fieldContent;
    if (w3) {
        fieldContent = document.getElementById(fieldId).value;
    } else if (ie) { //this is ie
        fieldContent = eval("document.all." + fieldId + ".value");
    } else {  //this is netscape 
        fieldContent = eval("document.layers." + fieldId + ".value");
    }
    return (fieldContent == defaultInput);
}
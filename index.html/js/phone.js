function phoneNum() {
    var e = event || window.event;  // get event object
    var key = e.keyCode || e.which; // get key cross-browser
    var invalid = true;

    if (key != 08 && key != 09 && key != 11 && key != 48 && key != 49 && key != 50 && key != 51 && key != 52 && key != 53 && key != 54 &&
        key != 55 && key != 56 && key != 57) { //if it is not a number or backspace ascii code
        //Prevent default action, which is inserting character
        if (e.preventDefault) {
            e.preventDefault();
        } //normal browsers

        e.returnValue = false; //IE
    } else {
        invalid = false;
    }
    if (invalid == true) {
        document.getElementById('num-only').id = 'num-only-alert';
        invalid = false;
    } else {
        document.getElementById('num-only-alert').id = 'num-only';
    }
};
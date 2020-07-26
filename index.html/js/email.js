function checkEmail(id) {
    var input = document.getElementById(id).value;
    var check = input.includes('@');

    if (check == false) {
        document.getElementById('email-check-alert').textContent = 'Invalid Email Address';
    }
    else if (check == true) {
        document.getElementById('email-check-alert').textContent = '';
    } 
};
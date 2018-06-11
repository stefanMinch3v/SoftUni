function validate() {
    let username = $('#username');
    let email = $('#email');
    let password = $('#password');
    let confirmPassword = $('#confirm-password');
    let companyInfo = $('#companyInfo');
    let companyNumber = $('#companyNumber');
    let allValidFields = true;
    let validDiv = $('#valid');
    let companyCheckBox = $('#company').on('change', function () {
        if(companyCheckBox.is(':checked')){
            companyInfo.fadeIn(() => companyInfo.css('display', 'inline'));
        } else {
            companyInfo.fadeOut(() => companyInfo.css('display', 'none'));
        }
    });
    let submitBtn = $('#submit');

    submitBtn.on('click', function(ev) {
        ev.preventDefault();

        validateForm();

        if(allValidFields){
            validDiv.css('display', 'block');
        } else {
            validDiv.css('display', 'none');
        }

        allValidFields = true;
    });

    function validateForm() {
        validateInputWithRegex(username, /^[a-zA-Z0-9]{3,20}$/g);

        if(password.val() === confirmPassword.val()){
            validateInputWithRegex(password, /^[a-zA-Z0-9_]{5,15}$/g);
            validateInputWithRegex(confirmPassword, /^[a-zA-Z0-9_]{5,15}$/g);
        } else {
            password.css('border', 'solid red');
            confirmPassword.css('border', 'solid red');
            allValidFields = false;
        }

        validateInputWithRegex(email, /^.*?@.*?\..*$/g);
        validateCompany();

        function validateCompany() {
            let number = +companyNumber.val();
            if(companyCheckBox.is(':checked')){
                if(number >= 1000 && number <= 9999){
                    companyNumber.css('border', 'none');
                } else {
                    companyNumber.css('border', 'solid red');
                    allValidFields = false;
                }
            }
        }
    }
    
    function validateInputWithRegex(input, pattern) {
        if(pattern.test(input.val())){
            input.css('border', 'none');
        } else {
            input.css('border', 'solid red');
            allValidFields = false;
        }
    }
}

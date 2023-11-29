// -------------- AUTHENTICATION FORM --------------
const authContainer = document.querySelector('#container');
const registerBtn = document.querySelector('#register');
const loginBtn = document.querySelector('#login');

registerBtn.onclick = () => {
    authContainer.classList.add("active");
}

loginBtn.onclick = () => {
    authContainer.classList.remove("active");
}

document.querySelector('.close-form').onclick = () => {
    authContainer.classList.remove('isDisplay')
}

document.querySelector('.user-icon').onclick = () => {
    authContainer.classList.add('isDisplay')
}

$('#registerForm').submit(function (event) {
    event.preventDefault();
    var form = $(this);
    $.ajax({
        type: form.attr('method'),
        url: form.attr('action'),
        data: form.serialize(),
        success: function (data) {
            // Remove previous error messages
            form.find('.text-danger').remove();

            if (data.isValid) {
                // Close the modal and show a success message
                var notyf = new Notyf();
                notyf.success('Register successfully.');
            } else if(data.errors) {
                // Display the validation errors
                for (var i = 0; i < data.errors.length; i++) {
                    var error = data.errors[i];
                    var inputElement = form.find('input[name="' + error.key + '"]');
                    var errorElement = $('<span class="text-danger"></span>');
                        errorElement.text(error.errorMessage);
                        inputElement.after(errorElement);
                }
                console.log($('.auth-container').height());
                $('.auth-container').height(550);
            }
        }
    });
});


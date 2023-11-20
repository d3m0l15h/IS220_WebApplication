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
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

// userIcon khoi tao o main.js
userIcon.onclick = () => {
    authContainer.classList.add('isDisplay')
}

document.onclick = (e) => {
    if (!userIcon.contains(e.target) && !authContainer.contains(e.target))
        authContainer.classList.remove('isDisplay');
}
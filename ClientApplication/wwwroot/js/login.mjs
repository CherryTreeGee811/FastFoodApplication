import { getToken } from './api.mjs';


export function loadFormJS() {
    const loginBtn = document.getElementById("login-btn");

    loginBtn.addEventListener("click", function () {
        manageSubmission();
    });
}


function manageSubmission() {
    const emailElement = document.getElementById("email-input");
    const passwordElement = document.getElementById("password-input");

    getToken(emailElement.value, passwordElement.value)
        .then(() => {
            const loginLinkElement = document.getElementById("login-link");
            loginLinkElement.style.display = 'none';
            loginLinkElement.ariaHidden = true;
            const logoElement = document.getElementById("logo");
            logoElement.click();
        }).catch(error => {
            console.error("An error occured while trying to log in ", error);
        });
}
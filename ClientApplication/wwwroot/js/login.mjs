import { getToken } from './api.mjs';
import { getEmployeeByEmail } from './employee/api.mjs';
import { getAccessTokenFromCookie, getRoleFromToken } from './token-parser.mjs';
import { routeHandler } from './router.mjs';


export function loadLoginForm(navContentDiv, contentDiv) {
    const loginBtn = document.getElementById("login-btn");

    loginBtn.addEventListener("click", function () {
        manageSubmission(navContentDiv, contentDiv);
    });
}


function manageSubmission(navContentDiv, contentDiv) {
    const emailElement = document.getElementById("email-input");
    const passwordElement = document.getElementById("password-input");

    getToken(emailElement.value, passwordElement.value)
        .then(() => {
            // Check if an existing token exists
            const token = getAccessTokenFromCookie();
            if (token) {
                const role = getRoleFromToken(token);
                if (role === "Manager") {
                    window.history.pushState({}, '', '/employees/list');
                    routeHandler(navContentDiv, contentDiv);
                }
                else {
                    getEmployeeByEmail(emailElement.value).then(employee => {
                        window.history.pushState({}, '', `/employees/details?id=${employee.employeeId}`);
                        routeHandler(navContentDiv, contentDiv);
                    });
                }
            }
        }).catch(error => {
            console.error("An error occured while trying to log in ", error);
        });
}
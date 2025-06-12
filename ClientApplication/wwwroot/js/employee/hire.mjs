import { getAllRoles, hireEmployee } from './api.mjs';
import { routeHandler } from '../router.mjs';


export function loadHireForm(navContentDiv, contentDiv) {
    const roleSelectListElement = document.getElementById('role-select-list');
    const loadingTextElement = document.getElementById('loading-text');
    const errorTextElement = document.getElementById('error-text');

    loadingTextElement.textContent = 'Loading roles...';
    errorTextElement.textContent = '';
    roleSelectListElement.innerHTML = '';


    getAllRoles()
        .then(roles => {
            roles.forEach(role => {
                const option = document.createElement('option');
                option.value = role.jobTitleId;
                option.textContent = role.jobTitle;
                roleSelectListElement.appendChild(option);
            });

            loadingTextElement.textContent = '';
        }).catch (error => {
            if (error.message.includes("404")) {
                errorTextElement.textContent = "Endpoint not found";
            } else if (error.message.includes("400")) {
                errorTextElement.textContent = "Invalid data was passed";
            } else if (error.message.includes("500")) {
                errorTextElement.textContent = "Internal server error";
            } else {
                errorTextElement.textContent = "Unknown error";
            }
            loadingTextElement.textContent = "";
        });

    const hireEmployeeBtn = document.getElementById("hire-employee-btn");
    hireEmployeeBtn.addEventListener("click", function () {
        manageSubmission(navContentDiv, contentDiv);
    });
}


function manageSubmission(navContentDiv, contentDiv) {
    const errorTextElement = document.getElementById('error-text');
    const email = document.getElementById("email-input").value;
    const firstName = document.getElementById("first-name-input").value;
    const lastName = document.getElementById("last-name-input").value;
    const role = document.getElementById("role-select-list").value;
    const password = document.getElementById("password-input").value;

    if (!firstName || !lastName || !role || !password) {
        errorTextElement.textContent = "Please fill in all fields.";
        return;
    }

    // Call the API to hire the employee
    hireEmployee(email, firstName, lastName, role, password)
        .then(() => {
            window.location.href = '/employees/list';
            routeHandler(navContentDiv, contentDiv);
        })
        .catch(error => {
            console.error('Error hiring employee:', error);
            errorTextElement.textContent = "Failed to hire employee. Please try again.";
        });
}
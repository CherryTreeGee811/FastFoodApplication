import { loadFormJS } from './login.mjs';
import { getAccessTokenFromCookie } from './token-parser.mjs';
import { handleEmployeeRoutes, initEmployeeLinkListeners } from './employee/router.mjs';


/**
 * Initializes the application when the DOM is fully loaded.
 * 
 * This function sets up the main content area, initializes event listeners for 
 * navigation links, and handles routing based on the current URL path. It also 
 * loads the appropriate templates and data.
 * 
 * @function
 * @returns {void} This function does not return a value.
 */
document.addEventListener("DOMContentLoaded", () => {
    const contentDiv = document.getElementById("content");
    const navContentDiv = document.getElementById("nav-content");

    // Event listener for the home link
    document.getElementById("home-link").addEventListener("click", (e) => {
        e.preventDefault();
        window.history.pushState({}, '', '/');
        routeHandler(contentDiv);
    });


    // Handle browser back/forward navigation
    window.addEventListener("popstate", routeHandler);

    // Initialize link listeners for radiation measurements
    initEmployeeLinkListeners(contentDiv, routeHandler);

    // Load Navigation Bar
    loadNavTemplate(navContentDiv);

    // Initial route handling
    routeHandler(contentDiv);
});


/**
* Loads an HTML template and updates the specified contentDiv with the fetched content.
* 
* This function fetches the specified template from the server and updates the 
* inner HTML of the provided contentDiv. If the fetch operation fails, it displays 
* an error message in the contentDiv.
* 
* @function loadTemplate
* @param {string} templateName - The name of the template file to load.
* @param {HTMLElement} contentDiv - The HTML element where the template will be loaded.
* @returns {void} This function does not return a value.
* 
* @example
* // Load the home template into the contentDiv
* loadTemplate("home.html", contentDiv);
*/
export function loadTemplate(templateName, contentDiv) {
    return fetch(`/templates/${templateName}`)
        .then(response => {
            if (!response.ok) throw new Error('Network response was not ok');
            return response.text();
        })
        .then(html => {
            contentDiv.innerHTML = html;
            return Promise.resolve();
        })
        .catch(error => {
            contentDiv.innerHTML = `<h1>Error loading template</h1><p>${error.message}</p>`;
            return Promise.reject(error);
        });
}


/**
* Loads an HTML template and updates the specified contentDiv with the fetched content.
* 
* This function fetches the specified template from the server and updates the 
* inner HTML of the provided contentDiv. If the fetch operation fails, it displays 
* an error message in the navContentDiv.
* 
* @function loadTemplate
* @param {string} templateName - The name of the template file to load.
* @param {HTMLElement} contentDiv - The HTML element where the template will be loaded.
* @returns {void} This function does not return a value.
* 
* @example
* // Load the home template into the contentDiv
* loadNavTemplate(navContentDiv);
*/
export function loadNavTemplate(navContentDiv) {
    let role = "anonymous";
    let templateName = "anonymous.html";

    // Check if an existing token exists
    const token = getAccessTokenFromCookie();
    if (token) {
        console.log("Token found in cookie:", token);
        templateName = "employee.html"
    }

    return fetch(`/templates/navigation/${templateName}`)
        .then(response => {
            if (!response.ok) throw new Error('Network response was not ok');
            return response.text();
        })
        .then(html => {
            navContentDiv.innerHTML = html;
            return Promise.resolve();
        })
        .catch(error => {
            navContentDiv.innerHTML = `<h1>Error loading template</h1><p>${error.message}</p>`;
            return Promise.reject(error);
        });
}


/**
* Handles routing based on the current URL path.
* 
* This function determines which template to load and which data to fetch based 
* on the current URL path. It updates the contentDiv with the appropriate template 
* and data.
* 
* @function routeHandler
* @returns {void} This function does not return a value.
*/
export function routeHandler(contentDiv) {
    const path = window.location.pathname;
    switch (true) {
        case path == '/':
            loadTemplate("home.html", contentDiv);
            break;
        case path.startsWith('/employees'):
            handleEmployeeRoutes(path, contentDiv);
            break
        case path == '/login':
            loadTemplate("login.html", contentDiv).then(() => {
                return loadFormJS()
            }).catch((error) => {
                console.error('Error loading login form js:', error);
            });
            break;
        default:
            contentDiv.innerHTML = `<h1>404 Not Found</h1>`;
    }
}
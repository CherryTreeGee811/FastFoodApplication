import { loadNavTemplate } from './navigation/router.mjs';
import { loadHomePage } from './home.mjs';
import { swapUserNameInNavBar } from './navigation/navigation.mjs';
import { loadLoginForm } from './login.mjs';
import { getAccessTokenFromCookie, deleteTokenCookie } from './token-parser.mjs';
import { handleEmployeeRoutes } from './employee/router.mjs';
import { requestLogout } from './api.mjs';


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
    const navContentDiv = document.getElementById("navbar-list");

    // Handle browser back/forward navigation
    window.addEventListener("popstate", routeHandler);

    // Initial route handling
    routeHandler(navContentDiv, contentDiv);
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
* Handles routing based on the current URL path.
* 
* This function determines which template to load and which data to fetch based 
* on the current URL path. It updates the contentDiv with the appropriate template 
* and data.
* 
* @function routeHandler
* @returns {void} This function does not return a value.
*/
export function routeHandler(navContentDiv, contentDiv) {
    const path = window.location.pathname;
    loadNavTemplate(navContentDiv, contentDiv).then(() => {
        swapUserNameInNavBar();
    });
    switch (true) {
        case path == '/':
            loadTemplate("home.html", contentDiv).then(() => {
                return loadHomePage();
            });
            break;
        case path.startsWith('/employees'):
            handleEmployeeRoutes(path, navContentDiv, contentDiv);
            break;
        case path == '/login':
            loadTemplate("login.html", contentDiv).then(() => {
                return loadLoginForm(navContentDiv, contentDiv);
            }).catch((error) => {
                console.error('Error loading login form js: ', error);
            });
            break;
        case path == '/logout':
            const token = getAccessTokenFromCookie();
            requestLogout(token).then(() => {
                deleteTokenCookie();
                window.history.pushState({}, '', '/');
                routeHandler(navContentDiv, contentDiv);
            }).catch((error) => {
                console.error('Error logging out: ', error);
            });
            break;
        default:
            contentDiv.innerHTML = `<h1>404 Not Found</h1>`;
    }
}
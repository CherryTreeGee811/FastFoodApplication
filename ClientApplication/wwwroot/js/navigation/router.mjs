import { routeHandler } from '../router.mjs';
import { getAccessTokenFromCookie, getRoleFromToken } from '../token-parser.mjs';


function initGeneralLinkListeners(navContentDiv, contentDiv) {
    document.getElementById("home-link").addEventListener("click", (e) => {
        e.preventDefault();
        window.history.pushState({}, '', '/');
        routeHandler(navContentDiv, contentDiv);
    });
}


function initAuthenticatedLinkListeners(navContentDiv, contentDiv) {
    document.getElementById("logout-link").addEventListener("click", (e) => {
        e.preventDefault();
        window.history.pushState({}, '', '/logout');
        routeHandler(navContentDiv, contentDiv);
    });
}


function initUnauthenticatedLinkListeners(navContentDiv, contentDiv) {
    document.getElementById("login-link").addEventListener("click", (e) => {
        e.preventDefault();
        window.history.pushState({}, '', '/login');
        routeHandler(navContentDiv, contentDiv);
    });
}

function initEmployeeLinkListeners(navContentDiv, contentDiv) {
    document.getElementById("details-link").addEventListener("click", (e) => {
        e.preventDefault();
        window.history.pushState({}, '', '/employees/details');
        routeHandler(navContentDiv, contentDiv);
    });
}

function initManagerLinkListeners(navContentDiv, contentDiv) {
    document.getElementById("list-link").addEventListener("click", (e) => {
        e.preventDefault();
        window.history.pushState({}, '', '/employees/list');
        routeHandler(navContentDiv, contentDiv);
    });
}


export function loadNavTemplate(navContentDiv, contentDiv) {
    let role = "anonymous";
    let templateName = "anonymous.html";

    // Check if an existing token exists
    const token = getAccessTokenFromCookie();
    if (token) {
        role = getRoleFromToken(token);
        if (role === "Manager") {
            templateName = "manager.html";
        }
        else {
            templateName = "employee.html";
        }
    }

    return fetch(`/templates/navigation/${templateName}`)
        .then(response => {
            if (!response.ok) throw new Error('Network response was not ok');
            return response.text();
        })
        .then(html => {
            navContentDiv.innerHTML = html;
            initNavLinkListeners(templateName, navContentDiv, contentDiv);
            return Promise.resolve();
        })
        .catch(error => {
            navContentDiv.innerHTML = `<h1>Error loading template</h1><p>${error.message}</p>`;
            return Promise.reject(error);
        });
}


function initNavLinkListeners(templateName, navContentDiv, contentDiv) {
    initGeneralLinkListeners(navContentDiv, contentDiv);
    if ((templateName === "employee.html") || (templateName === "manager.html")) {
        initAuthenticatedLinkListeners(navContentDiv, contentDiv);

        if (templateName === "manager.html") {
            initManagerLinkListeners(navContentDiv, contentDiv);
        }
        else {
            initEmployeeLinkListeners(navContentDiv, contentDiv);
        }
    }
    else {
        initUnauthenticatedLinkListeners(navContentDiv, contentDiv);
    }
}
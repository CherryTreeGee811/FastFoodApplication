import { routeHandler } from '../router.mjs';


export function initGeneralLinkListeners(navContentDiv, contentDiv) {
    document.getElementById("home-link").addEventListener("click", (e) => {
        e.preventDefault();
        window.history.pushState({}, '', '/');
        routeHandler(navContentDiv, contentDiv);
    });
}


export function initAuthenticatedLinkListeners(navContentDiv, contentDiv) {
    document.getElementById("logout-link").addEventListener("click", (e) => {
        e.preventDefault();
        window.history.pushState({}, '', '/logout');
        routeHandler(navContentDiv, contentDiv);
    });
}


export function initUnauthenticatedLinkListeners(navContentDiv, contentDiv) {
    document.getElementById("login-link").addEventListener("click", (e) => {
        e.preventDefault();
        window.history.pushState({}, '', '/login');
        routeHandler(navContentDiv, contentDiv);
    });
}

export function initEmployeeLinkListeners(navContentDiv, contentDiv) {
    document.getElementById("details-link").addEventListener("click", (e) => {
        e.preventDefault();
        window.history.pushState({}, '', '/employees/details');
        routeHandler(navContentDiv, contentDiv);
    });
}

export function initManagerLinkListeners(navContentDiv, contentDiv) {
    document.getElementById("list-link").addEventListener("click", (e) => {
        e.preventDefault();
        window.history.pushState({}, '', '/employees/list');
        routeHandler(navContentDiv, contentDiv);
    });
}
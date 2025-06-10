import { getAccessTokenFromCookie } from '../token-parser.mjs';
import { baseUrl } from '../api.mjs';


export function getAllEmployees() {
    const url = `${baseUrl}/employees`;
    const accessToken = getAccessTokenFromCookie();

    return fetch(url, {
        mode: 'cors',
        method: 'GET',
        headers: {
            'Authorization': `Bearer ${accessToken}`,
            'Accept': 'application/json',
            'Accept-Language': 'en-CA',
        }
    })
        .then(response => {
            if (response.ok) {
                if (response.status === 204) {
                    return null;
                } else {
                    return response.json();
                }
            } else if (response.status == 401) {
                const loginLinkElem = document.getElementById("login-link");
                loginLinkElem.style.display = "block";
                loginLinkElem.ariaHidden = false;
                loginLinkElem.click();
            } else {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
        })
        .catch(error => {
            throw error;
        });
}


export function fireEmployee(employeeId) {
    const url = `${baseUrl}/employees/${employeeId}`;
    const accessToken = getAccessTokenFromCookie();

    return fetch(url, {
        mode: 'cors',
        method: 'DELETE',
        headers: {
            'Authorization': `Bearer ${accessToken}`,
            'Accept': 'application/json',
            'Accept-Language': 'en-CA',
        }
    })
        .then(response => {
            if (response.ok) {
                if (response.status === 204) {
                    return null;
                } else {
                    return response.json();
                }
            } else if (response.status == 401) {
                const loginLinkElem = document.getElementById("login-link");
                loginLinkElem.style.display = "block";
                loginLinkElem.ariaHidden = false;
                loginLinkElem.click();
            } else {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
        })
        .catch(error => {
            throw error;
        });
}
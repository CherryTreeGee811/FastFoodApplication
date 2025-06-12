// API base URL for login.
export const baseUrl = "http://localhost:8000/api";


export function getToken(username, password) {
    const url = `${baseUrl}/login`;

    const body = JSON.stringify({
        email: `${username}`,
        password: `${password}`
    });

    return fetch(url, {
        method: 'POST',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Accept-Language': 'en-CA',
            'Content-Type': 'application/json',
            'Content-Language': 'en-CA',
        },
        body: body,
    })
        .then(response => {
            if (response.ok) {
                if (response.status === 204) {
                    return true;
                } else {
                    return response.json();
                }
            } else if (response.status == 401) {
                document.getElementById("login-link").click();
            } else {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
        })
        .then(data => {
            if (data && data.token) {
                document.cookie = `token=${data.token}; path=/; SameSite=Strict;`;
            }
        })
        .catch(error => {
            throw error;
        });
}


export function requestLogout(token) {
    const url = `${baseUrl}/logout`;

    return fetch(url, {
        method: 'POST',
        mode: 'cors',
        headers: {
            'Authorization': `Bearer ${token}`,
            'Accept': 'application/json',
            'Accept-Language': 'en-CA',
        },
    })
        .then(response => {
            if (response.ok) {
                if (response.status === 204) {
                    return true;
                } else {
                    return response.json();
                }
            } else if (response.status == 401) {
                document.getElementById("login-link").click();
            } else {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
        })
        .catch(error => {
            throw error;
        });
}


export function getAllPromotionalImages() {
    const url = `${baseUrl}/carousel`;

    return fetch(url, {
        method: 'GET',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Accept-Language': 'en-CA',
        },
    })
        .then(response => {
            if (response.ok) {
                if (response.status === 204) {
                    return true;
                } else {
                    return response.json();
                }
            } else {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
        })
        .catch(error => {
            throw error;
        });
}


export function uploadPromotionalImages(images, token) {
    const url = `${baseUrl}/carousel`;

    return fetch(url, {
        method: 'POST',
        mode: 'cors',
        headers: {
            'Authorization': `Bearer ${token}`,
            'Accept': 'application/json',
            'Accept-Language': 'en-CA',
            'Content-Language': 'en-CA',
        },
        body: images,
    })
        .then(response => {
            if (response.ok) {
                if (response.status === 204) {
                    return true;
                } else {
                    return response.json();
                }
            } else {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
        })
        .catch(error => {
            throw error;
        });
}
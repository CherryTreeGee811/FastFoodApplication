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


export function getEmployeeById(employeeId) {
    const url = `${baseUrl}/employees/${employeeId}`;
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


export function getEmployeeByEmail(employeeEmail) {
    const url = `${baseUrl}/employees/email/${employeeEmail}`;
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


export function hireEmployee(email, firstName, lastName, role, password) {
    const url = `${baseUrl}/register`;
    const accessToken = getAccessTokenFromCookie();

    const body = JSON.stringify({
        email: `${email}`,
        firstName: `${firstName}`,
        lastName: `${lastName}`,
        jobTitleId: `${role}`,
        password: `${password}`
    });

    return fetch(url, {
        mode: 'cors',
        method: 'POST',
        headers: {
            'Authorization': `Bearer ${accessToken}`,
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


export function getAllRoles() {
    const url = `${baseUrl}/employees/roles`;
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


export function getAllTrainingModules() {
    const url = `${baseUrl}/employees/trainingmodules`;
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


export function getAllWorkStations() {
    const url = `${baseUrl}/employees/workstations`;
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


export function getAllShifts() {
    const url = `${baseUrl}/employees/shifts`;
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


export function updateEmployeeRole(employeeId, roleId) {
        const url = `${baseUrl}/employees/${employeeId}`;
    const accessToken = getAccessTokenFromCookie();
    const body = JSON.stringify({
        jobTitleId: roleId
    });
    return fetch(url, {
        mode: 'cors',
        method: 'PATCH',
        headers: {
            'Authorization': `Bearer ${accessToken}`,
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


export function updateEmployeeWorkStation(employeeId, stationId) {
    const url = `${baseUrl}/employees/${employeeId}`;
    const accessToken = getAccessTokenFromCookie();
    const body = JSON.stringify({
        stationId: stationId
    });
    return fetch(url, {
        mode: 'cors',
        method: 'PATCH',
        headers: {
            'Authorization': `Bearer ${accessToken}`,
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


export function nofifyEmployeeOfShifts(employeeId) {
    const url = `${baseUrl}/employees/shifts/send-email/${employeeId}`;
    const accessToken = getAccessTokenFromCookie();
    return fetch(url, {
        mode: 'cors',
        method: 'POST',
        headers: {
            'Authorization': `Bearer ${accessToken}`,
            'Accept': 'application/json',
            'Accept-Language': 'en-CA',
        },
    })
        .then(response => {
            if (response.ok) {
                if (response.status === 204) {
                    return null;
                } else {
                    return {};
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


export function nofifyAllEmployeesOfShifts() {
    const url = `${baseUrl}/employees/shifts/send-email`;
    const accessToken = getAccessTokenFromCookie();
    return fetch(url, {
        mode: 'cors',
        method: 'POST',
        headers: {
            'Authorization': `Bearer ${accessToken}`,
            'Accept': 'application/json',
            'Accept-Language': 'en-CA',
        },
    })
        .then(response => {
            if (response.ok) {
                if (response.status === 204) {
                    return null;
                } else {
                    return {};
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


export function assignEmployeeShift(employeeId, shiftId, shiftDate) {
    const url = `${baseUrl}/employees/${employeeId}/shifts`;
    const accessToken = getAccessTokenFromCookie();
    const body = JSON.stringify({
        shiftId: shiftId,
        shiftDate: shiftDate
    });
    return fetch(url, {
        mode: 'cors',
        method: 'POST',
        headers: {
            'Authorization': `Bearer ${accessToken}`,
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


export function assignEmployeeTraining(employeeId, trainingId) {
    const url = `${baseUrl}/employees/trainingmodules/${employeeId}/${trainingId}`;
    const accessToken = getAccessTokenFromCookie();
    return fetch(url, {
        mode: 'cors',
        method: 'POST',
        headers: {
            'Authorization': `Bearer ${accessToken}`,
            'Accept': 'application/json',
            'Accept-Language': 'en-CA',
        },
    })
        .then(response => {
            if (response.ok) {
                if (response.status === 204) {
                    return null;
                } else {
                    return {};
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


export function getShiftsByEmployeeId(employeeId) {
    const url = `${baseUrl}/employees/${employeeId}/shifts`;
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


export function getTrainingModulesByEmployeeId(employeeId) {
    const url = `${baseUrl}/employees/${employeeId}/trainings`;
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


export function markTrainingAsComplete(employeeId, trainingId) {
    const url = `${baseUrl}/employees/${employeeId}/trainings/${trainingId}/complete`;
    const accessToken = getAccessTokenFromCookie();

    return fetch(url, {
        mode: 'cors',
        method: 'PATCH',
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
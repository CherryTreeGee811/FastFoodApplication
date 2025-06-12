import {
    getAllRoles, getAllTrainingModules, getAllWorkStations, getAllShifts,
    updateEmployeeRole, updateEmployeeWorkStation, nofifyEmployeeOfShifts, assignEmployeeShift,
    assignEmployeeTraining, getEmployeeById
} from "./api.mjs";
import { routeHandler } from "../router.mjs";


export function loadManageForm(idParam, navContentDiv, contentDiv) {
    const loadingTextElement = document.getElementById("loading-text");
    const employeeListLinkElement = document.getElementById("employee-list-link");
    loadingTextElement.textContent = "Loading employee data...";
    getEmployeeById(idParam).then(employee => {
        const employeeNameAndIdTextElement = document.getElementById("employee-name-and-id");
        employeeNameAndIdTextElement.textContent = `Employee Name: ${employee.firstName} ${employee.lastName}`;
        loadRoleForm(idParam, employee);
        loadWorkStationForm(idParam, employee);
    });
    loadShiftsForm(idParam);
    loadTrainingModulesForm(idParam);
    loadingTextElement.textContent = "";

    employeeListLinkElement.addEventListener("click", function (event) {
        event.preventDefault();
        window.history.pushState({}, "", "/employees/list");
        routeHandler(navContentDiv, contentDiv);
    });
}


function loadRoleForm(idParam, employee) {
    const errorTextElement = document.getElementById("error-text");
    const successTextElement = document.getElementById("success-text");
    const roleSelectListElement = document.getElementById("role-select-list");
    const promoteDemoteButton = document.getElementById("promote-demote-btn");
    getAllRoles().then(roles => {
        roles.forEach(role => {
            const optionElement = document.createElement("option");
            optionElement.value = role.jobTitleId;
            optionElement.textContent = role.jobTitle;
            if (role.jobTitle === employee.jobTitle) {
                optionElement.selected = true;
            }
            roleSelectListElement.appendChild(optionElement);
        });
    }).catch(error => {
        if (error.message.includes("404")) {
            errorTextElement.textContent += "Roles endpoint not found ";
        } else if (error.message.includes("500")) {
            errorTextElement.textContent += "Internal server error loading roles ";
        } else {
            errorTextElement.textContent += "Unknown error loading roles ";
        }
    });
    promoteDemoteButton.addEventListener("click", function () {
        const selectedRole = roleSelectListElement.value;
        updateEmployeeRole(idParam, selectedRole)
            .then(() => {
                errorTextElement.textContent = "";
                successTextElement.textContent = "Job title updated successfully";
            }).catch(error => {
                successTextElement.textContent = "";
                if (error.message.includes("404")) {
                    errorTextElement.textContent = "Update job title endpoint not found";
                } else if (error.message.includes("500")) {
                    errorTextElement.textContent = "Internal server error updating job title";
                } else {
                    errorTextElement.textContent = `Unknown error updating job title ${error}`;
                }
            });
    });
}


function loadWorkStationForm(idParam, employee) {
    const errorTextElement = document.getElementById("error-text");
    const successTextElement = document.getElementById("success-text");
    const workStationSelectListElement = document.getElementById("station-select-list");
    const relocateButton = document.getElementById("relocate-btn");
    getAllWorkStations().then(workStations => {
        workStations.forEach(workStation => {
            const optionElement = document.createElement("option");
            optionElement.value = workStation.stationId;
            optionElement.textContent = workStation.stationName;
            if (workStation.stationName === employee.stationName) {
                optionElement.selected = true;
            }
            workStationSelectListElement.appendChild(optionElement);
        });
    }).catch(error => {
        if (error.message.includes("404")) {
            errorTextElement.textContent += "Work stations endpoint not found ";
        } else if (error.message.includes("500")) {
            errorTextElement.textContent += "Internal server error loading work stations ";
        } else {
            errorTextElement.textContent += "Unknown error loading work stations ";
        }
    });
    relocateButton.addEventListener("click", function () {
        const selectedWorkStation = workStationSelectListElement.value;
        updateEmployeeWorkStation(idParam, selectedWorkStation)
            .then(() => {
                errorTextElement.textContent = "";
                successTextElement.textContent = "Work station updated successfully";
            }).catch(error => {
                successTextElement.textContent = "";
                if (error.message.includes("404")) {
                    errorTextElement.textContent = "Update work station endpoint not found";
                } else if (error.message.includes("500")) {
                    errorTextElement.textContent = "Internal server error updating work station";
                } else {
                    errorTextElement.textContent = `Unknown error updating work station: ${error}`;
                }
            });
    });
}


function loadShiftsForm(idParam) {
    const errorTextElement = document.getElementById("error-text");
    const successTextElement = document.getElementById("success-text");
    const shiftDateInputElement = document.getElementById("shift-date-input");
    const shiftSelectListElement = document.getElementById("shift-select-list");
    const notifyShiftButton = document.getElementById("notify-shift-btn");
    const scheduleShiftButton = document.getElementById("schedule-shift-btn");
    getAllShifts().then(shifts => {
        shifts.forEach(shift => {
            const optionElement = document.createElement("option");
            optionElement.value = shift.shiftId;
            optionElement.textContent = shift.shiftPosition;
            shiftSelectListElement.appendChild(optionElement);
        });
    }).catch(error => {
        if (error.message.includes("404")) {
            errorTextElement.textContent += "Shifts endpoint not found ";
        } else if (error.message.includes("500")) {
            errorTextElement.textContent += "Internal server error loading shifts ";
        } else {
            errorTextElement.textContent += "Unknown error loading shifts ";
        }
    });
    notifyShiftButton.addEventListener("click", function () {
        nofifyEmployeeOfShifts(idParam).then((response) => {
            errorTextElement.textContent = "";
            successTextElement.textContent = "Successfully notified employee of shifts";
        }).catch(error => {
            successTextElement.textContent = "";
            if (error.message.includes("404")) {
                errorTextElement.textContent = "Notify shifts endpoint not found";
            } else if (error.message.includes("500")) {
                errorTextElement.textContent = "Internal server error notifying shifts";
            } else {
                errorTextElement.textContent = `Unknown error notifying shifts: ${error}`;
            }
        });
    });
    scheduleShiftButton.addEventListener("click", function () {
        const selectedShift = shiftSelectListElement.value;
        const shiftDate = shiftDateInputElement.value;
        assignEmployeeShift(idParam, selectedShift, shiftDate)
            .then(() => {
                errorTextElement.textContent = "";
                successTextElement.textContent = "Shift assigned successfully";
            }).catch(error => {
                successTextElement.textContent = "";
                if (error.message.includes("404")) {
                    errorTextElement.textContent = "Assign shift endpoint not found";
                } else if (error.message.includes("500")) {
                    errorTextElement.textContent = "Internal server error assigning shift";
                } else {
                    errorTextElement.textContent = `Unknown error assigning shift: ${error}`;
                }
            });
    });
}


function loadTrainingModulesForm(idParam) {
    const errorTextElement = document.getElementById("error-text");
    const successTextElement = document.getElementById("success-text");
    const traingModulesSelectListElement = document.getElementById("training-select-list");
    const assignTrainingButton = document.getElementById("assign-training-btn");
    getAllTrainingModules().then(trainingModules => {
        trainingModules.forEach(trainingModule => {
            const optionElement = document.createElement("option");
            optionElement.value = trainingModule.trainingId;
            optionElement.textContent = trainingModule.trainingName;
            traingModulesSelectListElement.appendChild(optionElement);
        });
    }).catch(error => {
        if (error.message.includes("404")) {
            errorTextElement.textContent += "Training modules endpoint not found ";
        } else if (error.message.includes("500")) {
            errorTextElement.textContent += "Internal server error loading training modules ";
        } else {
            errorTextElement.textContent += "Unknown error loading training modules ";
        }
    });
    assignTrainingButton.addEventListener("click", function () {
        const selectedTrainingModule = traingModulesSelectListElement.value;
        assignEmployeeTraining(idParam, selectedTrainingModule).then(() => {
            errorTextElement.textContent = "";
            successTextElement.textContent = "Training assigned successfully";
        }).catch(error => {
            successTextElement.textContent = "";
            if (error.message.includes("404")) {
                errorTextElement.textContent = "Assign training endpoint not found";
            } else if (error.message.includes("500")) {
                errorTextElement.textContent = "Internal server error assigning training";
            } else if (error.message.includes("409")) {
                errorTextElement.textContent = "Training already assigned";
            } else {
                errorTextElement.textContent = `Unknown error assigning training: ${error}`;
            }
        });
    });
}
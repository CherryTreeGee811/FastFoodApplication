import {
    getShiftsByEmployeeId, getTrainingModulesByEmployeeId,
    markTrainingAsComplete, nofifyEmployeeOfShifts
} 
from "./api.mjs";


export function loadDetailsForm(idParam) {
    const loadingTextElement = document.getElementById("loading-text");
    const employeeIdTextElement = document.getElementById("employee-id");
    loadingTextElement.textContent = "Loading employee data...";
    employeeIdTextElement.textContent = idParam;
    loadShifts(idParam);
    loadTraining(idParam);
    loadingTextElement.textContent = "";
}


function loadShifts(idParam) {
    const errorTextElement = document.getElementById("error-text");
    const successTextElement = document.getElementById("error-text");
    const shiftsTableBody = document.getElementById("shifts-table-body");
    const notifyScheduleButtonElement = document.getElementById("notify-schedule-btn");

    notifyScheduleButtonElement.addEventListener("click", function () {
        nofifyEmployeeOfShifts(idParam).then(() => {
            errorTextElement.textContent = "";
            successTextElement.textContent = "Successfully sent shifts to email";
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

    getShiftsByEmployeeId(idParam).then(shifts => {
        shiftsTableBody.innerHTML = "";
        const headerRow = document.createElement("tr");
        headerRow.innerHTML = `
            <td class="fw-bold">Date</td>
            <td class="fw-bold">Shift</td>
        `;
        shiftsTableBody.appendChild(headerRow);

        if (shifts.length === 0) {
            const noShiftsRow = document.createElement("tr");
            noShiftsRow.innerHTML = `<td colspan="2">No shifts assigned</td>`;
            shiftsTableBody.appendChild(noShiftsRow);
            return;
        }

        shifts.forEach(shift => {
            const row = document.createElement("tr");
            const shiftDate = new Date(shift.shiftDate);
            const formattedShiftDate = shiftDate.toLocaleDateString("en-CA");
            row.innerHTML = `
                <td>${formattedShiftDate}</td>
                <td>${shift.shiftPosition}</td>
            `;
            shiftsTableBody.appendChild(row);
        });
    }).catch(error => {
        if (error.message.includes("404")) {
            errorTextElement.textContent += "Shift endpoint not found ";
        } else if (error.message.includes("500")) {
            errorTextElement.textContent += "Internal server error loading shifts ";
        } else {
            errorTextElement.textContent += `Unknown error loading shifts: ${error} `;
        }
    });
}


function loadTraining(idParam) {
    const errorTextElement = document.getElementById("error-text");
    const successTextElement = document.getElementById("success-text");
    const trainingTableBody = document.getElementById("training-table-body");

    getTrainingModulesByEmployeeId(idParam).then(trainingModules => {
        trainingTableBody.innerHTML = "";
        const headerRow = document.createElement("tr");
        headerRow.innerHTML = `
            <td class="fw-bold">Course Name</td>
            <td class="fw-bold">Mark Complete</td>
        `;
        trainingTableBody.appendChild(headerRow);
        if(trainingModules.length === 0) {
            const noTrainingRow = document.createElement("tr");
            noTrainingRow.innerHTML = `<td colspan="2">No training modules available</td>`;
            trainingTableBody.appendChild(noTrainingRow);
            return;
        }
        trainingModules.forEach(trainingModule => {
            const row = document.createElement("tr");
            row.innerHTML = `
                <td>${trainingModule.trainingName}</td>
                <td>
                    <form method="post">
                        <input type="button" class="training-complete-btn btn btn-success"
                            module-id="${trainingModule.trainingId}" value="Complete" />
                    </form>
                </td>
            `;
            trainingTableBody.appendChild(row);
        });
        trainingTableBody.querySelectorAll('.training-complete-btn[module-id]').forEach(completeBtn => {
            completeBtn.addEventListener('click', (e) => {
                e.preventDefault();
                const moduleId = completeBtn.getAttribute('module-id');
                markTrainingAsComplete(idParam, moduleId).then(() => {
                    errorTextElement.textContent = "";
                    successTextElement.textContent = "Successfully marked training module as complete";
                    // Reload training modules to reflect changes
                    loadTraining(idParam);
                }).catch(error => {
                    successTextElement.textContent = "";
                    if (error.message.includes("404")) {
                        errorTextElement.textContent += "Complete training endpoint not found ";
                    } else if (error.message.includes("500")) {
                        errorTextElement.textContent += "Internal server error marking training module as complete ";
                    } else {
                        errorTextElement.textContent += `Unknown error marking training module as complete: ${error} `;
                    }
                });
            });
        });
    }).catch(error => {
        if (error.message.includes("404")) {
            errorTextElement.textContent += "Training modules endpoint not found ";
        } else if (error.message.includes("500")) {
            errorTextElement.textContent += "Internal server error loading training modules ";
        } else {
            errorTextElement.textContent += `Unknown error loading training modules: ${error} `;
        }
    });
}
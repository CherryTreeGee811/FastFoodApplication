import { routeHandler } from "../router.mjs";
import { getAllEmployees, fireEmployee, nofifyAllEmployeesOfShifts } from "./api.mjs";


export function loadEmployeeList(navContentDiv, contentDiv) {
    const tableBody = document.getElementById('employee-list-table-body');
    const hireButtonElement = document.getElementById('hire-btn');
    const notifyAllEmployeesOfShiftsButtonElement = document.getElementById('notify-all-employees-of-shifts-btn');
    const errorTextElement = document.getElementById("error-text");
    const successTextElement = document.getElementById("success-text");
    const loadingTextElement = document.getElementById("loading-text");

    loadingTextElement.textContent = "Loading employees...";

    hireButtonElement.addEventListener("click", (e) => {
        e.preventDefault();
        window.history.pushState({}, '', '/employees/hire');
        routeHandler(navContentDiv, contentDiv);
    });

    notifyAllEmployeesOfShiftsButtonElement.addEventListener("click", (e) => {
        e.preventDefault();
        nofifyAllEmployeesOfShifts().then(() => {
            errorTextElement.textContent = "";
            successTextElement.textContent = "All employees have been notified of their shifts.";
        }).catch(error => {
            successTextElement.textContent = "";
            if (error.message.includes("404")) {
                errorTextElement.textContent = "Notify all of shifts endpoint not found";
            } else if (error.message.includes("500")) {
                errorTextElement.textContent = "Internal server error while notifying all staff of shifts";
            } else {
                errorTextElement.textContent = `Unknown error notifying all staff of shifts: ${error}`;
            }
        });
    });

    // Clear any existing rows in the table body
    tableBody.innerHTML = '';

    getAllEmployees().then(employees => {
        employees.forEach(employee => {
            const row = document.createElement('tr');
            row.innerHTML = `
                <td>${employee.firstName ?? ''}</td>
                <td>${employee.lastName ?? ''}</td>
                <td>${employee.jobTitle ?? ''}</td>
                <td>${employee.stationName ?? ''}</td>
                <td>
                    <a href="/employees/manage?id=${employee.employeeId}" 
                        class="manage-btn btn btn-primary btn-sm" employee-id="${employee.employeeId}">Manage</a>
                    <button class="fire-btn btn btn-danger btn-sm" employee-id="${employee.employeeId}">Fire</button>
                </td>
            `;
            tableBody.appendChild(row);
        });

        tableBody.querySelectorAll('.fire-btn[employee-id]').forEach(fireBtn => {
            fireBtn.addEventListener('click', (e) => {
                e.preventDefault();
                const employeeId = fireBtn.getAttribute('employee-id');
                fireEmployee(employeeId).then(() => {
                    // Reload the list after firing an employee
                    loadEmployeeList();
                }).catch(() => {
                    errorTextElement.textContent = "Failed to fire employee. Please try again.";
                });
            });
        });

        tableBody.querySelectorAll('.manage-btn[employee-id]').forEach(manageBtn => {
            manageBtn.addEventListener('click', (e) => {
                e.preventDefault();
                const employeeId = manageBtn.getAttribute('employee-id');
                window.history.pushState({}, '', `/employees/manage?id=${employeeId}`);
                routeHandler(navContentDiv, contentDiv);
            });
        });
    }).catch (error => {
        if (error.message.includes("404")) {
            errorTextElement.textContent = "Endpoint not found";
        } else if (error.message.includes("500")) {
            errorTextElement.textContent = "Internal server error";
        } else {
            errorTextElement.textContent = "Unknown error";
        }
    });
    loadingTextElement.textContent = "";
}
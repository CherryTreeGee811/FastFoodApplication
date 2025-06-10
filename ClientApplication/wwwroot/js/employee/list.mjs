import { getAllEmployees, fireEmployee } from "./api.mjs";


export function loadEmployeeList() {
    const tableBody = document.getElementById('employee-list-table-body');
    const errorTextElement = document.getElementById("error-text");

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
                    <a href="/employees/manage?id=${employee.employeeId}" class="btn btn-primary btn-sm">Manage</a>
                    <button class="btn btn-danger btn-sm" employee-id="${employee.employeeId}">Fire</button>
                </td>
            `;
            tableBody.appendChild(row);
        });

        // Optionally, add event listeners for Fire buttons here
        tableBody.querySelectorAll('button[employee-id]').forEach(fireBtn => {
            fireBtn.addEventListener('click', (e) => {
                e.preventDefault();
                const employeeId = fireBtn.getAttribute('employee-id');
                fireEmployee(employeeId).then(() => {
                    // Reload the list after firing an employee
                    loadEmployeeList();
                }).catch(error => {
                    console.error('Error firing employee:', error);
                    errorTextElement.textContent = "Failed to fire employee. Please try again.";
                });
            });
        });
    }).catch (error => {
        if (error.message.includes("404")) {
            errorTextElement.textContent = "Endpoint not found";
        } else if (error.message.includes("400")) {
            errorTextElement.textContent = "Invalid date was passed";
        } else if (error.message.includes("500")) {
            errorTextElement.textContent = "Internal server error";
        } else {
            errorTextElement.textContent = "Unknown error";
        }
        loadingTextElement.textContent = "";
    });
}
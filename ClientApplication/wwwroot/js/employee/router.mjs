import { loadTemplate } from '../router.mjs';
import { loadEmployeeList } from './list.mjs';
import { loadHireForm } from './hire.mjs';
import { loadManageForm } from './manage.mjs';



export function handleEmployeeRoutes(path, navContentDiv, contentDiv) {
    const urlParams = new URLSearchParams(window.location.search);
    const idParam = urlParams.get('id');
    switch (path) {
        case '/employees/details':
            loadTemplate("employee/details.html", contentDiv).then(() => {
                return loadFormJS();
            }).catch((error) => {
                console.error('Error loading form js:', error);
            });
            break;
        case '/employees/hire':
            loadTemplate("employee/hire.html", contentDiv).then(() => {
                return loadHireForm(navContentDiv, contentDiv);
            }).catch((error) => {
                console.error('Error loading radiation measurements for day:', error);
            });
            break;
        case '/employees/list':
            loadTemplate("employee/list.html", contentDiv).then(() => {
                return loadEmployeeList();
            }).catch((error) => {
                console.error('Error loading radiation measurements for year:', error);
            });
            break;
        case '/employees/manage':
            loadTemplate("employee/manage.html", contentDiv).then(() => {
                return loadManageForm(idParam, navContentDiv, contentDiv);
            }).catch((error) => {
                console.error('Error loading radiation measurements for year:', error);
            });
            break;
        default:
            contentDiv.innerHTML = `<h1>404 Not Found</h1>`;
    }
}
import { getAccessTokenFromCookie, getNameFromToken, getRoleFromToken } from '../token-parser.mjs';


export function swapUserNameInNavBar() {
    const token = getAccessTokenFromCookie();
    if (token) {
        const userName = getNameFromToken(token);
        const userRole = getRoleFromToken(token);
        if (userRole === "Manager") {
            document.getElementById("manager-dropdown").textContent = userName;
        }
        else {
            document.getElementById("employee-dropdown").textContent = userName;
        }
    }
}
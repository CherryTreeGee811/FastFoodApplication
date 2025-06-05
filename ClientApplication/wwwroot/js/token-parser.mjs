export function getAccessTokenFromCookie() {
    const name = 'token=';
    const decodedCookies = decodeURIComponent(document.cookie);
    const cookiesArray = decodedCookies.split('; ');

    // Iterate through the cookies to find the one with the key 'token'
    for (let i = 0; i < cookiesArray.length; i++) {
        if (cookiesArray[i].startsWith(name)) {
            return cookiesArray[i].substring(name.length);
        }
    }

    return null;
}


function base64UrlDecode(str) {
    // Replace non-url compatible chars with base64 standard chars
    str = str.replace(/-/g, '+').replace(/_/g, '/');
    // Pad with trailing '='
    while (str.length % 4) {
        str += '=';
    }
    return atob(str);
}


export function getRoleFromToken(token) {
    if (!token) return null;
    const parts = token.split('.');
    if (parts.length !== 3) return null;
    try {
        const payload = JSON.parse(base64UrlDecode(parts[1]));
        // The role claim may be 'role' or 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
        return payload.role || payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || null;
    } catch (e) {
        return null;
    }
}
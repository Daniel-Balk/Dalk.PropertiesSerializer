function isElectronX() {
    if (typeof window !== 'undefined' && typeof window.process === 'object' && window.process.type === 'renderer') {
        return true;
    }

    if (typeof process !== 'undefined' && typeof process.versions === 'object' && !!process.versions.electron) {
        return true;
    }

    if (typeof navigator === 'object' && typeof navigator.userAgent === 'string' && navigator.userAgent.indexOf('Electron') >= 0) {
        return true;
    }

    return false;
}

function isElectron() {
    var b = isElectronX();
    if (b) {
        return "true";
    }
    else {
        return "false";
    }
}

function copyCode(code) {
    if (!isElectronX()) {
        navigator.clipboard.writeText(code);
    }
    else {
        const { clipboard } = require('electron');
        clipboard.writeText(code);
    }
}
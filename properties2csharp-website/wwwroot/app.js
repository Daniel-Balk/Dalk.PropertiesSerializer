console.log("loaded app.js")

function isElectronX() {
    // Renderer process
    if (typeof window !== 'undefined' && typeof window.process === 'object' && window.process.type === 'renderer') {
        return true;
    }

    // Main process
    if (typeof process !== 'undefined' && typeof process.versions === 'object' && !!process.versions.electron) {
        return true;
    }

    // Detect the user agent when the `nodeIntegration` option is set to true
    if (typeof navigator === 'object' && typeof navigator.userAgent === 'string' && navigator.userAgent.indexOf('Electron') >= 0) {
        return true;
    }

    return false;
}

function isElectron() {
    var b = isElectronX();
    console.warn(b);
    if (b) {
        return "true";
    }
    else {
        return "false";
    }
}

window.checkDownload = () => {
    if (isElectron()) {
        document.getElementById("blz").style.visibility = "hidden";
    }
}
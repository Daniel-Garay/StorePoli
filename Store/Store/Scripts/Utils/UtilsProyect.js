function stringToHTML (registro) {
    var dom = document.createElement('tr');
    dom.innerHTML = registro;
    return dom;
};

function MostrarMensajeExitoso() {
    window.scrollTo(pageXOffset, 0);
    document.getElementById("alertUsuario").style.display = "flex";
    setTimeout(() => {
        document.getElementById("alertUsuario").style.display = "none";
    }, 2000);
}


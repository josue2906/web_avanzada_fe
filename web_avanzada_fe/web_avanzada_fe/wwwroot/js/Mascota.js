function validarNumeros(event) {
    var key = window.event ? event.keyCode : event.which;
    if (key < 48 || key > 57) {
        return false;
    } else {
        return true;
    }
};

function VerificarEspaciosRaza() {
    $("#Raza").val($("#Raza").val().trim());
}

function VerificarEspaciosNombre() {
    $("#NombreM").val($("#NombreM").val().trim());

}
function VerificarPeso() {
    if ($("#Peso").val() <= 0) {
        document.getElementById('validacionPeso').innerHTML = 'Digite un peso valido';
        return
    };
    document.getElementById('validacionPeso').innerHTML = '';
}

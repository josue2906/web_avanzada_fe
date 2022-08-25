function validarNumeros(event) {
    var key = window.event ? event.keyCode : event.which;
    if (key < 48 || key > 57) {
        return false;
    } else {
        return true;
    }
};

function VerificarEspacios() {
    $("#idDueno").val($("#idDueno").val().trim());
}

function VerificarEspaciosNombre() {
    $("#NombreD").val($("#NombreD").val().trim());

}
function VerificarEspaciosApellido() {
    $("#ApellidosD").val($("#ApellidosD").val().trim());

}

function ValidateEmail(correo_ingresado) {
    console.log(correo_ingresado)
    var validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    if (correo_ingresado.match(validRegex)) {
        document.getElementById('correo_label').innerHTML = '';
    } else
        document.getElementById('correo_label').innerHTML = 'Digite un correo valido';
}

function ValidateEmail_onBlur(correo_ingresado) {
    console.log(correo_ingresado)
    var validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    if (correo_ingresado.match(validRegex)) {
        document.getElementById('correo_label').innerHTML = '';
    } else {
        document.getElementById('Correo').value = '';
        document.getElementById('correo_label').innerHTML = 'Digite un correo valido';
    }
}

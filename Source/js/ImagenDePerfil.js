var imagen = document.getElementById("ImagenPefil");
var usuario = document.getElementById("usuario").innerText;
var nombrehtml = location.pathname.split("/").slice(-2);
var idllamada = location.pathname.split("/").slice(-1);

if (usuario.includes("Paolo")) {
    imagen.src = "/Source/images/Fotos/Paolo.jpg";

} else if (usuario.includes("Bayron")) {
    imagen.src = "/Source/images/Fotos/Bayron.jpg";

} else if (usuario.includes("Daniel")) {
    imagen.src = "/Source/images/Fotos/danielo.jpg";

} else if (usuario.includes("Alvaro")) {
    imagen.src = "/Source/images/Fotos/alvaro.jpg";

} else if (usuario.includes("CAMILA")) {
    imagen.src = "/Source/images/Fotos/camila.jpg";

} else if (usuario.includes("Piero")) {
    imagen.src = "/Source/images/Fotos/piero.jpg";

} else {
    imagen.src = "/Source/User/images/users/user-icon.jpg";
}

//GENERANDO EL NOMBRE DE LA LLAMADA

if (nombrehtml.includes("Videollamada")) {

    var identificadorUnico = eliminarTildes(usuario);
    var nombrellamada = document.getElementById("username-input");
    nombrellamada.value = "GGYM" + identificadorUnico + idllamada + "GGYM";
}

function eliminarTildes(cadena) {
    cadena = cadena.replace(" ", "").toLowerCase();
    const acentos = { 'á': 'a', 'é': 'e', 'í': 'i', 'ó': 'o', 'ú': 'u', 'Á': 'A', 'É': 'E', 'Í': 'I', 'Ó': 'O', 'Ú': 'U' };
    return cadena.split('').map(letra => acentos[letra] || letra).join('').toString();
}
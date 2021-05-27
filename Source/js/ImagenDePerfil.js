var imagen = document.getElementById("ImagenPefil");
var usuario = document.getElementById("usuario").innerText;
var nombrehtml = location.pathname.split("/").slice(-2);
var idllamada = location.pathname.split("/").slice(-1);

if (usuario.includes("PAOLO")) {
    imagen.src = "/Source/images/Fotos/Paolo.jpg";

} else if (usuario.includes("BAYRON")) {
    imagen.src = "/Source/images/Fotos/Bayron.jpg";

} else if (usuario.includes("DANIEL")) {
    imagen.src = "/Source/images/Fotos/danielo.jpg";

} else if (usuario.includes("ALVARO")) {
    imagen.src = "/Source/images/Fotos/alvaro.jpg";

} else if (usuario.includes("CAMILA")) {
    imagen.src = "/Source/images/Fotos/camila.jpg";

} else if (usuario.includes("PIERO")) {
    imagen.src = "/Source/images/Fotos/piero.jpg";

} else {
    imagen.src = "/Source/User/images/users/user-icon.jpg";
}

//GENERANDO EL NOMBRE DE LA LLAMADA

if (nombrehtml.includes("Videollamada")) {

    //definimos string
    idllamada = idllamada.toString();

    //eliminamos las tildes si es que hubiera
    var identificadorUnico = eliminarTildes(idllamada).toString();

    //tamaño del string para cortar
    var tamaño = contarletras(identificadorUnico)

    //iniciamos variables que usaremos para almacenar el id de la llamada y nombre
    var idunico = identificadorUnico.substring(0, 1);
    var nombrellamda = identificadorUnico.substring(1, parseInt(tamaño));    

    var nombrellamada = document.getElementById("username-input");
    nombrellamada.value = "GGYM" + nombrellamda + idunico + "GGYM";
}

function eliminarTildes(cadena) {
    cadena = cadena.replace(" ", "").toLowerCase();
    const acentos = { 'á': 'a', 'é': 'e', 'í': 'i', 'ó': 'o', 'ú': 'u', 'Á': 'A', 'É': 'E', 'Í': 'I', 'Ó': 'O', 'Ú': 'U' };
    return cadena.split('').map(letra => acentos[letra] || letra).join('').toString();
}

function contarletras(str) {
    return str.replace(/\s/g, '').length;
}
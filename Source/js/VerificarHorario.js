var usuario = document.getElementById("usuario").innerText;
var horainicio;
var horafin;

var horaentera;
var horainicioentera;
var horafinentera;

function validarhora(inicio, fin, id) {

    var fecha = new Date();
    var hora = fecha.getHours() + ':' + fecha.getMinutes();
    horaentera = parseInt(fecha.getHours() + "" + fecha.getMinutes());

    horainicioentera = parseInt(inicio);
    horainicio = String(inicio);
    horainicio = horainicio.substring(0, 2) + ":" + horainicio.substring(2, 4);

    horafinentera = parseInt(fin);
    horafin = String(fin);
    horafin = horafin.substring(0, 2) + ":" + horafin.substring(2, 4);


    if (horainicioentera > horaentera || horafinentera < horaentera ) {
        alert("Aun no empieza");
        location.href = "/Usuario/Videollamada/" + id + usuario.replace(" ", "");
    }

    if (horainicioentera < horaentera && horafinentera > horaentera) {       
        alert("empezo");
        //MOSTRAR MODAL DE CONFIRMACION
        
    }

}
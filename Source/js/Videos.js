//Creacion de arreglo para almacenar informacion de los videos ejercicios

//Titulo de los ejercicios
let titulovideo = ["Video Recomendado "];

//Creando el estilo
var videoparte1 = '<div class="col-sm-6 col-lg-3 col-md-4">'
    + '<div class="gal-detail thumb" style="box-shadow: 2px 2px 5px #999;">';
var videop = '<p class="text-muted" style="text-align: center">';

var galeria2 = document.getElementById("galeria2");


//Agregando div con los estilos dentro
for (var i = 1; i < titulovideo.length + 1; i++) {

    var video = '<video class="thumb-img" alt="work-thumbnail" controls>'
        + '<source src="/Source/images/VideoEjercicios/Video' + i
        + '.mp4" type="video/mp4"></source></video> ';

    galeria2.innerHTML += videoparte1 + video + videop + titulovideo[i - 1] + i + '</div>' + '</div>';
}
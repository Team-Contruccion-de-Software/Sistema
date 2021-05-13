var nombrehtml = location.pathname.split("/").slice(-1);
//console.log(nombrehtml);

var titulo = document.getElementById('Titulo');
var indice1 = document.getElementById('Indice1');
var indice2 = document.getElementById('Indice2');
var indice3 = document.getElementById('Indice3');
var indice4 = document.getElementById('Indice4');
var indice5 = document.getElementById('Indice5');
var indice6 = document.getElementById('Indice6');

//Estilo para el default del usuario
if (nombrehtml == "" || nombrehtml.includes("Usuario")) {
    indice1.className = 'waves-effect active';
    titulo.innerHTML = 'Pagina Principal';
    for (var i = 1; i < 8; i++) {
        if (i != 1) {
            ("indice" + i).className = 'waves-effect';
        }
    }
}

//Estilo para el Indice del usuario
if (nombrehtml.includes("Index")) {
    indice1.className = 'waves-effect active';
    titulo.innerHTML = 'Pagina Principal';
    for (var i = 1; i < 8; i++) {
        if (i != 1) {
            ("indice" + i).className = 'waves-effect';
        }        
    }
}

//Estilo para el Calendario del usuario
if (nombrehtml.includes("Calendario")) {
    indice2.className = 'waves-effect active';
    titulo.innerHTML = 'Calendario';
    for (var i = 1; i < 8; i++) {
        if (i != 2) {
            ("indice" + i).className = 'waves-effect';
        }
    }
}

//Estilo para el CoachHorario del usuario
if (nombrehtml.includes("CoachHorario")) {
    indice3.className = 'waves-effect active';
    titulo.innerHTML = 'Horarios';
    for (var i = 1; i < 8; i++) {
        if (i != 3) {
            ("indice" + i).className = 'waves-effect';
        }
    }
}

//Estilo para el Horario del usuario
if (nombrehtml.includes("Horario")) {
    indice4.className = 'waves-effect active';
    titulo.innerHTML = 'Horarios';
    for (var i = 1; i < 8; i++) {
        if (i != 4) {
            ("indice" + i).className = 'waves-effect';
        }
    }
}

//Estilo para el Recomendaciones del usuario
if (nombrehtml.includes("Recomendaciones")) {
    indice5.className = 'waves-effect active';
    titulo.innerHTML = 'Recomendaciones';
    for (var i = 1; i < 8; i++) {
        if (i != 5) {
            ("indice" + i).className = 'waves-effect';
        }
    }
}

//Estilo para el Seguimiento del usuario
if (nombrehtml.includes("Seguimiento")) {
    indice6.className = 'waves-effect active';
    titulo.innerHTML = 'Seguimiento';
    for (var i = 1; i < 8; i++) {
        if (i != 6) {
            ("indice" + i).className = 'waves-effect';
        }
    }
}
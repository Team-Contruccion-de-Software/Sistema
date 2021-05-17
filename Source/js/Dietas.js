//Creacion de arreglos para almacenar informacion de los ejercicios

//Titulo de los ejercicios
let titulodescripcion = ["Plie Squat Scoop Up"
    , "Side Lunge Front Raise"
    , "Remo vertical de peso muerto"
    , "Curvas laterales de sumo"
    , "Lunge Punch"
    , "Press de sentadillas dividido"
    , "Curl en cuclillas"
    , "Plank Bird Dog"
    , "Levantamiento de patada lateral con estocada de reverencia"
];

//Descripcion de los ejercicios
let descripcion = ["Plie squat scoop up ejercicio guía con instrucciones, demostración, calorías quemadas y músculos trabajados. Aprenda la forma adecuada, descubra todos los beneficios para la salud y elija un entrenamiento."
    , "Guía de ejercicios de elevación frontal de estocada lateral con instrucciones, demostración, calorías quemadas y músculos trabajados. Aprenda la forma adecuada, descubra todos los beneficios para la salud y elija un entrenamiento."
    , "Guía de ejercicios de remo vertical de peso muerto con instrucciones, demostración, calorías quemadas y músculos trabajados. Aprenda la forma adecuada, descubra todos los beneficios para la salud y elija un entrenamiento."
    , "Guía de ejercicios de curvas laterales de sumo con instrucciones, demostración, calorías quemadas y músculos trabajados. Aprenda la forma adecuada, descubra todos los beneficios para la salud y elija un entrenamiento."
    , "Guía de ejercicios de Lunge punch con instrucciones, demostración, calorías quemadas y músculos trabajados. Aprenda la forma adecuada, descubra todos los beneficios para la salud"
    , "Guía de ejercicios de press de cuclillas dividido con instrucciones, demostración, calorías quemadas y músculos trabajados. Aprenda la forma adecuada, descubra todos los beneficios para la salud y elija un entrenamiento."
    , "Guía de ejercicios de sentadillas curl con instrucciones, demostración, calorías quemadas y músculos trabajados. Aprenda la forma adecuada, descubra todos los beneficios para la salud y elija un entrenamiento."
    , "Guía de ejercicios de perro pájaro de tabla con instrucciones, demostración, calorías quemadas y músculos trabajados. Aprenda la forma adecuada, descubra todos los beneficios para la salud y elija un entrenamiento."
    , "Guía de ejercicios de levantamiento de patada lateral y estocada de reverencia con instrucciones, demostración, calorías quemadas y músculos trabajados. Aprenda la forma adecuada, descubra todos los beneficios para la salud y elija un entrenamiento."
];

//Creando el estilo
var parte1 = '<div class="col-sm-6 col-lg-3 col-md-4">'
    + '<div class="gal-detail thumb" style="box-shadow: 2px 2px 5px #999;">';
var p = '<p class="text-muted" style="text-align: justify">';

var galeria1 = document.getElementById("galeria1");


//Agregando div con los estilos dentro
for (var i = 1; i < descripcion.length + 1; i++) {

    var imagen = '<a href="/Source/images/Ejercicios/ejercicio' + i + '.gif" class="image-popup" title="Screenshot-' + i + '">';
    var imagen2 = '<img class="img-responsive img-circle" src="/Source/images/Ejercicios/ejercicio' + i + '.gif" class="thumb-img" alt="work-thumbnail"></a>';
    var titulo = '<h4 id="Titulo' + i + '">' + titulodescripcion[i - 1] + '</h4>';

    galeria1.innerHTML += parte1 + imagen + imagen2 + titulo + p + descripcion[i - 1] + '</p>' + '</div>' + '</div>';
}
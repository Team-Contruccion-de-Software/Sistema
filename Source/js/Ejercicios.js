//Creacion de arreglos para almacenar informacion de los ejercicios

//Titulo de los ejercicios
let titulodescripcion = ["Sentadilla Plié "
    , "Elevacion frontal con estocada lateral"
    , "Remo vertical de peso muerto"
    , "Curvas laterales de sumo"
    , "Puñetazo de estocada"
    , "Press de sentadillas dividido"
    , "Curl en cuclillas"
    , "El Bird Dog"
    , "Levantamiento de patada lateral con estocada de reverencia"
];

//Descripcion de los ejercicios
let descripcion = ["La sentadilla plié es un movimiento compuesto que se dirige a tus glúteos, muslos, piernas, caderas, pecho y brazos. Este es un ejercicio de cuerpo completo que estimula el metabolismo, fortalece todo el cuerpo y mejora su nivel de condición física."
    , "Da un paso hacia un lado con la pierna derecha, haz una estocada y levanta las mancuernas hasta que tus brazos queden ligeramente por encima de los paralelos al suelo."
    , "El remo vertical es un ejercicio de peso libre, que generalmente se realiza con mancuernas o con barra. Es un ejercicio simple, pero requiere una técnica perfecta para conseguir los mejores resultados y evitar lesiones."
    , "En esta variante de la sentadilla se modifica la distancia de separación entre las piernas y el ángulo de apertura de los pies; así se consigue una mayor participación de los aductores y el glúteo mayor en la extensión de la cadera en su ejecución."
    , "Manteniendo la espalda erguida, da un paso hacia adelante (alrededor de 1,5 veces un paso hacia adelante normal). Baje su cuerpo hacia la estocada hasta que la pierna delantera alcance un ángulo de 90 grados. Empuje hacia arriba a través de la pierna delantera y lleve su cuerpo de regreso a la posición inicial."
    , "En este ejercicio se entrena los Cuádriceps, Glúteos, Hombros, Brazos, Músculos abdominales, Todo el cuerpo."
    , "Empiece a pararse con los pies separados a la altura de los hombros y las pesas a cada lado de usted. Realice un rizo, luego gire los hombros y presione para encontrar los pesos sobre su cabeza."
    , "El bird-dog es un ejercicio de cuerpo completo que aprieta su núcleo y fortalece sus glúteos, isquiotibiales, cuádriceps, caderas, hombros y brazos. Este ejercicio ayuda a prevenir el dolor lumbar y mejora su postura y equilibrio."
    , "Involucre su núcleo, mire hacia adelante, abra el pecho y mantenga la espalda recta. Mientras se lanza, mantenga la rodilla delantera sobre el tobillo y mantenga los dedos de los pies apuntando en la misma dirección que las rodillas. Exhale mientras se pone de pie y, mientras patea hacia un lado y levanta la mancuerna, mantenga la espalda alineada."
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
//Creacion de arreglos para almacenar informacion de las dietas

//Titulo de las Dietas
let titulodescripcion = ["Dieta Mediterranea"
    , "Dieta Dash"
    , "Dieta Flexitariana"
    , "Dieta Keto"
    , "Dieta Hipocalórica"
    , "Dieta por Puntos"
    , "Dieta Paleo"
    , "Dieta Proteica"
    , "Dieta Alcalina"
    , "Dieta Liquida"
];

//Descripcion de las Dietas
let descripcion = ["La pirámide de la dieta mediterránea enfatiza en el consumo de frutas, verduras, granos integrales, frijoles, nueces, legumbres, aceite de oliva y hierbas y especias; pescado y marisco al menos un par de veces a la semana; y aves de corral, huevos, queso y yogur con moderación. Limita el consumo de dulces y carnes rojas para ocasiones especiales y se combina con actividad física diaria."
    , "La dieta DASH incluye menús con muchos vegetales, frutas y productos lácteos con bajo contenido de grasa, así como cereales integrales, pescado, carne de ave y frutos secos. Ofrece porciones limitadas de carnes rojas, dulces y bebidas azucaradas."
    , "Su énfasis en el consumo de granos enteros, frutas, verduras y proteínas de origen vegetal. Básicamente se puede definir como una dieta vegetariana que permite ocasionalmente consumir carne o pescado, de aquí que su nombre provenga de la palabra flexible."
    , "En este tipo de dieta, se realizan cinco comidas al día y no se evita ningún grupo de alimentos, excepto aquellos como el azúcar y las grasas saturadas. Estos parámetros son aptos en una dieta para diabéticos, puesto que, además de repartir las comidas a lo largo del día,  limitan la cantidad de grasa, azúcares y sal que ingerimos, y permite consumir una gran variedad de frutas y verduras."
    , "La dieta hipocalórica se caracteriza por ser una dieta o régimen dietético bajo en calorías. Es decir, consiste en aplicar una restricción calórica diaria o reducir la ingesta de alimento que aportan calorías."
    , "Cuenta con una tabla de puntos que los clasifica según sus características. El objetivo de este plan de alimentación es no sobrepasar los puntos indicados al cabo del día. En esta dieta no hay alimentos prohibidos, pero siempre hay que evitar aquellos como bollería o embutidos grasos, porque su alta puntuación puede hacer que alcancemos la totalidad de los puntos, o los sobrepasemos, con sólo probarlos."
    , "Se basa en que estamos genéticamente adaptados para comer lo que comían nuestros antepasados del Paleolítico: carne, verduras, pescado, frutas…, y es mejor evitar lácteos, legumbres y cereales. La dieta de nuestros antepasados estaba basada en la carne, fruta, verdura, pescado y marisco."
    , "En la dieta proteica, se limita la alimentación a aquellos alimentos que son altos en proteínas, como la carne, el pescado y los derivados lácteos. Este tipo de dieta, que llega a excluir grupos de alimentos tan fundamentales como las frutas y las verduras, puede llegar a ocasionar graves problemas de salud. Algunas de las carencias más graves de esta dieta son la falta de hidratos de carbono y de fibra, imprescindibles para el buen funcionamiento de nuestro cuerpo."
    , "Conocida como la dieta del pH y promocionada como la dieta “anticáncer”, basándose en el consumo de alimentos que tienen supuestos efectos sobre la acidez de los fluidos de nuestro organismo. El punto a favor de esta dieta es que aboga por alimentos como cereales, frutas, verduras y legumbres, pero con una restricción tan amplia en el resto de alimentos que no es una opción saludable."
    , "Consiste en tomar solamente alimentos líquidos y bebidas. En esta dieta son aptos el agua, los caldos, sopas y los puré claros, tés y jugos y zumos de fruta, gelatina, budín, helado… Todo ellos son de fácil digestión y no dejan residuos, ya que carecen de fibra."
];

//Creando el estilo
var parte1 = '<div class="col-sm-6 col-lg-3 col-md-4">'
    + '<div class="gal-detail thumb" style="box-shadow: 2px 2px 5px #999; height: 450px;">';
var p = '<p class="text-muted" style="text-align: justify">';

var galeria1 = document.getElementById("galeria1");


//Agregando div con los estilos dentro
for (var i = 1; i < descripcion.length + 1; i++) {

    var imagen = '<a href="/Source/images/dietas/dieta' + i + '.jpg" class="image-popup" title="Screenshot-' + i + '">';
    var imagen2 = '<img class="img-responsive" src="/Source/images/dietas/dieta' + i + '.jpg" class="thumb-img" alt="work-thumbnail"></a>';
    var titulo = '<h4 id="Titulo' + i + '">' + titulodescripcion[i - 1] + '</h4>';

    galeria1.innerHTML += parte1 + imagen + imagen2 + titulo + p + descripcion[i - 1] + '</p>' + '</div>' + '</div>';
}
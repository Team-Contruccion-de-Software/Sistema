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
];

//Descripcion de las Dietas
let descripcion = [" Se basa en los ingredientes propios de la agricultura local de los países con clima mediterráneo, fundamentalmente España e Italia. Se resume en reducir el consumo de carnes e hidratos de carbono en beneficio de más alimentos vegetales y grasas monoinsaturadas."
    , "La dieta DASH incluye menús con muchos vegetales, frutas y productos lácteos con bajo contenido de grasa, así como cereales integrales, pescado, carne de ave y frutos secos. Ofrece porciones limitadas de carnes rojas, dulces y bebidas azucaradas."
    , "Suelen contener mucho vegetal, frutas, verdura, cereales, legumbres, frutos secos y semillas, e incluyen cantidades moderadas de carne y variables de pescado y lácteos. La dieta flexitariana, más que restringir, estimula la variedad puesto que no excluye ningún alimento específico."
    , "En este tipo de dieta, se realizan cinco comidas al día y no se evita ningún grupo de alimentos, excepto aquellos como el azúcar y las grasas saturadas. Estos parámetros son aptos en una dieta para diabéticos, puesto que, además de repartir las comidas a lo largo del día,  limitan la cantidad de grasa, azúcares y sal que ingerimos, y permite consumir una gran variedad de frutas y verduras."
    , "Cuenta con una tabla de puntos que los clasifica según sus características. El objetivo de este plan de alimentación es no sobrepasar los puntos indicados al cabo del día. En esta dieta no hay alimentos prohibidos, pero siempre hay que evitar aquellos como bollería o embutidos grasos, porque su alta puntuación puede hacer que alcancemos la totalidad de los puntos, o los sobrepasemos, con sólo probarlos."
    , "Este tipo de dieta elimina los alimentos procesados y evita algunos grupos como cereales o lácteos, y basa la alimentación en carnes, pescados, frutas y verduras, que proporcionan un alto grado de energía. Aunque puede ser una buena opción, hay que encontrar el equilibrio en el consumo de estos productos, ya que un consumo excesivo de carne también puede ser perjudicial."
    , "En la dieta proteica, se limita la alimentación a aquellos alimentos que son altos en proteínas, como la carne, el pescado y los derivados lácteos. Este tipo de dieta, que llega a excluir grupos de alimentos tan fundamentales como las frutas y las verduras, puede llegar a ocasionar graves problemas de salud. Algunas de las carencias más graves de esta dieta son la falta de hidratos de carbono y de fibra, imprescindibles para el buen funcionamiento de nuestro cuerpo."
    , "Este tipo de dieta surge en los últimos años como una forma de depurar nuestro organismo, y se basa en el consumo exclusivo de líquidos durante, al menos, un día completo a la semana. Un consumo exclusivo de líquido no sólo no aporta la cantidad de energía necesaria para el funcionamiento del organismo, sino que puede provocar desequilibrios en componentes tan necesarios como el calcio, el potasio o el sodio."
    , "Conocida como la dieta del pH y promocionada como la dieta “anticáncer”, basándose en el consumo de alimentos que tienen supuestos efectos sobre la acidez de los fluidos de nuestro organismo. El punto a favor de esta dieta es que aboga por alimentos como cereales, frutas, verduras y legumbres, pero con una restricción tan amplia en el resto de alimentos que no es una opción saludable."
];

//Creando el estilo
var parte1 = '<div class="col-sm-6 col-lg-3 col-md-4">'
    + '<div class="gal-detail thumb" style="box-shadow: 2px 2px 5px #999;">';
var p = '<p class="text-muted" style="text-align: justify">';

var galeria1 = document.getElementById("galeria1");


//Agregando div con los estilos dentro
for (var i = 1; i < descripcion.length + 1; i++) {

    var imagen = '<a href="/Source/images/dietas/dieta' + i + '.jpg" class="image-popup" title="Screenshot-' + i + '">';
    var imagen2 = '<img class="img-responsive img-circle" src="/Source/images/dietas/dieta' + i + '.jpg" class="thumb-img" alt="work-thumbnail"></a>';
    var titulo = '<h4 id="Titulo' + i + '">' + titulodescripcion[i - 1] + '</h4>';

    galeria1.innerHTML += parte1 + imagen + imagen2 + titulo + p + descripcion[i - 1] + '</p>' + '</div>' + '</div>';
}
window.onload = function () {
    cargarCategorias();
    document.getElementById("selectCategorias").addEventListener("change", cargarPlantas, false);

}

function cargarPlantas() {
    var miLlamada = new XMLHttpRequest();
    var arrayPlantas;
    var select = document.getElementById("selectCategorias");
    miLlamada.open("GET", "http://localhost:52648/api/plantas/plantas/" + select.options[select.selectedIndex].value);
    miLlamada.onreadystatechange = function () {       
        if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            arrayPlantas = JSON.parse(miLlamada.responseText);
            anhiadirPlantas(arrayPlantas);
           
        }
    }
    miLlamada.send();

}


function anhiadirPlantas(arrayPlantas) {
    let column, element;
    document.getElementById("table").innerHTML = null;
    for (var i = 0; i < arrayPlantas.length; i++) {
        element = document.createElement('td');
        column = document.createElement('tr');
        element.innerText = arrayPlantas[i].nombrePlanta;
        column.appendChild(element);
        document.getElementById("table").appendChild(column);
    }
}

function cargarCategorias() {
    var miLlamada = new XMLHttpRequest();
    var arrayCategorias;
    miLlamada.open("GET", "http://localhost:52648/api/Categorias");
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState == 4 && miLlamada.status == 200) {           
            arrayCategorias = JSON.parse(miLlamada.responseText);
            anhiadirCategorias(arrayCategorias);
        }
    }
    miLlamada.send();
}

function anhiadirCategorias(arrayCategorias) {
    for (var i = 0; i < arrayCategorias.length; i++) {
        document.getElementById("selectCategorias").appendChild(new Option(arrayCategorias[i].nombreCategoria, arrayCategorias[i].idCategoria));
    }
}





//function insertar(Persona) {

//    var miLlamada = new XMLHttpRequest();

//    miLlamada.open("POST", "https:// vuestraapipersonas/api/Personas /");

//    miLlamada.setRequestHeader('Content-type', 'application/json; charset=utf-8');

//    var json = JSON.stringify(Persona);

//    // Definicion estados

//    miLlamada.onreadystatechange = function () {

//        if (miLlamada.readyState < 4) {

//            //aquí se puede poner una imagen de un reloj o un texto “Cargando”

//        }

//        else

//            if (miLlamada.readyState == 4 && miLlamada.status == 200) {

//                alert("Persona insertada con exito");

//            }

//    };

//    miLlamada.send(json);

//}
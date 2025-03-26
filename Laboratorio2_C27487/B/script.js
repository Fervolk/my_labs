
let esBlanco = true;
if (document.body.style.backgroundColor = "white") {
    esBlanco = true;
} else {
    esBlanco = false;
}
function agregar() {
    const lista = document.getElementById("lista");
    const cantidadLista = lista.getElementsByTagName("li").length;
    const nuevoElemento = document.createElement("li");
    nuevoElemento.textContent = `Elemento${cantidadLista + 1}`;
    lista.appendChild(nuevoElemento)
}
function cambiarFondo() {
    if (esBlanco) {
        document.body.style.backgroundColor = "#b8fffd";
        esBlanco = false
    } else {
        document.body.style.backgroundColor = "white";
        esBlanco = true;
    }
}
function borrar() {
    const lista = document.getElementById("lista");
    if (lista.lastElementChild) {
        lista.removeChild(lista.lastElementChild);
    }
}
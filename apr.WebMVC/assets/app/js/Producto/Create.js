let urlBaseApi = 'http://localhost:54330';
let urlCreate = `${urlBaseApi}/Producto/create`;
let urlModule = `${urlBaseApi}/Producto`;

//Variables
const ddlCatgoria = document.getElementById('ddlCatgoria'),
    txtNombre = document.getElementById('txtNombre'),
    txtPresentacion = document.getElementById('txtPresentacion'),
    txtPrecio = document.getElementById('txtPrecio');

const btnReturnList = document.getElementById('btnReturnList'),
    btnGuardar = document.getElementById('btnGuardar');


//Metodos
const returnToList = () => {
    location.replace(urlModule);
};

const drawDdlCategoria = items => {
    let ddlOptions = ``;

    ddlCatgoria.innerHTML = '';

    ddlOptions = `<option value="0">-Seleccione-</option>`;
    items.forEach(cat => {
        ddlOptions += `<option value="${cat.IdCategoria}">${cat.Nombre}</option>`;
    });

    ddlCatgoria.innerHTML = ddlOptions;
};

const getCategorias = async () => {

    const response = await fetch(`${urlBaseApi}/Categoria/findAll`);
    const data = await response.json();

    drawDdlCategoria(data.Items);
}

const validateData = () => {
    let isValid = true;
    let message = '';

    if(ddlCatgoria.value == "" || ddlCatgoria.value == 0) {
        message='Seleccione una catetoria';
        isValid = false;
    }else if(txtNombre.value.trim() == "") {
        message='Ingrese nombre del producto';
        isValid = false;
    }else if(txtPresentacion.value.trim() == "") {
        message='Ingrese presentacion del producto';
        isValid = false;
    }else if(txtPrecio.value.trim() == "" || txtPrecio.value.trim() == 0) {
        message='Ingrese precio del producto';
        isValid = false;
    }

    return {isValid, message}
}

//Ejecucion y Eventos
getCategorias();

btnReturnList.addEventListener('click', returnToList);

btnGuardar.addEventListener('click', async evt => {
    let validate = validateData();

    if(!validate.isValid){
        alert(validate.message);
        return;
    }

    let producto = {
        IdCategoria: ddlCatgoria.value,
        Nombre: txtNombre.value,
        Presentacion: txtPresentacion.value,
        Precio: parseFloat(txtPrecio.value)
    };

    console.log('guardar', producto);

    const response = await fetch(urlCreate, {
        method: 'POST', // or 'PUT'
        body: JSON.stringify(producto), // data can be `string` or {object}!
        headers: {
            'Content-Type': 'application/json'
        }
    });

    const data = await response.json();

    if(data.State){
        returnToList();
    } else {
        alert(data.Message);
    }

});
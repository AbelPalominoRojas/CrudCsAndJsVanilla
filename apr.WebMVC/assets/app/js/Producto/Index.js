let urlBaseApi = 'http://localhost:54330';
let url = `${urlBaseApi}/Producto/findAll`;
let urlModule = `${urlBaseApi}/Producto`;

//Variables
const tblPoductos = document.getElementById('tblPoductos'),
    btnNuevo = document.getElementById('btnNuevo');

//Metodos
const getProductos = async () => {
    const response = await fetch(url);
    const data = await response.json();

    //console.log(data);
    draw(data.Items);
};

const draw = (items)=> {

    const tableBody = tblPoductos.querySelector('tbody');
    let htmlRows = '';

    tableBody.innerHTML =  '';

    items.forEach(prod => {
        htmlRows += 
        `<tr>
            <td>
                <div class="text-nowrap">
                    <button type="button" class="btn btn-sm btn-outline-warning border-0">
                        <i class="fas fa-eye fa-lg"></i>
                    </button>
                    <button type="button" class="btn btn-sm btn-outline-info border-0">
                        <i class="fas fa-pen-alt fa-lg"></i>
                    </button>
                    <button type="button" class="btn btn-sm btn-outline-danger border-0">
                        <i class="fas fa-trash fa-lg"></i>
                    </button>
                </div>
            </td>
            <td>${prod.IdProducto}</td>
            <td>${prod.Categoria.Nombre}</td>
            <td>${prod.Nombre}</td>
            <td>${prod.Presentacion}</td>
            <td>${prod.Precio}</td>
        </tr>`;
    });

    tableBody.innerHTML = htmlRows;
}

//Ejecucion y eventos
getProductos();

btnNuevo.addEventListener('click', evt => {
    location.replace(`${urlModule}/Create`);
});


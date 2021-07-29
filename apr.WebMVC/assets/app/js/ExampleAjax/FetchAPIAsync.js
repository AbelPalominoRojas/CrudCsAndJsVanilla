let urlBaseApi = 'http://localhost:54330';
let url = `${urlBaseApi}/Categoria/findAll`;

//Variables
const tblCategorias = document.getElementById('tblCategorias');

//Metodos
const getCategorias = async () => {

    const response = await fetch(url);
    const data = await response.json();

    //console.log(data);
    draw(data.Items);
}

const draw = (items)=> {

    const tableBody = tblCategorias.querySelector('tbody');
    let htmlRows = '';

    tableBody.innerHTML =  '';

    items.forEach(cat => {
        htmlRows += 
        `<tr>
            <td>${cat.IdCategoria}</td>
            <td>${cat.Nombre}</td>
            <td>${cat.Descripcion == null ? '' : cat.Descripcion}</td>
        </tr>`;
    });

    tableBody.innerHTML = htmlRows;
}

//Ejecucion
getCategorias();
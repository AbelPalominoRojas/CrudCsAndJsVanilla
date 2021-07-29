let urlBaseApi = 'http://localhost:54330';
let url = `${urlBaseApi}/Categoria/findAll`;

//Variables
const tblCategorias = document.getElementById('tblCategorias');

//Metodos
const getCategorias = () => {

    fetch(url)
    .then(req => req.json())
    .then(data => {
        //console.log(data);
        draw(data.Items);
    })
    .catch(err => console.log(err));
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


//Ejecucion de metodos
getCategorias();
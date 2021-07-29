let urlBaseApi = 'http://localhost:54330';
let url = `${urlBaseApi}/Categoria/findAll`;

//Variables
const tblCategorias = document.getElementById('tblCategorias');

//Metodos
const getCategorias = () => {
    let req = new XMLHttpRequest();

    req.open('GET', url);

    req.onload = evt => {
        // console.log(req.responseText);
        let data = JSON.parse(evt.target.responseText);
        //console.log(data);
        draw(data.Items);
    };

    req.onerror = evt => {
        console.log(evt.target);
    }

    req.send(null);
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

//Ejecucion de los metodos
getCategorias();

class ConsultaService {
    constructor(){
    }

    //Promise que realiza una peticion al servidor y obtiene todos las consultas
    all(){
        return $.ajax({
            method: 'GET',
            url: '/Consultas/All',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'            
        });
    }

    //Promise que realiza una peticion al servidor y una consulta en especifico
    one(id){
        return $.ajax({
            method: 'GET',
            url:  `/Consultas/One/${id}`,
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'            
        });
    }

    //Promise que realiza una peticion al servidor y almacena una consulta
    store(dataString){
        console.log(dataString);
        return $.ajax({
            method: 'POST',
            url:  '/Consultas/Store',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            data: dataString     
        });
    }

    //Promise que realiza una peticion al servidor para editar una consulta
    edit(dataString){
        console.log(dataString);
        return $.ajax({
            method: 'POST',
            url:  '/Consultas/Edit',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            data: dataString     
        });
    }
}
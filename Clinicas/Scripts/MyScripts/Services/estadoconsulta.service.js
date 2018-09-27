class EstadoConsultasService {
    constructor(){

    }

    //Promise que realiza una peticion al servidor y obtiene todos los estados que puede tener una consulta medica
    all(){
        return $.ajax({
            method: 'GET',
            url: '/EstadoConsultas/All',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'            
        });
    }

    //Promise que realiza una peticion al servidor y obtiene un estado de la consulta medica.
    one(id){
        return $.ajax({
            method: 'GET',
            url:  `/EstadoConsultas/One/${id}`,
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'            
        });
    }

    //Promise que realiza una peticion al servidor para almacenar un estado de la consulta medica
    store(dataString){
        console.log(dataString);
        return $.ajax({
            method: 'POST',
            url:  '/EstadoConsultas/Store',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            data: dataString     
        });
    }

    //Promise que realiza una peticion al servidor para editar un estado de la consulta medica
    edit(dataString){
        console.log(dataString);
        return $.ajax({
            method: 'POST',
            url:  '/EstadoConsultas/Edit',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            data: dataString     
        });
    }
}
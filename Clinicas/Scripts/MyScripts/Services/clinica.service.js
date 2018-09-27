class ClinicaService {
    constructor(){
    }

    //Promise que realiza una peticion al servidor y obtiene todos las consultas
    all(){
        return $.ajax({
            method: 'GET',
            url: '/Clinicas/All',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'            
        });
    }

    //Promise que realiza una peticion al servidor y una consulta en especifico
    one(id){
        return $.ajax({
            method: 'GET',
            url:  `/Clinicas/One/${id}`,
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'            
        });
    }

    //Promise que realiza una peticion al servidor y almacena una consulta
    store(dataString){
        return $.ajax({
            method: 'POST',
            url:  '/Clinicas/Store',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            data: dataString     
        });
    }

    //Promise que realiza una peticion al servidor para editar una consulta
    edit(dataString){
        return $.ajax({
            method: 'POST',
            url:  '/Clinicas/Edit',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            data: dataString     
        });
    }
}
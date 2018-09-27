class TipoSangreService {
    constructor(){

    }

    //Promise que realiza una peticion al servidor y obtiene todos los Tipos de Sangre
    all(){
        return $.ajax({
            method: 'GET',
            url: '/TipoSangre/All',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'            
        });
    }

    //Promise que realiza una peticion al servidor y obtiene un tipo de sangre especifico
    one(id){
        return $.ajax({
            method: 'GET',
            url:  `/TipoSangre/One/${id}`,
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'            
        });
    }

    //Promise que realiza una peticion al servidor para almacenar un tipo de sangre
    store(dataString){
        console.log(dataString);
        return $.ajax({
            method: 'POST',
            url:  '/TipoSangre/Store',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            data: dataString     
        });
    }

    //Promise que realiza una peticion al servidor para editar un tipo de sangre
    edit(dataString){
        console.log(dataString);
        return $.ajax({
            method: 'POST',
            url:  '/TipoSangre/Edit',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            data: dataString     
        });
    }
}
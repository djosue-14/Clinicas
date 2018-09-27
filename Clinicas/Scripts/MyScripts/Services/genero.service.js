class GeneroService {
    constructor(){

    }

    //Promise que realiza una peticion al servidor y obtiene todos los  generos(sexos)
    all(){
        return $.ajax({
            method: 'GET',
            url: '/Sexo/All',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'            
        });
    }

    //Promise que realiza una peticion al servidor y un genero(sexo) en especifico
    one(id){
        return $.ajax({
            method: 'GET',
            url:  `/Sexo/One/${id}`,
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'            
        });
    }

    //Promise que realiza una peticion al servidor y almacena un genero(sexo)
    store(dataString){
        console.log(dataString);
        return $.ajax({
            method: 'POST',
            url:  '/Sexo/Store',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            data: dataString     
        });
    }

    //Promise que realiza una peticion al servidor para editar un genero(sexo)
    edit(dataString){
        console.log(dataString);
        return $.ajax({
            method: 'POST',
            url:  '/Sexo/Edit',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            data: dataString     
        });
    }
}
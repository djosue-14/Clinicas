class GraficaService {
    constructor(){

    }

    //Promise que realiza una peticion al servidor y obtiene todas las graficas
    all(){
        return $.ajax({
            method: 'GET',
            url: '/Graficas/All',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'            
        });
    }

    //Promise que realiza una peticion al servidor y devuelve una graficas en especifico
    one(id){
        return $.ajax({
            method: 'GET',
            url:  `/Graficas/One/${id}`,
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'            
        });
    }

    //Promise que almacena los datos de la grafica en la base de datos
    store(dataString){
        return $.ajax({
            method: 'POST',
            url:  '/Graficas/Store',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            data: dataString     
        });
    }

    //Promise que realiza una peticion al servidor para editar los datos de una grafica
    edit(dataString){
        return $.ajax({
            method: 'POST',
            url:  '/Graficas/Edit',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            data: dataString     
        });
    }

    getHistorial(id){
        return $.ajax({
            method: 'GET',
            url:  `/Graficas/getHistorial/${id}`,
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'            
        });
    }
}
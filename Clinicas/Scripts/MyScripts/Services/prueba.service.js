class PruebaService {
    constructor(){

    }

    all(){
        return $.ajax({
            method: 'get',
            url: '/Pruebas/All',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'            
        });
    }

    one(id){
        return $.ajax({
            method: 'get',
            url:  `/Pruebas/One/${id}`,
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'            
        });
    }

    store(dataString){
        console.log(dataString);
        
        return $.ajax({
            method: 'post',
            url:  `/Pruebas/Store`,
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            data: dataString     
        });
    }

    getDate(){
        return $.ajax({
            method: 'GET',
            url:  `/Prueba/GetDate`,
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'            
        });
    }
}
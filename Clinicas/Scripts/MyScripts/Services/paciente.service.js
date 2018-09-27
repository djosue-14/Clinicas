class PacienteService {
    constructor(){

    }

    //Promise que realiza una peticion al servidor y obtiene todos los Pacientes
    all(){
        return $.ajax({
            method: 'GET',
            url: '/Pacientes/All',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'            
        });
    }

    //Promise que realiza una peticion al servidor y obtiene un paciente especifico
    one(id){
        return $.ajax({
            method: 'GET',
            url:  `/Pacientes/One/${id}`,
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'            
        });
    }

    //Promise que realiza una peticion al servidor para almacenar un Paciente
    store(dataString){
        console.log(dataString);
        return $.ajax({
            method: 'POST',
            url:  '/Pacientes/Store',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            data: dataString     
        });
    }

    //Promise que realiza una peticion al servidor para editar un Paciente
    edit(dataString){
        console.log(dataString);
        return $.ajax({
            method: 'POST',
            url:  '/Pacientes/Edit',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            data: dataString     
        });
    }
}
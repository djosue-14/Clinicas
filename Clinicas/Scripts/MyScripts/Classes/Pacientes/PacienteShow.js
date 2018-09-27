//Clase que controla todo lo relacionado con mostrar un paciente unico
class PacienteShow {
    constructor(){
        this.init();
    }

    init(){
        this.pacienteService = new PacienteService();
        this.initEvents();
        this.initEvents();
    }

    initComponents(){

    }

    initEvents(){
        $('#pacienteOne').hide();
    }

    one(id){
        //return this.pacienteService.one(id);
        this.pacienteService.one(id).done((result) => {
            console.log(result);
        }).fail((error) => {
            console.log(error);
        });//*/
    }

    show(){
        $('#pacientesAll').hide();
        $('#create').hide();
        $('#edit').hide();
        $('#pacienteOne').show(1000);
    }
}
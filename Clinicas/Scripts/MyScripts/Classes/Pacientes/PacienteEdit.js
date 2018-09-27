//Clase que controla todo lo relacionado con editar un paciente
class PacienteEdit {
    constructor(){
        this.init();
    }
    
    //metodo que crea una nueva instancia de PacienteService e inicializa los componentes y eventos
    init(){
        this.pacienteService = new PacienteService();
        this.generoService = new GeneroService();
        this.tipoSangreService = new TipoSangreService();
        this.initComponents();
        this.initEvents();
    }

    initComponents(){
        let self = this;
        //Validacion y envio del formulario del paciente.
        $('#formEditPaciente').validate({
            //Reglas que se deben seguir para enviar el formulario
            rules: {
                PrimerNombre: { 
                    required: true, minlength: 3, maxlength: 30, lettersOnly: true 
                },
                SegundoNombre: { 
                    minlength: 3, maxlength: 30, lettersOnly: true 
                },
                PrimerApellido: {
                    required: true, minlength: 3, maxlength: 30 , lettersOnly: true
                },
                SegundoApellido: { 
                    minlength: 3, maxlength: 30, lettersOnly: true 
                },
                Telefono: { 
                    required: true, digits: true, minlength: 8 
                },
                Direccion: { 
                    required: true, minlength: 5, maxlength: 30
                },
                FechaNacimiento: { 
                    required: true, //formatDate: true 
                },
                Ocupacion: { 
                    minlength: 5, maxlength: 30, lettersOnly: true
                },
            },
            errorClass: "is-invalid text-danger",//Clases de bootstrap 4 para mostrar los errores
            validClass: "is-valid",//Clase de bootstrap 4 para mostrar que las entradas son validas
            //Si se pasan las reglas el formulario pasa a la fase de envio.
            submitHandler: function (form) {
                //serializacion de json para los campos de entrada del formulario
                let dataString = JSON.stringify(pacienteCreate.getInputs('formEditPaciente'));
                console.log(dataString);
                self.pacienteService.edit(dataString).done((result) => {
                    $('#formEditPaciente')[0].reset();//limpia el formulario
                    console.log(result); 
                    new PacienteIndex().all();//crea una nueva instancia de Pacientes y muestra a todos
                }).fail((error) => {
                    console.log(error);
                });
                return false;
            }
        });
    }

    initEvents(){
        //Captura el evento submit del formulario
        $('#formEditPaciente').submit((event) => {
            event.preventDefault();
        });
        //Oculta el formulario de edicion de la vista.
        $('#edit').hide();
        //inicializa el datetimepicker y le da un formato a las fechas ingresadas de Mes/Dia/Año
        $('#formEditPaciente #FechaNacimiento').datetimepicker({
            format: 'MM/DD/YYYY'
        });
    }

    //metodo que muestra al formulario de edicion y oculta los demas componentes ajenos al formulario de la vista
    show(id){
        $('#pacientesAll').hide();
        $('#create').hide();
        $('#pacienteOne').hide();
        this.fillForm(id);
        $('#edit').show(1000);
    }

    //Metodo que rellena los campos del formulario con los datos ya ingresados del paciente
    fillForm(id){
        this.pacienteService.one(id).done((result) => {
            let paciente = JSON.parse(result).data
            $.each(paciente, (key, value) => {
                //Si la key es FechaNacimiento y value es distinto de null le da un formato a la fecha
                //Sino simplemente rellena los campos.
                if( key == 'FechaNacimiento' && value != null ){
                    $('#formEditPaciente #'+key).val(moment(value).format('MM/DD/YYYY'));
                }
                else{
                    $('#formEditPaciente #'+key).val(value);
                }
            });
            this.getGeneros(paciente.SexoId);
            this.getTipoSangre(paciente.TipoSangreId);
        }).fail((error) => {
            console.log(error);
        });
    }

    getGeneros(generoId){
        //Realiza una peticion de todos los Generos(Sexos) y los agrega al campo select 
        this.generoService.all().done((result) => {
            let html = '';
            $.each(JSON.parse(result).data, (key, value) => {
                if(generoId == value.Id){
                    html += `
                    <option value="${value.Id}" selected>${value.Tipo}</option>             
                    `;
                }
                else{
                    html += `
                    <option value="${value.Id}">${value.Tipo}</option>             
                    `;
                }
            });
            $('#formEditPaciente #SexoId').html(html);
        }).fail((error) => {
            console.log(error);
        });
    }

    getTipoSangre(tipoSangreId){
        //Realiza una peticion de todos los tipos de sangre y los agrega al campo select
        this.tipoSangreService.all().done((result) => {
            let html = '';
            $.each(JSON.parse(result).data, (key, value) => {
                if(tipoSangreId == value.Id){
                    html += `
                    <option value="${value.Id}" selected>${value.Tipo}</option>             
                    `;
                }
                else{
                    html += `
                    <option value="${value.Id}">${value.Tipo}</option>             
                    `;
                }
            });
            $('#formEditPaciente #TipoSangreId').html(html);//*/
        }).fail((error) => {
            console.log(error);
        });
    }
}
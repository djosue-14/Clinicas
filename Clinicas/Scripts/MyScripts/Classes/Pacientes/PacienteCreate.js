//Clase que controla todo lo relacionado con crear un paciente
class PacienteCreate {
    constructor() {
        this.init();
    }

    //Metodo que crea una nueva instancia de los servicios e inicializa los componentes y eventos
    init() {
        this.pacienteService = new PacienteService();
        this.generoService = new GeneroService();
        this.tipoSangreService = new TipoSangreService();
        this.initComponents();
        this.initEvents();
    }

    initComponents() {
        let self = this;
        //Validacion del formulario para crear un nuevo paciente
        $('#formCreatePaciente').validate({
            //Reglas para validar el formulario
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
                    minlength: 5, maxlength: 30
                },
                Ocupacion: { 
                    minlength: 5, maxlength: 30, lettersOnly: true
                },
            },
            errorClass: "is-invalid text-danger",//Bootstrap4 clases para mostrar errores
            validClass: "is-valid",//Bootstrap4 clase para mostrar campos validados
            submitHandler: function (form) {
                //Serializacion Json de los campos del formulario
                let dataString = JSON.stringify(self.getInputs('formCreatePaciente'));
                self.pacienteService.store(dataString).done((result) => {
                    $('#formCreatePaciente')[0].reset();//Limpia el formulario
                    console.log(result);
                    new PacienteIndex().all();//Crea una nueva instancia de pacientes y muestra a todos.
                }).fail((error) => {
                    console.log(error);
                });
                return false;
            }
        });
    }

    //Inicializa los eventos del bloque html de creacion
    initEvents() {
        //Evento que captura el envio del formulario para crear un paciente
        $('#formCreatePaciente').submit((event) => {
            event.preventDefault();
        });
        //Oculta el formulario para crear un paciente de la vista
        $('#create').hide();
        //Inicializa el datetimepicker y le da un formato de Mes/Dia/Año a la fecha
        $('#formCreatePaciente #FechaNacimiento').datetimepicker({
            format: 'MM/DD/YYYY'
        });
    }

    //Obtiene todos los campos del formulario.
    getInputs(id) {
        let formValues = {};
        //Realiza una busqueda de todos los campos input en el formulario
        let formInputs = document.forms[id].getElementsByTagName("input");
        for (let i = 0; i < formInputs.length; i++) {
            formValues[formInputs[i].name] = formInputs[i].value;
        }
        //Realiza una busqueda de todos los campos select en el formulario
        let formSelects = document.forms[id].getElementsByTagName("select");
        for (let i = 0; i < formSelects.length; i++) {
            formValues[formSelects[i].name] = formSelects[i].value;
        }
        return formValues;
    }

    getDependencias(){
        //Realiza una peticion de todos los Generos(Sexos) y los agrega al campo select 
        this.generoService.all().done((result) => {
            let html = '';
            console.log(JSON.parse(result).data);
            $.each(JSON.parse(result).data, (key, value) => {
                html += `
                    <option value="${value.Id}">${value.Tipo}</option>             
                `;
            });
            $('#formCreatePaciente #SexoId').html(html);
        }).fail((error) => {
            console.log(error);
        });

        //Realiza una peticion de todos los tipos de sangre y los agrega al campo select
        this.tipoSangreService.all().done((result) => {
            let html = '';
            $.each(JSON.parse(result).data, (key, value) => {
                html += `
                    <option value="${value.Id}">${value.Tipo}</option>             
                `;
            });
            $('#formCreatePaciente #TipoSangreId').html(html);//*/
        }).fail((error) => {
            console.log(error);
        });
    }
}
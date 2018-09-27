class ConsultaCreate{
    constructor(){
        this.init();
    }

    //Crea una nueva instancia de los servicios e inicializa los componentes y eventos
    init() {
        this.consultaService = new ConsultaService();
        this.initComponents();
        this.initEvents();
    }

    initComponents() {
        let self = this;
        //Validacion del formulario para crear una nueva consulta
        $('#formCreateConsulta').validate({
            //Reglas para validar el formulario
            rules: {
                Titulo: { 
                    required: true, minlength: 3, maxlength: 30, lettersOnly: true 
                },
                Fecha: {
                    required: true
                },
                Descripcion: { 
                    minlength: 5, maxlength: 30
                }
            },
            //Bootstrap4 clases para mostrar errores
            errorClass: "is-invalid text-danger",
            //Bootstrap4 clase para mostrar campos validados
            validClass: "is-valid",
            submitHandler: function (form) {
                //Asignar Inicio y Fin de la consulta a los input de tipo hidden
                let inicio = $('#Fecha').data('daterangepicker').startDate;
                let fin = $('#Fecha').data('daterangepicker').endDate;
                $('#Inicio').val(moment(inicio).format("YYYY-MM-DD HH:mm"));
                $("#Fin").val(moment(fin).format("YYYY-MM-DD HH:mm"));
               
                //Serializacion Json de los campos del formulario
                let dataString = JSON.stringify(pacienteCreate.getInputs('formCreateConsulta'));
                self.consultaService.store(dataString).done((result) => {
                    $('#formCreateConsulta')[0].reset();//Limpia el formulario
                    window.open('/Consultas', '_self');
                }).fail((error) => {
                    console.log(error);
                });
                return false;
            }
        });
    }

    //Inicializa todos los eventos
    initEvents() {
        $("#Fecha").daterangepicker({
            autoUpdateInput: false,
            timePicker: true,
            //singleDatePicker: true,
        });

        $('#formCreateConsulta #Fecha').on('apply.daterangepicker', function(ev, picker) {
            $(this).val(picker.startDate.format('MM/DD/YYYY HH:mm') + ' - ' + picker.endDate.format('MM/DD/YYYY HH:mm'));
        });
      
        $('#formCreateConsulta #Fecha').on('cancel.daterangepicker', function(ev, picker) {
            $(this).val('');
        });

        $('#formCreateConsulta').submit((event) => {
            event.preventDefault();
        });
    }

    setPacienteId(pacienteId){
        console.log(pacienteId);
        $('#PacienteId').val(pacienteId);
        $('#modalAddConsulta').modal('show')
    }
}
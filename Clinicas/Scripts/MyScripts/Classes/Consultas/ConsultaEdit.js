class ConsultaEdit{
    constructor(){
        this.init();
    }

    //Crea una nueva instancia de los servicios e inicializa los componentes y eventos
    init() {
        this.consultaService = new ConsultaService();
        this.pacienteCreate = new PacienteCreate();
        this.initComponents();
        this.initEvents();
    }

    initComponents() {
        let self = this;
        //Validacion del formulario para crear una nueva consulta
        $('#formEditConsulta').validate({
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

                let dataString = JSON.stringify(self.pacienteCreate.getInputs('formEditConsulta'));
                self.consultaService.edit(dataString).done((result) => {
                    $('#formEditConsulta')[0].reset();//Limpia el formulario
                    new ConsultaIndex().all();
                }).fail((error) => {
                    console.log(error);
                });
                return false;//*/
            }
        });
    }

    //Inicializa todos los eventos
    initEvents() {

        $('#formEditConsulta').submit((event) => {
            event.preventDefault();
        });

        $("#formEditConsulta #Fecha").daterangepicker({
            autoUpdateInput: true,
            timePicker: true,
            //singleDatePicker: true,
        });

    }

    fillForm(id){
        this.consultaService.one(id).done((result) => {
            let data = JSON.parse(result).data;

            //Llena con un valor los input del formulario
            $('#formEditConsulta #Id').val(data.Id);
            $('#Titulo').val(data.Titulo);
            $('#formEditConsulta #Descripcion').val(data.Descripcion);
            $('#formEditConsulta #PacienteId').val(data.PacienteId);
            $('#formEditConsulta #EstadoConsultaId').val(data.EstadoConsultaId);
            $('#formEditConsulta #UsuarioAsignadoId').val(data.UsuarioAsignadoId);

            //Previene mostrar un valor null en el input fecha
            //Establece la fecha de inicio y fin de la variable data al daterangepicker.
            if(data.Fin != null){
                $('#formEditConsulta #Fecha').val(moment(data.Inicio).format('YYYY/MM/DD HH:mm') +' - '
                +moment(result.Fin).format('YYYY/MM/DD HH:mm'));
                $('#Fecha').data('daterangepicker').startDate = data.Inicio;
                $('#Fecha').data('daterangepicker').endDate = data.Fin;
            }else{
                $('#formEditConsulta #Fecha').val(moment(data.Inicio).format('YYYY/MM/DD HH:mm'));
                $('#Fecha').data('daterangepicker').startDate = data.Inicio;
            }
            
            $('#consultaShow').hide();
            $('#consultasEdit').show();
        }).fail((error) => {
            console.log(error);
        });
    }
}
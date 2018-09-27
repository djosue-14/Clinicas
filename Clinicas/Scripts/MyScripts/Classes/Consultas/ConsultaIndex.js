class ConsultaIndex{
    constructor(){
        this.init();
    }

    //Crea una nueva instancia de los servicios e inicializa los componentes y eventos
    init() {
        this.consultaService = new ConsultaService();
        this.initComponents();
        this.initEvents();
        this.all();
    }

    initComponents() {
    }

    //Inicializa todos los eventos
    initEvents() {
        $('#consultaShow').hide();
        $('#consultasEdit').hide();
        $('#graficas').hide();
        $("#consultasAll").show();

        $("#Fecha").daterangepicker({
            timePicker: true,
            //singleDatePicker: true,
        });

        $('#formCreateConsulta').submit((event) => {
            event.preventDefault();
            let inicio = $('#Fecha').data('daterangepicker').startDate;
            let fin = $('#Fecha').data('daterangepicker').endDate;
            console.log(moment(inicio).format("MM/DD/YYYY HH:mm"));
            console.log(moment(fin).format("MM/DD/YYYY HH:mm"));
        });
    }

    //Muestra todos los generos(sexos)
    all(){
        this.consultaService.all().done((result) => {
            let eventos = [];
            $.each(JSON.parse(result).data, (key, value) => {
                eventos.push({
                    "id": value.Id,
                    "title": value.Titulo,
                    "start": value.Inicio,
                    "end": value.Fin,
                    "descripcion": value.Descripcion,
                    "PacienteId": value.PacienteId,
                    "UsuarioAsignadoId": value.UsuarioAsignadoId,
                    "EstadoConsultaId": value.EstadoConsultaId,
                })
            });
            $('#calendar').fullCalendar({
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay,listWeek'
                },
                locale: 'es',//en español
                defaultDate: moment(new Date()).format('YYYY-MM-DD'),
                navLinks: true, // can click day/week names to navigate views
                editable: true,
                eventLimit: true, // allow "more" link when too many events
                events: eventos,
                eventClick: (event) => {
                    //consultaEdit.fillForm(event);
                    //$('#modalEditConsulta').modal('show');
                    $('#consultasAll').hide();
                    consultaShow.show(event.id);
                    $('#consultaShow').show(1000);
                }
            });
        }).fail((error) => {
            console.log(error);
        });
    }
}
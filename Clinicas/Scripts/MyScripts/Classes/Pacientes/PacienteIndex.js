//Class que controla el index
class PacienteIndex {
    constructor() {
        this.init();
    }

    //Metodo que crea una instancia de los servicios e inicializa los componentes y eventos
    init() {
        this.pacienteService = new PacienteService();
        this.initComponents();
        this.initEvents();
        this.all();
    }

    initComponents() {
    }

    //Metodo que inicializa los eventos.
    initEvents() {
        //Muestra la tabla con todos los pacientes y oculta las demas vistas.
        $('#pacientesAll').show();
        $('#edit').hide();
        $('#create').hide();
        $('#pacienteOne').hide();

        //Evento que muestra el formulario de creacion y oculta la tabla de pacientes.
        $('#btnAddPaciente').click(() => {
            $('#pacientesAll').hide();
            //Obtiene los datos de los que depende la entidad paciente.
            pacienteCreate.getDependencias();
            $('#create').show(1000);
        });
    }

    all() {
        this.pacienteService.all().done((result) => {
            console.log(JSON.parse(result));
            let resultado = JSON.parse(result);//Deserializacion de la resuesta json.
            let html ='';
            $.each(resultado.data, (key, paciente)=>{
                html += ` 
                    <tr>
                        <td>${paciente.PrimerNombre} </td>
                        <td>${paciente.PrimerApellido} </td>
                        <td>${paciente.Telefono}</td>
                        <td><button type="button" class="btn btn-info" id="btnInfoPaciente" onclick="pacienteShow.show()"><i aria-hidden="true" class="fa fa-info"></i></button>
                        <button type="button" class="btn btn-warning" id="btnEditPaciente" onclick="pacienteEdit.show(${paciente.Id})"><i aria-hidden="true" class="fa fa-edit"></i></button>
                        <button type="button" class="btn" id="btnEditPaciente" onclick="consultaCreate.setPacienteId(${paciente.Id})"><i aria-hidden="true" class="fa fa-calendar"></i></button></td>                        
                    </tr>                
                `;
            });
            $('#dtPacientes tbody').html(html);
            $("#dtPacientes").DataTable();
        }).fail((error) => {
            console.log(error);
        });
    }
}
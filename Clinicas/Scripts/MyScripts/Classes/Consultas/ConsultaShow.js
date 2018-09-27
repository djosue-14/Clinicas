class ConsultaShow{
    constructor(){
        this.init();
    }

    init(){
        this.consultaService = new ConsultaService();
        this.initComponents();
        this.initEvents();
    }

    initComponents(){

    }

    initEvents(){

    }

    show(id){
        console.log(id);
        this.consultaService.one(id).done((result) => {
            //console.log(result);
            this.fillConsulta(result);
        }).fail((error) => {
            console.log(error);
        });
    }

    fillConsulta(result){
        let html = '';
        let data = JSON.parse(result).data;
        html += `
            <dt class="col-sm-6">Titulo:</dt>
            <dd class="col-sm-6">${data.Titulo}</dd>
            <dt class="col-sm-6">Fecha y Hora Inicio:</dt>
            <dd class="col-sm-6">${moment(data.Inicio).format('YYYY-MM-DD HH:mm')}</dd>
            <dt class="col-sm-6">Fecha y Hora Fin:</dt>
            <dd class="col-sm-6">${moment(data.Fin).format('YYYY-MM-DD HH:mm')}</dd>
            <dt class="col-sm-6">Descripci&oacute;n</dt>
            <dd class="col-sm-6">${data.Descripcion}</dd>
            <dt class="col-sm-6">Estado Consulta</dt>
            <dd class="col-sm-6">${data.EstadoConsulta.Estado}</dd>   
            <dt class="col-sm-6">Opciones</dt>
            <dd class="col-sm-6">
                <button type="button" class="btn btn-warning" id="btnEditConsulta" onclick="consultaEdit.fillForm(${data.Id})"><i aria-hidden="true" class="fa fa-edit"></i></button>
                <button type="button" class="btn btn-dark" id="btnCreateGrafica" onclick="graficaCreate.getConsulta(${data.Id})"><i aria-hidden="true" class="fa fa-calculator"></i></button>
            </dd> 
        `;

        $('#datosConsulta').html(html);

        html = '';
        html +=`
            <dt class="col-sm-6">Nombres: </dt>
            <dd class="col-sm-6">${data.Paciente.PrimerNombre}</dd>
            <dt class="col-sm-6">Apellidos: </dt>
            <dd class="col-sm-6">${data.Paciente.PrimerApellido}</dd>
            <dt class="col-sm-6">Tel&eacute;fono: </dt>
            <dd class="col-sm-6">${data.Paciente.Telefono}</dd>
            <dt class="col-sm-6">Fecha Nacimiento: </dt>
            <dd class="col-sm-6">${moment(data.Paciente.FechaNacimiento).format('YYYY-MM-DD')}</dd>
            <dt class="col-sm-6">Edad: </dt>
            <dd class="col-sm-6">${moment(data.Paciente.FechaNacimiento).fromNow()}</dd>
        `;

        $('#datosPaciente').html(html);
    }
}
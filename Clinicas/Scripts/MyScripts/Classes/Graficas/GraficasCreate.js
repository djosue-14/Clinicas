class GraficasCreate{
    constructor(){
        this.init();
    }

    init(){
        this.graficaService = new GraficaService();
        this.consultaService = new ConsultaService();
        this.initComponents();
        this.initEvents();
    }

    initComponents(){
        let self = this;
        //Validacion del formulario para crear un nuevo paciente
        $('#formCreateGrafica').validate({
            //Reglas para validar el formulario
            rules: {
                Peso: { 
                    required: true,
                },
                Talla: { 
                    required: true,
                },
                EdadActual: {
                    required: true,
                }
            },
            errorClass: "is-invalid text-danger",//Bootstrap4 clases para mostrar errores
            validClass: "is-valid",//Bootstrap4 clase para mostrar campos validados
            submitHandler: function (form) {
                //Serializacion Json de los campos del formulario
                let edadActual = $('#formCreateGrafica #EdadActual').val().split(" ");
                let dataString = {
                    'Peso': $('#formCreateGrafica input#Peso').val(),
                    'Talla': $('#formCreateGrafica #Talla').val(),
                    'EdadActual': edadActual[0],
                    'ConsultaId': $('#formCreateGrafica #ConsultaId').val(), 
                };
                let d = JSON.stringify(dataString)
                console.log(d);
                self.graficaService.store(d).done((result) => {
                    $('#formCreateGrafica')[0].reset();//Limpia el formulario
                    new ConsultaIndex().all();//Crea una nueva instancia de pacientes y muestra a todos.
                }).fail((error) => {
                    console.log(error);
                });
                return false;
            }
        });
    }

    initEvents(){
        
        $('#formCreateGrafica').submit((event) => {
            event.preventDefault();
        });

        $('#graficas').hide();
    }

    getConsulta(id){
        this.consultaService.one(id).done((result) => {
            this.setData(result);
        }).fail((error) => {
            console.log(error);
        });
    }
    setData(result){
        let data = JSON.parse(result).data;
        $('#formCreateGrafica #ConsultaId').val(data.Id);
        $('#formCreateGrafica #FechaNacimiento').val(moment(data.Paciente.FechaNacimiento).format('YYYY-MM-DD'));
        $('#formCreateGrafica #FechaVisita').val(moment(data.Inicio).format('YYYY-MM-DD')).change();

        if(data.Paciente.Sexo.Tipo == "Femenino"){
            $('#formCreateGrafica #Femenino').attr('checked', true);
        }else{
            $('#formCreateGrafica #Masculino').attr("checked", true);
        }
        console.log(data);

        $('#consultaShow').hide();
        $('#graficas').show();
    }
}
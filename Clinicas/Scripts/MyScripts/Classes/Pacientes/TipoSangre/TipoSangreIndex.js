class TipoSangreIndex{
    constructor(){
        this.init();
    }

    //Crea una nueva instancia de los servicios e inicializa los componentes y eventos
    init() {
        this.tipoSangreService = new TipoSangreService();
        this.initComponents();
        this.initEvents();
        //this.all();
    }

    //Inicializa los componentes
    initComponents() {
    }

    //Inicializa los eventos
    initEvents() {
    }

    //Muestra todos los tipos de sangre
    all(){
        this.tipoSangreService.all().done((result) => {
            console.log(result);
        }).fail((error) => {
            console.log(error);
        });
    }
}
class GeneroIndex{
    constructor(){
        this.init();
    }

    //Crea una nueva instancia de los servicios e inicializa los componentes y eventos
    init() {
        this.generoService = new GeneroService();
        this.initComponents();
        this.initEvents();
        //this.all();
    }

    initComponents() {
    }

    //Inicializa todos los eventos
    initEvents() {
    }

    //Muestra todos los generos(sexos)
    all(){
        this.generoService.all().done((result) => {
            console.log(result);
        }).fail((error) => {
            console.log(error);
        });
    }
}
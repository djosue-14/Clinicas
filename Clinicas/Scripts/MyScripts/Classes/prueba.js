class PruebaIndex {
    constructor() {
        this.pruebaService = new PruebaService();
        this.init();
    }

    init() {
        this.initComponents();
        this.initEvents();
        this.all();
    }

    initComponents() {

    }

    initEvents() {

    }


    all() {
        this.pruebaService.all().done((result) => {
            let html = '';
            $.each(result.data, (key, prueba) => {
                html += `
                    <tr>
                        <td>${prueba.Id}</td>
                        <td>${prueba.Nombre}</td>
                        <td>${prueba.Direccion}</td>
                        <td>${prueba.Dpi}</td>
                        <td>
                            <a href="/Pruebas/Edit/${prueba.Id}" class="btn btn-warning btn-sm"><i class="fa fa-pencil"></i></a>
                        </td>
                    </tr>                
                `;
            });
            $('#tablePruebas tbody').html(html);
        }).fail((error) => {
            console.log(error);

        });
    }
}

class PruebaCreate {
    constructor() {
        this.init();
    }

    init() {
        this.pruebaService = new PruebaService();
        this.initComponents();
        this.initEvents();
    }

    initComponents() {
        let self = this;
        $('#formCreatePrueba').validate({
            rules: {
                Nombre: {
                    required: true
                },
                Direccion: {
                    required: true
                },
                Dpi: {
                    required: true,
                    minlength: 13,
                    maxlength: 13
                }
            },
            submitHandler: function (form) {
                let dataString = JSON.stringify({
                    Nombre: $('#Nombre').val(),
                    Direccion: $('#Direccion').val(),
                    Dpi: $('#Dpi').val(),
                });
                
                self.pruebaService.store(dataString).done((result) => {
                    
                }).fail((error) => {

                });
            }
        });
    }



    initEvents() {
        $('#formCreatePrueba').submit((event) => {
            event.preventDefault();
        });
    }

}

class PruebaShow{
    constructor(){
        this.pruebaService = new PruebaService();
        this.getDate();
    }

    getDate(){
        this.pruebaService.getDate().done((result) => {
            console.log(result);
        }).fail((error) => {
            console.log(error);
        });
    }
}
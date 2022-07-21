﻿jsRegistroIndicadorFonatel= {
    "Controles": {
        "btnllenadoweb": "#TableRegistroIndicadorFonatel tbody tr td .btn-home",
        "txtCantidadRegistroIndicador": "#txtCantidadRegistroIndicador",
        "txtCantidadRegistroIndicador": "#txtCantidadRegistroIndicador",
        "tabActivoRegistroIndicador": "div.tab-pane.active",
        "tablaIndicador": "div.tab-pane.active .table-wrapper-fonatel table",
        "columnasTablaIndicador": "div.tab-pane.active .table-wrapper-fonatel table thead tr",

        "ControlListaCategorias": (id, option) => `<div class="select2-wrapper">
                                                    <select class="listasDesplegables" id = "${id}" >
                                                    <option></option>${option}</select ></div >`

    },
    "Variables": {
        "VariableIndicador": 1,
        "paginasActualizadasConSelect2_tablaIndicador": {}
    },

    "Metodos": {
        "GuardarEncabezadFormulario": function(){

        }
    }

}

$(document).on("click", jsRegistroIndicadorFonatel.Controles.btnllenadoweb, function () {
    let id = 1;
    window.location.href = "/Fonatel/RegistroIndicadorFonatel/Create?id=" + id;
});

/*
 Evento para cada input Cantidad de Registros de cada tab o indicador.
 */
$(document).on("keypress", jsRegistroIndicadorFonatel.Controles.txtCantidadRegistroIndicador, function () {
    if (event.keyCode == 13) {
        var table = $(jsRegistroIndicadorFonatel.Controles.tablaIndicador).DataTable();
        table.clear().draw();

        let tabActual = getTabActivoRegistroIndicador();

        jsRegistroIndicadorFonatel.Variables.paginasActualizadasConSelect2_tablaIndicador[tabActual] = [];
        
        if ($(this).val() != 0 || $(this).val().trim() != "") {
            for (let x = 0; x < $(this).val(); x++) {
                let listaColumnasVariablesDato = [];

                $(jsRegistroIndicadorFonatel.Controles.columnasTablaIndicador).children().each(function (index) {
                    if ($(this).attr('class').includes("highlighted")) {
                        listaColumnasVariablesDato.push(1);
                    }
                    else {
                        listaColumnasVariablesDato.push(
                            jsRegistroIndicadorFonatel.Controles.ControlListaCategorias(
                                `ddlTabla-${tabActual}-${x}-${index}`,
                                '<option value="1">Opción 1</option><option value="2">Opción 2</option>'));
                    }
                });
                table.row.add(listaColumnasVariablesDato).draw(false);
            }

            jsRegistroIndicadorFonatel.Variables.paginasActualizadasConSelect2_tablaIndicador[tabActual].push(0);

            setSelect2();

            eventNextPrevDatatable();
        }
    }
});

/*
 Evento que captura los eventos de siguiente y atras de los datatables.
 Se maneja una variable que almacena las paginas visitadas de cada tab o indicador, 
 para así refrescar los select2.
 */
function eventNextPrevDatatable() {
    $(jsRegistroIndicadorFonatel.Controles.tablaIndicador).on('page.dt', function () {
        var nextPage = $(this).DataTable().page.info().page; 
        let listaPages = jsRegistroIndicadorFonatel.Variables.paginasActualizadasConSelect2_tablaIndicador[getTabActivoRegistroIndicador()];

        if (!listaPages.includes(nextPage)) {
            setTimeout(() => {
                setSelect2()
            }, 0);

            listaPages.push(nextPage);
        }
    });
}

function getTabActivoRegistroIndicador() {
    return $(jsRegistroIndicadorFonatel.Controles.tabActivoRegistroIndicador).attr("id");
}

function setSelect2() {
    $('.listasDesplegables').select2({
        placeholder: "Seleccione",
        width: 'resolve'
    });
}
﻿    JsIndicador= {
        "Controles": {
            "btnstep": ".step_navigation_indicador div",
            "divContenedor": ".stepwizard-content-container",
            "btnGuardarIndicador": "#btnGuardarIndicador",
            "btnSiguienteIndicador":"#btnSiguienteIndicador",
            "btnGuardarVariable": "#btnGuardarVariable",
            "btnGuardarCategoría": "#btnGuardarCategoría",
            "btnEditarIndicador": "#TableIndicador tbody tr td .btn-edit",
            "btnDesactivarIndicador": "#TableIndicador tbody tr td .btn-power-off",
            "btnActivarIndicador": "#TableIndicador tbody tr td .btn-power-on",
            "btnEliminarIndicador": "#TableIndicador tbody tr td .btn-delete",
            "btnClonarIndicador": "#TableIndicador tbody tr td .btn-clone",
            "btnAddIndicadorVariable": "#TableIndicador tbody tr td .variable",
            "btnAddIndicadorCategoría": "#TableIndicador tbody tr td .Categoría",
            "btnEliminarVariable":"#TableDetalleVariable tbody tr td .btn-delete",
            "btnSiguienteCategoría": "#btnSiguienteCategoría",
            "btnAtrasCategoría": "#btnAtrasCategoría",
            "btnSiguienteVariable": "#btnSiguienteVariable",
            "btnAtrasVariable": "#btnAtrasVariable",
            "btnCancelar":"#btnCancelarIndicador"


    },
    "Variables":{

    },

    "Metodos": {

    }

}


$(document).on("click", JsIndicador.Controles.btnCancelar, function (e) {
    e.preventDefault();
    jsMensajes.Metodos.ConfirmYesOrNoModal("¿Desea cancelar la acción?", jsMensajes.Variables.actionType.cancelar)
        .set('onok', function (closeEvent) {
            window.location.href = "/Fonatel/IndicadorFonatel/Index";
        });
});

$(document).on("click", JsIndicador.Controles.btnEditarIndicador, function () {
    let id = $(this).val();
    window.location.href = "/Fonatel/IndicadorFonatel/Create?id=" + id;
});



$(document).on("click", JsIndicador.Controles.btnAddIndicadorCategoría, function () {
    let id = 1;
    window.location.href = "/Fonatel/IndicadorFonatel/DetalleCategoría?id=" + id;
});

$(document).on("click", JsIndicador.Controles.btnAddIndicadorVariable, function () {
    let id = 1;
    window.location.href = "/Fonatel/IndicadorFonatel/DetalleVariables?id=" + id;
});




$(document).on("click", JsIndicador.Controles.btnDesactivarIndicador, function () {
    jsMensajes.Metodos.ConfirmYesOrNoModal("¿Desea activar el Indicador?", jsMensajes.Variables.actionType.estado)
        .set('onok', function (closeEvent) {
            jsMensajes.Metodos.OkAlertModal("El Indicador ha sido activado")
                .set('onok', function (closeEvent) { window.location.href = "/Fonatel/IndicadorFonatel/index" });
        });
});


$(document).on("click", JsIndicador.Controles.btnEliminarIndicador, function () {
    jsMensajes.Metodos.ConfirmYesOrNoModal("¿Desea eliminar el Indicador?", jsMensajes.Variables.actionType.estado)
        .set('onok', function (closeEvent) {
            jsMensajes.Metodos.OkAlertModal("El Indicador ha sido eliminado")
                .set('onok', function (closeEvent) { window.location.href = "/Fonatel/IndicadorFonatel/index" });
        });
});


$(document).on("click", JsIndicador.Controles.btnEliminarVariable, function () {
    let id = 1;
    jsMensajes.Metodos.ConfirmYesOrNoModal("¿Desea eliminar la Variable?", jsMensajes.Variables.actionType.eliminar)
        .set('onok', function (closeEvent) {
            jsMensajes.Metodos.OkAlertModal("La Variable ha sido eliminada")
                .set('onok', function (closeEvent) {  });
        });
});




$(document).on("click", JsIndicador.Controles.btnActivarIndicador, function () {
    jsMensajes.Metodos.ConfirmYesOrNoModal("¿Desea desactivar el Indicadores?", jsMensajes.Variables.actionType.estado)
        .set('onok', function (closeEvent) {
            jsMensajes.Metodos.OkAlertModal("La Indicador ha sido Desactivado")
                .set('onok', function (closeEvent) { window.location.href = "/Fonatel/IndicadorFonatel/index" });
        });
});




$(document).on("click", JsIndicador.Controles.btnGuardarIndicador, function (e) {
    e.preventDefault();
    jsMensajes.Metodos.ConfirmYesOrNoModal("Existen campos vacíos. ¿Desea realizar un guardado parcial del Indicador?", jsMensajes.Variables.actionType.agregar)
        .set('onok', function (closeEvent) {
            $("a[href='#step-2']").trigger('click');
        });
});



$(document).on("click", JsIndicador.Controles.btnSiguienteIndicador, function (e) {
    e.preventDefault();
    $("a[href='#step-2']").trigger('click');
});




$(document).on("click", JsIndicador.Controles.btnSiguienteVariable, function (e) {
    e.preventDefault();
   $("a[href='#step-3']").trigger('click');

});


$(document).on("click", JsIndicador.Controles.btnAtrasVariable, function (e) {
    e.preventDefault();
    $("a[href='#step-1']").trigger('click');

});


$(document).on("click", JsIndicador.Controles.btnSiguienteCategoría, function (e) {
    e.preventDefault();
    jsMensajes.Metodos.ConfirmYesOrNoModal("¿Desea agregar el Indicador?", jsMensajes.Variables.actionType.estado)
        .set('onok', function (closeEvent) {
            jsMensajes.Metodos.OkAlertModal("La Indicador ha sido agregado")
                .set('onok', function (closeEvent) { window.location.href = "/Fonatel/IndicadorFonatel/index" });
        });

});


$(document).on("click", JsIndicador.Controles.btnAtrasCategoría, function (e) {
    e.preventDefault();
    $("a[href='#step-2']").trigger('click');

});








$(document).on("click", JsIndicador.Controles.btnGuardarVariable, function (e) {
    e.preventDefault();

    jsMensajes.Metodos.ConfirmYesOrNoModal("¿Desea agregar  la Variable?", jsMensajes.Variables.actionType.agregar)
        .set('onok', function (closeEvent) {
            jsMensajes.Metodos.OkAlertModal("La Variable ha sido creada")
                .set('onok', function (closeEvent) { });
        });
});

$(document).on("click", JsIndicador.Controles.btnGuardarCategoría, function (e) {
    e.preventDefault();

    jsMensajes.Metodos.ConfirmYesOrNoModal("¿Desea agregar  la Categoría?", jsMensajes.Variables.actionType.agregar)
        .set('onok', function (closeEvent) {
            jsMensajes.Metodos.OkAlertModal("La Categoría ha sido creada")
                .set('onok', function (closeEvent) { });
        });
});


$(document).on("click", JsIndicador.Controles.btnClonarIndicador, function () {
    let id = 1;
    jsMensajes.Metodos.ConfirmYesOrNoModal("¿Desea clonar el Indicador?", jsMensajes.Variables.actionType.clonar)
        .set('onok', function (closeEvent) {
             window.location.href = "/Fonatel/IndicadorFonatel/Create?id="+id
        });
});


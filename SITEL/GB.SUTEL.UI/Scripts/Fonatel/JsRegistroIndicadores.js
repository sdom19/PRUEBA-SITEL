﻿jsRegistroIndicadorFonatel = {
    "Controles": {
        "tabRegistroIndicador": (id) => `#Tab${id} a`,
        "tabRgistroIndicadorActive": "ul .active a",
        "tabRgistroIndicador": "div.tab-pane",
        "columnasTablaIndicador": "div.tab-pane.active .table-wrapper-fonatel table thead tr",
        "columnaTablaIndicador": "div.tab-pane.active .table-wrapper-fonatel table thead tr th",
        "filasTablaIndicador": "div.tab-pane.active .table-wrapper-fonatel table tbody",
        "tablaIndicador": "div.tab-pane.active .table-wrapper-fonatel table",
        "tablaIndicadorRecorrido": "div.tab-pane.active .table-wrapper-fonatel table  tbody  tr",
        "tablaIndicador_filter": "div.tab-pane.active #tablaIndicador_filter",
        "tablaIndicadorActivo": "div.tab-pane.active .data-table-indicador",
        "tablaIndicadorRecorridoMultiple": '.data-table-indicador tbody  tr',



        "btnllenadoweb": "#TableRegistroIndicadorFonatel tbody tr td .btn-edit-form",
        "txtCantidadRegistroIndicador": "#txtCantidadRegistroIndicador",
        "txtNotasInformante": "#txtNotasInformante",
        "tabActivoRegistroIndicador": "div.tab-pane.active",


        "table": "",
        "btnDescargarPlantillaRegistro": "#btnDescargarPlantillaRegistro",
        "btnCargarPlantillaRegistro": "#btnCargarPlantillaRegistro",
        "inputFileCargarPlantilla": "#inputFileCargarPlantilla",
        "fileCargaRegistro": "#fileCargaRegistro",

        "btnGuardar": "div.tab-pane.active #btnGuardarRegistroIndicador",
        //"btnValidar": "div.tab-pane.active #btnValidarRegistroIndicador",
        "btnValidar": "#btnValidarRegistroIndicador",

        "btnCargaRegistroIndicador": "#btnCargaRegistroIndicador",
        "btnGuardarRegistroIndicador": "#btnGuardarRegistroIndicador",
        "btnValidarRegistroIndicador": "#btnValidarRegistroIndicador",
        "btnCancelarRegistroIndicador": "#btnCancelarRegistroIndicador",
        "tabMenu": (id) => `#menu${id}`,
        "txtcantidadIndicadores": "#cantidadIndicadores",
        "tabRgistroIndicadorVerificado": "div.tab-pane.verificado",
        "tabRgistroIndicadoractivo": "div.tab-pane.active",
    },
    "Variables": {
        "VariableIndicador": 1,
        "Validacion": false,
        "paginasActualizadasConSelect2_tablaIndicador": {},
        "ListadoDetalleRegistroIndicador": new Object(),
        "ModoConsulta": false,
        "GuardadoTotal": false

    },

    "Metodos": {
        "CrearRegistroIndicador": function () {

            jsRegistroIndicadorFonatel.Variables.ListadoDetalleRegistroIndicador = new Object();
            jsRegistroIndicadorFonatel.Variables.ListadoDetalleRegistroIndicador.DetalleRegistroIndicadorCategoriaValorFonatel = [];
            jsRegistroIndicadorFonatel.Variables.ListadoDetalleRegistroIndicador.DetalleRegistroIndicadorVariableValorFonatel = [];
            let NumeroFila = 0;
            $(jsRegistroIndicadorFonatel.Controles.tablaIndicadorRecorrido).each(function (index) {
                NumeroFila++;
                $(this).children("td").each(function (td) {

                    let registroIndicador = new Object();
                    registroIndicador.SolicitudId = ObtenerValorParametroUrl("idSolicitud");
                    registroIndicador.FormularioId = ObtenerValorParametroUrl("idFormulario");
                    registroIndicador.IndicadorId = $(jsRegistroIndicadorFonatel.Controles.tabRgistroIndicadorActive).attr('data-Indicador');
                    registroIndicador.Valor = "";
                    registroIndicador.NumeroFila = NumeroFila;
                    if ($(this).children("input").length != 0) {
                        var input = $(this).children("input");
                        if (input.hasClass("VariableDato")) {
                            let registroVariable = new Object();
                            registroVariable.SolicitudId = ObtenerValorParametroUrl("idSolicitud");
                            registroVariable.FormularioId = ObtenerValorParametroUrl("idFormulario");
                            registroVariable.IndicadorId = $(jsRegistroIndicadorFonatel.Controles.tabRgistroIndicadorActive).attr('data-Indicador');
                            registroVariable.Valor = "";
                            registroVariable.NumeroFila = NumeroFila;
                            registroVariable.IdVariable = $(input).attr("name").replace("name_", "");
                            registroVariable.Valor = input.val();
                            if (registroVariable.Valor.length != 0) {
                                jsRegistroIndicadorFonatel.Variables.ListadoDetalleRegistroIndicador.DetalleRegistroIndicadorVariableValorFonatel.push(registroVariable);
                            }
                        } else {
                            registroIndicador.IdCategoria = $(input).attr("name").replace("name_", "");
                            registroIndicador.Valor = input.val();
                        }
                    }
                    else if ($(this).children(".select2-wrapper").length != 0) {
                        var select = $(this).children(".select2-wrapper");
                        registroIndicador.IdCategoria = $(select.children(".listasDesplegables")).attr("name").replace("name_", "");
                        registroIndicador.Valor = select.children(".listasDesplegables").val();
                    }
                    if (registroIndicador.Valor.length != 0) {
                        jsRegistroIndicadorFonatel.Variables.ListadoDetalleRegistroIndicador.DetalleRegistroIndicadorCategoriaValorFonatel.push(registroIndicador);
                    }
                });
            });
        },

        "CrearRegistroIndicadorMultiple": function () {

            jsRegistroIndicadorFonatel.Variables.ListadoDetalleRegistroIndicador = new Object();
            jsRegistroIndicadorFonatel.Variables.ListadoDetalleRegistroIndicador.DetalleRegistroIndicadorCategoriaValorFonatel = [];
            jsRegistroIndicadorFonatel.Variables.ListadoDetalleRegistroIndicador.DetalleRegistroIndicadorVariableValorFonatel = [];
            let NumeroFila = 0;
            var cantIndicadores = parseInt($(jsRegistroIndicadorFonatel.Controles.txtcantidadIndicadores).val());
            for (var i = 1; i <= cantIndicadores; i++) {
                var cantFilas = $(jsRegistroIndicadorFonatel.Controles.tabMenu(i)).find(jsRegistroIndicadorFonatel.Controles.txtCantidadRegistroIndicador).val();
                if (cantFilas > 0) {
                    NumeroFila = 0;

                    $(jsRegistroIndicadorFonatel.Controles.tabMenu(i)).find(jsRegistroIndicadorFonatel.Controles.tablaIndicadorRecorridoMultiple).each(function (index) {
                        NumeroFila++;
                        $(this).children("td").each(function (td) {

                            let registroIndicador = new Object();
                            registroIndicador.SolicitudId = ObtenerValorParametroUrl("idSolicitud");
                            registroIndicador.FormularioId = ObtenerValorParametroUrl("idFormulario");
                            registroIndicador.IndicadorId = $(jsRegistroIndicadorFonatel.Controles.tabRegistroIndicador(i)).attr('data-Indicador');
                            registroIndicador.Valor = "";
                            registroIndicador.NumeroFila = NumeroFila;
                            if ($(this).children("input").length != 0) {
                                var input = $(this).children("input");
                                if (input.hasClass("VariableDato")) {
                                    let registroVariable = new Object();
                                    registroVariable.SolicitudId = ObtenerValorParametroUrl("idSolicitud");
                                    registroVariable.FormularioId = ObtenerValorParametroUrl("idFormulario");
                                    registroVariable.IndicadorId = $(jsRegistroIndicadorFonatel.Controles.tabRegistroIndicador(i)).attr('data-Indicador');
                                    registroVariable.Valor = "";
                                    registroVariable.NumeroFila = NumeroFila;
                                    registroVariable.IdVariable = $(input).attr("name").replace("name_", "");
                                    registroVariable.Valor = input.val();
                                    if (registroVariable.Valor.length != 0) {
                                        jsRegistroIndicadorFonatel.Variables.ListadoDetalleRegistroIndicador.DetalleRegistroIndicadorVariableValorFonatel.push(registroVariable);
                                    }
                                } else {
                                    registroIndicador.IdCategoria = $(input).attr("name").replace("name_", "");
                                    registroIndicador.Valor = input.val();
                                }
                            }
                            else if ($(this).children(".select2-wrapper").length != 0) {
                                var select = $(this).children(".select2-wrapper");
                                registroIndicador.IdCategoria = $(select.children(".listasDesplegables")).attr("name").replace("name_", "");
                                registroIndicador.Valor = select.children(".listasDesplegables").val();
                            }
                            if (registroIndicador.Valor.length != 0) {
                                jsRegistroIndicadorFonatel.Variables.ListadoDetalleRegistroIndicador.DetalleRegistroIndicadorCategoriaValorFonatel.push(registroIndicador);
                            }
                        });
                    });
                }
            }
        },

        "CargarColumnasTabla": function () {
            if ($(jsRegistroIndicadorFonatel.Controles.columnaTablaIndicador).length == 0) {
                let html = "<th style='min-width:30PX'>  </th>";
                for (var i = 0; i < jsRegistroIndicadorFonatel.Variables.detalleIndicadorFonatel.DetalleRegistroIndicadorVariableFonatel.length; i++) {
                    let variable = jsRegistroIndicadorFonatel.Variables.detalleIndicadorFonatel.DetalleRegistroIndicadorVariableFonatel[i];
                    html = html + variable.html;
                }
                for (var i = 0; i < jsRegistroIndicadorFonatel.Variables.detalleIndicadorFonatel.DetalleRegistroIndicadorCategoriaFonatel.length; i++) {
                    let categoria = jsRegistroIndicadorFonatel.Variables.detalleIndicadorFonatel.DetalleRegistroIndicadorCategoriaFonatel[i];
                    html = html + "<th style='min-width:160PX' scope='col'>" + categoria.NombreCategoria + "</th>";
                }
                $(jsRegistroIndicadorFonatel.Controles.columnasTablaIndicador).html(html);
            }
            else {
                //EliminarDatasource(jsRegistroIndicadorFonatel.Controles.tablaIndicador);
            }
        },

        "CargarFilasTabla": function (cantidadFilas) {
            $(jsRegistroIndicadorFonatel.Controles.filasTablaIndicador).html("");
            $(jsRegistroIndicadorFonatel.Controles.tabActivoRegistroIndicador).find(jsRegistroIndicadorFonatel.Controles.btnDescargarPlantillaRegistro).prop('disabled', false);
            $(jsRegistroIndicadorFonatel.Controles.tabActivoRegistroIndicador).find(jsRegistroIndicadorFonatel.Controles.btnCargarPlantillaRegistro).prop('disabled', false);
            let html = "<tr><td></td>";

            for (var i = 0; i < jsRegistroIndicadorFonatel.Variables.detalleIndicadorFonatel.DetalleRegistroIndicadorVariableFonatel.length; i++) {
                let variable = jsRegistroIndicadorFonatel.Variables.detalleIndicadorFonatel.DetalleRegistroIndicadorVariableFonatel[i];
                html = html + "<td><input type='number' name='name_" + variable.idVariable + "' class='form-control form-control-fonatel solo_numeros VariableDato' id='[0]-" + variable.idVariable + "'></td>";
            }
            for (var i = 0; i < jsRegistroIndicadorFonatel.Variables.detalleIndicadorFonatel.DetalleRegistroIndicadorCategoriaFonatel.length; i++) {
                let categoria = jsRegistroIndicadorFonatel.Variables.detalleIndicadorFonatel.DetalleRegistroIndicadorCategoriaFonatel[i];
                html = html + categoria.html;
            }
            html = html + "</tr>"

            for (var i = 0; i < cantidadFilas; i++) {
                $(jsRegistroIndicadorFonatel.Controles.filasTablaIndicador).append(html.replaceAll("[0]", i + 1));
            }

        },

        "CargarDatosVisualizar": function () {
            $('.container button').prop('disabled', true);
            $('textarea').prop('disabled', true);
        },

        "DescargarExcel": function () {
            jsMensajes.Metodos.OkAlertModal("El Formulario ha sido descargado")
        },

        "ImportarExcel": function () {
            var data;
            data = new FormData();
            data.append('file', $(jsRegistroIndicadorFonatel.Controles.inputFileCargarPlantilla)[0].files[0]);
            let registroIndicador = new Object();
            registroIndicador.IdSolicitudString = ObtenerValorParametroUrl("idSolicitud");
            registroIndicador.IdFormularioString = ObtenerValorParametroUrl("idFormulario");
            registroIndicador.IdIndicadorString = $(jsRegistroIndicadorFonatel.Controles.tabRgistroIndicadorActive).attr('data-Indicador');
            data.append('datos', JSON.stringify({ datos: registroIndicador }));
            data.append('cantidadFilas', $(jsRegistroIndicadorFonatel.Controles.tabActivoRegistroIndicador).find(jsRegistroIndicadorFonatel.Controles.txtCantidadRegistroIndicador).val());
            $.ajax({
                url: jsUtilidades.Variables.urlOrigen + '/RegistroIndicadorFonatel/CargarExcel',
                type: 'post',
                datatype: 'json',
                contentType: false,
                processData: false,
                data: data,
                beforeSend: function () {
                    $("#loading").fadeIn();
                },
                success: function (obj) {
                    $(jsRegistroIndicadorFonatel.Controles.inputFileCargarPlantilla).val('');
                    var respuesta = JSON.parse(obj);
                    if (respuesta.HayError == jsUtilidades.Variables.Error.NoError) {
                        jsRegistroIndicadorFonatel.Metodos.CargarValores(respuesta.objetoRespuesta);
                        //jsMensajes.Metodos.OkAlertModal("Los Datos han sido cargados")
                        //.set('onok', function (closeEvent) { window.location.href = "/Fonatel/RelacionCategoria/index" });
                    } else if (respuesta.HayError == jsUtilidades.Variables.Error.ErrorSistema) {
                        jsMensajes.Metodos.OkAlertErrorModal(respuesta.MensajeError)
                            .set('onok', function (closeEvent) { location.reload(); });
                    }


                }
            }).fail(function (obj) {
                $(jsRegistroIndicadorFonatel.Controles.inputFileCargarPlantilla).val('');
                jsMensajes.Metodos.OkAlertErrorModal("Error al cargar los Datos")
                    .set('onok', function (closeEvent) { })
                $("#loading").fadeOut();

            })
        },

        "CargarValores": function (listaDetalles) {

            //EliminarDatasource(jsRegistroIndicadorFonatel.Controles.tablaIndicadorActivo);
            if ($.fn.DataTable.isDataTable(jsRegistroIndicadorFonatel.Controles.tablaIndicadorActivo)) {
                EliminarDatasource(jsRegistroIndicadorFonatel.Controles.tablaIndicadorActivo);
            }

            jsRegistroIndicadorFonatel.Variables.ListadoDetalleRegistroIndicador = [];
            let NumeroFila = 0;
            $(jsRegistroIndicadorFonatel.Controles.tablaIndicadorRecorrido).each(function (index) {
                NumeroFila++;
                var elementotd = $(this).children("td");
                listaDetalles.DetalleRegistroIndicadorCategoriaValorFonatel.forEach(function (item) {
                    if (item.NumeroFila == NumeroFila) {
                        var elementoInput = elementotd.find("[name='name_" + item.idCategoria + "']");
                        elementoInput.val(item.Valor).change();
                    }

                });
                $(jsRegistroIndicadorFonatel.Controles.tablaIndicador_filter).addClass("hidden");
            });
            NumeroFila = 0
            $(jsRegistroIndicadorFonatel.Controles.tablaIndicadorRecorrido).each(function (index) {
                NumeroFila++;
                var elementotd = $(this).children("td");
                listaDetalles.DetalleRegistroIndicadorVariableValorFonatel.forEach(function (item) {
                    if (item.NumeroFila == NumeroFila) {
                        var elementoInput = elementotd.find("[name='name_" + item.IdVariable + "']");
                        elementoInput.val(item.Valor).change();
                    }

                });
                $(jsRegistroIndicadorFonatel.Controles.tablaIndicador_filter).addClass("hidden");
            });
            if (!jsRegistroIndicadorFonatel.Variables.ModoConsulta) {
                jsMensajes.Metodos.OkAlertModal("La Plantilla ha sido cargada")
                    .set('onok', function (closeEvent) { $("#loading").fadeOut(); });
            }

            CargarDatasourceV2(jsRegistroIndicadorFonatel.Controles.tablaIndicadorActivo);
            $("#loading").fadeOut();
        },

        "ValidarRegistroIndicadorDetalleValor": function () {
            $("#loading").fadeIn();
            jsRegistroIndicadorFonatel.Metodos.CrearRegistroIndicador();
            let detalleIndicadorValor = jsRegistroIndicadorFonatel.Variables.ListadoDetalleRegistroIndicador;
            if (detalleIndicadorValor.length > 0) {
                $.ajax({
                    url: '/RegistroIndicadorFonatel/ValidarRegistroIndicadorDetalleValor',
                    type: 'post',
                    contentType: 'application/json;charset=UTF-8',
                    dataType: 'json',
                    data: JSON.stringify({ ListaDetalleIndicadorValor: detalleIndicadorValor }),
                    success: function (obj) {
                        if (obj.HayError == jsUtilidades.Variables.Error.ErrorSistema) {
                            jsMensajes.Metodos.OkAlertErrorModal()
                                .set('onok', function (closeEvent) { location.reload(); });
                        }
                        else {
                            jsMensajes.Metodos.OkAlertModal("Los Datos han sido guardados")
                                .set('onok', function (closeEvent) { $("#loading").fadeOut(); });
                        }
                    },
                    error: function (obj) {
                        if (obj.HayError == jsUtilidades.Variables.Error.ErrorSistema) {
                            jsMensajes.Metodos.OkAlertErrorModal()
                                .set('onok', function (closeEvent) { location.reload(); });
                        }
                        else {
                            jsMensajes.Metodos.OkAlertErrorModal()
                                .set('onok', function (closeEvent) { })
                        }
                    },
                    async: false
                });
            } else {
                jsMensajes.Metodos.OkAlertErrorModal("No ha completado la ninguna información")
                    .set('onok', function (closeEvent) { $("#loading").fadeOut(); });
            }

        },

        "ValidarDetalle": function () {

            var valor = "";
            $(jsRegistroIndicadorFonatel.Controles.tablaIndicadorRecorrido).each(function (index) {
                $(this).children("td").each(function (td) {

                    if ($(this).children("input").length != 0) {
                        var input = $(this).children("input");
                        valor = input.val();
                    }
                    else if ($(this).children(".select2-wrapper").length != 0) {
                        var select = $(this).children(".select2-wrapper");
                        valor = select.children(".listasDesplegables").val();
                    }
                    //else if ($(this).children(".VariableDato").length != 0) {
                    //    var etiqueta = $(this).children(".VariableDato");
                    //    registroIndicador.IdCategoria = $(etiqueta).attr("name").replace("name_", "");
                    //    registroIndicador.Valor = $(etiqueta).text();
                    //}
                    if (valor.length == 0) {
                        return false;
                    }
                });
            });
            return true;
        },

        "VerificarCargado": function () {
            var cantIndicadores = $(jsRegistroIndicadorFonatel.Controles.tabRgistroIndicador).length;
            var cantVerificados = $(jsRegistroIndicadorFonatel.Controles.tabRgistroIndicadorVerificado).length;

            if (cantIndicadores == cantVerificados) {
                return true;
            } else {
                return false;
            }
        },
    },
    "Consultas": {

        "InsertarRegistroIndicadorDetalleValor": function () {
            $("#loading").fadeIn();
            jsRegistroIndicadorFonatel.Metodos.CrearRegistroIndicadorMultiple();
            let detalleIndicadorValor = jsRegistroIndicadorFonatel.Variables.ListadoDetalleRegistroIndicador;
            if (detalleIndicadorValor.DetalleRegistroIndicadorCategoriaValorFonatel.length > 0 || detalleIndicadorValor.DetalleRegistroIndicadorVariableValorFonatel.length > 0) {
                $.ajax({
                    url: '/RegistroIndicadorFonatel/InsertarRegistroIndicadorVariable',
                    type: 'post',
                    contentType: 'application/json;charset=UTF-8',
                    dataType: 'json',
                    data: JSON.stringify({ ListaDetalleIndicadorValor: detalleIndicadorValor }),
                    success: function (obj) {
                        if (obj.HayError == jsUtilidades.Variables.Error.ErrorSistema) {
                            jsMensajes.Metodos.OkAlertErrorModal()
                                .set('onok', function (closeEvent) { location.reload(); });
                        }
                        else {
                            CargarDatasourceV2("div.tab-pane .data-table-indicador.revisado");
                            jsMensajes.Metodos.OkAlertModal("Los Datos han sido guardados")
                                .set('onok', function (closeEvent) { });
                        }
                    },
                    error: function (obj) {
                        if (obj.HayError == jsUtilidades.Variables.Error.ErrorSistema) {
                            jsMensajes.Metodos.OkAlertErrorModal()
                                .set('onok', function (closeEvent) { location.reload(); });
                        }
                        else {
                            jsMensajes.Metodos.OkAlertErrorModal()
                                .set('onok', function (closeEvent) { })
                        }
                    },
                    async: false
                }).always(function () {
                    $("#loading").fadeOut();
                });
            } else {
                jsMensajes.Metodos.OkAlertErrorModal("No ha completado la ninguna información")
                    .set('onok', function (closeEvent) { $("#loading").fadeOut(); });
            }

        },

        "ActualizarDetalleRegistroIndicadorFonatel": function () {
            $("#loading").fadeIn();
            var listaActDetalleRegistroIndicador = [];
            var cantIndicadores = parseInt($(jsRegistroIndicadorFonatel.Controles.txtcantidadIndicadores).val());
            for (var i = 1; i <= cantIndicadores; i++) {
                let obj = new Object();
                obj.IdSolicitudString = ObtenerValorParametroUrl("idSolicitud");
                obj.IdFormularioString = ObtenerValorParametroUrl("idFormulario");
                obj.IdIndicadorString = $(jsRegistroIndicadorFonatel.Controles.tabRegistroIndicador(i)).attr('data-Indicador');
                obj.CantidadFilas = $(jsRegistroIndicadorFonatel.Controles.tabMenu(i)).find(jsRegistroIndicadorFonatel.Controles.txtCantidadRegistroIndicador).val();
                obj.NotasInformante = $(jsRegistroIndicadorFonatel.Controles.tabMenu(i)).find(jsRegistroIndicadorFonatel.Controles.txtNotasInformante).val();
                if (obj.CantidadFilas > 0) {
                    listaActDetalleRegistroIndicador.push(obj);
                }
            }

            $.ajax({
                url: '/RegistroIndicadorFonatel/ActualizarDetalleRegistroIndicadorFonatel',
                type: 'post',
                contentType: 'application/json;charset=UTF-8',
                dataType: 'json',
                data: JSON.stringify({ listaActDetalleRegistroIndicador: listaActDetalleRegistroIndicador }),
                success: function (obj) {
                    if (obj.HayError == jsUtilidades.Variables.Error.ErrorSistema) {
                        jsMensajes.Metodos.OkAlertErrorModal()
                            .set('onok', function (closeEvent) { location.reload(); });
                    }
                    else {
                        jsRegistroIndicadorFonatel.Consultas.InsertarRegistroIndicadorDetalleValor();
                    }
                },
                error: function (obj) {
                    if (obj.HayError == jsUtilidades.Variables.Error.ErrorSistema) {
                        jsMensajes.Metodos.OkAlertErrorModal()
                            .set('onok', function (closeEvent) { location.reload(); });
                    }
                    else {
                        jsMensajes.Metodos.OkAlertErrorModal()
                            .set('onok', function (closeEvent) { })
                    }
                },
                //async: false
            });
        },

        "ConsultaRegistroIndicadorDetalle": function (fadeOut = false) {
            $("#loading").fadeIn();

            let detalleIndicadorFonatel = new Object();
            detalleIndicadorFonatel.IdSolicitudString = ObtenerValorParametroUrl("idSolicitud");
            detalleIndicadorFonatel.IdFormularioString = ObtenerValorParametroUrl("idFormulario");
            detalleIndicadorFonatel.IdIndicadorString = $(jsRegistroIndicadorFonatel.Controles.tabRgistroIndicadorActive).attr('data-Indicador');
            detalleIndicadorFonatel.CantidadFilas = $(jsRegistroIndicadorFonatel.Controles.tabActivoRegistroIndicador).find(jsRegistroIndicadorFonatel.Controles.txtCantidadRegistroIndicador).val();
            execAjaxCall("/RegistroIndicadorFonatel/ConsultaRegistroIndicadorDetalle", "POST", detalleIndicadorFonatel = detalleIndicadorFonatel)
                .then((obj) => {
                    $(jsRegistroIndicadorFonatel.Controles.tablaIndicador).removeClass("hidden");
                    jsRegistroIndicadorFonatel.Variables.detalleIndicadorFonatel = obj.objetoRespuesta[0];
                    if (jsRegistroIndicadorFonatel.Variables.detalleIndicadorFonatel.DetalleRegistroIndicadorVariableFonatel.length > 0) {

                        if ($.fn.DataTable.isDataTable(jsRegistroIndicadorFonatel.Controles.tablaIndicadorActivo)) {
                            EliminarDatasource(jsRegistroIndicadorFonatel.Controles.tablaIndicadorActivo);
                        }

                        jsRegistroIndicadorFonatel.Metodos.CargarColumnasTabla();
                        jsRegistroIndicadorFonatel.Metodos.CargarFilasTabla(detalleIndicadorFonatel.CantidadFilas);
                    } else {
                        jsMensajes.Metodos.OkAlertErrorModal("No se posee datos a cargar")
                            .set('onok', function (closeEvent) { });
                    }

                }).catch((obj) => {
                    if (obj.HayError == jsUtilidades.Variables.Error.ErrorSistema) {
                        jsMensajes.Metodos.OkAlertErrorModal()
                            .set('onok', function (closeEvent) { location.reload(); });
                    }
                    else {
                        jsMensajes.Metodos.OkAlertErrorModal()
                            .set('onok', function (closeEvent) { })
                    }
                }).finally(() => {
                    //CargarDatasourceV2(jsRegistroIndicadorFonatel.Controles.tablaIndicador);
                    if (jsRegistroIndicadorFonatel.Variables.ModoConsulta) {
                        jsRegistroIndicadorFonatel.Consultas.ConsultaDetalleRegistroIndicadorValoresFonatel();
                    }
                    $(jsRegistroIndicadorFonatel.Controles.tablaIndicador_filter).addClass("hidden");

                    CargarDatasourceV2(jsRegistroIndicadorFonatel.Controles.tablaIndicadorActivo);

                    if (fadeOut) {
                        $("#loading").fadeOut();
                    }
                });
        },

        "ConsultaDetalleRegistroIndicadorValoresFonatel": function () {
            jsRegistroIndicadorFonatel.Metodos.CargarValores(jsRegistroIndicadorFonatel.Variables.detalleIndicadorFonatel);
        },

        "CargadoTotalRegistroIndicador": function (GuardadoTotal) {

            $("#loading").fadeIn();


            let listaActDetalleRegistroIndicador = [];
            let cantIndicadores = parseInt($(jsRegistroIndicadorFonatel.Controles.txtcantidadIndicadores).val());

            for (var i = 1; i <= cantIndicadores; i++) {
                let obj = new Object();

                obj.IdSolicitudString = ObtenerValorParametroUrl("idSolicitud");
                obj.IdFormularioString = ObtenerValorParametroUrl("idFormulario");
                obj.IdIndicadorString = $(jsRegistroIndicadorFonatel.Controles.tabRegistroIndicador(i)).attr('data-Indicador');
                obj.NotasEncargado = $(jsRegistroIndicadorFonatel.Controles.tabMenu(i)).find(jsRegistroIndicadorFonatel.Controles.txtNotasEncargado).val();


                let CantidadFilas = $(jsRegistroIndicadorFonatel.Controles.tabMenu(i)).find(jsRegistroIndicadorFonatel.Controles.txtCantidadRegistroIndicador).val();

                obj.CantidadFilas = CantidadFilas;

                if (CantidadFilas > 0) {
                    listaActDetalleRegistroIndicador.push(obj);
                }
            }

            execAjaxCall("/RegistroIndicadorFonatel/CargaTotalRegistroIndicador", "POST", { lista: listaActDetalleRegistroIndicador })
                .then((obj) => {
                    if (obj.HayError == jsUtilidades.Variables.Error.ErrorSistema) {
                        jsMensajes.Metodos.OkAlertErrorModal()
                            .set('onok', function (closeEvent) { location.reload(); });
                    }
                    else {
                        jsRegistroIndicadorFonatel.Consultas.InsertarRegistroIndicadorDetalleValor();
                        if (GuardadoTotal) {
                            jsMensajes.Metodos.OkAlertModal("El Formulario Web ha sido cargado")
                                .set('onok', function (closeEvent) { window.location.href = "/RegistroIndicador/Index"; });
                        }
                    }

                }).catch((obj) => {
                    if (obj.HayError == jsUtilidades.Variables.Error.ErrorSistema) {
                        jsMensajes.Metodos.OkAlertErrorModal()
                            .set('onok', function (closeEvent) { location.reload(); });
                    }
                    else {
                        jsMensajes.Metodos.OkAlertErrorModal()
                            .set('onok', function (closeEvent) { })
                    }
                })
        },

    }

}


$(document).on("click", jsRegistroIndicadorFonatel.Controles.btnCancelarRegistroIndicador, function (e) {
    e.preventDefault();
    jsMensajes.Metodos.ConfirmYesOrNoModal("¿Desea cancelar la acción?", jsMensajes.Variables.actionType.cancelar)
        .set('onok', function (closeEvent) {
            window.location.href = "/Fonatel/RegistroIndicadorFonatel/Index";
        });
});

$(document).on("click", jsRegistroIndicadorFonatel.Controles.btnGuardarRegistroIndicador, function (e) {
    e.preventDefault();
    jsMensajes.Metodos.ConfirmYesOrNoModal("Existen campos vacíos. ¿Desea realizar un guardado parcial para el Formulario?", jsMensajes.Variables.actionType.agregar)
        .set('onok', function (closeEvent) {
          
            var cantIndicadores = parseInt($(jsRegistroIndicadorFonatel.Controles.txtcantidadIndicadores).val());
            for (var i = 1; i <= cantIndicadores; i++) {
                let tabla = $(jsRegistroIndicadorFonatel.Controles.tabMenu(i)).find(".data-table-indicador");
                if ($.fn.DataTable.isDataTable(tabla)) {
                    tabla.DataTable().destroy();
                }
            }

            jsRegistroIndicadorFonatel.Consultas.ActualizarDetalleRegistroIndicadorFonatel();
        });


});

$(document).on("click", jsRegistroIndicadorFonatel.Controles.btnCargaRegistroIndicador, function (e) {
    e.preventDefault();

    jsMensajes.Metodos.ConfirmYesOrNoModal("¿Desea realizar la carga del Formulario Web?", jsMensajes.Variables.actionType.agregar)
        .set('onok', function (closeEvent) {
            let GuardadoTotal = true;
            jsRegistroIndicadorFonatel.Consultas.CargadoTotalRegistroIndicador(GuardadoTotal);

        });
});

$(document).on("click", jsRegistroIndicadorFonatel.Controles.btnDescargarPlantillaRegistro, function () {

    jsMensajes.Metodos.ConfirmYesOrNoModal("¿Desea descargar el Formulario?", null, "Descargar Registro")
        .set('onok', function (closeEvent) {

            var listaParametros = [];
            listaParametros.push(ObtenerValorParametroUrl("idSolicitud"));
            listaParametros.push(ObtenerValorParametroUrl("idFormulario"));
            listaParametros.push($(jsRegistroIndicadorFonatel.Controles.tabRgistroIndicadorActive).attr('data-Indicador'));
            listaParametros.push($(jsRegistroIndicadorFonatel.Controles.tabActivoRegistroIndicador).find(jsRegistroIndicadorFonatel.Controles.txtCantidadRegistroIndicador).val());

            window.open(jsUtilidades.Variables.urlOrigen + "/RegistroIndicadorFonatel/DescargarExcel?listaParametros=" + listaParametros);
            jsRegistroIndicadorFonatel.Metodos.DescargarExcel();
        });
});

$(document).on("click", jsRegistroIndicadorFonatel.Controles.btnCargarPlantillaRegistro, function () {
    $(jsRegistroIndicadorFonatel.Controles.inputFileCargarPlantilla).click();
});

$(document).on("change", jsRegistroIndicadorFonatel.Controles.inputFileCargarPlantilla, function (e) {
    jsRegistroIndicadorFonatel.Metodos.ImportarExcel();
});

$(document).on("click", jsRegistroIndicadorFonatel.Controles.IndicadorCorrecto, function () {

    jsRegistroIndicadorFonatel.Variables.Validacion = false;
});

$(document).on('draw.dt', jsRegistroIndicadorFonatel.Controles.tablaIndicador, function (e) {
    setSelect2();
});

$('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
    var target = $(e.target).attr("href") // activated tab
    setSelect2();
});

$(document).on("click", jsRegistroIndicadorFonatel.Controles.btnValidar, function () {
    if (jsRegistroIndicadorFonatel.Metodos.ValidarDetalle()) {
        if (jsRegistroIndicadorFonatel.Variables.Validacion == false) {
            $(jsRegistroIndicadorFonatel.Controles.tabRgistroIndicadoractivo).addClass("verificado");
            jsMensajes.Metodos.OkAlertModal("Validación Exitosa <br><br> La información ingresada cumple con los criterios de validación.");
            if (jsRegistroIndicadorFonatel.Metodos.VerificarCargado()) {
                $(jsRegistroIndicadorFonatel.Controles.btnCargaRegistroIndicador).prop("disabled", false);
            }
        } else {
            jsMensajes.Metodos.OkAlertErrorModal("Fórmula de cambio mensual <br><br> La información ingresada no es congruente con el registro del mes anterior");
        }
    } else {
        jsMensajes.Metodos.OkAlertErrorModal("");
    }


});

/*
 Evento para cada input Cantidad de Registros de cada tab o indicador.
 */
$(document).on("keypress", jsRegistroIndicadorFonatel.Controles.txtCantidadRegistroIndicador, function () {


    if (event.keyCode == 13) {
        var tabla = $(jsRegistroIndicadorFonatel.Controles.tablaIndicador);
        tabla.addClass("revisado");
        jsRegistroIndicadorFonatel.Consultas.ConsultaRegistroIndicadorDetalle(true);
    }
});

function getTabActivoRegistroIndicador() {
    return $(jsRegistroIndicadorFonatel.Controles.tabActivoRegistroIndicador).attr("id");
}

function setSelect2() {
    $('div.tab-pane.active .listasDesplegables').select2({
        placeholder: "Seleccione",
        width: 'resolve'
    });
}

$(document).on("click", jsRegistroIndicadorFonatel.Controles.tabRegistroIndicador, function () {

    //jsRegistroIndicadorFonatel.Variables.ModoConsulta = false;

    var cantidadFilas = parseInt($(jsRegistroIndicadorFonatel.Controles.tabActivoRegistroIndicador).find(jsRegistroIndicadorFonatel.Controles.txtCantidadRegistroIndicador).val());
    var tabla = $(jsRegistroIndicadorFonatel.Controles.tablaIndicador);
    var ind = tabla.hasClass("revisado");
    if (cantidadFilas > 0 && !ind) {
        tabla.addClass("revisado");
        jsRegistroIndicadorFonatel.Variables.ModoConsulta = true;
        jsRegistroIndicadorFonatel.Consultas.ConsultaRegistroIndicadorDetalle();
    } else {
        jsRegistroIndicadorFonatel.Variables.ModoConsulta = false;
    }

});

$(document).ready(function () {



    $(jsRegistroIndicadorFonatel.Controles.tabRegistroIndicador(1)).click();
});

﻿using System;
using System.Collections.Generic;
using System.Linq;
using GB.SIMEF.DAL;
using GB.SIMEF.Entities;
using GB.SIMEF.Resources;
using Newtonsoft.Json;
using static GB.SIMEF.Resources.Constantes;

namespace GB.SIMEF.BL
{
    public class DetalleReglaValidacionBL : IMetodos<DetalleReglaValidacion>
    {
        private readonly DetalleReglasValicionDAL clsDatos;
        private readonly DetalleIndicadorVariablesDAL clsDatosIndicadorVariableDAL;
        private readonly ReglaValidacionAtributosValidosDAL clsReglaValidacionAtributosValidosDAL;
        private readonly ReglaComparacionConstanteDAL clsReglaComparacionConstanteDAL;
        private readonly ReglaSecuencialDAL clsReglaSecuencialDAL;
        private readonly ReglaIndicadorSalidaDAL clsReglaIndicadorSalidaDAL;
        private readonly ReglaIndicadorEntradaDAL clsReglaIndicadorEntradaDAL;
        private readonly ReglaIndicadorEntradaSalidaDAL clsReglaIndicadorEntradaSalidaDAL;

        private RespuestaConsulta<List<DetalleReglaValidacion>> ResultadoConsulta;
        string modulo = Etiquetas.ReglasValidacion;
        string user;

        public DetalleReglaValidacionBL(string modulo, string user)
        {
            this.modulo = modulo;
            this.user = user;
            this.clsDatos = new DetalleReglasValicionDAL();
            this.clsDatosIndicadorVariableDAL = new DetalleIndicadorVariablesDAL();
            this.clsReglaValidacionAtributosValidosDAL = new ReglaValidacionAtributosValidosDAL();
            this.clsReglaComparacionConstanteDAL = new ReglaComparacionConstanteDAL();
            this.clsReglaSecuencialDAL = new ReglaSecuencialDAL();
            this.clsReglaIndicadorSalidaDAL = new ReglaIndicadorSalidaDAL();
            this.clsReglaIndicadorEntradaDAL = new ReglaIndicadorEntradaDAL();
            this.clsReglaIndicadorEntradaSalidaDAL = new ReglaIndicadorEntradaSalidaDAL();
            ResultadoConsulta = new RespuestaConsulta<List<DetalleReglaValidacion>>();
        }

        private string SerializarObjetoBitacora(DetalleReglaValidacion objRegla)
        {
            return JsonConvert.SerializeObject(objRegla, new JsonSerializerSettings
            { ContractResolver = new JsonIgnoreResolver(objRegla.NoSerialize) });
        }

        public RespuestaConsulta<List<DetalleReglaValidacion>> ActualizarElemento(DetalleReglaValidacion objeto)
        {
            try
            {
                if (!string.IsNullOrEmpty(objeto.id))
                {
                    DesencriptarObjReglasValidacion(objeto);

                    ResultadoConsulta.Clase = modulo;
                    ResultadoConsulta.Accion = (int)Constantes.Accion.Editar;
                    ResultadoConsulta.Usuario = user;
                    int IdReglasValidacionTipo = objeto.IdReglasValidacionTipo;
                    int IdRegla = objeto.IdRegla;
                    int IdOperador = objeto.IdOperador;
                    var resul = clsDatos.ObtenerDatos(new DetalleReglaValidacion());
                    //string valorAnterior = SerializarObjetoBitacora(resul.Where(x => x.IdReglasValidacionTipo == objeto.IdReglasValidacionTipo).Single());
                    objeto = resul.Where(x => x.IdRegla == objeto.IdRegla).Single();
                    objeto.IdOperador = IdOperador;
                    ResultadoConsulta.objetoRespuesta = clsDatos.ActualizarDatos(objeto);
                    var nuevoValor = clsDatos.ObtenerDatos(objeto).Single();
                    string jsonNuevoValor = SerializarObjetoBitacora(nuevoValor);

                    ResultadoConsulta.CantidadRegistros = resul.Count();
                    //clsDatos.RegistrarBitacora(ResultadoConsulta.Accion,
                    //       ResultadoConsulta.Usuario,
                    //       ResultadoConsulta.Clase, nuevovalor.Codigo, jsonNuevoValor, valorAnterior);

                }
            }
            catch (Exception ex)
            {

                if (ResultadoConsulta.HayError != (int)Constantes.Error.ErrorControlado)
                {
                 
                    ResultadoConsulta.HayError = (int)Constantes.Error.ErrorSistema;
                }


                ResultadoConsulta.MensajeError = ex.Message;
            }
            return ResultadoConsulta;
        }

        public RespuestaConsulta<List<DetalleReglaValidacion>> CambioEstado(DetalleReglaValidacion objeto)
        {
            throw new NotImplementedException();
        }

        public RespuestaConsulta<List<DetalleReglaValidacion>> ClonarDatos(DetalleReglaValidacion objeto)
        {
            throw new NotImplementedException();
        }

        public RespuestaConsulta<List<DetalleReglaValidacion>> EliminarElemento(DetalleReglaValidacion objeto)
        {
            try
            {
                if (!String.IsNullOrEmpty(objeto.id) || !String.IsNullOrEmpty(objeto.idReglasValidacionTipoString))
                {
                    DesencriptarObjReglasValidacion(objeto);
                }
                ResultadoConsulta.Clase = modulo;
                ResultadoConsulta.Usuario = user;
                var resul = clsDatos.ObtenerDatos(objeto).ToList();

                if (resul.Count() == 0)
                {
                    throw new Exception(Errores.NoRegistrosActualizar);
                }
                else
                {
                    objeto = resul.Single();
                    objeto.Estado = false;
                    ResultadoConsulta.Accion = (int)Constantes.Accion.Eliminar;
                    resul = clsDatos.ActualizarDatos(objeto);
                    ResultadoConsulta.objetoRespuesta = resul;
                    ResultadoConsulta.CantidadRegistros = resul.Count();

                    //clsDatos.RegistrarBitacora(ResultadoConsulta.Accion,
                    //       ResultadoConsulta.Usuario,
                    //       ResultadoConsulta.Clase, objeto.);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == Errores.NoRegistrosActualizar)
                {
                    ResultadoConsulta.HayError = (int)Constantes.Error.ErrorControlado;
                }
                else
                {
                    ResultadoConsulta.HayError = (int)Constantes.Error.ErrorSistema;
                }


                ResultadoConsulta.MensajeError = ex.Message;
            }
            return ResultadoConsulta;
        }

        public RespuestaConsulta<List<DetalleReglaValidacion>> InsertarDatos(DetalleReglaValidacion objeto)
        {
            try
            {
                ResultadoConsulta.Clase = modulo;
                ResultadoConsulta.Accion = (int)Constantes.Accion.Insertar;
                ResultadoConsulta.Usuario = user;
                objeto.IdOperador = objeto.IdOperador;
                objeto.IdRegla = objeto.IdRegla;
                objeto.Estado = true;
                //List<DetalleIndicadorVariables> listaDetallesIndicadorVariable = clsDatosIndicadorVariable.ObtenerDatos(new DetalleIndicadorVariables(){idDetalleIndicador = objeto.idIndicadorVariable});
                //bjeto.idIndicadorString = listaDetallesIndicadorVariable[0].idIndicadorString;
                DesencriptarObjReglasValidacion(objeto);
                var resul = clsDatos.ActualizarDatos(objeto);
                objeto.IdReglasValidacionTipo = resul.Single().IdReglasValidacionTipo;
                AgregarTipoDetalleReglaValidacion(objeto);
                ResultadoConsulta.objetoRespuesta = resul;
                ResultadoConsulta.CantidadRegistros = resul.Count();

            }
            catch (Exception ex)
            {
                if (ResultadoConsulta.HayError != (int)Constantes.Error.ErrorControlado)
                {
                    ResultadoConsulta.HayError = (int)Constantes.Error.ErrorSistema;
                }

                ResultadoConsulta.MensajeError = ex.Message;
            }
            return ResultadoConsulta;
        }

        public RespuestaConsulta<List<DetalleReglaValidacion>> ObtenerDatos(DetalleReglaValidacion objeto)
        {
            try
            {
                ResultadoConsulta.Clase = modulo;
                ResultadoConsulta.Accion = (int)Accion.Consultar;

                DesencriptarObjReglasValidacion(objeto);

                var resul = clsDatos.ObtenerDatos(objeto);
                ResultadoConsulta.objetoRespuesta = resul;
                ResultadoConsulta.CantidadRegistros = resul.Count();
            }
            catch (Exception ex)
            {
                ResultadoConsulta.HayError = (int)Error.ErrorSistema;
                ResultadoConsulta.MensajeError = ex.Message;

            }
            return ResultadoConsulta;
        }

        public RespuestaConsulta<List<string>> ValidarDatos(DetalleReglaValidacion objeto)
        {
            RespuestaConsulta<List<string>> resultado = new RespuestaConsulta<List<string>>();
            try
            {
                resultado.Clase = modulo;
                resultado.Accion = (int)Accion.Consultar;
                var resul = clsDatos.ValidarDatos(objeto);
                resultado.objetoRespuesta = resul;
                resultado.CantidadRegistros = resul.Count();
            }
            catch (Exception ex)
            {
                resultado.HayError = (int)Error.ErrorSistema;
                resultado.MensajeError = ex.Message;

            }
            return resultado;
        }

        RespuestaConsulta<List<DetalleReglaValidacion>> IMetodos<DetalleReglaValidacion>.ValidarDatos(DetalleReglaValidacion objeto)
        {
            throw new NotImplementedException();
        }

        private void AgregarTipoDetalleReglaValidacion(DetalleReglaValidacion objeto)
        {
            switch (objeto.IdTipo)
            {
                case (int)Constantes.TipoReglasDetalle.FormulaContraAtributosValidos:
                    objeto.reglaAtributosValidos.IdTipoReglaValidacion = objeto.IdReglasValidacionTipo;
                    clsReglaValidacionAtributosValidosDAL.ActualizarDatos(objeto.reglaAtributosValidos);
                    break;

                case (int)Constantes.TipoReglasDetalle.FormulaContraConstante:
                    objeto.reglaComparacionConstante.IdDetalleReglaValidacion = objeto.IdReglasValidacionTipo;
                    objeto.reglaComparacionConstante.idvariable = 0;
                    clsReglaComparacionConstanteDAL.ActualizarDatos(objeto.reglaComparacionConstante);
                    break;

                case (int)Constantes.TipoReglasDetalle.FormulaActualizacionSecuencial:
                    objeto.reglaSecuencial.IdDetalleReglaValidacion = objeto.IdReglasValidacionTipo;
                    objeto.reglaSecuencial.idvariable = 0;
                    clsReglaSecuencialDAL.ActualizarDatos(objeto.reglaSecuencial);
                    break;
                   
                case (int)Constantes.TipoReglasDetalle.FormulaContraOtroIndicadorSalida:
                    objeto.reglaIndicadorSalida.IdDetalleReglaValidacion = objeto.IdReglasValidacionTipo;
                    clsReglaIndicadorSalidaDAL.ActualizarDatos(objeto.reglaIndicadorSalida);
                    break;
                    
                case (int)Constantes.TipoReglasDetalle.FormulaContraOtroIndicadorEntrada:
                    objeto.reglaIndicadorEntrada.IdDetalleReglaValidacion = objeto.IdReglasValidacionTipo;
                    clsReglaIndicadorEntradaDAL.ActualizarDatos(objeto.reglaIndicadorEntrada);
                    break;
                    
                case (int)Constantes.TipoReglasDetalle.FormulaContraOtroIndicadorEntradaSalida:
                    objeto.reglaIndicadorEntradaSalida.IdDetalleReglaValidacion = objeto.IdReglasValidacionTipo;
                    clsReglaIndicadorEntradaSalidaDAL.ActualizarDatos(objeto.reglaIndicadorEntradaSalida);
                    break;

                default:
                    break;
            }
        }

        private void DesencriptarObjReglasValidacion(DetalleReglaValidacion detalleReglaValidacion)
        {
            if (!string.IsNullOrEmpty(detalleReglaValidacion.id))
            {
                int.TryParse(Utilidades.Desencriptar(detalleReglaValidacion.id), out int temp);
                detalleReglaValidacion.IdRegla = temp;
            }
            if (!string.IsNullOrEmpty(detalleReglaValidacion.idReglasValidacionTipoString))
            {
                int.TryParse(Utilidades.Desencriptar(detalleReglaValidacion.idReglasValidacionTipoString), out int temp);
                detalleReglaValidacion.IdReglasValidacionTipo = temp;
            }

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GB.SIMEF.DAL;
using GB.SIMEF.Entities;
using GB.SIMEF.Resources;
using Newtonsoft.Json;
using static GB.SIMEF.Resources.Constantes;

namespace GB.SIMEF.BL
{
    public class FuentesRegistroDestinatariosBL : IMetodos<DetalleFuenteRegistro>
    {
        private readonly FuentesRegistroDestinatarioDAL clsDatos;
        private readonly FuentesRegistroDAL clsfuente;

        private RespuestaConsulta<List<DetalleFuenteRegistro>> ResultadoConsulta;
        string modulo = string.Empty;
        string user = string.Empty;
        public FuentesRegistroDestinatariosBL(string modulo, string user )
        {
            this.clsDatos = new FuentesRegistroDestinatarioDAL();
            this.ResultadoConsulta = new RespuestaConsulta<List<DetalleFuenteRegistro>>();
            this.clsfuente = new FuentesRegistroDAL();
            this.modulo = modulo;
            this.user = user;
        }

        public RespuestaConsulta<List<DetalleFuenteRegistro>> ActualizarElemento(DetalleFuenteRegistro objeto)
        {

            try
            {
                if (!string.IsNullOrEmpty(objeto.FuenteId))
                {
                    int temp = 0;
                    int.TryParse(Utilidades.Desencriptar(objeto.FuenteId), out temp);
                    objeto.idFuenteRegistro = temp;
                }
                ResultadoConsulta.Clase = modulo;
                ResultadoConsulta.Usuario = user;
                ResultadoConsulta.Accion = (int)Accion.Editar;
                objeto= ValidarDatosDetalleFuentes(objeto);
                string jsonAnterior = clsDatos.ObtenerDatos(objeto).FirstOrDefault().ToString();
                ResultadoConsulta.objetoRespuesta = clsDatos.ActualizarDatos(objeto);
                ResultadoConsulta.CantidadRegistros = ResultadoConsulta.objetoRespuesta.Count();
                string jsonActual = ResultadoConsulta.objetoRespuesta.Single().ToString();
                clsDatos.RegistrarBitacora(ResultadoConsulta.Accion,
                             ResultadoConsulta.Usuario,
                             ResultadoConsulta.Clase, 
                             ResultadoConsulta.objetoRespuesta.Single().NombreFuente,
                             jsonActual,jsonAnterior,"");
                
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

        public RespuestaConsulta<List<DetalleFuenteRegistro>> CambioEstado(DetalleFuenteRegistro objeto)
        {
            throw new NotImplementedException();
        }

        public RespuestaConsulta<List<DetalleFuenteRegistro>> ClonarDatos(DetalleFuenteRegistro objeto)
        {
            throw new NotImplementedException();
        }

        public RespuestaConsulta<List<DetalleFuenteRegistro>> EliminarElemento(DetalleFuenteRegistro objeto)
        {
            try
            {
                objeto.Estado = false;
                ResultadoConsulta.Clase = modulo;
                ResultadoConsulta.Accion = (int)Accion.Eliminar;
                ResultadoConsulta.Usuario = user;
                if (!String.IsNullOrEmpty(objeto.FuenteId))
                {
                    objeto.FuenteId = Utilidades.Desencriptar(objeto.FuenteId);
                    int temp;
                    if (int.TryParse(objeto.FuenteId, out temp))
                    {
                        objeto.idFuenteRegistro = temp;
                    }
                }
                var fuente = clsfuente.ObtenerDatos(new FuenteRegistro() { IdFuenteRegistro = objeto.idFuenteRegistro }).SingleOrDefault();

                var consultardatos = fuente.DetalleFuenteRegistro.Where(x=>x.idDetalleFuenteRegistro==objeto.idDetalleFuenteRegistro).ToList();
                if (consultardatos.Count()==0)
                {
                    ResultadoConsulta.HayError = (int)Constantes.Error.ErrorControlado;
                    throw new Exception(Errores.NoRegistrosActualizar);
                }
                else
                {
                    var resul = clsDatos.ActualizarDatos(objeto);
                    ResultadoConsulta.objetoRespuesta = resul;
                    ResultadoConsulta.CantidadRegistros = resul.Count();


                    clsDatos.RegistrarBitacora(ResultadoConsulta.Accion,
                              ResultadoConsulta.Usuario,
                              ResultadoConsulta.Clase, fuente.Fuente);
                }                
            }
            catch (Exception ex)
            {
                if (ResultadoConsulta.HayError!= (int)Constantes.Error.ErrorControlado)
                {
                 
                    ResultadoConsulta.HayError = (int)Constantes.Error.ErrorSistema;
                }


                ResultadoConsulta.MensajeError = ex.Message;
            }
            return ResultadoConsulta;
        }

        private DetalleFuenteRegistro ValidarDatosDetalleFuentes(DetalleFuenteRegistro objeto, bool Agregar=false)
        {
            objeto.CorreoElectronico = objeto.CorreoElectronico.Trim().ToUpper();
            objeto.NombreDestinatario = objeto.NombreDestinatario.Trim().ToUpper();
            var fuente = clsfuente.ObtenerDatos(new FuenteRegistro() { IdFuenteRegistro = objeto.idFuenteRegistro }).SingleOrDefault();

            var consultardatos = fuente.DetalleFuenteRegistro;
            if (objeto==null && !Agregar)
            {
                ResultadoConsulta.HayError = (int)Constantes.Error.ErrorControlado;
                throw new Exception(Errores.NoRegistrosActualizar);
            }
            else if (!Utilidades.ValidarEmail(objeto.CorreoElectronico))
            {
                ResultadoConsulta.HayError = (int)Constantes.Error.ErrorControlado;
                throw new Exception(string.Format(Errores.CampoConFormatoInvalido, "Correo electrónico"));
            }
            else if (consultardatos.Where(x => x.CorreoElectronico.ToUpper() == objeto.CorreoElectronico).Count() > 0 && Agregar)
            {
                ResultadoConsulta.HayError = (int)Constantes.Error.ErrorControlado;
                throw new Exception(Errores.CorreoRegistrado);
            }
            else if (consultardatos.Count() >= fuente.CantidadDestinatario && Agregar)
            {
                ResultadoConsulta.HayError = (int)Constantes.Error.ErrorControlado;
                throw new Exception(Errores.CantidadRegistrosLimite);
            }
            else if (consultardatos.Where(x => x.idFuenteRegistro != objeto.idFuenteRegistro && objeto.NombreDestinatario.ToUpper() ==objeto.NombreDestinatario).Count() > 0)
            {
                ResultadoConsulta.HayError = (int)Constantes.Error.ErrorControlado;
                throw new Exception(Errores.NombreRegistrado);
            }
            objeto.Json = Agregar != true ? consultardatos
                .Where(x=>x.idDetalleFuenteRegistro==objeto.idDetalleFuenteRegistro).Single().ToString()
                 : string.Empty;
            objeto.Estado = true;
            return objeto;
        }
        public RespuestaConsulta<List<DetalleFuenteRegistro>> InsertarDatos(DetalleFuenteRegistro objeto)
        {
            try
            {
                ResultadoConsulta.Clase = modulo;
                ResultadoConsulta.Accion = (int)Accion.Crear;
                ResultadoConsulta.Usuario = user;
                objeto.Estado = true;
                if (!string.IsNullOrEmpty(objeto.FuenteId))
                {
                    int temp = 0;
                    int.TryParse(Utilidades.Desencriptar(objeto.FuenteId), out temp);
                    objeto.idFuenteRegistro = temp;
                }
                objeto = ValidarDatosDetalleFuentes(objeto, true);
                ResultadoConsulta.objetoRespuesta = clsDatos.ActualizarDatos(objeto); 
                ResultadoConsulta.CantidadRegistros = ResultadoConsulta.objetoRespuesta.Count();
                string jsonincial = ResultadoConsulta.objetoRespuesta.Single().ToString();
                clsDatos.RegistrarBitacora(ResultadoConsulta.Accion,
                             ResultadoConsulta.Usuario,
                             ResultadoConsulta.Clase, ResultadoConsulta.objetoRespuesta.Single().NombreFuente, "","",jsonincial);
                
            }
            catch (Exception ex)
            {
                if (ResultadoConsulta.HayError!=(int)Constantes.Error.ErrorControlado)
                {
                    ResultadoConsulta.HayError = (int)Constantes.Error.ErrorSistema;
                }
                ResultadoConsulta.MensajeError = ex.Message;
            }
            return ResultadoConsulta;
        }

        public RespuestaConsulta<List<DetalleFuenteRegistro>> ObtenerDatos(DetalleFuenteRegistro objDetalleFuentesRegistro)
        {
            try
            {
                if (!string.IsNullOrEmpty(objDetalleFuentesRegistro.FuenteId))
                {
                    int temp = 0;
                    int.TryParse(Utilidades.Desencriptar(objDetalleFuentesRegistro.FuenteId), out temp);
                    objDetalleFuentesRegistro.idFuenteRegistro = temp;
                }

                ResultadoConsulta.Clase = modulo;
                ResultadoConsulta.Accion = (int)Accion.Consultar;
                var resul = clsDatos.ObtenerDatos(objDetalleFuentesRegistro);
                ResultadoConsulta.objetoRespuesta = resul;
                ResultadoConsulta.CantidadRegistros = resul.Count();
            }
            catch (Exception ex)
            {
                ResultadoConsulta.HayError = (int)Constantes.Error.ErrorSistema;
                ResultadoConsulta.MensajeError = ex.Message;
            }
            return ResultadoConsulta;
        }



        public RespuestaConsulta<List<DetalleFuenteRegistro>> ValidarDatos(DetalleFuenteRegistro objeto)
        {
            throw new NotImplementedException();
        }
    }
}

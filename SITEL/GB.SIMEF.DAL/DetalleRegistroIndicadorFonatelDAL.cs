﻿using GB.SIMEF.Entities;
using GB.SIMEF.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.SIMEF.DAL
{
    public class DetalleRegistroIndicadorFonatelDAL : BitacoraDAL
    {
        private SITELContext db;

        #region Consultas

        /// Autor: Francisco Vindas
        /// Fecha: 03/01/2023
        /// El metodo crea una lista generica de la solicitud que puede ser utilizado en lo metodos que lo necesiten 
        /// </summary>
        /// <param name="ListaSolicitud"></param>
        /// <returns></returns>
        private List<DetalleRegistroIndicadorFonatel> CrearListado(List<DetalleRegistroIndicadorFonatel> ListaRegistroIndicador)
        {
            return ListaRegistroIndicador.Select(x => new DetalleRegistroIndicadorFonatel
            {
                idFormularioWeb = x.idFormularioWeb,
                IdIndicador = x.IdIndicador,
                IdDetalleRegistroIndicadorFonatel = x.IdDetalleRegistroIndicadorFonatel,
                NombreIndicador = x.NombreIndicador,
                NotaEncargado = x.NotaEncargado,
                NotaInformante = x.NotaInformante,
                CantidadFila = x.CantidadFila,
                CodigoIndicador = x.CodigoIndicador,
                TituloHoja = x.TituloHoja,
                IdSolicitud = x.IdSolicitud,
                DetalleRegistroIndicadorVariableFonatel = ObtenerDatoDetalleRegistroIndicadorVariable(x),
                DetalleRegistroIndicadorCategoriaFonatel = ObtenerDatoDetalleRegistroIndicadorCategoria(x),
                idFormularioWebString = Utilidades.Encriptar(x.idFormularioWeb.ToString()),
                IdIndicadorString = Utilidades.Encriptar(x.IdIndicador.ToString()),
                IdSolicitudString = Utilidades.Encriptar(x.IdSolicitud.ToString()),
                RegistroIndicadorFonatel=ObtenerRegistroIndicador(x.IdSolicitud,x.idFormularioWeb)
                
            }).ToList();
        }

        /// <summary>
        /// Detalle Registro Indicador Variable Fonatel
        /// </summary>
        /// <returns></returns>
        public List<DetalleRegistroIndicadorFonatel> ObtenerDatoDetalleRegistroIndicador(DetalleRegistroIndicadorFonatel pDetalleRegistroIndicador)
        {
            List<DetalleRegistroIndicadorFonatel> ListaRegistroIndicadorFonatel = new List<DetalleRegistroIndicadorFonatel>();

            using (db=new SITELContext())
            {
                ListaRegistroIndicadorFonatel = db.Database.SqlQuery<DetalleRegistroIndicadorFonatel>
                 ("execute Fonatel.pa_obtenerDetalleRegistroIndicadorFonatel   @idSolicitud, @idFormularioWeb, @idIndicador",
                  new SqlParameter("@idSolicitud", pDetalleRegistroIndicador.IdSolicitud),
                   new SqlParameter("@idFormularioWeb", pDetalleRegistroIndicador.idFormularioWeb),
                   new SqlParameter("@idIndicador", pDetalleRegistroIndicador.IdIndicador)
                 ).ToList();
            

            ListaRegistroIndicadorFonatel = ListaRegistroIndicadorFonatel.Select(x => new DetalleRegistroIndicadorFonatel()
                {
                    idFormularioWeb = x.idFormularioWeb,
                    IdIndicador = x.IdIndicador,
                    IdDetalleRegistroIndicadorFonatel = x.IdDetalleRegistroIndicadorFonatel,
                    NombreIndicador = x.NombreIndicador,
                    NotaEncargado = x.NotaEncargado,
                    NotaInformante = x.NotaInformante,
                    CantidadFila = x.CantidadFila,
                    CodigoIndicador = x.CodigoIndicador,
                    TituloHoja = x.TituloHoja,
                    IdSolicitud = x.IdSolicitud,
                    DetalleRegistroIndicadorVariableFonatel=ObtenerDatoDetalleRegistroIndicadorVariable(x),
                    DetalleRegistroIndicadorCategoriaFonatel=ObtenerDatoDetalleRegistroIndicadorCategoria(x),
                    DetalleRegistroIndicadorCategoriaValorFonatel = ObtenerDetalleRegistroIndicadorCategoriaValor(x),
                    DetalleRegistroIndicadorVariableValorFonatel = ObtenerDetalleRegistroIndicadorVariableValor(x),
                    idFormularioWebString = Utilidades.Encriptar(x.idFormularioWeb.ToString()),
                    IdIndicadorString = Utilidades.Encriptar(x.IdIndicador.ToString()),
                    IdSolicitudString = Utilidades.Encriptar(x.IdSolicitud.ToString()),
                RegistroIndicadorFonatel = ObtenerRegistroIndicador(x.IdSolicitud, x.idFormularioWeb)
            }).ToList();

            }

            return ListaRegistroIndicadorFonatel;
        }


        /// <summary>
        /// Obtiene el registro indicador asociado al detalle
        /// Michael Hernández Cordero
        /// 25/04/2023
        /// </summary>
        /// <param name="pDetalleRegistroIndicador"></param>
        /// <returns></returns>

        public RegistroIndicadorFonatel ObtenerRegistroIndicador(int idSolicitud, int IdFormulario)
        {

            return db.Database.SqlQuery<RegistroIndicadorFonatel>
                    ("execute Fonatel.pa_obtenerRegistroIndicadorFonatel @IdSolicitud,@IdFormulario,@idFuente,@idEstado,@RangoFecha",
                     new SqlParameter("@IdSolicitud", idSolicitud),
                     new SqlParameter("@IdFormulario", IdFormulario),
                     new SqlParameter("@IdFuente", DBNull.Value.ToString()),
                     new SqlParameter("@IdEstado", DBNull.Value.ToString()),
                     new SqlParameter("@RangoFecha", DBNull.Value.ToString())
                    ).First();
        }






        /// <summary>
        /// Carga las variable de registro indicador
        /// Michael Hernández Cordero
        /// 11/08/2022
        /// </summary>
        /// <param name="pDetalleRegistroIndicador"></param>
        /// <returns></returns>

        public List<DetalleRegistroIndicadorVariableFonatel> ObtenerDatoDetalleRegistroIndicadorVariable(DetalleRegistroIndicadorFonatel pDetalleRegistroIndicador)
        {
            List<DetalleRegistroIndicadorVariableFonatel> ListaRegistroIndicadorFonatelVariable = new List<DetalleRegistroIndicadorVariableFonatel>();
            ListaRegistroIndicadorFonatelVariable = db.Database.SqlQuery<DetalleRegistroIndicadorVariableFonatel>
             ("execute FONATEL.pa_ObtenerDetalleRegistroIndicadorVariableFonatel   @idSolicitud, @idFormularioWeb, @idIndicador",
                new SqlParameter("@idSolicitud", pDetalleRegistroIndicador.IdSolicitud),
                new SqlParameter("@idFormularioWeb", pDetalleRegistroIndicador.idFormularioWeb),
                new SqlParameter("@idIndicador", pDetalleRegistroIndicador.IdIndicador)
             ).ToList();
            ListaRegistroIndicadorFonatelVariable = ListaRegistroIndicadorFonatelVariable.Select(x => new DetalleRegistroIndicadorVariableFonatel()
            {
                IdSolicitud=x.IdSolicitud,
                idFormularioWeb=x.idFormularioWeb,
                IdIndicador=x.IdIndicador,
                idVariable=x.idVariable,
                NombreVariable=x.NombreVariable,
                Descripcion=x.Descripcion,
                html=string.Format(Constantes.EstructuraHtmlRegistroIndicador.Variable,x.NombreVariable)
            }).ToList();
            return ListaRegistroIndicadorFonatelVariable;
        }

        public List<DetalleRegistroIndicadorCategoriaFonatel> ObtenerDatoDetalleRegistroIndicadorCategoria(DetalleRegistroIndicadorFonatel pDetalleRegistroIndicador)
        {
            List<DetalleRegistroIndicadorCategoriaFonatel> ListaRegistroIndicadorFonatelCategoria = new List<DetalleRegistroIndicadorCategoriaFonatel>();
            ListaRegistroIndicadorFonatelCategoria = db.Database.SqlQuery<DetalleRegistroIndicadorCategoriaFonatel>
             ("execute FONATEL.pa_ObtenerDetalleRegistroIndicadorCategoriaFonatel   @idSolicitud, @idFormularioWeb, @idIndicador",
                new SqlParameter("@idSolicitud", pDetalleRegistroIndicador.IdSolicitud),
                new SqlParameter("@idFormularioWeb", pDetalleRegistroIndicador.idFormularioWeb),
                new SqlParameter("@idIndicador", pDetalleRegistroIndicador.IdIndicador)
             ).ToList();
            ListaRegistroIndicadorFonatelCategoria = ListaRegistroIndicadorFonatelCategoria.Select(x => new DetalleRegistroIndicadorCategoriaFonatel()
            {
                NombreCategoria=x.NombreCategoria,
                RangoMaximo=x.RangoMaximo,
                RangoMinimo=x.RangoMinimo,
                CantidadDetalleDesagregacion=x.CantidadDetalleDesagregacion,
                idCategoria=x.idCategoria,
                IdIndicador=x.IdIndicador,
                IdSolicitud=x.IdSolicitud,
                idFormularioWeb=x.idFormularioWeb,
                IdTipoCategoria=x.IdTipoCategoria,
                html=DefinirControl(x)
            }).ToList();
            


            return ListaRegistroIndicadorFonatelCategoria;
        }

        public List<DetalleRegistroIndicadorCategoriaValorFonatel> ObtenerDetalleRegistroIndicadorCategoriaValor(DetalleRegistroIndicadorFonatel objeto)
        {
            List<DetalleRegistroIndicadorCategoriaValorFonatel> ListaDetalleRegistroIndicadorCategoriaValorFonatel = new List<DetalleRegistroIndicadorCategoriaValorFonatel>();

                ListaDetalleRegistroIndicadorCategoriaValorFonatel = db.Database.SqlQuery<DetalleRegistroIndicadorCategoriaValorFonatel>
                ("execute FONATEL.pa_ObtenerDetalleRegistroIndicadorCategoriaValorFonatel  @idSolicitud, @idFormularioWeb, @idIndicador, @idCategoria",
                   new SqlParameter("@idSolicitud", objeto.IdSolicitud),
                   new SqlParameter("@idFormularioWeb", objeto.idFormularioWeb),
                   new SqlParameter("@idIndicador", objeto.IdIndicador),
                   new SqlParameter("@idCategoria", objeto.idCategoria)
                ).ToList();
            

            ListaDetalleRegistroIndicadorCategoriaValorFonatel = ListaDetalleRegistroIndicadorCategoriaValorFonatel.Select(x => new DetalleRegistroIndicadorCategoriaValorFonatel()
                {
                    IdSolicitud = x.IdSolicitud,
                    idFormularioWeb = x.idFormularioWeb,
                    IdIndicador = x.IdIndicador,
                    idCategoria = x.idCategoria,
                    NumeroFila = x.NumeroFila,
                    Valor = x.Valor,
                }).ToList();
            
            return ListaDetalleRegistroIndicadorCategoriaValorFonatel;
        }

        private string DefinirControl(DetalleRegistroIndicadorCategoriaFonatel DetalleRegistroIndicadorCategoriaFonatel)
        {
            string control = string.Empty;
            switch (DetalleRegistroIndicadorCategoriaFonatel.IdTipoCategoria)
            {
                case (int)Constantes.TipoDetalleCategoriaEnum.Alfanumerico:
                    control = string.Format(Constantes.EstructuraHtmlRegistroIndicador.InputAlfanumerico, DetalleRegistroIndicadorCategoriaFonatel.NombreCategoria, DetalleRegistroIndicadorCategoriaFonatel.idCategoria);
                    break;
                case (int)Constantes.TipoDetalleCategoriaEnum.Texto:
                    control = string.Format( Constantes.EstructuraHtmlRegistroIndicador.InputTexto, DetalleRegistroIndicadorCategoriaFonatel.NombreCategoria, DetalleRegistroIndicadorCategoriaFonatel.idCategoria);
                    break;
                 case (int)Constantes.TipoDetalleCategoriaEnum.Fecha:
                    control = string.Format(Constantes.EstructuraHtmlRegistroIndicador.InputFecha, DetalleRegistroIndicadorCategoriaFonatel.idCategoria, DetalleRegistroIndicadorCategoriaFonatel.RangoMinimo,DetalleRegistroIndicadorCategoriaFonatel.RangoMaximo);
                    break;
                case (int)Constantes.TipoDetalleCategoriaEnum.Numerico:
                    control = string.Format(Constantes.EstructuraHtmlRegistroIndicador.InputNumerico, DetalleRegistroIndicadorCategoriaFonatel.idCategoria, DetalleRegistroIndicadorCategoriaFonatel.RangoMinimo, DetalleRegistroIndicadorCategoriaFonatel.RangoMaximo);
                    break;
                default:
                    control = string.Format(Constantes.EstructuraHtmlRegistroIndicador.InputSelect, DetalleRegistroIndicadorCategoriaFonatel.idCategoria, DetalleRegistroIndicadorCategoriaFonatel.DetalleCategoriaDesagregacion);
                    break;
            }
            return control;
        }

        #endregion

        #region DetalleRegistroIndicadorCategoriaValorFonatel

        /// <summary>
        /// Autor: Georgi Mesen Cerdas
        /// Fecha: 17/11/2022
        /// Ejecutar procedimiento almacenado para actualizar o insertar datos de DetalleRegistroIndicadorCategoriaValorFonatel
        /// </summary>
        /// <param name="objCategoria"></param>
        /// <returns></returns>
        public List<DetalleRegistroIndicadorCategoriaValorFonatel> InsertarDetalleRegistroIndicadorCategoriaValorFonatel(DataTable objeto)
        {
            List<DetalleRegistroIndicadorCategoriaValorFonatel> ListaDetalleRegistroIndicadorCategoriaValorFonatel = new List<DetalleRegistroIndicadorCategoriaValorFonatel>();
            using (db = new SITELContext())
            {
                var parametros = new SqlParameter("@lst", SqlDbType.Structured);
                parametros.SqlValue = objeto;
                parametros.TypeName = "FONATEL.TypeDetalleRegistroIndicadorCategoriaValorFonatel";

                ListaDetalleRegistroIndicadorCategoriaValorFonatel = db.Database.SqlQuery<DetalleRegistroIndicadorCategoriaValorFonatel>
                ("execute FONATEL.pa_InsertarDetalleRegistroIndicadorCategoriaValorFonatel @lst", parametros
                    ).ToList();

                ListaDetalleRegistroIndicadorCategoriaValorFonatel = ListaDetalleRegistroIndicadorCategoriaValorFonatel.Select(x => new DetalleRegistroIndicadorCategoriaValorFonatel()
                {
                    IdSolicitud = x.IdSolicitud,
                    idFormularioWeb = x.idFormularioWeb,
                    IdIndicador = x.IdIndicador,
                    idCategoria = x.idCategoria,
                    NumeroFila = x.NumeroFila,
                    Valor = x.Valor,
                }).ToList();
            }
            return ListaDetalleRegistroIndicadorCategoriaValorFonatel;
        }


        /// <summary>
        /// Autor: Georgi Mesen Cerdas
        /// Fecha: 26/11/2022
        /// Ejecutar procedimiento almacenado para actualizar o insertar datos de DetalleRegistroIndicadorFonatel
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public List<DetalleRegistroIndicadorFonatel> ActualizarDetalleRegistroIndicadorFonatel(DetalleRegistroIndicadorFonatel objeto)
        {
            List<DetalleRegistroIndicadorFonatel> ListaRegistroIndicadorFonatel = new List<DetalleRegistroIndicadorFonatel>();
            using (db = new SITELContext())
            {
                ListaRegistroIndicadorFonatel = db.Database.SqlQuery<DetalleRegistroIndicadorFonatel>
                 ("execute FONATEL.pa_ActualizarDetalleRegistroIndicadorFonatel @IdSolicitud, @idFormularioWeb, @IdIndicador, @IdDetalleRegistroIndicador, @TituloHoja, @NotaEncargado, @NotaInformante, @CodigoIndicador, @NombreIndicador, @CantidadFila",
                   new SqlParameter("@IdSolicitud", objeto.IdSolicitud),
                   new SqlParameter("@idFormularioWeb", objeto.idFormularioWeb),
                   new SqlParameter("@IdIndicador", objeto.IdIndicador),
                   new SqlParameter("@IdDetalleRegistroIndicador", objeto.IdDetalleRegistroIndicadorFonatel),
                   new SqlParameter("@TituloHoja", objeto.TituloHoja),
                   new SqlParameter("@NotaEncargado", objeto.NotaEncargado),
                   new SqlParameter("@NotaInformante", objeto.NotaInformante), 
                   new SqlParameter("@CodigoIndicador", objeto.CodigoIndicador),
                   new SqlParameter("@NombreIndicador", objeto.NombreIndicador),
                   new SqlParameter("@CantidadFila", objeto.CantidadFila)
                 ).ToList();
                ListaRegistroIndicadorFonatel = ListaRegistroIndicadorFonatel.Select(x => new DetalleRegistroIndicadorFonatel()
                {
                    idFormularioWeb = x.idFormularioWeb,
                    IdIndicador = x.IdIndicador,
                    IdDetalleRegistroIndicadorFonatel = x.IdDetalleRegistroIndicadorFonatel,
                    NombreIndicador = x.NombreIndicador,
                    NotaEncargado = x.NotaEncargado,
                    NotaInformante = x.NotaInformante,
                    CantidadFila = x.CantidadFila,
                    CodigoIndicador = x.CodigoIndicador,
                    TituloHoja = x.TituloHoja,
                    IdSolicitud = x.IdSolicitud,
                    DetalleRegistroIndicadorVariableFonatel = ObtenerDatoDetalleRegistroIndicadorVariable(x),
                    DetalleRegistroIndicadorCategoriaFonatel = ObtenerDatoDetalleRegistroIndicadorCategoria(x),
                    idFormularioWebString = Utilidades.Encriptar(x.idFormularioWeb.ToString()),
                    IdIndicadorString = Utilidades.Encriptar(x.IdIndicador.ToString()),
                    IdSolicitudString = Utilidades.Encriptar(x.IdSolicitud.ToString())
                }).ToList();
            }
            return ListaRegistroIndicadorFonatel;
        }

        /// <summary>
        /// Autor: Georgi Mesen Cerdas
        /// Fecha: 26/11/2022
        /// Ejecutar procedimiento almacenado para obtener DetalleRegistroIndicadorCategoriaValorFonatel
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public List<DetalleRegistroIndicadorCategoriaValorFonatel> ObtenerDetalleRegistroIndicadorCategoriaValorFonatel(DetalleRegistroIndicadorCategoriaValorFonatel objeto)
        {
            List<DetalleRegistroIndicadorCategoriaValorFonatel> ListaDetalleRegistroIndicadorCategoriaValorFonatel = new List<DetalleRegistroIndicadorCategoriaValorFonatel>();
            using (db = new SITELContext())
            {
                 ListaDetalleRegistroIndicadorCategoriaValorFonatel = db.Database.SqlQuery<DetalleRegistroIndicadorCategoriaValorFonatel>
                 ("execute FONATEL.pa_ObtenerDetalleRegistroIndicadorCategoriaValorFonatel  @idSolicitud, @idFormularioWeb, @idIndicador, @idCategoria",
                    new SqlParameter("@idSolicitud", objeto.IdSolicitud),
                    new SqlParameter("@idFormularioWeb", objeto.idFormularioWeb),
                    new SqlParameter("@idIndicador", objeto.IdIndicador),
                    new SqlParameter("@idCategoria", objeto.idCategoria)
                 ).ToList();

                    ListaDetalleRegistroIndicadorCategoriaValorFonatel = ListaDetalleRegistroIndicadorCategoriaValorFonatel.Select(x => new DetalleRegistroIndicadorCategoriaValorFonatel()
                    {
                        IdSolicitud = x.IdSolicitud,
                        idFormularioWeb = x.idFormularioWeb,
                        IdIndicador = x.IdIndicador,
                        idCategoria = x.idCategoria,
                        NumeroFila = x.NumeroFila,
                        Valor = x.Valor,
                    }).ToList();
            }
          
            return ListaDetalleRegistroIndicadorCategoriaValorFonatel;
        }

        /// <summary>
        /// Autor: Georgi Mesen Cerdas
        /// Fecha: 01/12/2022
        /// Ejecutar procedimiento almacenado para eliminar DetalleRegistroIndicadorCategoriaValorFonatel
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public void EliminarDetalleRegistroIndicadorCategoriaValorFonatel(DetalleRegistroIndicadorCategoriaValorFonatel objeto)
        {
            List<DetalleRegistroIndicadorCategoriaValorFonatel> ListaDetalleRegistroIndicadorCategoriaValorFonatel = new List<DetalleRegistroIndicadorCategoriaValorFonatel>();
            using (db = new SITELContext())
            {
                ListaDetalleRegistroIndicadorCategoriaValorFonatel = db.Database.SqlQuery<DetalleRegistroIndicadorCategoriaValorFonatel>
                ("execute FONATEL.pa_EliminarDetalleRegistroIndicadorCategoriaValorFonatel  @idSolicitud, @idFormularioWeb, @idIndicador, @idCategoria",
                   new SqlParameter("@idSolicitud", objeto.IdSolicitud),
                   new SqlParameter("@idFormularioWeb", objeto.idFormularioWeb),
                   new SqlParameter("@idIndicador", objeto.IdIndicador),
                   new SqlParameter("@idCategoria", objeto.idCategoria)
                ).ToList();
            }
        }


        //CARGATOTAL
        /// <summary>
        /// Autor:Francisco Vindas Ruiz
        /// Fecha: 26/01/2023
        /// Metodo: Cargar los datos totales a Registro indicador para que pueda ser enviados por correo a los usuarios Encargado e Informante
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public List<DetalleRegistroIndicadorFonatel> CargaTotalRegistroIndicadorFonatel(DetalleRegistroIndicadorFonatel objeto)
        {
            List<DetalleRegistroIndicadorFonatel> ListaRegistroIndicadorFonatel = new List<DetalleRegistroIndicadorFonatel>();
            using (db = new SITELContext())
            {
                ListaRegistroIndicadorFonatel = db.Database.SqlQuery<DetalleRegistroIndicadorFonatel>
                 ("execute FONATEL.spCargarRegistroIndicadorFonatel @idSolicitud, @idFormularioWeb, @idIndicador, @IdDetalleRegistroIndicador, @TituloHojas, @NotasEncargado, @NotasInformante, @CodigoIndicador, @NombreIndicador, @CantidadFilas",
                   new SqlParameter("@idSolicitud", objeto.IdSolicitud),
                   new SqlParameter("@idFormularioWeb", objeto.idFormularioWeb),
                   new SqlParameter("@idIndicador", objeto.IdIndicador),
                   new SqlParameter("@IdDetalleRegistroIndicador", objeto.IdDetalleRegistroIndicadorFonatel),
                   new SqlParameter("@TituloHojas", objeto.TituloHoja),
                   new SqlParameter("@NotasEncargado", objeto.NotaEncargado),
                   new SqlParameter("@NotasInformante", objeto.NotaInformante),
                   new SqlParameter("@CodigoIndicador", objeto.CodigoIndicador),
                   new SqlParameter("@NombreIndicador", objeto.NombreIndicador),
                   new SqlParameter("@CantidadFilas", objeto.CantidadFila)
                 ).ToList();

                CrearListado(ListaRegistroIndicadorFonatel);
            }
            return ListaRegistroIndicadorFonatel;
        }

        #endregion

        #region DetalleRegistroIndicadorVariableValorFonatel
        /// <summary>
        /// Autor: Georgi Mesen Cerdas
        /// Fecha: 26/01/2023
        /// Ejecutar procedimiento almacenado para obtener DetalleRegistroIndicadorVariableValorFonatel
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public List<DetalleRegistroIndicadorVariableValorFonatel> ObtenerDetalleRegistroIndicadorVariableValorFonatel(DetalleRegistroIndicadorVariableValorFonatel objeto)
        {
            List<DetalleRegistroIndicadorVariableValorFonatel> ListaDetalleRegistroIndicadorVariableValorFonatel = new List<DetalleRegistroIndicadorVariableValorFonatel>();
            using (db = new SITELContext())
            {
                ListaDetalleRegistroIndicadorVariableValorFonatel = db.Database.SqlQuery<DetalleRegistroIndicadorVariableValorFonatel>
                ("execute FONATEL.pa_ObtenerDetalleRegistroIndicadorVariableValorFonatel  @idSolicitud, @idFormularioWeb, @idIndicador, @IdVariable",
                   new SqlParameter("@idSolicitud", objeto.IdSolicitud),
                   new SqlParameter("@idFormularioWeb", objeto.idFormularioWeb),
                   new SqlParameter("@idIndicador", objeto.IdIndicador),
                   new SqlParameter("@IdVariable", objeto.IdVariable)
                ).ToList();

                ListaDetalleRegistroIndicadorVariableValorFonatel = ListaDetalleRegistroIndicadorVariableValorFonatel.Select(x => new DetalleRegistroIndicadorVariableValorFonatel()
                {
                    IdSolicitud = x.IdSolicitud,
                    idFormularioWeb = x.idFormularioWeb,
                    IdIndicador = x.IdIndicador,
                    IdVariable = x.IdVariable,
                    NumeroFila = x.NumeroFila,
                    Valor = x.Valor,
                }).ToList();
            }

            return ListaDetalleRegistroIndicadorVariableValorFonatel;
        }

        /// <summary>
        /// Autor: Georgi Mesen Cerdas
        /// Fecha: 26/01/2023
        /// Ejecutar procedimiento almacenado para obtener DetalleRegistroIndicadorVariableValorFonatel
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public List<DetalleRegistroIndicadorVariableValorFonatel> ObtenerDetalleRegistroIndicadorVariableValor(DetalleRegistroIndicadorFonatel objeto)
        {
            List<DetalleRegistroIndicadorVariableValorFonatel> ListaDetalleRegistroIndicadorVariableValorFonatel = new List<DetalleRegistroIndicadorVariableValorFonatel>();

            ListaDetalleRegistroIndicadorVariableValorFonatel = db.Database.SqlQuery<DetalleRegistroIndicadorVariableValorFonatel>
            ("execute FONATEL.pa_ObtenerDetalleRegistroIndicadorVariableValorFonatel  @idSolicitud, @idFormularioWeb, @idIndicador, @IdVariable",
               new SqlParameter("@idSolicitud", objeto.IdSolicitud),
               new SqlParameter("@idFormularioWeb", objeto.idFormularioWeb),
               new SqlParameter("@idIndicador", objeto.IdIndicador),
               new SqlParameter("@IdVariable", objeto.idCategoria)
            ).ToList();


            ListaDetalleRegistroIndicadorVariableValorFonatel = ListaDetalleRegistroIndicadorVariableValorFonatel.Select(x => new DetalleRegistroIndicadorVariableValorFonatel()
            {
                IdSolicitud = x.IdSolicitud,
                idFormularioWeb = x.idFormularioWeb,
                IdIndicador = x.IdIndicador,
                IdVariable = x.IdVariable,
                NumeroFila = x.NumeroFila,
                Valor = x.Valor,
            }).ToList();

            return ListaDetalleRegistroIndicadorVariableValorFonatel;
        }

        /// <summary>
        /// Autor: Georgi Mesen Cerdas
        /// Fecha: 26/01/2023
        /// Ejecutar procedimiento almacenado para actualizar o insertar datos de DetalleRegistroIndicadorVariableValorFonatel
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public List<DetalleRegistroIndicadorVariableValorFonatel> InsertarDetalleRegistroIndicadorVariableValorFonatel(DataTable objeto)
        {
            List<DetalleRegistroIndicadorVariableValorFonatel> ListaDetalleRegistroIndicadorVariableValorFonatel = new List<DetalleRegistroIndicadorVariableValorFonatel>();
            using (db = new SITELContext())
            {
                var parametros = new SqlParameter("@lst", SqlDbType.Structured);
                parametros.SqlValue = objeto;
                parametros.TypeName = "FONATEL.TypeDetalleRegistroIndicadorVariableValorFonatel";

                ListaDetalleRegistroIndicadorVariableValorFonatel = db.Database.SqlQuery<DetalleRegistroIndicadorVariableValorFonatel>
                ("execute FONATEL.pa_InsertarDetalleRegistroIndicadorVariableValorFonatel @lst", parametros
                    ).ToList();

                ListaDetalleRegistroIndicadorVariableValorFonatel = ListaDetalleRegistroIndicadorVariableValorFonatel.Select(x => new DetalleRegistroIndicadorVariableValorFonatel()
                {
                    IdSolicitud = x.IdSolicitud,
                    idFormularioWeb = x.idFormularioWeb,
                    IdIndicador = x.IdIndicador,
                    IdVariable = x.IdVariable,
                    NumeroFila = x.NumeroFila,
                    Valor = x.Valor,
                }).ToList();
            }
            return ListaDetalleRegistroIndicadorVariableValorFonatel;
        }

        /// <summary>
        /// Autor: Georgi Mesen Cerdas
        /// Fecha: 26/01/2023
        /// Ejecutar procedimiento almacenado para eliminar DetalleRegistroIndicadorVariableValorFonatel
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public void EliminarDetalleRegistroIndicadorVariableValorFonatel(DetalleRegistroIndicadorVariableValorFonatel objeto)
        {
            List<DetalleRegistroIndicadorCategoriaValorFonatel> ListaDetalleRegistroIndicadorVariableValorFonatel = new List<DetalleRegistroIndicadorCategoriaValorFonatel>();
            using (db = new SITELContext())
            {
                ListaDetalleRegistroIndicadorVariableValorFonatel = db.Database.SqlQuery<DetalleRegistroIndicadorCategoriaValorFonatel>
                ("execute FONATEL.pa_EliminarDetalleRegistroIndicadorVariableValorFonatel  @idSolicitud, @idFormularioWeb, @idIndicador, @idVariable",
                   new SqlParameter("@idSolicitud", objeto.IdSolicitud),
                   new SqlParameter("@idFormularioWeb", objeto.idFormularioWeb),
                   new SqlParameter("@idIndicador", objeto.IdIndicador),
                   new SqlParameter("@idVariable", objeto.IdVariable)
                ).ToList();
            }
        }
        #endregion
    }
}

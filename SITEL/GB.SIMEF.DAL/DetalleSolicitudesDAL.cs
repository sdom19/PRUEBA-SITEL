﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GB.SIMEF.Entities;
using GB.SIMEF.Resources;

namespace GB.SIMEF.DAL
{
    public class DetalleSolicitudesDAL : BitacoraDAL
    {
        private SIMEFContext db;



        /// <summary>
        /// Autor: Francisco Vindas
        /// Fecha: 25/11/2022
        /// El metodo crea una lista generica de la solicitud que puede ser utilizado en lo metodos que lo necesiten 
        /// </summary>
        /// <param name="ListaSolicitud"></param>
        /// <returns></returns>

        private List<DetalleSolicitudFormulario> CrearListadoDetallesSolicitud(List<DetalleSolicitudFormulario> ListaDetalles)
        {
            return ListaDetalles.Select(x => new DetalleSolicitudFormulario
            {
                IdSolicitud = x.IdSolicitud,
                idFormularioWeb = x.idFormularioWeb,
                Estado = x.Estado,
                Completo = db.Solicitud.Where(i => i.idSolicitud == x.IdSolicitud).Single().CantidadFormulario == ListaDetalles.Count() ? true : false


            }).ToList();
        }
        /// <summary>
        /// Autor: Francisco Vindas Ruiz
        /// Fecha: 13/10/2022
        /// Consultar los datos de Detalles
        /// </summary>
        /// <param name="detalleSolicitud"></param>
        /// <returns></returns>
        public List<DetalleSolicitudFormulario> ObtenerDatos(DetalleSolicitudFormulario detalleSolicitud)
        {
            List<DetalleSolicitudFormulario> ListaDetalle = new List<DetalleSolicitudFormulario>();

            using (db = new SIMEFContext())
            {
                ListaDetalle = db.Database.SqlQuery<DetalleSolicitudFormulario>
                    ("execute pa_ObtenerDetalleSolicitud @pidSolicitud",
                      new SqlParameter("@pidSolicitud", detalleSolicitud.IdSolicitud)
                    ).ToList();

                ListaDetalle = CrearListadoDetallesSolicitud(ListaDetalle);
            }

            return ListaDetalle;
        }

        /// <summary>
        /// Autor: Francisco Vindas Ruiz
        /// Fecha: 24/08/2022
        /// Ejecutar procedimiento almacenado para insertar y editar datos detalle relacion categoria
        /// </summary>
        /// <param name="detalleSolicitud"></param>
        /// <returns></returns>
        public List<DetalleSolicitudFormulario> ActualizarDatos(DetalleSolicitudFormulario detalleSolicitud)
        {
            List<DetalleSolicitudFormulario> ListaDetalle = new List<DetalleSolicitudFormulario>();

            using (db = new SIMEFContext())
            {
                ListaDetalle = db.Database.SqlQuery<DetalleSolicitudFormulario>
                    ("execute pa_ActualizarDetalleSolicitud @idSolicitud, @idFormularioWeb, @Estado",
                      new SqlParameter("@idSolicitud", detalleSolicitud.IdSolicitud),
                      new SqlParameter("@idFormularioWeb", detalleSolicitud.idFormularioWeb),
                      new SqlParameter("@Estado", detalleSolicitud.Estado)
                    ).ToList();

                ListaDetalle = CrearListadoDetallesSolicitud(ListaDetalle);
            }

            return ListaDetalle;
        }

        public List<FormularioWeb> ObtenerListaFormularios(DetalleSolicitudFormulario detalleSolicitud)
        {

            List<FormularioWeb> listaFormularios  = new List<FormularioWeb>();

            using (db = new SIMEFContext())
            {
                listaFormularios = db.Database.SqlQuery<FormularioWeb>(
                    "execute pa_ObtenerFormularioXSolicitudLista @idSolicitud",
                    new SqlParameter("@idSolicitud", detalleSolicitud.IdSolicitud)
                    ).ToList();

                listaFormularios = listaFormularios.Select(x => new FormularioWeb()
                {
                    id = Utilidades.Encriptar(x.idFormularioWeb.ToString()),
                    idFormularioWeb = x.idFormularioWeb,
                    Codigo = x.Codigo,
                    Nombre = x.Nombre,
                    EstadoRegistro = db.EstadoRegistro.Where(i => i.IdEstadoRegistro == x.idEstadoRegistro).FirstOrDefault(),
                }).ToList();
            }

            return listaFormularios;
        }
    }
}

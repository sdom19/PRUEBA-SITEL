﻿using GB.SIMEF.Entities;
using GB.SIMEF.Resources;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.SIMEF.DAL
{
    public class DetalleFormularioWebDAL : BitacoraDAL
    {
        private SIMEFContext db;

        public List<DetalleFormularioWeb> ObtenerDatos(DetalleFormularioWeb objDetalleFormulario)
        {
            List<DetalleFormularioWeb> ListaDetalleFormulariosWeb = new List<DetalleFormularioWeb>();
            using (db = new SIMEFContext())
            { 
                ListaDetalleFormulariosWeb = db.Database.SqlQuery<DetalleFormularioWeb>
                    ("execute spObtenerDetalleFormularioWeb @idDetalle, @idFormulario, @idIndicador",
                    new SqlParameter("@idDetalle", objDetalleFormulario.idDetalle),
                    new SqlParameter("@idFormulario", objDetalleFormulario.idFormulario),
                    new SqlParameter("@idIndicador", objDetalleFormulario.idIndicador)
                    ).ToList();

                ListaDetalleFormulariosWeb = ListaDetalleFormulariosWeb.Select(x => new DetalleFormularioWeb() 
                {
                    idDetalle = x.idDetalle,
                    idFormulario = x.idFormulario,
                    idIndicador = x.idIndicador,
                    TituloHojas = x.TituloHojas,
                    NotasInformante = x.NotasInformante,
                    NotasEncargado = x.NotasEncargado,
                    Estado = x.Estado,

                    Indicador = db.Indicador.Where(i => i.idIndicador == x.idIndicador).FirstOrDefault(),
                    formularioweb = db.FormularioWeb.Where(i => i.idFormulario == x.idFormulario).FirstOrDefault(),
                }
                ).ToList();
            }
            return ListaDetalleFormulariosWeb;

        }
    }
}

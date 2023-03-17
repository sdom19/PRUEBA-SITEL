﻿using GB.SIMEF.Entities;
using GB.SIMEF.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.SIMEF.DAL
{
    public class TipoMedidaDAL : BitacoraDAL
    {
        private SIMEFContext db;

        /// <summary>
        /// 23/08/2022
        /// José Navarro Acuña
        /// Función que retorna todos los tipos de medidas registrados en estado activo.
        /// Se puede filtrar por el ID del objecto
        /// </summary>
        /// <returns></returns>
        public List<TipoMedida> ObtenerDatos(TipoMedida pTipoMedida)
        {
            List<TipoMedida> lista = new List<TipoMedida>();

            using (db = new SIMEFContext())
            {
                if (pTipoMedida.IdTipoMedida != 0)
                {
                    lista = db.TipoMedida.Where(x => x.IdTipoMedida == pTipoMedida.IdTipoMedida && x.Estado == true).ToList();
                }
                else
                {
                    lista = db.TipoMedida.Where(x => x.Estado == true).ToList();
                }
            }

            lista = lista.Select(x => new TipoMedida()
            {
                id = Utilidades.Encriptar(x.IdTipoMedida.ToString()),
                Nombre = x.Nombre,
                Estado = x.Estado
            }).ToList();

            return lista;
        }
    }
}

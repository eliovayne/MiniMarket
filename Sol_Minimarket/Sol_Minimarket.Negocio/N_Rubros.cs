using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Sol_Minimarket.Entidades;
using Sol_Minimarket.Datos;

namespace Sol_Minimarket.Negocio
{
    public class N_Rubros
    {
        public static DataTable Listado_ru(string cTexto)
        {
            D_Rubros Datos = new D_Rubros();
            return Datos.Listado_ru(cTexto);
        }

        public static string Guardar_ru(int nOpcion, E_Rubros oRu)
        {
            D_Rubros Datos = new D_Rubros();
            return Datos.Guardar_ru(nOpcion, oRu);
        }

        public static string Eliminar_ru(int Codigo_ru)
        {
            D_Rubros Datos = new D_Rubros();
            return Datos.Eliminar_ru(Codigo_ru);
        }
    }
}

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
    public class N_Departamentos
    {
        public static DataTable Listado_de(string cTexto)
        {
            D_Departamentos Datos = new D_Departamentos();
            return Datos.Listado_de(cTexto);
        }

        public static string Guardar_de(int nOpcion, E_Departamentos oDe)
        {
            D_Departamentos Datos = new D_Departamentos();
            return Datos.Guardar_de(nOpcion, oDe);
        }

        public static string Eliminar_de(int Codigo_de)
        {
            D_Departamentos Datos = new D_Departamentos();
            return Datos.Eliminar_de(Codigo_de);
        }
    }
}

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
    public class N_Distritos
    {
        public static DataTable Listado_di(string cTexto)
        {
            D_Distritos Datos = new D_Distritos();
            return Datos.Listado_di(cTexto);
        }

        public static string Guardar_di(int nOpcion, E_Distritos oDi)
        {
            D_Distritos Datos = new D_Distritos();
            return Datos.Guardar_di(nOpcion, oDi);
        }

        public static string Eliminar_di(int Codigo_di)
        {
            D_Distritos Datos = new D_Distritos();
            return Datos.Eliminar_di(Codigo_di);
        }

        public static DataTable Listado_po_personalizado(string cTexto)
        {
            D_Distritos Datos = new D_Distritos();
            return Datos.Listado_po_personalizado(cTexto);
        }
    }
}

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
    public class N_Proveedores
    {
        public static DataTable Listado_pv(string cTexto)
        {
            D_Proveedores Datos = new D_Proveedores();
            return Datos.Listado_pv(cTexto);
        }

        public static string Guardar_pv(int nOpcion, E_Proveedores oPv)
        {
            D_Proveedores Datos = new D_Proveedores(); ;
            return Datos.Guardar_pv(nOpcion, oPv);
        }

        public static string Eliminar_pv(int Codigo_pv)
        {
            D_Proveedores Datos = new D_Proveedores();
            return Datos.Eliminar_pv(Codigo_pv);
        }

        public static DataTable Listado_tdpc()
        {
            D_Proveedores Datos = new D_Proveedores();
            return Datos.Listado_tdpc();
        }

        public static DataTable Listado_sx()
        {
            D_Proveedores Datos = new D_Proveedores();
            return Datos.Listado_sx();
        }        
        public static DataTable Listado_ru_pv(string cTexto)
        {
            D_Proveedores Datos = new D_Proveedores();
            return Datos.Listado_ru_pv(cTexto);
        }

        public static DataTable Listado_di_pv(string cTexto)
        {
            D_Proveedores Datos = new D_Proveedores();
            return Datos.Listado_di_pv(cTexto);
        }
    }
}

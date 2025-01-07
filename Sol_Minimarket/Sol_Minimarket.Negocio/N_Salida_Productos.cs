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
    public class N_Salida_Productos
    {
        public static DataTable Listado_sp(string cTexto)
        {
            D_Salida_Productos Datos = new D_Salida_Productos();
            return Datos.Listado_sp(cTexto);
        }

        public static DataTable Listado__detalle_sp(int nCodigo_sp)
        {
            D_Salida_Productos Datos = new D_Salida_Productos();
            return Datos.Listado__detalle_sp(nCodigo_sp);
        }

        public static string Guardar_sp(E_Salida_Productos oSp, DataTable dTabla)
        {
            D_Salida_Productos Datos = new D_Salida_Productos();
            return Datos.Guardar_sp(oSp, dTabla);
        }

        public static string Eliminar_sp(int Codigo_sp)
        {
            D_Salida_Productos Datos = new D_Salida_Productos();
            return Datos.Eliminar_sp(Codigo_sp);
        }

        public static DataTable Listado_tde()
        {
            D_Salida_Productos Datos = new D_Salida_Productos();
            return Datos.Listado_tde();
        }       

        public static DataTable Listado_cl_sp(string cTexto)
        {
            D_Salida_Productos Datos = new D_Salida_Productos();
            return Datos.Listado_cl_sp(cTexto);
        }

        public static DataTable Listado_pr_sp(string cTexto)
        {
            D_Salida_Productos Datos = new D_Salida_Productos();
            return Datos.Listado_pr_sp(cTexto);
        }
    }
}

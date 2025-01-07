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
    public class N_Provincias
    {
        public static DataTable Listado_po(string cTexto)
        {
            D_Provincias Datos = new D_Provincias();
            return Datos.Listado_po(cTexto);
        }

        public static string Guardar_po(int nOpcion, E_Provincias oPo)
        {
            D_Provincias Datos = new D_Provincias();
            return Datos.Guardar_po(nOpcion, oPo);
        }

        public static string Eliminar_po(int Codigo_po)
        {
            D_Provincias Datos = new D_Provincias();
            return Datos.Eliminar_po(Codigo_po);
        }

        public static DataTable Listado_de_po(string cTexto)
        {
            D_Provincias Datos = new D_Provincias();
            return Datos.Listado_de_po(cTexto);
        }
    }
}

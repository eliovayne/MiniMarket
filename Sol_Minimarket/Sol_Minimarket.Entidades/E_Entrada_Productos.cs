using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Minimarket.Entidades
{
    public class E_Entrada_Productos
    {
        public int Codigo_ep { get; set; }
        public int Codigo_tde { get; set; }
        public string nrodocumento_ep { get; set; }
        public int Codigo_pv { get; set; }
        public DateTime Fecha_ep { get; set; }
        public int Codigo_al { get; set; }
        public string Observacion { get; set; }
        public decimal Subtotal { get; set; }
        public decimal igv { get; set; }
        public decimal total_importe { get; set; }
    }
}

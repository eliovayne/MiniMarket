using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sol_Minimarket.Presentacion.Reportes_Consolidado
{
    public partial class Frm_Reporte_Salida_AcumuladoxProducto : Form
    {
        public Frm_Reporte_Salida_AcumuladoxProducto()
        {
            InitializeComponent();
        }

        private void Btn_vistaprevia_Click(object sender, EventArgs e)
        {
            Reportes_Consolidado.Frm_Rpt_Salida_AcumuladoxProducto oRpt_SAP = new Reportes_Consolidado.Frm_Rpt_Salida_AcumuladoxProducto();
            oRpt_SAP.txt_p1.Text = Convert.ToString(Dp_fecha_ini.Value);
            oRpt_SAP.txt_p2.Text = Convert.ToString(Dp_fecha_fin.Value);
            oRpt_SAP.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

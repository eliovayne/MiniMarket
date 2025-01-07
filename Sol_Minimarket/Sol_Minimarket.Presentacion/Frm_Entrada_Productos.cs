using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sol_Minimarket.Entidades;
using Sol_Minimarket.Negocio;

namespace Sol_Minimarket.Presentacion
{
    public partial class Frm_Entrada_Productos : Form
    {
        public Frm_Entrada_Productos()
        {
            InitializeComponent();
        }
        #region "Mis Variables"
        int Codigo_ep = 0;
        int Codigo_tde = 0;
        int Codigo_pv = 0;
        int Codigo_al = 0;

        int Estadoguarda = 0;
        DataTable TablaDetalle = new DataTable();
        #endregion

        #region "Mis Métodos"
        private void Formato_ep()
        {
            Dgv_principal.Columns[0].Width = 85;
            Dgv_principal.Columns[0].HeaderText = "CÓDIGO_EP";
            Dgv_principal.Columns[1].Width = 70;
            Dgv_principal.Columns[1].HeaderText = "TIPO DOC";
            Dgv_principal.Columns[2].Width = 110;
            Dgv_principal.Columns[2].HeaderText = "NRO DOC";
            Dgv_principal.Columns[3].Width = 140;
            Dgv_principal.Columns[3].HeaderText = "FECHA DOC";
            Dgv_principal.Columns[4].Width = 270;
            Dgv_principal.Columns[4].HeaderText = "PROVEEDOR";
            Dgv_principal.Columns[5].Width = 170;
            Dgv_principal.Columns[5].HeaderText = "ALMACÉN";
            Dgv_principal.Columns[6].Width = 140;
            Dgv_principal.Columns[6].HeaderText = "TOTAL IMPORTE";
            Dgv_principal.Columns[7].Visible = false;
            Dgv_principal.Columns[8].Visible = false;
            Dgv_principal.Columns[9].Visible = false;
            Dgv_principal.Columns[10].Visible = false;
            Dgv_principal.Columns[11].Visible = false;
            Dgv_principal.Columns[12].Visible = false;
        }

        private void Listado_ep(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Entrada_Productos.Listado_ep(cTexto);
                this.Formato_ep();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Estado_Botonesprincipales(bool lEstado)
        {
            this.Btn_nuevo.Enabled = lEstado;           
            this.Btn_eliminar.Enabled = lEstado;
            this.Btn_reporte.Enabled = lEstado;
            this.Btn_salir.Enabled = lEstado;
        }

        private void Estado_Botonesprocesos(bool lEstado)
        {
            this.Btn_cancelar.Visible = lEstado;
            this.Btn_guardar.Visible = lEstado;
            this.Btn_retornar.Visible = !lEstado;

            this.Btn_agregar.Visible = lEstado;
            this.Btn_quitar.Visible = lEstado;

            this.Btn_lupa1.Visible = lEstado;
            this.Btn_lupa2.Visible = lEstado;
            this.Btn_lupa3.Visible = lEstado;
        }

        private void Selecciona_item()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_ep"].Value)))
            {
                MessageBox.Show("No se tiene información para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {                
                this.Codigo_ep = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ep"].Value);
                this.Codigo_tde= Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_tde"].Value);
                this.Codigo_pv = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_pv"].Value);
                this.Codigo_al = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_al"].Value);
                Txt_descripcion_tde.Text = Dgv_principal.CurrentRow.Cells["descripcion_tde"].Value.ToString();
                Txt_nrodocumento_ep.Text = Dgv_principal.CurrentRow.Cells["nrodocumento_ep"].Value.ToString();
                Dtp_fecha_ep.Value = Convert.ToDateTime(Dgv_principal.CurrentRow.Cells["fecha_ep"].Value);
                Txt_razon_social_pv.Text = Dgv_principal.CurrentRow.Cells["razon_social_pv"].Value.ToString();
                Txt_descripcion_al.Text = Dgv_principal.CurrentRow.Cells["descripcion_al"].Value.ToString();
                Txt_observacion_ep.Text = Dgv_principal.CurrentRow.Cells["observacion_ep"].Value.ToString();
                Txt_subtotal.Text = Dgv_principal.CurrentRow.Cells["subtotal"].Value.ToString();
                Txt_igv.Text = Dgv_principal.CurrentRow.Cells["igv"].Value.ToString();
                Txt_total_importe.Text = Dgv_principal.CurrentRow.Cells["total_importe"].Value.ToString();
                
                Dgv_Detalle.DataSource = N_Entrada_Productos.Listado__detalle_ep(this.Codigo_ep);
                this.Formato_detalle();
            }
           
        }

        private void Crear_TablaDetalle()
        {
            this.TablaDetalle = new DataTable("TablaDetalle");
            this.TablaDetalle.Columns.Add("Descripcion_pr", System.Type.GetType("System.String"));
            this.TablaDetalle.Columns.Add("Descripcion_ma", System.Type.GetType("System.String"));
            this.TablaDetalle.Columns.Add("Descripcion_um", System.Type.GetType("System.String"));
            this.TablaDetalle.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"));
            this.TablaDetalle.Columns.Add("Pu_compra", System.Type.GetType("System.Decimal"));
            this.TablaDetalle.Columns.Add("Total", System.Type.GetType("System.Decimal"));
            this.TablaDetalle.Columns.Add("Codigo_pr", System.Type.GetType("System.Int32"));
            this.TablaDetalle.AcceptChanges();

            Dgv_Detalle.DataSource = this.TablaDetalle;
            this.Formato_detalle();

        }

        private void Agregar_item(string cDescripcion_pr,
                                  string cDescripcion_ma,
                                  string cDescripcion_um,
                                  decimal nCantidad,
                                  decimal nPu_compra,
                                  decimal nTotal,
                                  int nCodigo_pr)
        {
            DataRow xFila = TablaDetalle.NewRow();
            xFila["Descripcion_pr"] = cDescripcion_pr;
            xFila["Descripcion_ma"] = cDescripcion_ma;
            xFila["Descripcion_um"] = cDescripcion_um;
            xFila["Cantidad"] = nCantidad;
            xFila["Pu_compra"] = nPu_compra;
            xFila["Total"] = nTotal;
            xFila["Codigo_pr"] = nCodigo_pr;
            this.TablaDetalle.Rows.Add(xFila);
            TablaDetalle.AcceptChanges();
        }
        
        private void Formato_detalle()
        {
            Dgv_Detalle.Columns[0].Width = 270;
            Dgv_Detalle.Columns[0].HeaderText = "PRODUCTO";
            Dgv_Detalle.Columns[1].Width = 160;
            Dgv_Detalle.Columns[1].HeaderText = "MARCA";
            Dgv_Detalle.Columns[2].Width = 80;
            Dgv_Detalle.Columns[2].HeaderText = "U.MEDIDA";
            Dgv_Detalle.Columns[3].Width = 90;
            Dgv_Detalle.Columns[3].HeaderText = "CANTIDAD";
            Dgv_Detalle.Columns[4].Width = 110;
            Dgv_Detalle.Columns[4].HeaderText = "PU COMPRA";
            Dgv_Detalle.Columns[5].Width = 90;
            Dgv_Detalle.Columns[5].HeaderText = "TOTAL";
            Dgv_Detalle.Columns[6].Visible = false;
            Dgv_Detalle.Columns[0].ReadOnly = true;
            Dgv_Detalle.Columns[1].ReadOnly = true;
            Dgv_Detalle.Columns[2].ReadOnly = true;
            Dgv_Detalle.Columns[3].ReadOnly = true;
            Dgv_Detalle.Columns[4].ReadOnly = true;
            Dgv_Detalle.Columns[5].ReadOnly = true;
        }

        private void Formato_tde()
        {
            Dgv_tipo_tde.Columns[0].Width = 200;
            Dgv_tipo_tde.Columns[0].HeaderText = "TIPO DOCUMENTO";
            Dgv_tipo_tde.Columns[1].Visible = false;

        }
        private void Listado_tde()
        {
            try
            {
                Dgv_tipo_tde.DataSource = N_Entrada_Productos.Listado_tde();
                this.Formato_tde();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_tde()
        {
           if (string.IsNullOrEmpty(Convert.ToString(Dgv_tipo_tde.CurrentRow.Cells["codigo_tde"].Value)))
            {
                MessageBox.Show("No se tiene información para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_tde = Convert.ToInt32(Dgv_tipo_tde.CurrentRow.Cells["codigo_tde"].Value);
                Txt_descripcion_tde.Text = Convert.ToString(Dgv_tipo_tde.CurrentRow.Cells["descripcion_tde"].Value);
            }
        }
               

        private void Formato_al()
        {
            Dgv_almacenes.Columns[0].Width = 220;
            Dgv_almacenes.Columns[0].HeaderText = "ALMACÉN";
            Dgv_almacenes.Columns[1].Visible = false;

        }

        private void Listado_al()
        {
            try
            {
                Dgv_almacenes.DataSource = N_Entrada_Productos.Listado_al_ep();
                this.Formato_al();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_al()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_almacenes.CurrentRow.Cells["codigo_al"].Value)))
            {
                MessageBox.Show("No se tiene información para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_al = Convert.ToInt32(Dgv_almacenes.CurrentRow.Cells["codigo_al"].Value);
                Txt_descripcion_al.Text = Convert.ToString(Dgv_almacenes.CurrentRow.Cells["descripcion_al"].Value);
            }
        }

        private void Formato_pv()
        {
            Dgv_proveedores.Columns[0].Width = 220;
            Dgv_proveedores.Columns[0].HeaderText = "PROVEEDOR";
            Dgv_proveedores.Columns[1].Width = 220;
            Dgv_proveedores.Columns[1].HeaderText = "TIPO DOC.";
            Dgv_proveedores.Columns[2].Width = 220;
            Dgv_proveedores.Columns[2].HeaderText = "NRO. DOC.";
            Dgv_proveedores.Columns[3].Visible = false;

        }

        private void Listado_pv(string cTexto)
        {
            try
            {
                Dgv_proveedores.DataSource = N_Entrada_Productos.Listado_pv_ep(cTexto);
                this.Formato_pv();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_pv()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_proveedores.CurrentRow.Cells["codigo_pv"].Value)))
            {
                MessageBox.Show("No se tiene información para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_pv = Convert.ToInt32(Dgv_proveedores.CurrentRow.Cells["codigo_pv"].Value);
                Txt_razon_social_pv.Text = Convert.ToString(Dgv_proveedores.CurrentRow.Cells["razon_social_pv"].Value);
            }
        }

        private void Formato_pr()
        {
            Dgv_productos.Columns[0].Width = 220;
            Dgv_productos.Columns[0].HeaderText = "PRODUCTO";
            Dgv_productos.Columns[1].Width = 160;
            Dgv_productos.Columns[1].HeaderText = "MARCA.";
            Dgv_productos.Columns[2].Width = 90;
            Dgv_productos.Columns[2].HeaderText = "U.MEDIDA";
            Dgv_productos.Columns[3].Width = 160;
            Dgv_productos.Columns[3].HeaderText = "CATEGORÍA";
            Dgv_productos.Columns[4].Visible = false;

        }

        private void Listado_pr(string cTexto)
        {
            try
            {
                Dgv_productos.DataSource = N_Entrada_Productos.Listado_pr_ep(cTexto);
                this.Formato_pr();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_pr()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_productos.CurrentRow.Cells["codigo_pr"].Value)))
            {
                MessageBox.Show("No se tiene información para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                string xDescripcion_pr;
                string xDescripcion_ma;
                string xDescripcion_um;
                decimal xCantidad;
                decimal xPu_compra;
                decimal xTotal;
                int xCodigo_pr;

                bool Agregar = true;

                xCodigo_pr = Convert.ToInt32(Dgv_productos.CurrentRow.Cells["codigo_pr"].Value);
                foreach (DataRow Filatemp in TablaDetalle.Rows)
                {
                    if (Convert.ToInt32(Filatemp["codigo_pr"])==xCodigo_pr)
                    {
                        Agregar = false;
                        MessageBox.Show("El producto ya se encuetra agregado", "Aviso del Sistema");
                    }
                }

                if (Agregar==true)
                {
                    xDescripcion_pr = Convert.ToString(Dgv_productos.CurrentRow.Cells["descripcion_pr"].Value);
                    xDescripcion_ma = Convert.ToString(Dgv_productos.CurrentRow.Cells["descripcion_ma"].Value);
                    xDescripcion_um = Convert.ToString(Dgv_productos.CurrentRow.Cells["descripcion_um"].Value);
                    xCantidad = Convert.ToDecimal("0.00");
                    xPu_compra = Convert.ToDecimal("0.00");
                    xTotal = Convert.ToDecimal("0.00");


                    this.Agregar_item(xDescripcion_pr,
                                      xDescripcion_ma,
                                      xDescripcion_um,
                                      xCantidad,
                                      xPu_compra,
                                      xTotal,
                                      xCodigo_pr);
                }
                
            }
        }
        private void Estado_texto(bool lestado)
        {
            Txt_nrodocumento_ep.ReadOnly = !lestado;
            Txt_observacion_ep.ReadOnly = !lestado;
            Dtp_fecha_ep.Enabled = lestado;
        }

        private void Limpia_texto()
        {
            Txt_nrodocumento_ep.Text = "";
            Txt_observacion_ep.Text = "";
            Txt_subtotal.Text = "";
            Txt_igv.Text = "";
            Txt_total_importe.Text = "";
            this.Crear_TablaDetalle();
        }

        private void Calcular_totales()
        {
            
            decimal nSubtotal = 0;
            decimal nIgv = 0;
            decimal nTotal_importe = 0;
            if (Dgv_Detalle.Rows.Count==0)
            {
                nSubtotal = 0;
                nIgv = 0;
                nTotal_importe = 0;                
            }
            else
            {
                TablaDetalle.AcceptChanges();
                foreach (DataRow Filatemp in TablaDetalle.Rows)
                {
                    nTotal_importe = nTotal_importe + Convert.ToDecimal(Filatemp["total"]);
                }               

                nSubtotal = nTotal_importe / (1 + Convert.ToDecimal("0.18"));
                nIgv = (nTotal_importe - nSubtotal);

                Txt_subtotal.Text = decimal.Round(nSubtotal, 2).ToString("#0.00");
                Txt_igv.Text = decimal.Round(nIgv,2).ToString("#0.00");
                Txt_total_importe.Text =decimal.Round(nTotal_importe,2).ToString("#0.00");
            }
           
        }
        #endregion

        private void Frm_Entrada_Productos_Load(object sender, EventArgs e)
        {
            this.Listado_ep("%");
            this.Listado_tde();
            this.Listado_pv("%");
            this.Listado_al();
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_tde.Text== String.Empty ||
                Txt_nrodocumento_ep.Text == string.Empty ||
                Txt_razon_social_pv.Text == String.Empty ||
                Txt_descripcion_al.Text == String.Empty ||
                Dgv_Detalle.Rows.Count==0)
            {
                MessageBox.Show("Falta ingresa datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a registrar la información
            {
              
                string Rpta = "";
                E_Entrada_Productos oEp = new E_Entrada_Productos();
                oEp.Codigo_ep = this.Codigo_ep;
                oEp.Codigo_tde = this.Codigo_tde;
                oEp.nrodocumento_ep = Txt_nrodocumento_ep.Text.Trim();
                oEp.Codigo_pv = this.Codigo_pv;
                oEp.Fecha_ep = Dtp_fecha_ep.Value;
                oEp.Codigo_al = this.Codigo_al;
                oEp.Observacion = Txt_observacion_ep.Text.Trim();
                oEp.Subtotal = Convert.ToDecimal(Txt_subtotal.Text.Trim());
                oEp.igv = Convert.ToDecimal(Txt_igv.Text.Trim());
                oEp.total_importe = Convert.ToDecimal(Txt_total_importe.Text.Trim());

                this.TablaDetalle.AcceptChanges();

                Rpta = N_Entrada_Productos.Guardar_ep(oEp, TablaDetalle);
                if (Rpta.Equals("OK"))
                {
                    this.Listado_ep("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    this.Estado_texto(false);
                    Dgv_Detalle.Columns[3].ReadOnly = true;
                    Dgv_Detalle.Columns[4].ReadOnly = true;

                    Tbc_principal.SelectedIndex = 0;
                    this.Codigo_ep = 0;                   
                    this.Estadoguarda = 0;

                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            this.Estadoguarda = 1;
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Limpia_texto();
            Dgv_Detalle.Columns[3].ReadOnly = false;
            Dgv_Detalle.Columns[4].ReadOnly = false;
            this.Estado_texto(true);          
            Tbc_principal.SelectedIndex = 1;
            Txt_nrodocumento_ep.Focus();
            
        }
      

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Codigo_ep = 0;
            this.Codigo_tde = 0;
            this.Codigo_pv = 0;
            this.Codigo_al = 0;
            this.Estadoguarda = 0;

            this.Estado_texto(false);
            this.Limpia_texto();
            Dgv_Detalle.Columns[3].ReadOnly = true;
            Dgv_Detalle.Columns[4].ReadOnly = true;

            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
           this.Selecciona_item();
           this.Estado_Botonesprocesos(false);
           Tbc_principal.SelectedIndex = 1;           
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;            
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_ep"].Value)))
            {
                MessageBox.Show("No se tiene información para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Estás seguro de anular el registro seleccionado?", "Aviso del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Opcion==DialogResult.Yes)
                {
                    string Rpta = "";
                    this.Codigo_ep = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ep"].Value);
                    Rpta = N_Entrada_Productos.Eliminar_ep(this.Codigo_ep);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_ep("%");
                        this.Codigo_ep = 0;
                        MessageBox.Show("Registro Anulado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                
               
            }

        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
           this.Listado_ep(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Entrada_Productos oRpt_ep = new Reportes.Frm_Rpt_Entrada_Productos();
            oRpt_ep.txt_p1.Text = Txt_buscar.Text;
            oRpt_ep.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_lupa1_Click(object sender, EventArgs e)
        {
            this.Pnl_Listado_tde.Location = Btn_lupa1.Location;
            this.Pnl_Listado_tde.Visible = true;
        }

        private void Dgv_tipo_tdpc_DoubleClick(object sender, EventArgs e)
        {
            this.Selecciona_item_tde();
            Pnl_Listado_tde.Visible = false;
            Txt_nrodocumento_ep.Focus();
        }

        private void Btn_lupa2_Click(object sender, EventArgs e)
        {
            this.Pnl_listado_pv.Location = Btn_lupa1.Location;
            this.Pnl_listado_pv.Visible = true;
        }
       

        private void Btn_buscar2_Click(object sender, EventArgs e)
        {
            this.Listado_pv(Txt_buscar2.Text);
        }

        private void Btn_retornar1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_tde.Visible = false;
        }

        private void Btn_retornar2_Click(object sender, EventArgs e)
        {
            Pnl_listado_pv.Visible = false;
        }

       

        private void Btn_lupa3_Click(object sender, EventArgs e)
        {
            this.Pnl_Listado_al.Location = Btn_lupa3.Location;
            this.Pnl_Listado_al.Visible = true;
        }

        private void Dgv_almacenes_DoubleClick(object sender, EventArgs e)
        {
            this.Selecciona_al();
            Pnl_Listado_al.Visible = false;
        }

        private void Dgv_proveedores_DoubleClick(object sender, EventArgs e)
        {
            this.Selecciona_pv();
            Pnl_listado_pv.Visible = false;
        }
       

        private void Btn_retornar3_Click(object sender, EventArgs e)
        {
            Pnl_Listado_al.Visible = false;
        }

        private void Btn_lupa4_Click(object sender, EventArgs e)
        {
            this.Pnl_listado_pv.Location = Btn_lupa1.Location;
            this.Pnl_listado_pv.Visible = true;
        }

        private void Btn_buscar4_Click(object sender, EventArgs e)
        {
            this.Listado_pr(Txt_buscar4.Text);
        }

        private void Btn_agregar_Click(object sender, EventArgs e)
        {
            Pnl_listado_pr.Location = Btn_lupa1.Location;
            Pnl_listado_pr.Visible = true;
            Txt_buscar4.Focus();
        }

        private void Btn_retornar4_Click(object sender, EventArgs e)
        {
            Pnl_listado_pr.Visible = false;
        }             

        private void Dgv_productos_DoubleClick(object sender, EventArgs e)
        {
            this.Selecciona_pr();
            Pnl_listado_pr.Visible = false;
        }

        private void Dgv_Detalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Estadoguarda==1)
            {
                DataRow yFila = (DataRow)TablaDetalle.Rows[e.RowIndex];
                decimal yCantidad = Convert.ToDecimal(yFila["Cantidad"]);
                decimal yPu_compra = Convert.ToDecimal(yFila["Pu_compra"]);
                yFila["Total"] = decimal.Round(yCantidad * yPu_compra, 2).ToString("#0.00");

                this.Calcular_totales();
            }
            
        }

        private void Btn_quitar_Click(object sender, EventArgs e)
        {
            if (Dgv_Detalle.Rows.Count>0)
            {
                Dgv_Detalle.Rows.Remove(Dgv_Detalle.CurrentRow);
                Dgv_Detalle.Refresh();
                TablaDetalle.AcceptChanges();
                this.Calcular_totales();
            }
        }
    }
}

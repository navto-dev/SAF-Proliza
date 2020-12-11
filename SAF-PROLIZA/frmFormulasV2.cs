using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using CapaNegocios;
using Entidades;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;

namespace SAF_PROLIZA
{
    public partial class frmFormulasV2 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public decimal CostoTotal { get; set; }
        public int IdFormula { get; set; }
        DataTable DetallesFormula = new DataTable();
        public frmFormulasV2(int IdFormula)
        {
            InitializeComponent();
            llenarComboFamilia();
            llenarComboUnidadMedida();
            llenarComboInsumos();
            this.IdFormula = IdFormula;
            ribbonPageGroup2.Visible = (IdFormula > 0);
            btnBaja.Visibility = (IdFormula > 0) ? BarItemVisibility.Always : BarItemVisibility.Never;
            if (IdFormula > 0)
            {
                DataTable Formula = new CNFormulas().ConsultaPorId(IdFormula);
                txtFormula.Text = Formula.Rows[0]["NombreFormula"].ToString();
                txtFormula.Properties.ReadOnly = (Convert.ToInt32(Formula.Rows[0]["IdFamilia"]) == 1);
                cmbFamilia.EditValue = Convert.ToInt32(Formula.Rows[0]["IdFamilia"]);
                txtCantidad.Text = Formula.Rows[0]["Cantidad"].ToString();
                cmbUnidadMedida.EditValue = Formula.Rows[0]["Capacidad"].ToString();
                foreach (DataRow item in new CNDetallesFormulas().ConsultaPorFormula(IdFormula).Rows)
                    AgregarNuevoRegistro(Convert.ToInt32(item["IdDetalle"]), Convert.ToInt32(item["IdInsumo"]), item["CantidadInsumo"].ToString(), item["UnidadMedidaInsumo"].ToString());
            }
        }

        void llenarComboFamilia()
        {
            cmbFamilia.Properties.DataSource = new CNFamiliaFormulas().ConsultaGeneral();
            cmbFamilia.Properties.DisplayMember = "NombreFamilia";
            cmbFamilia.Properties.ValueMember = "IdFamilia";
            cmbFamilia.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreFamilia", "Familia"));

        }
        void llenarComboUnidadMedida()
        {
            cmbUnidadMedida.Properties.ValueMember = cmbUnidadMedida.Properties.DisplayMember = "Column";
            cmbUnidadMedida.Properties.DataSource = new string[5] { "Kilográmos", "grámos", "miligrámos", "Litros", "Mililitros" };
            cmbUnidadMedida.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Column", "Unidad de Medida"));
        }
        void llenarComboInsumos()
        {
            cmbInsumos.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreInterno", "Nombre Insumo"));
            if (Estaticos.IdRol == 1)
                cmbInsumos.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreInsumo", "Nombre Real"));
            cmbInsumos.Properties.ValueMember = "IdInsumo";
            cmbInsumos.Properties.DisplayMember = "NombreInsumo";
            cmbInsumos.Properties.DataSource = new CNInsumos().ConsultaInsumosIngredientes();
        }
        void llenarComboUnidadMedidaInsumo()
        {
            if (cmbInsumos.EditValue != null)
            {
                DataRow row = new CNInsumos().ConsultaPorId(Convert.ToInt32(cmbInsumos.EditValue)).Rows[0];
                cmbUnidadMedidaInsumo.Properties.Columns.Clear();
                if (row["UnidadMedida"].ToString().StartsWith("K"))
                    cmbUnidadMedidaInsumo.Properties.DataSource = new string[3] { "Kilográmos", "grámos", "miligrámos" };
                else if (row["UnidadMedida"].ToString().StartsWith("L"))
                    cmbUnidadMedidaInsumo.Properties.DataSource = new string[2] { "Litros", "Mililitros" };
                else
                {
                    cmbUnidadMedidaInsumo.Properties.DataSource = new string[1] { "Piezas" };
                    cmbUnidadMedidaInsumo.ItemIndex = 0;
                }
                cmbUnidadMedidaInsumo.Properties.ValueMember = cmbUnidadMedidaInsumo.Properties.DisplayMember = "Column";
                cmbUnidadMedidaInsumo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Column", "Unidad de Medida"));
            }
        }


        string GetUnidadMedida(string capacidad)
        {
            string UnidadMedida = "";
            switch (capacidad)
            {
                case "Litros":
                    UnidadMedida = "L";
                    break;
                case "Mililitros":
                    UnidadMedida = "L";
                    break;

                case "Kilográmos":
                    UnidadMedida = "K";
                    break;
                case "grámos":
                    UnidadMedida = "K";
                    break;
                case "miligrámos":
                    UnidadMedida = "K";
                    break;
            }
            return UnidadMedida;
        }



        bool ValidaGUI()
        {
            if (DetallesFormula.Rows.Count == 0)
            {
                if (MessageBox.Show("No se ha agregado ningun insumo a la elaboración de la fórmula.\n¿Desea continuar con el guardado de la fórmula?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return false;
            }
            if (string.IsNullOrEmpty(txtFormula.Text))
            {
                toolTipController1.ShowHint("Debes capturar el nombre de la fórmula", "Este Campo No Puede Quedar en Blanco", txtFormula, DevExpress.Utils.ToolTipLocation.TopRight);
                txtFormula.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                toolTipController1.ShowHint("Debes capturar la cantidad de producción de la fórmula.", "Este Campo No Puede Quedar en Blanco", txtCantidad, DevExpress.Utils.ToolTipLocation.TopRight);
                txtCantidad.Focus();
                return false;
            }
            if (cmbFamilia.EditValue is null)
            {
                toolTipController1.ShowHint("Debes agrupar la fórmula dentro de una familia.", "Este Campo No Puede Quedar Vacío", cmbFamilia, DevExpress.Utils.ToolTipLocation.TopRight);
                cmbFamilia.Focus();
                return false;
            }
            if (cmbUnidadMedida.EditValue is null)
            {
                toolTipController1.ShowHint("Debes capturar la unidad en que se mide la fórmula.", "Este Campo No Puede Quedar Vacío", cmbUnidadMedida, DevExpress.Utils.ToolTipLocation.TopRight);
                cmbUnidadMedida.Focus();
                return false;
            }

            return true;

        }
        FormulasModel AsignaGUIOjeto2()
        {
            return new FormulasModel
            {
                NombreFormula = txtFormula.Text,
                Cantidad = Convert.ToDouble(txtCantidad.Text),
                IdFamilia = Convert.ToInt32(cmbFamilia.EditValue),
                Capacidad = cmbUnidadMedida.Text,
                UnidadMedida = GetUnidadMedida(cmbUnidadMedida.Text),
                CostoTotal = CostoTotal,
                IdFormula = IdFormula
            };

        }
        void AgregarNuevoRegistro(int IdDetalle, int IdInsumo, string Cantidad, string UnidadMedida)
        {
            decimal Costo = 0;
            DataTable TI = new CNInsumos().ConsultaPorId(IdInsumo);
            DataRow row = TI.Rows[0];
            int Moneda = Convert.ToInt32(row["IdMoneda"]);
            if (Moneda == 1)
                Costo = calculaPrecio(row["UnidadMedida"].ToString(), row["PrecioUnitario"].ToString(),
                                        Convert.ToDecimal(Cantidad), UnidadMedida);
            else
            {
                DataTable Factor = new CNTipoDeCambio().ConsultaPorMoneda(Moneda);
                DataRow FactorConversion = Factor.Rows[0];
                decimal Precio = Convert.ToDecimal(FactorConversion["FactorConversion"]) * Convert.ToDecimal(row["PrecioUnitario"]);
                Costo = calculaPrecio(row["UnidadMedida"].ToString(), Precio.ToString(),
                                       Convert.ToDecimal(Cantidad), UnidadMedida);
            }
            if (DetallesFormula.Columns.Count == 0)
            {
                DetallesFormula.Columns.Add("IdDetalle");
                DetallesFormula.Columns.Add("IdInsumo");
                DetallesFormula.Columns.Add("NombreInsumo");
                DetallesFormula.Columns.Add("NombreInterno");
                DetallesFormula.Columns.Add("CostoUnitario");
                DetallesFormula.Columns.Add("Cantidad");
                DetallesFormula.Columns.Add("Precio", typeof(decimal));
                DetallesFormula.Columns.Add("Moneda");
            }

            DataRow Row = DetallesFormula.Rows.Add();
            Row["IdDetalle"] = IdDetalle;
            Row["IdInsumo"] = IdInsumo;
            Row["NombreInsumo"] = row["NombreInsumo"].ToString();
            Row["NombreInterno"] = row["NombreInterno"].ToString();
            Row["CostoUnitario"] = row["PrecioUnitario"].ToString();
            Row["Cantidad"] = Cantidad + " " + UnidadMedida;
            Row["Precio"] = Costo;
            Row["Moneda"] = "MXN";

            CostoTotal = Convert.ToDecimal(DetallesFormula.Compute("SUM(Precio)", String.Empty));

            llenarGrid();
            lblCosto.Text = Math.Round(CostoTotal, 4).ToString();
            //lblCosto.Text = CostoTotal.ToString();

        }
        decimal calculaPrecio(string UnidadMedida, string CostoUnitario, decimal CantidadInsumo, string Unidad)
        {
            decimal Costo = 0.0m;
            decimal CU = Convert.ToDecimal(CostoUnitario);
            switch (UnidadMedida.ToUpper())
            {
                case "KG":
                    switch (Unidad.ToUpper())
                    {
                        case "KILOGRÁMOS":
                            Costo = CU * CantidadInsumo;
                            break;
                        case "GRÁMOS":
                            Costo = (CU / 1000m) * CantidadInsumo;
                            break;
                        case "MILIGRÁMOS":
                            Costo = (CU / 10000m) * CantidadInsumo;
                            break;
                    }
                    break;
                case "L":
                    switch (Unidad.ToUpper())
                    {
                        case "LITROS":
                            Costo = CU * CantidadInsumo;
                            break;
                        case "MILILITROS":
                            Costo = (CU / 1000m) * CantidadInsumo;
                            break;
                    }
                    break;
                default:
                    Costo = CU * CantidadInsumo;
                    break;

            }
            return Costo;
        }
        void llenarGrid()
        {
            gridView1.Columns.Clear();
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.BestFitColumns();
            gridView1.OptionsBehavior.AutoPopulateColumns = false;
            gridView1.OptionsBehavior.Editable = false;
            gridControl1.DataSource = DetallesFormula;
            GridColumn myCol1 = new GridColumn() { Caption = "No.Insumo", Visible = false, FieldName = "IdInsumo" };
            gridView1.Columns.Add(myCol1);
            gridView1.Columns["IdInsumo"].BestFit();
            GridColumn myCol2 = new GridColumn() { Caption = "Nombre Interno", Visible = true, FieldName = "NombreInterno" };
            gridView1.Columns.Add(myCol2);
            gridView1.Columns["NombreInterno"].BestFit();
            if (Estaticos.IdRol == 1)
            {
                GridColumn myCol = new GridColumn() { Caption = "Nombre Insumo", Visible = true, FieldName = "NombreInsumo" };
                gridView1.Columns.Add(myCol);
                gridView1.Columns["NombreInsumo"].BestFit();
            }
            GridColumn myColX = new GridColumn() { Caption = "Costo Unitario", Visible = true, FieldName = "CostoUnitario" };
            gridView1.Columns.Add(myColX);
            gridView1.Columns["CostoUnitario"].BestFit();
            GridColumn myCol3 = new GridColumn() { Caption = "Cantidad", Visible = true, FieldName = "Cantidad" };
            gridView1.Columns.Add(myCol3);
            gridView1.Columns["Cantidad"].BestFit();
            GridColumn myCol4 = new GridColumn() { Caption = "Costo", Visible = true, FieldName = "Precio" };
            gridView1.Columns.Add(myCol4);
            gridView1.Columns["Precio"].BestFit();
            if (myCol4 != null)
            {
                gridView1.Columns["Precio"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["Precio"].DisplayFormat.FormatString = "#.0000";
                gridView1.Columns["Precio"].BestFit();
            }
            GridColumn myCol5 = new GridColumn() { Caption = "Moneda", Visible = true, FieldName = "Moneda" };
            gridView1.Columns.Add(myCol5);
            gridView1.Columns["Moneda"].BestFit();
        }
        void EliminarRegistro()
        {
            try
            {
                DetallesFormula.Rows.RemoveAt(gridView1.GetSelectedRows()[0]);
                CostoTotal = Convert.ToDecimal(DetallesFormula.Compute("SUM(Precio)", String.Empty));
                lblCosto.Text = CostoTotal.ToString();
            }
            catch
            {
                if (DetallesFormula.Rows.Count == 0)
                {
                    CostoTotal = 0.00m;
                    lblCosto.Text = CostoTotal.ToString();
                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtCantidad.Text.Length; i++)
            {
                if (txtCantidad.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 4)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
        private void txtCantInsumo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtCantInsumo.Text.Length; i++)
            {
                if (txtCantInsumo.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 4)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;

        }

        private void cmbInsumos_EditValueChanged(object sender, EventArgs e) => llenarComboUnidadMedidaInsumo();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbInsumos.EditValue != null && !string.IsNullOrEmpty(txtCantInsumo.Text) && cmbUnidadMedidaInsumo.Text != null)
            {
                AgregarNuevoRegistro(0, int.Parse(cmbInsumos.EditValue.ToString()), txtCantInsumo.Text, cmbUnidadMedidaInsumo.Text);
                cmbInsumos.EditValue = null;
                txtCantInsumo.Text = "";
                cmbUnidadMedidaInsumo.EditValue = null;
                cmbInsumos.Focus();
            }
        }
        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(gridControl1, new System.Drawing.Point(e.X, e.Y));
        }
        private void borarInsumoDeLaListaToolStripMenuItem_Click(object sender, EventArgs e) => EliminarRegistro();
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                EliminarRegistro();
        }
        private void frmFormulasV2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAdd.PerformClick();
        }


        #region Menú
        private void btnBaja_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult ds = MessageBox.Show("¿Estas seguro que deseas eliminar '" + txtFormula.Text + "' ?",
                           "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ds == DialogResult.Yes)
                if (new CNProductos().ConsultaPorFormula(IdFormula).Rows.Count == 0)
                {
                    new CNFormulas().Borrar(IdFormula);
                    Close();
                }
                else
                    MessageBox.Show("No puedes dar de baja esta fórmula porque tiene productos activos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmImpDetallesFormulas frm = new frmImpDetallesFormulas(new Reporteador().PrintAFormula(new int[] { IdFormula }), "U");
                frm.crystalReportViewer1.PrintReport();
                frm.Dispose();
            }
            catch
            {
            }
        }

        private void btnGuardar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ValidaGUI())
            {
                new CNFormulas().Guardar(Estaticos.IdUsuario,AsignaGUIOjeto2(), DetallesFormula);
                Close();
            }
        }



        #endregion

        private void lblCosto_TextChanged(object sender, EventArgs e)
        {
            while (lblCosto.Width < TextRenderer.MeasureText(lblCosto.Text, new Font(lblCosto.Font.FontFamily, lblCosto.Font.Size, lblCosto.Font.Style)).Width)
            {
                lblCosto.Font = new Font(lblCosto.Font.FontFamily, lblCosto.Font.Size - 0.5f, lblCosto.Font.Style);
            }
        }
    }
}
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using System;
using System.Data;
using DevExpress.Utils;
using Entidades;
using CapaNegocios;

namespace SAF_PROLIZA
{
    public partial class frmDetallesFormulas : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string UnidadMedida = "";
        decimal Cantidad = 0;

        DataTable T = new DataTable();
        int[] Detalles = new int[100];
        bool Actualizar = false;

        #region "Metodos"
        DetallesFormulasModel AsignaGUIObjeto(int i)
        {
            string cad = gridView1.GetRowCellValue(i, "Cantidad").ToString();
            string[] partes = cad.Split(' ');
            cad = gridView1.GetRowCellValue(i, "Precio").ToString().Remove(0, 2);
            cad = cad.Remove(cad.Length - 6);
            return new DetallesFormulasModel
            {
                IdDetalle = Convert.ToInt32(T.Rows[i]["IdDetalle"]),
                IdFormula = int.Parse(lblIdFormula.Text),
                IdInsumo = int.Parse(T.Rows[i]["IdInsumo"].ToString()),
                CantidadInsumo = decimal.Parse(partes[0]),
                UnidadMedidaInsumo = partes[1].ToString(),
                CostoInsumo = decimal.Parse(cad)
            };
        }
        InsumosModel AsignaDatosObjetoInsumo()
        {
            return new InsumosModel
            {
                IdFamilia = 1,
                IdMoneda = 1,
                IdProveedor = 1,
                NombreInsumo = this.txtFormula.Text,
                NombreInterno = this.txtFormula.Text,
                UnidadMedida = UnidadMedida,
                PrecioUnitario = Convert.ToDouble(lblCosto.Text),
                TotalCompraMX = 1000
            };
        }
        void CrearInsumo()
        {

            //Objetos.Insumos.IdFamilia = 1;
            //Objetos.Insumos.IdMoneda = 1;
            //Objetos.Insumos.IdProveedor = 1;
            //Objetos.Insumos.NombreInsumo = this.txtFormula.Text;
            //Objetos.Insumos.NombreInterno = this.txtFormula.Text;
            //Objetos.Insumos.UnidadMedida = UnidadMedida;
            //Objetos.Insumos.PrecioUnitario = Convert.ToDouble(lblCosto.Text) / Convert.ToDouble(Cantidad);
            //Objetos.Insumos.TotalCompraMX = 1000;
            //Objetos.Insumos.Guardar(Objetos.Insumos);
            new CNInsumos().Guardar(AsignaDatosObjetoInsumo());
        }

        double calculaPrecio(string UnidadMedida, string CostoUnitario, double CantidadInsumo, string Unidad)
        {
            double Costo = 0.0;
            double CU = double.Parse(CostoUnitario);
            switch (UnidadMedida.ToUpper())
            {
                case "KG":
                    switch (Unidad.ToUpper())
                    {
                        case "KILOGRÁMOS":
                            Costo = CU * CantidadInsumo;
                            break;
                        case "GRÁMOS":
                            Costo = (CU / 1000) * CantidadInsumo;
                            break;
                        case "MILIGRÁMOS":
                            Costo = (CU / 10000) * CantidadInsumo;
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
                            Costo = (CU / 1000) * CantidadInsumo;
                            break;
                    }
                    break;
                default:
                    Costo = CU * CantidadInsumo;
                    break;

            }
            return Costo;
        }
        void llenarComboInsumos()
        {
            Objetos Objetos = new Objetos();
            cmbInsumos.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreInterno"));
            if (Estaticos.IdRol == 1)
                cmbInsumos.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreInsumo"));
            cmbInsumos.Properties.ValueMember = "IdInsumo";
            cmbInsumos.Properties.DisplayMember = "NombreInsumo";
            //cmbInsumos.Properties.DataSource = Objetos.Insumos.ConsultarInsumosIngredientes().Tables["Insumos"];
            cmbInsumos.Properties.DataSource = new CNInsumos().ConsultaInsumosIngredientes();
        }
        void llenarComboUnidadMedida()
        {
            if (cmbInsumos.EditValue != null)
            {
                //DataTable TI = I.ConsultarInsumoPorId(int.Parse(cmbInsumos.EditValue.ToString())).Tables["Insumos"];
                DataTable TI = new CNInsumos().ConsultaPorId(int.Parse(cmbInsumos.EditValue.ToString()));
                DataRow row = TI.Rows[0];

                if (row["UnidadMedida"].ToString().StartsWith("K"))
                {
                    cmbUnidadMedida.Properties.ValueMember = cmbUnidadMedida.Properties.DisplayMember = "Column";
                    cmbUnidadMedida.Properties.DataSource = new string[3] { "Kilográmos", "grámos", "miligrámos" };
                }
                else if (row["UnidadMedida"].ToString().StartsWith("L"))
                {
                    cmbUnidadMedida.Properties.ValueMember = cmbUnidadMedida.Properties.DisplayMember = "Column";
                    cmbUnidadMedida.Properties.DataSource = new string[2] { "Litros", "Mililitros" };
                }
                else
                {
                    cmbUnidadMedida.Properties.ValueMember = cmbUnidadMedida.Properties.DisplayMember = "Column";
                    cmbUnidadMedida.Properties.DataSource = new string[1] { "Piezas" };
                    cmbUnidadMedida.ItemIndex = 0;
                }
            }
        }
        void llenarGrid()
        {
            gridView1.Columns.Clear();
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.BestFitColumns();
            gridView1.OptionsBehavior.AutoPopulateColumns = false;
            gridView1.OptionsBehavior.Editable = false;
            gridControl1.DataSource = T;
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
            gridView1.Columns["Cantidad"].OptionsColumn.AllowEdit = true;
            gridView1.Columns.Add(myCol3);
            gridView1.Columns["Cantidad"].BestFit();
            GridColumn myCol4 = new GridColumn() { Caption = "Costo", Visible = true, FieldName = "Precio" };
            gridView1.Columns.Add(myCol4);
            gridView1.Columns["Precio"].BestFit();
            if (myCol4 != null)
            {
                gridView1.Columns["Precio"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["Precio"].DisplayFormat.FormatString = "#.00";
                gridView1.Columns["Precio"].BestFit();
            }

        }
        private void AgregarNuevoRegistro(int IdDetalle, int IdInsumo, string Cantidad, string UnidadMedida)
        {
            double Costo = 0;
            //DataTable TI = I.ConsultarInsumoPorId(IdInsumo).Tables["Insumos"];
            DataTable TI = new CNInsumos().ConsultaPorId(IdInsumo);
            DataRow row = TI.Rows[0];
            int Moneda = Convert.ToInt32(row["IdMoneda"]);
            if (Moneda == 1)
            {
                Costo = calculaPrecio(row["UnidadMedida"].ToString(), row["PrecioUnitario"].ToString(),
                                        double.Parse(Cantidad), UnidadMedida);
            }
            else
            {
                //DataTable Factor = Objetos.TipoDeCambio.ConsultarPorMoneda(Moneda).Tables["TipoDeCambio"];
                DataTable Factor = new CNTipoDeCambio().ConsultaPorMoneda(Moneda);
                DataRow FactorConversion = Factor.Rows[0];
                double a = Double.Parse(FactorConversion["FactorConversion"].ToString());
                double b = double.Parse(row["PrecioUnitario"].ToString());
                double Precio = Double.Parse(FactorConversion["FactorConversion"].ToString()) * double.Parse(row["PrecioUnitario"].ToString());
                Costo = calculaPrecio(row["UnidadMedida"].ToString(), Precio.ToString(),
                                        double.Parse(Cantidad), UnidadMedida);
            }
            if (T.Columns.Count == 0)
            {
                T.Columns.Add("IdDetalle");
                T.Columns.Add("IdInsumo");
                T.Columns.Add("NombreInsumo");
                T.Columns.Add("NombreInterno");
                T.Columns.Add("CostoUnitario");
                T.Columns.Add("Cantidad");
                T.Columns.Add("Precio");
            }

            DataRow Row = T.Rows.Add();
            Row["IdDetalle"] = IdDetalle;
            Row["IdInsumo"] = IdInsumo;
            Row["NombreInsumo"] = row["NombreInsumo"].ToString();
            Row["NombreInterno"] = row["NombreInterno"].ToString();
            Row["CostoUnitario"] = row["PrecioUnitario"].ToString();
            Row["Cantidad"] = Cantidad + " " + UnidadMedida;
            Row["Precio"] = "$ " + Costo + " Pesos";
            llenarGrid();
            lblCosto.Text = (double.Parse(lblCosto.Text) + Costo).ToString();

        }
        void EliminarRegistro(int[] Posicion)
        {
            for (int i = 0; i < Posicion.Length; i++)
            {
                string cad = gridView1.GetRowCellValue(Posicion[i], "Precio").ToString().Remove(0, 2);
                cad = cad.Remove(cad.Length - 6);
                lblCosto.Text = (double.Parse(lblCosto.Text) - double.Parse(cad)).ToString();
                T.Rows[Posicion[i]].Delete();
            }
            llenarGrid();
        }
        void Guardar()
        {
            for (int i = 0; i < T.Rows.Count; i++)
                new CNDetallesFormulas().Guardar(AsignaGUIObjeto(i));

            if (this.txtFamilia.Text == "Formula Insumo")
            {
                CrearInsumo();
            }
        }
        private void cmbInsumos_EditValueChanged(object sender, EventArgs e)
        {
            llenarComboUnidadMedida();
        }

        string AsignarUnidadMedida(string Capacidad)
        {
            string UnidadMedida = "";
            switch (Capacidad.ToLower())
            {
                case "kilográmos":
                    UnidadMedida = "K";
                    break;
                case "grámos":
                    UnidadMedida = "K";
                    break;
                case "miligrámos":
                    UnidadMedida = "K";
                    break;
                case "litros":
                    UnidadMedida = "L";
                    break;
                case "mililitros":
                    UnidadMedida = "L";
                    break;
            }
            return UnidadMedida;
        }
        FormulasModel AsignaObjetoFormula(DataTable T)
        {
            return new FormulasModel
            {
                Activo = true,
                Cantidad = Convert.ToDouble(T.Rows[0]["Cantidad"].ToString()),
                Capacidad = (T.Rows[0]["Capacidad"].ToString()),
                CostoTotal = Convert.ToDecimal(T.Rows[0]["CostoTotal"].ToString()),
                IdFamilia = Convert.ToInt32(T.Rows[0]["IdFamilia"].ToString()),
                UnidadMedida = AsignarUnidadMedida(T.Rows[0]["Capacidad"].ToString()),
                NombreFormula = (T.Rows[0]["NombreFormula"].ToString()),
            };
        }

        #endregion
        public frmDetallesFormulas(int IdFormula)
        {
            InitializeComponent();
            llenarComboInsumos();
            cmbInsumos.Focus();
            if (IdFormula > 0)
            {
                ribbonPageGroup1.Visible = true;
                Actualizar = true;
                DataTable Formula = new CNFormulas().ConsultaPorId(IdFormula);
                lblIdFormula.Text = Formula.Rows[0]["IdFormula"].ToString();
                txtFormula.Text = Formula.Rows[0]["NombreFormula"].ToString();
                txtFamilia.Text = Formula.Rows[0]["NombreFamilia"].ToString();
                txtCantidadFormula.Text = Formula.Rows[0]["Cantidad"] + " " + Formula.Rows[0]["Capacidad"];
                Cantidad = Convert.ToDecimal(Formula.Rows[0]["Cantidad"]);
                UnidadMedida = Formula.Rows[0]["UnidadMedida"].ToString();
                lblCosto.Text = "0.00"; // T.Rows[0]["CostoTotal"].ToString();
                foreach (DataRow item in new CNDetallesFormulas().ConsultaPorFormula(IdFormula).Rows)
                    AgregarNuevoRegistro(Convert.ToInt32(item["IdDetalle"]), Convert.ToInt32(item["IdInsumo"]), item["CantidadInsumo"].ToString(), item["UnidadMedidaInsumo"].ToString());
            }
        }

        #region "botones"
        private void btnGuardar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Actualizar)
            {
                Guardar();
                this.Close();
            }
            else
            {
                DataTable Form = new CNFormulas().ConsultaPorId(Convert.ToInt32(lblIdFormula.Text));
                int FormulaNueva = new ActualizaFormulas().ActualizarFormula(Convert.ToInt32(lblIdFormula.Text), AsignaObjetoFormula(Form));
                lblIdFormula.Text = FormulaNueva.ToString();
                Guardar();
                Close();
            }

        }
        #endregion


        #region "Eventos de teclas"
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdInsumo") != null)
                    EliminarRegistro(gridView1.GetSelectedRows());
        }
        private void frmDetallesFormulas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAdd.PerformClick();
        }


        #endregion

        private void btnBorrar_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult ds = MessageBox.Show("¿Estas seguro que deseas eliminar '" + txtFormula.Text + "' ?",
                            "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ds == DialogResult.Yes)
            {
                if (new CNProductos().ConsultaPorFormula(Convert.ToInt32(this.lblIdFormula.Text)).Rows.Count == 0)
                {
                    new CNFormulas().Borrar(Convert.ToInt32(this.lblIdFormula.Text));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No puedes dar de baja esta formula porque tiene productos activos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int[] idformula = { Convert.ToInt32(lblIdFormula.Text) };
                frmImpDetallesFormulas frm = new frmImpDetallesFormulas(new Reporteador().PrintAFormula(idformula), "U");
                frm.crystalReportViewer1.PrintReport();
            }
            catch
            {
            }
        }

        private void txtCantInsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !char.IsPunctuation(e.KeyChar) && (e.KeyChar != (char)Keys.Tab))
            //{
            //    e.Handled = true;
            //}
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

        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(gridControl1, new System.Drawing.Point(e.X, e.Y));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbInsumos.Text != "[Vacío]" && txtCantInsumo.Text != "" && cmbUnidadMedida.Text != "[Vacío]")
            {
                AgregarNuevoRegistro(0, int.Parse(cmbInsumos.EditValue.ToString()), txtCantInsumo.Text, cmbUnidadMedida.Text);
                cmbInsumos.EditValue = null;
                txtCantInsumo.Text = "";
                cmbUnidadMedida.EditValue = null;
                cmbInsumos.Focus();
            }
        }

        private void borarInsumoDeLaListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdInsumo") != null)
                EliminarRegistro(gridView1.GetSelectedRows());
        }
    }
}
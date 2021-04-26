using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using CapaNegocios;
using Entidades;
using System.Collections.Generic;
using System.Configuration;

namespace SAF_PROLIZA
{
    public partial class frmProductosTerminados : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        bool encendido = false; // para controlar el evento editChanged del cmbFormulas. Si esta apagado Ignora ese evento.
        bool Guarda = true;
        int Id = 0;
        DataTable T = new DataTable();
        Dictionary<int, int> Borrados = new Dictionary<int, int>();
        #region "Metodos"
        double Costo = 0.00;
        private readonly CNFormulas cnFormulas;
        private readonly CNProductos cnProductos;
        private readonly CNInsumos cnInsumos;
        private readonly CNDetallesProductos cnDetallesProductos;

        void Limpiar()
        {
            encendido = false;
            cmbFormula.EditValue = null;
            txtNombre.Text = "";
            txtCosto.Text = "";
            txtCantidad.Text = "";
            cmbUnidadMedida.EditValue = null;
            T.Clear();
            llenarGrid(T);
            cmbDetalles.EditValue = null;
            lblCosto.Text = "0.00";
            HabilitarCampos(false);
            encendido = true;
        }
        void llenarComboFormulas()
        {
            cmbFormula.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreFormula"));
            cmbFormula.Properties.ValueMember = "IdFormula";
            cmbFormula.Properties.DisplayMember = "NombreFormula";
            cmbFormula.Properties.DataSource = cnFormulas.ConsultaGeneral();
        }
        void llenarComboInsumos()
        {
            cmbDetalles.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreInsumo"));
            cmbDetalles.Properties.ValueMember = "IdInsumo";
            cmbDetalles.Properties.DisplayMember = "NombreInsumo";
            //cmbDetalles.Properties.DataSource = Objetos.Insumos.ConsultarInsumosDeEmpacado().Tables["Insumos"];
            cmbDetalles.Properties.DataSource = cnInsumos.ConsultaInsumosDeEmpacado();
        }
        void autoCompleteTextBox()
        {
            DataTable dt = cnProductos.ConsultaPorFormula(int.Parse(cmbFormula.EditValue.ToString()));
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                collection.Add(Convert.ToString(row["NombreProducto"]));
            }
            txtNombre.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtNombre.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNombre.MaskBox.AutoCompleteCustomSource = collection;

        }
        void HabilitarCampos(bool estado)
        {
            txtCantidad.Properties.ReadOnly = !estado;
            //txtNombre.Properties.ReadOnly = !estado;
            txtCosto.Properties.ReadOnly = !estado;
            cmbDetalles.Properties.ReadOnly = !estado;
            cmbUnidadMedida.Properties.ReadOnly = !estado;
        }
        bool ValidaGUI()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingresa un nombre de producto");
                return false;
            }
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingresa un nombre de producto");
                return false;
            }
            if (txtCantidad.Text == "")
            {
                MessageBox.Show("Ingresa la cantidad del producto");
                return false;
            }

            if (T.Rows.Count == 0)
            {
                MessageBox.Show("Debes proporcionar por lo menos un detalle de envasado.");
                return false;
            }
            return true;
        }
        void llenarGrid(DataTable T)
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
            GridColumn myCol2 = new GridColumn() { Caption = "NombreInsumo", Visible = true, FieldName = "NombreInsumo" };
            gridView1.Columns.Add(myCol2);
            gridView1.Columns["NombreInsumo"].BestFit();
            GridColumn myCol3 = new GridColumn() { Caption = "Cantidad", Visible = false, FieldName = "Cantidad" };
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
        public void llenarDatos(int Id)
        {
            frmProductosTerminados frm = new frmProductosTerminados(false);
            //DataTable dt = Objetos.Productos.ConsultarProductoPorId(Id).Tables["ProductosTerminados"];
            DataTable dt = cnProductos.ConsultaConsultaPorId(Id);
            if (dt.Rows.Count != 0)
            {
                frm.cmbFormula.Properties.ReadOnly = true;
                frm.Guarda = false;
                DataRow row = dt.Rows[0];
                frm.Id = (Convert.ToInt32(row["IdProducto"]));
                frm.txtNombre.Text = (Convert.ToString(row["NombreProducto"]));
                frm.cmbFormula.EditValue = (Convert.ToInt32(row["IdFormula"]));
                frm.txtCantidad.Text = (Convert.ToString(row["Cantidad"]));
                frm.txtUM.Visible = true;
                frm.txtUM.Text = (Convert.ToString(row["UnidadMedida"]));
                frm.txtCosto.Text = (Convert.ToString(row["CostoUnitario"]));
                frm.lblCosto.Text = (Convert.ToString(row["CostoUnitario"]));
                frm.cmbDetalles.Enabled = true;
                frm.cmbDetalles.Properties.ReadOnly = false;
                frm.encendido = true;
                frm.btnBorrar.Links[0].Visible = true;
                dt = cnDetallesProductos.ConsultaDetallesPorProducto(Id);
                for (int i = 0; i < dt.Rows.Count; i++)
                    frm.AgregarNuevoRegistro(Convert.ToInt32(dt.Rows[i]["IdDetalle"]), Convert.ToInt32(dt.Rows[i]["IdInsumo"]));
                frm.llenarGrid(frm.T);
                this.T = frm.T;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Producto no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        void llenarComboUnidadMedida()
        {
            DataTable TI = cnFormulas.ConsultaPorId(Convert.ToInt32(cmbFormula.EditValue.ToString()));

            if (TI.Rows.Count != 0)
            {
                DataRow row = TI.Rows[0];
                if (row["UnidadMedida"].ToString() == "K")
                {
                    cmbUnidadMedida.Properties.ValueMember = cmbUnidadMedida.Properties.DisplayMember = "Column";
                    cmbUnidadMedida.Properties.DataSource = new string[3] { "Kilográmos", "grámos", "miligrámos" };
                }
                else
                {
                    cmbUnidadMedida.Properties.ValueMember = cmbUnidadMedida.Properties.DisplayMember = "Column";
                    cmbUnidadMedida.Properties.DataSource = new string[2] { "Litros", "Mililitros" };
                }
            }
            else
            {
                cmbUnidadMedida.Properties.ValueMember = cmbUnidadMedida.Properties.DisplayMember = "Column";
                cmbUnidadMedida.Properties.DataSource = new string[3 + 2] { "Kilográmos", "grámos", "miligrámos", "Litros", "Mililitros" };
            }


        }
        void EliminarRegistro(int[] Posicion)
        {
            try
            {
                for (int i = 0; i < Posicion.Length; i++)
                {
                    Borrados.Add(Convert.ToInt32(T.Rows[Posicion[i]]["IdDetalle"]), Convert.ToInt32(T.Rows[Posicion[i]]["IdInsumo"]));
                    string cad = gridView1.GetRowCellValue(Posicion[i], "Precio").ToString().Remove(0, 2);
                    cad = cad.Remove(cad.Length - 6);
                    lblCosto.Text = (double.Parse(lblCosto.Text) - double.Parse(cad)).ToString();
                    T.Rows[Posicion[i]].Delete();
                }
                llenarGrid(T);
            }
            catch
            {
            }
        }
        void GuardarDetalle()
        {
            for (int i = 0; i < T.Rows.Count; i++)
                cnDetallesProductos.Guardar(AsignaGUIObjetoDetalleProducto(i));
        }
        void ActualizarDetalle()
        {
            foreach (KeyValuePair<int, int> item in Borrados)
                cnDetallesProductos.Borrar(new DetallesProductosModel { IdDetalle = item.Key, IdInsumo = item.Value });

            for (int i = 0; i < T.Rows.Count; i++)
            {
                if (Convert.ToInt32(T.Rows[i]["IdDetalle"]) == -1)
                    cnDetallesProductos.Guardar(AsignaGUIObjetoDetalleProducto(i));
                else
                    cnDetallesProductos.Actualizar(AsignaGUIObjetoDetalleProducto(i));
            }
        }
        private void AgregarNuevoRegistro(int IdDetalle, int IdInsumo)
        {
            //BLL.ActualizadorPrecios Calculador = new BLL.ActualizadorPrecios();
            //DataTable TI = Objetos.Insumos.ConsultarInsumoPorId(IdInsumo).Tables["Insumos"];
            DataTable TI = cnInsumos.ConsultaPorId(IdInsumo);

            DataRow row = TI.Rows[0];
            if (Convert.ToInt32(row["IdMoneda"]) == 2)
            {
                Costo = Estaticos.dolar * Convert.ToDouble(row["PrecioUnitario"]);
            }
            else
            {
                Costo = double.Parse(row["PrecioUnitario"].ToString());
            }

            if (T.Columns.Count == 0)
            {

                T.Columns.Add("IdDetalle");
                T.Columns.Add("IdInsumo");
                T.Columns.Add("NombreInsumo");
                //T.Columns.Add("Cantidad");
                //T.Columns.Add("UnidadMedida");
                T.Columns.Add("Precio");
                T.Columns.Add("Costo");
            }

            DataRow Row = T.Rows.Add();
            Row["IdDetalle"] = IdDetalle;
            Row["IdInsumo"] = IdInsumo;
            Row["NombreInsumo"] = row["NombreInsumo"].ToString();
            //Row["UnidadMedida"] = UnidadMedida;
            //Row["Cantidad"] = Cantidad + " " + UnidadMedida;
            Row["Precio"] = "$ " + Costo + " Pesos";
            Row["Costo"] = Costo;
            llenarGrid(T);
            lblCosto.Text = (double.Parse(lblCosto.Text) + Costo).ToString();

        }
        #endregion
        ProductosModel AsignaGUIObjetoProducto()
        {
            return new ProductosModel
            {
                IdProducto = Guarda ? 1 : Id,
                UnidadMedida = Guarda ? cmbUnidadMedida.Text : txtUM.Text,
                IdFormula = Convert.ToInt32(cmbFormula.EditValue.ToString()),
                Cantidad = Convert.ToDecimal(txtCantidad.Text),
                CostoUnitario = Convert.ToDecimal(txtCosto.Text),
                CostoTotalProducto = Convert.ToDecimal(lblCosto.Text),
                NombreProducto = txtNombre.Text,
                IdUsuario = Estaticos.IdUsuario,
                Activo = true
            };
        }
        DetallesProductosModel AsignaGUIObjetoDetalleProducto(int i)
        {
            return new DetallesProductosModel
            {
                IdDetalle = int.Parse(T.Rows[i]["IdDetalle"].ToString()),
                IdInsumo = int.Parse(T.Rows[i]["IdInsumo"].ToString()),
                CostoInsumo = Convert.ToDecimal(T.Rows[i]["Costo"].ToString()),
                IdProducto = Id
            };
        }
        public frmProductosTerminados(bool encendido)
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["sdprolizaEntitiessp"].ConnectionString;
            cnFormulas = new CNFormulas(connectionString);
            cnProductos = new CNProductos(connectionString);
            cnInsumos = new CNInsumos(connectionString, -1, null, false, 0);
            cnDetallesProductos = new CNDetallesProductos(connectionString);
            HabilitarCampos(false);
            llenarComboFormulas();
            llenarComboInsumos();
            this.encendido = encendido;
            btnBorrar.Links[0].Visible = false;
        }
        private void cmbFormula_EditValueChanged(object sender, EventArgs e)
        {
            if (encendido)
            {
                llenarComboUnidadMedida();
                autoCompleteTextBox();
                HabilitarCampos(true);
            }
        }
        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (cmbUnidadMedida.Text != "[Vacío]" && txtCantidad.Text != "")
            {
                if (double.Parse(lblCosto.Text) != 0.00)
                {
                    if (double.Parse(lblCosto.Text) != 0.00)
                    {
                        double _Costo = 0;
                        if (string.IsNullOrEmpty(txtCosto.Text))
                        {
                            _Costo = 0;
                        }
                        else
                        {
                            _Costo = Convert.ToDouble(txtCosto.Text);
                        }
                        lblCosto.Text = (Convert.ToDouble(lblCosto.Text) - _Costo).ToString();
                    }

                    //ActualizadorPrecios Calculador = new ActualizadorPrecios();
                    //DataTable T = Objetos.Formulas.ConsultarFormulaPorId(Convert.ToInt32(cmbFormula.EditValue.ToString())).Tables["Formulas"];
                    DataTable Formula = cnFormulas.ConsultaPorId(Convert.ToInt32(cmbFormula.EditValue.ToString()));
                    //double Precio = Calculador.calculaPrecioProducto(T.Rows[0]["UnidadMedida"].ToString(), Convert.ToDouble(T.Rows[0]["CostoTotal"].ToString()), Convert.ToDouble(T.Rows[0]["Cantidad"].ToString()), Convert.ToDouble(txtCantidad.Text), cmbUnidadMedida.Text);
                    decimal CostoMinimoFormula = Formula.Rows[0]["UnidadMedida"].ToString().Equals("K") ?
                        (Convert.ToDecimal(Formula.Rows[0]["CostoTotal"]) / (Formula.Rows[0]["Capacidad"].ToString().ToUpper().StartsWith("K") ? ConversorUnidades.Kilos_Miligramos(Convert.ToDecimal(Formula.Rows[0]["Cantidad"])) :
                                                                             Formula.Rows[0]["Capacidad"].ToString().ToUpper().StartsWith("G") ? ConversorUnidades.Gramos_Miligramos(Convert.ToDecimal(Formula.Rows[0]["Cantidad"])) :
                                                                              Convert.ToDecimal(Formula.Rows[0]["Cantidad"]))) :
                                      (Convert.ToDecimal(Formula.Rows[0]["CostoTotal"]) / (Formula.Rows[0]["Capacidad"].ToString().ToUpper().StartsWith("L") ? ConversorUnidades.Litros_Mililitros(Convert.ToDecimal(Formula.Rows[0]["Cantidad"]))
                                      : Convert.ToDecimal(Formula.Rows[0]["Cantidad"])));

                    decimal CostoGranel = CostoMinimoFormula *
                                           (cmbUnidadMedida.Text.ToUpper().StartsWith("L") ? ConversorUnidades.Litros_Mililitros(Convert.ToDecimal(txtCantidad.Text)) :
                                          cmbUnidadMedida.Text.ToUpper().StartsWith("K") ? ConversorUnidades.Kilos_Miligramos(Convert.ToDecimal(txtCantidad.Text)) :
                                          cmbUnidadMedida.Text.ToUpper().StartsWith("G") ? ConversorUnidades.Gramos_Miligramos(Convert.ToDecimal(txtCantidad.Text)) :
                                           Convert.ToDecimal(txtCantidad.Text));


                    txtCosto.Text = CostoGranel.ToString();
                    lblCosto.Text = (decimal.Parse(lblCosto.Text) + CostoGranel).ToString();
                }
            }
        }
        private void txtUnidadMedida_Leave(object sender, EventArgs e)
        {
            if (cmbUnidadMedida.EditValue != null && txtCantidad.Text != "")
            {
                if (double.Parse(lblCosto.Text) != 0.00)
                {
                    double _Costo = 0;
                    if (string.IsNullOrEmpty(txtCosto.Text))
                    {
                        _Costo = 0;
                    }
                    else
                    {
                        _Costo = Convert.ToDouble(txtCosto.Text);
                    }
                    lblCosto.Text = (Convert.ToDouble(lblCosto.Text) - _Costo).ToString();
                }

                //ActualizadorPrecios Calculador = new ActualizadorPrecios();
                //DataTable T = Objetos.Formulas.ConsultarFormulaPorId(Convert.ToInt32(cmbFormula.EditValue.ToString())).Tables["Formulas"];
                DataTable Formula = cnFormulas.ConsultaPorId(Convert.ToInt32(cmbFormula.EditValue.ToString()));
                //double Precio = Calculador.calculaPrecioProducto(T.Rows[0]["UnidadMedida"].ToString(), Convert.ToDouble(T.Rows[0]["CostoTotal"].ToString()), Convert.ToDouble(T.Rows[0]["Cantidad"].ToString()), Convert.ToDouble(txtCantidad.Text), cmbUnidadMedida.Text);
                decimal CostoMinimoFormula = Formula.Rows[0]["UnidadMedida"].ToString().Equals("K") ?
                    (Convert.ToDecimal(Formula.Rows[0]["CostoTotal"]) / (Formula.Rows[0]["Capacidad"].ToString().ToUpper().StartsWith("K") ? ConversorUnidades.Kilos_Miligramos(Convert.ToDecimal(Formula.Rows[0]["Cantidad"])) :
                                                                         Formula.Rows[0]["Capacidad"].ToString().ToUpper().StartsWith("G") ? ConversorUnidades.Gramos_Miligramos(Convert.ToDecimal(Formula.Rows[0]["Cantidad"])) :
                                                                          Convert.ToDecimal(Formula.Rows[0]["Cantidad"]))) :
                                  (Convert.ToDecimal(Formula.Rows[0]["CostoTotal"]) / (Formula.Rows[0]["Capacidad"].ToString().ToUpper().StartsWith("L") ? ConversorUnidades.Litros_Mililitros(Convert.ToDecimal(Formula.Rows[0]["Cantidad"]))
                                  : Convert.ToDecimal(Formula.Rows[0]["Cantidad"])));

                decimal CostoGranel = CostoMinimoFormula *
                                       (cmbUnidadMedida.Text.ToUpper().StartsWith("L") ? ConversorUnidades.Litros_Mililitros(Convert.ToDecimal(txtCantidad.Text)) :
                                      cmbUnidadMedida.Text.ToUpper().StartsWith("K") ? ConversorUnidades.Kilos_Miligramos(Convert.ToDecimal(txtCantidad.Text)) :
                                      cmbUnidadMedida.Text.ToUpper().StartsWith("G") ? ConversorUnidades.Gramos_Miligramos(Convert.ToDecimal(txtCantidad.Text)) :
                                       Convert.ToDecimal(txtCantidad.Text));


                txtCosto.Text = CostoGranel.ToString();
                lblCosto.Text = (decimal.Parse(lblCosto.Text) + CostoGranel).ToString();
            }
        }
        private void frmProductosTerminados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAdd.PerformClick();
        }
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                borrarEsteInsumoToolStripMenuItem.PerformClick();
        }
        private void btnBorrar_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult ds = MessageBox.Show("¿Estas seguro que deseas eliminar '" + txtNombre.Text + "' ?",
                            "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ds == DialogResult.Yes)
            {
                //Objetos.Productos.DarDeBajaPorId(this.Id);
                cnProductos.Borrar(Id);
                this.Close();
            }
        }
        private void btnGuardar_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidaGUI())
            {
                //AsignaGUIObjetoProducto();
                //string msj = "";
                if (Guarda)
                {

                    //msj = Objetos.Productos.Guardar(Objetos.Productos);
                    Id = cnProductos.Guardar(AsignaGUIObjetoProducto());
                    GuardarDetalle();
                    Limpiar();
                }
                else
                {
                    //cnProductos.Borrar(Id);
                    cnProductos.Actualizar(AsignaGUIObjetoProducto());
                    ActualizarDetalle();
                    Limpiar();
                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarNuevoRegistro(-1, Convert.ToInt32(cmbDetalles.EditValue.ToString()));
                cmbDetalles.EditValue = null;
            }
            catch
            {
            }
        }

        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(gridControl1, new System.Drawing.Point(e.X, e.Y));
        }

        private void borrarEsteInsumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarRegistro(gridView1.GetSelectedRows());
            }
            catch { }

        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtCosto.Text.Length; i++)
            {
                if (txtCosto.Text[i] == '.')
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
    }
}
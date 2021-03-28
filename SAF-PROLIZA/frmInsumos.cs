using CapaNegocios;
using DevExpress.XtraBars;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace SAF_PROLIZA
{
    public partial class frmInsumos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        UpdatePrices updatePrices = new UpdatePrices();
        double PU = 0; //Salvar el Precio Unitario de la consulta
        bool Guardar = true; //SI la consuta devuelve algo, se convierte a false y no guarda, actualiza.
        int Id = 1;
        #region "Métodos"

        public void LlenarDatos(int Id)
        {
            //DataRow row = Objetos.Insumos.ConsultarInsumoPorId(Id).Tables["Insumos"].Rows[0];
            DataRow row = new CNInsumos().ConsultaPorId(Id).Rows[0];
            frmInsumos frm = new frmInsumos();
            frm.Guardar = false;
            frm.Id = Convert.ToInt32(row["IdInsumo"]);
            frm.cmbProveedor.EditValue = Convert.ToInt32(row["IdProveedor"]);
            frm.txtNombreInsumo.Text = Convert.ToString(row["NombreInsumo"]);
            frm.txtNombreInterno.Text = Convert.ToString(row["NombreInterno"]);
            frm.txtPrecioUnitaio.Text = Convert.ToString(row["PrecioUnitario"]);
            frm.PU = Convert.ToDouble(frm.txtPrecioUnitaio.Text);
            frm.cmbFamilia.EditValue = Convert.ToInt32(row["IdFamilia"]);
            frm.cmbMoneda.EditValue = Convert.ToInt32(row["IdMoneda"]);
            if (row["UnidadMedida"].ToString().StartsWith("K"))
                frm.cmbUnidadMedida.EditValue = "Kilográmos";
            else if (row["UnidadMedida"].ToString().StartsWith("L"))
                frm.cmbUnidadMedida.EditValue = "Litros";
            else
                frm.cmbUnidadMedida.EditValue = "Piezas";
            //frm.cmbUnidadMedida.ReadOnly = true;
            frm.btnBorrar.Links[0].Visible = true;
            frm.ShowDialog();
        }

        void autoCompleteTextBox()
        {
            //DataTable dt = Insumos.ConsultarInsumoPorProveedor(int.Parse(cmbProveedor.EditValue.ToString())).Tables["Insumos"];
            if (cmbProveedor.EditValue == null)
                return;
            DataTable dt = new CNInsumos().ConsultaPorProveedor(int.Parse(cmbProveedor.EditValue.ToString()));
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                collection.Add(Convert.ToString(row["NombreInsumo"]));
            }
            txtNombreInsumo.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtNombreInsumo.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNombreInsumo.MaskBox.AutoCompleteCustomSource = collection;
        }
        void llenarComboProveedores()
        {
            cmbProveedor.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreProveedor"));
            cmbProveedor.Properties.ValueMember = "IdProveedor";
            cmbProveedor.Properties.DisplayMember = "NombreProveedor";
            //cmbProveedor.Properties.DataSource = Proveedores.ConsultarProveedores().Tables["Proveedores"];
            cmbProveedor.Properties.DataSource = new CNProveedores().ConsultaGeneral();
        }
        void llenarComboMonedas()
        {
            cmbMoneda.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreMoneda"));
            cmbMoneda.Properties.ValueMember = "IdMoneda";
            cmbMoneda.Properties.DisplayMember = "NombreMoneda";
            cmbMoneda.Properties.DataSource = new CNMonedas().ConsultaGeneral();
        }
        void llenarComboFamilia()
        {
            cmbFamilia.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreFamilia"));
            cmbFamilia.Properties.ValueMember = "IdFamilia";
            cmbFamilia.Properties.DisplayMember = "NombreFamilia";
            //cmbFamilia.Properties.DataSource = Familia.ConsultarFamilias().Tables["FamiliaInsumos"];
            cmbFamilia.Properties.DataSource = new CNFamiliaInsumos().ConsultaGeneral();
        }
        void llenarComboUnidadMedida()
        {
            cmbUnidadMedida.Properties.ValueMember = cmbUnidadMedida.Properties.DisplayMember = "Column";
            cmbUnidadMedida.Properties.DataSource = new string[2 + 1] { "Litros", "Kilográmos", "Piezas" };
        }
        void llenarDatos()
        {
            //DataTable dt = Insumos.ConsultarInsumoPorNombre(txtNombreInsumo.Text).Tables["Insumos"];
            DataTable dt = new CNInsumos().ConsultaPorNombre(txtNombreInsumo.Text);
            if (dt.Rows.Count != 0)
            {
                Guardar = false;
                foreach (DataRow row in dt.Rows)
                {
                    Id = (Convert.ToInt32(row["IdInsumo"]));
                    txtNombreInterno.Text = (Convert.ToString(row["NombreInterno"]));
                    txtPrecioUnitaio.Text = (Convert.ToString(row["PrecioUnitario"]));

                    PU = double.Parse(txtPrecioUnitaio.Text);
                    cmbMoneda.EditValue = (Convert.ToInt32(row["IdMoneda"]));
                    cmbFamilia.EditValue = (Convert.ToInt32(row["IdFamilia"]));
                    if (row["UnidadMedida"].ToString().StartsWith("K"))
                    {
                        cmbUnidadMedida.EditValue = "Kilográmos";
                    }
                    else if (row["UnidadMedida"].ToString().StartsWith("L"))
                    {
                        cmbUnidadMedida.EditValue = "Litros";
                    }
                    else
                    {
                        cmbUnidadMedida.EditValue = "Piezas";
                    }
                }
            }
        }
        //void AsignaGUIObjeto()
        //{
        //    Insumos.IdInsumo = Id;
        //    Insumos.IdFamilia = int.Parse(cmbFamilia.EditValue.ToString());
        //    Insumos.IdMoneda = int.Parse(cmbMoneda.EditValue.ToString());
        //    Insumos.NombreInsumo = txtNombreInsumo.Text;
        //    Insumos.NombreInterno = txtNombreInterno.Text;
        //    Insumos.IdProveedor = int.Parse(cmbProveedor.EditValue.ToString());
        //    if (txtPrecioUnitaio.Text.StartsWith("."))
        //        txtPrecioUnitaio.Text = "0" + txtPrecioUnitaio.Text;
        //    Insumos.PrecioUnitario = Convert.ToDouble(txtPrecioUnitaio.Text);
        //    Insumos.TotalCompraMX = 1000;
        //    if (cmbUnidadMedida.Text.StartsWith("K"))
        //    {
        //        Insumos.UnidadMedida = "KG";
        //    }
        //    else if (cmbUnidadMedida.Text.StartsWith("L"))
        //    {
        //        Insumos.UnidadMedida = "L";
        //    }
        //    else
        //    {
        //        Insumos.UnidadMedida = "P";
        //    }
        //}
        InsumosModel AsignaGUIObjeto2(bool ActualizarPrecios)
        {
            return new InsumosModel
            {
                IdInsumo = Id,
                IdFamilia = int.Parse(cmbFamilia.EditValue.ToString()),
                IdMoneda = int.Parse(cmbMoneda.EditValue.ToString()),
                NombreInsumo = txtNombreInsumo.Text,
                NombreInterno = txtNombreInterno.Text,
                IdProveedor = int.Parse(cmbProveedor.EditValue.ToString()),
                //(txtPrecioUnitaio.Text.StartsWith("."))
                //   txtPrecioUnitaio.Text = "0" + txtPrecioUnitaio.Text,
                PrecioUnitario = Convert.ToDouble(txtPrecioUnitaio.Text),
                TotalCompraMX = 1000,
                UnidadMedida = cmbUnidadMedida.Text.StartsWith("K") ? "KG" : cmbUnidadMedida.Text.StartsWith("L") ? "L" : "P",
                IdUsuario = Estaticos.IdUsuario,
                ActualizaFormulas = ActualizarPrecios
                
            };

        }
        void Limpiar()
        {
            cmbProveedor.EditValue = null;
            txtPrecioUnitaio.Text = "";
            txtNombreInterno.Text = "";
            txtNombreInsumo.Text = "";
            cmbFamilia.EditValue = 0;
            cmbMoneda.EditValue = 0;
            cmbUnidadMedida.EditValue = 0;

        }
        bool ValidaGUI()
        {
            if (String.IsNullOrEmpty(txtNombreInsumo.Text))
            {
                MessageBox.Show("Ingresa el nombre del Insumo", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombreInsumo.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtNombreInterno.Text))
            {
                MessageBox.Show("Ingresa el nombre interno del Insumo", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombreInterno.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtPrecioUnitaio.Text))
            {
                MessageBox.Show("El precio del Insumo no puede quedar en ceros.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioUnitaio.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(cmbFamilia.Text) || cmbFamilia.Text == "[Vacío]")
            {
                MessageBox.Show("Debes asignar el insumo a una familia.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbFamilia.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(cmbMoneda.Text) || cmbMoneda.Text == "[Vacío]")
            {
                MessageBox.Show("Selecciona la divisa de compra.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbMoneda.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(cmbProveedor.Text) || cmbProveedor.Text == "[Vacío]")
            {
                MessageBox.Show("Selecciona un proveedor.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbProveedor.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(cmbUnidadMedida.Text) || cmbUnidadMedida.Text == "[Vacío]")
            {
                MessageBox.Show("Selecciona la Unidad de medida.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbUnidadMedida.Focus();
                return false;
            }
            return true;
        }
        void HabilitarCampos(bool estado)
        {
            txtPrecioUnitaio.Enabled = estado;
            txtNombreInterno.Enabled = estado;
            txtNombreInsumo.Enabled = estado;
            cmbFamilia.Enabled = estado;
            cmbMoneda.Enabled = estado;
            cmbUnidadMedida.Enabled = estado;
        }
        #endregion
        public frmInsumos()
        {
            InitializeComponent();
            llenarComboProveedores();
            llenarComboMonedas();
            llenarComboFamilia();
            llenarComboUnidadMedida();
            HabilitarCampos(false);
            btnBorrar.Links[0].Visible = false;
        }
        private void btnGuardar_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (ValidaGUI())
                {
                    if (!Guardar)
                    {
                        bool ActualizarPreciosFormulas = false;
                        if (Convert.ToDouble(txtPrecioUnitaio.Text) != PU) //PU=> variable para almacenar el precio unitario del insumo cuando se consulta antes de cualquier edicion.
                            if (Convert.ToDouble(txtPrecioUnitaio.Text) < PU)
                            {
                                if (MessageBox.Show("El costo del insumo ha bajado.\n" +
                                    "¿Deseas actualizar el precio de las fórmulas que contienen este insumo?",
                                   "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    ActualizarPreciosFormulas = true;
                            }
                            else
                                ActualizarPreciosFormulas = true;
                        CNInsumos cNInsumos = new CNInsumos(Estaticos.IdUsuario, AsignaGUIObjeto2(ActualizarPreciosFormulas), ActualizarPreciosFormulas, Convert.ToInt32(cmbMoneda.EditValue) == 2 ? Convert.ToDecimal(Estaticos.dolar) : 1);
                        using (waitForm frm = new waitForm(cNInsumos.ActualizarP, "Actualizando precio", "Por favor espere, no tardaremos mucho."))
                        {
                            frm.ShowDialog(this);
                        }
                        if (!cNInsumos.EstadoOperacion)
                            throw new Exception(cNInsumos.Msj);
                    }
                    else
                        new CNInsumos().Guardar(AsignaGUIObjeto2(true));

                    Limpiar();
                    HabilitarCampos(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtNombreInsumo_Leave(object sender, EventArgs e)
        {
            llenarDatos();
        }
        private void cmbProveedor_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                autoCompleteTextBox();
                HabilitarCampos(true);
            }
            catch
            {
            }
        }

        private void btnBorrar_ItemClick(object sender, ItemClickEventArgs e)
        {
            //DataTable BuscaInsumos = Objetos.DetallesFormulas.ConsultarDetallePorInsumo(Id).Tables["DetallesFormulas"];
            DataTable BuscaInsumos = new CNDetallesFormulas().ConsultaPorInsumo(Id);
            //DataTable InsumosEnProductos = Objetos.DetallesProductos.ConsultarDetallesPorInsumo(Id).Tables["DetallesProductos"];
            DataTable InsumosEnProductos = new CNDetallesProductos().ConsultaDetallesPorInsumo(Id);
            if (BuscaInsumos.Rows.Count == 0 && InsumosEnProductos.Rows.Count == 0)
            {
                DialogResult ds = MessageBox.Show("¿Estas seguro que deseas eliminar '" + txtNombreInsumo.Text + "' ?",
                           "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ds == DialogResult.Yes)
                {
                    //Objetos.Insumos.DarDeBajaPorId(this.Id);
                    new CNInsumos().Borrar(this.Id);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("No puedes eliminar '" + txtNombreInsumo.Text + "' porque es parte de una formula activa o de un producto terminado."
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrecioUnitaio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtPrecioUnitaio.Text.Length; i++)
            {
                if (txtPrecioUnitaio.Text[i] == '.')
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
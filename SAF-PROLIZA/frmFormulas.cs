using CapaNegocios;
using Entidades;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace SAF_PROLIZA
{
    public partial class frmFormulas : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        bool ValidaGUI()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Ingresa el nombre de la fórmula.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("Ingresa la cantidad a producir.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCantidad.Focus();
                return false;
            }
            if (cmbFamilia.EditValue == null)
            {
                MessageBox.Show("Selecciona la familia a la que pertenece la fórmula.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbFamilia.Focus();
                return false;
            }
            if (cmbUnidad.EditValue == null)
            {
                MessageBox.Show("Selecciona la unidad de medida de la fórmula.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbUnidad.Focus();
                return false;
            }
            return true;
        }
        public decimal costo;
        FormulasModel AsignaGUIOjeto()
        {
            return new FormulasModel
            {
                NombreFormula = txtNombre.Text,
                Cantidad = double.Parse(txtCantidad.Text),
                IdFamilia = int.Parse(cmbFamilia.EditValue.ToString()),
                Capacidad = cmbUnidad.Text,
                UnidadMedida = GetUnidadMedida(cmbUnidad.Text),
                CostoTotal = 0,
            };
        }
        FormulasModel AsignaGUIOjeto2()
        {
            return new FormulasModel
            {
                NombreFormula = txtNombre.Text,
                Cantidad = Convert.ToDouble(txtCantidad.Text),
                IdFamilia = int.Parse(cmbFamilia.EditValue.ToString()),
                Capacidad = cmbUnidad.Text,
                UnidadMedida = GetUnidadMedida(cmbUnidad.Text),
                CostoTotal = 0,

            };

        }
        void Limpiar()
        {
            txtNombre.Text = "";
            txtCantidad.Text = "";
            cmbUnidad.EditValue = null;
            cmbFamilia.EditValue = null;
        }
        void llenarComboFamilia()
        {
            //BLL.BLLFamiliaFormulas FF = new BLL.BLLFamiliaFormulas(BLL.Gral.gStrConexion, BLL.Gral.gStrUsuario);
            //cmbFamilia.Properties.DataSource = FF.ConsultarFamilias().Tables["FamiliaFormulas"];
            cmbFamilia.Properties.DataSource = new CNFamiliaFormulas(ConfigurationManager.ConnectionStrings["sdprolizaEntitiessp"].ConnectionString).ConsultaGeneral();
            cmbFamilia.Properties.DisplayMember = "NombreFamilia";
            cmbFamilia.Properties.ValueMember = "IdFamilia";
            cmbFamilia.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreFamilia"));

        }
        void llenarComboUnidadMedida()
        {
            cmbUnidad.Properties.ValueMember = cmbUnidad.Properties.DisplayMember = "Column";
            cmbUnidad.Properties.DataSource = new string[5] { "Kilográmos", "grámos", "miligrámos", "Litros", "Mililitros" };

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
        public frmFormulas()
        {
            InitializeComponent();
            llenarComboFamilia();
            llenarComboUnidadMedida();
        }
        private void btnDetalles_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidaGUI())
            {
                //AsignaGUIOjeto();
                //BLL.BLLFormulas g = new BLL.BLLFormulas(BLL.Gral.gStrConexion, BLL.Gral.gStrUsuario);
                //string msj = g.Guardar(F);
                FormulasModel F = AsignaGUIOjeto2();
                int IdFormula = 0;// new CNFormulas().Guardar(F);
                //frmDetallesFormulas frm = ;
                //frm.llenarCampos(txtNombre.Text, IdFormula.ToString(), cmbFamilia.Text, txtCantidad.Text + " " + cmbUnidad.Text, F.IdFamilia, F.UnidadMedida, txtCantidad.Text);
                new frmDetallesFormulas(IdFormula).ShowDialog();
                Close();
            }
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (ValidaGUI())
            //{
            //    AsignaGUIOjeto();
            //    BLL.BLLFormulas g = new BLL.BLLFormulas(BLL.Gral.gStrConexion, BLL.Gral.gStrUsuario);
            //    string msj = g.Guardar(F);
            //    Limpiar();
            //}

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && 
            //    !char.IsPunctuation(e.KeyChar) && (e.KeyChar != (char)Keys.Tab))
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
    }
}
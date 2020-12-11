using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace SAF_PROLIZA
{
    public partial class frmFamilias : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string EstadoFormulario;

        public void prepararFormulario(string Estado)
        {
            switch (Estado)
            {
                case "Formulas":
                    this.Text = "Agregar Familia de Formulas";
                    groupControl1.Text = "Nombre Familia Formula";
                    EstadoFormulario = "Formulas";
                    if (Id > 0)
                        txtFamilias.Text = new CNFamiliaFormulas().ConsultaIndividual(Id).Rows[0]["NombreFamilia"].ToString();
                    break;
                case "Insumos":
                    this.Text = "Agregar Familia de Insumos";
                    groupControl1.Text = "Nombre Familia Insumo";
                    EstadoFormulario = "Insumos";
                    if (Id > 0)
                        txtFamilias.Text = new CNFamiliaInsumos().ConsultaIndividual(Id).Rows[0]["NombreFamilia"].ToString();
                    break;
                case "Proveedores":
                    this.Text = "Agregar Proveedor";
                    groupControl1.Text = "Nombre Proveedor";
                    EstadoFormulario = "Proveedores";
                    if (Id > 0)
                        txtFamilias.Text = new CNProveedores().ConsultaIndividual(Id).Rows[0]["NombreProveedor"].ToString();
                    break;
                case "Dolar":
                    this.Text = "Actualizar Precio Dolar";
                    groupControl1.Text = "Precio Dolar";
                    EstadoFormulario = "Dolar";
                    break;
                case "Pwd":
                    this.Text = "Confirma tu contraseña.";
                    groupControl1.Text = "Contraseña";
                    btnGuardar.Text = "Aceptar";
                    txtFamilias.Properties.PasswordChar = '*';
                    EstadoFormulario = "Pwd";
                    break;

            }
        }

        void AccionBoton()
        {
            //string mensaje = "";
            switch (EstadoFormulario)
            {
                case "Formulas":
                    //BLL.BLLFamiliaFormulas F = new BLL.BLLFamiliaFormulas(BLL.Gral.gStrConexion, BLL.Gral.gStrUsuario);
                    //F.IdFamilia = 1;
                    //F.nombreFamilia = txtFamilias.Text;
                    //mensaje = F.Guardar(F);
                    if (Id > 0)
                        new CNFamiliaFormulas().Actualizar(new Entidades.FamiliaFormulasModel
                        {
                            IdFamilia = Id,
                            nombreFamilia = txtFamilias.Text
                        });
                    else
                        new CNFamiliaFormulas().Guardar(new Entidades.FamiliaFormulasModel
                        {
                            IdFamilia = Id,
                            nombreFamilia = txtFamilias.Text
                        });
                    txtFamilias.Text = "";
                    break;
                case "Insumos":
                    //BLL.BLLFamiliaInsumos I = new BLL.BLLFamiliaInsumos(BLL.Gral.gStrConexion, BLL.Gral.gStrUsuario);
                    //I.IdFamilia = 1;
                    //I.nombreFamilia = txtFamilias.Text;
                    //mensaje = I.Guardar(I);
                    if (Id > 0)
                        new CNFamiliaInsumos().Actualizar(new Entidades.FamiliaInsumosModel
                        {
                            IdFamilia = Id,
                            nombreFamilia = txtFamilias.Text
                        });
                    else
                        new CNFamiliaInsumos().Guardar(new Entidades.FamiliaInsumosModel
                        {
                            IdFamilia = Id,
                            nombreFamilia = txtFamilias.Text
                        });
                    txtFamilias.Text = "";
                    break;
                case "Proveedores":
                    //BLL.BLLProveedores P = new BLL.BLLProveedores(BLL.Gral.gStrConexion, BLL.Gral.gStrUsuario);
                    //P.IdProveedor = 1;
                    //P.nombreProveedor = txtFamilias.Text;
                    //mensaje = P.Guardar(P);
                    if (Id > 0)
                        new CNProveedores().Actualizar(new Entidades.ProveedoresModel
                        {
                            IdProveedor = Id,
                            nombreProveedor = txtFamilias.Text
                        });
                    else
                        new CNProveedores().Guardar(new Entidades.ProveedoresModel
                        {
                            nombreProveedor = txtFamilias.Text
                        });
                    txtFamilias.Text = "";
                    break;
                case "Dolar":
                    //Objetos.TipoDeCambio.IdMoneda = 2;
                    //Objetos.TipoDeCambio.IdTipoCambio = 2;
                    //Objetos.TipoDeCambio.FactorConversion = Convert.ToDecimal(txtFamilias.Text);
                    //Estaticos.dolar = Convert.ToDouble(Objetos.TipoDeCambio.FactorConversion);
                    //Objetos.TipoDeCambio.Guardar(Objetos.TipoDeCambio);
                    new CNTipoDeCambio().Guardar(new Entidades.TipoDeCambioModel
                    {
                        IdMoneda = 2,
                        IdTipoCambio = 2,
                        FactorConversion = Convert.ToDecimal(txtFamilias.Text)
                    });
                    Estaticos.dolar = Convert.ToDouble(txtFamilias.Text);
                    Close();
                    break;
                case "Pwd":
                    //DataTable User = Objetos.Usuario.ConsultarUsuarios(Estaticos.Username, Seguridad.EncryptAES(txtFamilias.Text)).Tables["Usuario"];
                    DataTable User = new CNUsuarios().ConsultaLOGIN(Estaticos.Username, Seguridad.EncryptAES(txtFamilias.Text));
                    if (User.Rows.Count == 1)
                        this.DialogResult = DialogResult.OK;
                    else
                        MessageBox.Show("Contraseña Incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        public frmFamilias()
        {
            InitializeComponent();
        }
        int Id;
        public frmFamilias(int Id)
        {
            InitializeComponent();
            this.Id = Id;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFamilias.Text))
            {
                AccionBoton();
            }
        }
        private void frmFamilias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
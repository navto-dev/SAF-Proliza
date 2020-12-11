using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocios;
using DevExpress.Utils;
using Entidades;

namespace SAF_PROLIZA
{
    public partial class frmUsuario : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        int Idusuario = 0;
        bool Guardar = false;
        private void ShowTooltip()
        {
            string formattedMessage = "Este nombre de usuario ya esta en uso. Selecciona otro.";
            Point toolTipLocation = txtUsername.PointToScreen(new Point(10, txtUsername.Height));
            toolTipController1.ShowHint(formattedMessage, ToolTipLocation.Fixed, toolTipLocation);
        }
        void llenarComboRol()
        {
            cmbRol.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Rol"));
            //cmbRol.Properties.DataSource = Objetos.Usuario.ConsultarRolesActivos().Tables["RolesUsuarios"];
            cmbRol.Properties.DataSource = new CNUsuarios().ConsultaRolesActivos();
            cmbRol.Properties.ValueMember = "IdRol";
            cmbRol.Properties.DisplayMember = "Rol";

        }
        bool ValidaGUI()
        {
            #region "Valida que todos los campos esten llenos"
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Proporciona el nombre real del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Ingresa un nombre de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPwd.Text))
            {
                MessageBox.Show("Ingresa una contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPwd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtConfirmPwd.Text))
            {
                MessageBox.Show("Confirma la cntraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirmPwd.Focus();
                return false;
            }
            if (cmbRol.EditValue == null)
            {
                MessageBox.Show("Selecciona un Rol para el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbRol.Focus();
                return false;
            }
            #endregion
            if (!txtPwd.Text.Equals(txtConfirmPwd.Text))
            {
                MessageBox.Show("Confirmación de contraseña incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirmPwd.Focus();
                return false;
            }

            return true;
        }
        void HabilitaBotones(string Accion)
        {
            switch (Accion)
            {
                case "Alta":
                    Guardar = true;
                    btnAceptar.Links[0].Visible = true;
                    btnBorrar.Links[0].Visible = false;
                    btnEditar.Links[0].Visible = false;
                    btnMostrarContraseña.Links[0].Visible = false;
                    break;
                case "Consulta":
                    btnAceptar.Enabled = false;
                    btnBorrar.Links[0].Visible = true;
                    btnEditar.Links[0].Visible = true;
                    btnMostrarContraseña.Links[0].Visible = true;
                    if (Estaticos.IdRol == 1)
                    {
                        cmbRol.Properties.ReadOnly = false;
                    }
                    else
                    {
                        if (txtUsername.Text.Equals(Estaticos.Username))
                        {
                            cmbRol.Properties.ReadOnly = true;
                        }
                    }
                    break;
            }
        }
       
        UsuariosModel AsignaGUIObjeto2()
        {
            return new UsuariosModel
            {
                IdUsuario = Idusuario,
                Nombre = txtNombre.Text,
                Username = txtUsername.Text,
                Pasword = Seguridad.EncryptAES(txtPwd.Text),
                email = !string.IsNullOrEmpty(txtEmail.Text) ? txtEmail.Text : "-----------",
                IdRol = Convert.ToInt32(cmbRol.EditValue),
            };
        }
        public void MostrarDatos(int Id)
        {
            frmUsuario frm = new frmUsuario("Consulta");
            frm.Guardar = false;
            if (Estaticos.IdRol != 1) frm.cmbRol.Properties.ReadOnly = true;
            frm.habilitarControles(true);
            frm.Idusuario = Id;
            if (Estaticos.IdUsuario == frm.Idusuario) frm.btnBorrar.Links[0].Visible = false;
            //DataTable User = Objetos.Usuario.ConsultaPorId(Id).Tables["Usuario"];
            DataTable User = new CNUsuarios().ConsultaPorId(Id);
            frm.txtNombre.Text = Convert.ToString(User.Rows[0]["Nombre"]);
            frm.txtUsername.Text = Convert.ToString(User.Rows[0]["Username"]);
            frm.txtPwd.Text = Seguridad.DecryptAES(Convert.ToString(User.Rows[0]["Pasword"]));
            frm.txtConfirmPwd.Text = frm.txtPwd.Text;
            frm.txtEmail.Text = Convert.ToString(User.Rows[0]["email"]);
            frm.cmbRol.EditValue = Convert.ToString(User.Rows[0]["IdRol"]);
            frm.btnAceptar.Enabled = false;
            frm.ShowDialog();
        }

        void habilitarControles(bool estado)
        {
            txtConfirmPwd.Properties.ReadOnly = estado;
            txtEmail.Properties.ReadOnly = estado;
            txtNombre.Properties.ReadOnly = estado;
            txtPwd.Properties.ReadOnly = estado;
            if (Estaticos.IdRol == 1) cmbRol.Properties.ReadOnly = estado;
            txtUsername.Properties.ReadOnly = estado;
        }





        public frmUsuario(string Accion)
        {
            InitializeComponent();
            HabilitaBotones(Accion);
            llenarComboRol();
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            //DataTable Username = Objetos.Usuario.ValidaUsername(txtUsername.Text).Tables["Usuario"];
            DataTable Username = new CNUsuarios().ConsultaValidaUsername(txtUsername.Text);
            if (Username.Rows.Count != 0)
            {
                if (Convert.ToInt32(Username.Rows[0]["IdUsuario"]) != Estaticos.IdUsuario)
                {
                    ShowTooltip();
                    txtUsername.Focus();
                }
            }
            else
                toolTipController1.HideHint();
        }

        private void btnBorrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmFamilias frm = new frmFamilias();
            DialogResult ds = new DialogResult();
            frm.prepararFormulario("Pwd");
            ds = frm.ShowDialog();
            if (ds == DialogResult.OK)
            {
                //Objetos.Usuario.DarDeBajaUsuario(Idusuario);
                new CNUsuarios().Borrar(Idusuario);
                habilitarControles(true);
            }
        }

        private void btnMostrarContraseña_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtPwd.Properties.PasswordChar != '*')
            {
                txtPwd.Properties.PasswordChar = '*';
                txtConfirmPwd.Properties.PasswordChar = '*';
                btnMostrarContraseña.Caption = "Mostrar Contraseña";
            }
            else
            {
                txtPwd.Properties.PasswordChar = '\0';
                txtConfirmPwd.Properties.PasswordChar = '\0';
                btnMostrarContraseña.Caption = "Ocultar Contraseña";
            }
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidaGUI())
            {

                //AsignaGUIObjeto();
                if (ValidaGUI())
                {
                    if (Guardar)
                    {
                        //string msj = Objetos.Usuario.Guardar(Objetos.Usuario);
                        //if (!msj.Contains("Error"))
                        //{
                        //    Close();
                        //}
                        if (new CNUsuarios().Guardar(AsignaGUIObjeto2()) > 0)
                            Close();
                        else
                            MessageBox.Show("No se han podido gurdar los datos del usuario.");
                    }
                    else
                    {
                        //string msj = Objetos.Usuario.Actualizar(Objetos.Usuario);
                        //Console.Write(msj);
                        //if (!msj.Contains("Error"))
                        //{
                        //    Close();
                        //}
                        if (new CNUsuarios().Actualizar(AsignaGUIObjeto2()) > 0)
                            Close();
                        else
                            MessageBox.Show("No se han podido gurdar los datos del usuario.");
                    }
                }
            }
        }

        private void btnCambiarDatos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            habilitarControles(false);
            btnAceptar.Enabled = true;

        }
    }
}
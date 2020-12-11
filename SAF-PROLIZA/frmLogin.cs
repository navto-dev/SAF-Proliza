using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SAF_PROLIZA
{
    public partial class frmLogin : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //DataTable Usuario = Objetos.Usuario.ConsultarUsuarios(txtUsuario.Text, Seguridad.EncryptAES(txtPasword.Text)).Tables["Usuario"];
            DataTable Usuario = new CNUsuarios().ConsultaLOGIN(txtUsuario.Text, Seguridad.EncryptAES(txtPasword.Text));
            //if (Usuario.Rows.Count == 1)
            if (Usuario.Rows.Count == 1)
            {
                if ((bool)(Usuario.Rows[0]["Activo"]))
                {
                    Estaticos.IdRol = Convert.ToInt32(Usuario.Rows[0]["IdRol"]);
                    Estaticos.Username = Convert.ToString(Usuario.Rows[0]["Username"]);
                    Estaticos.IdUsuario = Convert.ToInt32(Usuario.Rows[0]["IdUsuario"]);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Lo siento. No tienes permiso para acceder.", "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPasword.SelectAll();
                    txtPasword.Focus();
                }
            }
            else
            {
                MessageBox.Show("Datos de usuario incorrectos", "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPasword.SelectAll();
                txtPasword.Focus();
            }
        }


        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnLogin.PerformClick();
                    break;
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }
    }
}
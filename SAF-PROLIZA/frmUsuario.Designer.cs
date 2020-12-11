namespace SAF_PROLIZA
{
    partial class frmUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuario));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbRol = new DevExpress.XtraEditors.LookUpEdit();
            this.txtConfirmPwd = new DevExpress.XtraEditors.TextEdit();
            this.txtPwd = new DevExpress.XtraEditors.TextEdit();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.btnNuevosDatos = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditar = new DevExpress.XtraBars.BarButtonItem();
            this.btnMostrarContraseña = new DevExpress.XtraBars.BarButtonItem();
            this.btnBorrar = new DevExpress.XtraBars.BarButtonItem();
            this.InicioRibbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.InicioRibbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRol.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtEmail);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.cmbRol);
            this.panelControl1.Controls.Add(this.txtConfirmPwd);
            this.panelControl1.Controls.Add(this.txtPwd);
            this.panelControl1.Controls.Add(this.txtUsername);
            this.panelControl1.Controls.Add(this.txtNombre);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 122);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(306, 300);
            this.panelControl1.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 218);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(229, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 244);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(19, 13);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "Rol:";
            // 
            // labelControl5
            // 
            this.labelControl5.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
            this.labelControl5.LineStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            this.labelControl5.Location = new System.Drawing.Point(12, 199);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(92, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Correo Electrónico:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 154);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(117, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Confirma la Contraseña:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 109);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Contraseña:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(95, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Nombre de Usuario:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(89, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Nombre Completo:";
            // 
            // cmbRol
            // 
            this.cmbRol.Location = new System.Drawing.Point(12, 263);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRol.Size = new System.Drawing.Size(229, 20);
            this.cmbRol.TabIndex = 6;
            // 
            // txtConfirmPwd
            // 
            this.txtConfirmPwd.Location = new System.Drawing.Point(12, 173);
            this.txtConfirmPwd.Name = "txtConfirmPwd";
            this.txtConfirmPwd.Properties.PasswordChar = '*';
            this.txtConfirmPwd.Size = new System.Drawing.Size(229, 20);
            this.txtConfirmPwd.TabIndex = 4;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(12, 128);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Properties.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(229, 20);
            this.txtPwd.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(12, 83);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(229, 20);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(12, 38);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(229, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnAceptar,
            this.btnNuevosDatos,
            this.btnEditar,
            this.btnMostrarContraseña,
            this.btnBorrar});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 10;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.InicioRibbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(306, 122);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Caption = "Guardar";
            this.btnAceptar.Id = 2;
            this.btnAceptar.ImageOptions.ImageUri.Uri = "Save";
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // btnNuevosDatos
            // 
            this.btnNuevosDatos.Caption = "Actualizar Datos";
            this.btnNuevosDatos.Enabled = false;
            this.btnNuevosDatos.Id = 3;
            this.btnNuevosDatos.ImageOptions.ImageUri.Uri = "Replace";
            this.btnNuevosDatos.Name = "btnNuevosDatos";
            // 
            // btnEditar
            // 
            this.btnEditar.Caption = "Editar";
            this.btnEditar.Id = 7;
            this.btnEditar.ImageOptions.ImageUri.Uri = "Edit";
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCambiarDatos_ItemClick);
            // 
            // btnMostrarContraseña
            // 
            this.btnMostrarContraseña.Caption = "Mostrar Contraseña";
            this.btnMostrarContraseña.Id = 8;
            this.btnMostrarContraseña.ImageOptions.ImageUri.Uri = "Zoom";
            this.btnMostrarContraseña.Name = "btnMostrarContraseña";
            this.btnMostrarContraseña.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMostrarContraseña_ItemClick);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Caption = "Dar de Baja";
            this.btnBorrar.Id = 9;
            this.btnBorrar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrar.ImageOptions.Image")));
            this.btnBorrar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBorrar.ImageOptions.LargeImage")));
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBorrar_ItemClick);
            // 
            // InicioRibbonPage1
            // 
            this.InicioRibbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.InicioRibbonPageGroup1});
            this.InicioRibbonPage1.Name = "InicioRibbonPage1";
            this.InicioRibbonPage1.Text = "Inicio";
            // 
            // InicioRibbonPageGroup1
            // 
            this.InicioRibbonPageGroup1.ItemLinks.Add(this.btnAceptar);
            this.InicioRibbonPageGroup1.ItemLinks.Add(this.btnEditar);
            this.InicioRibbonPageGroup1.ItemLinks.Add(this.btnMostrarContraseña);
            this.InicioRibbonPageGroup1.ItemLinks.Add(this.btnBorrar, true);
            this.InicioRibbonPageGroup1.Name = "InicioRibbonPageGroup1";
            this.InicioRibbonPageGroup1.Text = "Inicio";
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 422);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsuario";
            this.Ribbon = this.ribbonControl1;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos de Usuario";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRol.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cmbRol;
        private DevExpress.XtraEditors.TextEdit txtConfirmPwd;
        private DevExpress.XtraEditors.TextEdit txtPwd;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraBars.BarButtonItem btnNuevosDatos;
        private DevExpress.XtraBars.BarButtonItem btnEditar;
        private DevExpress.XtraBars.BarButtonItem btnMostrarContraseña;
        public DevExpress.XtraBars.BarButtonItem btnBorrar;
        private DevExpress.XtraBars.Ribbon.RibbonPage InicioRibbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup InicioRibbonPageGroup1;
        private DevExpress.Utils.ToolTipController toolTipController1;
    }
}
namespace SAF_PROLIZA
{
    partial class frmInsumos
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
            this.rbnControlReportes = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.btnBorrar = new DevExpress.XtraBars.BarButtonItem();
            this.InicioRibbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.InicioRibbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtNombreInsumo = new DevExpress.XtraEditors.TextEdit();
            this.txtPrecioUnitaio = new DevExpress.XtraEditors.TextEdit();
            this.txtNombreInterno = new DevExpress.XtraEditors.TextEdit();
            this.cmbMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbFamilia = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbUnidadMedida = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbProveedor = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlReportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreInsumo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecioUnitaio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreInterno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFamilia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnidadMedida.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProveedor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnControlReportes
            // 
            this.rbnControlReportes.ExpandCollapseItem.Id = 0;
            this.rbnControlReportes.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbnControlReportes.ExpandCollapseItem,
            this.btnGuardar,
            this.btnBorrar});
            this.rbnControlReportes.Location = new System.Drawing.Point(0, 0);
            this.rbnControlReportes.MaxItemId = 19;
            this.rbnControlReportes.Name = "rbnControlReportes";
            this.rbnControlReportes.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.InicioRibbonPage1});
            this.rbnControlReportes.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.rbnControlReportes.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.rbnControlReportes.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.rbnControlReportes.ShowQatLocationSelector = false;
            this.rbnControlReportes.ShowToolbarCustomizeItem = false;
            this.rbnControlReportes.Size = new System.Drawing.Size(430, 122);
            this.rbnControlReportes.Toolbar.ShowCustomizeItem = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Caption = "Guardar";
            this.btnGuardar.Id = 1;
            this.btnGuardar.ImageOptions.ImageUri.Uri = "Save";
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGuardar_ItemClick);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Caption = "Dar de Baja ";
            this.btnBorrar.Id = 18;
            this.btnBorrar.ImageOptions.ImageUri.Uri = "Clear";
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
            this.InicioRibbonPageGroup1.ItemLinks.Add(this.btnGuardar);
            this.InicioRibbonPageGroup1.ItemLinks.Add(this.btnBorrar);
            this.InicioRibbonPageGroup1.Name = "InicioRibbonPageGroup1";
            this.InicioRibbonPageGroup1.ShowCaptionButton = false;
            this.InicioRibbonPageGroup1.Text = "Inicio";
            // 
            // groupControl1
            // 
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl1.Controls.Add(this.txtNombreInsumo);
            this.groupControl1.Controls.Add(this.txtPrecioUnitaio);
            this.groupControl1.Controls.Add(this.txtNombreInterno);
            this.groupControl1.Controls.Add(this.cmbMoneda);
            this.groupControl1.Controls.Add(this.cmbFamilia);
            this.groupControl1.Controls.Add(this.cmbUnidadMedida);
            this.groupControl1.Controls.Add(this.cmbProveedor);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 122);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(430, 236);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Datos de Insumo";
            // 
            // txtNombreInsumo
            // 
            this.txtNombreInsumo.Location = new System.Drawing.Point(18, 91);
            this.txtNombreInsumo.MenuManager = this.rbnControlReportes;
            this.txtNombreInsumo.Name = "txtNombreInsumo";
            this.txtNombreInsumo.Size = new System.Drawing.Size(389, 20);
            this.txtNombreInsumo.TabIndex = 2;
            this.txtNombreInsumo.Leave += new System.EventHandler(this.txtNombreInsumo_Leave);
            // 
            // txtPrecioUnitaio
            // 
            this.txtPrecioUnitaio.Location = new System.Drawing.Point(159, 191);
            this.txtPrecioUnitaio.MenuManager = this.rbnControlReportes;
            this.txtPrecioUnitaio.Name = "txtPrecioUnitaio";
            this.txtPrecioUnitaio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioUnitaio.TabIndex = 6;
            this.txtPrecioUnitaio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioUnitaio_KeyPress);
            // 
            // txtNombreInterno
            // 
            this.txtNombreInterno.Location = new System.Drawing.Point(18, 141);
            this.txtNombreInterno.MenuManager = this.rbnControlReportes;
            this.txtNombreInterno.Name = "txtNombreInterno";
            this.txtNombreInterno.Size = new System.Drawing.Size(266, 20);
            this.txtNombreInterno.TabIndex = 3;
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.Location = new System.Drawing.Point(309, 191);
            this.cmbMoneda.MenuManager = this.rbnControlReportes;
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMoneda.Size = new System.Drawing.Size(100, 20);
            this.cmbMoneda.TabIndex = 7;
            // 
            // cmbFamilia
            // 
            this.cmbFamilia.Location = new System.Drawing.Point(20, 191);
            this.cmbFamilia.MenuManager = this.rbnControlReportes;
            this.cmbFamilia.Name = "cmbFamilia";
            this.cmbFamilia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFamilia.Size = new System.Drawing.Size(100, 20);
            this.cmbFamilia.TabIndex = 5;
            // 
            // cmbUnidadMedida
            // 
            this.cmbUnidadMedida.Location = new System.Drawing.Point(307, 141);
            this.cmbUnidadMedida.MenuManager = this.rbnControlReportes;
            this.cmbUnidadMedida.Name = "cmbUnidadMedida";
            this.cmbUnidadMedida.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUnidadMedida.Size = new System.Drawing.Size(111, 20);
            this.cmbUnidadMedida.TabIndex = 4;
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.Location = new System.Drawing.Point(18, 47);
            this.cmbProveedor.MenuManager = this.rbnControlReportes;
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProveedor.Size = new System.Drawing.Size(239, 20);
            this.cmbProveedor.TabIndex = 1;
            this.cmbProveedor.EditValueChanged += new System.EventHandler(this.cmbProveedor_EditValueChanged);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(309, 172);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(38, 13);
            this.labelControl8.TabIndex = 7;
            this.labelControl8.Text = "Moneda";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(20, 172);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(32, 13);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "Familia";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(159, 172);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(69, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Precio Unitario";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(307, 126);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(85, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Unidad de Medida";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(18, 122);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(76, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Nombre Interno";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(18, 72);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(92, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Nombre del Insumo";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Proveedor";
            // 
            // frmInsumos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 358);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.rbnControlReportes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInsumos";
            this.Ribbon = this.rbnControlReportes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insumos";
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlReportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreInsumo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecioUnitaio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreInterno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFamilia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnidadMedida.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProveedor.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rbnControlReportes;
        private DevExpress.XtraBars.BarButtonItem btnGuardar;
        private DevExpress.XtraBars.Ribbon.RibbonPage InicioRibbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup InicioRibbonPageGroup1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtPrecioUnitaio;
        private DevExpress.XtraEditors.TextEdit txtNombreInterno;
        private DevExpress.XtraEditors.LookUpEdit cmbMoneda;
        private DevExpress.XtraEditors.LookUpEdit cmbFamilia;
        private DevExpress.XtraEditors.LookUpEdit cmbProveedor;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNombreInsumo;
        private DevExpress.XtraEditors.LookUpEdit cmbUnidadMedida;
        private DevExpress.XtraBars.BarButtonItem btnBorrar;
    }
}
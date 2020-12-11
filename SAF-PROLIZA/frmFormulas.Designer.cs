namespace SAF_PROLIZA
{
    partial class frmFormulas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormulas));
            this.rbnControlReportes = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.btnDetalles = new DevExpress.XtraBars.BarButtonItem();
            this.InicioRibbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.InicioRibbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cmbUnidad = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbFamilia = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCantidad = new DevExpress.XtraEditors.TextEdit();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlReportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFamilia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnControlReportes
            // 
            this.rbnControlReportes.ExpandCollapseItem.Id = 0;
            this.rbnControlReportes.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbnControlReportes.ExpandCollapseItem,
            this.btnGuardar,
            this.btnDetalles});
            this.rbnControlReportes.Location = new System.Drawing.Point(0, 0);
            this.rbnControlReportes.MaxItemId = 20;
            this.rbnControlReportes.Name = "rbnControlReportes";
            this.rbnControlReportes.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.InicioRibbonPage1});
            this.rbnControlReportes.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.rbnControlReportes.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.rbnControlReportes.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.rbnControlReportes.ShowQatLocationSelector = false;
            this.rbnControlReportes.ShowToolbarCustomizeItem = false;
            this.rbnControlReportes.Size = new System.Drawing.Size(330, 122);
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
            // btnDetalles
            // 
            this.btnDetalles.Caption = "Guardar y Agregar Detalles";
            this.btnDetalles.Id = 18;
            this.btnDetalles.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalles.ImageOptions.Image")));
            this.btnDetalles.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDetalles.ImageOptions.LargeImage")));
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDetalles_ItemClick);
            // 
            // InicioRibbonPage1
            // 
            this.InicioRibbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.InicioRibbonPageGroup1});
            this.InicioRibbonPage1.Name = "InicioRibbonPage1";
            this.InicioRibbonPage1.Text = "Guardar";
            // 
            // InicioRibbonPageGroup1
            // 
            this.InicioRibbonPageGroup1.ItemLinks.Add(this.btnDetalles);
            this.InicioRibbonPageGroup1.Name = "InicioRibbonPageGroup1";
            this.InicioRibbonPageGroup1.Text = "Guardar";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.cmbUnidad);
            this.groupControl1.Controls.Add(this.cmbFamilia);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtCantidad);
            this.groupControl1.Controls.Add(this.txtNombre);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 122);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(330, 197);
            this.groupControl1.TabIndex = 12;
            this.groupControl1.Text = "Datos Formula:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(129, 77);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(85, 13);
            this.labelControl4.TabIndex = 17;
            this.labelControl4.Text = "Unidad de Medida";
            // 
            // cmbUnidad
            // 
            this.cmbUnidad.Location = new System.Drawing.Point(129, 96);
            this.cmbUnidad.MenuManager = this.rbnControlReportes;
            this.cmbUnidad.Name = "cmbUnidad";
            this.cmbUnidad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUnidad.Size = new System.Drawing.Size(93, 20);
            this.cmbUnidad.TabIndex = 3;
            // 
            // cmbFamilia
            // 
            this.cmbFamilia.Location = new System.Drawing.Point(23, 141);
            this.cmbFamilia.MenuManager = this.rbnControlReportes;
            this.cmbFamilia.Name = "cmbFamilia";
            this.cmbFamilia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFamilia.Size = new System.Drawing.Size(199, 20);
            this.cmbFamilia.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(25, 122);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 13);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "Familia:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(25, 77);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Cantidad:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 13);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Nombre de la Formula:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(23, 96);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 2;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(23, 51);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(287, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // frmFormulas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 319);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.rbnControlReportes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFormulas";
            this.Ribbon = this.rbnControlReportes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Formula";
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlReportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFamilia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl rbnControlReportes;
        private DevExpress.XtraBars.BarButtonItem btnGuardar;
        private DevExpress.XtraBars.Ribbon.RibbonPage InicioRibbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup InicioRibbonPageGroup1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtCantidad;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.LookUpEdit cmbUnidad;
        private DevExpress.XtraEditors.LookUpEdit cmbFamilia;
        private DevExpress.XtraBars.BarButtonItem btnDetalles;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}
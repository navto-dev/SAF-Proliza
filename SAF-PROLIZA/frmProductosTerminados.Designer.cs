namespace SAF_PROLIZA
{
    partial class frmProductosTerminados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductosTerminados));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtUM = new DevExpress.XtraEditors.TextEdit();
            this.txtCosto = new DevExpress.XtraEditors.TextEdit();
            this.txtCantidad = new DevExpress.XtraEditors.TextEdit();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.cmbUnidadMedida = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblCosto = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cmbDetalles = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cmbFormula = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.rbnControlReportes = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.btnBorrar = new DevExpress.XtraBars.BarButtonItem();
            this.InicioRibbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.InicioRibbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.borrarEsteInsumoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnidadMedida.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDetalles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFormula.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlReportes)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtUM);
            this.groupControl1.Controls.Add(this.txtCosto);
            this.groupControl1.Controls.Add(this.txtCantidad);
            this.groupControl1.Controls.Add(this.txtNombre);
            this.groupControl1.Controls.Add(this.cmbUnidadMedida);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.groupControl3);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Controls.Add(this.cmbFormula);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 122);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(464, 503);
            this.groupControl1.TabIndex = 11;
            this.groupControl1.Text = "Datos del Producto";
            // 
            // txtUM
            // 
            this.txtUM.Location = new System.Drawing.Point(84, 137);
            this.txtUM.Name = "txtUM";
            this.txtUM.Properties.ReadOnly = true;
            this.txtUM.Size = new System.Drawing.Size(100, 20);
            this.txtUM.TabIndex = 34;
            this.txtUM.Visible = false;
            // 
            // txtCosto
            // 
            this.txtCosto.Enabled = false;
            this.txtCosto.Location = new System.Drawing.Point(12, 188);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(149, 20);
            this.txtCosto.TabIndex = 5;
            this.txtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCosto_KeyPress);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(12, 137);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(66, 20);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(12, 92);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(431, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // cmbUnidadMedida
            // 
            this.cmbUnidadMedida.Location = new System.Drawing.Point(84, 137);
            this.cmbUnidadMedida.Name = "cmbUnidadMedida";
            this.cmbUnidadMedida.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUnidadMedida.Size = new System.Drawing.Size(77, 20);
            this.cmbUnidadMedida.TabIndex = 4;
            this.cmbUnidadMedida.Leave += new System.EventHandler(this.txtUnidadMedida_Leave);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 166);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(75, 13);
            this.labelControl4.TabIndex = 33;
            this.labelControl4.Text = "Costo a Granel:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 118);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(47, 13);
            this.labelControl3.TabIndex = 32;
            this.labelControl3.Text = "Cantidad:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 73);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(104, 13);
            this.labelControl2.TabIndex = 31;
            this.labelControl2.Text = "Nombre del Producto:";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Controls.Add(this.lblCosto);
            this.groupControl3.Location = new System.Drawing.Point(217, 118);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(226, 94);
            this.groupControl3.TabIndex = 30;
            this.groupControl3.Text = "Costo Total de Elaboración:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(18, 38);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(15, 33);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "$";
            // 
            // lblCosto
            // 
            this.lblCosto.Appearance.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosto.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblCosto.Appearance.Options.UseFont = true;
            this.lblCosto.Appearance.Options.UseForeColor = true;
            this.lblCosto.Location = new System.Drawing.Point(55, 38);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(63, 35);
            this.lblCosto.TabIndex = 11;
            this.lblCosto.Text = "0.00";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnAdd);
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Controls.Add(this.cmbDetalles);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(2, 240);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(460, 261);
            this.groupControl2.TabIndex = 29;
            this.groupControl2.Text = "Detalle de Empaquetado:";
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.Location = new System.Drawing.Point(215, 40);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 23);
            this.btnAdd.TabIndex = 35;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.Location = new System.Drawing.Point(2, 86);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(456, 173);
            this.gridControl1.TabIndex = 34;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl1_KeyDown);
            this.gridControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseClick);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // cmbDetalles
            // 
            this.cmbDetalles.Location = new System.Drawing.Point(5, 42);
            this.cmbDetalles.Name = "cmbDetalles";
            this.cmbDetalles.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDetalles.Size = new System.Drawing.Size(204, 20);
            this.cmbDetalles.TabIndex = 6;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(5, 23);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(39, 13);
            this.labelControl6.TabIndex = 32;
            this.labelControl6.Text = "Insumo:";
            // 
            // cmbFormula
            // 
            this.cmbFormula.Location = new System.Drawing.Point(12, 45);
            this.cmbFormula.Name = "cmbFormula";
            this.cmbFormula.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFormula.Size = new System.Drawing.Size(431, 20);
            this.cmbFormula.TabIndex = 1;
            this.cmbFormula.EditValueChanged += new System.EventHandler(this.cmbFormula_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "Formula:";
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
            this.rbnControlReportes.Size = new System.Drawing.Size(464, 122);
            this.rbnControlReportes.Toolbar.ShowCustomizeItem = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Caption = "Guardar";
            this.btnGuardar.Id = 1;
            this.btnGuardar.ImageOptions.ImageUri.Uri = "Save";
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGuardar_ItemClick_1);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Caption = "Dar de Baja";
            this.btnBorrar.Id = 18;
            this.btnBorrar.ImageOptions.ImageUri.Uri = "Clear";
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBorrar_ItemClick_1);
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
            this.InicioRibbonPageGroup1.Text = "Inicio";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.borrarEsteInsumoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 26);
            // 
            // borrarEsteInsumoToolStripMenuItem
            // 
            this.borrarEsteInsumoToolStripMenuItem.Name = "borrarEsteInsumoToolStripMenuItem";
            this.borrarEsteInsumoToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.borrarEsteInsumoToolStripMenuItem.Text = "Borrar este insumo";
            this.borrarEsteInsumoToolStripMenuItem.Click += new System.EventHandler(this.borrarEsteInsumoToolStripMenuItem_Click);
            // 
            // frmProductosTerminados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 625);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.rbnControlReportes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductosTerminados";
            this.Ribbon = this.rbnControlReportes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos Terminados";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProductosTerminados_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnidadMedida.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDetalles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFormula.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlReportes)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit cmbFormula;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LookUpEdit cmbDetalles;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl lblCosto;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit txtCosto;
        private DevExpress.XtraEditors.TextEdit txtCantidad;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.LookUpEdit cmbUnidadMedida;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtUM;
        private DevExpress.XtraBars.Ribbon.RibbonControl rbnControlReportes;
        private DevExpress.XtraBars.BarButtonItem btnGuardar;
        private DevExpress.XtraBars.BarButtonItem btnBorrar;
        private DevExpress.XtraBars.Ribbon.RibbonPage InicioRibbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup InicioRibbonPageGroup1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem borrarEsteInsumoToolStripMenuItem;
    }
}
namespace SAF_PROLIZA
{
    partial class frmDetallesFormulas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetallesFormulas));
            this.rbnControlReportes = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.btnBorrar = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.InicioRibbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.InicioRibbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblIdFormula = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.cmbInsumos = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCantInsumo = new DevExpress.XtraEditors.TextEdit();
            this.cmbUnidadMedida = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblCosto = new DevExpress.XtraEditors.LabelControl();
            this.txtCantidadFormula = new DevExpress.XtraEditors.TextEdit();
            this.txtFamilia = new DevExpress.XtraEditors.TextEdit();
            this.txtFormula = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.borarInsumoDeLaListaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlReportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInsumos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantInsumo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnidadMedida.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadFormula.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFamilia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormula.Properties)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbnControlReportes
            // 
            this.rbnControlReportes.ExpandCollapseItem.Id = 0;
            this.rbnControlReportes.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbnControlReportes.ExpandCollapseItem,
            this.btnGuardar,
            this.btnBorrar,
            this.btnPrint});
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
            this.rbnControlReportes.Size = new System.Drawing.Size(549, 122);
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
            this.btnBorrar.Caption = "Dar de Baja";
            this.btnBorrar.Id = 18;
            this.btnBorrar.ImageOptions.ImageUri.Uri = "Clear";
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBorrar_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "Imprimir Fórmula";
            this.btnPrint.Id = 19;
            this.btnPrint.ImageOptions.ImageUri.Uri = "Print";
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // InicioRibbonPage1
            // 
            this.InicioRibbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.InicioRibbonPageGroup1,
            this.ribbonPageGroup1});
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
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPrint);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Imprimir";
            this.ribbonPageGroup1.Visible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblIdFormula);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Controls.Add(this.txtCantidadFormula);
            this.groupControl1.Controls.Add(this.txtFamilia);
            this.groupControl1.Controls.Add(this.txtFormula);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 122);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(549, 183);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Detalles de Formula";
            // 
            // lblIdFormula
            // 
            this.lblIdFormula.Location = new System.Drawing.Point(5, 17);
            this.lblIdFormula.Name = "lblIdFormula";
            this.lblIdFormula.Size = new System.Drawing.Size(63, 13);
            this.lblIdFormula.TabIndex = 0;
            this.lblIdFormula.Text = "labelControl8";
            this.lblIdFormula.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.Location = new System.Drawing.Point(504, 23);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbInsumos
            // 
            this.cmbInsumos.Location = new System.Drawing.Point(5, 24);
            this.cmbInsumos.MenuManager = this.rbnControlReportes;
            this.cmbInsumos.Name = "cmbInsumos";
            this.cmbInsumos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbInsumos.Size = new System.Drawing.Size(267, 20);
            this.cmbInsumos.TabIndex = 1;
            this.cmbInsumos.EditValueChanged += new System.EventHandler(this.cmbInsumos_EditValueChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.Location = new System.Drawing.Point(2, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(545, 181);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl1_KeyDown);
            this.gridControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseClick);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollStep = 5;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(403, 6);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(74, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Unidad Medida:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(283, 6);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(69, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Cant. Insumo:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 5);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(39, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Insumo:";
            // 
            // txtCantInsumo
            // 
            this.txtCantInsumo.Location = new System.Drawing.Point(278, 24);
            this.txtCantInsumo.MenuManager = this.rbnControlReportes;
            this.txtCantInsumo.Name = "txtCantInsumo";
            this.txtCantInsumo.Size = new System.Drawing.Size(100, 20);
            this.txtCantInsumo.TabIndex = 2;
            this.txtCantInsumo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantInsumo_KeyPress);
            // 
            // cmbUnidadMedida
            // 
            this.cmbUnidadMedida.Location = new System.Drawing.Point(398, 24);
            this.cmbUnidadMedida.MenuManager = this.rbnControlReportes;
            this.cmbUnidadMedida.Name = "cmbUnidadMedida";
            this.cmbUnidadMedida.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUnidadMedida.Size = new System.Drawing.Size(100, 20);
            this.cmbUnidadMedida.TabIndex = 3;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.lblCosto);
            this.groupControl2.Location = new System.Drawing.Point(361, 23);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(179, 100);
            this.groupControl2.TabIndex = 16;
            this.groupControl2.Text = "Costo de Elaboración:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(3, 39);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(15, 33);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "$";
            // 
            // lblCosto
            // 
            this.lblCosto.Appearance.Font = new System.Drawing.Font("Tahoma", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosto.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblCosto.Appearance.Options.UseFont = true;
            this.lblCosto.Appearance.Options.UseForeColor = true;
            this.lblCosto.Location = new System.Drawing.Point(24, 42);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(56, 30);
            this.lblCosto.TabIndex = 11;
            this.lblCosto.Text = "0.00";
            // 
            // txtCantidadFormula
            // 
            this.txtCantidadFormula.Location = new System.Drawing.Point(14, 147);
            this.txtCantidadFormula.MenuManager = this.rbnControlReportes;
            this.txtCantidadFormula.Name = "txtCantidadFormula";
            this.txtCantidadFormula.Properties.ReadOnly = true;
            this.txtCantidadFormula.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadFormula.TabIndex = 0;
            // 
            // txtFamilia
            // 
            this.txtFamilia.Location = new System.Drawing.Point(12, 101);
            this.txtFamilia.MenuManager = this.rbnControlReportes;
            this.txtFamilia.Name = "txtFamilia";
            this.txtFamilia.Properties.ReadOnly = true;
            this.txtFamilia.Size = new System.Drawing.Size(179, 20);
            this.txtFamilia.TabIndex = 0;
            // 
            // txtFormula
            // 
            this.txtFormula.Location = new System.Drawing.Point(13, 56);
            this.txtFormula.MenuManager = this.rbnControlReportes;
            this.txtFormula.Name = "txtFormula";
            this.txtFormula.Properties.ReadOnly = true;
            this.txtFormula.Size = new System.Drawing.Size(342, 20);
            this.txtFormula.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 127);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(47, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Cantidad:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 82);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Familia:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Fórmula:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.borarInsumoDeLaListaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(202, 26);
            // 
            // borarInsumoDeLaListaToolStripMenuItem
            // 
            this.borarInsumoDeLaListaToolStripMenuItem.Name = "borarInsumoDeLaListaToolStripMenuItem";
            this.borarInsumoDeLaListaToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.borarInsumoDeLaListaToolStripMenuItem.Text = "Borrar Insumo de la lista";
            this.borarInsumoDeLaListaToolStripMenuItem.Click += new System.EventHandler(this.borarInsumoDeLaListaToolStripMenuItem_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.gridControl1);
            this.groupControl3.Controls.Add(this.btnAdd);
            this.groupControl3.Controls.Add(this.labelControl4);
            this.groupControl3.Controls.Add(this.cmbInsumos);
            this.groupControl3.Controls.Add(this.cmbUnidadMedida);
            this.groupControl3.Controls.Add(this.txtCantInsumo);
            this.groupControl3.Controls.Add(this.labelControl7);
            this.groupControl3.Controls.Add(this.labelControl6);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl3.Location = new System.Drawing.Point(0, 303);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.ShowCaption = false;
            this.groupControl3.Size = new System.Drawing.Size(549, 239);
            this.groupControl3.TabIndex = 17;
            this.groupControl3.Text = "groupControl3";
            // 
            // frmDetallesFormulas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 542);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.rbnControlReportes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDetallesFormulas";
            this.Ribbon = this.rbnControlReportes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detallles de Fórmulas";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDetallesFormulas_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlReportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInsumos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantInsumo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnidadMedida.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadFormula.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFamilia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormula.Properties)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rbnControlReportes;
        private DevExpress.XtraBars.BarButtonItem btnGuardar;
        private DevExpress.XtraBars.Ribbon.RibbonPage InicioRibbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup InicioRibbonPageGroup1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl lblCosto;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit txtCantidadFormula;
        private DevExpress.XtraEditors.TextEdit txtFamilia;
        private DevExpress.XtraEditors.TextEdit txtFormula;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtCantInsumo;
        private DevExpress.XtraEditors.LookUpEdit cmbUnidadMedida;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LookUpEdit cmbInsumos;
        public DevExpress.XtraEditors.LabelControl lblIdFormula;
        private DevExpress.XtraBars.BarButtonItem btnBorrar;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.ToolStripMenuItem borarInsumoDeLaListaToolStripMenuItem;
        private DevExpress.XtraEditors.GroupControl groupControl3;
    }
}
namespace SAF_PROLIZA
{
    partial class frmFormulasV2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormulasV2));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.btnBaja = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.toolTipController2 = new DevExpress.Utils.ToolTipController(this.components);
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblCosto = new DevExpress.XtraEditors.LabelControl();
            this.txtFormula = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cmbUnidadMedida = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbFamilia = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCantidad = new DevExpress.XtraEditors.TextEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cmbInsumos = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbUnidadMedidaInsumo = new DevExpress.XtraEditors.LookUpEdit();
            this.txtCantInsumo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.borarInsumoDeLaListaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormula.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnidadMedida.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFamilia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInsumos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnidadMedidaInsumo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantInsumo.Properties)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnGuardar,
            this.btnBaja,
            this.barButtonItem1});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 4;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowCategoryInCaption = false;
            this.ribbon.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.ShowQatLocationSelector = false;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(488, 122);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            this.ribbon.ToolTipController = this.toolTipController2;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Caption = "Guardar";
            this.btnGuardar.Id = 1;
            this.btnGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.ImageOptions.Image")));
            this.btnGuardar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGuardar.ImageOptions.LargeImage")));
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGuardar_ItemClick);
            // 
            // btnBaja
            // 
            this.btnBaja.Caption = "Dar de Baja";
            this.btnBaja.Id = 2;
            this.btnBaja.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBaja.ImageOptions.Image")));
            this.btnBaja.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBaja.ImageOptions.LargeImage")));
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBaja_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Imprimir Fórmula";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnGuardar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnBaja);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Inicio";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Impresión";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 517);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.ShowSizeGrip = false;
            this.ribbonStatusBar.Size = new System.Drawing.Size(488, 31);
            // 
            // toolTipController2
            // 
            this.toolTipController2.InitialDelay = 500000;
            this.toolTipController2.ReshowDelay = 1000000;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.lblCosto);
            this.groupControl2.Location = new System.Drawing.Point(270, 193);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(194, 65);
            this.groupControl2.TabIndex = 16;
            this.groupControl2.Text = "Costo de Elaboración:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(3, 24);
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
            this.lblCosto.Appearance.Options.UseTextOptions = true;
            this.lblCosto.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblCosto.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCosto.Location = new System.Drawing.Point(24, 26);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(163, 30);
            this.lblCosto.TabIndex = 11;
            this.lblCosto.Text = "0.00";
            this.lblCosto.TextChanged += new System.EventHandler(this.lblCosto_TextChanged);
            // 
            // txtFormula
            // 
            this.txtFormula.Location = new System.Drawing.Point(11, 148);
            this.txtFormula.Name = "txtFormula";
            this.txtFormula.Size = new System.Drawing.Size(451, 20);
            this.txtFormula.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 128);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Fórmula:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(117, 174);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(85, 13);
            this.labelControl4.TabIndex = 23;
            this.labelControl4.Text = "Unidad de Medida";
            // 
            // cmbUnidadMedida
            // 
            this.cmbUnidadMedida.Location = new System.Drawing.Point(117, 193);
            this.cmbUnidadMedida.Name = "cmbUnidadMedida";
            this.cmbUnidadMedida.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUnidadMedida.Size = new System.Drawing.Size(147, 20);
            this.cmbUnidadMedida.TabIndex = 19;
            // 
            // cmbFamilia
            // 
            this.cmbFamilia.Location = new System.Drawing.Point(11, 238);
            this.cmbFamilia.Name = "cmbFamilia";
            this.cmbFamilia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFamilia.Size = new System.Drawing.Size(253, 20);
            this.cmbFamilia.TabIndex = 20;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(11, 219);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 13);
            this.labelControl3.TabIndex = 22;
            this.labelControl3.Text = "Familia:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 174);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 21;
            this.labelControl2.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(11, 193);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCantidad.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 18;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // groupControl3
            // 
            this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.groupControl3.Controls.Add(this.gridControl1);
            this.groupControl3.Controls.Add(this.btnAdd);
            this.groupControl3.Controls.Add(this.labelControl6);
            this.groupControl3.Controls.Add(this.cmbInsumos);
            this.groupControl3.Controls.Add(this.cmbUnidadMedidaInsumo);
            this.groupControl3.Controls.Add(this.txtCantInsumo);
            this.groupControl3.Controls.Add(this.labelControl7);
            this.groupControl3.Controls.Add(this.labelControl8);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl3.Location = new System.Drawing.Point(0, 278);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.ShowCaption = false;
            this.groupControl3.Size = new System.Drawing.Size(488, 239);
            this.groupControl3.TabIndex = 24;
            this.groupControl3.Text = "groupControl3";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.Location = new System.Drawing.Point(2, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(484, 181);
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
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.Location = new System.Drawing.Point(430, 23);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.ToolTip = "Agrega el isnumo seleccionado a la fórmula";
            this.btnAdd.ToolTipTitle = "Agregar";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(10, 5);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(39, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Insumo:";
            // 
            // cmbInsumos
            // 
            this.cmbInsumos.Location = new System.Drawing.Point(5, 24);
            this.cmbInsumos.Name = "cmbInsumos";
            this.cmbInsumos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbInsumos.Size = new System.Drawing.Size(205, 20);
            this.cmbInsumos.TabIndex = 1;
            this.cmbInsumos.EditValueChanged += new System.EventHandler(this.cmbInsumos_EditValueChanged);
            // 
            // cmbUnidadMedidaInsumo
            // 
            this.cmbUnidadMedidaInsumo.Location = new System.Drawing.Point(322, 24);
            this.cmbUnidadMedidaInsumo.Name = "cmbUnidadMedidaInsumo";
            this.cmbUnidadMedidaInsumo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUnidadMedidaInsumo.Size = new System.Drawing.Size(100, 20);
            this.cmbUnidadMedidaInsumo.TabIndex = 3;
            // 
            // txtCantInsumo
            // 
            this.txtCantInsumo.Location = new System.Drawing.Point(216, 24);
            this.txtCantInsumo.Name = "txtCantInsumo";
            this.txtCantInsumo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCantInsumo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtCantInsumo.Size = new System.Drawing.Size(100, 20);
            this.txtCantInsumo.TabIndex = 2;
            this.txtCantInsumo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantInsumo_KeyPress);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(327, 8);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(74, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Unidad Medida:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(221, 6);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(69, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Cant. Insumo:";
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
            this.borarInsumoDeLaListaToolStripMenuItem.Image = global::SAF_PROLIZA.Properties.Resources.delete;
            this.borarInsumoDeLaListaToolStripMenuItem.Name = "borarInsumoDeLaListaToolStripMenuItem";
            this.borarInsumoDeLaListaToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.borarInsumoDeLaListaToolStripMenuItem.Text = "Borrar Insumo de la lista";
            this.borarInsumoDeLaListaToolStripMenuItem.Click += new System.EventHandler(this.borarInsumoDeLaListaToolStripMenuItem_Click);
            // 
            // toolTipController1
            // 
            this.toolTipController1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.toolTipController1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.toolTipController1.Appearance.Options.UseBackColor = true;
            // 
            // frmFormulasV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 548);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.cmbUnidadMedida);
            this.Controls.Add(this.cmbFamilia);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.txtFormula);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFormulasV2";
            this.Ribbon = this.ribbon;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Detalles de Fórmulas";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFormulasV2_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormula.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnidadMedida.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFamilia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInsumos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnidadMedidaInsumo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantInsumo.Properties)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnGuardar;
        private DevExpress.XtraBars.BarButtonItem btnBaja;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl lblCosto;
        private DevExpress.XtraEditors.TextEdit txtFormula;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit cmbUnidadMedida;
        private DevExpress.XtraEditors.LookUpEdit cmbFamilia;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtCantidad;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LookUpEdit cmbInsumos;
        private DevExpress.XtraEditors.LookUpEdit cmbUnidadMedidaInsumo;
        private DevExpress.XtraEditors.TextEdit txtCantInsumo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem borarInsumoDeLaListaToolStripMenuItem;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.Utils.ToolTipController toolTipController2;
    }
}
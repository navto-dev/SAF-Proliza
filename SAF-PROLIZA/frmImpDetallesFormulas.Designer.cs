namespace SAF_PROLIZA
{
    partial class frmImpDetallesFormulas
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
            this.btnGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.btnBorrar = new DevExpress.XtraBars.BarButtonItem();
            this.rbnControlReportes = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Caption = "Guardar";
            this.btnGuardar.Id = 1;
            this.btnGuardar.ImageOptions.ImageUri.Uri = "Save";
            this.btnGuardar.Name = "btnGuardar";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Caption = "Dar de Baja ";
            this.btnBorrar.Id = 18;
            this.btnBorrar.ImageOptions.ImageUri.Uri = "Clear";
            this.btnBorrar.Name = "btnBorrar";
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
            this.rbnControlReportes.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.rbnControlReportes.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.rbnControlReportes.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.rbnControlReportes.ShowQatLocationSelector = false;
            this.rbnControlReportes.ShowToolbarCustomizeItem = false;
            this.rbnControlReportes.Size = new System.Drawing.Size(738, 27);
            this.rbnControlReportes.Toolbar.ShowCustomizeItem = false;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 27);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowCopyButton = false;
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(738, 437);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmImpDetallesFormulas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 464);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.rbnControlReportes);
            this.Name = "frmImpDetallesFormulas";
            this.Ribbon = this.rbnControlReportes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizador de Impresiones";
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlReportes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btnGuardar;
        private DevExpress.XtraBars.BarButtonItem btnBorrar;
        private DevExpress.XtraBars.Ribbon.RibbonControl rbnControlReportes;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}
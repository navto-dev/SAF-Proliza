using System.Data;


namespace SAF_PROLIZA
{
    public partial class frmRptProductos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmRptProductos(DataTable _Productos)
        {
            InitializeComponent();
            Reportes.rptProductos reporte = new Reportes.rptProductos();
            reporte.SetDataSource(_Productos);
            this.crystalReportViewer1.ReportSource = reporte;
            this.crystalReportViewer1.RefreshReport();
        }
    }
}

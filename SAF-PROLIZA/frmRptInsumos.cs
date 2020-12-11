using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAF_PROLIZA
{
    public partial class frmRptInsumos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmRptInsumos(DataTable _Insumos)
        {
            InitializeComponent();
            Reportes.rptInsumos reporte = new Reportes.rptInsumos();
            reporte.SetDataSource(_Insumos);
            this.crystalReportViewer1.ReportSource = reporte;
            this.crystalReportViewer1.RefreshReport();
        }
    }
}

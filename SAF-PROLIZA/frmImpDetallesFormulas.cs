using CapaNegocios;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace SAF_PROLIZA
{
    public partial class frmImpDetallesFormulas : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmImpDetallesFormulas(DataSet _DetallesFormulas, string cantidad)
        {
            InitializeComponent();
            if (cantidad == "U")
            {
                if (ComprobarTablas(_DetallesFormulas).Equals(""))
                {
                    Reportes.rptFormulasV2 reporte = new Reportes.rptFormulasV2();
                    reporte.SetDataSource(_DetallesFormulas);
                    this.crystalReportViewer1.ReportSource = reporte;
                    this.crystalReportViewer1.RefreshReport();
                }
                else
                {
                    Reportes.rptFormulaDetails reporte = new Reportes.rptFormulaDetails();
                    reporte.SetDataSource(_DetallesFormulas);
                    this.crystalReportViewer1.ReportSource = reporte;
                    this.crystalReportViewer1.RefreshReport();
                }

            }
            else
            {
                //string msj = ComprobarTablas(_DetallesFormulas);
                //if (!msj.Equals(""))
                //{
                //    MessageBox.Show("Las siguientes fórmulas: " + msj + "\nNo tienen productos terminados, esto ocasionará que el formato de impresión tenga desperfectos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);                   
                //}
                Reportes.rptFormulasV2 reporte = new Reportes.rptFormulasV2();
                reporte.SetDataSource(_DetallesFormulas);
                this.crystalReportViewer1.ReportSource = reporte;
                this.crystalReportViewer1.RefreshReport();
            }

        }
        string ComprobarTablas(DataSet _Detalles)
        {
            string msj = "";
            DataTable Productos = new DataTable();
            DataTable DetallesProductos = new DataTable();
            DataTable Formula = _Detalles.Tables["Formula"];
            foreach (DataRow item in Formula.Rows)
            {
                Productos.Rows.Clear();
                string connectionString = ConfigurationManager.ConnectionStrings["sdprolizaEntitiessp"].ConnectionString;

                Productos = new CNProductos(connectionString).ConsultaPorFormula(Convert.ToInt32(item["IdFormula"]));
                if (Productos.Rows.Count == 0)
                {
                    msj += "\n" + item["NombreFormula"].ToString();
                }
            }
            return msj;
        }
    }
}
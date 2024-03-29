﻿using CapaNegocios;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace SAF_PROLIZA
{
    public partial class frmBuscador : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string EstadoFormulario;
        private readonly CNFormulas cnFormula;
        private readonly CNProductos cnProducto;
        private readonly CNInsumos cnInsumos;

        public frmBuscador(string Edo)
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["sdprolizaEntitiessp"].ConnectionString;
            cnFormula = new CNFormulas(connectionString);
            cnProducto = new CNProductos(connectionString);
            cnInsumos = new CNInsumos(connectionString, -1, null, false, 0);
            prepararFormulario(Edo);
            llenarComboInsumos(Edo);
        }
        void prepararFormulario(string Estado)
        {
            switch (Estado)
            {
                case "Formulas":
                    this.Text = "Buscar Formulas";
                    groupControl1.Text = "Buscar Formula";
                    EstadoFormulario = "Formulas";
                    break;
                case "Insumos":
                    this.Text = "Buscar Insumos";
                    groupControl1.Text = "Buscar Insumo";
                    EstadoFormulario = "Insumos";
                    break;
                case "Productos":
                    this.Text = "Buscar Producto";
                    groupControl1.Text = "Buscar Producto";
                    EstadoFormulario = "Productos";
                    break;
            }
        }
        void llenarComboInsumos(string Estado)
        {
            switch (Estado)
            {
                case "Formulas":
                    cmbBuscador.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreFormula"));
                    cmbBuscador.Properties.DataSource = cnFormula.ConsultaGeneral();
                    cmbBuscador.Properties.DisplayMember = "NombreFormula";
                    cmbBuscador.Properties.ValueMember = "NombreFormula";
                    break;
                case "Insumos":
                    cmbBuscador.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreInsumo"));
                    cmbBuscador.Properties.ValueMember = "NombreInsumo";
                    cmbBuscador.Properties.DisplayMember = "NombreInsumo";
                    //cmbBuscador.Properties.DataSource = Objetos.Insumos.ConsultarInsumo().Tables["Insumos"];
                    cmbBuscador.Properties.DataSource = cnInsumos.ConsultaGeneral();
                    break;
                case "Productos":
                    cmbBuscador.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreProducto"));
                    cmbBuscador.Properties.ValueMember = "NombreProducto";
                    cmbBuscador.Properties.DisplayMember = "NombreProducto";
                    cmbBuscador.Properties.DataSource = cnProducto.ConsultaActivos();
                    break;
            }





        }
        void AccionBoton()
        {
            switch (EstadoFormulario)
            {
                case "Formulas":
                    if (cnFormula.ConsultaPorNombre(cmbBuscador.EditValue.ToString(), true).Rows.Count != 0)
                    {
                        Objetos.Nombre = cmbBuscador.EditValue.ToString();
                        Objetos.Activo = false;
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    break;
                case "Insumos":
                    // Dts = Objetos.Insumos.ConsultarInsumoPorNombre(cmbBuscador.EditValue.ToString());
                    //if (Dts.Tables["Insumos"].Rows.Count != 0)
                    if (cnInsumos.ConsultaPorNombre(cmbBuscador.EditValue.ToString()).Rows.Count != 0)
                    {
                        Objetos.Nombre = cmbBuscador.EditValue.ToString();
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    break;
                case "Productos":
                    if (cnProducto.ConsultaPorNombre(cmbBuscador.EditValue.ToString()).Rows.Count != 0)
                    {
                        Objetos.Nombre = cmbBuscador.EditValue.ToString();
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    break;
            }
        }

        private void btnBuscador_Click(object sender, EventArgs e)
        {
            if (cmbBuscador.ItemIndex != -1)
            {
                AccionBoton();
            }
        }
    }
}
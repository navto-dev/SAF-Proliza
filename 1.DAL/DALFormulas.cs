using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALFormulas
    {

        DALBase Objbase;


        #region "propiedades"
        public string Formulas { get; set; }
        #endregion

        #region "Constructores"

        public DALFormulas(DALBase objDALBase, string strUsuarioSistema)
        {
            Objbase = objDALBase;
            this.Formulas = strUsuarioSistema;
        }

        #endregion

        #region "Métodos"
        public string Guardar(string DetalleAccion, DataSet Formulas)
        {
            string mensaje = "";
            try
            {
                if (DetalleAccion == "G")
                {
                    Objbase.CadenaSQL = "spFormulasGuardar";
                    Objbase.InicializaCommand();
                    SqlParameter IdParam = Objbase.AgregarParametro("@IdFormula", SqlDbType.Int, Formulas.Tables["Formulas"].Rows[0]["IdFormula"], "O");
                    Objbase.AgregarParametro("@NombreFormula", SqlDbType.NVarChar, Formulas.Tables["Formulas"].Rows[0]["NombreFormula"]);
                    Objbase.AgregarParametro("@Cantidad", SqlDbType.Int, Formulas.Tables["Formulas"].Rows[0]["Cantidad"]);
                    Objbase.AgregarParametro("@Capacidad", SqlDbType.VarChar, Formulas.Tables["Formulas"].Rows[0]["Capacidad"]);
                    Objbase.AgregarParametro("@UnidadMedida", SqlDbType.NVarChar, Formulas.Tables["Formulas"].Rows[0]["UnidadMedida"]);
                    Objbase.AgregarParametro("@IdFamilia", SqlDbType.Int, Formulas.Tables["Formulas"].Rows[0]["IdFamilia"]);
                    Objbase.AgregarParametro("@DetalleAccion", SqlDbType.VarChar, DetalleAccion);
                    Objbase.EjecutaBD();
                    mensaje = IdParam.Value.ToString();
                }
                else
                {
                    Objbase.CadenaSQL = "spFormulasGuardar";
                    Objbase.InicializaCommand();
                    Objbase.AgregarParametro("@IdFormula", SqlDbType.Int, Formulas.Tables["Formulas"].Rows[0]["IdFormula"]);
                    Objbase.AgregarParametro("@NombreFormula", SqlDbType.NVarChar, Formulas.Tables["Formulas"].Rows[0]["NombreFormula"]);
                    Objbase.AgregarParametro("@Cantidad", SqlDbType.Int, Formulas.Tables["Formulas"].Rows[0]["Cantidad"]);
                    Objbase.AgregarParametro("@IdFamilia", SqlDbType.Int, Formulas.Tables["Formulas"].Rows[0]["IdFamilia"]);
                    Objbase.AgregarParametro("@DetalleAccion", SqlDbType.VarChar, "A");
                    Objbase.EjecutaBD();
                    mensaje = "Actualizado con Exito";
                }
            }
            catch (Exception err)
            {

                mensaje = "Error: " + err.Message;
            }
            return mensaje;
        }
        public DataSet ConsultaPorNombre(string nombre, bool Activo)
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = ("spFormulasConsultaPorNombre");
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@Nombre", SqlDbType.NVarChar, nombre);
            Objbase.AgregarParametro("@Activo", SqlDbType.Bit, Activo);
            dtsRet = Objbase.ConsultaCadena("Formulas");
            return dtsRet;
        }
        public DataSet ConsultaFormulasActivas()
        {
            try
            {
                DataSet dtsRet;
                Objbase.CadenaSQL = "spFormulasConsultaActivo";
                Objbase.InicializaCommand();
                dtsRet = Objbase.ConsultaCadena("Formulas");
                return dtsRet;
            }
            catch (Exception er)
            {

                throw new Exception(er.Message, er.InnerException);
            }
        }
        public DataSet ConsultaPorId(int IdFormula)
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = ("spFormulasConsultaPorId");
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@IdFormula", SqlDbType.Int, IdFormula);
            dtsRet = Objbase.ConsultaCadena("Formulas");
            return dtsRet;
        }
        public void DardeBajaFormula(int IdFormula)
        {
            Objbase.CadenaSQL = ("spFormulasDardeBaja");
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@IdFormula", SqlDbType.Int, IdFormula);
            Objbase.EjecutaBD();
        }
        #endregion
      
    }
}

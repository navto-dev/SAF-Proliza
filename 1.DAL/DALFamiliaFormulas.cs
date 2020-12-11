using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALFamiliaFormulas
    {
        DALBase Objbase;
        #region "propiedades"
        public string FamiliaFormulas { get; set; }
        #endregion

        #region "Constructores"
        public DALFamiliaFormulas(DALBase ObjDALBase, string UsuarioSistema)
        {
            Objbase = ObjDALBase;
            this.FamiliaFormulas = UsuarioSistema;
        }
        #endregion

        #region "Métodos"
        public string Guardar(string DetalleAccion, DataSet Familia)
        {

            try
            {
                if (DetalleAccion == "G")
                {
                    Objbase.CadenaSQL = "spFamiliasFormulasGuardar";
                    Objbase.InicializaCommand();
                    SqlParameter IdParam = Objbase.AgregarParametro("@IdFamilia", SqlDbType.Int, Familia.Tables["FamiliaFormulas"].Rows[0]["IdFamilia"], "O");
                    Objbase.AgregarParametro("@NombreFamilia", SqlDbType.NVarChar, Familia.Tables["FamiliaFormulas"].Rows[0]["NombreFamilia"]);
                    Objbase.AgregarParametro("@DetalleAccion", SqlDbType.VarChar, DetalleAccion);
                    Objbase.EjecutaBD();
                    return IdParam.ToString();
                }
                else
                {
                    Objbase.CadenaSQL = "spFamiliaFormulasGuardar";
                    Objbase.InicializaCommand();
                    Objbase.AgregarParametro("@IdFamilia", SqlDbType.Int, Familia.Tables["FamiliaFormulas"].Rows[0]["IdFamilia"]);
                    Objbase.AgregarParametro("@NombreFamilia", SqlDbType.NVarChar, Familia.Tables["FamiliaFormulas"].Rows[0]["NombreFamilia"]);
                    Objbase.AgregarParametro("@DetalleAccion", SqlDbType.VarChar, "A");
                    Objbase.EjecutaBD();
                    return "";
                }
            }
            catch (Exception err)
            {

                throw new Exception(err.Message, err.InnerException);
            }

        }


        public DataSet Consulta()
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spFamiliaFormulasConsultaGeneral";
            Objbase.InicializaCommand();
            dtsRet = Objbase.ConsultaCadena("FamiliaFormulas");
            return dtsRet;
        }
        #endregion
    }
}

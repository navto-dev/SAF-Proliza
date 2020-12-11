using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALFamiliaInsumos
    {
        DALBase Objbase;
        #region "propiedades"
        public string FamiliaInsumos { get; set; }
        #endregion

        #region "Constructores"
        public DALFamiliaInsumos(DALBase ObjDALBase, string UsuarioSistema)
        {
            Objbase = ObjDALBase;
            this.FamiliaInsumos = UsuarioSistema;
        }
        #endregion

        #region "Métodos"
        public string Guardar(string DetalleAccion, DataSet Familia)
        {

            try
            {
                if (DetalleAccion == "G")
                {
                    Objbase.CadenaSQL = "spFamiliaInsumosGuardar";
                    Objbase.InicializaCommand();
                    SqlParameter IdParam = Objbase.AgregarParametro("@IdFamilia", SqlDbType.Int, Familia.Tables["FamiliaInsumos"].Rows[0]["IdFamilia"],"O");
                    Objbase.AgregarParametro("@NombreFamilia", SqlDbType.NVarChar, Familia.Tables["FamiliaInsumos"].Rows[0]["NombreFamilia"]);
                    Objbase.AgregarParametro("@DetalleAccion", SqlDbType.VarChar, DetalleAccion);
                    Objbase.EjecutaBD();
                    return IdParam.ToString();
                }
                else
                {
                    Objbase.CadenaSQL = "spFamiliaInsumosGuardar";
                    Objbase.InicializaCommand();
                    Objbase.AgregarParametro("@IdFamilia", SqlDbType.Int, Familia.Tables["FamiliaInsumos"].Rows[0]["IdFamilia"]);
                    Objbase.AgregarParametro("@NombreFamilia", SqlDbType.NVarChar, Familia.Tables["FamiliaInsumos"].Rows[0]["NombreFamilia"]);
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

        public DataSet ConsultaGeneral()
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spFamiliaInsumosConsultaGeneral";
            Objbase.InicializaCommand();            
            dtsRet = Objbase.ConsultaCadena("FamiliaInsumos");
            return dtsRet;
        }

        #endregion
    }
}

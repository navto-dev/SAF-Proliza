using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALMonedas
    {
        DALBase Objbase;
        #region "propiedades"
        public string Monedas { get; set; }
        #endregion

        #region "Constructores"
        public DALMonedas(DALBase ObjDALBase, string UsuarioSistema)
        {
            Objbase = ObjDALBase;
            this.Monedas = UsuarioSistema;
        }
        #endregion
        public string Guardar(string DetalleAccion, DataSet Moneda)
        {

            try
            {
                if (DetalleAccion == "G")
                {
                    Objbase.CadenaSQL = "spMonedasGuardar";
                    Objbase.InicializaCommand();
                    SqlParameter IdParam = Objbase.AgregarParametro("@IdMoneda", SqlDbType.Int, Moneda.Tables["Monedas"].Rows[0]["IdMoneda"],"O");
                    Objbase.AgregarParametro("@NombreMoneda", SqlDbType.NVarChar, Moneda.Tables["Monedas"].Rows[0]["NombreMoneda"]);
                    Objbase.AgregarParametro("@DetalleAccion", SqlDbType.VarChar, DetalleAccion );
                    Objbase.EjecutaBD();
                    return IdParam.ToString();
                }
                else
                {
                    Objbase.CadenaSQL = "spMonedasGuardar";
                    Objbase.InicializaCommand();
                    Objbase.AgregarParametro("@IdMoneda", SqlDbType.Int, Moneda.Tables["Monedas"].Rows[0]["IdMoneda"]);
                    Objbase.AgregarParametro("@NombreMoneda", SqlDbType.NVarChar, Moneda.Tables["Monedas"].Rows[0]["NombreMoneda"]);
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
            Objbase.CadenaSQL = "spMonedasConsultaGeneral";
            Objbase.InicializaCommand();            
            dtsRet = Objbase.ConsultaCadena("Monedas");
            return dtsRet;
        }
    }
}

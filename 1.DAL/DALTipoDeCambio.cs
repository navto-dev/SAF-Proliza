using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALTipoDeCambio
    {
        DALBase Objbase;
        #region "propiedades"
        public string TipoDeCambio { get; set; }
        #endregion

        #region "Constructores"
        public DALTipoDeCambio(DALBase ObjDALBase, string UsuarioSistema)
        {
            Objbase = ObjDALBase;
            this.TipoDeCambio = UsuarioSistema;
        }
        #endregion

        #region "Métodos"
        public string Guardar(string DetalleAccion, DataSet TipoDeCambio)
        {

            try
            {
                if (DetalleAccion == "G")
                {
                    Objbase.CadenaSQL = "spTipoDeCambioGuardar";
                    Objbase.InicializaCommand();
                    SqlParameter IdParam = Objbase.AgregarParametro("@IdTipoCambio", SqlDbType.Int, TipoDeCambio.Tables["TipoDecambio"].Rows[0]["IdTipoCambio"], "O");
                    Objbase.AgregarParametro("@IdMoneda", SqlDbType.Int, TipoDeCambio.Tables["TipoDeCambio"].Rows[0]["IdMoneda"]);
                    Objbase.AgregarParametro("@FactorConversion", SqlDbType.Decimal, TipoDeCambio.Tables["TipoDeCambio"].Rows[0]["FactorConversion"]);
                    Objbase.AgregarParametro("@DetalleAccion", SqlDbType.VarChar, DetalleAccion);
                    Objbase.EjecutaBD();
                    return IdParam.Value.ToString();
                }
                else
                {
                    Objbase.CadenaSQL = "spTipoDeCambioGuardar";
                    Objbase.InicializaCommand();
                    Objbase.AgregarParametro("@IdTipoCambio", SqlDbType.Int, TipoDeCambio.Tables["TipoDecambio"].Rows[0]["IdTipoCambio"]);
                    Objbase.AgregarParametro("@IdMoneda", SqlDbType.Int, TipoDeCambio.Tables["TipoDeCambio"].Rows[0]["IdMoneda"]);
                    Objbase.AgregarParametro("@FactorConversion", SqlDbType.Decimal, TipoDeCambio.Tables["TipoDeCambio"].Rows[0]["FactorConversion"]);
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


        public DataSet ConsultaPorMoneda(int IdMoneda)
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spTipoDeCambioConsultaPorMoneda";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@IdMoneda", SqlDbType.Int, IdMoneda);
            dtsRet = Objbase.ConsultaCadena("TipoDeCambio");
            return dtsRet;
        }

        public DataSet ConsultaReciente()
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spTipoCambioConsultaReciente";
            Objbase.InicializaCommand();
            dtsRet = Objbase.ConsultaCadena("TipoDeCambio");
            return dtsRet;
        }
        #endregion
    }
}

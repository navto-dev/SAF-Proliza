using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALDetallesProductos
    {

        DALBase Objbase;
        #region "propiedades"
        public string DetallesProductos { get; set; }
        #endregion

        #region "Constructores"
        public DALDetallesProductos(DALBase ObjDALBase, string UsuarioSistema)
        {
            Objbase = ObjDALBase;
            this.DetallesProductos = UsuarioSistema;
        }
        #endregion

        #region "Métodos"
        public string Guardar(string DetalleAccion, DataSet DetallesProductos)
        {
            try
            {
                if (DetalleAccion == "G")
                {
                    Objbase.CadenaSQL = "spDetalleProductosGuardar";
                    Objbase.InicializaCommand();
                    SqlParameter IdParam = Objbase.AgregarParametro("@IdDetalle", SqlDbType.Int, DetallesProductos.Tables["DetallesProductos"].Rows[0]["IdDetalle"], "O");
                    Objbase.AgregarParametro("@IdInsumo", SqlDbType.Int, DetallesProductos.Tables["DetallesProductos"].Rows[0]["IdInsumo"]);
                    Objbase.AgregarParametro("@IdProducto", SqlDbType.Int, DetallesProductos.Tables["DetallesProductos"].Rows[0]["IdProducto"]);
                    Objbase.AgregarParametro("@CostoInsumo", SqlDbType.Decimal, DetallesProductos.Tables["DetallesProductos"].Rows[0]["CostoInsumo"]);
                    Objbase.AgregarParametro("@DetalleAccion", SqlDbType.VarChar, DetalleAccion);
                    Objbase.EjecutaBD();
                    return IdParam.Value.ToString();
                }
                else
                {
                    Objbase.CadenaSQL = "spDetalleProductosGuardar";
                    Objbase.InicializaCommand();
                    Objbase.AgregarParametro("@IdDetalle", SqlDbType.Int, DetallesProductos.Tables["DetallesProductos"].Rows[0]["IdDetalle"]);
                    Objbase.AgregarParametro("@IdInsumo", SqlDbType.Int, DetallesProductos.Tables["DetallesProductos"].Rows[0]["IdInsumo"]);
                    Objbase.AgregarParametro("@IdProducto", SqlDbType.Int, DetallesProductos.Tables["DetallesProductos"].Rows[0]["IdProducto"]);
                    Objbase.AgregarParametro("@CostoInsumo", SqlDbType.Decimal, DetallesProductos.Tables["DetallesProductos"].Rows[0]["CostoInsumo"]);
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
        public DataSet ConsultaPorProducto(int IdProducto)
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spDetallesProductosConsultaPorProducto";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@IdProducto", SqlDbType.Int, IdProducto);
            dtsRet = Objbase.ConsultaCadena("DetallesProductos");
            return dtsRet;
        }
        public DataSet ConsultaPorInsumo(int IdInsumo)
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spBuscaProductoPorInsumo";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@IdInsumo", SqlDbType.Int, IdInsumo);
            dtsRet = Objbase.ConsultaCadena("DetallesProductos");
            return dtsRet;
        }
        #endregion
    }
}

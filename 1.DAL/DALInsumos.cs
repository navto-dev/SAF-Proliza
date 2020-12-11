using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALInsumos
    {
        DALBase Objbase;
        #region "propiedades"
        public string Insumos { get; set; }
        #endregion

        #region "Constructores"
        public DALInsumos(DALBase ObjDALBase, string UsuarioSistema)
        {
            Objbase = ObjDALBase;
            this.Insumos = UsuarioSistema;
        }
        #endregion
        public string Guardar(string DetalleAccion, DataSet Insumos)
        {

            try
            {
                if (DetalleAccion == "G")
                {
                    Objbase.CadenaSQL = "spInsumosGuardar";
                    Objbase.InicializaCommand();
                    SqlParameter IdParam = Objbase.AgregarParametro("@IdInsumo", SqlDbType.Int, Insumos.Tables["Insumos"].Rows[0]["IdInsumo"],"O");
                    Objbase.AgregarParametro("@IdProveedor", SqlDbType.Int, Insumos.Tables["Insumos"].Rows[0]["IdProveedor"]);
                    Objbase.AgregarParametro("@NombreInsumo", SqlDbType.NVarChar, Insumos.Tables["Insumos"].Rows[0]["NombreInsumo"]);
                    Objbase.AgregarParametro("@NombreInterno", SqlDbType.NVarChar, Insumos.Tables["Insumos"].Rows[0]["NombreInterno"]);
                    Objbase.AgregarParametro("@UnidadMedida", SqlDbType.NVarChar, Insumos.Tables["Insumos"].Rows[0]["UnidadMedida"]);
                    Objbase.AgregarParametro("@PrecioUnitario", SqlDbType.Decimal, Insumos.Tables["Insumos"].Rows[0]["PrecioUnitario"]);
                    Objbase.AgregarParametro("@TotalCompraMX", SqlDbType.Decimal, Insumos.Tables["Insumos"].Rows[0]["TotalCompraMX"]);                
                    Objbase.AgregarParametro("@IdFamilia", SqlDbType.Int, Insumos.Tables["Insumos"].Rows[0]["IdFamilia"]);
                    Objbase.AgregarParametro("@IdMoneda", SqlDbType.Int, Insumos.Tables["Insumos"].Rows[0]["IdMoneda"]);
                    Objbase.AgregarParametro("@DetalleAccion", SqlDbType.VarChar, DetalleAccion);
                    Objbase.EjecutaBD();
                    return IdParam.Value.ToString();
                }
                else
                {
                    Objbase.CadenaSQL = "spInsumosGuardar";
                    Objbase.InicializaCommand();
                    Objbase.AgregarParametro("@IdInsumo", SqlDbType.Int, Insumos.Tables["Insumos"].Rows[0]["IdInsumo"]);
                    Objbase.AgregarParametro("@IdProveedor", SqlDbType.Int, Insumos.Tables["Insumos"].Rows[0]["IdProveedor"]);
                    Objbase.AgregarParametro("@NombreInsumo", SqlDbType.NVarChar, Insumos.Tables["Insumos"].Rows[0]["NombreInsumo"]);
                    Objbase.AgregarParametro("@NombreInterno", SqlDbType.NVarChar, Insumos.Tables["Insumos"].Rows[0]["NombreInterno"]);
                    Objbase.AgregarParametro("@UnidadMedida", SqlDbType.NVarChar, Insumos.Tables["Insumos"].Rows[0]["UnidadMedida"]);
                    Objbase.AgregarParametro("@PrecioUnitario", SqlDbType.Decimal, Insumos.Tables["Insumos"].Rows[0]["PrecioUnitario"]);
                    Objbase.AgregarParametro("@TotalCompraMX", SqlDbType.Decimal, Insumos.Tables["Insumos"].Rows[0]["TotalCompraMX"]);
                    Objbase.AgregarParametro("@IdFamilia", SqlDbType.Int, Insumos.Tables["Insumos"].Rows[0]["IdFamilia"]);
                    Objbase.AgregarParametro("@IdMoneda", SqlDbType.Int, Insumos.Tables["Insumos"].Rows[0]["IdMoneda"]);
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
        public DataSet ConsultaPorProveedor(int IdProveedor)
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spInsumosConsultaProveedor";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@IdProveedor", SqlDbType.Int, IdProveedor);
            dtsRet = Objbase.ConsultaCadena("Insumos");
            return dtsRet;
        }
        public DataSet ConsultaPorId(int IdInsumo)
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spInsumosConsultaPorId";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@IdInsumo", SqlDbType.Int, IdInsumo);
            dtsRet = Objbase.ConsultaCadena("Insumos");
            return dtsRet;
        }
        public DataSet ConsultaPorFamilia(int IdFamilia)
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spInsumosConsultaPorFamilia";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@IdFamilia", SqlDbType.Int, IdFamilia);
            dtsRet = Objbase.ConsultaCadena("Insumos");
            return dtsRet;
        }
        public DataSet ConsultaGeneral()
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spInsumosConsultaGeneral";
            Objbase.InicializaCommand();            
            dtsRet = Objbase.ConsultaCadena("Insumos");
            return dtsRet;
        }
        public DataSet ConsultaPorNombre(string nombre)
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spInsumosConsultaPorNombre";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@nombreInsumo", SqlDbType.NVarChar, nombre);
            dtsRet = Objbase.ConsultaCadena("Insumos");
            return dtsRet;
        }
        public DataSet ConsultaIngredientes()
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spInsumosConsultaIngredietnes";
            Objbase.InicializaCommand();
            dtsRet = Objbase.ConsultaCadena("Insumos");
            return dtsRet;
        }
        public DataSet ConsultaAcabados()
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spInsumosConsultaAcabados";
            Objbase.InicializaCommand();
            dtsRet = Objbase.ConsultaCadena("Insumos");
            return dtsRet;
        }
        public void DardeBajaPorId(int IdInsumo)
        {
            Objbase.CadenaSQL = "spInsumosDarDeBaja";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@IdInsumo", SqlDbType.Int, IdInsumo);
            Objbase.EjecutaBD();
        }
        public DataSet ConsultaPorMoneda(int IdMoneda)
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spInsumosConsultaPorMoneda";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@IdMoneda", SqlDbType.NVarChar, IdMoneda);
            dtsRet = Objbase.ConsultaCadena("Insumos");
            return dtsRet;
        }
    }
}

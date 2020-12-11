using System;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class DALProductos
    {

        DALBase Objbase;
        #region "propiedades"
        public string Productos { get; set; }
        #endregion

        #region "Constructores"
        public DALProductos(DALBase ObjDALBase, string UsuarioSistema)
        {
            Objbase = ObjDALBase;
            this.Productos = UsuarioSistema;
        }
        #endregion

        #region "Métodos"
        public string Guardar(string DetalleAccion, DataSet Productos)
        {
            string mensaje = "";
            try
            {
                if (DetalleAccion == "G")
                {
                    Objbase.CadenaSQL = "spProductosTerminadosGuardar";
                    Objbase.InicializaCommand();
                    SqlParameter IdParam = Objbase.AgregarParametro("@IdProducto", SqlDbType.Int, Productos.Tables["ProductosTerminados"].Rows[0]["IdProducto"], "O");
                    Objbase.AgregarParametro("@IdFormula", SqlDbType.Int, Productos.Tables["ProductosTerminados"].Rows[0]["IdFormula"]);
                    Objbase.AgregarParametro("@NombreProducto", SqlDbType.NVarChar, Productos.Tables["ProductosTerminados"].Rows[0]["NombreProducto"]);
                    Objbase.AgregarParametro("@Cantidad", SqlDbType.Decimal, Productos.Tables["ProductosTerminados"].Rows[0]["Cantidad"]);
                    Objbase.AgregarParametro("@UnidadMedida", SqlDbType.VarChar, Productos.Tables["ProductosTerminados"].Rows[0]["UnidadMedida"]);
                    Objbase.AgregarParametro("@CostoUnitario", SqlDbType.Decimal, Productos.Tables["ProductosTerminados"].Rows[0]["CostoUnitario"]);
                    Objbase.AgregarParametro("@CostoTotalProducto", SqlDbType.Decimal, Productos.Tables["ProductosTerminados"].Rows[0]["CostoTotalProducto"]);                    
                    Objbase.AgregarParametro("@Activo", SqlDbType.Bit, Productos.Tables["ProductosTerminados"].Rows[0]["Activo"]);
                    Objbase.AgregarParametro("@DetalleAccion", SqlDbType.VarChar, DetalleAccion);
                    Objbase.EjecutaBD();
                    mensaje = IdParam.Value.ToString();
                }
                else
                {
                    Objbase.CadenaSQL = "spProductosTerminadosGuardar";
                    Objbase.InicializaCommand();
                    Objbase.AgregarParametro("@IdProducto", SqlDbType.Int, Productos.Tables["ProductosTerminados"].Rows[0]["IdProducto"]);
                    Objbase.AgregarParametro("@IdFormula", SqlDbType.Int, Productos.Tables["ProductosTerminados"].Rows[0]["IdFormula"]);
                    Objbase.AgregarParametro("@NombreProducto", SqlDbType.NVarChar, Productos.Tables["ProductosTerminados"].Rows[0]["NombreProducto"]);
                    Objbase.AgregarParametro("@Cantidad", SqlDbType.Decimal, Productos.Tables["ProductosTerminados"].Rows[0]["Cantidad"]);
                    Objbase.AgregarParametro("@UnidadMedida", SqlDbType.VarChar, Productos.Tables["ProductosTerminados"].Rows[0]["UnidadMedida"]);
                    Objbase.AgregarParametro("@CostoUnitario", SqlDbType.Decimal, Productos.Tables["ProductosTerminados"].Rows[0]["CostoUnitario"]);
                    Objbase.AgregarParametro("@CostoTotalProducto", SqlDbType.Decimal, Productos.Tables["ProductosTerminados"].Rows[0]["CostoTotalProducto"]);
                    Objbase.AgregarParametro("@Activo", SqlDbType.Bit, Productos.Tables["ProductosTerminados"].Rows[0]["Activo"]);
                    Objbase.AgregarParametro("@DetalleAccion", SqlDbType.Char, "A");
                    Objbase.EjecutaBD();
                    return "";
                }
            }
            catch (Exception err)
            {

                mensaje = "Error: "+ err.Message;
            }
            return mensaje;
        }
        public DataSet ConsultaPorNombre(string nombre)
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spProductosTerminadosConsultaPorNombre";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@NombreProducto",SqlDbType.NVarChar,nombre);
            dtsRet = Objbase.ConsultaCadena("ProductosTerminados");
            return dtsRet;
        }
        public DataSet ConsultaPorId(int IdProducto)
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spProductosTerminadosConsultaPorId";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@IdProducto", SqlDbType.Int, IdProducto);
            dtsRet = Objbase.ConsultaCadena("ProductosTerminados");
            return dtsRet;
        }
        public DataSet ConsultaPorFormula(int IdFormula)
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spProductosTerminadosConsultaPorFormula";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@IdFormula", SqlDbType.Int, IdFormula);
            dtsRet = Objbase.ConsultaCadena("ProductosTerminados");
            return dtsRet;
        }
        public DataSet ConsultaActivos()
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spProductosTerminadosConsultaActivos";
            Objbase.InicializaCommand();            
            dtsRet = Objbase.ConsultaCadena("ProductosTerminados");
            return dtsRet;
        }
        public DataSet ConsultaCatalogo()
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spProductosTerminadosConsultaCatalogo";
            Objbase.InicializaCommand();
            dtsRet = Objbase.ConsultaCadena("ProductosTerminados");
            return dtsRet;
        }
        public DataSet ConsultaVariedades(int IdFormula, string NombreProducto)
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spProductosTerminadosConsultaVariedades";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@IdFormula", SqlDbType.Int, IdFormula);
            Objbase.AgregarParametro("@NombreProducto", SqlDbType.VarChar, NombreProducto);
            dtsRet = Objbase.ConsultaCadena("ProductosTerminados");
            return dtsRet;
        }
        public void DardeBajaPorFormula(int IdFormula)
        {
            Objbase.CadenaSQL = "spDarDeBajaProductosPorFormula";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@IdFormula", SqlDbType.Int, IdFormula);
            Objbase.EjecutaBD();
        }
        public void DardeBajaPorId(int IdProducto)
        {
            Objbase.CadenaSQL = "spProductosTerminadosDarDeBaja";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@IdProduto", SqlDbType.Int, IdProducto);
            Objbase.EjecutaBD();
        }
        #endregion

    }
}

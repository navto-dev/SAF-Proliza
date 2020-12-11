using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALDetallesFormulas
    {
        DALBase Objbase;
        #region "propiedades"
        public string DetallesFormulas { get; set; }
        #endregion

        #region "Constructores"
        public DALDetallesFormulas(DALBase ObjDALBase, string UsuarioSistema)
        {
            Objbase = ObjDALBase;
            this.DetallesFormulas = UsuarioSistema;
        }
        #endregion

        #region "Métodos"
        public string Guardar(string accion, DataSet Detalle)
        {
            try
            {
                if (accion =="G")
                {
                    Objbase.CadenaSQL = "spDetallesFormulasGuardar";
                    Objbase.InicializaCommand();
                    SqlParameter IdParam = Objbase.AgregarParametro("@IdDetalle", SqlDbType.Int, Detalle.Tables["DetallesFormulas"].Rows[0]["IdDetalle"], "O");
                    Objbase.AgregarParametro("@IdFormula", SqlDbType.Int, Detalle.Tables["DetallesFormulas"].Rows[0]["IdFormula"]);
                    Objbase.AgregarParametro("@IdInsumo", SqlDbType.Int, Detalle.Tables["DetallesFormulas"].Rows[0]["IdInsumo"]);
                    Objbase.AgregarParametro("@CantidadInsumo", SqlDbType.Decimal, Detalle.Tables["DetallesFormulas"].Rows[0]["CantidadInsumo"]);
                    Objbase.AgregarParametro("@UnidadMedidaInsumo", SqlDbType.NVarChar, Detalle.Tables["DetallesFormulas"].Rows[0]["UnidadMedidaInsumo"]);
                    Objbase.AgregarParametro("@CostoInsumo", SqlDbType.Decimal, Detalle.Tables["DetallesFormulas"].Rows[0]["CostoInsumo"]);
                    Objbase.AgregarParametro("@DetalleAccion", SqlDbType.VarChar, accion); 
                    Objbase.EjecutaBD();
                    return IdParam.Value.ToString();
                }
                else
                {
                    Objbase.CadenaSQL = "spDetallesFormulasGuardar";
                    Objbase.InicializaCommand();
                    Objbase.AgregarParametro("@IdDetalle", SqlDbType.Int, Detalle.Tables["DetallesFormulas"].Rows[0]["IdDetalle"]);
                    Objbase.AgregarParametro("@IdFormula", SqlDbType.Int, Detalle.Tables["DetallesFormulas"].Rows[0]["IdFormula"]);
                    Objbase.AgregarParametro("@IdInsumo", SqlDbType.Int, Detalle.Tables["DetallesFormulas"].Rows[0]["IdInsumo"]);
                    Objbase.AgregarParametro("@CantidadInsumo", SqlDbType.Decimal, Detalle.Tables["DetallesFormulas"].Rows[0]["CantidadInsumo"]);
                    Objbase.AgregarParametro("@UnidadMedidaInsumo", SqlDbType.NVarChar, Detalle.Tables["DetallesFormulas"].Rows[0]["UnidadMedidaInsumo"]);
                    Objbase.AgregarParametro("@CostoInsumo", SqlDbType.Decimal, Detalle.Tables["DetallesFormulas"].Rows[0]["CostoInsumo"]);
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

        public DataSet ConsultaPorFormula(int IdFormula)
        {
            try
            {
                DataSet dtsRet;
                Objbase.CadenaSQL = ("spDetallesFormulasConsultaPorFormula");
                Objbase.InicializaCommand();
                Objbase.AgregarParametro("@IdFormula", SqlDbType.Int, IdFormula);
                dtsRet = Objbase.ConsultaCadena("DetallesFormulas");
                return dtsRet;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }
        public DataSet ConsultaPorId(int IdDetalle)
        {
            try
            {
                DataSet dtsRet;
                Objbase.CadenaSQL = ("spDetallesFormulasConsultaPorId");
                Objbase.InicializaCommand();
                Objbase.AgregarParametro("@IdDetalle", SqlDbType.Int, IdDetalle);
                dtsRet = Objbase.ConsultaCadena("DetallesFormulas");
                return dtsRet;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }
        public DataSet ConsultaPorInsumo(int IdInsumo)
        {
            try
            {
                DataSet dtsRet;
                Objbase.CadenaSQL = ("spDetallesFormulasConsultaPorInsumo");
                Objbase.InicializaCommand();
                Objbase.AgregarParametro("@IdInsumo", SqlDbType.Int, IdInsumo);
                dtsRet = Objbase.ConsultaCadena("DetallesFormulas");
                return dtsRet;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }
        public void CambiarPrecios(int IdDetalle, decimal precio, int IdFormula)
        {
            Objbase.CadenaSQL = "spCambiarPreciosFormulas";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@IdDetalle", SqlDbType.Int, IdDetalle);
            Objbase.AgregarParametro("@IdFormula", SqlDbType.Int, IdFormula);
            Objbase.AgregarParametro("@Precio", SqlDbType.Decimal, precio);
            Objbase.EjecutaBD();
        }
        public DataSet ConsultaPorMoneda()
        {
            try
            {
                DataSet dtsRet;
                Objbase.CadenaSQL = ("spDetallesFormulasConsultaPorMoneda");
                Objbase.InicializaCommand();
                dtsRet = Objbase.ConsultaCadena("DetallesFormulas");
                return dtsRet;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }
        public void DardeBajaPorId(int IdDetalle)
        {
            Objbase.CadenaSQL = "spDetallesFormulasDaraDeBaja";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@IdDetalle", SqlDbType.Int, IdDetalle);
            Objbase.EjecutaBD();
        }
        #endregion
    }
}


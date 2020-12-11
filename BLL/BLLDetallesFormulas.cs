using System;
using System.Collections.Generic;
using System.Data;
namespace BLL
{
    public class BLLDetallesFormulas : BLLBase
    {
        public int IdDetalle, IdFormula, IdInsumo;
        public string NombreFormula, NombreInsumo, NombreInterno, UnidadMedidaInsumo;
        public decimal CantidadInsumo, CostoInsumo;
        public bool Activo;
        DAL.DALDetallesFormulas Detalles;
        #region "Constructores"
        public BLLDetallesFormulas(String Conexion, String UsuarioSistema) : base(Conexion, UsuarioSistema) { }

        public BLLDetallesFormulas(string Conexion, string UsuarioSistema, DAL.DALBase DALBase) : base(Conexion, UsuarioSistema, DALBase) { }
        #endregion
        #region "Métodos"
        public DataSet CreaDSDetallesFormulas()
        {
            try
            {
                DataSet dtsret = new DataSet();
                DataTable objDataTable = dtsret.Tables.Add("DetallesFormulas");
                objDataTable.Columns.Add("IdDetalle", Type.GetType("System.String"));
                objDataTable.Columns.Add("IdFormula", Type.GetType("System.String"));
                objDataTable.Columns.Add("IdInsumo", Type.GetType("System.String"));
                objDataTable.Columns.Add("CantidadInsumo", Type.GetType("System.String"));
                objDataTable.Columns.Add("UnidadMedidaInsumo", Type.GetType("System.String"));
                objDataTable.Columns.Add("CostoInsumo", Type.GetType("System.String"));
                objDataTable.Columns.Add("Activo", Type.GetType("System.String"));
                return dtsret;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }
        public DataSet ConvierteEntidadDS()
        {
            try
            {
                DataSet dtsRet = new BLL.BLLDetallesFormulas(Gral.gStrConexion, Gral.gStrUsuario).CreaDSDetallesFormulas();
                DataRow dtrReg = dtsRet.Tables["DetallesFormulas"].Rows.Add();
                dtrReg["IdDetalle"] = this.IdDetalle;
                dtrReg["IdFormula"] = this.IdFormula;
                dtrReg["IdInsumo"] = this.IdInsumo;
                dtrReg["CantidadInsumo"] = this.CantidadInsumo;
                dtrReg["UnidadMedidaInsumo"] = this.UnidadMedidaInsumo;
                dtrReg["CostoInsumo"] = this.CostoInsumo;
                dtrReg["Activo"] = this.Activo;
                return dtsRet;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err);
            }
        }
        public List<BLLDetallesFormulas> ConvierteDSEntidad(DataSet DF)
        {
            try
            {
                List<BLLDetallesFormulas> Lista = new List<BLLDetallesFormulas>();
                foreach (DataRow dtrDetalles in DF.Tables["DetallesFormulas"].Rows)
                {
                    BLLDetallesFormulas Detalles = new BLLDetallesFormulas("", "");
                    Detalles.IdDetalle = int.Parse(dtrDetalles["IdDetalle"].ToString());
                    Detalles.IdFormula = int.Parse(dtrDetalles["IdFormula"].ToString());
                    Detalles.NombreFormula = dtrDetalles["NombreFormula"].ToString();
                    Detalles.IdInsumo = int.Parse(dtrDetalles["IdInsumo"].ToString());
                    Detalles.NombreInsumo = dtrDetalles["NombreInsumo"].ToString();
                    Detalles.NombreInterno = dtrDetalles["NombreInterno"].ToString();
                    Detalles.CantidadInsumo = decimal.Parse(dtrDetalles["CantidadInsumo"].ToString());
                    Detalles.UnidadMedidaInsumo = dtrDetalles["UnidadMedidaInsumo"].ToString();
                    Detalles.CostoInsumo = decimal.Parse(dtrDetalles["CostoInsumo"].ToString());
                    Detalles.Activo = (bool)(dtrDetalles["Activo"]);
                    Lista.Add(Detalles);
                }
                return Lista;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err);
            }
        }
        public string Guardar(BLLDetallesFormulas DF)
        {
            string mensaje = "";
            DataSet dtsRet = DF.ConvierteEntidadDS();
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Detalles = new DAL.DALDetallesFormulas(objDALBase, StrUsuarioSistema);
                mensaje = Detalles.Guardar("G", dtsRet);
            }
            catch (Exception er)
            {

                mensaje = "Error: " + er.Message;
            }
            return mensaje;
        }
        public string Actualizar(BLLDetallesFormulas DF)
        {
            string mensaje = "";
            DataSet dtsRet = DF.ConvierteEntidadDS();
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Detalles = new DAL.DALDetallesFormulas(objDALBase, StrUsuarioSistema);
                mensaje = Detalles.Guardar("A", dtsRet);
            }
            catch (Exception er)
            {

                mensaje = "Error: " + er.Message;
            }
            return mensaje;
        }
        public DataSet ConsultarDetallePorId(int Id)
        {
            bool blnIniObjCon = false;
            try
            {

                List<BLLDetallesFormulas> lista = new List<BLLDetallesFormulas>();
                blnIniObjCon = InicializaObjConexion();
                Detalles = new DAL.DALDetallesFormulas(objDALBase, StrUsuarioSistema);
                DataSet dtsRet = Detalles.ConsultaPorId(Id);
                lista = ConvierteDSEntidad(dtsRet);
                return dtsRet;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err.InnerException);
            }

            finally
            {
                if (blnIniObjCon) objDALBase.CierraConexion();
            }
        }
        public DataSet ConsultarDetallePorFormula(int Id)
        {
            bool blnIniObjCon = false;
            try
            {

                //List<BLLDetallesFormulas> lista = new List<BLLDetallesFormulas>();
                blnIniObjCon = InicializaObjConexion();
                Detalles = new DAL.DALDetallesFormulas(objDALBase, StrUsuarioSistema);
                DataSet dtsRet = Detalles.ConsultaPorFormula(Id);
                //lista = ConvierteDSEntidad(dtsRet);
                return dtsRet;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err.InnerException);
            }

            finally
            {
                if (blnIniObjCon) objDALBase.CierraConexion();
            }
        }
        public DataSet ConsultarDetallePorInsumo(int Id)
        {
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Detalles = new DAL.DALDetallesFormulas(objDALBase, StrUsuarioSistema);
                DataSet dtsRet = Detalles.ConsultaPorInsumo(Id);
                return dtsRet;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err.InnerException);
            }

            finally
            {
                if (blnIniObjCon) objDALBase.CierraConexion();
            }
        }
        public void ActualizarPrecios(int IdDetalle, decimal precio, int IdFormula)
        {
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Detalles = new DAL.DALDetallesFormulas(objDALBase, StrUsuarioSistema);
                Detalles.CambiarPrecios(IdDetalle, precio, IdFormula);
            }
            catch 
            {
            }
        }
        public DataSet ConsultarDetallePorMoneda()
        {
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Detalles = new DAL.DALDetallesFormulas(objDALBase, StrUsuarioSistema);
                DataSet dtsRet = Detalles.ConsultaPorMoneda();
                return dtsRet;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err.InnerException);
            }

            finally
            {
                if (blnIniObjCon) objDALBase.CierraConexion();
            }
        }
        public void DarDeBajaPorId(int IdProducto)
        {
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Detalles = new DAL.DALDetallesFormulas(objDALBase, StrUsuarioSistema);
                Detalles.DardeBajaPorId(IdProducto);
            }
            catch
            {
            }
        }
        #endregion

    }
}

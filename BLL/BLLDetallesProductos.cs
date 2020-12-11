using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class BLLDetallesProductos : BLLBase
    {
        public int IdDetalle, IdInsumo, IdProducto;
        public decimal CostoInsumo;
        DAL.DALDetallesProductos Detalles;
        #region "Constructores"
        public BLLDetallesProductos(String Conexion, String UsuarioSistema) : base(Conexion, UsuarioSistema) { }

        public BLLDetallesProductos(string Conexion, string UsuarioSistema, DAL.DALBase DALBase) : base(Conexion, UsuarioSistema, DALBase) { }
        #endregion
        public DataSet CreaDSDetallesProductos()
        {
            try
            {
                DataSet dtsret = new DataSet();
                DataTable objDataTable = dtsret.Tables.Add("DetallesProductos");
                objDataTable.Columns.Add("IdDetalle", Type.GetType("System.String"));
                objDataTable.Columns.Add("IdProducto", Type.GetType("System.String"));
                objDataTable.Columns.Add("IdInsumo", Type.GetType("System.String"));                
                objDataTable.Columns.Add("CostoInsumo", Type.GetType("System.String"));
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
                DataSet dtsRet = new BLL.BLLDetallesProductos(Gral.gStrConexion, Gral.gStrUsuario).CreaDSDetallesProductos();
                DataRow dtrReg = dtsRet.Tables["DetallesProductos"].Rows.Add();
                dtrReg["IdDetalle"] = this.IdDetalle;
                dtrReg["IdProducto"] = this.IdProducto;
                dtrReg["IdInsumo"] = this.IdInsumo;
                dtrReg["CostoInsumo"] = this.CostoInsumo;
                return dtsRet;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err);
            }
        }

        public string Guardar(BLLDetallesProductos DP)
        {
            string mensaje = "";
            DataSet dtsRet = DP.ConvierteEntidadDS();
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Detalles = new DAL.DALDetallesProductos(objDALBase, StrUsuarioSistema);
                mensaje = Detalles.Guardar("G", dtsRet);
            }
            catch (Exception er)
            {

                mensaje = "Error: " + er.Message;
            }
            return mensaje;
        }
        public string Actualizar(BLLDetallesProductos DP)
        {
            string mensaje = "";
            DataSet dtsRet = DP.ConvierteEntidadDS();
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Detalles = new DAL.DALDetallesProductos(objDALBase, StrUsuarioSistema);
                mensaje = Detalles.Guardar("A", dtsRet);
            }
            catch (Exception er)
            {

                mensaje = "Error: " + er.Message;
            }
            return mensaje;
        }
        public DataSet ConsultarDetallesPorProducto(int Id)
        {
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Detalles = new DAL.DALDetallesProductos(objDALBase, StrUsuarioSistema);
                DataSet dtsRet = Detalles.ConsultaPorProducto(Id);
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
        public DataSet ConsultarDetallesPorInsumo(int Id)
        {
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Detalles = new DAL.DALDetallesProductos(objDALBase, StrUsuarioSistema);
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
    }
}

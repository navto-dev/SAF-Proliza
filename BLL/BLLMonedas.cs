using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class BLLMonedas : BLLBase
    {
        public int IdMoneda;
        public string nombreMoneda;
        DAL.DALMonedas Monedas;
        #region "Constructores"
        public BLLMonedas(String Conexion, String UsuarioSistema) : base(Conexion, UsuarioSistema) { }

        public BLLMonedas(string Conexion, string UsuarioSistema, DAL.DALBase DALBase) : base(Conexion, UsuarioSistema, DALBase) { }
        #endregion
        public DataSet CreaDSMonedas()
        {
            try
            {
                DataSet dtsret = new DataSet();
                DataTable objDataTable = dtsret.Tables.Add("Monedas");
                objDataTable.Columns.Add("IdMoneda", Type.GetType("System.String"));
                objDataTable.Columns.Add("NombreMoneda", Type.GetType("System.String"));                
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
                DataSet dtsRet = new BLL.BLLMonedas(Gral.gStrConexion, Gral.gStrUsuario).CreaDSMonedas();
                DataRow dtrReg = dtsRet.Tables["Monedas"].Rows.Add();              
                dtrReg["IdMoneda"] = this.IdMoneda;
                dtrReg["NombreMoneda"] = this.nombreMoneda;
                return dtsRet;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err);
            }
        }
        public string Guardar(BLLMonedas M)
        {
            string mensaje = "";
            DataSet dtsRet = M.ConvierteEntidadDS();
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Monedas = new DAL.DALMonedas(objDALBase, StrUsuarioSistema);
                mensaje = Monedas.Guardar("G", dtsRet);
            }
            catch (Exception er)
            {

                mensaje = "Error: " + er.Message;
            }
            return mensaje;
        }
        public string Actualizar(BLLMonedas M)
        {
            string mensaje = "";
            DataSet dtsRet = M.ConvierteEntidadDS();
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Monedas = new DAL.DALMonedas(objDALBase, StrUsuarioSistema);
                mensaje = Monedas.Guardar("A", dtsRet);
            }
            catch (Exception er)
            {

                mensaje = "Error: " + er.Message;
            }
            return mensaje;
        }
        public DataSet ConsultarMonedas()
        {
            bool blnIniObjCon = false;
            try
            {                
                blnIniObjCon = InicializaObjConexion();
                Monedas = new DAL.DALMonedas(objDALBase, StrUsuarioSistema);
                DataSet dtsRet = Monedas.ConsultaGeneral();                
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

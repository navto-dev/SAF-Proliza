using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class BLLFamiliaFormulas : BLLBase
    {
        public int IdFamilia;
        public string nombreFamilia;
        DAL.DALFamiliaFormulas Familias;
        #region "Constructores"
        public BLLFamiliaFormulas(String Conexion, String UsuarioSistema) : base(Conexion, UsuarioSistema) { }

        public BLLFamiliaFormulas(string Conexion, string UsuarioSistema, DAL.DALBase DALBase) : base(Conexion, UsuarioSistema, DALBase) { }
        #endregion

        public DataSet CreaDSDetallesFamilias()
        {
            try
            {
                DataSet dtsret = new DataSet();
                DataTable objDataTable = dtsret.Tables.Add("FamiliaFormulas");
                objDataTable.Columns.Add("IdFamilia", Type.GetType("System.String"));
                objDataTable.Columns.Add("NombreFamilia", Type.GetType("System.String"));
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
                DataSet dtsRet = new BLL.BLLFamiliaFormulas(Gral.gStrConexion, Gral.gStrUsuario).CreaDSDetallesFamilias();
                DataRow dtrReg = dtsRet.Tables["FamiliaFormulas"].Rows.Add();
                dtrReg["IdFamilia"] = this.IdFamilia;
                dtrReg["NombreFamilia"] = this.nombreFamilia;
                return dtsRet;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err);
            }
        }
        public string Guardar(BLLFamiliaFormulas FF)
        {
            string mensaje = "";
            DataSet dtsRet = FF.ConvierteEntidadDS();
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Familias = new DAL.DALFamiliaFormulas(objDALBase, StrUsuarioSistema);
                mensaje = Familias.Guardar("G", dtsRet);
            }
            catch (Exception er)
            {

                mensaje = "Error: " + er.Message;
            }
            return mensaje;
        }
        public string Actualizar(BLLFamiliaFormulas FF)
        {
            string mensaje = "";
            DataSet dtsRet = FF.ConvierteEntidadDS();
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Familias = new DAL.DALFamiliaFormulas(objDALBase, StrUsuarioSistema);
                mensaje = Familias.Guardar("A", dtsRet);
            }
            catch (Exception er)
            {

                mensaje = "Error: " + er.Message;
            }
            return mensaje;
        }
        public DataSet ConsultarFamilias()
        {
            bool blnIniObjCon = false;
            try
            {

                List<BLLFamiliaFormulas> lista = new List<BLLFamiliaFormulas>();
                blnIniObjCon = InicializaObjConexion();
                Familias = new DAL.DALFamiliaFormulas(objDALBase, StrUsuarioSistema);
                DataSet dtsRet = Familias.Consulta();                
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

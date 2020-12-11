using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class BLLFormulas : BLLBase
    {
        public int IdFormula, Cantidad, IdFamilia;
        public string NombreFormula, NombreFamilia, UnidadMedida, Capacidad;
        public bool Activo;
        public decimal CostoTotal;
        DAL.DALFormulas Formulas;
        #region "Constructores"
        public BLLFormulas(String Conexion, String UsuarioSistema) : base(Conexion, UsuarioSistema) { }
        public BLLFormulas(string Conexion, string UsuarioSistema, DAL.DALBase DALBase) : base(Conexion, UsuarioSistema, DALBase) { }
        #endregion
        #region "Métodos"
        public DataSet CreaDSFormulas()
        {
            try
            {
                DataSet dtsret = new DataSet();
                DataTable objDataTable = dtsret.Tables.Add("Formulas");
                objDataTable.Columns.Add("IdFormula", Type.GetType("System.String"));
                objDataTable.Columns.Add("NombreFormula", Type.GetType("System.String"));
                objDataTable.Columns.Add("Cantidad", Type.GetType("System.String"));
                objDataTable.Columns.Add("Capacidad", Type.GetType("System.String"));
                objDataTable.Columns.Add("UnidadMedida", Type.GetType("System.String"));
                objDataTable.Columns.Add("CostoTotal", Type.GetType("System.String"));
                objDataTable.Columns.Add("IdFamilia", Type.GetType("System.String"));
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
                DataSet dtsRet = new BLL.BLLFormulas(Gral.gStrConexion, Gral.gStrUsuario).CreaDSFormulas();
                DataRow dtrReg = dtsRet.Tables["Formulas"].Rows.Add();
                dtrReg["IdFormula"] = this.IdFormula;
                dtrReg["NombreFormula"] = this.NombreFormula;                
                dtrReg["Cantidad"] = this.Cantidad;
                dtrReg["Capacidad"] = this.Capacidad;
                dtrReg["UnidadMedida"] = this.UnidadMedida;
                dtrReg["CostoTotal"] = this.CostoTotal;
                dtrReg["IdFamilia"] = this.IdFamilia;
                dtrReg["Activo"] = this.Activo;                
                return dtsRet;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err);
            }
        }       
        public string Guardar(BLLFormulas F)
        {
            string mensaje = "";
            DataSet dtsRet = F.ConvierteEntidadDS();
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Formulas = new DAL.DALFormulas(objDALBase,StrUsuarioSistema);
                mensaje = Formulas.Guardar("G", dtsRet);
                Console.Write(mensaje);
            }
            catch (Exception er)
            {

                mensaje = "Error: "+er.Message;
            }
            return mensaje;
        }
        public string Actualizar(BLLFormulas F)
        {
            string mensaje = "";
            DataSet dtsRet = F.ConvierteEntidadDS();
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Formulas = new DAL.DALFormulas(objDALBase, StrUsuarioSistema);
                mensaje = Formulas.Guardar("A", dtsRet);
            }
            catch (Exception er)
            {

                mensaje = "Error: " + er.Message;
            }
            return mensaje;
        }
        public DataSet ConsultarFormulas()
        {
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Formulas = new DAL.DALFormulas(objDALBase, StrUsuarioSistema);
                DataSet dtsRet = Formulas.ConsultaFormulasActivas();
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
        public DataSet ConsultarFormulaPorNombre(string Nombre, bool Activo)
        {
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Formulas = new DAL.DALFormulas(objDALBase, StrUsuarioSistema);
                DataSet dtsRet = Formulas.ConsultaPorNombre(Nombre, Activo);
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
        public DataSet ConsultarFormulaPorId(int IdFormula)
        {
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Formulas = new DAL.DALFormulas(objDALBase, StrUsuarioSistema);
                DataSet dtsRet = Formulas.ConsultaPorId(IdFormula);
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
        public void DarDeBaja(int IdFormula)
        {            
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Formulas = new DAL.DALFormulas(objDALBase, StrUsuarioSistema);
                Formulas.DardeBajaFormula(IdFormula);
            }
            catch 
            { 
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class BLLProductos : BLLBase
    {
        public int IdFormula, IdProducto, IdDetalle;
        public string NombreProducto, UnidadMedida, NombreFormula;
        public decimal Cantidad, CostoUnitario, CostoTotalProducto;
        public bool Activo;
        DAL.DALProductos Productos;
        #region "Constructores"
        public BLLProductos(String Conexion, String UsuarioSistema) : base(Conexion, UsuarioSistema) { }

        public BLLProductos(string Conexion, string UsuarioSistema, DAL.DALBase DALBase) : base(Conexion, UsuarioSistema, DALBase) { }
        #endregion

        #region "Métodos"
        public DataSet CreaDSProductos()
        {
            try
            {
                DataSet dtsret = new DataSet();
                DataTable objDataTable = dtsret.Tables.Add("ProductosTerminados");
                objDataTable.Columns.Add("IdProducto", Type.GetType("System.String"));
                objDataTable.Columns.Add("Idformula", Type.GetType("System.String"));
                objDataTable.Columns.Add("NombreProducto", Type.GetType("System.String"));
                objDataTable.Columns.Add("Cantidad", Type.GetType("System.String"));
                objDataTable.Columns.Add("UnidadMedida", Type.GetType("System.String"));
                objDataTable.Columns.Add("CostoUnitario", Type.GetType("System.String"));
                objDataTable.Columns.Add("CostoTotalProducto", Type.GetType("System.String"));
                objDataTable.Columns.Add("IdDetalle", Type.GetType("System.String"));
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
                DataSet dtsRet = new BLL.BLLProductos(Gral.gStrConexion, Gral.gStrUsuario).CreaDSProductos();
                DataRow dtrReg = dtsRet.Tables["ProductosTerminados"].Rows.Add();
                dtrReg["IdProducto"] = this.IdProducto;
                dtrReg["IdFormula"] = this.IdFormula;
                dtrReg["NombreProducto"] = this.NombreProducto;
                dtrReg["Cantidad"] = this.Cantidad;
                dtrReg["UnidadMedida"] = this.UnidadMedida;
                dtrReg["CostoUnitario"] = this.CostoUnitario;
                dtrReg["CostoTotalProducto"] = this.CostoTotalProducto;
                dtrReg["IdDetalle"] = this.IdDetalle;
                dtrReg["Activo"] = this.Activo;
                return dtsRet;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err);
            }
        }
       
        public string Guardar(BLLProductos P)
        {
            string mensaje = "";
            DataSet dtsRet = P.ConvierteEntidadDS();
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Productos = new DAL.DALProductos(objDALBase, StrUsuarioSistema);
                mensaje = Productos.Guardar("G", dtsRet);
            }
            catch (Exception er)
            {

                mensaje = "Error: " + er.Message;
            }
            return mensaje;
        }
        public string Actualizar(BLLProductos P)
        {
            string mensaje = "";
            DataSet dtsRet = P.ConvierteEntidadDS();
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Productos = new DAL.DALProductos(objDALBase, StrUsuarioSistema);
                mensaje = Productos.Guardar("A", dtsRet);
            }
            catch (Exception er)
            {

                mensaje = "Error: " + er.Message;
            }
            return mensaje;
        }
        public DataSet ConsultarProductos()
        {
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Productos = new DAL.DALProductos(objDALBase, StrUsuarioSistema);
                DataSet dtsRet = Productos.ConsultaActivos();
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
        public DataSet ConsultarProductoPorNombre(string Nombre)
        {
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Productos = new DAL.DALProductos(objDALBase, StrUsuarioSistema);
                DataSet dtsRet = Productos.ConsultaPorNombre(Nombre);
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
        public DataSet ConsultarProductoPorId(int Id)
        {
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Productos = new DAL.DALProductos(objDALBase, StrUsuarioSistema);
                DataSet dtsRet = Productos.ConsultaPorId(Id);
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
        public DataSet ConsultarProductosPorFormula(int Id)
        {
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Productos = new DAL.DALProductos(objDALBase, StrUsuarioSistema);
                DataSet dtsRet = Productos.ConsultaPorFormula(Id);
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
        public DataSet ConsultarCatalogoProductos()
        {
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Productos = new DAL.DALProductos(objDALBase, StrUsuarioSistema);
                DataSet dtsRet = Productos.ConsultaCatalogo();
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
        public DataSet ConsultarVariedadProductos(int Id, string nombreProducto)
        {
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Productos = new DAL.DALProductos(objDALBase, StrUsuarioSistema);
                DataSet dtsRet = Productos.ConsultaVariedades(Id,nombreProducto);
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
        public void DarDeBajaPorFormula(int IdFormula)
        {
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Productos = new DAL.DALProductos(objDALBase, StrUsuarioSistema);
                Productos.DardeBajaPorFormula(IdFormula);
            }
            catch
            {
            }
        }
        public void DarDeBajaPorId(int IdProducto)
        {
            bool blnIniObjCon = false;
            try
            {
                blnIniObjCon = InicializaObjConexion();
                Productos = new DAL.DALProductos(objDALBase, StrUsuarioSistema);
                Productos.DardeBajaPorId(IdProducto);
            }
            catch
            {
            }
        }
        #endregion
    }
}

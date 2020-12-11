using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALProveedores
    {
        DALBase Objbase;
        #region "propiedades"
        public string Proveedores { get; set; }
        #endregion

        #region "Constructores"
        public DALProveedores(DALBase ObjDALBase, string UsuarioSistema)
        {
            Objbase = ObjDALBase;
            this.Proveedores = UsuarioSistema;
        }
        #endregion

        #region "Métodos"

        public string Guardar(string DetalleAccion, DataSet Proveedores)
        {
            string mensaje = "";
            try
            {
                if (DetalleAccion == "G")
                {
                    Objbase.CadenaSQL = "spProveedoresGuardar";
                    Objbase.InicializaCommand();
                    SqlParameter IdParam = Objbase.AgregarParametro("@IdProveedor", SqlDbType.Int, Proveedores.Tables["Proveedores"].Rows[0]["IdProveedor"], "O");
                    Objbase.AgregarParametro("@NombreProveedor", SqlDbType.NVarChar, Proveedores.Tables["Proveedores"].Rows[0]["NombreProveedor"]);
                    Objbase.AgregarParametro("@DetalleAccion", SqlDbType.VarChar, DetalleAccion);
                    Objbase.EjecutaBD();
                    mensaje = IdParam.ToString();
                }
                else
                {
                    Objbase.CadenaSQL = "spProveedoresGuardar";
                    Objbase.InicializaCommand();
                    Objbase.AgregarParametro("@IdProveedor", SqlDbType.Int, Proveedores.Tables["Proveedores"].Rows[0]["IdProveedor"]);
                    Objbase.AgregarParametro("@NombreProveedor", SqlDbType.NVarChar, Proveedores.Tables["Proveedores"].Rows[0]["NombreProveedor"]);
                    Objbase.AgregarParametro("@DetalleAccion", SqlDbType.VarChar, "A");
                    Objbase.EjecutaBD();
                    return "";
                }
            }
            catch (Exception err)
            {

                mensaje = "Error: " + err.Message;
            }
            return mensaje;
        }
        public DataSet ConsultaGeneral()
        {
            DataSet dtsRet;
            try
            {
                Objbase.CadenaSQL = "spProveedoresConsutaGeneral";
                Objbase.InicializaCommand();
                dtsRet = Objbase.ConsultaCadena("Proveedores");
                return dtsRet;
            }
            catch (Exception er)
            {

                throw new Exception(er.Message, er.InnerException);
            }
        }

        public void Borrar(int Id)
        {
            Objbase.CadenaSQL = "spProveedoresDarDeBaja";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@IdProveedor", SqlDbType.Int, Id);
            Objbase.EjecutaBD();
        }


        #endregion
    }
}

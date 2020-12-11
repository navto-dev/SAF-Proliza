using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALUsuario
    {
        DALBase Objbase;
        #region "propiedades"
        public string Usuario { get; set; }
        #endregion

        #region "Constructores"
        public DALUsuario(DALBase ObjDALBase, string UsuarioSistema)
        {
            Objbase = ObjDALBase;
            this.Usuario = UsuarioSistema;
        }
        #endregion
        #region "Métodos"

        public string Guardar(char DetalleAccion, DataSet Usuario)
        {
            try
            {
                if (DetalleAccion == 'G')
                {
                    Objbase.CadenaSQL = "spUsuarioGuardar";
                    Objbase.InicializaCommand();
                    SqlParameter IdParam = Objbase.AgregarParametro("@IdUsuario", SqlDbType.Int, Usuario.Tables["Usuario"].Rows[0]["IdUsuario"], "O");
                    Objbase.AgregarParametro("@Nombre", SqlDbType.NVarChar, Usuario.Tables["Usuario"].Rows[0]["Nombre"]);
                    Objbase.AgregarParametro("@Username", SqlDbType.NVarChar, Usuario.Tables["Usuario"].Rows[0]["Username"]);
                    Objbase.AgregarParametro("@Pasword", SqlDbType.NVarChar, Usuario.Tables["Usuario"].Rows[0]["Pasword"]);
                    Objbase.AgregarParametro("@IdRol", SqlDbType.Int, Usuario.Tables["Usuario"].Rows[0]["IdRol"]);
                    Objbase.AgregarParametro("@email", SqlDbType.NVarChar, Usuario.Tables["Usuario"].Rows[0]["email"]);                    
                    Objbase.AgregarParametro("@DetalleAccion", SqlDbType.Char, DetalleAccion);
                    Objbase.EjecutaBD();
                    return IdParam.Value.ToString();
                }
                else
                {
                    Objbase.CadenaSQL = "spUsuarioGuardar";
                    Objbase.InicializaCommand();
                    Objbase.AgregarParametro("@IdUsuario", SqlDbType.Int, Usuario.Tables["Usuario"].Rows[0]["IdUsuario"]);
                    Objbase.AgregarParametro("@Nombre", SqlDbType.NVarChar, Usuario.Tables["Usuario"].Rows[0]["Nombre"]);
                    Objbase.AgregarParametro("@Username", SqlDbType.NVarChar, Usuario.Tables["Usuario"].Rows[0]["Username"]);
                    Objbase.AgregarParametro("@Pasword", SqlDbType.NVarChar, Usuario.Tables["Usuario"].Rows[0]["Pasword"]);
                    Objbase.AgregarParametro("@IdRol", SqlDbType.Int, Usuario.Tables["Usuario"].Rows[0]["IdRol"]);
                    Objbase.AgregarParametro("@email", SqlDbType.NVarChar, Usuario.Tables["Usuario"].Rows[0]["email"]);
                    Objbase.AgregarParametro("@DetalleAccion", SqlDbType.Char, 'A');
                    Objbase.EjecutaBD();
                    return "";
                }
            }
            catch (Exception err)
            {

                throw new Exception(err.Message, err.InnerException);
            }
        }
        public DataSet ValidaUsername(string username)
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spUsuariosValidaUsername";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@Username", SqlDbType.NVarChar, username);
            dtsRet = Objbase.ConsultaCadena("Usuario");
            return dtsRet;
        }
        public DataSet ConsultaGeneral()
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spUsuariosConsultaUsuariosActivos";
            Objbase.InicializaCommand();
            dtsRet = Objbase.ConsultaCadena("Usuario");
            return dtsRet;
        }
        public DataSet consultaPorUsername(string username, string pwd)
        {
            try
            {
                DataSet dtsRet;
                Objbase.CadenaSQL = "spUsuarioConsultaUsername";
                Objbase.InicializaCommand();
                Objbase.AgregarParametro("@Username", SqlDbType.VarChar, username);
                Objbase.AgregarParametro("@Pasword", SqlDbType.VarChar, pwd);
                dtsRet = Objbase.ConsultaCadena("Usuario");
                return dtsRet;
            }
            catch (Exception err)
            {                               
                throw new Exception (err.Message);
            }
        }
        public void DarDeBajaUsuario(int IdUsuario)
        {
            try
            {
                Objbase.CadenaSQL = "spUsuarioDarDeBaja";
                Objbase.InicializaCommand();
                Objbase.AgregarParametro("@IdUsuario", SqlDbType.Int, IdUsuario);
                Objbase.EjecutaBD();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataSet ConsultaPorId(int IdUsuario)
        {
            try
            {
                Objbase.CadenaSQL = "spUsuarioConsultaPorId";
                Objbase.InicializaCommand();
                Objbase.AgregarParametro("@IdUsuario", SqlDbType.Int, IdUsuario);
                DataSet dtsRet = Objbase.ConsultaCadena("Usuario");
                return dtsRet;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet ConsultaRolesActivos()
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spRolesUsuarioConsultaActivo";
            Objbase.InicializaCommand();
            dtsRet = Objbase.ConsultaCadena("RolesUsuarios");
            return dtsRet;
        }

        public void Respaldo()
        {
            Objbase.CadenaSQL = "spRespaldo";
            Objbase.InicializaCommand();        
            Objbase.EjecutaBD();
        }

        public DataSet ConsultaPorFecha(int Mes, int anio)
        {
            DataSet dtsRet;
            Objbase.CadenaSQL = "spConsultaRespaldo";
            Objbase.InicializaCommand();
            Objbase.AgregarParametro("@Mes", SqlDbType.Int, Mes);
            Objbase.AgregarParametro("@anio", SqlDbType.Int, anio);
            dtsRet = Objbase.ConsultaCadena("respaldo");
            return dtsRet;
        }

        #endregion

    }
}

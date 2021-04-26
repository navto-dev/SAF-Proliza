using CapaDatos;
using Entidades;
using System;
using System.Data;


namespace CapaNegocios
{

    public class CNUsuarios
    {
        private readonly CDUsuarios cdUsuario;
        public CNUsuarios(string conexion)
        {
            cdUsuario = new CDUsuarios(conexion);
        }

        public int Guardar(UsuariosModel Objeto)
        {
            int res;
            try
            {
                res = cdUsuario.Guardar(Objeto);
            }
            catch (Exception)
            {
                res = 0;
            }

            return res;
        }
        public int Actualizar(UsuariosModel Parametro)
        {
            try
            {
                return cdUsuario.Actualizar(Parametro);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaValidaUsername(string Username)
        {
            try
            {
                return cdUsuario.ConsultaGridValidaUserName(Username);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaGeneral()
        {
            try
            {
                return cdUsuario.ConsultaGridGeneral();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaLOGIN(string username, string Pwd)
        {
            try
            {
                return cdUsuario.ConsultaGridLOGIN(username, Pwd);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaPorId(int IdUsuario)
        {
            try
            {
                return cdUsuario.ConsultaGridPorId(IdUsuario);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaRolesActivos()
        {
            try
            {
                return cdUsuario.ConsultaGridRolesActivos();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public int Borrar(int IdUsuario)
        {
            try
            {
                return cdUsuario.Borrar(IdUsuario);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }

        #region Respaldos
        public int Respaldo()
        {
            int res;
            try
            {
                res = cdUsuario.GuardarRespaldo();
            }
            catch (Exception)
            {
                res = 0;
            }

            return res;
        }
        public int Respaldo(string ruta)
        {
            int res;
            try
            {
                res = cdUsuario.GuardarRespaldo(ruta);
            }
            catch (Exception)
            {
                res = 0;
            }

            return res;
        }
        public DataTable ConsultaRespaldoFecha(int Mes, int anio)
        {
            try
            {
                return cdUsuario.ConsultaGridRespaldoPorFecha(Mes, anio);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        #endregion
    }
}

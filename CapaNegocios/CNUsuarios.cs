using CapaDatos;
using Entidades;
using System;
using System.Data;


namespace CapaNegocios
{
    public class CNUsuarios
    {
        public int Guardar(UsuariosModel Objeto)
        {
            int res;
            try
            {
                res = new CDUsuarios().Guardar(Objeto);
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
                return new CDUsuarios().Actualizar(Parametro);
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
                return new CDUsuarios().ConsultaGridValidaUserName(Username);
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
                return new CDUsuarios().ConsultaGridGeneral();
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
                return new CDUsuarios().ConsultaGridLOGIN(username, Pwd);
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
                return new CDUsuarios().ConsultaGridPorId(IdUsuario);
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
                return new CDUsuarios().ConsultaGridRolesActivos();
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
                return new CDUsuarios().Borrar(IdUsuario);
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
                res = new CDUsuarios().GuardarRespaldo();
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
                return new CDUsuarios().ConsultaGridRespaldoPorFecha(Mes, anio);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        #endregion
    }
}

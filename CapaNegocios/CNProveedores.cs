using CapaDatos;
using Entidades;
using System;
using System.Data;

namespace CapaNegocios
{
    public class CNProveedores
    {

        public int Guardar(ProveedoresModel Objeto)
        {
            int res;
            try
            {
                res = new CDProveedores().Guardar(Objeto);
            }
            catch (Exception)
            {
                res = 0;
            }

            return res;
        }
        public int Actualizar(ProveedoresModel Parametro)
        {
            try
            {
                return new CDProveedores().Actualizar(Parametro);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public int Borrar(int IdProveedor)
        {
            try
            {
                return new CDProveedores().Borrar(IdProveedor);
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
                return new CDProveedores().ConsultaGridGeneral();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaIndividual(int IdProveedor)
        {
            try
            {
                return new CDProveedores().ConsultaGridPorId(IdProveedor);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}

using CapaDatos;
using Entidades;
using System;
using System.Data;

namespace CapaNegocios
{
    public class CNProveedores
    {
        private readonly CDProveedores cdProveedores;

        public CNProveedores(string conexion)
        {
            cdProveedores = new CDProveedores(conexion);
        }

        public int Guardar(ProveedoresModel Objeto)
        {
            int res;
            try
            {
                res = cdProveedores.Guardar(Objeto);
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
                return cdProveedores.Actualizar(Parametro);
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
                return cdProveedores.Borrar(IdProveedor);
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
                return cdProveedores.ConsultaGridGeneral();
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
                return cdProveedores.ConsultaGridPorId(IdProveedor);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}

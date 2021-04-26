using CapaDatos;
using Entidades;
using System;
using System.Data;

namespace CapaNegocios
{
    public class CNProductos
    {
        private readonly CDProductos cdProductos;

        public CNProductos(string conexion)
        {
            cdProductos = new CDProductos(conexion);
        }
        public int Guardar(ProductosModel Objeto)
        {
            int res;
            try
            {
                res = cdProductos.Guardar(Objeto);
            }
            catch (Exception)
            {
                res = 0;
            }

            return res;
        }
        public int Actualizar(ProductosModel Parametro)
        {
            try
            {
                return cdProductos.Actualizar(Parametro);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public int BorrarPorFormula(int IdFormula)
        {
            try
            {
                return cdProductos.BorrarPorFormula(IdFormula);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public int Borrar(int IdProducto)
        {
            try
            {
                return cdProductos.BorrarPorId(IdProducto);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaActivos()
        {
            try
            {
                return cdProductos.ConsultaGridActivos();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaCatalogo()
        {
            try
            {
                return cdProductos.ConsultaGridCatalogo();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaPorNombre(string Nombre)
        {
            try
            {
                return cdProductos.ConsultaGridPorNombre(Nombre);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaConsultaPorId(int IdProducto)
        {
            try
            {
                return cdProductos.ConsultaGridPorId(IdProducto);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaPorFormula(int IdFormula)
        {
            try
            {
                return cdProductos.ConsultaGridPorFormula(IdFormula);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaVariedades(int IdFormula, string NombreProducto)
        {
            try
            {
                return cdProductos.ConsultaGridVariedades(IdFormula, NombreProducto);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }

    }
}

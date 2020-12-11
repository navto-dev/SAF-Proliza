using CapaDatos;
using Entidades;
using System;
using System.Data;

namespace CapaNegocios
{
    public class CNProductos
    {
        public int Guardar(ProductosModel Objeto)
        {
            int res;
            try
            {
                res = new CDProductos().Guardar(Objeto);
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
                return new CDProductos().Actualizar(Parametro);
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
                return new CDProductos().BorrarPorFormula(IdFormula);
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
                return new CDProductos().BorrarPorId(IdProducto);
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
                return new CDProductos().ConsultaGridActivos();
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
                return new CDProductos().ConsultaGridCatalogo();
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
                return new CDProductos().ConsultaGridPorNombre(Nombre);
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
                return new CDProductos().ConsultaGridPorId(IdProducto);
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
                return new CDProductos().ConsultaGridPorFormula(IdFormula);
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
                return new CDProductos().ConsultaGridVariedades(IdFormula, NombreProducto);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }

    }
}

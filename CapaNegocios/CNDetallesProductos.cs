using CapaDatos;
using Entidades;
using System;
using System.Data;
namespace CapaNegocios
{
    public class CNDetallesProductos
    {
        public int Guardar(DetallesProductosModel Objeto)
        {
            int res;
            try
            {
                res = new CDDetallesProductos().Guardar(Objeto);
            }
            catch (Exception)
            {
                res = 0;
            }

            return res;
        }
        public int Actualizar(DetallesProductosModel Parametro)
        {
            try
            {
                return new CDDetallesProductos().Actualizar(Parametro);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public int Borrar(DetallesProductosModel Parametro)
        {
            try
            {
                return new CDDetallesProductos().Borrar(Parametro);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaDetallesPorProducto(int IdProducto)
        {
            try
            {
                return new CDDetallesProductos().ConsultaGridPorProducto(IdProducto);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaDetallesPorInsumo(int IdInsumo)
        {
            try
            {
                return new CDDetallesProductos().ConsultaGridPorInsumo(IdInsumo);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}

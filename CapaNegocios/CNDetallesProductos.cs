using CapaDatos;
using Entidades;
using System;
using System.Data;
namespace CapaNegocios
{
    public class CNDetallesProductos
    {
        private readonly CDDetallesProductos cdDetallesProductos;

        public CNDetallesProductos(string conexion)
        {
            cdDetallesProductos = new CDDetallesProductos(conexion);
        }
        public int Guardar(DetallesProductosModel Objeto)
        {
            int res;
            try
            {
                res = cdDetallesProductos.Guardar(Objeto);
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
                return cdDetallesProductos.Actualizar(Parametro);
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
                return cdDetallesProductos.Borrar(Parametro);
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
                return cdDetallesProductos.ConsultaGridPorProducto(IdProducto);
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
                return cdDetallesProductos.ConsultaGridPorInsumo(IdInsumo);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}

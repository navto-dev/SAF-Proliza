using CapaDatos;
using Entidades;
using System;
using System.Data;
namespace CapaNegocios
{
    public class CNTipoDeCambio
    {
        private readonly CDTipoDeCambio cdTipoCambio;

        public CNTipoDeCambio(string conexion)
        {
            cdTipoCambio = new CDTipoDeCambio(conexion);
        }

        public int Guardar(TipoDeCambioModel Objeto)
        {
            int res;
            try
            {
                res = cdTipoCambio.Guardar(Objeto);
            }
            catch (Exception)
            {
                res = 0;
            }

            return res;
        }
        public int Actualizar(TipoDeCambioModel Parametro)
        {
            try
            {
                return cdTipoCambio.Actualizar(Parametro);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaPorMoneda(int IdMoneda)
        {
            try
            {
                return cdTipoCambio.ConsultaGridPorMoneda(IdMoneda);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaReciente()
        {
            try
            {
                return cdTipoCambio.ConsultaGridReciente();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}

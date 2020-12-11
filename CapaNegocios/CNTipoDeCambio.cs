using CapaDatos;
using Entidades;
using System;
using System.Data;
namespace CapaNegocios
{
    public class CNTipoDeCambio
    {
        public int Guardar(TipoDeCambioModel Objeto)
        {
            int res;
            try
            {
                res = new CDTipoDeCambio().Guardar(Objeto);
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
                return new CDTipoDeCambio().Actualizar(Parametro);
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
                return new CDTipoDeCambio().ConsultaGridPorMoneda(IdMoneda);
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
                return new CDTipoDeCambio().ConsultaGridReciente();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}

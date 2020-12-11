using CapaDatos;
using Entidades;
using System;
using System.Data;

namespace CapaNegocios
{
    public class CNMonedas
    {

        public int Guardar(MonedasModel Objeto)
        {
            int res;
            try
            {
                res = new CDMonedas().Guardar(Objeto);
            }
            catch (Exception)
            {
                res = 0;
            }

            return res;
        }
        public int Actualizar(MonedasModel Parametro)
        {
            try
            {
                return new CDMonedas().Actualizar(Parametro);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaGeneral( )
        {
            try
            {
                return new CDMonedas().ConsultaGridGeneral();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}

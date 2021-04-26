using CapaDatos;
using Entidades;
using System;
using System.Data;

namespace CapaNegocios
{
    public class CNMonedas
    {
        private readonly CDMonedas cdMonedas;

        public CNMonedas(string conexion)
        {
            cdMonedas = new CDMonedas(conexion);
        }
        public int Guardar(MonedasModel Objeto)
        {
            int res;
            try
            {
                res = cdMonedas.Guardar(Objeto);
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
                return cdMonedas.Actualizar(Parametro);
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
                return cdMonedas.ConsultaGridGeneral();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}

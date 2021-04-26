using CapaDatos;
using Entidades;
using System;
using System.Data;

namespace CapaNegocios
{
    public class CNDetallesFormulas
    {
        private readonly CDDetallesFormula cdDetallesFormula;

        public CNDetallesFormulas(string conexion)
        {
            cdDetallesFormula = new CDDetallesFormula(conexion);
        }
        public int Guardar(DetallesFormulasModel Objeto)
        {
            int res;
            try
            {
                res = cdDetallesFormula.Guardar(Objeto);
            }
            catch (Exception)
            {
                res = 0;
            }

            return res;
        }
        public int Actualizar(DetallesFormulasModel Parametro)
        {
            try
            {
                return cdDetallesFormula.Actualizar(Parametro);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }

        public int Borrar(int IdDetalleFormula)
        {
            try
            {
                return cdDetallesFormula.Borrar(IdDetalleFormula);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public int ActualizarPrecios(DetallesFormulasModel Parametro)
        {
            try
            {
                return cdDetallesFormula.CambiarPrecios(Parametro);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaDEtallePorId(int IdDetalle)
        {
            try
            {
                return cdDetallesFormula.ConsultaGridPorId(IdDetalle);
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
                return cdDetallesFormula.ConsultaGridPorFormula(IdFormula);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaPorInsumo(int IdInsumo)
        {
            try
            {
                return cdDetallesFormula.ConsultaGridPorInsumo(IdInsumo);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaPorMoneda()
        {
            try
            {
                return cdDetallesFormula.ConsultaGridPorMoneda();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}

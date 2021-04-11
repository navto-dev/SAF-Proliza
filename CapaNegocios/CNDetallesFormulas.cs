using CapaDatos;
using Entidades;
using System;
using System.Data;

namespace CapaNegocios
{
    public class CNDetallesFormulas
    {
        public int Guardar(DetallesFormulasModel Objeto)
        {
            int res;
            try
            {
                res = new CDDetallesFormula().Guardar(Objeto);
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
                return new CDDetallesFormula().Actualizar(Parametro);
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
                return new CDDetallesFormula().Borrar(IdDetalleFormula);
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
                return new CDDetallesFormula().CambiarPrecios(Parametro);
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
                return new CDDetallesFormula().ConsultaGridPorId(IdDetalle);
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
                return new CDDetallesFormula().ConsultaGridPorFormula(IdFormula);
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
                return new CDDetallesFormula().ConsultaGridPorInsumo(IdInsumo);
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
                return new CDDetallesFormula().ConsultaGridPorMoneda();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}

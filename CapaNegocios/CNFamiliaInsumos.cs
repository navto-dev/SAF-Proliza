using CapaDatos;
using Entidades;
using System;
using System.Data;

namespace CapaNegocios
{
    public class CNFamiliaInsumos
    {
        public int Guardar(FamiliaInsumosModel Objeto)
        {
            int res;
            try
            {
                res = new CDFamiliaInsumos().Guardar(Objeto);
            }
            catch (Exception)
            {
                res = 0;
            }

            return res;
        }
        public int Actualizar(FamiliaInsumosModel Parametro)
        {
            try
            {
                return new CDFamiliaInsumos().Actualizar(Parametro);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public int Borrar(int IdFamiliaInsumo)
        {
            try
            {
                return new CDFamiliaInsumos().Borrar(IdFamiliaInsumo);
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
                return new CDFamiliaInsumos().ConsultaGridGeneral();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaIndividual(int IdFamilia)
        {
            try
            {
                return new CDFamiliaInsumos().ConsultaGridIndividual(IdFamilia);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}

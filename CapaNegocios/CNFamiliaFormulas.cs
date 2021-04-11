using CapaDatos;
using Entidades;
using System;
using System.Data;

namespace CapaNegocios
{
    public class CNFamiliaFormulas
    {
        public int Guardar(FamiliaFormulasModel Objeto)
        {
            int res;
            try
            {
                res = new CDFamiliaFormulas().Guardar(Objeto);
            }
            catch (Exception)
            {
                res = 0;
            }

            return res;
        }
        public int Actualizar(FamiliaFormulasModel Parametro)
        {
            try
            {
                return new CDFamiliaFormulas().Actualizar(Parametro);
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
                return new CDFamiliaFormulas().Borrar(IdFamiliaInsumo);
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
                return new CDFamiliaFormulas().ConsultaGridGeneral();
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
                return new CDFamiliaFormulas().ConsultaGridIndividual(IdFamilia);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}

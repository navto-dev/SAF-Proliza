using CapaDatos;
using Entidades;
using System;
using System.Data;

namespace CapaNegocios
{
    public class CNFamiliaFormulas
    {
        private readonly CDFamiliaFormulas cdFamiliaFormulas;

        public CNFamiliaFormulas(string conexion)
        {
            cdFamiliaFormulas = new CDFamiliaFormulas(conexion);
        }
        public int Guardar(FamiliaFormulasModel Objeto)
        {
            int res;
            try
            {
                res = cdFamiliaFormulas.Guardar(Objeto);
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
                return cdFamiliaFormulas.Actualizar(Parametro);
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
                return cdFamiliaFormulas.Borrar(IdFamiliaInsumo);
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
                return cdFamiliaFormulas.ConsultaGridGeneral();
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
                return cdFamiliaFormulas.ConsultaGridIndividual(IdFamilia);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}

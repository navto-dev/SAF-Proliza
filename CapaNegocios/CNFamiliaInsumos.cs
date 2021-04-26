using CapaDatos;
using Entidades;
using System;
using System.Data;

namespace CapaNegocios
{
    public class CNFamiliaInsumos
    {
        private readonly CDFamiliaInsumos cdFamiliaInsumos;

        public CNFamiliaInsumos(string conexion)
        {
            cdFamiliaInsumos = new CDFamiliaInsumos(conexion);
        }
        public int Guardar(FamiliaInsumosModel Objeto)
        {
            int res;
            try
            {
                res = cdFamiliaInsumos.Guardar(Objeto);
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
                return cdFamiliaInsumos.Actualizar(Parametro);
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
                return cdFamiliaInsumos.Borrar(IdFamiliaInsumo);
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
                return cdFamiliaInsumos.ConsultaGridGeneral();
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
                return cdFamiliaInsumos.ConsultaGridIndividual(IdFamilia);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}

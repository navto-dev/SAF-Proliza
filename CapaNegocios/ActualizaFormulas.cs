using Entidades;
using System;
using System.Data;

namespace CapaNegocios
{
    public class ActualizaFormulas
    {
        private readonly CNFormulas cnFormulas;
        private readonly CNProductos cnProductos;
        public ActualizaFormulas(string conexion)
        {
            cnFormulas = new CNFormulas(conexion);
            cnProductos = new CNProductos(conexion);
        }
        void MoverProductos(int IdFormula, DataTable TablaProductosOld)
        {

            for (int i = 0; i < TablaProductosOld.Rows.Count; i++)
            {

                cnProductos.Guardar(new ProductosModel
                {
                    Activo = (bool)(TablaProductosOld.Rows[i]["Activo"]),
                    Cantidad = Convert.ToDecimal(TablaProductosOld.Rows[i]["Cantidad"].ToString()),
                    CostoTotalProducto = Convert.ToDecimal(TablaProductosOld.Rows[i]["CostoTotalProducto"].ToString()),
                    CostoUnitario = Convert.ToDecimal(TablaProductosOld.Rows[i]["CostoUnitario"].ToString()),
                    IdFormula = IdFormula,
                    NombreProducto = (TablaProductosOld.Rows[i]["NombreProducto"].ToString()),
                    UnidadMedida = (TablaProductosOld.Rows[i]["UnidadMedida"].ToString()),
                });
            }
        }
        public int ActualizarFormula(int IdFormula, FormulasModel F)
        {
            DataTable TablaProductosOld = cnProductos.ConsultaPorFormula(IdFormula);
            cnFormulas.Borrar(IdFormula);
            int id = 0;// Convert.ToInt32(BLF.Guardar(F));
            MoverProductos(id, TablaProductosOld);
            cnProductos.BorrarPorFormula(IdFormula);
            return id;
        }

    }
}

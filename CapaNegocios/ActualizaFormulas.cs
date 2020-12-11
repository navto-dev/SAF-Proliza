using Entidades;
using System;
using System.Data;

namespace CapaNegocios
{
    public class ActualizaFormulas
    {
        void MoverProductos(int IdFormula, DataTable TablaProductosOld)
        {

            for (int i = 0; i < TablaProductosOld.Rows.Count; i++)
            {
                CNProductos BLP = new CNProductos();

                BLP.Guardar(new ProductosModel
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
            CNFormulas BLF = new CNFormulas();
            CNProductos BLP = new CNProductos();
            DataTable TablaProductosOld = BLP.ConsultaPorFormula(IdFormula);
            BLF.Borrar(IdFormula);
            int id = 0;// Convert.ToInt32(BLF.Guardar(F));
            MoverProductos(id, TablaProductosOld);
            BLP.BorrarPorFormula(IdFormula);
            return id;
        }

    }
}

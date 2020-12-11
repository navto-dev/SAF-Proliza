using System;
using System.Data;

namespace BLL
{
    public class ActualizaFormulas
    {
        void MoverProductos(int IdFormula, DataTable TablaProductosOld)
        {
            
            for (int i = 0; i < TablaProductosOld.Rows.Count; i++)
            {
                BLLProductos BLP = new BLLProductos(Gral.gStrConexion, Gral.gStrUsuario);
                BLP.Activo = (bool)(TablaProductosOld.Rows[i]["Activo"]);
                BLP.Cantidad = Convert.ToDecimal(TablaProductosOld.Rows[i]["Cantidad"].ToString());
                BLP.CostoTotalProducto = Convert.ToDecimal(TablaProductosOld.Rows[i]["CostoTotalProducto"].ToString());
                BLP.CostoUnitario = Convert.ToDecimal(TablaProductosOld.Rows[i]["CostoUnitario"].ToString());
                BLP.IdFormula = IdFormula;
                BLP.NombreProducto = (TablaProductosOld.Rows[i]["NombreProducto"].ToString());
                BLP.UnidadMedida = (TablaProductosOld.Rows[i]["UnidadMedida"].ToString());
                BLP.Guardar(BLP);
            }
        }
        public int ActualizarFormula(int IdFormula, BLLFormulas F)
        {
            BLLFormulas BLF = new BLLFormulas(Gral.gStrConexion,Gral.gStrUsuario);
            BLLProductos BLP = new BLLProductos(Gral.gStrConexion, Gral.gStrUsuario);
            DataTable TablaProductosOld = BLP.ConsultarProductosPorFormula(IdFormula).Tables["ProductosTerminados"];
            BLF.DarDeBaja(IdFormula);
            int id = Convert.ToInt32(BLF.Guardar(F));
            MoverProductos(id, TablaProductosOld);
            BLP.DarDeBajaPorFormula(IdFormula);
            return id;
        }

    }
}

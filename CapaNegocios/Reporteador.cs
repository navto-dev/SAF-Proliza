using CapaNegocios;
using System;
using System.Data;


namespace CapaNegocios
{
    public class Reporteador
    {
        CNFormulas _Formula = new CNFormulas();
        CNDetallesFormulas _Detalles = new CNDetallesFormulas();
        CNProductos _Productos = new CNProductos();
        CNDetallesProductos _DetProductos = new CNDetallesProductos();
        public DataSet PrintAFormula(int[] Idformula)
        {
            DataSet dtsret = new DataSet();
            #region "ConsultandoFormulas"
            DataTable Formula = new DataTable();
            if (Idformula.Length == 1)
                Formula = _Formula.ConsultaPorId(Idformula[0]).Copy();
            else
            {
                Formula = _Formula.ConsultaPorId(Idformula[0]).Copy();
                for (int i = 1; i < Idformula.Length; i++)
                    Formula.ImportRow(_Formula.ConsultaPorId(Idformula[i]).Rows[0]);
            }
            Formula.TableName = "Formula";
            dtsret.Tables.Add(Formula);
            #endregion
            #region "DetallesFormulas"
            DataTable DetallesFormula = new DataTable();
            if (Idformula.Length == 1)
                DetallesFormula = _Detalles.ConsultaPorFormula(Idformula[0]).Copy();
            else
            {
                DetallesFormula = _Detalles.ConsultaPorFormula(Idformula[0]).Copy();
                for (int i = 1; i < Idformula.Length; i++)
                {
                    DataTable Detalles = new DataTable();
                    Detalles = _Detalles.ConsultaPorFormula(Idformula[i]).Copy();
                    foreach (DataRow item in Detalles.Rows)
                        DetallesFormula.ImportRow(item);
                }
            }
            DetallesFormula.TableName = "DetallesFormula";
            dtsret.Tables.Add(DetallesFormula);
            #endregion
            #region"ConsultandoProductos"
            DataTable ProductosTerminados = new DataTable();
            if (Idformula.Length == 1)
                ProductosTerminados = _Productos.ConsultaPorFormula(Idformula[0]).Copy();
            else
            {
                ProductosTerminados = _Productos.ConsultaPorFormula(Idformula[0]).Copy();
                for (int i = 1; i < Idformula.Length; i++)
                {
                    DataTable Productos = _Productos.ConsultaPorFormula(Idformula[i]).Copy();
                    foreach (DataRow item in Productos.Rows)
                        ProductosTerminados.ImportRow(item);
                }
            }
            ProductosTerminados.TableName = "ProductosTerminados";
            dtsret.Tables.Add(ProductosTerminados);
            #endregion
            #region "DetallesProductos"
            DataTable DetallesProducto = new DataTable();
            try
            {
                DetallesProducto = _DetProductos.ConsultaDetallesPorProducto(Convert.ToInt32(ProductosTerminados.Rows[0]["IdProducto"])).Copy();
                if (ProductosTerminados.Rows.Count > 1)
                {
                    foreach (DataRow item in ProductosTerminados.Rows)
                    {
                        DataTable DetProd = new DataTable();
                        DetProd = _DetProductos.ConsultaDetallesPorProducto(Convert.ToInt32(item["IdProducto"])).Copy();
                        foreach (DataRow item1 in DetProd.Rows)
                        {
                            DetallesProducto.ImportRow(item1);
                        }
                    }
                }


            }
            catch
            {
            }

            DetallesProducto.TableName = "DetallesProducto";
            dtsret.Tables.Add(DetallesProducto);
            #endregion
            return dtsret;
        }
    }
}

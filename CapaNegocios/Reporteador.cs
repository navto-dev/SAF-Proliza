using System;
using System.Data;


namespace CapaNegocios
{
    public class Reporteador
    {
        private readonly CNFormulas cnFormulas;
        private readonly CNDetallesFormulas cnDetFormula;
        private readonly CNDetallesProductos cnDetProducto;
        private readonly CNProductos cnProductos;
        public Reporteador(string conexion)
        {
            cnFormulas = new CNFormulas(conexion);
            cnDetFormula = new CNDetallesFormulas(conexion);
            cnDetProducto = new CNDetallesProductos(conexion);
            cnProductos = new CNProductos(conexion);
        }
        public DataSet PrintAFormula(int[] Idformula)
        {
            DataSet dtsret = new DataSet();
            #region "ConsultandoFormulas"
            DataTable Formula = new DataTable();
            if (Idformula.Length == 1)
                Formula = cnFormulas.ConsultaPorId(Idformula[0]).Copy();
            else
            {
                Formula = cnFormulas.ConsultaPorId(Idformula[0]).Copy();
                for (int i = 1; i < Idformula.Length; i++)
                    Formula.ImportRow(cnFormulas.ConsultaPorId(Idformula[i]).Rows[0]);
            }
            Formula.TableName = "Formula";
            dtsret.Tables.Add(Formula);
            #endregion
            #region "DetallesFormulas"
            DataTable DetallesFormula = new DataTable();
            if (Idformula.Length == 1)
                DetallesFormula = cnDetFormula.ConsultaPorFormula(Idformula[0]).Copy();
            else
            {
                DetallesFormula = cnDetFormula.ConsultaPorFormula(Idformula[0]).Copy();
                for (int i = 1; i < Idformula.Length; i++)
                {
                    DataTable Detalles = new DataTable();
                    Detalles = cnDetFormula.ConsultaPorFormula(Idformula[i]).Copy();
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
                ProductosTerminados = cnProductos.ConsultaPorFormula(Idformula[0]).Copy();
            else
            {
                ProductosTerminados = cnProductos.ConsultaPorFormula(Idformula[0]).Copy();
                for (int i = 1; i < Idformula.Length; i++)
                {
                    DataTable Productos = cnProductos.ConsultaPorFormula(Idformula[i]).Copy();
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
                DetallesProducto = cnDetProducto.ConsultaDetallesPorProducto(Convert.ToInt32(ProductosTerminados.Rows[0]["IdProducto"])).Copy();
                if (ProductosTerminados.Rows.Count > 1)
                {
                    foreach (DataRow item in ProductosTerminados.Rows)
                    {
                        DataTable DetProd = new DataTable();
                        DetProd = cnDetProducto.ConsultaDetallesPorProducto(Convert.ToInt32(item["IdProducto"])).Copy();
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

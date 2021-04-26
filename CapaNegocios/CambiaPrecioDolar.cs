using Entidades;
using System;
using System.Data;

namespace CapaNegocios
{
    public class CambiaPrecioDolar
    {
        private readonly CNInsumos cnInsumos;
        private readonly CNFormulas cnFormulas;
        private readonly CNDetallesFormulas cnDetFormula;
        private readonly CNDetallesProductos cnDetProducto;
        private readonly CNProductos cnProductos;
        public CambiaPrecioDolar(string conexion)
        {
            cnInsumos = new CNInsumos(conexion, -1, null, false, 0);
            cnFormulas = new CNFormulas(conexion);
            cnDetFormula = new CNDetallesFormulas(conexion);
            cnDetProducto = new CNDetallesProductos(conexion);
            cnProductos = new CNProductos(conexion);
        }
        double dolar;
        double CalculaPrecioInsumo(int IdInsumo)
        {
            //DataRow ConsultaInsumo = Insumo.ConsultarInsumoPorId(IdInsumo).Tables["Insumos"].Rows[0];
            DataRow ConsultaInsumo = cnInsumos.ConsultaPorId(IdInsumo).Rows[0];
            double Precio = Convert.ToDouble(ConsultaInsumo["PrecioUnitario"]);
            if (Convert.ToInt32(ConsultaInsumo["IdMoneda"]) == 2)
                Precio = dolar * Precio;
            return Precio;
        }
        decimal calculaPrecio(string UnidadMedida, double CostoUnitario, double CantidadInsumo, string Unidad, double dolar)
        {
            double Costo = 0.0;
            char c = Unidad[0];
            switch (UnidadMedida.ToUpper())
            {
                case "KG":
                    switch (c.ToString().ToUpper())
                    {
                        case "K":
                            Costo = (CostoUnitario * CantidadInsumo) * dolar;
                            break;
                        case "G":
                            Costo = ((CostoUnitario / 1000) * CantidadInsumo) * dolar;
                            break;
                        case "M":
                            Costo = ((CostoUnitario / 10000) * CantidadInsumo) * dolar;
                            break;
                    }
                    break;
                case "L":
                    switch (c.ToString().ToUpper())
                    {
                        case "L":
                            Costo = (CostoUnitario * CantidadInsumo) * dolar;
                            break;
                        case "M":
                            Costo = ((CostoUnitario / 1000) * CantidadInsumo) * dolar;
                            break;
                    }
                    break;

            }
            return Convert.ToDecimal(Costo);
        }
        void MoverProductos(int IdFormula, DataTable TablaProductosOld)
        {

            for (int i = 0; i < TablaProductosOld.Rows.Count; i++)
            {
                DataTable Detalles = cnDetProducto.ConsultaDetallesPorProducto(Convert.ToInt32(TablaProductosOld.Rows[i]["IdProducto"]));

                ProductosModel Producto = new ProductosModel
                {
                    Activo = (bool)(TablaProductosOld.Rows[i]["Activo"]),
                    Cantidad = Convert.ToDecimal(TablaProductosOld.Rows[i]["Cantidad"].ToString()),
                    CostoTotalProducto = Convert.ToDecimal(TablaProductosOld.Rows[i]["CostoTotalProducto"].ToString()),
                    CostoUnitario = Convert.ToDecimal(TablaProductosOld.Rows[i]["CostoUnitario"].ToString()),
                    IdFormula = IdFormula,
                    NombreProducto = (TablaProductosOld.Rows[i]["NombreProducto"].ToString()),
                    UnidadMedida = (TablaProductosOld.Rows[i]["UnidadMedida"].ToString()),
                };
                int id = Convert.ToInt32(cnProductos.Guardar(Producto));
                decimal CostoTotal = 0;
                foreach (DataRow row in Detalles.Rows)
                {

                    DetallesProductosModel detalle = new DetallesProductosModel
                    {
                        IdDetalle = 0,
                        IdProducto = id,
                        IdInsumo = Convert.ToInt32(row["IdInsumo"]),
                        CostoInsumo = Convert.ToDecimal(CalculaPrecioInsumo(Convert.ToInt32(row["IdInsumo"]))),
                    };
                    CostoTotal += detalle.CostoInsumo;
                    cnDetProducto.Guardar(detalle);
                }
                Producto.CostoTotalProducto = CostoTotal + Producto.CostoUnitario;
                Producto.IdProducto = id;
                cnProductos.Actualizar(Producto);
            }
        }
        FormulasModel CreaObjetoFormula(DataTable Formula)
        {
            FormulasModel _Formula = new FormulasModel();
            _Formula.IdFormula = 0;
            _Formula.NombreFormula = Formula.Rows[0]["NombreFormula"].ToString();
            _Formula.Cantidad = Convert.ToDouble(Formula.Rows[0]["Cantidad"].ToString());
            _Formula.Capacidad = Formula.Rows[0]["Capacidad"].ToString();
            _Formula.UnidadMedida = Formula.Rows[0]["UnidadMedida"].ToString();
            _Formula.IdFamilia = Convert.ToInt32(Formula.Rows[0]["IdFamilia"].ToString());
            return _Formula;
        }
        DetallesFormulasModel CreaObjetoDetalleFormula(int i, int idFormula, DataTable Detalle, double dolar, int IdUsuario)
        {
            DetallesFormulasModel _DetallesFormula = new DetallesFormulasModel();
            _DetallesFormula.IdDetalle = 0;
            _DetallesFormula.IdFormula = idFormula;
            _DetallesFormula.IdInsumo = Convert.ToInt32(Detalle.Rows[i]["IdInsumo"]);
            _DetallesFormula.CantidadInsumo = Convert.ToDecimal(Detalle.Rows[i]["CantidadInsumo"]);
            _DetallesFormula.UnidadMedidaInsumo = (Detalle.Rows[i]["UnidadMedidaInsumo"].ToString());
            _DetallesFormula.IdUsuario = IdUsuario;
            if (Convert.ToInt32(Detalle.Rows[i]["IdMoneda"]) == 2)
            {
                _DetallesFormula.CostoInsumo = calculaPrecio(Convert.ToString(Detalle.Rows[i]["UnidadMedida"]),
                Convert.ToDouble(Detalle.Rows[i]["PrecioUnitario"]), Convert.ToDouble(Detalle.Rows[i]["CantidadInsumo"]),
                Convert.ToString(Detalle.Rows[i]["UnidadMedidaInsumo"]), dolar);
            }
            else
            {
                _DetallesFormula.CostoInsumo = Convert.ToDecimal(Detalle.Rows[i]["CostoInsumo"]);
            }



            return _DetallesFormula;
        }
        public void ActualizarFormulasConDivisaExtranjera(int IdUsuario, double dolar)
        {
            this.dolar = dolar;
            DataTable TablaFormulas = cnDetFormula.ConsultaPorMoneda();
            int[] IdFormulas = new int[TablaFormulas.Rows.Count];
            for (int i = 0; i < TablaFormulas.Rows.Count; i++)
            {
                bool exists = false;
                for (int j = 0; j < IdFormulas.Length; j++)
                {
                    if (Convert.ToInt32(TablaFormulas.Rows[i]["IdFormula"].ToString()) == IdFormulas[j])
                    {
                        exists = true;
                    }
                }
                if (!exists)
                {
                    IdFormulas[i] = Convert.ToInt32(TablaFormulas.Rows[i]["IdFormula"]);
                }
            }
            for (int i = 0; i < IdFormulas.Length; i++)
            {
                if (IdFormulas[i] != 0)
                {
                    DataTable Detalles = cnDetFormula.ConsultaPorFormula(IdFormulas[i]);
                    DataTable Formula = cnFormulas.ConsultaPorId(IdFormulas[i]);
                    DataTable TablaProductosOld = cnProductos.ConsultaPorFormula(IdFormulas[i]);
                    int IdFormula = Convert.ToInt32(cnFormulas.Guardar(IdUsuario, CreaObjetoFormula(Formula), Detalles));
                    MoverProductos(IdFormula, TablaProductosOld);
                    cnProductos.BorrarPorFormula(IdFormulas[i]);
                    cnFormulas.Borrar(IdFormulas[i]);
                    for (int k = 0; k < Detalles.Rows.Count; k++)
                        cnDetFormula.Guardar(CreaObjetoDetalleFormula(k, IdFormula, Detalles, dolar, IdUsuario));

                }
            }

        }

    }
}

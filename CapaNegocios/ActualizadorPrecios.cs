using Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios
{
    public class ActualizadorPrecios
    {
        CNDetallesFormulas Detalle = new CNDetallesFormulas();
        DataTable DetailNew = new DataTable();
        int Id = 0;
        List<int> IdsFormula = new List<int>();
        string ConsultaUnidadMedida()
        {
            string UnidadMedida = "";
            //DataTable tableInsumos = Insumo.ConsultarInsumoPorId(Id).Tables["Insumos"];
            DataTable tableInsumos = new CNInsumos().ConsultaPorId(Id);
            UnidadMedida = Convert.ToString(tableInsumos.Rows[0]["UnidadMedida"]);
            return UnidadMedida;
        }
        DataTable NewTable()
        {
            DataTable DetailNew = new DataTable();
            DetailNew.Columns.Add("IdDetalle");//0
            DetailNew.Columns.Add("IdFormula");//1
            DetailNew.Columns.Add("NombreFormula");//2
            DetailNew.Columns.Add("IdInsumo");//3
            DetailNew.Columns.Add("NombreInsumo");//4
            DetailNew.Columns.Add("NombreInterno");//5
            DetailNew.Columns.Add("CantidadInsumo");//6
            DetailNew.Columns.Add("UnidadMedidaInsumo");//7
            DetailNew.Columns.Add("CostoInsumo");//8
            DetailNew.Columns.Add("Activo");//9
            return DetailNew;
        }
        public double calculaPrecio(string UnidadMedida, double CostoUnitario, double CantidadInsumo, string Unidad)
        {
            double Costo = 0.0;
            char c = Unidad[0];
            switch (UnidadMedida.ToUpper())
            {
                case "KG":
                    switch (c.ToString().ToUpper())
                    {
                        case "K":
                            Costo = CostoUnitario * CantidadInsumo;
                            break;
                        case "G":
                            Costo = (CostoUnitario / 1000) * CantidadInsumo;
                            break;
                        case "M":
                            Costo = (CostoUnitario / 10000) * CantidadInsumo;
                            break;
                    }
                    break;
                case "L":
                    switch (c.ToString().ToUpper())
                    {
                        case "L":
                            Costo = CostoUnitario * CantidadInsumo;
                            break;
                        case "M":
                            Costo = (CostoUnitario / 1000) * CantidadInsumo;
                            break;
                    }
                    break;

            }
            return Costo;
        }
        //vvv El Metodo de abajo es para calcular precio unitario de Una Formula vvv
        double CalculaPrecioUnitarioFormula(string Capacidad/*<<la capacidad de la formula*/, double CostoTotal /*Costo de producir la formula*/, double Cantidad /*Cantidad QUe se produce de formula*/)
        {
            double CostoUnitario = 0.00;
            switch (Capacidad.ToUpper())
            {
                case "LITROS":
                    CostoUnitario = CostoTotal / Cantidad;
                    break;
                case "MILILITROS":
                    CostoUnitario = (1000 * CostoTotal) / Cantidad;
                    break;
                case "KILOGRAMOS":
                    CostoUnitario = CostoTotal;
                    break;
                case "GRAMOS":
                    CostoUnitario = (1000 * CostoTotal) / Cantidad;
                    break;
                case "MILIGRAMOS":
                    CostoUnitario = (10000 * CostoTotal) / Cantidad;
                    break;
            }
            return CostoUnitario;
        }
        //public void Actualizador(double Precio, int IdInsumo)
        //{

        //    Id = IdInsumo;
        //    DataTable Detail = Detalle.ConsultaPorInsumo(IdInsumo);
        //    DetailNew = NewTable();

        //    foreach (DataRow row in Detail.Rows)
        //    {
        //        DataRow Row = DetailNew.Rows.Add();
        //        Row["IdDetalle"] = row["IdDetalle"];
        //        Row["IdFormula"] = row["IdFormula"];
        //        IdsFormula.Add(Convert.ToInt32(Row["IdFormula"]));
        //        Row["NombreFormula"] = row["NombreFormula"];
        //        Row["IdInsumo"] = row["IdInsumo"];
        //        Row["NombreInsumo"] = row["NombreInsumo"];
        //        Row["NombreInterno"] = row["NombreInterno"];
        //        Row["CantidadInsumo"] = row["CantidadInsumo"];
        //        Row["UnidadMedidaInsumo"] = row["UnidadMedidaInsumo"];
        //        Row["CostoInsumo"] = calculaPrecio(ConsultaUnidadMedida(), Precio, Convert.ToDouble(Row["CantidadInsumo"]), Convert.ToString(Row["UnidadMedidaInsumo"]));
        //        Row["Activo"] = row["Activo"];
        //        Detalle.ActualizarPrecios(new DetallesFormulasModel
        //        {
        //            IdDetalle = Convert.ToInt32(Row["IdDetalle"]),
        //            CostoInsumo = Convert.ToDecimal(Row["CostoInsumo"]),
        //            IdFormula = Convert.ToInt32(Row["IdFormula"])
        //        });
        //        if (ExisteInsumo(Convert.ToString(Row["NombreFormula"])))
        //        {
        //            //DataTable ConsultaInsumo = Insumo.ConsultarInsumoPorNombre(Convert.ToString(Row["NombreFormula"])).Tables["Insumos"];
        //            DataTable ConsultaInsumo = new CNInsumos().ConsultaPorNombre(Convert.ToString(Row["NombreFormula"]));
        //            ActualizaPrecioInsumo(ConsultaInsumo, CalculaPrecioInsumo(Convert.ToInt32(Row["IdFormula"])));

        //            Actualizador(CalculaPrecioInsumo(Convert.ToInt32(Row["IdFormula"])), Convert.ToInt32(ConsultaInsumo.Rows[0]["IdInsumo"]));
        //            for (int j = 0; j < IdsFormula.Count; j++)
        //                if (IdsFormula[j] != 0)
        //                    ActuaizarPrecioProductos(IdsFormula[j], CalculaPrecioInsumo(Convert.ToInt32(Row["IdFormula"])));

        //        }
        //    }


        //}

        public double calculaPrecioProducto(string UnidadMedida, double CostoUnitario, double Cantidad, double CantidadInsumo, string Unidad)
        {
            double Costo = 0.0;
            char c = Unidad[0];
            switch (UnidadMedida.ToUpper())
            {
                case "K":
                    switch (c.ToString().ToUpper())
                    {
                        case "K":
                            Costo = ((CostoUnitario / Cantidad) * CantidadInsumo);
                            break;
                        case "G":
                            Costo = ((CostoUnitario / Cantidad) / 1000) * CantidadInsumo;
                            break;
                        case "M":
                            Costo = ((CostoUnitario / Cantidad) / 10000) * CantidadInsumo;
                            break;
                    }
                    break;
                case "L":
                    switch (c.ToString().ToUpper())
                    {
                        case "L":
                            Costo = ((CostoUnitario / Cantidad) * CantidadInsumo);
                            break;
                        case "M":
                            Costo = ((CostoUnitario / Cantidad) / 1000 * CantidadInsumo);
                            break;
                    }
                    break;

            }
            return Costo;
        }
        bool ExisteInsumo(string NombreFormula)
        {
            //DataTable Existe = Insumo.ConsultarInsumoPorNombre(NombreFormula).Tables["Insumos"];
            //if (Existe.Rows.Count != 0)
            //{
            //    return true;
            //}
            //return false;
            return new CNInsumos().ConsultaPorNombre(NombreFormula).Rows.Count != 0 ? true : false;
        }
        double CalculaPrecioInsumo(int IdFormula)
        {
            CNFormulas Formula = new CNFormulas();
            DataTable TablaFormula = Formula.ConsultaPorId(IdFormula);
            double CostoFormula = Convert.ToDouble(TablaFormula.Rows[0]["CostoTotal"]);
            string unidadMedida = Convert.ToString(TablaFormula.Rows[0]["Capacidad"]);
            double Cantidad = Convert.ToDouble(TablaFormula.Rows[0]["Cantidad"]);
            return CalculaPrecioUnitarioFormula(unidadMedida, CostoFormula, Cantidad);


        }

        //Este Método busca los productos relacionados a la formula que contiene al insumo y les actualiza el precio despues de actualizar el precio de la formula
        void ActuaizarPrecioProductos(int IdFormula, double PrecioUnitarioFormula)
        {
            CNProductos Productos = new CNProductos();
            CNFormulas Formulas = new CNFormulas();
            DataTable _Productos = Productos.ConsultaPorFormula(IdFormula);
            foreach (DataRow row in _Productos.Rows)
            {
                double CostoDetallesProducto = Convert.ToDouble(row["CostoTotalProducto"]) - Convert.ToDouble(row["CostoUnitario"]);
                row["CostoUnitario"] = PrecioGranel(PrecioUnitarioFormula, Convert.ToString(row["UnidadMedida"]), Convert.ToDouble(row["Cantidad"]));
                row["CostoTotalProducto"] = Convert.ToDouble(row["CostoUnitario"]) + CostoDetallesProducto;

                Productos.Actualizar(new ProductosModel
                {
                    IdProducto = Convert.ToInt32(row["IdProducto"]),
                    IdFormula = Convert.ToInt32(row["IdFormula"]),
                    NombreProducto = Convert.ToString(row["NombreProducto"]),
                    Cantidad = Convert.ToDecimal(row["Cantidad"]),
                    UnidadMedida = Convert.ToString(row["UnidadMedida"]),
                    CostoUnitario = Convert.ToDecimal(row["CostoUnitario"]),
                    CostoTotalProducto = Convert.ToDecimal(row["CostoTotalProducto"]),
                    Activo = (bool)(row["Activo"]),
                });
            }

        }
        double PrecioGranel(/*Datos de la Formula >>>*/double PrecioUnitarioFormula, /*Datos del Producto*/ string UnidadMedida, double Cantidad)
        {
            double PrecioGranel = 0.00;
            switch (UnidadMedida.ToUpper())
            {
                case "LITROS":
                    PrecioGranel = PrecioUnitarioFormula * Cantidad;
                    break;
                case "MILILITROS":
                    PrecioGranel = (PrecioUnitarioFormula / 1000) * Cantidad;
                    break;
                case "KILOGRAMOS":
                    PrecioGranel = PrecioUnitarioFormula * Cantidad;
                    break;
                case "GRAMOS":
                    PrecioGranel = (PrecioUnitarioFormula / 1000) * Cantidad;
                    break;
                case "MILIGRAMOS":
                    PrecioGranel = (PrecioUnitarioFormula / 10000) * Cantidad;
                    break;
            }
            return PrecioGranel;
        }
        //void ActualizaPrecioInsumo(DataTable Insumo, double PrecioInsumo)
        //{
        //    //this.Insumo.IdInsumo = Convert.ToInt32(Insumo.Rows[0]["IdInsumo"]);
        //    //this.Insumo.NombreInsumo = Convert.ToString(Insumo.Rows[0]["NombreInsumo"]);
        //    //this.Insumo.NombreInterno = Convert.ToString(Insumo.Rows[0]["NombreInterno"]);
        //    //this.Insumo.IdProveedor = Convert.ToInt32(Insumo.Rows[0]["IdProveedor"]);
        //    //this.Insumo.UnidadMedida = Convert.ToString(Insumo.Rows[0]["UnidadMedida"]);
        //    //this.Insumo.IdInsumo = Convert.ToInt32(Insumo.Rows[0]["IdInsumo"]);
        //    //this.Insumo.PrecioUnitario = Convert.ToDouble(PrecioInsumo);
        //    //this.Insumo.IdInsumo = Convert.ToInt32(Insumo.Rows[0]["IdInsumo"]);
        //    //this.Insumo.IdFamilia= Convert.ToInt32(Insumo.Rows[0]["IdFamilia"]);
        //    //this.Insumo.IdMoneda= Convert.ToInt32(Insumo.Rows[0]["IdMoneda"]);
        //    //this.Insumo.Actualizar(this.Insumo);

        //    new CNInsumos().Actualizar(new InsumosModel
        //    {
        //        IdInsumo = Convert.ToInt32(Insumo.Rows[0]["IdInsumo"]),
        //        NombreInsumo = Convert.ToString(Insumo.Rows[0]["NombreInsumo"]),
        //        NombreInterno = Convert.ToString(Insumo.Rows[0]["NombreInterno"]),
        //        IdProveedor = Convert.ToInt32(Insumo.Rows[0]["IdProveedor"]),
        //        UnidadMedida = Convert.ToString(Insumo.Rows[0]["UnidadMedida"]),
        //        PrecioUnitario = Convert.ToDouble(PrecioInsumo),
        //        IdFamilia = Convert.ToInt32(Insumo.Rows[0]["IdFamilia"]),
        //        IdMoneda = Convert.ToInt32(Insumo.Rows[0]["IdMoneda"]),
        //    });
        //}
    }
}

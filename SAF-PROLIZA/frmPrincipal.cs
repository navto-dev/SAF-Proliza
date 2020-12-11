using System;
using System.Data;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using System.Windows.Forms;
using DevExpress.Utils;
using CapaNegocios;
using System.Deployment.Application;
using System.Drawing;

namespace SAF_PROLIZA
{
    public partial class frmPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Objetos Objetos = new Objetos();
        public string EstadoGrid = "Productos", nombreProducto = "", ContenidoGrid = "";
        public DataTable T = new DataTable();
        double dolar = 0.00;
        public void llenarGrid(string EstadoGrid)
        {
            gridView1.FindFilterText = "";
            switch (EstadoGrid)
            {
                case "F"://Mostrar Todas las Formulas
                    #region "Formulas"
                    ContenidoGrid = "Fórmulas";
                    gridView2.Columns.Clear();
                    gridView1.Columns.Clear();
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                    gridView1.OptionsBehavior.AutoPopulateColumns = false;
                    gridView1.OptionsBehavior.Editable = false;
                    try
                    {
                        T = new CNFormulas().ConsultaGeneral();
                        gridControl1.DataSource = CalculaCostoUnitario(T);
                        GridColumn myCol1 = new GridColumn() { Caption = "No.Formula", Visible = false, FieldName = "IdFormula" };
                        gridView1.Columns.Add(myCol1);
                        gridView1.Columns["IdFormula"].BestFit();
                        GridColumn myCol2 = new GridColumn() { Caption = "Formula", Visible = true, FieldName = "NombreFormula" };
                        gridView1.Columns.Add(myCol2);
                        gridView1.Columns["NombreFormula"].BestFit();
                        GridColumn myCol5 = new GridColumn() { Caption = "Familia", Visible = true, FieldName = "NombreFamilia" };
                        gridView1.Columns.Add(myCol5);
                        gridView1.Columns["NombreFamilia"].BestFit();
                        GridColumn myCol3 = new GridColumn() { Caption = "Cantidad", Visible = true, FieldName = "Cantidad" };
                        gridView1.Columns.Add(myCol3);
                        gridView1.Columns["Cantidad"].BestFit();
                        GridColumn myCol6 = new GridColumn() { Caption = "Capacidad", Visible = true, FieldName = "Capacidad" };
                        gridView1.Columns.Add(myCol6);
                        gridView1.Columns["Capacidad"].BestFit();
                        if (Estaticos.IdRol != 4)
                        {
                            GridColumn myCol4 = new GridColumn() { Caption = "Costo", Visible = true, FieldName = "CostoTotal" };
                            gridView1.Columns.Add(myCol4);
                            gridView1.Columns["CostoTotal"].BestFit();
                            GridColumn myCol7 = new GridColumn() { Caption = "Costo Unitario", Visible = true, FieldName = "PrecioUnitario" };
                            gridView1.Columns.Add(myCol7);
                            gridView1.Columns["PrecioUnitario"].BestFit();
                        }
                    }
                    catch (Exception err)
                    {
                        //throw new Exception(err.Message, err);
                    }
                    finally
                    {
                        gridControl1.EndUpdate();
                    }
                    break;
                #endregion
                case "I":// Mostrar Todos Los Insumos
                    #region"Insumos"
                    ContenidoGrid = "Insumos";
                    gridView2.Columns.Clear();
                    gridView1.Columns.Clear();
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                    gridView1.OptionsBehavior.AutoPopulateColumns = false;
                    gridView1.OptionsBehavior.Editable = false;
                    try
                    {
                        //T = Objetos.Insumos.ConsultarInsumo().Tables["Insumos"];
                        T = new CNInsumos().ConsultaGeneral();
                        gridControl1.DataSource = T;
                        GridColumn myCol1 = new GridColumn() { Caption = "No.Insumo", Visible = false, FieldName = "IdInsumo" };
                        gridView1.Columns.Add(myCol1);
                        gridView1.Columns["IdInsumo"].BestFit();
                        GridColumn myCol4 = new GridColumn() { Caption = "Nombre Interno", Visible = true, FieldName = "NombreInterno" };
                        gridView1.Columns.Add(myCol4);
                        gridView1.Columns["NombreInterno"].BestFit();
                        GridColumn myCol3 = new GridColumn() { Caption = "Nombre Real", Visible = true, FieldName = "NombreInsumo" };
                        gridView1.Columns.Add(myCol3);
                        gridView1.Columns["NombreInsumo"].BestFit();
                        GridColumn myCol2 = new GridColumn() { Caption = "Proveedor", Visible = true, FieldName = "NombreProveedor" };
                        gridView1.Columns.Add(myCol2);
                        gridView1.Columns["NombreProveedor"].BestFit();
                        GridColumn myCol6 = new GridColumn() { Caption = "Familia", Visible = true, FieldName = "NombreFamilia" };
                        gridView1.Columns.Add(myCol6);
                        gridView1.Columns["NombreFamilia"].BestFit();
                        GridColumn myCol5 = new GridColumn() { Caption = "Precio Unitario", Visible = true, FieldName = "PrecioUnitario" };
                        gridView1.Columns.Add(myCol5);
                        gridView1.Columns["PrecioUnitario"].BestFit();
                        GridColumn myCol7 = new GridColumn() { Caption = "Divisa", Visible = true, FieldName = "NombreMoneda" };
                        gridView1.Columns.Add(myCol7);
                        gridView1.Columns["NombreMoneda"].BestFit();
                    }
                    catch (Exception err)
                    {
                        //throw new Exception(err.Message, err);
                    }
                    finally
                    {
                        gridControl1.EndUpdate();
                    }
                    break;
                #endregion
                case "BF"://Mostrar Resultado de una busqueda de Formulas
                    #region"BusquedaFormula"  
                    ContenidoGrid = "Fórmulas";
                    gridView2.Columns.Clear();
                    gridView1.Columns.Clear();
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                    gridView1.OptionsBehavior.AutoPopulateColumns = false;
                    gridView1.OptionsBehavior.Editable = false;
                    try
                    {
                        //T = Objetos.Formulas.ConsultarFormulaPorNombre(Objetos.Nombre, Objetos.Activo).Tables["Formulas"];
                        T = new CNFormulas().ConsultaPorNombre(Objetos.Nombre, Objetos.Activo);
                        gridControl1.DataSource = T;
                        GridColumn myCol1 = new GridColumn() { Caption = "No.Formula", Visible = false, FieldName = "IdFormula" };
                        gridView1.Columns.Add(myCol1);
                        gridView1.Columns["IdFormula"].BestFit();
                        GridColumn myCol2 = new GridColumn() { Caption = "Formula", Visible = true, FieldName = "NombreFormula" };
                        gridView1.Columns.Add(myCol2);
                        gridView1.Columns["NombreFormula"].BestFit();
                        GridColumn myCol3 = new GridColumn() { Caption = "Cantidad", Visible = true, FieldName = "Cantidad" };
                        gridView1.Columns.Add(myCol3);
                        gridView1.Columns["Cantidad"].BestFit();
                        GridColumn myCol4 = new GridColumn() { Caption = "Costo", Visible = true, FieldName = "CostoTotal" };
                        gridView1.Columns.Add(myCol4);
                        gridView1.Columns["CostoTotal"].BestFit();
                        GridColumn myCol5 = new GridColumn() { Caption = "Familia", Visible = true, FieldName = "NombreFamilia" };
                        gridView1.Columns.Add(myCol5);
                        gridView1.Columns["NombreFamilia"].BestFit();
                        if (!Objetos.Activo)
                        {
                            GridColumn myCol6 = new GridColumn() { Caption = "Fecha de Cambio", Visible = true, FieldName = "FechaElaboracion" };
                            gridView1.Columns.Add(myCol6);
                            gridView1.Columns["FechaElaboracion"].BestFit();
                            if (myCol6 != null)
                            {
                                gridView1.Columns["FechaElaboracion"].DisplayFormat.FormatType = FormatType.DateTime;
                                gridView1.Columns["FechaElaboracion"].DisplayFormat.FormatString = "G";
                                gridView1.Columns["FechaElaboracion"].BestFit();
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        //throw new Exception(err.Message, err);
                    }
                    finally
                    {
                        gridControl1.EndUpdate();
                    }
                    break;
                #endregion
                case "BI"://Mostrar Resultado de una Busqueda de Insumos
                    #region"BusquedaInsumos"
                    ContenidoGrid = "Insumos";
                    gridView2.Columns.Clear();
                    gridView1.Columns.Clear();
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                    gridView1.OptionsBehavior.AutoPopulateColumns = false;
                    gridView1.OptionsBehavior.Editable = false;
                    try
                    {
                        //T = Objetos.Insumos.ConsultarInsumoPorNombre(Objetos.Nombre).Tables["Insumos"];
                        T = new CNInsumos().ConsultaPorNombre(Objetos.Nombre);
                        gridControl1.DataSource = T;
                        GridColumn myCol1 = new GridColumn() { Caption = "No.Insumo", Visible = false, FieldName = "IdInsumo" };
                        gridView1.Columns.Add(myCol1);
                        gridView1.Columns["IdInsumo"].BestFit();
                        GridColumn myCol4 = new GridColumn() { Caption = "Nombre Interno", Visible = true, FieldName = "NombreInterno" };
                        gridView1.Columns.Add(myCol4);
                        gridView1.Columns["NombreInterno"].BestFit();
                        if (Estaticos.IdRol == 1 || Estaticos.IdRol == 2)
                        {
                            GridColumn myCol3 = new GridColumn() { Caption = "Nombre del Insumo", Visible = true, FieldName = "NombreInsumo" };
                            gridView1.Columns.Add(myCol3);
                            gridView1.Columns["NombreInsumo"].BestFit();
                            GridColumn myCol2 = new GridColumn() { Caption = "Proveedor", Visible = true, FieldName = "NombreProveedor" };
                            gridView1.Columns.Add(myCol2);
                            gridView1.Columns["NombreProveedor"].BestFit();
                        }
                        GridColumn myCol6 = new GridColumn() { Caption = "Familia", Visible = true, FieldName = "NombreFamilia" };
                        gridView1.Columns.Add(myCol6);
                        gridView1.Columns["NombreFamilia"].BestFit();
                        GridColumn myCol5 = new GridColumn() { Caption = "Precio Unitario", Visible = true, FieldName = "PrecioUnitario" };
                        gridView1.Columns.Add(myCol5);
                        gridView1.Columns["PrecioUnitario"].BestFit();
                        GridColumn myCol7 = new GridColumn() { Caption = "Divisa", Visible = true, FieldName = "NombreMoneda" };
                        gridView1.Columns.Add(myCol7);
                        gridView1.Columns["NombreMoneda"].BestFit();
                    }
                    catch (Exception err)
                    {
                        //throw new Exception(err.Message, err);
                    }
                    finally
                    {
                        gridControl1.EndUpdate();
                    }
                    break;
                #endregion
                case "Productos"://Mostrar Resultado de una Busqueda de Productos
                    #region"BusquedaProductos"
                    ContenidoGrid = "Productos";
                    gridView2.Columns.Clear();
                    gridView1.Columns.Clear();
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                    gridView1.OptionsBehavior.AutoPopulateColumns = false;
                    gridView1.OptionsBehavior.Editable = false;
                    try
                    {
                        //T = Objetos.Productos.ConsultarProductos().Tables["ProductosTerminados"];
                        T = new CNProductos().ConsultaActivos();
                        gridControl1.DataSource = T;
                        GridColumn myCol = new GridColumn() { Caption = "IdProducto", Visible = false, FieldName = "IdProducto" };
                        gridView1.Columns.Add(myCol);
                        GridColumn myCol2 = new GridColumn() { Caption = "Nombre del Producto", Visible = true, FieldName = "NombreProducto" };
                        gridView1.Columns.Add(myCol2);
                        gridView1.Columns["NombreProducto"].BestFit();
                        GridColumn myCol3 = new GridColumn() { Caption = "Formula", Visible = true, FieldName = "NombreFormula" };
                        gridView1.Columns.Add(myCol3);
                        gridView1.Columns["NombreFormula"].BestFit();
                        GridColumn myCol4 = new GridColumn() { Caption = "Cantidad", Visible = true, FieldName = "Cantidad" };
                        gridView1.Columns.Add(myCol4);
                        gridView1.Columns["Cantidad"].BestFit();
                        GridColumn myCol5 = new GridColumn() { Caption = "Unidad de Medida", Visible = true, FieldName = "UnidadMedida" };
                        gridView1.Columns.Add(myCol5);
                        gridView1.Columns["UnidadMedida"].BestFit();
                        GridColumn myCol6 = new GridColumn() { Caption = "Costo a Granel", Visible = true, FieldName = "CostoUnitario" };
                        gridView1.Columns.Add(myCol6);
                        gridView1.Columns["CostoUnitario"].BestFit();
                        GridColumn myCol7 = new GridColumn() { Caption = "Costo Envasado", Visible = true, FieldName = "CostoTotalProducto" };
                        gridView1.Columns.Add(myCol7);
                        gridView1.Columns["CostoTotalProducto"].BestFit();
                        GridColumn myCol8 = new GridColumn() { Caption = "Familia", Visible = true, FieldName = "NombreFamilia" };
                        gridView1.Columns.Add(myCol8);
                        gridView1.Columns["NombreFamilia"].BestFit();

                    }
                    catch (Exception err)
                    {
                        //throw new Exception(err.Message, err);
                    }
                    finally
                    {
                        gridControl1.EndUpdate();
                    }
                    break;
                #endregion
                case "BP"://Mostrar Resultado de una Busqueda de Productos
                    #region"BusquedaProductos"
                    ContenidoGrid = "Productos";
                    gridView2.Columns.Clear();
                    gridView1.Columns.Clear();
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                    gridView1.OptionsBehavior.AutoPopulateColumns = false;
                    gridView1.OptionsBehavior.Editable = false;
                    try
                    {
                        T = new CNProductos().ConsultaPorNombre(Objetos.Nombre);
                        gridControl1.DataSource = T;
                        GridColumn myCol3 = new GridColumn() { Caption = "Nombre del Producto", Visible = true, FieldName = "NombreProducto" };
                        gridView1.Columns.Add(myCol3);
                        gridView1.Columns["NombreProducto"].BestFit();
                        GridColumn myCol4 = new GridColumn() { Caption = "Formula", Visible = true, FieldName = "NombreFormula" };
                        gridView1.Columns.Add(myCol4);
                        gridView1.Columns["NombreFormula"].BestFit();
                        GridColumn myCol2 = new GridColumn() { Caption = "Familia", Visible = true, FieldName = "NombreFamilia" };
                        gridView1.Columns.Add(myCol2);
                        gridView1.Columns["NombreFamilia"].BestFit();

                    }
                    catch (Exception err)
                    {
                        //throw new Exception(err.Message, err);
                    }
                    finally
                    {
                        gridControl1.EndUpdate();
                    }
                    break;
                #endregion
                case "U": //Mostrar todos los usuarios
                    #region "Usuaros"                
                    ContenidoGrid = "Usuarios";
                    gridView2.Columns.Clear();
                    gridView1.Columns.Clear();
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                    gridView1.OptionsBehavior.AutoPopulateColumns = false;
                    gridView1.OptionsBehavior.Editable = false;
                    try
                    {
                        //T = Objetos.Usuario.ConsultaGeneralUsuarios().Tables["Usuario"];
                        T = new CNUsuarios().ConsultaGeneral();
                        gridControl1.DataSource = T;
                        GridColumn myCol1 = new GridColumn() { Caption = "No. Usuario", Visible = false, FieldName = "IdUsuario" };
                        gridView1.Columns.Add(myCol1);
                        gridView1.Columns["IdUsuario"].BestFit();
                        GridColumn myCol2 = new GridColumn() { Caption = "Nombre Real", Visible = true, FieldName = "Nombre" };
                        gridView1.Columns.Add(myCol2);
                        gridView1.Columns["Nombre"].BestFit();
                        GridColumn myCol3 = new GridColumn() { Caption = "Username", Visible = true, FieldName = "Username" };
                        gridView1.Columns.Add(myCol3);
                        gridView1.Columns["Username"].BestFit();
                        GridColumn myCol6 = new GridColumn() { Caption = "Rol", Visible = true, FieldName = "Rol" };
                        gridView1.Columns.Add(myCol6);
                        gridView1.Columns["Rol"].BestFit();
                        GridColumn myCol4 = new GridColumn() { Caption = "Correo Electrónico", Visible = true, FieldName = "email" };
                        gridView1.Columns.Add(myCol4);
                        gridView1.Columns["email"].BestFit();
                    }
                    catch (Exception err)
                    {
                        //throw new Exception(err.Message, err);
                    }
                    finally
                    {
                        gridControl1.EndUpdate();
                    }
                    break;
                #endregion                
                case "Proveedores":
                    #region "Proveedores" 
                    ContenidoGrid = "Proveedores";
                    btnProveedor.Visibility = BarItemVisibility.Always;
                    btnDeleteFamilia.Visibility = BarItemVisibility.Never;
                    gridView2.Columns.Clear();
                    gridView1.Columns.Clear();
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                    gridView1.OptionsBehavior.AutoPopulateColumns = false;
                    gridView1.OptionsBehavior.Editable = false;
                    try
                    {
                        //T = Objetos.Proveedores.ConsultarProveedores().Tables["Proveedores"];
                        T = new CNProveedores().ConsultaGeneral();
                        gridControl1.DataSource = T;
                        GridColumn myCol1 = new GridColumn() { Caption = "No. Proveedor", Visible = false, FieldName = "IdProveedor" };
                        gridView1.Columns.Add(myCol1);
                        gridView1.Columns["IdProveedor"].BestFit();
                        GridColumn myCol2 = new GridColumn() { Caption = "Nombre Proveedor", Visible = true, FieldName = "NombreProveedor" };
                        gridView1.Columns.Add(myCol2);
                        gridView1.Columns["NombreProveedor"].BestFit();
                    }
                    catch (Exception err)
                    {
                        //throw new Exception(err.Message, err);
                    }
                    finally
                    {
                        gridControl1.EndUpdate();
                    }
                    break;
                #endregion
                case "FI":
                    #region "Familia de Insumos" 
                    ContenidoGrid = "Familias de Insumos";
                    btnProveedor.Visibility = BarItemVisibility.Never;
                    btnDeleteFamilia.Visibility = BarItemVisibility.Always;
                    gridView2.Columns.Clear();
                    gridView1.Columns.Clear();
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                    gridView1.OptionsBehavior.AutoPopulateColumns = false;
                    gridView1.OptionsBehavior.Editable = false;
                    try
                    {
                        //T = Objetos.Proveedores.ConsultarProveedores().Tables["Proveedores"];
                        T = new CNFamiliaInsumos().ConsultaGeneral();
                        gridControl1.DataSource = T;
                        GridColumn myCol1 = new GridColumn() { Caption = "No. Familia", Visible = false, FieldName = "IdFamilia" };
                        gridView1.Columns.Add(myCol1);
                        gridView1.Columns["IdFamilia"].BestFit();
                        GridColumn myCol2 = new GridColumn() { Caption = "Nombre Familia", Visible = true, FieldName = "NombreFamilia" };
                        gridView1.Columns.Add(myCol2);
                        gridView1.Columns["NombreFamilia"].BestFit();
                    }
                    catch (Exception err)
                    {
                        //throw new Exception(err.Message, err);
                    }
                    finally
                    {
                        gridControl1.EndUpdate();
                    }
                    break;
                #endregion
                case "FF":
                    #region "Familia de Formulas" 
                    ContenidoGrid = "Familias de Fórmulas";
                    gridView2.Columns.Clear();
                    gridView1.Columns.Clear();
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                    gridView1.OptionsBehavior.AutoPopulateColumns = false;
                    gridView1.OptionsBehavior.Editable = false;
                    try
                    {
                        //T = Objetos.Proveedores.ConsultarProveedores().Tables["Proveedores"];
                        T = new CNFamiliaFormulas().ConsultaGeneral();
                        gridControl1.DataSource = T;
                        GridColumn myCol1 = new GridColumn() { Caption = "No. Familia", Visible = false, FieldName = "IdFamilia" };
                        gridView1.Columns.Add(myCol1);
                        gridView1.Columns["IdFamilia"].BestFit();
                        GridColumn myCol2 = new GridColumn() { Caption = "Nombre Familia", Visible = true, FieldName = "NombreFamilia" };
                        gridView1.Columns.Add(myCol2);
                        gridView1.Columns["NombreFamilia"].BestFit();
                    }
                    catch (Exception err)
                    {
                        //throw new Exception(err.Message, err);
                    }
                    finally
                    {
                        gridControl1.EndUpdate();
                    }
                    break;
                    #endregion

            }

        }
        void ConsultaPrecioDolar()
        {
            //DataTable Dolar = Objetos.TipoDeCambio.ConsultarReciente().Tables["TipoDeCambio"];
            DataTable Dolar = new CNTipoDeCambio().ConsultaReciente();
            navBarItem4.Caption = "$ " + Dolar.Rows[0]["FactorConversion"].ToString() + " Pesos";
            dolar = Convert.ToDouble(Dolar.Rows[0]["FactorConversion"].ToString());
            Estaticos.dolar = dolar;
        }
        void MostrarDetalles(string EstadoGrid, int IdFormula)
        {
            switch (EstadoGrid)
            {
                case "F":
                    #region "Formulas"
                    try
                    {
                        DataTable T = new CNDetallesFormulas().ConsultaPorFormula(IdFormula);
                        gridView2.Columns.Clear();
                        gridView2.OptionsView.ColumnAutoWidth = false;
                        gridView2.BestFitColumns();
                        gridView2.OptionsBehavior.AutoPopulateColumns = false;
                        gridView2.OptionsBehavior.Editable = false;
                        gridControl2.DataSource = T;
                        GridColumn myCol1 = new GridColumn() { Caption = "No.Detalle", Visible = false, FieldName = "IdDetalle" };
                        gridView2.Columns.Add(myCol1);
                        gridView2.Columns["IdDetalle"].BestFit();
                        GridColumn myCol2 = new GridColumn() { Caption = "Formula", Visible = true, FieldName = "NombreFormula" };
                        gridView2.Columns.Add(myCol2); //PrecioUnitario
                        gridView2.Columns["NombreFormula"].BestFit();
                        GridColumn myCol4 = new GridColumn() { Caption = "Nombre Insumo", Visible = true, FieldName = "NombreInterno" };
                        gridView2.Columns.Add(myCol4);
                        gridView2.Columns["NombreInterno"].BestFit();
                        if (Estaticos.IdRol == 1 || Estaticos.IdRol == 2)
                        {
                            GridColumn myCol3 = new GridColumn() { Caption = "Nombre Real Insumo", Visible = true, FieldName = "NombreInsumo" };
                            gridView2.Columns.Add(myCol3);
                            gridView2.Columns["NombreInsumo"].BestFit();
                            GridColumn Col = new GridColumn() { Caption = "Costo Unitario", Visible = true, FieldName = "PrecioUnitario" };
                            gridView2.Columns.Add(Col);
                            gridView2.Columns["PrecioUnitario"].BestFit();
                            GridColumn Col1 = new GridColumn() { Caption = "Moneda", Visible = true, FieldName = "NombreMoneda" };
                            gridView2.Columns.Add(Col1);
                            gridView2.Columns["NombreMoneda"].BestFit();
                            GridColumn myCol7 = new GridColumn() { Caption = "Costo MX", Visible = true, FieldName = "CostoInsumo" };
                            gridView2.Columns.Add(myCol7);
                            gridView2.Columns["CostoInsumo"].BestFit();

                        }
                        GridColumn myCol5 = new GridColumn() { Caption = "Cantidad de Insumo", Visible = true, FieldName = "CantidadInsumo" };
                        gridView2.Columns.Add(myCol5);
                        gridView2.Columns["CantidadInsumo"].BestFit();
                        GridColumn myCol6 = new GridColumn() { Caption = "Unidad de Medida", Visible = true, FieldName = "UnidadMedidaInsumo" };
                        gridView2.Columns.Add(myCol6);
                        gridView2.Columns["UnidadMedidaInsumo"].BestFit();

                    }
                    catch (Exception err)
                    {
                        throw new Exception(err.Message, err);
                    }
                    finally
                    {
                        gridControl2.EndUpdate();
                    }
                    break;
                #endregion
                case "Productos":
                    #region "Productos"
                    try
                    {
                        DataTable T = new CNDetallesProductos().ConsultaDetallesPorProducto(IdFormula);
                        gridView2.Columns.Clear();
                        gridView2.OptionsView.ColumnAutoWidth = false;
                        gridView2.BestFitColumns();
                        gridView2.OptionsBehavior.AutoPopulateColumns = false;
                        gridView2.OptionsBehavior.Editable = false;
                        gridControl2.DataSource = T;
                        GridColumn myCol = new GridColumn() { Caption = "", Visible = false, FieldName = "IdInsumo" };
                        gridView2.Columns.Add(myCol);
                        GridColumn myCol1 = new GridColumn() { Caption = "Nombre Insumo", Visible = true, FieldName = "NombreInterno" };
                        gridView2.Columns.Add(myCol1);
                        gridView2.Columns["NombreInterno"].BestFit();
                        if (Estaticos.IdRol == 1 || Estaticos.IdRol == 2)
                        {
                            GridColumn Col = new GridColumn() { Caption = "Nombre Real Insumo", Visible = true, FieldName = "NombreInsumo" };
                            gridView2.Columns.Add(Col);
                            gridView2.Columns["NombreInsumo"].BestFit();
                        }
                        GridColumn myCol2 = new GridColumn() { Caption = "Costo de Insumo", Visible = true, FieldName = "Precio" };
                        gridView2.Columns.Add(myCol2);
                        gridView2.Columns["Precio"].BestFit();
                        GridColumn myCol3 = new GridColumn() { Caption = "Moneda", Visible = true, FieldName = "NombreMoneda" };
                        gridView2.Columns.Add(myCol3);
                        gridView2.Columns["NombreMoneda"].BestFit();
                    }
                    catch (Exception err)
                    {
                        throw new Exception(err.Message, err);
                    }
                    finally
                    {
                        gridControl2.EndUpdate();
                    }
                    break;
                    #endregion
            }
        }
        public frmPrincipal()
        {
            InitializeComponent();
            lblVersion.Caption = Version();

        }

        DataTable CalculaCostoUnitario(DataTable Formulas)
        {
            Formulas.Columns.Add("PrecioUnitario");
            foreach (DataRow Row in Formulas.Rows)
            {
                #region "CalculaPrecioUnitario"  
                double Costo = 0.0;
                switch (Row["Capacidad"].ToString().ToUpper())
                {
                    case "KILOGRÁMOS":
                        switch (Row["Capacidad"].ToString().ToUpper())
                        {
                            case "KILOGRÁMOS":
                                Costo = Convert.ToDouble(Row["CostoTotal"].ToString()) / Convert.ToDouble(Row["Cantidad"].ToString());
                                break;
                            case "GRÁMOS":
                                Costo = (Convert.ToDouble(Row["CostoTotal"].ToString()) * 1000) / Convert.ToDouble(Row["Cantidad"].ToString());
                                break;
                            case "MILIGRÁMOS":
                                Costo = (Convert.ToDouble(Row["CostoTotal"].ToString()) * 1000) / Convert.ToDouble(Row["Cantidad"].ToString());
                                break;
                        }
                        break;
                    case "LITROS":
                        switch (Row["Capacidad"].ToString().ToUpper())
                        {
                            case "LITROS":
                                Costo = Convert.ToDouble(Row["CostoTotal"].ToString()) / Convert.ToDouble(Row["Cantidad"].ToString());
                                break;
                            case "MILILITROS":
                                Costo = (Convert.ToDouble(Row["CostoTotal"].ToString()) * 1000) / Convert.ToDouble(Row["Cantidad"].ToString());
                                break;
                        }
                        break;
                }
                #endregion
                Row["PrecioUnitario"] = "$ " + Costo + " Pesos";
            }
            return Formulas;
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //Objetos.MoverRespaldo.SimpleFileMove();
            frmLogin frm = new frmLogin();
            DialogResult dr = new DialogResult();
            dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                llenarGrid(EstadoGrid);
                ConsultaPrecioDolar();
                switch (Estaticos.IdRol)
                {
                    case 3:
                        ribbonPage1.Visible = false;
                        ribbonPage4.Visible = false;
                        rbnPageUsuario.Visible = false;
                        ribbonPageGroup7.Visible = false;
                        rbnPageProveedores.Visible = false;
                        navBarControl1.Visible = false;
                        btnNuevoInsumo.Links[0].Visible = true;
                        llenarGrid("I");
                        break;
                    case 4:
                        ribbonPage1.Visible = false;
                        ribbonPage2.Visible = false;
                        //ribbonPage3.Visible = false;
                        ribbonPage4.Visible = false;
                        rbnPageUsuario.Visible = false;
                        navBarControl1.Visible = false;
                        EstadoGrid = "F";
                        llenarGrid("F");
                        break;
                }
            }
            else
            {
                this.Close();
            }
        }

        string Version()
        {
            try
            {
                return Convert.ToString(ApplicationDeployment.CurrentDeployment.CurrentVersion);
            }
            catch
            {
                return "";
            }
        }

        private void btnGuardarFormula_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmFormulasV2 frm = new frmFormulasV2(0);
            frm.ShowDialog();
            //if (frm.CloseBox)
            //{
            //    EstadoGrid = "F";
            //    llenarGrid(EstadoGrid);
            //}
        }
        private void btnNuevoInsumo_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmInsumos frm = new frmInsumos();
            frm.ShowDialog();
        }

        private void btnBuscarFormulas_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBuscador frm = new frmBuscador("Formulas");
            DialogResult dl = new DialogResult();
            dl = frm.ShowDialog();
            if (dl == DialogResult.OK)
            {
                EstadoGrid = "BF";
                llenarGrid(EstadoGrid);
            }
        }
        private void btnMostrarFormulas_ItemClick(object sender, ItemClickEventArgs e)
        {
            EstadoGrid = "F";
            llenarGrid(EstadoGrid);
        }

        private void btnMostrarInsumos_ItemClick(object sender, ItemClickEventArgs e)
        {
            EstadoGrid = "I";
            llenarGrid(EstadoGrid);
        }
        private void btnBuscarInsumos_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBuscador frm = new frmBuscador("Insumos");
            DialogResult dl = new DialogResult();
            dl = frm.ShowDialog();
            if (dl == DialogResult.OK)
            {
                EstadoGrid = "BI";
                llenarGrid(EstadoGrid);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            switch (EstadoGrid)
            {
                case "F":
                    try
                    {
                        int IdFormula = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFormula").ToString());
                        MostrarDetalles(EstadoGrid, IdFormula);
                    }
                    catch
                    {
                    }
                    break;
                case "Productos":
                    try
                    {
                        int IdFormula = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdProducto").ToString());
                        nombreProducto = (gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "NombreProducto").ToString());
                        MostrarDetalles(EstadoGrid, IdFormula);
                    }
                    catch
                    {
                    }
                    break;
            }
        }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            switch (EstadoGrid)
            {
                case "F":
                    try
                    {
                        if (Estaticos.IdRol < 3)
                        {
                            //frmDetallesFormulas frm = new frmDetallesFormulas(IdFormula);
                            frmFormulasV2 frm = new frmFormulasV2(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFormula")));
                            frm.ShowDialog();
                            //if (frm.CloseBox)
                            //{
                            //    EstadoGrid = "F";
                            //    llenarGrid(EstadoGrid);
                            //}
                        }
                    }
                    catch
                    {
                    }
                    break;
                case "BF":
                    try
                    {
                        if (Estaticos.IdRol < 3)
                        {
                            //int IdFormula = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFormula").ToString());
                            //frmDetallesFormulas frm = new frmDetallesFormulas(IdFormula);
                            frmFormulasV2 frm = new frmFormulasV2(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFormula")));
                            frm.ShowDialog();
                            //if (frm.CloseBox)
                            //{
                            //    EstadoGrid = "F";
                            //    llenarGrid(EstadoGrid);
                            //}
                        }
                    }
                    catch
                    {
                    }
                    break;
                case "Productos":
                    try
                    {
                        int IdProducto = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdProducto").ToString());
                        frmProductosTerminados frm = new frmProductosTerminados(false);
                        frm.llenarDatos(IdProducto);
                        //if (frm.CloseBox)
                        //{
                        //    EstadoGrid = "Productos";
                        //    llenarGrid(EstadoGrid);
                        //}
                    }
                    catch
                    {
                    }
                    break;
                case "BP":
                    try
                    {
                        int IdProducto = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdProducto").ToString());
                        frmProductosTerminados frm = new frmProductosTerminados(false);
                        frm.llenarDatos(IdProducto);
                        //if (frm.CloseBox)
                        //{
                        //    EstadoGrid = "Productos";
                        //    llenarGrid(EstadoGrid);
                        //}
                    }
                    catch
                    {
                    }
                    break;
                case "I":
                    try
                    {
                        int IdInsumo = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdInsumo").ToString());
                        frmInsumos frm = new frmInsumos();
                        frm.LlenarDatos(IdInsumo);
                        //if (frm.CloseBox)
                        //{
                        //    llenarGrid("I");
                        //}
                    }
                    catch
                    {
                    }
                    break;
                case "BI":
                    try
                    {
                        int IdInsumo = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdInsumo").ToString());
                        frmInsumos frm = new frmInsumos();
                        frm.LlenarDatos(IdInsumo);
                        //if (frm.CloseBox)
                        //{
                        //    llenarGrid("I");
                        //}
                    }
                    catch
                    {
                    }
                    break;
                case "U":
                    try
                    {
                        frmUsuario frm = new frmUsuario("Consulta");
                        int IdUsuario = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdUsuario").ToString());
                        frm.MostrarDatos(IdUsuario);
                        //if (frm.CloseBox)
                        //{
                        //    llenarGrid(EstadoGrid);
                        //}
                    }
                    catch
                    {
                    }
                    break;
                case "Proveedores":
                    try
                    {
                        frmFamilias frm = new frmFamilias(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdProveedor")));
                        frm.prepararFormulario("Proveedores");
                        frm.ShowDialog();
                        EstadoGrid = "Proveedores";
                        llenarGrid(EstadoGrid);
                    }
                    catch { }
                    break;
                case "FI":
                    try
                    {
                        if (int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFamilia").ToString()) < 2)
                        {
                            MessageBox.Show("No puedes modificar esta familia porque es una variable del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        frmFamilias frm = new frmFamilias(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFamilia")));
                        frm.prepararFormulario("Insumos");
                        frm.ShowDialog();
                        EstadoGrid = "FI";
                        llenarGrid(EstadoGrid);
                    }
                    catch { }
                    break;
                case "FF":
                    try
                    {
                        if (int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFamilia").ToString()) < 2)
                        {
                            MessageBox.Show("No puedes dar de baja esta familia porque es una variable del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        frmFamilias frm = new frmFamilias(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFamilia")));
                        frm.prepararFormulario("Formulas");
                        frm.ShowDialog();
                        EstadoGrid = "FF";
                        llenarGrid(EstadoGrid);
                    }
                    catch { }
                    break;
            }
        }
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (EstadoGrid)
            {
                case "Proveedores":
                    try
                    {
                        if (e.KeyData == Keys.Delete)
                        {
                            DialogResult ds = MessageBox.Show("¿Deseas dar de baja a " + gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "NombreProveedor").ToString() + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (ds == DialogResult.Yes)
                            {
                                //if (Objetos.Insumos.ConsultarInsumoPorProveedor(int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdProveedor").ToString())).Tables["Insumos"].Rows.Count == 0)
                                if (new CNInsumos().ConsultaPorProveedor(int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdProveedor").ToString())).Rows.Count == 0)
                                {
                                    //Objetos.Proveedores.BorrarProveedor(int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdProveedor").ToString()));
                                    new CNProveedores().Borrar(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdProveedor")));
                                    EstadoGrid = "Proveedores";
                                    llenarGrid(EstadoGrid);
                                }
                                else
                                {
                                    MessageBox.Show("No puedes dar de baja este proveedor porque tiene insumos activos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                    break;
                case "FI":
                    try
                    {
                        if (int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFamilia").ToString()) < 2)
                        {
                            MessageBox.Show("No puedes dar de baja esta familia porque es una variable del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }


                        DialogResult ds = MessageBox.Show("¿Deseas dar de baja la familia " + gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "NombreFamilia").ToString() + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ds == DialogResult.Yes)
                        {
                            if (new CNInsumos().ConsultaPorFamilia(int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFamilia").ToString())).Rows.Count == 0)
                            {
                                new CNFamiliaInsumos().Borrar(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFamilia")));
                                EstadoGrid = "FI";
                                llenarGrid(EstadoGrid);
                            }
                            else
                                MessageBox.Show("No puedes dar de baja esta familia porque tiene insumos activos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                    }
                    break;
                case "FF":
                    try
                    {
                        if (int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFamilia").ToString()) < 2)
                        {
                            MessageBox.Show("No puedes dar de baja esta familia porque es una variable del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        DialogResult ds = MessageBox.Show("¿Deseas dar de baja la familia " + gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "NombreFamilia").ToString() + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ds == DialogResult.Yes)
                        {
                            if (new CNFormulas().ConsultaPorFamilia(int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFamilia").ToString())).Rows.Count == 0)
                            {
                                new CNFamiliaFormulas().Borrar(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFamilia")));
                                EstadoGrid = "FF";
                                llenarGrid(EstadoGrid);
                            }
                            else
                                MessageBox.Show("No puedes dar de baja esta familia porque tiene formulas activas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                    }
                    break;
            }
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmFamilias frm = new frmFamilias();
            frm.prepararFormulario("Proveedores");
            frm.ShowDialog();
            EstadoGrid = "Proveedores";
            llenarGrid(EstadoGrid);
        }
        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmFamilias frm = new frmFamilias();
            frm.prepararFormulario("Insumos");
            frm.ShowDialog();
            EstadoGrid = "FI";
            llenarGrid(EstadoGrid);
        }
        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmFamilias frm = new frmFamilias();
            frm.prepararFormulario("Formulas");
            frm.ShowDialog();
            EstadoGrid = "FF";
            llenarGrid(EstadoGrid);
        }
        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmFamilias frm = new frmFamilias();
            frm.prepararFormulario("Dolar");
            frm.ShowDialog();
            if (frm.CloseBox)
            {
                ConsultaPrecioDolar();
                new CambiaPrecioDolar().ActualizarFormulasConDivisaExtranjera(Estaticos.IdUsuario, dolar);
                llenarGrid("F");
            }
        }
        private void btnAddProduct_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProductosTerminados frm = new frmProductosTerminados(true);
            frm.ShowDialog();
            //if (frm.CloseBox)
            //{
            //    EstadoGrid = "Productos";
            //    llenarGrid(EstadoGrid);
            //}
        }
        private void btnSearchProduct_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (new frmBuscador("Productos").ShowDialog() == DialogResult.OK)
            {
                EstadoGrid = "BP";
                llenarGrid(EstadoGrid);
            }
            //try
            //{
            //    new CapaNegocios.resp().respaldo();
            //}
            //catch { }
        }
        private void btnMiPerfil_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUsuario frm = new frmUsuario("Consulta");
            frm.MostrarDatos(Estaticos.IdUsuario);
        }
        private void btnAgregarUsuario_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUsuario frm = new frmUsuario("Alta");
            frm.ShowDialog();
            if (frm.CloseBox)
            {
                EstadoGrid = "U";
                llenarGrid(EstadoGrid);
            }
        }
        private void btnMostrarUsuario_ItemClick(object sender, ItemClickEventArgs e)
        {
            EstadoGrid = "U";
            llenarGrid(EstadoGrid);
        }
        private void btnImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmRptInsumos frm = new frmRptInsumos(Objetos.Insumos.ConsultarInsumo().Tables["Insumos"]);
            frmRptInsumos frm = new frmRptInsumos(new CNInsumos().ConsultaGeneral());
            frm.crystalReportViewer1.PrintReport();
        }
        private void btnImprimirForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                DataTable Ids = new CNFormulas().ConsultaGeneral();
                int[] idformula = new int[Ids.Rows.Count];
                int i = 0;
                foreach (DataRow item in Ids.Rows)
                {
                    idformula[i] = Convert.ToInt32(item["IdFormula"]);
                    i++;
                }

                frmImpDetallesFormulas frm = new frmImpDetallesFormulas(new Reporteador().PrintAFormula(idformula), "M");
                frm.crystalReportViewer1.PrintReport();
            }
            catch
            {
            }
        }
        private void btnImprimirProd_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRptProductos frm = new frmRptProductos(new CNProductos().ConsultaActivos());
            frm.crystalReportViewer1.PrintReport();
        }
        private void btnAltaProveedor_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmFamilias frm = new frmFamilias();
            frm.prepararFormulario("Proveedores");
            frm.ShowDialog();
        }
        private void btnShowProveedores_ItemClick(object sender, ItemClickEventArgs e)
        {
            EstadoGrid = "Proveedores";
            llenarGrid(EstadoGrid);
        }



        private void btnProveedor_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (EstadoGrid)
            {
                case "Proveedores":
                    try
                    {
                        DialogResult ds = MessageBox.Show("¿Deseas dar de baja a " + gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "NombreProveedor").ToString() + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ds == DialogResult.Yes)
                        {
                            //if (Objetos.Insumos.ConsultarInsumoPorProveedor(int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdProveedor").ToString())).Tables["Insumos"].Rows.Count == 0)
                            if (new CNInsumos().ConsultaPorProveedor(int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdProveedor").ToString())).Rows.Count == 0)
                            {
                                //Objetos.Proveedores.BorrarProveedor(int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdProveedor").ToString()));
                                new CNProveedores().Borrar(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdProveedor")));
                                EstadoGrid = "Proveedores";
                                llenarGrid(EstadoGrid);
                            }
                            else
                                MessageBox.Show("No puedes dar de baja este proveedor porque tiene insumos activos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                    }
                    break;
            }
        }

        private void btnFamilias_ItemClick(object sender, ItemClickEventArgs e)
        {
            EstadoGrid = "FI";
            llenarGrid(EstadoGrid);
        }

        private void btnDeleteFamilia_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (EstadoGrid)
            {
                case "FI":
                    try
                    {
                        if (int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFamilia").ToString()) < 2)
                        {
                            MessageBox.Show("No puedes dar de baja esta familia porque es una variable del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        DialogResult ds = MessageBox.Show("¿Deseas dar de baja la familia " + gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "NombreFamilia").ToString() + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ds == DialogResult.Yes)
                        {
                            if (new CNInsumos().ConsultaPorFamilia(int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFamilia").ToString())).Rows.Count == 0)
                            {
                                new CNFamiliaInsumos().Borrar(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFamilia")));
                                EstadoGrid = "FI";
                                llenarGrid(EstadoGrid);
                            }
                            else
                                MessageBox.Show("No puedes dar de baja esta familia porque tiene insumos activos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                    }
                    break;
            }
        }

        private void btnFamiliaFormulas_ItemClick(object sender, ItemClickEventArgs e)
        {
            EstadoGrid = "FF";
            llenarGrid(EstadoGrid);
        }

        private void btnDeleteFamiliaFormuuas_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (EstadoGrid)
            {
                case "FF":
                    try
                    {
                        if (int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFamilia").ToString()) < 2)
                        {
                            MessageBox.Show("No puedes dar de baja esta familia porque es una variable del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        DialogResult ds = MessageBox.Show("¿Deseas dar de baja la familia " + gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "NombreFamilia").ToString() + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ds == DialogResult.Yes)
                        {
                            if (new CNFormulas().ConsultaPorFamilia(int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFamilia").ToString())).Rows.Count == 0)
                            {
                                new CNFamiliaFormulas().Borrar(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "IdFamilia")));
                                EstadoGrid = "FF";
                                llenarGrid(EstadoGrid);
                            }
                            else
                                MessageBox.Show("No puedes dar de baja esta familia porque tiene formulas activas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                    }
                    break;
            }
        }

        private void frmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F5))
                llenarGrid(EstadoGrid);
        }

        private void gridView1_CustomDrawFooter(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Center;
            var rect = e.Bounds;
            rect.X += 10;
            e.DefaultDraw();
            e.Cache.DrawString(string.IsNullOrEmpty(ContenidoGrid) ? "" : "Cant. de " + ContenidoGrid + ": " + gridView1.RowCount,
                e.Appearance.GetFont(), e.Appearance.GetForeBrush(e.Cache), rect, stringFormat);
            e.Handled = true;
        }

        private void btnShowProducts_ItemClick(object sender, ItemClickEventArgs e)
        {
            EstadoGrid = "Productos";
            llenarGrid(EstadoGrid);
        }
    }
}
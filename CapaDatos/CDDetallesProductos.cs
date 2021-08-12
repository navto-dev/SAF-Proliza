using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDDetallesProductos
    {
        private string conexion { get; set; }

        public CDDetallesProductos(string conexion)
        {
            this.conexion = conexion ?? throw new ArgumentNullException(nameof(conexion));
        }

        public int Guardar(DetallesProductosModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spDetalleProductosGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdDetalle", SqlDbType.Int).Value = Objeto.IdDetalle;
                        cmd.Parameters.Add("@IdInsumo", SqlDbType.Int).Value = Objeto.IdInsumo;
                        cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = Objeto.IdProducto;
                        cmd.Parameters.Add("@CostoInsumo", SqlDbType.Decimal).Value = Objeto.CostoInsumo;
                        cmd.Parameters.Add("@DetalleAccion", SqlDbType.VarChar).Value = "G";
                        con.Open();
                        res = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return res;
        }
        public int Actualizar(DetallesProductosModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spDetalleProductosGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdDetalle", SqlDbType.Int).Value = Objeto.IdDetalle;
                        cmd.Parameters.Add("@IdInsumo", SqlDbType.Int).Value = Objeto.IdInsumo;
                        cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = Objeto.IdProducto;
                        cmd.Parameters.Add("@CostoInsumo", SqlDbType.Decimal).Value = Objeto.CostoInsumo;
                        cmd.Parameters.Add("@DetalleAccion", SqlDbType.Char).Value = 'A';
                        con.Open();
                        res = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return res;
        }

        public int Borrar(DetallesProductosModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spDetalleProductosBorrar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdDetalle", SqlDbType.Int).Value = Objeto.IdDetalle;
                        cmd.Parameters.Add("@IdInsumo", SqlDbType.Int).Value = Objeto.IdInsumo;
                        con.Open();
                        res = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return res;
        }
        public DataTable ConsultaGridPorProducto(int IdProducto)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spDetallesProductosConsultaPorProducto", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = IdProducto;


                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            con.Open();
                            adapter.Fill(tabla);
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return tabla;
        }
        public DataTable ConsultaGridPorInsumo(int IdInsumo)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spBuscaProductoPorInsumo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdInsumo", SqlDbType.Int).Value = IdInsumo;


                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            con.Open();
                            adapter.Fill(tabla);
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return tabla;
        }
    }
}

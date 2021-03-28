using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDInsumos
    {

        public int Guardar(InsumosModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsumosGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdInsumo", SqlDbType.Int).Value = Objeto.IdInsumo;
                        cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = Objeto.IdProveedor;
                        cmd.Parameters.Add("@NombreInsumo", SqlDbType.NVarChar).Value = Objeto.NombreInsumo;
                        cmd.Parameters.Add("@NombreInterno", SqlDbType.NVarChar).Value = Objeto.NombreInterno;
                        cmd.Parameters.Add("@UnidadMedida", SqlDbType.NVarChar).Value = Objeto.UnidadMedida;
                        cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = Objeto.PrecioUnitario;
                        cmd.Parameters.Add("@TotalCompraMX", SqlDbType.Decimal).Value = Objeto.TotalCompraMX;
                        cmd.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = Objeto.IdFamilia;
                        cmd.Parameters.Add("@IdMoneda", SqlDbType.Int).Value = Objeto.IdMoneda;
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
        public int Actualizar(InsumosModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsumosGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdInsumo", SqlDbType.Int).Value = Objeto.IdInsumo;
                        cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = Objeto.IdProveedor;
                        cmd.Parameters.Add("@NombreInsumo", SqlDbType.NVarChar).Value = Objeto.NombreInsumo;
                        cmd.Parameters.Add("@NombreInterno", SqlDbType.NVarChar).Value = Objeto.NombreInterno;
                        cmd.Parameters.Add("@UnidadMedida", SqlDbType.NVarChar).Value = Objeto.UnidadMedida;
                        cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = Objeto.PrecioUnitario;
                        cmd.Parameters.Add("@TotalCompraMX", SqlDbType.Decimal).Value = Objeto.TotalCompraMX;
                        cmd.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = Objeto.IdFamilia;
                        cmd.Parameters.Add("@IdMoneda", SqlDbType.Int).Value = Objeto.IdMoneda;
                        cmd.Parameters.Add("@DetalleAccion", SqlDbType.VarChar).Value = "A";
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

        public int ActualizarV2(InsumosModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spActualizaInsumosFormulas", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdInsumo", SqlDbType.Int).Value = Objeto.IdInsumo;
                        cmd.Parameters.Add("@PUnitario", SqlDbType.Decimal).Value = Objeto.PrecioUnitario;
                        cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Objeto.IdUsuario;
                        cmd.Parameters.Add("@ActualizaFormulas", SqlDbType.Bit).Value = Objeto.ActualizaFormulas;
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

        public DataTable ConsultaGridPorProveedor(int IdProveedor)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsumosConsultaProveedor", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = IdProveedor;


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
        public DataTable ConsultaGridPorId(int IdInsumo)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsumosConsultaPorId", con))
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
        public DataTable ConsultaGridPorFamilia(int IdFamilia)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsumosConsultaPorFamilia", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = IdFamilia;


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
        public DataTable ConsultaGridGeneral()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsumosConsultaGeneral", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable ConsultaGridPorNombre(string nombreInsumo)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsumosConsultaPorNombre", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@nombreInsumo", SqlDbType.NVarChar).Value = nombreInsumo;


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
        public DataTable ConsultaGridIngredientes()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsumosConsultaIngredietnes", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable ConsultaGridAcabados()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsumosConsultaAcabados", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable ConsultaGridPorMoneda(int IdMoneda)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsumosConsultaPorMoneda", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdMoneda", SqlDbType.Int).Value = IdMoneda;


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
        public int Borrar(int IdInsumo)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsumosDarDeBaja", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdInsumo", SqlDbType.Int).Value = IdInsumo;
                        con.Open();
                        res = Convert.ToInt32(cmd.ExecuteNonQuery());
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
    }
}

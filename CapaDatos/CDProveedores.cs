using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDProveedores
    {

        public int Guardar(ProveedoresModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spProveedoresGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = Objeto.IdProveedor;
                        cmd.Parameters.Add("@NombreProveedor", SqlDbType.NVarChar).Value = Objeto.nombreProveedor;
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
        public int Actualizar(ProveedoresModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spProveedoresGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = Objeto.IdProveedor;
                        cmd.Parameters.Add("@NombreProveedor", SqlDbType.NVarChar).Value = Objeto.nombreProveedor;
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
        public DataTable ConsultaGridGeneral()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spProveedoresConsutaGeneral", con))
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

        public DataTable ConsultaGridPorId(int IdProvedor)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spProveedoresConsultaPorId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = IdProvedor;


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
        public int Borrar(int IdProveedor)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spProveedoresDarDeBaja", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = IdProveedor;
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

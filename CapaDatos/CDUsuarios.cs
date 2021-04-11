using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CDUsuarios
    {

        public int Guardar(UsuariosModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spUsuarioGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Objeto.IdUsuario;
                        cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = Objeto.Nombre;
                        cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = Objeto.Username;
                        cmd.Parameters.Add("@Pasword", SqlDbType.NVarChar).Value = Objeto.Pasword;
                        cmd.Parameters.Add("@IdRol", SqlDbType.Int).Value = Objeto.IdRol;
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = Objeto.email;
                        cmd.Parameters.Add("@DetalleAccion", SqlDbType.Char).Value = 'G';
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
        public int Actualizar(UsuariosModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spUsuarioGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Objeto.IdUsuario;
                        cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = Objeto.Nombre;
                        cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = Objeto.Username;
                        cmd.Parameters.Add("@Pasword", SqlDbType.NVarChar).Value = Objeto.Pasword;
                        cmd.Parameters.Add("@IdRol", SqlDbType.Int).Value = Objeto.IdRol;
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = Objeto.email;
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

        public DataTable ConsultaGridValidaUserName(string Username)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spUsuariosValidaUsername", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = Username;


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
                    using (SqlCommand cmd = new SqlCommand("spUsuariosConsultaUsuariosActivos", con))
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
        public DataTable ConsultaGridLOGIN(string Username, string pwd)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spUsuarioConsultaUsername", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = Username;
                        cmd.Parameters.Add("@Pasword", SqlDbType.NVarChar).Value = pwd;


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

        public DataTable ConsultaGridPorId(int IdUsuario)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spUsuarioConsultaPorId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;


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
        public DataTable ConsultaGridRolesActivos()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spRolesUsuarioConsultaActivo", con))
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

        public int Borrar(int IdUsuario)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spUsuarioDarDeBaja", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Parametro", SqlDbType.Int).Value = IdUsuario;
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

        #region Respaldos

        public int GuardarRespaldo()
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spRespaldo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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
        public int GuardarRespaldo(string ruta)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spRespaldo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Ruta", SqlDbType.NVarChar).Value = ruta;
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
        public DataTable ConsultaGridRespaldoPorFecha(int Mes, int anio)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spConsultaRespaldo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Mes", SqlDbType.Int).Value = Mes;
                        cmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;


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
        #endregion
    }
}

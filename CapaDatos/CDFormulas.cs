using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDFormulas
    {
        private string conexion { get; set; }

        public CDFormulas(string conexion)
        {
            this.conexion = conexion ?? throw new ArgumentNullException(nameof(conexion));
        }

        public int Guardar(FormulasModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spFormulasGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdFormula", SqlDbType.Int).Value = Objeto.IdFormula;
                        cmd.Parameters.Add("@NombreFormula", SqlDbType.NVarChar).Value = Objeto.NombreFormula;
                        cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = Objeto.Cantidad;
                        cmd.Parameters.Add("@Capacidad", SqlDbType.VarChar).Value = Objeto.Capacidad;
                        cmd.Parameters.Add("@UnidadMedida", SqlDbType.NVarChar).Value = Objeto.UnidadMedida;
                        cmd.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = Objeto.IdFamilia;
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
        public int Actualizar(FormulasModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spFormulasGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdFormula", SqlDbType.Int).Value = Objeto.IdFormula;
                        cmd.Parameters.Add("@NombreFormula", SqlDbType.NVarChar).Value = Objeto.NombreFormula;
                        cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = Objeto.Cantidad;
                        cmd.Parameters.Add("@Capacidad", SqlDbType.VarChar).Value = Objeto.Capacidad;
                        cmd.Parameters.Add("@UnidadMedida", SqlDbType.NVarChar).Value = Objeto.UnidadMedida;
                        cmd.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = Objeto.IdFamilia;
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

        public int Borrar(int IdFormula)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spFormulasDardeBaja", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdFormula", SqlDbType.Int).Value = IdFormula;
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
        public DataTable ConsultaGridPorNombre(string Nombre, bool Activo)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spFormulasConsultaPorNombre", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = Nombre;
                        cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = Activo;


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
        public DataTable ConsultaGridActivas()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spFormulasConsultaActivo", con))
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
        public DataTable ConsultaGridIndividual(int IdFormula)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spFormulasConsultaPorId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdFormula", SqlDbType.Int).Value = IdFormula;


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
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spFormulasConsultaPorFamilia", con))
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
    }
}

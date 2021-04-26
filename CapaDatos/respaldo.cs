using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CapaDatos
{
    public class respaldo
    {
        private string conexion { get; set; }

        public respaldo(string conexion)
        {
            this.conexion = conexion ?? throw new ArgumentNullException(nameof(conexion));
        }

        public void DoLocalBackup(string AremoteTempPath, string AlocalPath)
        {
            try
            {
                SqlConnection _conn = new SqlConnection(conexion);
                string _dbname = "sdproliza_dev";
                if (_conn == null)
                    return;
                SqlCommand _command = new SqlCommand();
                _command.Connection = _conn;
                // nice filename on local side, so we know when backup was done
                string fileName = _dbname + DateTime.Now.Year.ToString() + "-" +
                    DateTime.Now.Month.ToString() + "-" +
                    DateTime.Now.Day.ToString() + "-" +
                        DateTime.Now.Millisecond.ToString() + ".bak";
                // we invoke this method to ensure we didnt mess up with other programs
                string temporaryTableName = "Respaldos";

                string _sql;

                _sql = String.Format("BACKUP DATABASE {0} TO DISK = N'{1}\\{0}.bak' " +
                       "WITH FORMAT, COPY_ONLY, INIT, NAME = N'{0} - Full Database " +
                       "Backup', SKIP ", _dbname, AremoteTempPath, _dbname);
                _command.CommandText = _sql;
                _conn.Open();
                _command.ExecuteNonQuery();
                _conn.Close();
                _sql = String.Format("IF OBJECT_ID('tempdb..##{0}') IS " +
                       "NOT NULL DROP TABLE ##{0}", temporaryTableName);
                _command.CommandText = _sql;
                _conn.Open();
                _command.ExecuteNonQuery();
                _conn.Close();
                _sql = String.Format("CREATE TABLE ##{0} (bck VARBINARY(MAX))",
                                     temporaryTableName);
                _command.CommandText = _sql;
                _conn.Open();
                _command.ExecuteNonQuery();
                _conn.Close();
                _sql = String.Format("INSERT INTO ##{0} SELECT bck.* FROM " +
                       "OPENROWSET(BULK '{1}\\{2}.bak',SINGLE_BLOB) bck",
                       temporaryTableName, AremoteTempPath, _dbname);
                _command.CommandText = _sql;
                _conn.Open();
                _command.ExecuteNonQuery();
                _conn.Close();
                _sql = String.Format("SELECT bck FROM ##{0}", temporaryTableName);
                SqlDataAdapter da = new SqlDataAdapter(_sql, _conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataRow dr = ds.Tables[0].Rows[0];
                byte[] backupFromServer = new byte[0];
                backupFromServer = (byte[])dr["bck"];
                int aSize = new int();
                aSize = backupFromServer.GetUpperBound(0) + 1;

                FileStream fs = new FileStream(String.Format("{0}\\{1}",
                                AlocalPath, fileName), FileMode.OpenOrCreate,
                                FileAccess.Write);
                fs.Write(backupFromServer, 0, aSize);
                fs.Close();

                _sql = String.Format("DROP TABLE ##{0}", temporaryTableName);
                _command.CommandText = _sql;
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}

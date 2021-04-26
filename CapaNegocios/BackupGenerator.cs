using System;
using System.IO;

namespace CapaNegocios
{
    public class BackupGenerator
    {
        private static CNUsuarios cnUsuario;
        public BackupGenerator(string conexion)
        {
            cnUsuario = new CNUsuarios(conexion);
        }
        public void SimpleFileMove()
        {
            int Mes = DateTime.Now.Month;
            int anio = DateTime.Now.Year;
            if (cnUsuario.ConsultaRespaldoFecha(Mes, anio).Rows.Count == 0)
            {
                cnUsuario.Respaldo();
                string[] dirs = Directory.GetFiles(@"C:\PROLIZA\", "*.bak");
                int cantidad = dirs.Length;
                for (int i = 0; i < dirs.Length; i++)
                {
                    string sourceFile = @"C:\PROLIZA\" + Path.GetFileName(dirs[i]);
                    string destinationFile = @"C:\Users\TOÑO\OneDrive\BD\" + Path.GetFileName(dirs[i]);
                    File.Move(sourceFile, destinationFile);
                }
            }
        }
        public static bool RespaldoMes()
        {
            var dateTosearch = DateTime.Now.AddMonths(-1);
            int Mes = dateTosearch.Month;
            int anio = dateTosearch.Year;
            return cnUsuario.ConsultaRespaldoFecha(Mes, anio).Rows.Count != 0;
        }
        public static bool createRespaldo(string Directory, out string Msj)
        {
            try
            {
                if (cnUsuario.Respaldo(Directory) == 0)
                    throw new Exception("Error al crear el respaldo. Contacte al administrador de sistemas.");
                Msj = "";
                return true;
            }
            catch (Exception ex)
            {
                Msj = ex.Message;
                return false;
            }
        }

    }
}

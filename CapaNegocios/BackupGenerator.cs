using System;
using System.IO;

namespace CapaNegocios
{
    public class BackupGenerator
    {

        public void SimpleFileMove()
        {
            int Mes = DateTime.Now.Month;
            int anio = DateTime.Now.Year;
            if (new CNUsuarios().ConsultaRespaldoFecha(Mes, anio).Rows.Count == 0)
            {
                new CNUsuarios().Respaldo();
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

    }
}

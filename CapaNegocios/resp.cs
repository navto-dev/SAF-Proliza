﻿namespace CapaNegocios
{
    public class resp
    {
        public void respaldo()
        {
            new CapaDatos.respaldo().DoLocalBackup(@"D:\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\Backup\", @"C:\Data");
        }
    }
}

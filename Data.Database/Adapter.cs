using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Business.Entities;
namespace Data.Database
{
    public class Adapter
    {
        
        //Clave por defecto a utlizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringLocal";

        protected SqlConnection sqlConn = new SqlConnection();


        private string connectionString;

        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");

        protected void OpenConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Server=localhost;Database=Academia;User=net; Password=net;"].ConnectionString;
            sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
            //throw new Exception("Metodo no implementado");
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
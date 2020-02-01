using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SetRooms.Class
{
    class SQLDBConnection
    {
        private string dataSource, catalog, connectionString;
        bool integratedSecurity;
        public SqlConnection Connection;
        public SqlCommand CMD;

        public SQLDBConnection(string dataSource, string catalog, bool integratedSecurity)
        {
            this.dataSource = dataSource;
            this.catalog = catalog;
            this.integratedSecurity = integratedSecurity;
            connectionString = $"Data Source={this.dataSource};Initial Catalog={this.catalog};Integrated Security={this.integratedSecurity}";
        }

        public bool GetConnection()
        {
            //SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder();
            //connBuilder.Add("Database", dbName);
            //connBuilder.Add("Data Source", hostDS);
            //connBuilder.Add("User Id", uID);
            //connBuilder.Add("Password", pwd);
            //connBuilder.ConnectionString()

            Connection = new SqlConnection(connectionString);

            try
            {

                Connection.Open();
                return true;//Console.WriteLine("Conectado");
            }
            catch (Exception)
            {
                return false;//Console.WriteLine("ERROR");
                //throw;
            }
        }

        public bool CreateCMD()
        {
            try
            {
                CMD = Connection.CreateCommand();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Establece/Asigna al CMD el Query a ejecutar, después de haber asignado esto, habria que ejecutarlo
        public bool SetSQLQuery(string strSQLQuery)
        {
            try
            {
                CMD.CommandText = strSQLQuery;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Open()
        {
            try
            {
                Connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Close()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}

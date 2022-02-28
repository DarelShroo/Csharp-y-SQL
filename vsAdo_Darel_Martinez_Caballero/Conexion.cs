using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMicrosfPROYECTO
{
    internal class Conexion
    {
        /*
         *
         * Clase Conexión, aquí se ubica la conexión a SQLServer
         * 
         */
        string cadena = "Data Source=DESKTOP-I231AFO\\SQLEXPRESS;Initial Catalog=bdhoteles; Integrated Security=True";
        private SqlConnection sqlConnection = new SqlConnection();

        /*
         *Constructor de la clase en la que realizamos la conexión a los datos del servidor sql.
         */
        public Conexion() {
            sqlConnection.ConnectionString = cadena;
        }
        public void openConection()
        {
            //Método openConection() se encarga de abrir la conexión a la bd
            try
            {
                sqlConnection.Open();
                Console.WriteLine("Open conection");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void closeConnection()
        {
            //Este método se encarga de abrir la conexión a la bd

            sqlConnection.Close();
        }

        public SqlConnection getConexion() {
            //Nos devuelve un objeto sqlConnection con los datos y la conexión a esta bd.
            return this.sqlConnection;
        }

    }
}

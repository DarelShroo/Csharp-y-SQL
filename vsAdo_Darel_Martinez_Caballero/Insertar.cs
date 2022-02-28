using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLMicrosfPROYECTO
{
    public partial class Insertar : Form
    {
        private Conexion conexion = new Conexion();
        private Visualizar visualizar = new Visualizar();
/*
 *  Clase insertar
 * Aquí los registros se insertan en las tablas
 * utilizando los textBox y un botón de click
 * 
 */
        public Insertar()
        {
            InitializeComponent();

            //Abrimos la conexió
            conexion.openConection();

            //Le pasamos los datos a los dataGridView utilizando los diferentes métodos de la clase Visualizar
            dgvClientes.DataSource = visualizar.visualizarClientes();
            dgvHabitaciones.DataSource = visualizar.visualizarHabitaciones();
            dgvHoteles.DataSource = visualizar.visualizarHoteles();
            dgvRegimenes.DataSource = visualizar.visualizarRegimenes();
            
            //Cerramos la conexión
            conexion.closeConnection();

        }

        private void btnInsertarCliente_Click(object sender, EventArgs e)
        {
            //Si el usuario hace click se llamará a este método
            //Abrimos la conexion
            conexion.openConection();
            //Creamos un string con la sentencia y los respectivos nombre de datos que van a ser introducidos 
            string query = "INSERT INTO clientes VALUES (@coddnionie, @nombre, @nacionalidad)";
            
            //Instanciamos un objeto SqlCommand le pasamos la sentencia y un objeto conexión
            SqlCommand sqlCommand = new SqlCommand(query, conexion.getConexion());
            //Le pasamos los datos recogidos de lso diferentes textBox y los enlazamos a los parámetros
            sqlCommand.Parameters.AddWithValue("@coddnionie", txtCodnionie.Text);
            sqlCommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
            sqlCommand.Parameters.AddWithValue("@nacionalidad", txtNacionalidad.Text);
            
            //Ejecutamos la sentencia
            sqlCommand.ExecuteNonQuery();
            
            //Limpiamos los textBox
            txtCodnionie.Text = "";
            txtNombre.Text = "";
            txtNacionalidad.Text = "";
            
            //Cargamos la vista en el dataGridView
            dgvClientes.DataSource = visualizar.visualizarClientes();

            //Rrefrescamos el dataGridView con los nuevos datos
            dgvClientes.Refresh();
            
            //Cerramos la conexion
            conexion.closeConnection();
        }

        private void btnInsertHotel_Click(object sender, EventArgs e)
        {
            conexion.openConection();
            string query = "INSERT INTO hoteles VALUES (@codHotel, @nomHotel)";
            SqlCommand sqlCommand = new SqlCommand(query, conexion.getConexion());

            sqlCommand.Parameters.AddWithValue("@codHotel", txtCodHotelHoteles.Text);
            sqlCommand.Parameters.AddWithValue("@nomHotel", txtNomHotelHoteles.Text);
            sqlCommand.ExecuteNonQuery();

            txtCodHotelHoteles.Text = "";
            txtNomHotelHoteles.Text = "";
            dgvHoteles.DataSource = visualizar.visualizarHoteles();
            dgvHoteles.Refresh();
            conexion.closeConnection();
        }

        private void btnInsertRegimen_Click(object sender, EventArgs e)
        {
            conexion.openConection();
            string query = "INSERT INTO regimenes VALUES (@codHotel, @tipo, @precio)";
            SqlCommand sqlCommand = new SqlCommand(query, conexion.getConexion());

            sqlCommand.Parameters.AddWithValue("@codHotel", txtCodhotelRegimenes.Text);
            sqlCommand.Parameters.AddWithValue("@tipo", txtTipoRegimenes.Text);
            sqlCommand.Parameters.AddWithValue("@precio", txtPrecioRegimenes.Text);

            dgvRegimenes.DataSource = visualizar.visualizarRegimenes();
            dgvRegimenes.Refresh();
            conexion.closeConnection();
        }

        private void btnInsertHabitaciones_Click(object sender, EventArgs e)
        {
            //Si el usuario hace click se llamará a este método
            //Abrimos la conexion
            conexion.openConection();
            
            //Creamos un string con la sentencia y los respectivos parámetros que recibirá
            string query = "INSERT INTO habitaciones VALUES (@codHotel, @numHabitacion, @capacidad, @preciodia, @activa)";
            
            //Instanciamos un objeto SqlCommand
            SqlCommand sqlCommand = new SqlCommand(query, conexion.getConexion());

            //Le pasamos los datos y los enlazamos a los respectivos parámetros de entrada
            sqlCommand.Parameters.AddWithValue("@codHotel", txtCodHotelHabitaciones.Text);
            sqlCommand.Parameters.AddWithValue("@numHabitacion", txtNumHabitacion.Text);
            sqlCommand.Parameters.AddWithValue("@capacidad",txtCapacidad.Text);
            sqlCommand.Parameters.AddWithValue("@preciodia", txtPreciodia.Text);
            //Control booleano 
            sqlCommand.Parameters.AddWithValue("@activa", chkActiva.Checked ? 1 : 0);
            
            //Ejecutamos la sentencia
            sqlCommand.ExecuteNonQuery();
            txtCodHotelHabitaciones.Text = "";
            txtNumHabitacion.Text = "";
            txtCapacidad.Text = "";
            txtPreciodia.Text = "";
            chkActiva.Checked = false;
            
            //Llamamos al la visualización 
            dgvHabitaciones.DataSource = visualizar.visualizarHabitaciones();
            
            //Refrescamos con los nuevos datos.
            dgvHabitaciones.Refresh();
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

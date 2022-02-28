using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SQLMicrosfPROYECTO
{
    public partial class Procedimientos : Form
    {
        private readonly Conexion conexion = new Conexion();
        private Visualizar visualizar = new Visualizar();
        public Procedimientos()
        {
            InitializeComponent();
            conexion.openConection();
            dgvHabitaciones.DataSource = visualizar.visualizarHabitaciones();
            conexion.closeConnection();
        }

        private void btnExecuteProcListaHabitaciones_Click(object sender, EventArgs e)
        {
            //DEVUELVE VARIOS REGISTROS
            //Abrimos la conexión 
            conexion.openConection();
            
            //Instanciamos el objeto DataTable
            var dt = new DataTable();
            
            //Le pasamos al dataGridView el DataTable
            dgvListaHabitaciones.DataSource = dt;
            
            //Creamos un string con el nombre del procedimiento
            var query = "lista_habitaciones_nomHotel";
            var sqlDataAdapter = new SqlDataAdapter(query, conexion.getConexion());

            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter.SelectCommand.Parameters.Add("@nomHotel", SqlDbType.VarChar).Value = ListaHabitaciones.Text;
            sqlDataAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
                using (sqlDataAdapter)
                {
                    dgvListaHabitaciones.DataSource = dt;
                }
            else
                MessageBox.Show("No existen registros");

            conexion.closeConnection();
        }

        private void btnExecuteProccantidadHabitaciones_Click(object sender, EventArgs e)
        {
            //SUMA LAS HABITACIONES
            //Abrimos la conexión
            conexion.openConection();
            
            //Instanciamos un objeto DataTable
            var dt = new DataTable();
            
            //Pasamos el dataTable al DatGridView
            dgvCantidadHabitaciones.DataSource = dt;
            
            //Instanciamos un objeto SqlCommand le pasamos el nombre del procedimiento y el objeto conexión
            var query = new SqlCommand("cantidadHabitaciones", conexion.getConexion());
            
            //Instanciamos el objeto DataAdapter y le pasamos el objeto sqlCommand
            var sqlDataAdapter = new SqlDataAdapter(query);

            //Le indicamos que se trata de un procedimient
            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            
            //Le damos valos a los parámetros de entrada y le indicamos sus respectivos tipos de datos
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@nombreHotel", SqlDbType.VarChar).Value =
                txtNomHotelcantidadHabitaciones.Text;
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@preciod", SqlDbType.Int).Value =
                txtPreciodiaCantidadHabitaciones.Text;
            
            //Le indicamos los parámetros de salida
            sqlDataAdapter.SelectCommand.Parameters.Add("@salida1", SqlDbType.Int).Direction =
                ParameterDirection.Output;
            sqlDataAdapter.SelectCommand.Parameters.Add("@salida2", SqlDbType.Int).Direction =
                ParameterDirection.Output;

            //Le pasamos el dataTable al dataAdapter utilizando su método fill
            sqlDataAdapter.Fill(dt);
            
            //Creamos las columnas que serán usadas
            DataColumn colCantidadHabitaciones = dt.Columns.Add("CantidadHabitaciones", typeof(int));
            DataColumn colCantidadPreciodia = dt.Columns.Add("preciodia", typeof(int));
            
            DataGridViewRow row = dgvCantidadHabitaciones.Rows[0];

            //Limpiamos los posibles valores anteriores
            row.Cells[0].Value = "";
            row.Cells[1].Value = "";
            
            //Le damos el valor que recogemos de los parámetros de salida
            row.Cells[0].Value = query.Parameters["@salida1"].Value.ToString();
            row.Cells[1].Value = query.Parameters["@salida2"].Value.ToString();
            
            //Ejecutamos el procedimiento
            query.ExecuteNonQuery();

            //Creamos el adaptador
            using (sqlDataAdapter)
            {
                //Le pasamos el dataTable al dataGridView
                dgvCantidadHabitaciones.DataSource = dt;
                
                //Refrescamos el dataGridView
                dgvCantidadHabitaciones.Refresh();
            }

            //Cerramos la conexión
            conexion.closeConnection();
        }

        private void btnProcInsertarHabitacion_Click(object sender, EventArgs e)
        {
            //DEVUELVE PARÁMETROS
            //Abrimos la conexión
            conexion.openConection();
                
            //Instanciamos un objeto DataTable
                var dt = new DataTable();
                
                //Le pasamos el objeto DataTable al dataGridView
                dgvProcInsertHabitaciones.DataSource = dt;
                //Instanciamos un objeto SqlCommand llamando al procedimiento y además el objeto de la conexión
                var query = new SqlCommand("insertarHabitacion", conexion.getConexion());
                //Instanciamos 
                var sqlDataAdapter = new SqlDataAdapter(query);
                
                //Al tratarse de un procedimiento usamos CommandType y se lo indicamos
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                //Damos valor a los diferentes parámetros de entrada con sus respectivos tipos de datos
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@codHotel", SqlDbType.Char).Value =
                    txtCodHotelHabitaciones.Text;
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@numHabitacion", SqlDbType.Char).Value =
                    txtNumHabitacion.Text;
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@capacidad", SqlDbType.TinyInt).Value =
                    txtCapacidad.Text;
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@preciodia", SqlDbType.Int).Value =
                    txtPreciodia.Text;
                //Control booleano                
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@activa", SqlDbType.Bit).Value =
                    chkActiva.Checked ? 1 : 0;
                
                //Indicamos los parámetros que serán de salida
                sqlDataAdapter.SelectCommand.Parameters.Add("@salida1", SqlDbType.Int).Direction =
                    ParameterDirection.Output;
                sqlDataAdapter.SelectCommand.Parameters.Add("@salida2", SqlDbType.Int).Direction =
                    ParameterDirection.Output;
                
                //Recogemos los datos del dataTable y se los pasamos al dataAdapter
                sqlDataAdapter.Fill(dt);
                
                //Creamos las columnas que recibirán los datos de salida de la sentencia
                DataColumn colCantidadHabitaciones = dt.Columns.Add("CantidadHabitaciones", typeof(int));
                DataColumn colCantidadPreciodia = dt.Columns.Add("preciodia", typeof(int));
                
                //Creamos un dataGridViewRow que será la fila que 
                MessageBox.Show(dgvProcInsertHabitaciones.Rows[0].ToString());
                DataGridViewRow row = dgvProcInsertHabitaciones.Rows[0];

                //Limpiamos los posibles valores anteriores
                row.Cells[0].Value = "";
                row.Cells[1].Value = "";
                
                //Pasamos los datos a las diferentes columnas
                row.Cells[0].Value = query.Parameters["@salida1"].Value.ToString();
                row.Cells[1].Value = query.Parameters["@salida2"].Value.ToString();

                //Limpiamos los textBox
                txtCodHotelHabitaciones.Text = "";
                txtNumHabitacion.Text = "";
                txtCapacidad.Text = "";
                txtPreciodia.Text = "";
                //Pasamos a false el checkBox
                chkActiva.Checked = false;
                //Utilizamos refresh para actualizar el dataGridView con los nuevos datos
                dgvHabitaciones.Refresh();
                //Le pasamos los datos de la consula visualizar habitaciones de la clase Visualizar
                dgvHabitaciones.DataSource = visualizar.visualizarHabitaciones();
                //Cerramos la conexión
                conexion.closeConnection();
         
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
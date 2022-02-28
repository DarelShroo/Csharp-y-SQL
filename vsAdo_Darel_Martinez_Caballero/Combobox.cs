using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLMicrosfPROYECTO
{
    public partial class Combobox : Form
    {
        Conexion conexion = new Conexion();
        private string codHotelOld;
        private string numHabitacionOld;
       
        public Combobox()
        {
            conexion.openConection();
            InitializeComponent();
            loadDataHabitaciones();
            loadDataRegimenes();
            loadDataHoteles();
            updateDataGrid(null, null);
            conexion.closeConnection();
        }
        
        private void loadDataHabitaciones() {
            conexion.openConection();
            
            //Cargamos los datos de la tabla que vamos a visualizar utilizando un DataSet
            DataSet ds = new DataSet();            
            //Guardamos en una variable la sentencia
            string cmdHoteles = "select * from habitaciones";
            //Instanciamos un objeto SqlDataAdapter, le pasamos la sentencia y la conexión.
            SqlDataAdapter daHabitaciones = new SqlDataAdapter(cmdHoteles, conexion.getConexion());
            //Rellanamos el dataSet 
            daHabitaciones.Fill(ds, "habitaciones");
            //Pasamos los datos de dataset como una tabla "habitaciones"
            dgvHabitaciones.DataSource = ds.Tables["habitaciones"];

            //Creamos un combobox dentro de la tabla
            DataGridViewComboBoxColumn dataGridViewComboBoxColumn = new DataGridViewComboBoxColumn();

            //La propiedad a la que pertenece
            dataGridViewComboBoxColumn.DataPropertyName = "codHotel";
            //Lo que va a mostrar
            dataGridViewComboBoxColumn.DisplayMember = "nomHotel";
            //A quien pertenece
            dataGridViewComboBoxColumn.ValueMember = "codHotel";

            //Creamos la sentencia
            cmdHoteles = "select * from hoteles";
            //Instanciamos un SqlDataAdapter le pasamos la sentencia y el objeto conexión.
            SqlDataAdapter daHoteles = new SqlDataAdapter(cmdHoteles, conexion.getConexion());
            //Rellenamos el dataAdapter con el dataSet
            daHoteles.Fill(ds, "hoteles");
            //Pasamos los datos del dataset como una tabla de hoteles
            dataGridViewComboBoxColumn.DataSource = ds.Tables["hoteles"];
            //Agregamos este combobox como una nueva columna del dataGridView.
            dgvHabitaciones.Columns.Add(dataGridViewComboBoxColumn);
        conexion.closeConnection();
        }

        private void onChangeDataHabitaciones(object sender, DataGridViewCellEventArgs e)
        {
            //Si si producen cambios dentro del dataGridView  este método será llamado
            //Abrimos la conexion
            conexion.openConection();
            //Recogemos la fila donde se han producido cambios
            int rowindex = dgvHabitaciones.CurrentCell.RowIndex;

            //Recogemos todos estos datos que algunos han sido modificados. 
            string codHotel = dgvHabitaciones.Rows[rowindex].Cells[0].Value.ToString();
            //Se necesitará convertir los datos según su tipo en la base de datos.
            int numHabitacion = Convert.ToInt32(dgvHabitaciones.Rows[rowindex].Cells[1].Value.ToString());
            int capacidad = Convert.ToInt32(dgvHabitaciones.Rows[rowindex].Cells[2].Value.ToString());
            int preciodia = Convert.ToInt32(dgvHabitaciones.Rows[rowindex].Cells[3].Value.ToString());
            string activa = dgvHabitaciones.Rows[rowindex].Cells[4].Value.ToString();

            //Creamos una variable con los datos de la sentencia se utiliza @ para poder relacionar los datos con los que van a ser introducidos
            string query = "UPDATE habitaciones SET codHotel = @codHotel, numHabitacion = @numHabitacionNew, capacidad=@capacidad , preciodia=@preciodia , activa=@activa WHERE codHotel=@codHotelOld and numHabitacion = @numHabitacionOld";
            
            //Instanciamos un objeto SqlCommand, le pasamos la sentencia y el objeto conexión
            SqlCommand sqlCommand = new SqlCommand(query, conexion.getConexion());

            //Le pasamos los datos de los parámetros de entrada 
            sqlCommand.Parameters.AddWithValue("@codHotel", codHotel);
            sqlCommand.Parameters.AddWithValue("@numHabitacionNew", numHabitacion);
            sqlCommand.Parameters.AddWithValue("@capacidad", capacidad);
            sqlCommand.Parameters.AddWithValue("@preciodia", preciodia);
            sqlCommand.Parameters.AddWithValue("@activa", activa);
            sqlCommand.Parameters.AddWithValue("@codHotelOld", codHotelOld);
            sqlCommand.Parameters.AddWithValue("@numHabitacionOld", numHabitacionOld);

            //Ejecutamos la sentencia
            sqlCommand.ExecuteNonQuery();
            conexion.closeConnection();
        }

        private void loadDataRegimenes()
        {
            conexion.openConection();

            DataSet ds = new DataSet();
            string cmdHoteles = "select * from regimenes";
            SqlDataAdapter daHabitaciones = new SqlDataAdapter(cmdHoteles, conexion.getConexion());
            daHabitaciones.Fill(ds, "regimenes");
            dgvRegimenes.DataSource = ds.Tables["regimenes"];

            DataGridViewComboBoxColumn dataGridViewComboBoxColumn = new DataGridViewComboBoxColumn();

            dataGridViewComboBoxColumn.DataPropertyName = "codHotel";
            dataGridViewComboBoxColumn.DisplayMember = "nomHotel";
            dataGridViewComboBoxColumn.ValueMember = "codHotel";

            cmdHoteles = "select * from hoteles";
            SqlDataAdapter daHoteles = new SqlDataAdapter(cmdHoteles, conexion.getConexion());
            daHoteles.Fill(ds, "hoteles");
            dataGridViewComboBoxColumn.DataSource = ds.Tables["hoteles"];
            dgvRegimenes.Columns.Add(dataGridViewComboBoxColumn);
            conexion.closeConnection();
        }



        private void onChangeDataRegimenes(object sender, DataGridViewCellEventArgs e)
        {
            conexion.openConection();
            int rowindex = dgvRegimenes.CurrentCell.RowIndex;

            string codregimen = dgvRegimenes.Rows[rowindex].Cells[0].Value.ToString();
            string codHotel = dgvRegimenes.Rows[rowindex].Cells[1].Value.ToString();
            string tipo = dgvRegimenes.Rows[rowindex].Cells[2].Value.ToString();
            int precio = Convert.ToInt32(dgvRegimenes.Rows[rowindex].Cells[3].Value.ToString());

            string query = "UPDATE regimenes SET codHotel = @codHotel, tipo=@tipo , precio=@precio WHERE codregimen=@codregimen";
            SqlCommand sqlCommand = new SqlCommand(query, conexion.getConexion());

            sqlCommand.Parameters.AddWithValue("@codHotel", codHotel);
            sqlCommand.Parameters.AddWithValue("@tipo", tipo);
            sqlCommand.Parameters.AddWithValue("@precio", precio);
            sqlCommand.Parameters.AddWithValue("@codregimen", codregimen);

            sqlCommand.ExecuteNonQuery();
            conexion.closeConnection();
        }

        private void loadDataHoteles() {
            //AQUÍ CREAMOS EL COMBOBOX ENLAZADO A UNA TABLA
            //Abrimos la conexión
            conexion.getConexion();
            //Instanciamos un objeto SqlCommand y le pasamos la sentencia
            SqlCommand sqlCommand = new SqlCommand("select * from hoteles",conexion.getConexion());
            
            //Instanciamos un objeto dataTable
            DataTable dt = new DataTable();
            //Instanciamos un objeto dataAdapter
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            
            //Le pasamos el objeto dataTable al adaptador
            dataAdapter.Fill(dt);
            //Instanciamos un objeto DataRow  que contendrá todos los hoteles en el combobox
            DataRow dr = dt.NewRow();
            //Seleccionamos la columna y como valor por defecto le pasamos un string
            dr["codHotel"] = "Selecciona un codHotel";
            
            //Y nos posicionamos en la priemr posición
            dt.Rows.InsertAt(dr, 0);
            //Enlazamos la columna 
            comboCodHoteles.ValueMember = "codHotel";
            //La columna que mostraremos
            comboCodHoteles.DisplayMember = "codHotel";
            //Le pasamos los datos del dataTable
            comboCodHoteles.DataSource = dt;
            //Por último cerramos la conexión
            conexion.closeConnection();
        }


        private void beginValue(object sender, DataGridViewCellCancelEventArgs e)
        {
            //Obtenemos los valores  anteriores para usarlos en el update
            int rowindex = dgvHabitaciones.CurrentCell.RowIndex;
            codHotelOld = dgvHabitaciones.Rows[rowindex].Cells[0].Value.ToString();
            numHabitacionOld = dgvHabitaciones.Rows[rowindex].Cells[1].Value.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Cerramos el form
            this.Close();
        }

        private void updateDataGrid(object sender, EventArgs e)
        {
            //AQUÍ SE ACTUALIZAN LOS DATOS DE LA TABLA ENLAZADA AL COMBOBOX
            //Este método es llamado desde "DropDownClose" del combobox
            
            //Abrimos la conexion
            conexion.openConection();
            
            //Creamos una variable con la sentencia 
            string consulta = "SELECT * FROM estancias WHERE codHotel = @codHotel" ;

            //Creamos el objeto SqlCommand le pasamos la consulta y la conexión
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion.getConexion());
            //Creamos el objeto DataAdapter y le pasamos el sqlCommand
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            //Creamos el adaptador
            using (adapter)
            {
                //Le pasamos el codigo de hotel que se necesitará para el where y poder actualizar los datos
                sqlCommand.Parameters.AddWithValue("@codHotel", comboCodHoteles.SelectedValue);
                //Instanciamos in objeto DataTable
                DataTable dt = new DataTable();
                //Le pasamos el DataTable atravéz del método Fill al adaptador.
                adapter.Fill(dt);
                dgvEstancias.DataSource = dt;
            }
            conexion.closeConnection();
        }
    }
}

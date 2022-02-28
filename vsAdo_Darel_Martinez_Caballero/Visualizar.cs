using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SQLMicrosfPROYECTO
{
    public partial class Visualizar : Form
    {
        //Instanciamos un objeto conexión
        Conexion conexion = new Conexion();

        public Visualizar()
        {
            InitializeComponent();
        }
        public DataTable visualizarClientes(){
            //Abrimos la conexión
            conexion.openConection();
            //Creamos un string con la consulta sql
            string consulta = "SELECT * FROM clientes";

            //Creamos un objeto SqlDataAdapter y le introducimos por parámetros la sentencia sql y el objeto conexión
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion.getConexion());
            
            using (adapter)
            {
                //Utilizamos el adaptador creado
                
                //Creamos un objeto DataTable
                DataTable dt = new DataTable();
                
                //Agregamos el contenido del DataTable al adaptador
                adapter.Fill(dt);
                
                //Agregamos los datos del adaptador al DataGridView de Clientes
                dgvClientes.DataSource = dt;
                
                //Mostramos al usuario el numero de filas de la tabla
                lblFilasClientes.Text = dgvClientes.RowCount.ToString();

                //Devolvemos el objeto DataTable para ser reciclado en las diferentes vistas.
                return dt;
            }
            conexion.closeConnection();
        }

        public DataTable visualizarEstancias()
        {
            string consulta = "SELECT * FROM estancias";

            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion.getConexion());
            using (adapter)
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvEstancias.DataSource = dt;
                lblFilasEstancias.Text = dgvEstancias.RowCount.ToString();

                return dt; 
            }
        }


        public DataTable visualizarHabitaciones()
        {
            string consulta = "SELECT * FROM habitaciones";

            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion.getConexion());
            DataTable dt = new DataTable();

            using (adapter)
            {
                adapter.Fill(dt);
                dgvHabitaciones.DataSource = dt;
                lblFilasHabitaciones.Text = lblFilasHoteles.Text = dgvHoteles.RowCount.ToString();

                return dt;

            }
        }


        public DataTable visualizarHoteles()
        {
            string consulta = "SELECT * FROM hoteles";

            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion.getConexion());
            using (adapter)
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvHoteles.DataSource = dt;
                lblFilasHoteles.Text = dgvHoteles.RowCount.ToString();
                return dt;
            }
        }


        public DataTable visualizarRegimenes()
        {
            string consulta = "SELECT * FROM regimenes";

            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion.getConexion());
            using (adapter)
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvRegimenes.DataSource = dt;
                lblFilasRegimenes.Text = dgvRegimenes.RowCount.ToString();

                return dt;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Visualizar_Load(object sender, EventArgs e)
        {
            //VISUALIZACIÓN DE LAS TABLAS
            //Llamamos a los diferentes métodos creados
            visualizarClientes();
            visualizarEstancias();
            visualizarHabitaciones();
            visualizarHoteles();
            visualizarRegimenes();
        }
    }
}

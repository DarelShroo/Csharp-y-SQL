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
    public partial class Actualizar : Form
    {
        //Instanciamos un objeto visualizar, reciclando a si la clase.
        private Visualizar visualizar = new Visualizar();
        //Instanciamos un objeto conexión, reciclando a si la clase.
        private Conexion conexion = new Conexion();
        
        //Guardamos el valor anterior de su clave en caso de necesitarlo para hacer una búsqueda del registro 
        private string numHabitacionOld;
        public Actualizar()
        {
            InitializeComponent();
            //Abrimos la conexión
            conexion.openConection();
            //Reciclando la clase visualizar procedemos a inyectar los datos del DataTable que nos proporciona a los respectivos dataGridView de este form
            dgvClientes.DataSource = visualizar.visualizarClientes();
            dgvEstancias.DataSource = visualizar.visualizarEstancias();
            dgvHabitaciones.DataSource = visualizar.visualizarHabitaciones();
            dgvHoteles.DataSource = visualizar.visualizarHoteles();
            dgvRegimenes.DataSource = visualizar.visualizarRegimenes();
            //Cerramos la conexión
            conexion.closeConnection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void onClickEstancias(object sender, EventArgs e)
        {
            try
            {
                //Obtenemos el click del usuario y localizamos con ello la fila del registro.
                int rowindex = dgvEstancias.CurrentCell.RowIndex;
                
                //Sabiendo la fila obtenemos los datos de las diferentes tablas y los guardamos en variables.
                string codestancia = dgvEstancias.Rows[rowindex].Cells[0].Value.ToString();
                string coddnionie = dgvEstancias.Rows[rowindex].Cells[1].Value.ToString();
                string codhotel = dgvEstancias.Rows[rowindex].Cells[2].Value.ToString();
                string numhabitacion = dgvEstancias.Rows[rowindex].Cells[3].Value.ToString();
                string fechaInicio = dgvEstancias.Rows[rowindex].Cells[4].Value.ToString().Substring(0, 10);
                string fechaFin = dgvEstancias.Rows[rowindex].Cells[5].Value.ToString().Substring(0, 10);
                string codregimen = dgvEstancias.Rows[rowindex].Cells[6].Value.ToString();
                string ocupantes = dgvEstancias.Rows[rowindex].Cells[7].Value.ToString();
                string precioestancia = dgvEstancias.Rows[rowindex].Cells[8].Value.ToString();
                string pagado = dgvEstancias.Rows[rowindex].Cells[9].Value.ToString();
                
                //Seteamos a los textBox los respectivos datos 
                txtCodestanciaEstancias.Text = codestancia;
                txtCoddnionieEstancias.Text = coddnionie;
                txtCodHotelEstancias.Text = codhotel;
                txtNumHabitacionEstancias.Text = numhabitacion;
                txtFechaInicioEstancias.Text = fechaInicio;
                txtFechaFinEstancias.Text = fechaFin;
                txtCodregimenEstancias.Text = codregimen;
                txtOcupantesEstancias.Text = ocupantes;
                txtPrecioestanciaEstancias.Text = precioestancia;
                //Hay datos que quizás se necesiten convertir.
                chkPagadoEstancias.Checked = Convert.ToBoolean(pagado.ToLower());
            }
            catch (Exception ignored) { }
        }

        public void onClickClientes(object sender, EventArgs e)
        {
            try
            {
                int rowindex = dgvClientes.CurrentCell.RowIndex;

                string coddnionie = dgvClientes.Rows[rowindex].Cells[0].Value.ToString();
                string nombre = dgvClientes.Rows[rowindex].Cells[1].Value.ToString();
                string nacionalidad = dgvClientes.Rows[rowindex].Cells[2].Value.ToString();

                txtCoddnionieClientes.Text = coddnionie;
                txtNombreClientes.Text = nombre;
                txtNacionalidadClientes.Text = nacionalidad;
            } catch (Exception ignored) { }
        }

        public void onClickHabitaciones(object sender, EventArgs e)
        {
            try { 
            int rowindex = dgvHabitaciones.CurrentCell.RowIndex;

            string codhotel = dgvHabitaciones.Rows[rowindex].Cells[0].Value.ToString();
            string numhabitacion = dgvHabitaciones.Rows[rowindex].Cells[1].Value.ToString();
            string capacidad = dgvHabitaciones.Rows[rowindex].Cells[2].Value.ToString();
            string preciodia = dgvHabitaciones.Rows[rowindex].Cells[3].Value.ToString();
            string activa = dgvHabitaciones.Rows[rowindex].Cells[4].Value.ToString();

            numHabitacionOld = dgvHabitaciones.Rows[rowindex].Cells[1].Value.ToString();



            txtCodHotelHabitaciones.Text = codhotel;
            txtNumHabitacionHabitaciones.Text = numhabitacion;
            txtCapacidadHabitaciones.Text = capacidad;
            txtPreciodiaHabitaciones.Text = preciodia;
            chkActivaHabitaciones.Checked = Convert.ToBoolean(activa.ToLower());
        }catch(Exception ignored){}
        }

        public void onClickHoteles(object sender, EventArgs e)
        {
            int rowindex = dgvHoteles.CurrentCell.RowIndex;

            string codhotel = dgvHoteles.Rows[rowindex].Cells[0].Value.ToString();
            string nomhotel = dgvHoteles.Rows[rowindex].Cells[1].Value.ToString();

            txtCodHotelHoteles.Text = codhotel;
            txtNomHotelHoteles.Text = nomhotel;
           
        }

        public void onClickRegimenes(object sender, EventArgs e)
        {
            int rowindex = dgvRegimenes.CurrentCell.RowIndex;

            string codregimen = dgvRegimenes.Rows[rowindex].Cells[0].Value.ToString();
            string codHotel = dgvRegimenes.Rows[rowindex].Cells[1].Value.ToString();
            string tipo = dgvRegimenes.Rows[rowindex].Cells[2].Value.ToString();
            string precio = dgvRegimenes.Rows[rowindex].Cells[3].Value.ToString();


            txtCodRegimenRegimenes.Text = codregimen;
            txtCodHotelRegimenes.Text = codHotel;
            txtTipoRegimenes.Text = tipo;
            txtPrecioRegimenes.Text = precio;
        }

        private void btnUpdateCliente_Click(object sender, EventArgs e)
        {
            //Si el usuario da click en el botón Actualizar cliente se llama a este método
            conexion.openConection();
            
            //Creamos una variable con los da tos de la sentencia.
            string query = "UPDATE clientes SET nombre=@nombre , nacionalidad=@nacionalidad WHERE coddnionie=@coddnionie";
            //Instanciamos un objeto SqlCommand
            SqlCommand sqlCommand = new SqlCommand(query, conexion.getConexion());

            //Le pasamos todos los datos necesarios para que se pueda realizar correctamente la actualización
            sqlCommand.Parameters.AddWithValue("@nombre", txtNombreClientes.Text);
            sqlCommand.Parameters.AddWithValue("@nacionalidad", txtNacionalidadClientes.Text);
            sqlCommand.Parameters.AddWithValue("@coddnionie", txtCoddnionieClientes.Text);
            
            //Ejecutamos la sentencia
            sqlCommand.ExecuteNonQuery();
            
            //Reciclamos la clase visualizar y llamamos a su método visualizarClientes() 
            dgvClientes.DataSource = visualizar.visualizarClientes();

            //Refrescamos el dataGridView para que se visualizen los nuevos datos
            dgvClientes.Refresh();

            //Cerramos la conexión
            conexion.closeConnection();
        }

        private void btnUpdateEstancia_Click(object sender, EventArgs e)
        {
            conexion.openConection();

            string query = "UPDATE estancias SET numhabitacion=@numhabitacion , fechaInicio=@fechaInicio , fechaFin=@fechaFin , codregimen=@codregimen, precioestancia=@precioestancia, pagado=@pagado WHERE codestancia=@codestancia";
            SqlCommand sqlCommand = new SqlCommand(query, conexion.getConexion());

            sqlCommand.Parameters.AddWithValue("@numhabitacion", txtNombreClientes.Text);
            sqlCommand.Parameters.AddWithValue("@fechaInicio", txtNacionalidadClientes.Text);
            sqlCommand.Parameters.AddWithValue("@fechaFin", txtCoddnionieClientes.Text);
            sqlCommand.Parameters.AddWithValue("@codregimen", txtCoddnionieClientes.Text); 
            sqlCommand.Parameters.AddWithValue("@precioestancia", txtCoddnionieClientes.Text);
            sqlCommand.Parameters.AddWithValue("@pagado", chkPagadoEstancias.Checked ? 1 : 0);
            sqlCommand.Parameters.AddWithValue("@codestancia", txtCodestanciaEstancias.Text);
            sqlCommand.ExecuteNonQuery();

            dgvEstancias.DataSource = visualizar.visualizarEstancias();

            dgvEstancias.Refresh();

            conexion.closeConnection();
        }

        private void btnUpdateHabitacion_Click(object sender, EventArgs e)
        {
            conexion.openConection();

            string query = "UPDATE habitaciones SET numHabitacion = @numHabitacionNew, capacidad=@capacidad , preciodia=@preciodia , activa=@activa WHERE codHotel=@codHotel and numHabitacion = @numHabitacionOld";
            SqlCommand sqlCommand = new SqlCommand(query, conexion.getConexion());

            sqlCommand.Parameters.AddWithValue("@capacidad", txtCapacidadHabitaciones.Text);
            sqlCommand.Parameters.AddWithValue("@numHabitacionNew", txtNumHabitacionHabitaciones.Text);
            sqlCommand.Parameters.AddWithValue("@preciodia", txtPreciodiaHabitaciones.Text);
            sqlCommand.Parameters.AddWithValue("@activa", chkActivaHabitaciones.Checked ? 1:0);
            sqlCommand.Parameters.AddWithValue("@codHotel", txtCodHotelHabitaciones.Text);
            sqlCommand.Parameters.AddWithValue("@numHabitacionOld", numHabitacionOld);

            sqlCommand.ExecuteNonQuery();

            dgvHabitaciones.DataSource = visualizar.visualizarHabitaciones();

            dgvHabitaciones.Refresh();

            conexion.closeConnection();
        }

        private void btnUpdateHotel_Click(object sender, EventArgs e)
        {
            conexion.openConection();

            string query = "UPDATE hoteles SET nomHotel=@nomHotel WHERE codHotel=@codHotel";
            SqlCommand sqlCommand = new SqlCommand(query, conexion.getConexion());

            sqlCommand.Parameters.AddWithValue("@nomHotel", txtNomHotelHoteles.Text);
            sqlCommand.Parameters.AddWithValue("@codHotel", txtCodHotelHoteles.Text);


            sqlCommand.ExecuteNonQuery();

            dgvHoteles.DataSource = visualizar.visualizarHoteles();

            dgvHoteles.Refresh();

            conexion.closeConnection();
        }

        private void btnUpdateRegimen_Click(object sender, EventArgs e)
        {
            conexion.openConection();

            string query = "UPDATE regimenes SET tipo=@tipo , precio=@precio WHERE codregimen=@codregimen";
            SqlCommand sqlCommand = new SqlCommand(query, conexion.getConexion());

            sqlCommand.Parameters.AddWithValue("@tipo", txtTipoRegimenes.Text);
            sqlCommand.Parameters.AddWithValue("@precio", txtPrecioRegimenes.Text);
            sqlCommand.Parameters.AddWithValue("@codregimen", txtCodRegimenRegimenes.Text);
     

            sqlCommand.ExecuteNonQuery();

            dgvRegimenes.DataSource = visualizar.visualizarRegimenes();

            dgvRegimenes.Refresh();

            conexion.closeConnection();
        }
    }
}

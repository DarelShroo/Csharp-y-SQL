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
    public partial class Borrar : Form
    {
        //Creamos un objeto conexión, reciclamos la clase.
        private Conexion conexion = new Conexion();
        //Creamos un objeto visualizar, reciclamos la clase
        private Visualizar visualizar = new Visualizar();
        public Borrar()
        { 
            InitializeComponent();
            //Abrimos la conexión 
            conexion.openConection();
            //Aprovechamos la clase ya creado visualizar que nos devolverá un DataTable con las vistas de las tablas
            dgvClientes.DataSource = visualizar.visualizarClientes();
            dgvEstancias.DataSource = visualizar.visualizarEstancias();
            dgvHabitaciones.DataSource = visualizar.visualizarHabitaciones();
            dgvRegimenes.DataSource = visualizar.visualizarRegimenes();
            
            //Cerramos la conexión
            conexion.closeConnection();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBorrarCliente_Click(object sender, EventArgs e)
        {
            //Preguntamos al usuario con MessageBox con opciones si/no
            DialogResult dr = MessageBox.Show("¿Estás seguro de querer borrar el registro?",
                      "Mood Test", MessageBoxButtons.YesNo);
            
            //Comprobamos el resultado de los botones
            switch (dr)
            {
                case DialogResult.Yes:
                    //En el caso de que el usuario haya dado click a si, se intentará realizar el borrado de ese registro.
                    try
                    {
                        //Abrimos la conexión
                        conexion.openConection();

                        string query = "DELETE FROM clientes WHERE coddnionie=@coddnionie";
                        SqlCommand sqlCommand = new SqlCommand(query, conexion.getConexion());

                        int rowindex = dgvClientes.CurrentCell.RowIndex;

                        string coddnionie = dgvClientes.Rows[rowindex].Cells[0].Value.ToString();

                        sqlCommand.Parameters.AddWithValue("@coddnionie", coddnionie);
                        sqlCommand.ExecuteNonQuery();
                        dgvClientes.DataSource = visualizar.visualizarClientes();
                        dgvClientes.Refresh();
                        conexion.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("A ocurrido un error de claves, este registro no se puede eliminar.");
                    }
                    break;
                case DialogResult.No:
                    break;
            }
            

        }

        private void btnBorrarEstancia_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Estás seguro de querer borrar el registro?",
                      "Mood Test", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    try
                    {
                        conexion.openConection();

                        string query = "DELETE FROM estancias WHERE codestancia=@codestancia";
                        SqlCommand sqlCommand = new SqlCommand(query, conexion.getConexion());

                        int rowindex = dgvEstancias.CurrentCell.RowIndex;

                        int codestancia = Convert.ToInt32(dgvEstancias.Rows[rowindex].Cells[0].Value.ToString());
                        sqlCommand.Parameters.AddWithValue("@codestancia", codestancia);
                        sqlCommand.ExecuteNonQuery();

                        dgvEstancias.DataSource = visualizar.visualizarEstancias();

                        dgvEstancias.Refresh();
                        conexion.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("A ocurrido un error de claves, este registro no se puede eliminar.");
                    }
                    break;
                case DialogResult.No:
                    break;
            }

        }

        private void btnBorrarHabitacion_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Estás seguro de querer borrar el registro?",
                      "Mood Test", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    try
                    {
                        conexion.openConection();

                        string query = "DELETE FROM habitaciones WHERE codHotel=@codHotel and numHabitacion = @numHabitacion";
                        SqlCommand sqlCommand = new SqlCommand(query, conexion.getConexion());

                        int rowindex = dgvHabitaciones.CurrentCell.RowIndex;

                        string codHotel = dgvHabitaciones.Rows[rowindex].Cells[0].Value.ToString();
                        string numHabitacion = dgvHabitaciones.Rows[rowindex].Cells[1].Value.ToString();
                        sqlCommand.Parameters.AddWithValue("@codHotel", codHotel);
                        sqlCommand.Parameters.AddWithValue("@numHabitacion", numHabitacion);

                        sqlCommand.ExecuteNonQuery();

                        dgvHabitaciones.DataSource = visualizar.visualizarHabitaciones();

                        dgvHabitaciones.Refresh();
                        conexion.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("A ocurrido un error de claves, este registro no se puede eliminar.");
                    }
                    break;
                case DialogResult.No:
                    break;
            }

        }

        private void btnBorrarRegimen_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Estás seguro de querer borrar el registro?",
                     "Mood Test", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    try
                    {
                        conexion.openConection();

                        string query = "DELETE FROM regimenes  WHERE codregimen=@codregimen";
                        SqlCommand sqlCommand = new SqlCommand(query, conexion.getConexion());

                        int rowindex = dgvRegimenes.CurrentCell.RowIndex;

                        string codregimen =dgvRegimenes.Rows[rowindex].Cells[0].Value.ToString();
                        sqlCommand.Parameters.AddWithValue("@codregimen", codregimen);

                        sqlCommand.ExecuteNonQuery();

                        dgvRegimenes.DataSource = visualizar.visualizarRegimenes();

                        dgvRegimenes.Refresh();
                        conexion.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("A ocurrido un error de claves, este registro no se puede eliminar.");
                    }
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void onClickClientes(object sender, EventArgs e)
        {
            try
            {
                //Recogemos el click que a hecho el usuario sobre la fila (registro)
                int rowindex = dgvClientes.CurrentCell.RowIndex;
                //Sabiendo la posición del índice donde el usuario a hecho click, recogemos los valores de las respectivas columnas
                //Y los seteamos a los textBox
                string coddnionie = dgvClientes.Rows[rowindex].Cells[0].Value.ToString();
                string nombre = dgvClientes.Rows[rowindex].Cells[1].Value.ToString();
                string nacionalidad = dgvClientes.Rows[rowindex].Cells[2].Value.ToString();

                txtCoddnionieClientes.Text = coddnionie;
                txtNombreClientes.Text = nombre;
                txtNacionalidadClientes.Text = nacionalidad;
            }
            catch (Exception ignored) { }
        }

        private void dgvEstancias_Click(object sender, EventArgs e)
        {
            try
            {
                int rowindex = dgvEstancias.CurrentCell.RowIndex;

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

                txtCodestanciaEstancias.Text = codestancia;
                txtCoddnionieEstancias.Text = coddnionie;
                txtCodHotelEstancias.Text = codhotel;
                txtNumHabitacionEstancias.Text = numhabitacion;
                txtFechaInicioEstancias.Text = fechaInicio;
                txtFechaFinEstancias.Text = fechaFin;
                txtCodregimenEstancias.Text = codregimen;
                txtOcupantesEstancias.Text = ocupantes;
                txtPrecioestanciaEstancias.Text = precioestancia;
                chkPagadoEstancias.Checked = Convert.ToBoolean(pagado.ToLower());
            }
            catch (Exception ignored) { }
        }

        private void dgvHabitaciones_Click(object sender, EventArgs e)
        {
            try
            {
                int rowindex = dgvHabitaciones.CurrentCell.RowIndex;

                string codhotel = dgvHabitaciones.Rows[rowindex].Cells[0].Value.ToString();
                string numhabitacion = dgvHabitaciones.Rows[rowindex].Cells[1].Value.ToString();
                string capacidad = dgvHabitaciones.Rows[rowindex].Cells[2].Value.ToString();
                string preciodia = dgvHabitaciones.Rows[rowindex].Cells[3].Value.ToString();
                string activa = dgvHabitaciones.Rows[rowindex].Cells[4].Value.ToString();


                txtCodHotelHabitaciones.Text = codhotel;
                txtNumHabitacionHabitaciones.Text = numhabitacion;
                txtCapacidadHabitaciones.Text = capacidad;
                txtPreciodiaHabitaciones.Text = preciodia;
                chkActivaHabitaciones.Checked = Convert.ToBoolean(activa.ToLower());
            }
            catch (Exception ignored) { }
        }

        private void dgvRegimenes_Click(object sender, EventArgs e)
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
    }
}

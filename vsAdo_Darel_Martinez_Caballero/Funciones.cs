using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SQLMicrosfPROYECTO
{
    public partial class Funciones : Form
    {
        private Conexion conexion = new Conexion();
        
        public Funciones()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFuncSumaTotalEstancias_Click(object sender, EventArgs e)
        {
            //Abrimos la conexión
             conexion.openConection();
             
            //Instanciamos un objeto DataTable();
            var dt = new DataTable();
            
            //Enlazamos el DataGridView con el dataTable
            dgvFuncSumaTotalEstancias.DataSource = dt;
            
            //Instanciamos un objeto SqlCommand  y creamos la sentencia de la siguiente forma: 
            var query = new SqlCommand("select dbo.sumaTotalEstancias(@coddni)", conexion.getConexion());
            
            //Instanciamos un objeto SqlDataAdapter y le pasamos el objeto SqlCommand
            var sqlDataAdapter = new SqlDataAdapter(query);
            
            //Añadimos los parámetros de entrada
            query.Parameters.AddWithValue("@coddni", SqlDbType.Char).Value =
                txtCoddnionie.Text;
            
            //Recogemos los datos y se los pasamos al adaptador
            sqlDataAdapter.Fill(dt);
            
            //Le ponemos un nombre a la cabecera
            dgvFuncSumaTotalEstancias.Columns[0].HeaderText = "Suma total";
        }
    }
}
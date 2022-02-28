using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLMicrosfPROYECTO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            Visualizar visualizar = new Visualizar();
            visualizar.Show();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Borrar borrar = new Borrar();
            borrar.Show();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Insertar insertar = new Insertar();
            insertar.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Actualizar actualizar = new Actualizar();
            actualizar.Show();
        }

        private void btnCombobox_Click(object sender, EventArgs e)
        {
            Combobox combobox = new Combobox();
            combobox.Show();
        }

        private void btnProcedimientos_Click(object sender, EventArgs e)
        {
            Procedimientos procedimientos = new Procedimientos();
            procedimientos.Show();
        }

        private void btnFunciones_Click(object sender, EventArgs e)
        {
            Funciones funciones = new Funciones();
            funciones.Show();
        }
    }
}

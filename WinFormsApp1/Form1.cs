namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var lista = ClasesEjercicioPrueba.Repository.VehiculoRepository.ObtenerTodos();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string marca = textBox1.Text;
            string modelo = textBox2.Text;
            string anioTexto = textBox3.Text;

            int anio;
            if (!int.TryParse(anioTexto, out anio))
            {
                MessageBox.Show("Año debe ser un número");
                return;
            }

            var v = new ClasesEjercicioPrueba.Models.Vehiculo(marca, modelo, anio);
            ClasesEjercicioPrueba.Repository.VehiculoRepository.Agregar(v);

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            MessageBox.Show("Guardado");
        }
    }
}

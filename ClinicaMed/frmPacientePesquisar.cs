using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model;

namespace ClinicaMed
{
    public partial class frmPacientePesquisar : Form
    {
        public frmPacientePesquisar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txtNascimento.MaxDate = DateTime.Today;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Paciente item = new Paciente();

            item.Nome = txtNome.Text.Trim();
            item.Telefone = txtTelefone.Text.Trim();

            try
            {
                List<Paciente> lista = PacienteController.Pesquisar(item);
                dataGridView1.DataSource = lista;
            }
            catch
            {
                MessageBox.Show("Erro na consulta dos dados");
            }
        }
    }
}

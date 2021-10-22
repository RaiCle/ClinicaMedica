using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaMed
{
    public partial class frmMedicoPesquisar : Form
    {
        public frmMedicoPesquisar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Medico item = new Medico();

            item.Nome = txtNome.Text.Trim();
            item.CRM = txtCRM.Text.Trim();

            try
            {
                List<Medico> lista = MedicoController.Pesquisar(item);
                dataGridView1.DataSource = lista;
            }
            catch
            {
                MessageBox.Show("Erro na consulta dos dados");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void medicoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}

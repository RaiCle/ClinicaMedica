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
    public partial class frmPacienteInserir : Form
    {
        public frmPacienteInserir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            txtNome.Text = txtNome.Text.Trim();
            txtTelefone.Text = txtTelefone.Text.Trim();

            bool erro = false;

            if (txtNome.Text == "" || txtNome.Text.Length > 100)
            {
                errorProvider1.SetError(txtNome, "Valor inválido");
                erro = true;
            }

            if(txtTelefone.Text == "" || txtTelefone.Text.Length > 11)
            {
                errorProvider1.SetError(txtTelefone, "Valor inválido");
                erro = true;
            }

            if (erro)
                return;

            Paciente item = new Paciente();
            item.Nome = txtNome.Text;
            item.Telefone = txtTelefone.Text.Trim(); //validar
            item.DataNascimento = txtNascimento.Value;

            try
            {
                PacienteController.Inserir(item);
                MessageBox.Show("Paciente cadastrado com sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPacienteInserir_Load(object sender, EventArgs e)
        {
            txtNascimento.MaxDate = DateTime.Today;
        }
    }
}

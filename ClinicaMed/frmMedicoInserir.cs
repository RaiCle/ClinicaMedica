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
    public partial class frmMedicoInserir : Form
    {
        public frmMedicoInserir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            Medico item = new Medico();
            item.Nome = txtNome.Text;
            item.CRM = txtCRM.Text;

            //todo: validar nome

            if(item.CRM == "" || item.CRM.Length > 50)
            {
                errorProvider1.SetError(txtCRM, "CRM Inválido");
                return;
            }

            try
            {
                MedicoController.Inserir(item);
                MessageBox.Show("Médico inserido com sucesso");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class PacienteController
    {
        public static void Inserir(Paciente item)
        {
            item.Nome = item.Nome.Trim();
            item.Telefone = item.Telefone.Trim();

            if(item.Nome == "" || item.Nome.Length > 100)
            {
                throw new Exception("Nome inválido");
            }

            if(item.Telefone == "" || item.Telefone.Length > 11)
            {
                throw new Exception("Telefone inválido");
            }
            
            if(item.DataNascimento > DateTime.Today)
            {
                throw new Exception("Data inválida");
            }

            PacienteDAO.Inserir(item);
        }
        public static List<Paciente> Pesquisar(Paciente item)
        {
            return PacienteDAO.Pesquisar(item);
        }
    }
   
}

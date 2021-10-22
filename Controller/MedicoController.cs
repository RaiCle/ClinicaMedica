using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public static class MedicoController
    {
        public static void Inserir(Medico item)
        {
            if (item.Nome == null || item.Nome.Trim() == "" || item.Nome.Length > 100)
                throw new Exception("Nome inválido");

            if (item.CRM == null || item.CRM.Trim() == "" || item.CRM.Length > 50)
                throw new Exception("CRM inválido");

            //todo: verificar no SGBD se há um médico cadastrado com o CRM informado
            Medico pesquisa = new Medico { CRM = item.CRM, Nome = "" };
            List<Medico> lista = Pesquisar(pesquisa);

            if(lista != null && lista.Count > 0)
            {
                throw new Exception("Já existe médico cadastrado com o CRM informado");
            }

            MedicoDAO.Inserir(item);
        }

        public static List<Medico> Pesquisar(Medico item)
        {
            return MedicoDAO.Pesquisar(item);
        }
    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class MedicoDAO
    {
        public static void Inserir(Medico item)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = Configuracao.ConnectionString;

            try
            {
                conexao.Open();
            }
            catch
            {
                throw new Exception("Erro na conexão com o banco de dados");
            }

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = " INSERT INTO TBMedico(Nome, CRM) Values(@Nome, @CRM) ";

            SqlParameter param = new SqlParameter("@Nome", System.Data.SqlDbType.VarChar);
            param.Value = item.Nome;
            comando.Parameters.Add(param);

            param = new SqlParameter("@CRM", System.Data.SqlDbType.VarChar);
            param.Value = item.CRM;
            comando.Parameters.Add(param);

            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Erro na execução da consulta");
            }
            finally
            {
                conexao.Close();
            }
        }

        public static List<Medico> Pesquisar(Medico item)
        {
            List<Medico> retorno = null;

            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = Configuracao.ConnectionString;

            try
            {
                conexao.Open();
            }
            catch
            {
                throw new Exception("Erro na conexão com o banco de dados");
            }

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = " SELECT ID, CRM, Nome from TBMedico WHERE 1=1 ";

            if(item.CRM != "")
            {
                comando.CommandText += " AND CRM = @CRM ";

                SqlParameter param = new SqlParameter("@CRM", System.Data.SqlDbType.VarChar);
                param.Value = item.CRM;
                comando.Parameters.Add(param);
            }

            if(item.Nome != "")
            {
                comando.CommandText += " AND NOME LIKE @NOME ";

                SqlParameter param = new SqlParameter("@NOME", System.Data.SqlDbType.VarChar);
                param.Value = "%" + item.Nome + "%";
                comando.Parameters.Add(param);
            }

            comando.CommandText += " ORDER BY Nome ";

            SqlDataReader reader = null;

            try
            {
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (retorno == null)
                        retorno = new List<Medico>();

                    Medico medico = new Medico();

                    medico.Id = (int?)reader["ID"];
                    medico.CRM = reader["CRM"].ToString();
                    medico.Nome = reader["Nome"].ToString();

                    retorno.Add(medico);
                }
            }
            catch
            {
                throw new Exception("Erro na execução da consulta");
            }
            finally
            {
                reader.Close();
                conexao.Close();
            }

            return retorno;
        }
    }
}

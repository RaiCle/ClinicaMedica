using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PacienteDAO
    {
        public static void Inserir(Paciente item)
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
            comando.CommandText = " INSERT INTO TBPaciente(Nome, Telefone, DataNascimento) Values(@Nome, @Telefone, @DataNascimento) ";

            SqlParameter param = new SqlParameter("@Nome", System.Data.SqlDbType.VarChar);
            param.Value = item.Nome;
            comando.Parameters.Add(param);

            param = new SqlParameter("@Telefone", System.Data.SqlDbType.VarChar);
            param.Value = item.Telefone;
            comando.Parameters.Add(param);

            param = new SqlParameter("@DataNascimento", System.Data.SqlDbType.DateTime);
            param.Value = item.DataNascimento;
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
        public static List<Paciente> Pesquisar(Paciente item)
        {
            List<Paciente> retorno = null;

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
            comando.CommandText = " SELECT ID, Nome, Telefone, DataNascimento from TBPaciente WHERE 1=1 ";

            if (item.Nome != "")
            {
                comando.CommandText += " AND Nome LIKE @Nome ";

                SqlParameter param = new SqlParameter("@Nome", System.Data.SqlDbType.VarChar);
                param.Value = "%" + item.Nome + "%";
                comando.Parameters.Add(param);
            }

            if (item.Telefone != "")
            {
                comando.CommandText += " AND Telefone LIKE @Telefone ";

                SqlParameter param = new SqlParameter("@Telefone", System.Data.SqlDbType.VarChar);
                param.Value = item.Telefone ;
                comando.Parameters.Add(param);
            }


            if (item.DataNascimento < DateTime.Today )
            {

                comando.CommandText += " AND DataNascimento LIKE @DataNascimento ";

                SqlParameter param = new SqlParameter("@DataNascimento", System.Data.SqlDbType.DateTime);
                param.Value = item.DataNascimento;
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
                        retorno = new List<Paciente>();

                    Paciente paciente = new Paciente();

                    paciente.ID = (int?)reader["ID"];
                    paciente.Nome = reader["Nome"].ToString();
                    paciente.Telefone = reader["Telefone"].ToString();
                    paciente.DataNascimento = (DateTime)reader["DataNascimento"];

                    retorno.Add(paciente);
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

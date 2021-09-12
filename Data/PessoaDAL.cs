using LuizHenriqueTesteConfirp.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LuizHenriqueTesteConfirp.Data
{
    public class PessoaDAL
    {

        string conectionString = "Data Source=DESKTOP-9UFE5KR\\SQLEXPRESS;Initial Catalog=TesteConfirpBD;Integrated Security=True";




        public Pessoa GetPessoa( int Id)
        {
            Pessoa pessoa = new Pessoa();
            Sexo sexo = new Sexo();

            using (SqlConnection con = new SqlConnection(conectionString))
            {
                string comando = " SELECT p.IdPessoa,p.Nome,p.Sobrenome,p.Cpf,p.Rg,p.DataNascimento,p.Email,p.IdSexo,s.Descricao" +
                    " FROM Pessoa p" +
                    " INNER JOIN Sexo s ON p.IdSexo = s.IdSexo" +
                    " WHERE IdPessoa = @IdPessoa";
                    

                SqlCommand cmd = new SqlCommand(comando, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@IdPessoa", Id);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {         
                    
                    pessoa.IdPessoa = Convert.ToInt32(reader["IdPessoa"]);
                    pessoa.Nome = Convert.ToString(reader["Nome"]);
                    pessoa.Sobrenome = Convert.ToString(reader["Sobrenome"]);
                    pessoa.Cpf = Convert.ToString(reader["Cpf"]);                   
                    pessoa.Rg = Convert.ToString(reader["Rg"]);
                    pessoa.DataNascimento = Convert.ToDateTime(reader["DataNascimento"]);
                    pessoa.Email = Convert.ToString(reader["Email"]);
                    sexo.IdSexo = Convert.ToInt32(reader["IdSexo"]);
                    sexo.Descricao = Convert.ToString(reader["Descricao"]);

                    pessoa.Sexo = sexo;
                }

                con.Close();
            }
            return pessoa;
        }

        public List<Pessoa> GetPessoas()
        {
            List<Pessoa> lstPessoas = new List<Pessoa>();

            using (SqlConnection con = new SqlConnection(conectionString))
            {
                string comando = " SELECT p.IdPessoa,p.Nome,p.Sobrenome,p.Cpf,p.Rg,p.DataNascimento,p.Email,p.IdSexo,s.Descricao" +
                    " FROM Pessoa p" +
                    " INNER JOIN Sexo s ON p.IdSexo = s.IdSexo";
                    
                SqlCommand cmd = new SqlCommand(comando, con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Pessoa pessoa = new Pessoa();
                    Sexo sexo = new Sexo();
                    pessoa.IdPessoa = Convert.ToInt32(reader["IdPessoa"]);
                    pessoa.Nome = Convert.ToString(reader["Nome"]);
                    pessoa.Sobrenome = Convert.ToString(reader["Sobrenome"]);
                    pessoa.Cpf = Convert.ToString(reader["Cpf"]);                   
                    pessoa.Rg = Convert.ToString(reader["Rg"]);
                    pessoa.DataNascimento = Convert.ToDateTime(reader["DataNascimento"]);
                    pessoa.Email = Convert.ToString(reader["Email"]);
                    sexo.IdSexo = Convert.ToInt32(reader["IdSexo"]);
                    sexo.Descricao = Convert.ToString(reader["Descricao"]);

                    lstPessoas.Add(pessoa);

                }

                con.Close();

            }
            return lstPessoas;
        }

        public void AddPessoa(Pessoa pessoa)
        {
            using (SqlConnection con = new SqlConnection(conectionString))
            {
                string comando = "INSERT INTO Pessoa (Nome,Sobrenome,Cpf,IdSexo,Rg,DataNascimento,Email)" +
                    " VALUES (@Nome,@Sobrenome,@Cpf,@IdSexo,@Rg,@DataNascimento,@Email) ";

                SqlCommand cmd = new SqlCommand(comando, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Nome", pessoa.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", pessoa.Sobrenome);
                cmd.Parameters.AddWithValue("@Cpf", pessoa.Cpf);
                cmd.Parameters.AddWithValue("@IdSexo", pessoa.Sexo.IdSexo);
                cmd.Parameters.AddWithValue("@Rg", pessoa.Rg);
                cmd.Parameters.AddWithValue("@DataNascimento", pessoa.DataNascimento);
                cmd.Parameters.AddWithValue("@Email", pessoa.Email);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdatePessoa(Pessoa pessoa)
        {
            using (SqlConnection con = new SqlConnection(conectionString))
            {
                string comando = "UPDATE Pessoa SET Nome = @Nome," +
                    " Sobrenome = @Sobrenome," +
                    " Cpf = @Cpf," +
                    " IdSexo = @IdSexo," +
                    " Rg = @Rg, " +
                    " DataNascimento = @DataNascimento," +
                    " Email = @Email" +
                    " WHERE IdPessoa = @IdPessoa"
                    ;

                SqlCommand cmd = new SqlCommand(comando, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Nome", pessoa.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", pessoa.Sobrenome);
                cmd.Parameters.AddWithValue("@Cpf", pessoa.Cpf);
                cmd.Parameters.AddWithValue("@IdSexo", pessoa.Sexo.IdSexo);
                cmd.Parameters.AddWithValue("@Rg", pessoa.Rg);
                cmd.Parameters.AddWithValue("@DataNascimento", pessoa.DataNascimento);
                cmd.Parameters.AddWithValue("@Email", pessoa.Email);
                cmd.Parameters.AddWithValue("@IdPessoa", pessoa.IdPessoa);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeletePessoa(int id)
        {
            using (SqlConnection con = new SqlConnection(conectionString))
            {
                string comando = "DELETE FROM Pessoa WHERE IdPessoa = @IdPessoa";
                    

                SqlCommand cmd = new SqlCommand(comando, con);
                cmd.CommandType = CommandType.Text;

      
                cmd.Parameters.AddWithValue("@IdPessoa", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}

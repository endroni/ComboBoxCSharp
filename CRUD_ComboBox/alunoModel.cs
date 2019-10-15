using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_ComboBox
{
    public class alunoModel : IDisposable
    {
        private static SqlConnection sqlConnection;
        private static string sqlConnectionString;
        public alunoModel()
        { }
        private static string DbConnectionString()
        {
            sqlConnectionString = ConfigurationManager.ConnectionStrings["CRUD_ComboBox.Properties.Settings.banco"].ConnectionString;
            return sqlConnectionString;
        }
        private static SqlConnection DbConnection()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CRUD_ComboBox.Properties.Settings.banco"].ConnectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
        public static DataTable GetAlunos()
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM alunos";
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAlunoTabela(int id)
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM alunos Where id_aluno=" + id;
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static alunoEnt GetAluno(int id)
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            alunoEnt aluno = new alunoEnt();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM alunos Where id_aluno=" + id;
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    aluno.IdAluno = Convert.ToInt32(dt.Rows[0]["id_aluno"]);
                    aluno.Nome = dt.Rows[0]["Nome"].ToString();
                    aluno.Endereco = dt.Rows[0]["Endereco"].ToString();
                    aluno.Email = dt.Rows[0]["Email"].ToString();
                    aluno.Telefone = dt.Rows[0]["Telefone"].ToString();
                    return aluno;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Add(alunoEnt aluno)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO alunos(Nome, Endereco,Email,Telefone ) values(@nome, @endereco, @email, @telefone)";
                    cmd.Parameters.AddWithValue("@nome", aluno.Nome);
                    cmd.Parameters.AddWithValue("@endereco", aluno.Endereco);
                    cmd.Parameters.AddWithValue("@email", aluno.Email);
                    cmd.Parameters.AddWithValue("@telefone", aluno.Telefone);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Update (alunoEnt aluno)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    if (aluno != null)
                    {
                        cmd.CommandText = "UPDATE alunos SET Nome=@Nome,Email=@Email,Endereco=@Endereco,Telefone = @Telefone WHERE id_aluno = @Id";
                        cmd.Parameters.AddWithValue("@Id", aluno.IdAluno);
                        cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
                        cmd.Parameters.AddWithValue("@Endereco", aluno.Endereco);
                        cmd.Parameters.AddWithValue("@Email", aluno.Email);
                        cmd.Parameters.AddWithValue("@Telefone", aluno.Telefone);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Delete(int Id)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM alunos Where id_aluno=@Id";
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

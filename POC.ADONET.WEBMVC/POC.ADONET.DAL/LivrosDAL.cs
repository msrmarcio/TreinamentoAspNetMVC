using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.ADONET.MODELS;
using System.Data.SqlClient;

namespace POC.ADONET.DAL
{
    public class LivrosDAL
    {
        Repository repoDB;
        //string stringConexao = "Data Source=3P47_INSTRUTOR;Initial Catalog=pubs;User ID=sa;Password=Imp@ct@";
        string stringConexao = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pubs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        private void CriarInstanciaRepositorioDB()
        {
            if (repoDB == null)
            {
                // se não ha, cria uma
                repoDB = new Repository();

                // adiciona a string conexao
                repoDB.Conn.ConnectionString = stringConexao;

                // atribuimos a SqlConnection
                repoDB.Cmd.Connection = repoDB.Conn;
            }
        }

        public List<LivroMOD> GetBooks()
        {
            SqlDataReader dataReader = null;
            List<LivroMOD> listaLivros = new List<LivroMOD>();

            try
            {
                // cria conexao
                CriarInstanciaRepositorioDB();

                // vamos montar o comando de SQL
                repoDB.Cmd.CommandText = @"SELECT * FROM TITLES ORDER BY Title";

                // abre conexao com BD
                if (repoDB.OpenConnection())
                {
                    LivroMOD livro;
                    dataReader = repoDB.Cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        livro = new LivroMOD();
                        livro.Id = dataReader["title_id"].ToString();
                        livro.Titulo = dataReader["title"].ToString();
                        livro.Tipo = dataReader["type"].ToString();
                        livro.Preco = dataReader["price"] == System.DBNull.Value ? 0 : Convert.ToDecimal(dataReader["price"]);
                        livro.Resenha = dataReader["notes"].ToString();

                        // adiciona na lista
                        listaLivros.Add(livro);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dataReader.Close();
                repoDB.CloseConnection();
            }

            return listaLivros;
        }

        public bool UpdateBook(LivroMOD livro)
        {
            // criar variavel de retorno
            int retorno = 0;

            try
            {
                // verifica se ha uma  instancia valida de sqlconnection e SqlCommand
                CriarInstanciaRepositorioDB();

                // montar o comando SQL
                repoDB.Cmd.CommandText = @"UPDATE Titles SET title=@titulo, type=@tipo, price=@preco, notes=@resenha WHERE title_id=@bookId";
                 
                // substitui os valores dos parametros
                repoDB.Cmd.Parameters.AddWithValue("@bookId", livro.Id);
                repoDB.Cmd.Parameters.AddWithValue("@titulo", livro.Titulo);
                repoDB.Cmd.Parameters.AddWithValue("@tipo", livro.Tipo);
                repoDB.Cmd.Parameters.AddWithValue("@preco", livro.Preco);
                repoDB.Cmd.Parameters.AddWithValue("@resenha", livro.Resenha);
                
                // abrir a conexao com DB
                if (repoDB.OpenConnection())
                {
                    // Vamos executar o comando Insert na Base de dados
                    // ExecuteNonQuery ele retorna o numero de linhas afetadas
                    retorno = repoDB.Cmd.ExecuteNonQuery(); 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                repoDB.CloseConnection();
            }

            return (retorno > 0);
        }        

        public bool DeleteBookById(string id)
        {
            // criar variavel de retorno
            int retorno = 0;

            try
            {
                // verifica se ha uma  instancia valida de sqlconnection e SqlCommand
                CriarInstanciaRepositorioDB();

                // montar o comando SQL  - DELETE FROM table_name WHERE condition;
                repoDB.Cmd.CommandText = @"DELETE FROM Titles WHERE title_id=@bookId";

                // substitui os valores dos parametros
                repoDB.Cmd.Parameters.AddWithValue("@bookId", id); 

                // abrir a conexao com DB
                if (repoDB.OpenConnection())
                {
                    // Vamos executar o comando Insert na Base de dados
                    // ExecuteNonQuery ele retorna o numero de linhas afetadas
                    retorno = repoDB.Cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                repoDB.CloseConnection();
            }

            return retorno > 0;
        }

        public LivroMOD GetBooksById(string id)
        {
            SqlDataReader dataReader = null;
            LivroMOD livro = null;

            try
            {
                // cria conexao
                CriarInstanciaRepositorioDB();

                // vamos montar o comando de SQL
                repoDB.Cmd.CommandText = @"SELECT * FROM TITLES WHERE title_id = @id";
                
                // substitui os valores dos parametros
                repoDB.Cmd.Parameters.AddWithValue("@id", id);

                if (repoDB.OpenConnection())
                {
                    dataReader = repoDB.Cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        livro = new LivroMOD();
                        livro.Id = dataReader["title_id"].ToString();
                        livro.Titulo = dataReader["title"].ToString();
                        livro.Tipo = dataReader["type"].ToString();
                        // No C# valores nulo é igual a null
                        // no SqlServer nulo é datatype igual a DbNull
                        // fizemos um tratamento, p/ qdo retornar DbNull, 
                        // insira 0 e qdo diferente converta para Decimal
                        livro.Preco = dataReader["price"] == System.DBNull.Value ? 0 : Convert.ToDecimal(dataReader["price"]);
                        livro.Resenha = dataReader["notes"].ToString();
                    }
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataReader.Close();
                repoDB.CloseConnection();
            }

            return livro;
        }
    }
}

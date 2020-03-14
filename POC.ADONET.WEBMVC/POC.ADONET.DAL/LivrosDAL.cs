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
        string stringConexao = "Data Source=3P47_INSTRUTOR;Initial Catalog=pubs;User ID=sa;Password=Imp@ct@";

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
                    LivroMOD livro = new LivroMOD();
                    dataReader = repoDB.Cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        livro.Id = dataReader["title_id"].ToString();
                        livro.Titulo = dataReader["title"].ToString();
                        livro.Tipo = dataReader["type"].ToString();
                        // var preco = dataReader["price"];
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
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.ADONET.MODELS;

namespace POC.ADONET.DAL
{
    public class ClienteDAL
    {
        Repository repoDB;
        string stringConexao = "Data Source=3P47_INSTRUTOR;Initial Catalog=LIVRARIA;User ID=sa;Password=Imp@ct@";

        public bool Add(string nome, string email, string observacao = "")
        {
            // criar variavel de retorno
            int retorno = 0;

            try
            {

                // verifica se ha uma  instancia valida de sqlconnection e SqlCommand
                CriarInstanciaRepositorioDB();

                // vamos atribuir ums string de conexao
                repoDB.Conn.ConnectionString = "Data Source=3P47_INSTRUTOR;Initial Catalog=LIVRARIA;User ID=sa;Password=Imp@ct@";

                // montar o comando SQL
                repoDB.Cmd.CommandText = @"INSERT INTO Cliente(NOME, EMAIL, OBSERVACAO) VALUES (@nome, @email, @observacao)";

                // substitui os valores dos parametros
                repoDB.Cmd.Parameters.AddWithValue("@nome", nome);
                repoDB.Cmd.Parameters.AddWithValue("@email", email);
                repoDB.Cmd.Parameters.AddWithValue("@observacao", observacao);

                // vamos atribuir para a propriedade connection do comando o objeto SqlConnection ja instanciado
                repoDB.Cmd.Connection = repoDB.Conn;

                // abrir a conexao com DB
                if (repoDB.OpenConnection())
                {
                    // Vamos executar o comando Insert na Base de dados
                    // ExecuteNonQuery ele retorna o numero de linhas afetadas
                    retorno = repoDB.Cmd.ExecuteNonQuery();

                    // if ternario para retornar o resultado verdadeiro ou8 falso para insercao
                    // Se retorno for maior que zero, entao retorna true;
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

            return (retorno > 0 ? true : false);
        }

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

        public bool DeleteById(int id)
        {
            int retorno = 0;

            try
            {
                // criar instancia do Repository
                CriarInstanciaRepositorioDB();

                repoDB.Cmd.CommandText = "DELETE CLIENTE WHERE Id = @clienteId";

                // substitui o parametro
                repoDB.Cmd.Parameters.AddWithValue("@clienteId", id);

                if (repoDB.OpenConnection())
                {
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

        public bool Update(ClienteMOD cliente, int Id = 0)
        {
            // variavel de retorno
            int retorno = 0;

            try
            {
                // criar instancia de RepoDB
                CriarInstanciaRepositorioDB();

                // criar a QUERY de UPDATE
                repoDB.Cmd.CommandText =
                    @"UPDATE Cliente SET Nome=@Nome, Email=@Email, Observacao=@Observacao WHERE Id=@clienteId";

                // faz a troca dos parametros
                repoDB.Cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                repoDB.Cmd.Parameters.AddWithValue("@email", cliente.Email);
                repoDB.Cmd.Parameters.AddWithValue("@observacao", cliente.Observacao);
                repoDB.Cmd.Parameters.AddWithValue("@clienteId", cliente.Id);

                // abrir conexao com banco de dados
                if (repoDB.OpenConnection())
                {
                    retorno = repoDB.Cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                // sempre executado o bloco finally
                repoDB.CloseConnection();
            }

            // se numero de linhas alteradas for igua a zero, quer dizer que nao foi alterado
            //return retorno == 0 ? false : true;
            return retorno >= 1;
        }

        public List<ClienteMOD> SelectAll()
        {
            // variavel para capturar o retorno do select
            var lista = new List<ClienteMOD>();

            try
            {
                // objeto do tipo ClienteMOD
                var cliente = new ClienteMOD();

                // criar instancia RepoDB
                CriarInstanciaRepositorioDB();

                repoDB.Cmd.CommandText = "SELECT * FROM CLIENTE";

                // abrimos a conexao com BD
                if (repoDB.OpenConnection())
                {
                    SqlDataReader resultadoSelect = repoDB.Cmd.ExecuteReader();

                    //Método Read() lê um registro por vez e retorna true se existem dados
                    while (resultadoSelect.Read())
                    {
                        //Para obter os dados, a propriedade [this] do DataReader é utilizada
                        // como tudo que é retornado pelo ExecuteReader sao objetos, precisamos converter
                        // para os respectivos tipos
                        cliente.Id = (int)resultadoSelect["Id"]; // Cast para Int32
                        cliente.Nome = resultadoSelect["Nome"].ToString();
                        cliente.Email = resultadoSelect["Email"].ToString();
                        cliente.Observacao = resultadoSelect["Observacao"].ToString();

                        //adiciona na lista
                        lista.Add(cliente);
                    }

                    // Fecha e deixa disponivel para leitura ou exclusao pelo GC (garbage collection)
                    resultadoSelect.Close();
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

            // precisamos devolver o resultado do select para as demais camadas do projeto
            return lista;
        }

        public ClienteMOD SelectByID(int id)
        {
            // objeto do tipo ClienteMOD
            var cliente = new ClienteMOD();
            try
            {
                // criar instancia RepoDB
                CriarInstanciaRepositorioDB();

                repoDB.Cmd.CommandText = "SELECT * FROM Cliente WHERE Id = @id";

                // Substitui o parametro 
                repoDB.Cmd.Parameters.AddWithValue("@id", id);

                // abrimos a conexao com BD
                if (repoDB.OpenConnection())
                {
                    SqlDataReader resultadoSelect = repoDB.Cmd.ExecuteReader();

                    //Método Read() lê um registro por vez e retorna true se existem dados
                    while (resultadoSelect.Read())
                    {
                        //Para obter os dados, a propriedade [this] do DataReader é utilizada
                        // como tudo que é retornado pelo ExecuteReader sao objetos, precisamos converter
                        // para os respectivos tipos
                        cliente.Id = (int)resultadoSelect["Id"]; // Cast para Int32
                        cliente.Nome = resultadoSelect["Nome"].ToString();
                        cliente.Email = resultadoSelect["Email"].ToString();
                        cliente.Observacao = resultadoSelect["Observacao"].ToString();
                    }

                    // Fecha e deixa disponivel para leitura ou exclusao pelo GC (garbage collection)
                    resultadoSelect.Close();
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

            // precisamos devolver o resultado do select para as demais camadas do projeto
            return cliente;
        }
    }
}

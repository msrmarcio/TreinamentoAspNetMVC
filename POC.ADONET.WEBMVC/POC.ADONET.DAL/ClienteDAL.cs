using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.ADONET.DAL
{
    public class ClienteDAL
    {
        Repository repoDB;

        public bool Add(string nome, string email, string observacao = "")
        {
            // verifica se ha uma  instancia valida de sqlconnection e SqlCommand
            if (repoDB == null)
            {
                // se não ha, cria uma
                repoDB = new Repository();
            }

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

            // criar variavel de retorno
            int retorno = 0;

            // abrir a conexao com DB
            if (repoDB.OpenConnection())
            {
                // Vamos executar o comando Insert na Base de dados
                // ExecuteNonQuery ele retorna o numero de linhas afetadas
                retorno = repoDB.Cmd.ExecuteNonQuery();

                // if ternario para retornar o resultado verdadeiro ou8 falso para insercao
                // Se retorno for maior que zero, entao retorna true;
            }

            return (retorno > 0 ? true : false);
        }
    }
}

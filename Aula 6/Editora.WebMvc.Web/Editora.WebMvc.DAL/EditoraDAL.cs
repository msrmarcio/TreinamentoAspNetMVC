using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editora.WebMvc.DAL
{
    public class EditoraDAL
    {
        public void Create(string Nome)
        {
            string insere = @"INSERT INTO EDITORAS (Nome, Email) VALUES(?, ?)";

            using (SqlConnection sqlConn = FactoryConnection.CreateConnection())
            {
                SqlCommand command = new SqlCommand(insere, sqlConn);

                command.Parameters.AddWithValue("@Nome", Nome);

                sqlConn.Open();
                command.ExecuteNonQuery();

            }
        }
    }
}

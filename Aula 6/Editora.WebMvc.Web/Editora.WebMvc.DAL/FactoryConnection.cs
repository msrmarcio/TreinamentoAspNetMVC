using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editora.WebMvc.DAL
{
    public static class FactoryConnection
    {
        public static SqlConnection CreateConnection()
        {
            string servidor = @"";
            string baseDados = @"";
            string usuario = @"";
            string senha = @"";

            // concatenar string
            StringBuilder connectionString = new StringBuilder();
            connectionString.Append("server=");
            connectionString.Append(servidor);
            connectionString.Append(";database=");
            connectionString.Append(baseDados);
            connectionString.Append(";User Id=");
            connectionString.Append(usuario);
            connectionString.Append(";Password=");
            connectionString.Append(senha);

            return new SqlConnection(connectionString.ToString());

        }
    }
}

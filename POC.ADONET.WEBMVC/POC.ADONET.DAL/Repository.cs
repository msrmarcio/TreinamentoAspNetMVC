using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// adiciona os namespace do banco de dados
using System.Data.SqlClient;
using System.Data;

namespace POC.ADONET.DAL
{
    public class Repository
    {
        // objeto de conexao e command
        public SqlCommand Cmd { get; set; }
        public SqlConnection Conn { get; set; }

        public Repository()
        {
            Conn = new SqlConnection();
            Cmd = new SqlCommand();
        }

        public bool OpenConnection()
        {
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CloseConnection()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }
    }
}

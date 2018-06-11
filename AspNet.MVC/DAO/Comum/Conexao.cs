using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AspNet.MVC.DAO.Comum
{
    public class Conexao
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public SqlConnection Connection = new SqlConnection(ConnectionString);

        public void Conectar()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }

        public void Desconectar()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}
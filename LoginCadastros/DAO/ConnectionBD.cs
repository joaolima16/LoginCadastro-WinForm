
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LoginCadastros.DAO
{
    public class ConnectionBD
    {
      
    public static SqlConnection Conexao()
        {
            string str_Conn = @"Data Source=DESKTOP-37MVHN7\SQLSERVER;Initial Catalog=LoginTest;Integrated Security=True";
            SqlConnection conn = new SqlConnection(str_Conn);
      
            return conn; 
        }
        public void Crud(SqlCommand comando)
        {
            SqlConnection conn = Conexao();
            comando.Connection = conn;
            conn.Open();
             comando.ExecuteNonQuery();
            conn.Close();
        }
        public SqlDataReader Select(SqlCommand comando)
        {

            SqlConnection conn = Conexao();
            conn.Open();
            comando.Connection = conn;
            SqlDataReader dr = comando.ExecuteReader();
            return dr;

        }

    }
}

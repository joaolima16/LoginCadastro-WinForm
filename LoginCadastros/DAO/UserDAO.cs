
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LoginCadastros.DAO
{
    public class UserDAO
    {

        public string Error { get; set; }
        public string Validation { get; set; }
        ConnectionBD connection = new ConnectionBD();
        public void Insert(string user , string password, string email, byte[] Picture)
        {

            try
            {

                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO users(usuario,senha,email,image) VALUES (@usuario,@senha,@email,@image)";
                comando.Parameters.AddWithValue("@usuario", user);
                comando.Parameters.AddWithValue("@senha", password);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@image", Picture);
                connection.Crud(comando);
                Error = "Usuário Cadastrado";
            }
            catch (Exception ex)
            {

                Error = "Usuário não cadastrado:" + ex.Message;
            }
           
        }
        public void Select(string user, string pass, byte[] Picture)
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select  usuario,senha from users where usuario=@user and senha=@senha";
                comando.Parameters.AddWithValue("@user", user);
                comando.Parameters.AddWithValue("@senha", pass);
              comando.Parameters.AddWithValue("@image", Picture);
                var dr = connection.Select(comando);
                if (dr.Read())
                {
                    Validation = "Usuário Logado";
                }
                else
                {
                    Validation = "Login não realizado: Um dos campos está incorreto";
                }

            }
            catch (Exception ex)
            {
                Validation = "o erro foi" + ex.Message;
                
            }
           
           

        }
    }
}

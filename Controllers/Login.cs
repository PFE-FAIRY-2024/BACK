using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ConsultationBack.Controllers
{
    public class Login : Controller
    {

        [Route("api/login"),HttpGet]
        public Boolean getLogin(string login, string password)
        {


            string Connexion = @"Data Source =DESKTOP-0188551\SQLEXPRESS ; Initial Catalog = gestionachats;Integrated Security=true";

            String constr = Connexion;
            SqlConnection connection = new SqlConnection(constr);

            // Connect to SQL

            try
            {

                using (connection)
                {



                    var sql = @"select * from userslogin where login='" + login+"' and password='"+password+"'";
                    SqlCommand command = new SqlCommand(sql, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();


                    if (reader.HasRows)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                    reader.Close();


                }


            }
            
            finally
            {
                connection.Close();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersLibrary.Contracts;
using UsersLibrary.Entities;
using System.Data.SqlClient;

namespace UsersLibrary.Repositories
{
    public class UserRepository : IUserContract
    {
        SqlConnection conn = new SqlConnection("Data Source=HYD-8G9ZNW3\\MSSQLSERVER1;Initial Catalog=User;Integrated Security=True");
        SqlCommand command = null;
        public bool Login(Users User)
        {
            try
            {
                command = new SqlCommand($"Select * from [Users] where Email = {User.Email} and Password = {User.Password}", conn);
                SqlDataReader reader = command.ExecuteReader();
                //Users user = new Users();
                if (reader.HasRows)
                {
                    //user.Name = reader[0].T oString();
                    // user.Email = reader[1].ToString();
                    // user.Password = reader[2].ToString();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Register(Users user)
        {

            try
            {
                command = new SqlCommand($"Insert into [Users](Name, Email, Password) values('{user.Name}', '{user.Email}', '{user.Password}')", conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

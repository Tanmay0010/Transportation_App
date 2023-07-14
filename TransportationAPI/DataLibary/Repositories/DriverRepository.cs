using DataLibary.Contracts;
using DataLibary.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.ConstrainedExecution;

namespace DataLibary.Repositories
{
    public class DriverRepository : IDriverContracts
    {
        SqlConnection connection = new SqlConnection("Data Source=HYD-9CLLNW3\\SQLEXPRESS;Initial Catalog=Transport;Integrated Security=True");
        SqlCommand command = null;
        public List<Driver> GetAllDrivers()
        {
            try
            {
                command = new SqlCommand("select * from driver", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Driver> drivers = new List<Driver>();
                while (reader.Read())
                {
                    drivers.Add(new Driver()

                    {
                        DriverId = (int)reader[0],
                        DriverName = reader[1].ToString(),
                        CarNumber = reader[2].ToString()
                    });

                }
                return drivers;
            }
            catch (Exception)
            {
                throw;
            }


            finally { connection.Close(); }
        }

        public Driver GetDriver(string CarNumber)
        {
            try
            {
                command = new SqlCommand($"select * from driver where carNumber='{CarNumber}'", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Driver driver = null;
                if (reader.HasRows)
                {
                    reader.Read();
                    driver = new Driver()
                    {
                        DriverId = (int)reader[0],
                        DriverName = reader[1].ToString(),
                        CarNumber = reader[2].ToString()
                    };
                }
                return driver;


            }
            catch (Exception) { throw; }
            finally { connection.Close(); }
        }
    }
}

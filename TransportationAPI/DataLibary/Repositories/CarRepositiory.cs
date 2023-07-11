using DataLibary.Contracts;
using DataLibary.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace DataLibary.Repositories
{
    public class CarRepositiory : ICarContracts
    {
        SqlConnection connection = new SqlConnection("Data Source=HYD-B99ZNW3\\SQLEXPRESS;Initial Catalog=Transport;Integrated Security=True");
        SqlCommand command = null;
        public void AddCar(Car car)
        {
            try
            {
                command = new SqlCommand($"insert into car values('{car.CarNumber}','{car.CarModel}','{car.Avaiablity}')", connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }
        }

        public void DeleteCar(string CarNumber)
        {
            try
            {
                command = new SqlCommand($"delete from car where carnumber='{CarNumber}'", connection);
                connection.Open ();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }


        }

        public void EditCar(Car car)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllCars()
        {
            try
            {
                command = new SqlCommand("select * from car", connection);
                connection.Open(); 
                SqlDataReader reader = command.ExecuteReader();
                List<Car> cars = new List<Car>();
                while(reader.Read())
                {
                    cars.Add(new Car()

                    {
                        CarNumber = reader[0].ToString(),
                        CarModel = reader[1].ToString(),
                        Avaiablity = (bool)reader[2]
                    });

                }
                return cars;

            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }
        }

        public Car GetCar(string CarNumber)
        {
            try
            {
                command = new SqlCommand($"select * from car where carNumber='{CarNumber}' ", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Car car = null;
                if (reader.HasRows)
                {
                    reader.Read();
                    car = new Car()
                    {
                        CarNumber = reader[0].ToString(),
                        CarModel = reader[1].ToString(),
                        Avaiablity = (bool)reader[2]
                    };
                }
                return car;
            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
        }
    }
}

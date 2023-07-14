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
    public class bookingRepository:IbookingContracts
    {
        SqlConnection connection = new SqlConnection("Data Source=HYD-9CLLNW3\\SQLEXPRESS;Initial Catalog=Transport;Integrated Security=True");
        SqlCommand command = null;
        public booking GetBookingDetail(string email)
        {
            try
            {
                command = new SqlCommand($"Select *from booking where email='{email}'", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                booking booking =null;
                if(reader.HasRows)
                {
                    reader.Read();
                    booking = new booking();
                    {
                        booking.bookingId = (int)reader[0];
                        booking.carNumber = reader[1].ToString();
                        booking.email = reader[2].ToString();
                    };
                }
                return booking;
            }
            catch (Exception) { throw; }
            
        }
        public void AddDetail(booking book)
        {
            try
            {
                command = new SqlCommand($"insert into booking values('{book.carNumber}','{book.email}')", connection);
                connection.Open();
                command.ExecuteNonQuery();
            }catch (Exception) { throw; }
            finally { connection.Close(); }
        }
    }
}

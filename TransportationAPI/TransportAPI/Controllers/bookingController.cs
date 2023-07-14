using DataLibary.Contracts;
using DataLibary.Entites;
using DataLibary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TransportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bookingController : ControllerBase
    {
        private readonly IbookingContracts bookingContracts;
        public bookingController()
        {
            bookingContracts = new bookingRepository();
        }
        [HttpGet, Route("GetBookingDetails/{email}")]
        public IActionResult GetBookingDetails(string email)
        {
            try
            {
                booking booking = bookingContracts.GetBookingDetail(email);
                return (StatusCode(200, booking));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost, Route("AddBookingDetail")]
        public IActionResult AddBookingDetail(booking booking)
        {
            try
            {
                bookingContracts.AddDetail(booking);
                return (StatusCode(200, booking));
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }


    }
}
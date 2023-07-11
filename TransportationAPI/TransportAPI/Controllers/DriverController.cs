using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLibary;
using DataLibary.Contracts;
using DataLibary.Entites;
using DataLibary.Repositories;

namespace TransportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverContracts driverContracts;
        public DriverController()
        {
            driverContracts = new DriverRepository();
        }
        [HttpGet, Route("GetAllDrivers")]
        public IActionResult GetAllDrivers()
        {
            try
            {
                List<Driver> drivers = driverContracts.GetAllDrivers();
                return (StatusCode(200, drivers));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }



        }
        [HttpGet, Route("GetDriver/{carNumber}")]
        public IActionResult GetDriver(string carNumber)
        {
            try
            {
                Driver driver = driverContracts.GetDriver(carNumber);
                return (StatusCode(200, driver));
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }
    }
}

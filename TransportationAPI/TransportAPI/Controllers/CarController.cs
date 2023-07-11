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
    public class CarController : ControllerBase
    {
        private readonly ICarContracts carContract;
        public CarController()
        {
            carContract = new CarRepositiory();
        }
        [HttpGet, Route("GetAllCars")]
        public IActionResult GetAllCars()
        {
            try
            {
                List<Car> cars = carContract.GetAllCars();
                return (StatusCode(200, cars));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }



        }
        [HttpGet, Route("GetCar/{carNumber}")]
        public IActionResult GetCar(string carNumber)
        {
            try
            {
                Car car = carContract.GetCar(carNumber);
                return (StatusCode(200, car));
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }
        [HttpPost, Route("AddCar")]
        public IActionResult AddCar(Car car)
        {
            try
            {
                carContract.AddCar(car);
                return (StatusCode(200, car));
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }
          
        [HttpDelete, Route("DeleteCar")]
        public IActionResult DeleteCar(string carNumber)
        {
            try
            {
                carContract.DeleteCar(carNumber);
                return (StatusCode(200, "Car Deleted"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

       


    }
}

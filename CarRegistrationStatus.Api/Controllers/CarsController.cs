using CarRegistrationStatus.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRegistrationStatus.API.Controllers
{
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        [Route("api/getCars")]
        public IActionResult GetCars([FromQuery] string? make)
        {
            var mockDataProvider = new MockDataProvider();
            var cars = string.IsNullOrEmpty(make)
                ? mockDataProvider.GetCars()
                : mockDataProvider.GetCars().Where(c => c.Make.StartsWith(make, StringComparison.OrdinalIgnoreCase)).ToList();

            return Ok(cars);
        }

        [HttpGet]
        [Route("api/getCarById/{id}")]
        public IActionResult GetCarById([FromRoute] Guid id)
        {
            var mockDataProvider = new MockDataProvider();
            var car = mockDataProvider.GetCars().FirstOrDefault(c => c.Id == id);

            return Ok(car);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getalldetail")]
        public IActionResult GetAllDetail()
        {
            var results = _carService.CarListDetails();
            if (results.Success)
            {
                return Ok(results);
            }

            return BadRequest(results);
        }
    }
}

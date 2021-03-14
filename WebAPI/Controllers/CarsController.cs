using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

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
        [HttpGet("getbycoloriddetail")]
        public IActionResult GetByColorIdDetail(int colorId)
        {
            var results = _carService.CarListColorIdDetails(colorId);
            if (results.Success)
            {
                return Ok(results);
            }

            return Ok(results);
        }
        [HttpGet("getiddetail")]
        public IActionResult GetIdDetail(Car _car)
        {
            var results = _carService.CarListColorIdDetails(_car.ColorId);
            if (results.Success)
            {
                return Ok(results);
            }

            return Ok(results);
        }
    }
}

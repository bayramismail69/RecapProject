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
    public class RentalsController : ControllerBase
    {
        private IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpGet("canACarBeRented")]
        public IActionResult CanACarBeRented(int carId)
        {
            var results=_rentalService.CanACarBeRented(carId);
            if (results.Success)
            {
                return Ok(results);
            }

            return BadRequest(results);
        }
        [HttpGet("getRentalDetails")]
        public IActionResult GetRentalDetailList()
        {
         
            var results = _rentalService.RentalDetailList();
            if (results.Success)
            {
                return Ok(results);
            }

            return BadRequest(results);
        }
        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            rental.RentDate = DateTime.Now;
            var results = _rentalService.Add(rental);
            if (results.Success)
            {
                return Ok(results);
            }

            return BadRequest(results);
        }
        [HttpGet("getRentalByCarIdControl")]
        public IActionResult RentalByCarIdControl(int carId)
        {
           
            var results = _rentalService.rentalCarIdControl(carId);
            if (results.Success)
            {
                return Ok(results);
            }

            return BadRequest(results);
        }
    }
}

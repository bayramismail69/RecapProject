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
    public class ColorsController : ControllerBase
    {
        private IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getall")]
        public IActionResult GetColorAll()
        {
            DateTime adfs = DateTime.Now.AddDays(10);
            DateTime sss = DateTime.Now;
            var dad =Math.Round((adfs - sss).TotalDays);
        
            var results = _colorService.GetAll();
            if (results.Success)
            {
                return Ok(results);
            }

            return BadRequest(results);
        }
        [HttpGet("getColor")]
        public IActionResult GetBrand(int colorId)
        {
            var results = _colorService.GetById(colorId);
            if (results.Success)
            {
                return Ok(results);
            }

            return BadRequest(results);
        }
        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var results = _colorService.Add(color);
            if (results.Success)
            {
                return Ok(results);
            }

            return BadRequest(results);
        }
        [HttpPost("Update")]
        public IActionResult Update(Color color)
        {
            var results = _colorService.Update(color);
            if (results.Success)
            {
                return Ok(results);
            }

            return BadRequest(results);
        }
    }
}

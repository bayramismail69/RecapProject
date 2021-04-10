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
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var results = _brandService.GetAll();
            if (results.Success)
            {
                return Ok(results);
            }

            return BadRequest(results);
        }
        [HttpGet("getBrand")]
        public IActionResult GetBrand(int brandId)
        {
            var results = _brandService.GetById(brandId);
            if (results.Success)
            {
                return Ok(results);
            }

            return BadRequest(results);
        }
        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var results = _brandService.Add(brand);
            if (results.Success)
            {
                return Ok(results);
            }

            return BadRequest(results);
        }
        [HttpPost("Update")]
        public IActionResult Update(Brand brand)
        {
            var results = _brandService.Update(brand);
            if (results.Success)
            {
                return Ok(results);
            }

            return BadRequest(results);
        }
    }
}

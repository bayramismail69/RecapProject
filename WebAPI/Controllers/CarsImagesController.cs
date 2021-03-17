using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Helpers.FilesHelper;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsImagesController : ControllerBase
    {
        private ICarImageService _carImageService;
        private IFileHelper _file;
        private IWebHostEnvironment _environment;
        public CarsImagesController(IFileHelper file, IWebHostEnvironment environment, ICarImageService carImageService)
        {
            _file = file;
            _environment = environment;
            _carImageService = carImageService;
        }

        public IFormFile FromFile { get; private set; }

        [HttpGet("gel")]
        public IActionResult Gel()
        {
            var results = _carImageService.GetAll();
            return Ok(results);
        }
        //[HttpPost("all")]
        //public IActionResult All([FromForm] IFormFile file)
        //{
        //    var path = _environment.WebRootPath + "/Images/";
        //    var result = _file.Upload(file, path, "Image");
        //    return Ok(result);
        //}
        [HttpPost("postall")]
        public IActionResult PostAll([FromForm] IFormFile file,[FromForm] CarImage carImage)
        {
            var path = _environment.WebRootPath;
            var newImage = _file.Upload(file, path,"Image");
            if (newImage.Success)
            {
                carImage.ImagePath = newImage.Data;
                var result2= _carImageService.Add(carImage);
                return Ok(result2.Message);
            }

            return BadRequest(newImage);
        }
    }
}

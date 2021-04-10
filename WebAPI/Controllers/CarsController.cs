using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;
        private ICarImageService _carImageService;
        List<CarListDetailsDto> carlistDtos = new List<CarListDetailsDto>();
        CarListDetailsDto carListDetailsDto = new CarListDetailsDto();
        public CarsController(ICarService carService, ICarImageService carImageService)
        {
            _carService = carService;
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getalldetail")]
        public IActionResult GetAllDetail()
        {
            var carList = _carService.CarListDetails();
           
            if (carList.Success)
            {
                return Ok(carList);
            }

            return BadRequest(carList);
        }
        [HttpGet("getByColorIdDetail")]
        public IActionResult GetByColorIdDetail(int colorId)
        {
            var carList = _carService.CarListColorIdDetails(colorId);
          
           
            if (carList.Success)
            {
                return Ok(carList);
            }

            return Ok(carList);
        }
        [HttpGet("getByBrandIdDetail")]
        public IActionResult GetByBarndIdDetail(int brandId)
        {
            var carList = _carService.CarListBrandIdDetails(brandId);
           
            if (carList.Success)
            {
                return Ok(carList);
            }

            return Ok(carList);
        }
        [HttpGet("getCar")]
        public IActionResult GetCar(int carId)
        {
            var car = _carService.GetById(carId);
            if (car.Success)
            {
                return Ok(car);
            }
            return BadRequest(car);
        }
        [HttpGet("getCarId")]
        public IActionResult GetCarId(int carId)
        {
            var carList = _carService.CarListCarIdDetails(carId);
            return Ok(carList);
        }
        [HttpGet("getByColorIdBrandIdDetail")]
        public IActionResult GetByColorIdBrandIdDetail(int colorId, int brandId)
        {
            var carList = _carService.CarListColorIdBrandIdDetails(colorId, brandId);
          
            return Ok(carList);
        }

        [HttpGet("getCarDetailByCarId")]
        public IActionResult GetIdDetail(int carId)
        {
            var results = _carService.carDetailByCarId(carId);

            if (results.Success)
            {
                return Ok(results);
            }

            return BadRequest(results);
        }
        //[HttpGet("getiddetail")]
        //public IActionResult GetIdDetail(Car _car)
        //{
        //    var results = _carService.CarListColorIdDetails(_car.ColorId);
         
        //    if (results.Success)
        //    {
        //        return Ok(results);
        //    }

        //    return Ok(results);
        //}
    }
}

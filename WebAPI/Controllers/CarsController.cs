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

        [HttpGet("getalldetail")]
        public IActionResult GetAllDetail()
        {
            var results = _carImageService.GetCarDtoIamgeList();
            if (results.Success)
            {
                return Ok(results);
            }

            return Ok(results);
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
        [HttpGet("getbybrandiddetail")]
        public IActionResult GetByBarndIdDetail(int brandId)
        {
            var results = _carService.CarListBrandIdDetails(brandId);
            if (results.Success)
            {
                return Ok(results);
            }

            return Ok(results);
        }
        [HttpGet("getByColoridBrandidDetail")]
        public IActionResult GetByColorIdBrandIdDetail(int colorId, int brandId)
        {
            var results = _carService.CarListColorIdBrandIdDetails(colorId, brandId);
            return Ok(results);
        }
        [HttpGet("getCarImagePatById")]
        public IActionResult GetCarImagePatById(int carId)
        {
            var results = _carService.GetCarImagePathById(carId);
            return Ok(results);
        }
        [HttpGet("getiddetail")]
        public IActionResult GetIdDetail(Car _car)
        {
            var results = _carService.CarListColorIdDetails(_car.ColorId);
            foreach (var item in results.Data)
            {
                carListDetailsDto = item;
                var resultImage = _carImageService.GetByCarId(item.CarId);
                foreach (var item2 in resultImage.Data)
                {
                    carListDetailsDto.ImagePath = item2.ImagePath;
                    break;
                }
                carlistDtos.Add(carListDetailsDto);
            }
            if (results.Success)
            {
                return Ok(results);
            }

            return Ok(results);
        }
    }
}

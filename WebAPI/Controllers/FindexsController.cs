using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindexsController : ControllerBase
    {
        private ICarFindexService _carFindexService;
        private IUserFindexService _userFindexService;

        public FindexsController(ICarFindexService carFindexService, IUserFindexService userFindexService)
        {
            _carFindexService = carFindexService;
            _userFindexService = userFindexService;
        }
        [HttpGet("findexUserCarControl")]
        public IActionResult FindexControl(int carId,int userId)
        {
            var carFindex = _carFindexService.GetByCarId(carId);
            var userFindex = _userFindexService.GetByUserId(userId);
            if (userFindex.Data.FindexNot>= carFindex.Data.FindexNot)
            {
                return Ok(new SuccessResult());
            }

            return BadRequest(new ErrorResult("Findex notunuz bu araç için uygun değil.Uygun araçlara bakabilirsiniz!"));
        }
        [HttpGet("getFindexCar")]
        public IActionResult GetFindexCar(int carId)
        {
            var carFindex = _carFindexService.GetByCarId(carId);
           
            if (carFindex.Data!=null)
            {
                return Ok(carFindex);
            }

            return BadRequest(carFindex);
        }
        [HttpGet("getFindexUser")]
        public IActionResult GetFindexUser(int userId)
        {
            var userFindex = _userFindexService.GetByUserId(userId);
            if (userFindex.Data != null)
            {
                return Ok(userFindex);
            }

            return BadRequest(userFindex);
        }
        [HttpGet("userFindexUpdate")]
        public IActionResult UserFindexUpdate(UserFindex userFindex)
        {
            var result = _userFindexService.Update(userFindex);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("userFindexAdd")]
        public IActionResult UserFindexAdd(UserFindex userFindex)
        {
            var result = _userFindexService.Add(userFindex);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("carFindexUpdate")]
        public IActionResult CarFindexUpdate(CarFindex carFindex)
        {
            var result = _carFindexService.Update(carFindex);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("carFindexAdd")]
        public IActionResult CarFindexAdd(CarFindex carFindex)
        {
            var result = _carFindexService.Add(carFindex);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}

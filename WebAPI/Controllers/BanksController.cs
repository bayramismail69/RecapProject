using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
       private IBankService _bankService;
       private IUserBankCardSaveService _bankCardSaveService;
        public BanksController(IBankService bankService, IUserBankCardSaveService bankCardSaveService)
        {
            _bankService = bankService;
            _bankCardSaveService = bankCardSaveService;
        }
        [HttpPost("getByCardVerify")]
        public IActionResult GetByCardNumber(Bank bank)
        {
            var result = _bankService.GetByCardNumber(bank);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost("userBankSave")]
        public IActionResult UserBankSave(UserBankCardSave bank)
        {
            var result = _bankCardSaveService.Add(bank);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}

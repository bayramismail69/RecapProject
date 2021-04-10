using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BankManager : IBankService
    {
        private IBankDal _bankDal;

        public BankManager(IBankDal bankDal)
        {
            _bankDal = bankDal;
        }

        public IDataResult<Bank> GetByCardNumber(Bank bank)
        {
            var result = _bankDal.GetAll(c => c.CardNumber == bank.CardNumber  && c.ExpirationDate == bank.ExpirationDate && c.NameAndSurname.ToUpper() == bank.NameAndSurname.ToUpper() && c.Cvv == bank.Cvv );
            if (result.Count() != 0)
            {
                return new SuccessDataResult<Bank>(result.FirstOrDefault());
            }
            return new ErrorDataResult<Bank>("Kart bilgileri hatalı");
        }
    }
}

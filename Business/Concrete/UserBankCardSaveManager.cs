using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserBankCardSaveManager : IUserBankCardSaveService
    {
        private IUserBankCardSaveDal _bankCardSaveDal;

        public UserBankCardSaveManager(IUserBankCardSaveDal bankCardSaveDal)
        {
            _bankCardSaveDal = bankCardSaveDal;
        }

        public IDataResult<UserBankCardSave> GetByUserId(int userId)
        {
            var result = _bankCardSaveDal.Get(b => b.UserId == userId);
            if (result==null)
            {return new ErrorDataResult<UserBankCardSave>("kart");
                
            }
            return new SuccessDataResult<UserBankCardSave>(result);
        }

        public IResult Add(UserBankCardSave userBankCardSave)
        {
           _bankCardSaveDal.Add(userBankCardSave);
           return new SuccessResult();
        }

        public IResult Delete(int userBankCardSaveId)
        {
            var result = _bankCardSaveDal.Get(b => b.Id == userBankCardSaveId);
            if (result==null)
            {
                return new ErrorResult("Kart bulunamadı");
            }
            _bankCardSaveDal.Delete(result);
            return new SuccessResult();
        }

        public IDataResult<List<UserBankCardSave>> GetAll()
        {
            return  new DataResult<List<UserBankCardSave>>(new List<UserBankCardSave>(),true, "Buservis devredısı");
        }

        public IDataResult<UserBankCardSave> GetById(int userBankCardSaveId)
        {
            var result = _bankCardSaveDal.Get(b => b.Id == userBankCardSaveId);
            if (result==null)
            {
                return new ErrorDataResult<UserBankCardSave>("kart  bulunamadı");
            }
            return  new SuccessDataResult<UserBankCardSave>(result);
        }

        public IResult Update(UserBankCardSave userBankCardSave)
        {
            var result = _bankCardSaveDal.Get(b => b.Id == userBankCardSave.Id);
            if (result == null)
            {
                return new ErrorResult("Findex bulunamadı");
            }
            _bankCardSaveDal.Update(result);
            return new SuccessResult();
        }
    }
}

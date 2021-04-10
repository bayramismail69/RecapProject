using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserBankCardSaveService
    {
        IDataResult<List<UserBankCardSave>> GetAll();
        IDataResult<UserBankCardSave> GetById(int userBankCardSaveId);
        IDataResult<UserBankCardSave> GetByUserId(int userId);
        IResult Add(UserBankCardSave userBankCardSave);
        IResult Update(UserBankCardSave userBankCardSave);
        IResult Delete(int userBankCardSaveId);
    }
}
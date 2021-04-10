using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserFindexService
    {
        IDataResult<List<UserFindex>> GetAll();
        IDataResult<UserFindex> GetById(int userFindexId);
        IDataResult<UserFindex> GetByUserId(int userId);
        IResult Add(UserFindex userFindex);
        IResult Update(UserFindex userFindex);
        IResult Delete(int userFindexId);
    }
}
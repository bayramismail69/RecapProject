using Core.Entities.Concrete;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        IResult Update(UserDto userDto);
        User GetByMail(string email);
        IDataResult<UserDto> GetById(int userId);
    }
}

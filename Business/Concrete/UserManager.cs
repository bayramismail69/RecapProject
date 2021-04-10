using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(UserDto userDto)
        {  
            var user = _userDal.Get(u => u.Id == userDto.Id);
            if (userDto.Password!=null&&userDto.Password!="   ")
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(userDto.Password, out passwordHash, out passwordSalt);
                user.Email = userDto.Email;
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.Status = userDto.Status;
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }
          
            user.Email = userDto.Email;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Status = userDto.Status;
            _userDal.Update(user);
            return new SuccessResult("Bilgiler güncellendi");
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IDataResult<UserDto> GetById(int userId)
        {
            var  result=_userDal.Get(u => u.Id == userId);
            if (result==null)
            {
                return  new ErrorDataResult<UserDto>("Hatalı kullanıcı");
            }
            var userDto=new UserDto
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                Status = result.Status,
                
            };
            return  new SuccessDataResult<UserDto>(userDto);
        }
    }
}

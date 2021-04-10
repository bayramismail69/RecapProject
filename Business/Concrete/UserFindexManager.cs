using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserFindexManager : IUserFindexService
    {
        private IUserFindexDal _userFindexDal;

        public UserFindexManager(IUserFindexDal userFindexDal)
        {
            _userFindexDal = userFindexDal;
        }

        public IDataResult<List<UserFindex>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<UserFindex> GetById(int userFindexId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<UserFindex> GetByUserId(int userId)
        {
            var result = _userFindexDal.Get(ca => ca.UserId == userId);
            if (result == null)
            {
                return new ErrorDataResult<UserFindex>("Kullanıcı'ya ait findex notu bulunamadı");
            }
            return new SuccessDataResult<UserFindex>(result);
        }

        public IResult Add(UserFindex userFindex)
        {
            _userFindexDal.Add(userFindex);
            return  new SuccessResult("Ekle işlemi basarılı");
        }

        public IResult Update(UserFindex userFindex)
        {
            _userFindexDal.Update(userFindex);
            return new SuccessResult("Güncelleme işlemi basarılı");
        }

        public IResult Delete(int userFindexId)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<RentalDetailListDto>> RentalDetailList()
        {
            var result = _rentalDal.RentalDetailListDtos();
            if (result.Count==0)
            {
                return new ErrorDataResult<List<RentalDetailListDto>>(Messages.RentalNotFound);
            }
            return new SuccessDataResult<List<RentalDetailListDto>>(result);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            throw new NotImplementedException();
        }

        public IResult Add(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int rentalId)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        private ICarService _carService;
        private IUserFindexService _userFindexService;
        public RentalManager(IRentalDal rentalDal, ICarService carService, IUserFindexService userFindexService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _userFindexService = userFindexService;
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
            IResult result = BusinessRules.Run(RentalControl(rental.CarId),RentalCarIdControl(rental.CarId));

            if (result != null)
            {
                return result;
            }

            var findex = _userFindexService.GetByUserId(rental.CustomerId);
            findex.Data.FindexNot = findex.Data.FindexNot +500;
            _userFindexService.Update(findex.Data);
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAddedSuccess);
        }

        private IResult RentalControl( int carId)
        {
            var result =  _rentalDal.GetAll(p=>p.CarId==carId && p.ReturnDate>DateTime.Now);
            if (result.Count==0)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.RentalError);
        }
        private IResult RentalCarIdControl(int carId)
        {
            var result = _carService.GetById(carId);
            if (result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarNotFound);
        }

        public IResult CanACarBeRented(int carId)
        {
            var carRental = _rentalDal.GetAll(r=>r.CarId==carId&& r.ReturnDate>=DateTime.Now);
            if (carRental.Count==0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Bu araç bu "+carRental[0].ReturnDate+" tarihe kadar kiralanamaz");
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int rentalId)
        {
            throw new NotImplementedException();
        }

        public IResult rentalCarIdControl(int carId)
        {
            var carRental = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate >= DateTime.Now);
            if (carRental.Count == 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Bu araç " + carRental[0].ReturnDate + " tarihi' ne kadar kiralanamaz");
        }
    }
}
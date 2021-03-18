using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            var results = _carDal.GetAll();
            if (results.Count != 0)
            {
                return new SuccessDataResult<List<Car>>(results);
            }
            return new ErrorDataResult<List<Car>>(Messages.ThereAreNoCarsRegisteredInTheSystem);
        }
        [CacheAspect]
        public IDataResult<List<CarListDetailsDto>> CarListDetails()
        {
            var results = _carDal.CarListDetailsDtos();
            if (results==null)
            {
                return new ErrorDataResult<List<CarListDetailsDto>>(new List<CarListDetailsDto>(), Messages.CarNotFound);
            }
            return new SuccessDataResult<List<CarListDetailsDto>>(results);
        }

        [CacheAspect]
        public IDataResult<List<CarListDetailsDto>> CarListColorIdDetails(int colorId)
        {
            var results = _carDal.CarListDetailsDtos(c=>c.ColorId==colorId);
            if (results.Count==0)
            {
                return  new ErrorDataResult<List<CarListDetailsDto>>(new List<CarListDetailsDto>(), Messages.CarNotFound);
            }
            return new SuccessDataResult<List<CarListDetailsDto>>(results);
        }
        [CacheAspect]
        public IDataResult<List<CarListDetailsDto>> CarListBrandIdDetails(int brandId)
        {
            var results = _carDal.CarListDetailsDtos(c=>c.BrandId==brandId);
           
            if (results.Count == 0)
            {
                return new ErrorDataResult<List<CarListDetailsDto>>(new List<CarListDetailsDto>(),Messages.CarNotFound);
            }
            return new SuccessDataResult<List<CarListDetailsDto>>(results);
        }

        public IDataResult<List<CarListDetailsDto>> CarListColorIdBrandIdDetails(int colorId, int brandId)
        {
            var results = _carDal.CarListDetailsDtos(c=>c.ColorId==colorId && c.BrandId==brandId);
            if (results.Count==0)
            {
                return  new ErrorDataResult<List<CarListDetailsDto>>(new List<CarListDetailsDto>());
            }
            return new SuccessDataResult<List<CarListDetailsDto>>(results);
        }

        public IDataResult<Car> GetById(int carId)
        {
            var result = _carDal.Get(c => c.Id == carId);
            if (result != null)
            {
                return new SuccessDataResult<Car>(result);
            }
            return new ErrorDataResult<Car>(Messages.CarNotFound);
        }
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfTheModelYearIsSuitable(car.ModelYear));

            if (result != null)
            {
                return result;
            }

            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Update(Car car)
        {
            IResult result = BusinessRules.Run(CarIdCheck(car.Id), CheckIfTheModelYearIsSuitable(car.ModelYear));

            if (result != null)
            {
                return result;
            }

            _carDal.Update(car);

            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(int carId)
        {
            var getCar = DatabaseCarCheck(carId);
            IResult result = BusinessRules.Run(getCar, CarIdCheck(carId));

            if (result != null)
            {
                return result;
            }

            _carDal.Delete(getCar.Data);

            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<Car> DatabaseCarCheck(int carId)
        {
            var result = _carDal.Get(c => c.Id == carId);
            if (result == null)
            {
                return new ErrorDataResult<Car>(Messages.CarNotFound);
            }
            return new SuccessDataResult<Car>();
        }
        private IResult CarIdCheck(int carId)
        {
            if (carId <= 0)
            {
                return new ErrorResult(Messages.CarIdIsWrong);
            }

            return new SuccessResult();
        }
        private IResult CheckIfTheModelYearIsSuitable(string modelYear)
        {
            if (modelYear.Length < 4)
            {
                return new ErrorResult(Messages.CheckTheModelYearOfTheCar);
            }

            return new SuccessResult();
        }

        public IDataResult<CarImage> GetCarImagePathById(int carId)
        {
            var result = _carDal.CarImagePathCarId(carId);
            return new SuccessDataResult<CarImage>(result);
        }
    }
}

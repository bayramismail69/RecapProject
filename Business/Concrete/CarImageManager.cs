using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private ICarService _carService;
        List<CarListDetailsDto> carlistDtos = new List<CarListDetailsDto>();
        CarListDetailsDto carListDetailsDto = new CarListDetailsDto();
        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        public IDataResult<List<CarImageDto>> GetAll()
        {
            List<CarImageDto> carImageDtos = new List<CarImageDto>();
            foreach(var item in _carImageDal.GetAll())
            {
                CarImageDto carImageDto = new CarImageDto {ImagePath=item.ImagePath };
                carImageDtos.Add(carImageDto);
            }
            var results = carImageDtos;
            if (results.Count != 0)
            {
                return new SuccessDataResult<List<CarImageDto>>(results);
            }
            return new ErrorDataResult<List<CarImageDto>>(Messages.CarPhotosNotFound);
        }

        public IDataResult<List<CarImage>> GetById(int carImageId)
        {
            var results = _carImageDal.GetAll(c=>c.CarId==carImageId);
            if (results.Count != 0)
            {
                return new SuccessDataResult<List<CarImage>>(results);
            }
            return new ErrorDataResult<List<CarImage>>(Messages.PhotosOfTheCarNotFound);
        }
        //[SecuredOperation("product.add,admin")]
        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CarControl(carImage.CarId));

            if (result != null)
            {
                return result;
            }
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CarImageIdCheck(carImage.Id),CarControl(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IResult Delete(int carImageId)
        {
            var getCarImage = DatabaseCarImageCheck(carImageId);
            IResult result = BusinessRules.Run(getCarImage);

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(getCarImage.Data);

            return new SuccessResult(Messages.CarImageDeleted);
        }
        private IResult CarControl(int carId )
        {
            var result = _carService.GetById(carId);
            if (result.Success)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarNotFound);
        }
        private IResult CarImageIdCheck(int carImageId)
        {
            if (carImageId <= 0)
            {
                return new ErrorResult(Messages.CarImageIdIsWrong);
            }

            return new SuccessResult();
        }
        private IDataResult<CarImage> DatabaseCarImageCheck(int carImageId)
        {
            var result = _carImageDal.Get(c => c.Id ==carImageId );
            if (result == null)
            {
                return new ErrorDataResult<CarImage>(Messages.CarImageNotFound);
            }
            return new SuccessDataResult<CarImage>();
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var results = _carImageDal.GetAll(p=>p.CarId==carId);
            if (results.Count==0)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.CarImageNotFound);
            }
            return new SuccessDataResult<List<CarImage>>(results);
        }
        public IDataResult<List<CarListDetailsDto>> GetCarDtoIamgeList()
        {
            carlistDtos.Clear();
               var results = _carService.CarListDetails();
            foreach (var item in results.Data)
            {
                carListDetailsDto = item;
                var resultImage =_carImageDal.GetAll(p=>p.CarId== item.CarId);
                if (resultImage.Count!=0)
                {
                    foreach (var item2 in resultImage)
                    {
                        carListDetailsDto.ImagePath = item2.ImagePath;
                        break;
                    }
                }
                else
                {

                    carListDetailsDto.ImagePath = "/Images/default.png";


                }
                carlistDtos.Add(carListDetailsDto);
            }
            return new SuccessDataResult<List<CarListDetailsDto>>(carlistDtos);
        }
    }
}
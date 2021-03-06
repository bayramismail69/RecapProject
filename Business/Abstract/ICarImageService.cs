﻿using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImageDto>> GetAll();
        IDataResult<List<CarImage>> GetByCarId(int carId);
        
         IDataResult<List<CarListDetailsDto>> GetCarDtoIamgeList(List<CarListDetailsDto> carListDetailsDtos);
        IResult Add(CarImage carImage);
        IResult Update(CarImage carImage);
        IResult Delete(int carImageId);
    }
}
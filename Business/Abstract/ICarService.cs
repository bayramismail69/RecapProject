﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
   public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarListDetailsDto>> CarListDetails();
        IDataResult<List<CarListDetailsDto>> CarListCarIdDetails(int carId);
        IDataResult<List<CarListDetailsDto>> CarListColorIdDetails(int colorId);
        IDataResult<List<CarListDetailsDto>> CarListBrandIdDetails(int brandId);
        IDataResult<List<CarListDetailsDto>> CarListColorIdBrandIdDetails(int colorId,int brandId);
        IDataResult<CarListDetailsDto> carDetailByCarId(int carId);
        IDataResult<Car> GetById(int carId);
       
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(int carId);
    }
}

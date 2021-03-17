using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCarDal:EfEntityRepositoryBase<Car,RecapContext>,ICarDal
    {
        public IDataResult<List<CarListDetailsDto>> CarListDetailsDtos()
        {
            using (RecapContext recapContext=new RecapContext())
            {
            
                var results = from car in recapContext.Cars
                    join brand in recapContext.Brands on car.BrandId equals brand.Id
                    join color in recapContext.Colors on car.ColorId equals color.Id
                    select new CarListDetailsDto
                    {
                        CarId = car.Id,
                        CarName = car.CarName,
                        BrandName = brand.BrandName,
                        ColorName = color.ColorName
                    };
                return new SuccessDataResult<List<CarListDetailsDto>>(results.ToList());
            }
           
        }

        public List<CarListDetailsDto> CarListColorIdDetailsDtos(int colorId)
        {
            using (RecapContext recapContext = new RecapContext())
            {
                var results = from car in recapContext.Cars
                    join brand in recapContext.Brands on car.BrandId equals brand.Id
                    join color in recapContext.Colors on car.ColorId equals color.Id
                    where car.ColorId==colorId
                    select new CarListDetailsDto
                    {
                        CarId = car.Id,
                        CarName = car.CarName,
                        BrandName = brand.BrandName,
                        ColorName = color.ColorName
                    };
                return results.ToList();
            }
        }

        public List<CarListDetailsDto> CarListBarndIdDetailsDtos(int brandId)
        {

            using (RecapContext recapContext = new RecapContext())
            {
                var results = from car in recapContext.Cars
                              join brand in recapContext.Brands on car.BrandId equals brand.Id
                              join color in recapContext.Colors on car.ColorId equals color.Id
                              where car.BrandId == brandId
                              select new CarListDetailsDto
                              {
                                  CarId = car.Id,
                                  CarName = car.CarName,
                                  BrandName = brand.BrandName,
                                  ColorName = color.ColorName

                              };
              
                return results.ToList();
            }
        }

        public List<CarListDetailsDto> CarListColorIdBrandIdDetailsDtos(int colorId, int brandId)
        {
            using (RecapContext recapContext = new RecapContext())
            {
                if (brandId!=0)
                {
                    var results = from car in recapContext.Cars
                        join brand in recapContext.Brands on car.BrandId equals brand.Id
                        join color in recapContext.Colors on car.ColorId equals color.Id
                        where car.ColorId == colorId && car.BrandId==brandId
                        select new CarListDetailsDto
                        {
                            CarId = car.Id,
                            CarName = car.CarName,
                            BrandName = brand.BrandName,
                            ColorName = color.ColorName
                        }; 
                    return results.ToList();
                }
                else
                {
                    var results = from car in recapContext.Cars
                        join brand in recapContext.Brands on car.BrandId equals brand.Id
                        join color in recapContext.Colors on car.ColorId equals color.Id
                        where car.ColorId == colorId || car.BrandId == brandId
                        select new CarListDetailsDto
                        {
                            CarId = car.Id,
                            CarName = car.CarName,
                            BrandName = brand.BrandName,
                            ColorName = color.ColorName
                        };
                    return results.ToList();
                }
            }
        }

        public CarImage CarImagePathCarId(int carId)
        {
            CarImage carImage = new CarImage();
            using (RecapContext context=new RecapContext())
            {
                var result = from v in context.CarImages where v.CarId == carId select v;
                foreach (var item in result)
                {
                    carImage = item;
                    break;
                } 
                return carImage;
            }
        }
    }
}

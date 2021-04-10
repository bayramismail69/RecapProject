using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapContext>, ICarDal
    {
        public CarListDetailsDto CarDetailDto(Expression<Func<Car, bool>> filter = null)
        {
            using (RecapContext recapContext = new RecapContext())
            {
                IQueryable<CarListDetailsDto> carDetailsDtos = from car in filter is null ? recapContext.Cars : recapContext.Cars.Where(filter)
                                                               join brand in recapContext.Brands
                                                                   on car.BrandId equals brand.Id
                                                               join color in recapContext.Colors
                                                                   on car.ColorId equals color.Id
                                                               join carFindex in recapContext.CarFindexes
                                                                   on car.Id equals carFindex.CarId
                                                               select new CarListDetailsDto
                                                               {
                                                                   MinimumCarFindex = carFindex.FindexNot,
                                                                   CarId = car.Id,
                                                                   CarName = car.CarName,
                                                                   BrandName = brand.BrandName,
                                                                   ColorName = color.ColorName,
                                                                   DailyPrice = car.DailyPrice,
                                                                   ModelYear = car.ModelYear,
                                                                   Description = car.Description,
                                                                   ImagePath = (from carImage in recapContext.CarImages where carImage.CarId == car.Id select carImage.ImagePath).ToList()
                                                               };
                return carDetailsDtos.FirstOrDefault();
            }
        }

        public List<CarListDetailsDto> CarDetailDtos(Expression<Func<Car, bool>> filter = null)
        {
            using (RecapContext recapContext = new RecapContext())
            {
                IQueryable<CarListDetailsDto> carDetailsDtos = from car in filter is null ? recapContext.Cars : recapContext.Cars.Where(filter)
                                                               join brand in recapContext.Brands
                                                                   on car.BrandId equals brand.Id
                                                               join color in recapContext.Colors
                                                                   on car.ColorId equals color.Id
                                                               join carFindex in recapContext.CarFindexes
                                                                   on car.Id equals carFindex.CarId
                                                               select new CarListDetailsDto
                                                               {
                                                                   MinimumCarFindex = carFindex.FindexNot,
                                                                   CarId = car.Id,
                                                                   CarName = car.CarName,
                                                                   BrandName = brand.BrandName,
                                                                   ColorName = color.ColorName,
                                                                   DailyPrice = car.DailyPrice,
                                                                   ModelYear = car.ModelYear,
                                                                   Description = car.Description,
                                                                   ImagePath = (from carImage in recapContext.CarImages where carImage.CarId == car.Id select carImage.ImagePath).ToList()
                                                               };
                return carDetailsDtos.ToList();
            }

        }

    }
}

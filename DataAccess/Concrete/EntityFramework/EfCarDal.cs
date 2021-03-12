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
    }
}

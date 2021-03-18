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
   public class EfCarDal:EfEntityRepositoryBase<Car,RecapContext>,ICarDal
    {
        public List<CarListDetailsDto> CarListDetailsDtos(Expression<Func<Car, bool>> filter = null)
        {
            using (RecapContext recapContext=new RecapContext())
            {
                IQueryable<CarListDetailsDto> carDetailsDtos = from car in filter is null ? recapContext.Cars : recapContext.Cars.Where(filter)
                    join brand in recapContext.Brands
                        on car.BrandId equals brand.Id
                    join color in recapContext.Colors
                        on car.ColorId equals color.Id
                    select new CarListDetailsDto
                    {
                        CarId = car.Id,
                        CarName = car.CarName,
                        BrandName = brand.BrandName,
                        ColorName = color.ColorName,
                    };
                return carDetailsDtos.ToList();
            }
           
        }
        
    }
}

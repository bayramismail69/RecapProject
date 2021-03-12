using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RecapContext>, IRentalDal
    {
        public List<RentalDetailListDto> RentalDetailListDtos()
        {
            using (RecapContext recapContext=new RecapContext())
            {
                var results = from rental in recapContext.Rentals
                    join car in recapContext.Cars on rental.CarId equals car.Id
                    join brand in recapContext.Brands on car.BrandId equals brand.Id
                    join customer in recapContext.Customers on rental.CustomerId equals customer.Id
                    join user in recapContext.Users on customer.UserId equals user.Id
                    select new RentalDetailListDto
                    {
                        RentalId =rental.Id,
                        CarName = car.CarName,
                        BrandName = brand.BrandName,
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    };
                return results.ToList();
            }
        }
    }
}
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, RecapContext>, ICarImageDal
    {
        public CarImage GetImageMin(int carId)
        {
            using (RecapContext recapContext=new RecapContext())
            {
                var Image = (from carImage in recapContext.CarImages where carImage.CarId == carId select carImage).FirstOrDefault();
                return Image;
            }
           
        }
    }
}
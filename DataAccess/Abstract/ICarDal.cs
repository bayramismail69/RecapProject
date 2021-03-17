using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
      IDataResult<List<CarListDetailsDto>> CarListDetailsDtos();
      List<CarListDetailsDto> CarListColorIdDetailsDtos(int colorId);
        List<CarListDetailsDto> CarListBarndIdDetailsDtos(int brandId);
       CarImage CarImagePathCarId(int carId);
        List<CarListDetailsDto> CarListColorIdBrandIdDetailsDtos(int colorId, int brandId);
    }
}

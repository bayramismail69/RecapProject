using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetById(int carImageId);
        IResult Add(CarImage carImage);
        IResult Update(CarImage carImage);
        IResult Delete(int carImageId);
    }
}
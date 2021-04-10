using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarFindexService
    {
        IDataResult<List<CarFindex>> GetAll();
        IDataResult<CarFindex> GetById(int carFindexId);
        IDataResult<CarFindex> GetByCarId(int carId);
        IResult Add(CarFindex carFindex);
        IResult DefaultCarFindexAdd(int carId);
        IResult Update(CarFindex carFindex);
        IResult Delete(int carFindexId);
    }
}
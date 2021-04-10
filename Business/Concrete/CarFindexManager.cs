using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class CarFindexManager:ICarFindexService
   {
       private ICarFindexDal _carFindexDal;

       public CarFindexManager(ICarFindexDal carFindexDal)
       {
           _carFindexDal = carFindexDal;
       }

       public IDataResult<List<CarFindex>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarFindex> GetById(int carFindexId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarFindex> GetByCarId(int carId)
        {
          var result=  _carFindexDal.Get(ca => ca.CarId == carId);
          if (result==null)
          {
                return new ErrorDataResult<CarFindex>("Arac'a ait findex notu bulunamadı");
          }
          return  new SuccessDataResult<CarFindex>(result);
        }

        public IResult Add(CarFindex carFindex)
        {
            _carFindexDal.Add(carFindex);
            return new SuccessResult();
        }

        public IResult DefaultCarFindexAdd(int carId)
        {
            _carFindexDal.Add(new CarFindex{CarId = carId,FindexNot =1000});
            return new SuccessResult();
        }

        public IResult Update(CarFindex carFindex)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int carFindexId)
        {
            throw new NotImplementedException();
        }
    }
}

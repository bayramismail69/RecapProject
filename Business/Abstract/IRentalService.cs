using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailListDto>> RentalDetailList();
        IDataResult<Rental> GetById(int rentalId);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(int rentalId);
    }
}
using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAll()
        {
          var results=  _customerDal.GetAll();
          if (results.Count==0)
          {
              return new ErrorDataResult<List<Customer>>(Messages.CustomerNotFound);
          }
          return new SuccessDataResult<List<Customer>>(results);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CustomerListDto>> CustomerDetailList()
        {
            var result = _customerDal.CustomerListDtos();
            if (result.Count==0)
            {
                return new ErrorDataResult<List<CustomerListDto>>(Messages.CustomerNotFound);
            }
            return new SuccessDataResult<List<CustomerListDto>>(result);
        }

        public IResult Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var results = _brandDal.GetAll();
            if (results.Count != 0)
            {
                return new SuccessDataResult<List<Brand>>(results);
            }
            return new ErrorDataResult<List<Brand>>(Messages.NoBrandsRegisteredInTheSystem);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            var result = _brandDal.Get(c => c.Id == brandId);
            if (result != null)
            {
                return new SuccessDataResult<Brand>(result);
            }
            return new ErrorDataResult<Brand>(Messages.BrandNotFound);
        }

        [SecuredOperation("brand.add,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            IResult result = BusinessRules.Run(BrandNameCheck(brand.BrandName));

            if (result != null)
            {
                return result;
            }

            _brandDal.Add(brand);

            return new SuccessResult(Messages.BrandAdded);
        }
        [SecuredOperation("brand.add,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            IResult result = BusinessRules.Run(BrandNameCheck(brand.BrandName),BrandIdCheck(brand.Id));

            if (result != null)
            {
                return result;
            }

            _brandDal.Update(brand);

            return new SuccessResult(Messages.BrandUpdated);
        }
        [SecuredOperation("brand.add,admin")]
        public IResult Delete(int brandId)
        {
            var getBrand = DatabaseBrandCheck(brandId);
            IResult result = BusinessRules.Run(getBrand);

            if (result != null)
            {
                return result;
            }

            _brandDal.Delete(getBrand.Data);

            return new SuccessResult(Messages.BrandDeleted);
        }
        private IResult BrandNameCheck(string brandName)
        {
            if (brandName.Length<3)
            {
                return new ErrorResult(Messages.BrandNameMustContainAtLeastThreeCharacters);
            }
            return new SuccessResult();
        }
        private IDataResult<Brand> DatabaseBrandCheck(int brandId)
        {
            var result = _brandDal.Get(c => c.Id == brandId);
            if (result == null)
            {
                return new ErrorDataResult<Brand>(Messages.BrandNotFound);
            }
            return new SuccessDataResult<Brand>();
        }
        private IResult BrandIdCheck(int brandId)
        {
            if (brandId <= 0)
            {
                return new ErrorResult(Messages.BrandIdIsWrong);
            }

            return new SuccessResult();
        }
    }
}
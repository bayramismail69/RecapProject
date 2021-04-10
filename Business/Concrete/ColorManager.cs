using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll()
        {
            var results = _colorDal.ColorsGetAll();
            if (results.Count==0)
            {
                return new ErrorDataResult<List<Color>>(Messages.ColorNotFound);
            }
            return new SuccessDataResult<List<Color>>(results);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            var results = _colorDal.Get(c=>c.Id==colorId);
            if (results == null)
            {
                return new ErrorDataResult<Color>(Messages.ColorNotFound);
            }
            return new SuccessDataResult<Color>(results);
        }

        public IResult Add(Color color)
        {
            IResult result = BusinessRules.Run(ColorName(color.ColorName));
            if (result!=null)
            {
                return result;
            }
            _colorDal.Add(color);
            return new SuccessResult("Renk basarıyla eklendi");

        }

        private IResult ColorName(string colorName)
        {
            if (_colorDal.GetAll(c=>c.ColorName.ToUpper()==colorName.ToUpper()).Count==0)
            {
                return new ErrorResult("Aynı renk mevcut");
            }
           return new SuccessResult();
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult("Renk Basarıyla güncellendi");
        }

        public IResult Delete(int colorId)
        {
            throw new NotImplementedException();
        }
    }
}
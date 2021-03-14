using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
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
            var results = _colorDal.GetAll();
            if (results.Count==0)
            {
                return new ErrorDataResult<List<Color>>(Messages.ColorNotFound);
            }
            return new SuccessDataResult<List<Color>>(results);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            throw new NotImplementedException();
        }

        public IResult Add(Color color)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Color color)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int colorId)
        {
            throw new NotImplementedException();
        }
    }
}
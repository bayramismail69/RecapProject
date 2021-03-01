using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        public IDataResult<List<Color>> GetAll()
        {
            throw new NotImplementedException();
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
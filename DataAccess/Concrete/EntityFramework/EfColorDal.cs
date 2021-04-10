using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, RecapContext>, IColorDal
    {
        public List<Color> ColorsGetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (RecapContext recapContext = new RecapContext())
            {
                IQueryable<Color> colors = (from color in filter is null ? recapContext.Colors : recapContext.Colors.Where(filter)
                                                orderby color.ColorName   select color);
                return colors.ToList();
            }

        }
    }
}
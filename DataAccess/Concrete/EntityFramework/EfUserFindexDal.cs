using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserFindexDal : EfEntityRepositoryBase<UserFindex, RecapContext>, IUserFindexDal
    {
    }
}